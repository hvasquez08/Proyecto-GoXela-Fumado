<?php
//  GOXELA DELIVERY - CONFIGURACION DEL SITIO WEB
//
//  Este archivo guarda los datos de la base y la clave que usa la consola
//  de C# para conectarse. Es el UNICO archivo que hay que editar.

define('BD_SERVIDOR', 'mysql-hmvasquez.alwaysdata.net');   
define('BD_USUARIO',  'hmvasquez');              
define('BD_CLAVE',    'ESCRIBA_AQUI_SU_PASSWORD');      
define('BD_NOMBRE',   'hmvasquez_goxela');      


//  2. CLAVE DEL PUENTE CON LA CONSOLA DE C#

define('CLAVE_API', 'WilliamAndMajo'); // xddddd la real 

define('ZONA_HORARIA',  'America/Guatemala');
define('EMPRESA',       'GoXela Delivery');
define('CIUDAD',        'Quetzaltenango, Guatemala');
define('MAX_PENDIENTES', 25);   // cuantos pedidos baja la consola por vuelta


//no tocar nada de aqui para abajo

date_default_timezone_set(ZONA_HORARIA);

error_reporting(E_ALL);
ini_set('display_errors', '0');

mysqli_report(MYSQLI_REPORT_OFF);


//  CONEXION A LA BASE DE DATOS
function conectar()
{
    static $conexion = null;
    if ($conexion !== null) {
        return $conexion;
    }

    $conexion = @new mysqli(BD_SERVIDOR, BD_USUARIO, BD_CLAVE, BD_NOMBRE);
    if ($conexion->connect_errno) {
        return null;
    }
    $conexion->set_charset('utf8mb4');
    return $conexion;
}

class ErrorGoXela extends Exception
{
}


//  VALIDACIONES
//  Son EXACTAMENTE las mismas reglas de la clase Validar del programa en C#,
//  para que un pedido aceptado por la pagina tambien sea aceptado por la
//  consola cuando lo baje.
function validar_texto_obligatorio($valor, $campo)
{
    if (trim((string)$valor) === '') {
        throw new ErrorGoXela("El campo '$campo' no puede quedar vacio.");
    }
}

function validar_telefono($telefono)
{
    validar_texto_obligatorio($telefono, 'telefono');
    $limpio = str_replace(array('-', ' '), '', trim($telefono));
    if (strlen($limpio) !== 8 || !ctype_digit($limpio)) {
        throw new ErrorGoXela("El telefono debe tener exactamente 8 digitos. Se recibio: $telefono");
    }
    return $limpio;
}

function validar_correo($correo)
{
    validar_texto_obligatorio($correo, 'correo');
    $arroba = strpos($correo, '@');
    $punto  = strrpos($correo, '.');
    if ($arroba === false || $arroba < 1 || $punto === false ||
        $punto < $arroba + 2 || $punto === strlen($correo) - 1) {
        throw new ErrorGoXela("El correo no tiene un formato valido (ejemplo: nombre@correo.com). Se recibio: $correo");
    }
}

function validar_distancia($distancia)
{
    if ($distancia <= 0) {
        throw new ErrorGoXela("La distancia estimada debe ser mayor que cero. Se recibio: $distancia");
    }
    if ($distancia > 100) {
        throw new ErrorGoXela("La distancia excede el area de cobertura de GoXela (maximo 100 km). Se recibio: $distancia km.");
    }
}

function validar_valor_declarado($valor)
{
    if ($valor < 0) {
        throw new ErrorGoXela("El valor declarado no puede ser negativo. Se recibio: $valor");
    }
    if ($valor > 50000) {
        throw new ErrorGoXela("GoXela no transporta paquetes con valor declarado mayor a Q50,000.00. Se recibio: Q$valor");
    }
}

function validar_peso($peso, $tipoPaquete)
{
    if ($peso <= 0) {
        throw new ErrorGoXela("El peso debe ser mayor que cero. Se recibio: $peso");
    }
    if ($peso > 200) {
        throw new ErrorGoXela("GoXela no transporta paquetes de mas de 200 kg. Se recibio: $peso kg.");
    }
    // Misma regla que la clase del programa en C#.
    if ($tipoPaquete === 'DOCUMENTO' && $peso > 2) {
        throw new ErrorGoXela("Un documento no puede pesar mas de 2 kg. Si pesa mas, elija 'Paquete estandar'. Se recibio: $peso kg.");
    }
}

