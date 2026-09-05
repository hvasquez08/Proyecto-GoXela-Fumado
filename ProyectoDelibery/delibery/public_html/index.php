<?php
require_once 'config.php';

function valor_inicial($porDefecto = '')
{
    return h($porDefecto);
}

encabezado('Solicitar una entrega', 'Servicio de mensajeria y paqueteria en ' . CIUDAD . '.');
?>

<div class="cuadricula">

  <form action="pedido.php" method="post" class="tarjeta" id="formulario">

    <h2>1. Sus datos</h2>
    <div class="campo">
      <label for="nombre">Nombre completo</label>
      <input type="text" id="nombre" name="nombre" maxlength="120" required
             value="<?php echo valor_inicial(); ?>" placeholder="Ana Lucia Lopez">
    </div>
    <div class="dos">
      <div class="campo">
        <label for="telefono">Telefono (8 digitos)</label>
        <input type="text" id="telefono" name="telefono" maxlength="12" required
               inputmode="numeric" value="<?php echo valor_inicial(); ?>" placeholder="55112233">
      </div>
      <div class="campo">
        <label for="correo">Correo electronico</label>
        <input type="email" id="correo" name="correo" maxlength="150" required
               value="<?php echo valor_inicial(); ?>" placeholder="ana@correo.com">
      </div>
    </div>

    <h2>2. Direcciones</h2>
    <div class="campo">
      <label for="origen">Direccion de origen <span class="pista">donde se recoge</span></label>
      <input type="text" id="origen" name="origen" maxlength="200" required
             value="<?php echo valor_inicial(); ?>" placeholder="5a calle 12-30 zona 1, Quetzaltenango">
    </div>
    <div class="campo">
      <label for="destino">Direccion de destino <span class="pista">donde se entrega</span></label>
      <input type="text" id="destino" name="destino" maxlength="200" required
             value="<?php echo valor_inicial(); ?>" placeholder="Calzada Independencia 4-15 zona 3">
    </div>
    <div class="campo">
      <label for="distancia">Distancia estimada en kilometros <span class="pista">maximo 100</span></label>
      <input type="number" id="distancia" name="distancia" step="0.1" min="0.1" max="100" required
             value="<?php echo valor_inicial('5'); ?>">
    </div>

    <h2>3. El paquete</h2>
    <div class="campo">
      <label for="descripcion">Descripcion del contenido</label>
      <input type="text" id="descripcion" name="descripcion" maxlength="200" required
             value="<?php echo valor_inicial(); ?>" placeholder="Caja con repuestos de computadora">
    </div>
    <div class="campo">
      <label for="tipopaquete">Tipo de paquete</label>
      <select id="tipopaquete" name="tipopaquete">
        <option value="DOCUMENTO">Documento (maximo 2 kg)</option>
        <option value="ESTANDAR" selected>Paquete estandar</option>
        <option value="FRAGIL">Paquete fragil (+35% y Q15 de embalaje)</option>
        <option value="REFRIGERADO">Producto refrigerado (cadena de frio)</option>
      </select>
    </div>
    <div class="dos">
      <div class="campo">
        <label for="peso">Peso en kilogramos</label>
        <input type="number" id="peso" name="peso" step="0.1" min="0.1" required
               value="<?php echo valor_inicial('1'); ?>">
      </div>
      <div class="campo">
        <label for="valor">Valor declarado (Q) <span class="pista">maximo 50,000</span></label>
        <input type="number" id="valor" name="valor" step="0.01" min="0" max="50000" required
               value="<?php echo valor_inicial('100'); ?>">
      </div>
    </div>

    <h2>4. Tipo de servicio</h2>
    <div class="campo">
      <label for="servicio">Servicio</label>
      <select id="servicio" name="servicio">
        <option value="NORMAL" selected>Normal (sin recargo)</option>
        <option value="PRIORITARIO">Prioritario (25% mas)</option>
        <option value="URGENTE">Urgente (60% mas)</option>
      </select>
    </div>

    <p class="acciones">
      <button type="submit">Enviar pedido</button>
      <a class="boton-plano" href="estado.php">Consultar un pedido</a>
    </p>
  </form>

  <aside class="lateral">
    <div class="tarjeta calculadora">
      <h2>Costo estimado</h2>
      <p class="monto" id="monto">Q0.00</p>
      <p class="chico" id="detalle">Llene el formulario para ver el estimado.</p>
      <p class="chico">El total definitivo se confirma cuando la central le
         asigna el vehiculo que hara la entrega.</p>
    </div>

    <div class="tarjeta">
      <h2>Como funciona</h2>
      <ol class="pasos">
        <li>Usted envia el formulario y recibe un <b>codigo de seguimiento</b>.</li>
        <li>La central de GoXela baja el pedido a su sistema en pocos segundos.</li>
        <li>Se le asigna un repartidor y un vehiculo segun el tipo de paquete.</li>
        <li>Puede seguir el avance en <a href="estado.php">Consultar</a> con su codigo.</li>
      </ol>
    </div>

    <div class="tarjeta">
      <h2>Lo que no transportamos</h2>
      <ul class="lista">
        <li>Paquetes con valor declarado mayor a Q50,000.00</li>
        <li>Destinos a mas de 100 km de Quetzaltenango</li>
        <li>Documentos de mas de 2 kg (van como paquete estandar)</li>
      </ul>
    </div>
  </aside>

</div>

<script>

(function () {
  var f = document.getElementById('formulario');
  var monto = document.getElementById('monto');
  var detalle = document.getElementById('detalle');

  function tarifaBase(tipo, km, peso) {
    if (tipo === 'DOCUMENTO') { return 8.00 + 2.50 * km; }
    if (tipo === 'FRAGIL')    { return (10.00 + 3.50 * km + 2.00 * peso) * 1.35 + 15.00; }
    if (tipo === 'REFRIGERADO') { return (10.00 + 3.50 * km + 2.50 * peso) + 25.00 + 1.50 * km; }
    return 10.00 + 3.50 * km + 2.00 * peso;
  }

  function factor(servicio) {
    if (servicio === 'PRIORITARIO') { return 1.25; }
    if (servicio === 'URGENTE')     { return 1.60; }
    return 1.00;
  }

  function recalcular() {
    var km    = parseFloat(f.distancia.value) || 0;
    var peso  = parseFloat(f.peso.value) || 0;
    var valor = parseFloat(f.valor.value) || 0;
    var tipo  = f.tipopaquete.value;
    var serv  = f.servicio.value;

    if (km <= 0 || peso <= 0) {
      monto.textContent = 'Q0.00';
      detalle.textContent = 'Llene la distancia y el peso para ver el estimado.';
      return;
    }

    var base = tarifaBase(tipo, km, peso) * factor(serv);
    var recargos = 0;
    var dia = new Date().getDay();
    if (dia === 0 || dia === 6) { recargos += 10.00; }
    if (valor > 2000) { recargos += base * 0.02; }
    var descuentos = (km <= 2) ? 5.00 : 0;
    var total = Math.max(0, base + recargos - descuentos);

    monto.textContent = 'Q' + total.toFixed(2);
    detalle.textContent = 'Tarifa Q' + base.toFixed(2) +
                          '  |  recargos Q' + recargos.toFixed(2) +
                          '  |  descuentos Q' + descuentos.toFixed(2);
  }

  f.addEventListener('input', recalcular);
  f.addEventListener('change', recalcular);
  recalcular();
})();
</script>

<?php pie(); ?>
