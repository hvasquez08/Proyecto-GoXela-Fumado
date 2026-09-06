<?php

//  Aqui llega lo que el cliente escribio en index.php. Se revisa con las
//  MISMAS reglas del programa en C#, se calcula el estimado y se guarda en
//  MySQL con estado PENDIENTE.
//
//  PENDIENTE quiere decir: "ya esta guardado en la pagina, falta que la
//  consola de la empresa lo baje". Eso lo hace api.php cuando el programa
//  en C# se conecta.

require_once 'config.php';

if ($_SERVER['REQUEST_METHOD'] !== 'POST') {
    header('Location: index.php');
    exit;
}

function campo($nombre)
{
    return isset($_POST[$nombre]) ? trim((string)$_POST[$nombre]) : '';
}

function pagina_de_error($mensaje)
{
    encabezado('No se pudo registrar el pedido');
    echo "<div class=\"aviso malo\">\n";
    echo "  <b>Su pedido NO fue registrado.</b><br>\n";
    echo "  Motivo: " . h($mensaje) . "\n";
    echo "</div>\n";
    echo "<p>Regrese al formulario, corrija ese dato y vuelva a enviarlo.\n";
    echo "   Los datos que ya escribio siguen ahi.</p>\n";
    echo "<p class=\"acciones\">\n";
    echo "  <a class=\"boton\" href=\"javascript:history.back()\">Regresar y corregir</a>\n";
    echo "  <a class=\"boton-plano\" href=\"index.php\">Empezar de nuevo</a>\n";
    echo "</p>\n";
    pie();
    exit;
}

$conexion = conectar();
if ($conexion === null) {
    pagina_de_error('En este momento no se puede conectar con la base de datos. Intente de nuevo en unos minutos.');
}

try {
    $nombre      = campo('nombre');
    $telefono    = campo('telefono');
    $correo      = campo('correo');
    $origen      = campo('origen');
    $destino     = campo('destino');
    $descripcion = campo('descripcion');

    validar_texto_obligatorio($nombre, 'nombre');
    $telefono = validar_telefono($telefono);
    validar_correo($correo);
    validar_texto_obligatorio($origen, 'direccion de origen');
    validar_texto_obligatorio($destino, 'direccion de destino');
    validar_texto_obligatorio($descripcion, 'descripcion del paquete');

    $tipoPaquete  = validar_tipo_paquete(campo('tipopaquete'));
    $tipoServicio = validar_tipo_servicio(campo('servicio'));

    $peso      = convertir_a_numero(campo('peso'), 'peso');
    $valor     = convertir_a_numero(campo('valor'), 'valor declarado');
    $distancia = convertir_a_numero(campo('distancia'), 'distancia');

    validar_peso($peso, $tipoPaquete);
    validar_valor_declarado($valor);
    validar_distancia($distancia);

    $tarifa = calcular_tarifa($tipoPaquete, $tipoServicio, $distancia, $peso, $valor);

    $codigoWeb = 'TMP-' . substr(str_replace('.', '', uniqid('', true)), -12);
    $ahora     = date('Y-m-d H:i:s');
    $ip        = isset($_SERVER['REMOTE_ADDR']) ? $_SERVER['REMOTE_ADDR'] : '';

    $sql = "INSERT INTO pedidos
            (codigo_web, nombre, telefono, correo, origen, destino, descripcion,
             tipo_paquete, tipo_servicio, peso, valor_declarado, distancia,
             tarifa_base, recargos, descuentos, total, total_estimado,
             estado, bajado, fecha, ip)
            VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,1,'PENDIENTE',0,?,?)";

    $orden = $conexion->prepare($sql);
    if ($orden === false) {
        throw new ErrorGoXela('No se pudo preparar el guardado. Avise a la empresa.');
    }

    $montoBase       = $tarifa['tarifa_base'];
    $montoRecargos   = $tarifa['recargos'];
    $montoDescuentos = $tarifa['descuentos'];
    $montoTotal      = $tarifa['total'];

    $orden->bind_param(
        'sssssssssdddddddss',
        $codigoWeb, $nombre, $telefono, $correo, $origen, $destino, $descripcion,
        $tipoPaquete, $tipoServicio, $peso, $valor, $distancia,
        $montoBase, $montoRecargos, $montoDescuentos, $montoTotal,
        $ahora, $ip
    );

    if (!$orden->execute()) {
        throw new ErrorGoXela('No se pudo guardar el pedido. Intente de nuevo.');
    }
    $idPedido = (int)$conexion->insert_id;
    $orden->close();

    $codigoWeb = 'GX-' . str_pad((string)$idPedido, 6, '0', STR_PAD_LEFT);
    $cambio = $conexion->prepare("UPDATE pedidos SET codigo_web = ? WHERE id = ?");
    $cambio->bind_param('si', $codigoWeb, $idPedido);
    $cambio->execute();
    $cambio->close();

} catch (ErrorGoXela $error) {
    pagina_de_error($error->getMessage());
} catch (Exception $error) {
    pagina_de_error('Ocurrio un problema inesperado. Intente de nuevo en unos minutos.');
}


encabezado('Pedido registrado correctamente');
?>

<div class="aviso ok">
  Su pedido quedo guardado. La central de GoXela lo va a tomar en unos segundos.
</div>

<div class="codigo-grande">
  <span class="chico">Guarde este codigo de seguimiento</span>
  <strong><?php echo h($codigoWeb); ?></strong>
</div>

<div class="cuadricula">
  <div class="tarjeta">
    <h2>Resumen del pedido</h2>
    <table class="ficha">
      <?php
      fila('Codigo de seguimiento', $codigoWeb);
      fila('Fecha', date('d/m/Y H:i'));
      fila('Cliente', $nombre);
      fila('Telefono', $telefono);
      fila('Paquete', $tipoPaquete . ' - ' . $descripcion);
      fila('Peso', number_format($peso, 2) . ' kg');
      fila('Condiciones', condiciones_transporte($tipoPaquete));
      fila('Origen', $origen);
      fila('Destino', $destino);
      fila('Distancia', number_format($distancia, 1) . ' km');
      fila('Tipo de servicio', $tipoServicio);
      fila('Valor declarado', q($valor));
      ?>
    </table>
  </div>

  <div class="tarjeta">
    <h2>Cobro estimado</h2>
    <table class="ficha">
      <?php
      fila('Tarifa base', q($tarifa['tarifa_base']));
      fila('Recargos', q($tarifa['recargos']));
      fila('Descuentos', q($tarifa['descuentos']));
      ?>
      <tr class="destacada"><th>TOTAL ESTIMADO</th><td><?php echo q($tarifa['total']); ?></td></tr>
    </table>
    <p class="chico">El total puede variar un poco cuando la empresa le asigne
       el vehiculo que hara la entrega, porque cada vehiculo tiene un costo
       de operacion distinto por kilometro.</p>
    <p class="acciones">
      <a class="boton" href="estado.php?codigo=<?php echo urlencode($codigoWeb); ?>">Ver el estado de este pedido</a>
      <a class="boton-plano" href="index.php">Solicitar otra entrega</a>
    </p>
  </div>
</div>

<?php pie(); ?>