function validar_tipo_paquete($tipo)
{
    $validos = array('DOCUMENTO', 'ESTANDAR', 'FRAGIL', 'REFRIGERADO');
    $t = strtoupper(trim((string)$tipo));
    if (!in_array($t, $validos, true)) {
        throw new ErrorGoXela("Tipo de paquete no valido: '$tipo'. Use DOCUMENTO, ESTANDAR, FRAGIL o REFRIGERADO.");
    }
    return $t;
}

function validar_tipo_servicio($tipo)
{
    $validos = array('NORMAL', 'PRIORITARIO', 'URGENTE');
    $t = strtoupper(trim((string)$tipo));
    if (!in_array($t, $validos, true)) {
        throw new ErrorGoXela("Tipo de servicio no valido: '$tipo'. Use NORMAL, PRIORITARIO o URGENTE.");
    }
    return $t;
}

// Convierte un texto a numero aceptando punto o coma decimal,
// igual que Validar.ConvertirANumero en C#.
function convertir_a_numero($texto, $campo)
{
    $limpio = str_replace(',', '.', trim((string)$texto));
    if ($limpio === '' || !is_numeric($limpio)) {
        throw new ErrorGoXela("El campo '$campo' debe ser un numero. Se recibio: '$texto'.");
    }
    return (float)$limpio;
}


//  CALCULO DE LA TARIFA
//  Es la misma formula del metodo CalcularTarifa de la clase SistemaGoXela,
//  con la diferencia de que aqui todavia no hay vehiculo asignado: por eso
//  el total que muestra la pagina siempre es un ESTIMADO.

// Polimorfismo del C# : cada tipo de paquete tiene su formula.
function tarifa_base_del_paquete($tipoPaquete, $km, $peso)
{
    if ($tipoPaquete === 'DOCUMENTO') {
        return 8.00 + (2.50 * $km);
    }
    if ($tipoPaquete === 'FRAGIL') {
        $normal = 10.00 + (3.50 * $km) + (2.00 * $peso);
        return ($normal * 1.35) + 15.00;
    }
    if ($tipoPaquete === 'REFRIGERADO') {
        $normal = 10.00 + (3.50 * $km) + (2.50 * $peso);
        return $normal + 25.00 + (1.50 * $km);
    }
    return 10.00 + (3.50 * $km) + (2.00 * $peso);  
}

function factor_del_servicio($tipoServicio)
{
    if ($tipoServicio === 'PRIORITARIO') {
        return 1.25;
    }
    if ($tipoServicio === 'URGENTE') {
        return 1.60;
    }
    return 1.00;
}

// Devuelve un arreglo con tarifa base, recargos, descuentos y total.
function calcular_tarifa($tipoPaquete, $tipoServicio, $km, $peso, $valorDeclarado)
{
    $tarifaBase = tarifa_base_del_paquete($tipoPaquete, $km, $peso) * factor_del_servicio($tipoServicio);

    $recargos = 0.0;

    // Recargo 1: fin de semana.
    $dia = (int)date('w');           // 0 = domingo, 6 = sabado
    if ($dia === 0 || $dia === 6) {
        $recargos += 10.00;
    }

    // Recargo 2: seguro del 2% cuando el paquete vale mas de Q2,000.
    if ($valorDeclarado > 2000) {
        $recargos += $tarifaBase * 0.02;
    }

    $descuentos = 0.0;

    if ($km <= 2) {
        $descuentos += 5.00;
    }

    $total = $tarifaBase + $recargos - $descuentos;
    if ($total < 0) {
        $total = 0;
    }

    return array(
        'tarifa_base' => round($tarifaBase, 2),
        'recargos'    => round($recargos, 2),
        'descuentos'  => round($descuentos, 2),
        'total'       => round($total, 2)
    );
}

function condiciones_transporte($tipoPaquete)
{
    if ($tipoPaquete === 'DOCUMENTO') {
        return 'Debe viajar en sobre cerrado y protegido de la lluvia.';
    }
    if ($tipoPaquete === 'FRAGIL') {
        return 'Embalaje con burbuja, no apilar y manejar con cuidado.';
    }
    if ($tipoPaquete === 'REFRIGERADO') {
        return 'Cadena de frio a 4.0 grados o menos, entrega inmediata.';
    }
    return 'Transporte normal.';
}


function explicar_estado($estado)
{
    $textos = array(
        'PENDIENTE'      => 'Su pedido fue recibido en la pagina y esta esperando que la central lo tome. Esto tarda unos segundos.',
        'SOLICITADA'     => 'Su pedido ya entro al sistema de la empresa y esta esperando que se le asigne un repartidor.',
        'ASIGNADA'       => 'Ya se le asigno un repartidor y un vehiculo. Pronto pasaran a recoger el paquete.',
        'RECOGIDA'       => 'El repartidor ya recogio el paquete en la direccion de origen.',
        'EN RUTA'        => 'El repartidor va en camino a la direccion de destino.',
        'ENTREGADA'      => 'El paquete ya fue entregado al destinatario. Gracias por preferirnos.',
        'CANCELADA'      => 'Este pedido fue cancelado y no se realizara.',
        'REPROGRAMADA'   => 'Este pedido fue reprogramado para otra fecha.',
        'CON INCIDENCIA' => 'Se presento un problema durante la entrega. Abajo aparece el detalle.',
        'RECHAZADA'      => 'La central no pudo aceptar este pedido. Abajo aparece el motivo.'
    );
    if (isset($textos[$estado])) {
        return $textos[$estado];
    }
    return 'Estado del pedido: ' . $estado;
}

function clase_del_estado($estado)
{
    if ($estado === 'ENTREGADA') {
        return 'ok';
    }
    if ($estado === 'CANCELADA' || $estado === 'RECHAZADA' || $estado === 'CON INCIDENCIA') {
        return 'malo';
    }
    if ($estado === 'PENDIENTE') {
        return 'espera';
    }
    return 'activo';
}

function h($texto)
{
    return htmlspecialchars((string)$texto, ENT_QUOTES, 'UTF-8');
}

function q($numero)
{
    return 'Q' . number_format((float)$numero, 2);
}

function encabezado($titulo, $subtitulo = '')
{
    $t = h($titulo);
    echo "<!DOCTYPE html>\n";
    echo "<html lang=\"es\">\n<head>\n";
    echo "<meta charset=\"utf-8\">\n";
    echo "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\n";
    echo "<title>" . h(EMPRESA) . " - $t</title>\n";
    echo "<link rel=\"stylesheet\" href=\"estilos.css\">\n";
    echo "</head>\n<body>\n";
    echo "<header class=\"barra\">\n";
    echo "  <a class=\"marca\" href=\"index.php\"><span class=\"logo\">GX</span> " . h(EMPRESA) . "</a>\n";
    echo "  <nav>\n";
    echo "    <a href=\"index.php\">Solicitar</a>\n";
    echo "    <a href=\"estado.php\">Consultar</a>\n";
    echo "  </nav>\n";
    echo "</header>\n";
    echo "<main>\n";
    echo "<h1>$t</h1>\n";
    if ($subtitulo !== '') {
        echo "<p class=\"sub\">" . h($subtitulo) . "</p>\n";
    }
}

function pie()
{
    echo "</main>\n";
    echo "<footer>\n";
    echo "  <p>" . h(EMPRESA) . " &mdash; " . h(CIUDAD) . "</p>\n";
    echo "  <p class=\"chico\">Proyecto de Programacion Avanzada</p>\n";
    echo "</footer>\n";
    echo "</body>\n</html>\n";
}

function fila($titulo, $valor)
{
    echo "<tr><th>" . h($titulo) . "</th><td>" . h($valor) . "</td></tr>\n";
}

function anotar_en_bitacora($conexion, $accion, $detalle)
{
    $orden = $conexion->prepare(
        "INSERT INTO bitacora (fecha, accion, detalle, ip) VALUES (?,?,?,?)");
    if ($orden === false) {
        return;
    }
    $ahora = date('Y-m-d H:i:s');
    $ip    = isset($_SERVER['REMOTE_ADDR']) ? $_SERVER['REMOTE_ADDR'] : '';
    $orden->bind_param('ssss', $ahora, $accion, $detalle, $ip);
    $orden->execute();
    $orden->close();
}
