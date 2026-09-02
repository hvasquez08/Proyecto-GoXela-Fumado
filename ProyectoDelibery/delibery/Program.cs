using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delibery
{
    internal class Program
    {
        public class Persona
        {
            private string codigo;

            public string Codigo
            {
                get { return codigo; }
                set { codigo = value; }
            }

            private string nombrecompleto;

            public string NombreCompleto
            {
                get { return nombrecompleto; }
                set { nombrecompleto = value; }
            }

            private string telefono;
            public string Telefono
            {
                get { return telefono; }
                set { telefono = value; }
            }

            public Persona(string codigo, string nombrecompleto, string telefono)
            {
                Codigo = codigo;
                NombreCompleto = nombrecompleto;
                Telefono = telefono;
            }

            public void MostrarInformacion()
            {
                Console.WriteLine("Código: " + Codigo);
                Console.WriteLine("Nombre completo: " + NombreCompleto);
                Console.WriteLine("Teléfono: " + Telefono);
            }

            public bool ValidarDatos()
            {
                if (string.IsNullOrWhiteSpace(Codigo))
                {
                    Console.WriteLine("Error: El código no puede estar vacío.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(NombreCompleto))
                {
                    Console.WriteLine("Error: El nombre completo no puede estar vacío.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(Telefono))
                {
                    Console.WriteLine("Error: El teléfono no puede estar vacío.");
                    return false;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(Telefono, @"^\d{8,}$"))
                {
                    Console.WriteLine("Error: El teléfono debe contener solo dígitos y tener al menos 8 caracteres.");
                    return false;
                }

                Console.WriteLine("Datos validados correctamente.");
                return true;
            }

        }


        public class Cliente : Persona
        {

            private string correo;

            public string Correo
            {
                get { return correo; }
                set { correo = value; }
            }


            private string direccion;
            public string Direccion
            {
                get { return direccion; }
                set { direccion = value; }
            }

            private int cantidad;
            public int Cantidad
            {
                get { return cantidad; }
                set { cantidad = value; }
            }


            public Cliente(string codigo, string nombrecompleto, string telefono, string correo, string direccion, int cantidad) : base(codigo, nombrecompleto, telefono)
            {
                Correo = correo;
                Direccion = direccion;
                Cantidad = cantidad;
            }

            public void MostrarInformacionCliente()
            {
                MostrarInformacion();
                Console.WriteLine("Correo: " + Correo);
                Console.WriteLine("Dirección: " + Direccion);
                Console.WriteLine("Cantidad: " + Cantidad);
            }
            public void incrementarSolicitud()
            {
                Cantidad++;
            }
            public new bool ValidarDatos()
            {
                if (!base.ValidarDatos())
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(Correo))
                {
                    Console.WriteLine("Error: El correo no puede estar vacío.");
                    return false;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(Correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    Console.WriteLine("Error: El correo no tiene un formato válido.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(Direccion))
                {
                    Console.WriteLine("Error: La dirección no puede estar vacía.");
                    return false;
                }

                if (Cantidad <= 0)
                {
                    Console.WriteLine("Error: La cantidad debe ser mayor a 0.");
                    return false;
                }

                Console.WriteLine("Datos del cliente validados correctamente.");
                return true;
            }

        }
        public class Repartidor : Persona
        {
            private string nummerolicencia;
            public string Nummerolicencia
            {
                get { return nummerolicencia; }
                set { nummerolicencia = value; }

                // ay que esperar que herbert haga la clase vehiculo para poder hacer la clase repartidor
                // YA ESTA LA CLASE VEHICULO, YA PUEDO HACER LA CLASE REPARTIDOR XDDD

            }

            private string tipolicencia;
            public string Tipolicencia
            {
                get { return tipolicencia; }
                set { tipolicencia = value; }
            }

            private string estado;
            public string Estado
            {
                get { return estado; }
                set { estado = value; }
            }

            private int entregasrealizadas;
            public int Entregasrealizadas
            {
                get { return entregasrealizadas; }
                set { entregasrealizadas = value; }
            }

            private double calificacion;
            public double Calificacion
            {
                get { return calificacion; }
                set { calificacion = value; }
            }

            public Repartidor(string codigo, string nombrecompleto, string telefono, string nummerolicencia, string tipolicencia) : base(codigo, nombrecompleto, telefono)
            {
                Nummerolicencia = nummerolicencia;
                Tipolicencia = tipolicencia;
                Estado = "DISPONIBLE";
                Entregasrealizadas = 0;
                Calificacion = 0;
            }

            public void MostrarInformacionRepartidor()
            {
                MostrarInformacion();
                Console.WriteLine("Número de licencia: " + Nummerolicencia);
                Console.WriteLine("Tipo de licencia: " + Tipolicencia);
                Console.WriteLine("Estado: " + Estado);
                Console.WriteLine("Entregas realizadas: " + Entregasrealizadas);
                Console.WriteLine("Calificación: " + Calificacion);
            }

            public void incrementarEntrega()
            {
                Entregasrealizadas++;
            }

            public new bool ValidarDatos()
            {
                if (!base.ValidarDatos())
                {
                    return false;
                }

                if (Tipolicencia != "NINGUNA" && Tipolicencia != "M" && Tipolicencia != "A" && Tipolicencia != "B")
                {
                    Console.WriteLine("Error: El tipo de licencia debe ser NINGUNA, M, A o B.");
                    return false;
                }

                if (Tipolicencia != "NINGUNA" && string.IsNullOrWhiteSpace(Nummerolicencia))
                {
                    Console.WriteLine("Error: Si el repartidor tiene licencia debe llevar número de licencia.");
                    return false;
                }

                if (Estado != "DISPONIBLE" && Estado != "ASIGNADO" && Estado != "FUERA DE SERVICIO")
                {
                    Console.WriteLine("Error: El estado debe ser DISPONIBLE, ASIGNADO o FUERA DE SERVICIO.");
                    return false;
                }

                if (Calificacion < 0 || Calificacion > 5)
                {
                    Console.WriteLine("Error: La calificación debe estar entre 0 y 5.");
                    return false;
                }

                Console.WriteLine("Datos del repartidor validados correctamente.");
                return true;
            }

            public bool TieneLicencia(string licenciapedida)
            {
                if (licenciapedida == "NINGUNA")
                {
                    return true;
                }

                if (licenciapedida == "M")
                {
                    if (Tipolicencia == "M" || Tipolicencia == "A" || Tipolicencia == "B")
                    {
                        return true;
                    }
                    return false;
                }

                if (licenciapedida == "A o B")
                {
                    if (Tipolicencia == "A" || Tipolicencia == "B")
                    {
                        return true;
                    }
                    return false;
                }

                return false;
            }

        }
        class Vehiculo
        {
            private String codigo;

            public String MyCodigo
            {
                get { return codigo; }
                set { codigo = value; }
            }
            private String placa;

            public String MyPlaca
            {
                get { return placa; }
                set { placa = value; }
            }
            private String marca;

            public String MyMarca
            {
                get { return marca; }
                set { marca = value; }
            }
            private string modelo;

            public string MyModelo
            {
                get { return modelo; }
                set { modelo = value; }
            }
            private double cargamaxima;

            public double Mycargamaxima
            {
                get { return cargamaxima; }
                set { cargamaxima = value; }
            }
            private double costoOperativo;

            public double MycostoOperativo
            {
                get { return costoOperativo; }
                set { costoOperativo = value; }
            }
            private string tipoLicencia;

            public string MytipoLicencia
            {
                get { return tipoLicencia; }
                set { tipoLicencia = value; }
            }

            public Vehiculo(string codigo, string placa, string marca, string modelo, double cargaMaxima, double costoOperativo, string tipoLicencia)
            {
                MyCodigo = codigo;
                MyPlaca = placa;
                MyMarca = marca;
                MyModelo = modelo;
                Mycargamaxima = cargaMaxima;
                MycostoOperativo = costoOperativo;
                MytipoLicencia = tipoLicencia;
            }

            private string estado = "DISPONIBLE";
            public string Estado
            {
                get { return estado; }
                set { estado = value; }
            }

            public void MostrarInformacionVehiculo()
            {
                Console.WriteLine("Código: " + MyCodigo);
                Console.WriteLine("Placa: " + MyPlaca);
                Console.WriteLine("Marca: " + MyMarca);
                Console.WriteLine("Modelo: " + MyModelo);
                Console.WriteLine("Carga máxima: " + Mycargamaxima + " kg");
                Console.WriteLine("Costo operativo: Q" + MycostoOperativo);
                Console.WriteLine("Tipo de licencia: " + MytipoLicencia);
                Console.WriteLine("Estado: " + Estado);
            }

            public bool ValidarDatos()
            {
                if (string.IsNullOrWhiteSpace(MyCodigo))
                {
                    Console.WriteLine("Error: El código del vehículo no puede estar vacío.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(MyPlaca))
                {
                    Console.WriteLine("Error: La placa no puede estar vacía.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(MyMarca))
                {
                    Console.WriteLine("Error: La marca no puede estar vacía.");
                    return false;
                }

                if (Mycargamaxima <= 0)
                {
                    Console.WriteLine("Error: La carga máxima debe ser mayor a 0.");
                    return false;
                }

                if (MycostoOperativo < 0)
                {
                    Console.WriteLine("Error: El costo operativo no puede ser negativo.");
                    return false;
                }

                if (MytipoLicencia != "NINGUNA" && MytipoLicencia != "M" && MytipoLicencia != "A o B")
                {
                    Console.WriteLine("Error: El tipo de licencia debe ser NINGUNA, M o A o B.");
                    return false;
                }

                if (Estado != "DISPONIBLE" && Estado != "ASIGNADO" && Estado != "EN MANTENIMIENTO")
                {
                    Console.WriteLine("Error: El estado debe ser DISPONIBLE, ASIGNADO o EN MANTENIMIENTO.");
                    return false;
                }

                Console.WriteLine("Datos del vehículo validados correctamente.");
                return true;
            }

        }

        class bicicleta : Vehiculo
        {
            private int myVar;

            public int MyProperty
            {
                get { return myVar; }
                set { myVar = value; }
            }

            public bicicleta(string codigo, string placa, string marca, string modelo, double cargaMaxima, double costoOperativo, string tipoLicencia) : base(codigo, placa, marca, modelo, cargaMaxima, costoOperativo, tipoLicencia)
            {

            }

            public string Tipo()
            {
                return "BICICLETA";
            }

            public string LicenciaRequerida()
            {
                return "NINGUNA";
            }

            public double CalcularCostoOperativo(double distanciaKm)
            {
                return MycostoOperativo * distanciaKm;
            }

            public bool PuedeTransportar(Paquete paquete)
            {
                if (paquete.Peso > Mycargamaxima)
                {
                    Console.WriteLine("La bicicleta soporta " + Mycargamaxima + " kg y el paquete pesa " + paquete.Peso + " kg.");
                    return false;
                }

                if (paquete.Valordeclarado > 1000)
                {
                    Console.WriteLine("Por seguridad la bicicleta no lleva paquetes de más de Q1000.");
                    return false;
                }

                return true;
            }

            public bool PuedeTransportar(PaqueteFragil paquete)
            {
                if (paquete.Peso > 5)
                {
                    Console.WriteLine("Un paquete frágil de más de 5 kg no viaja seguro en bicicleta.");
                    return false;
                }

                return PuedeTransportar((Paquete)paquete);
            }

            public bool PuedeTransportar(ProductoRefrigerado paquete)
            {
                Console.WriteLine("La bicicleta no tiene equipo de refrigeración.");
                return false;
            }
        }
        class Motocicleta : Vehiculo
        {
            public Motocicleta(string codigo, string placa, string marca, string modelo, double cargaMaxima, double costoOperativo, string tipoLicencia) : base(codigo, placa, marca, modelo, cargaMaxima, costoOperativo, tipoLicencia)

            {

            }

            private bool tienecajatermica;
            public bool Tienecajatermica
            {
                get { return tienecajatermica; }
                set { tienecajatermica = value; }
            }

            public string Tipo()
            {
                return "MOTOCICLETA";
            }

            public string LicenciaRequerida()
            {
                return "M";
            }

            public double CalcularCostoOperativo(double distanciaKm)
            {
                return (MycostoOperativo * distanciaKm) + 5.00;
            }

            public bool PuedeTransportar(Paquete paquete)
            {
                if (paquete.Peso > Mycargamaxima)
                {
                    Console.WriteLine("La motocicleta soporta " + Mycargamaxima + " kg y el paquete pesa " + paquete.Peso + " kg.");
                    return false;
                }

                if (paquete.Valordeclarado > 15000)
                {
                    Console.WriteLine("Por seguridad la motocicleta no lleva paquetes de más de Q15000.");
                    return false;
                }

                return true;
            }

            public bool PuedeTransportar(ProductoRefrigerado paquete)
            {
                if (Tienecajatermica == false)
                {
                    Console.WriteLine("Esta motocicleta no tiene caja térmica.");
                    return false;
                }

                return PuedeTransportar((Paquete)paquete);
            }
        }
        class automovil : Vehiculo
        {
            public automovil(string codigo, string placa, string marca, string modelo, double cargaMaxima, double costoOperativo, string tipoLicencia) : base(codigo, placa, marca, modelo, cargaMaxima, costoOperativo, tipoLicencia)

            {

            }

            private int numerodepuertas;
            public int Numerodepuertas
            {
                get { return numerodepuertas; }
                set { numerodepuertas = value; }
            }

            public string Tipo()
            {
                return "AUTOMOVIL";
            }

            public string LicenciaRequerida()
            {
                return "A o B";
            }

            public double CalcularCostoOperativo(double distanciaKm)
            {
                return (MycostoOperativo * distanciaKm) + 12.00;
            }

            public bool PuedeTransportar(Paquete paquete)
            {
                if (paquete.Peso > Mycargamaxima)
                {
                    Console.WriteLine("El automóvil soporta " + Mycargamaxima + " kg y el paquete pesa " + paquete.Peso + " kg.");
                    return false;
                }

                return true;
            }
        }
        public class Paquete
        {
            private string codigo;
            public string Codigo
            {
                get { return codigo; }
                set { codigo = value; }
            }

            private string descripcion;
            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }

            private double peso;
            public double Peso
            {
                get { return peso; }
                set { peso = value; }
            }

            private double valordeclarado;
            public double Valordeclarado
            {
                get { return valordeclarado; }
                set { valordeclarado = value; }
            }

            private string direccionorigen;
            public string Direccionorigen
            {
                get { return direccionorigen; }
                set { direccionorigen = value; }
            }

            private string direcciondestino;
            public string Direcciondestino
            {
                get { return direcciondestino; }
                set { direcciondestino = value; }
            }

            private string estado = "REGISTRADO";
            public string Estado
            {
                get { return estado; }
                set { estado = value; }
            }

            public Paquete(string codigo, string descripcion, double peso, double valordeclarado, string direccionorigen, string direcciondestino)
            {
                Codigo = codigo;
                Descripcion = descripcion;
                Peso = peso;
                Valordeclarado = valordeclarado;
                Direccionorigen = direccionorigen;
                Direcciondestino = direcciondestino;
            }

            public void MostrarInformacionPaquete()
            {
                Console.WriteLine("Código: " + Codigo);
                Console.WriteLine("Descripción: " + Descripcion);
                Console.WriteLine("Peso: " + Peso + " kg");
                Console.WriteLine("Valor declarado: Q" + Valordeclarado);
                Console.WriteLine("Dirección de origen: " + Direccionorigen);
                Console.WriteLine("Dirección de destino: " + Direcciondestino);
                Console.WriteLine("Estado: " + Estado);
            }

            public bool ValidarDatos()
            {
                if (string.IsNullOrWhiteSpace(Codigo))
                {
                    Console.WriteLine("Error: El código del paquete no puede estar vacío.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(Descripcion))
                {
                    Console.WriteLine("Error: La descripción no puede estar vacía.");
                    return false;
                }

                if (Peso <= 0)
                {
                    Console.WriteLine("Error: El peso debe ser mayor a 0.");
                    return false;
                }

                if (Valordeclarado < 0)
                {
                    Console.WriteLine("Error: El valor declarado no puede ser negativo.");
                    return false;
                }

                if (Valordeclarado > 50000)
                {
                    Console.WriteLine("Error: No se transportan paquetes de más de Q50000.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(Direccionorigen))
                {
                    Console.WriteLine("Error: La dirección de origen no puede estar vacía.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(Direcciondestino))
                {
                    Console.WriteLine("Error: La dirección de destino no puede estar vacía.");
                    return false;
                }

                if (Estado != "REGISTRADO" && Estado != "ASIGNADO" && Estado != "EN TRANSITO" && Estado != "ENTREGADO")
                {
                    Console.WriteLine("Error: El estado debe ser REGISTRADO, ASIGNADO, EN TRANSITO o ENTREGADO.");
                    return false;
                }

                Console.WriteLine("Datos del paquete validados correctamente.");
                return true;
            }

        }
        public class Documento : Paquete
        {
            public Documento(string codigo, string descripcion, double peso, double valordeclarado, string direccionorigen, string direcciondestino) : base(codigo, descripcion, peso, valordeclarado, direccionorigen, direcciondestino)
            {

            }

            public string Tipo()
            {
                return "DOCUMENTO";
            }

            public double CalcularTarifaBase(double distanciaKm)
            {
                return 8.00 + (2.50 * distanciaKm);
            }

            public string CondicionesTransporte()
            {
                return "Debe viajar en sobre cerrado y protegido de la lluvia.";
            }

            public new bool ValidarDatos()
            {
                if (!base.ValidarDatos())
                {
                    return false;
                }

                if (Peso > 2)
                {
                    Console.WriteLine("Error: Un documento no puede pesar más de 2 kg. Si pesa más regístrelo como paquete estándar.");
                    return false;
                }

                Console.WriteLine("Datos del documento validados correctamente.");
                return true;
            }

        }
        public class PaqueteEstandar : Paquete
        {
            public PaqueteEstandar(string codigo, string descripcion, double peso, double valordeclarado, string direccionorigen, string direcciondestino) : base(codigo, descripcion, peso, valordeclarado, direccionorigen, direcciondestino)
            {

            }

            public string Tipo()
            {
                return "ESTANDAR";
            }

            public double CalcularTarifaBase(double distanciaKm)
            {
                return 10.00 + (3.50 * distanciaKm) + (2.00 * Peso);
            }

            public string CondicionesTransporte()
            {
                return "Sin condiciones especiales.";
            }

        }
        public class PaqueteFragil : Paquete
        {
            public PaqueteFragil(string codigo, string descripcion, double peso, double valordeclarado, string direccionorigen, string direcciondestino) : base(codigo, descripcion, peso, valordeclarado, direccionorigen, direcciondestino)
            {

            }

            public string Tipo()
            {
                return "FRAGIL";
            }

            public bool EsFragil()
            {
                return true;
            }

            public double CalcularTarifaBase(double distanciaKm)
            {
                double normal = 10.00 + (3.50 * distanciaKm) + (2.00 * Peso);
                return (normal * 1.35) + 15.00;
            }

            public string CondicionesTransporte()
            {
                return "Embalaje con burbuja, no apilar y manejar con cuidado.";
            }

        }
        public class ProductoRefrigerado : Paquete
        {
            private double temperaturamaxima;
            public double Temperaturamaxima
            {
                get { return temperaturamaxima; }
                set { temperaturamaxima = value; }
            }

            public ProductoRefrigerado(string codigo, string descripcion, double peso, double valordeclarado, string direccionorigen, string direcciondestino, double temperaturamaxima) : base(codigo, descripcion, peso, valordeclarado, direccionorigen, direcciondestino)
            {
                Temperaturamaxima = temperaturamaxima;
            }

            public string Tipo()
            {
                return "REFRIGERADO";
            }

            public bool NecesitaRefrigeracion()
            {
                return true;
            }

            public double CalcularTarifaBase(double distanciaKm)
            {
                double normal = 10.00 + (3.50 * distanciaKm) + (2.50 * Peso);
                return normal + 25.00 + (1.50 * distanciaKm);
            }

            public string CondicionesTransporte()
            {
                return "Cadena de frío a " + Temperaturamaxima + " grados o menos, entrega inmediata.";
            }

            public new bool ValidarDatos()
            {
                if (!base.ValidarDatos())
                {
                    return false;
                }

                if (Temperaturamaxima > 15)
                {
                    Console.WriteLine("Error: Un producto refrigerado debe conservarse a 15 grados o menos.");
                    return false;
                }

                Console.WriteLine("Datos del producto refrigerado validados correctamente.");
                return true;
            }

        }
        public class Incidencia
        {
            private string codigo;
            public string Codigo
            {
                get { return codigo; }
                set { codigo = value; }
            }

            private string codigoentrega;
            public string Codigoentrega
            {
                get { return codigoentrega; }
                set { codigoentrega = value; }
            }

            private string tipo;
            public string Tipo
            {
                get { return tipo; }
                set { tipo = value; }
            }

            private string descripcion;
            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }

            private DateTime fecha;
            public DateTime Fecha
            {
                get { return fecha; }
                set { fecha = value; }
            }

            private string estado = "ABIERTA";
            public string Estado
            {
                get { return estado; }
                set { estado = value; }
            }

            private string acciontomada;
            public string Acciontomada
            {
                get { return acciontomada; }
                set { acciontomada = value; }
            }

            public Incidencia(string codigo, string codigoentrega, string tipo, string descripcion) : this(codigo, codigoentrega, tipo, descripcion, "Pendiente de revisión")
            {

            }

            public Incidencia(string codigo, string codigoentrega, string tipo, string descripcion, string acciontomada)
            {
                Codigo = codigo;
                Codigoentrega = codigoentrega;
                Tipo = tipo;
                Descripcion = descripcion;
                Acciontomada = acciontomada;
                Fecha = DateTime.Now;
            }

            public bool EsTipoValido(string tipo)
            {
                if (tipo == "CLIENTE AUSENTE" || tipo == "DIRECCION INCORRECTA" || tipo == "PAQUETE DANADO" || tipo == "VEHICULO AVERIADO" || tipo == "RETRASO" || tipo == "CLIMA" || tipo == "RECHAZO")
                {
                    return true;
                }
                return false;
            }

            public void CerrarIncidencia(string acciontomada)
            {
                Acciontomada = acciontomada;
                Estado = "CERRADA";
            }

            public void MostrarInformacionIncidencia()
            {
                Console.WriteLine("Código: " + Codigo);
                Console.WriteLine("Entrega: " + Codigoentrega);
                Console.WriteLine("Tipo: " + Tipo);
                Console.WriteLine("Fecha: " + Fecha);
                Console.WriteLine("Descripción: " + Descripcion);
                Console.WriteLine("Estado: " + Estado);
                Console.WriteLine("Acción tomada: " + Acciontomada);
            }

            public bool ValidarDatos()
            {
                if (string.IsNullOrWhiteSpace(Codigo))
                {
                    Console.WriteLine("Error: El código de la incidencia no puede estar vacío.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(Codigoentrega))
                {
                    Console.WriteLine("Error: La incidencia debe pertenecer a una entrega.");
                    return false;
                }

                if (!EsTipoValido(Tipo))
                {
                    Console.WriteLine("Error: El tipo debe ser CLIENTE AUSENTE, DIRECCION INCORRECTA, PAQUETE DANADO, VEHICULO AVERIADO, RETRASO, CLIMA o RECHAZO.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(Descripcion))
                {
                    Console.WriteLine("Error: La descripción de la incidencia no puede estar vacía.");
                    return false;
                }

                if (Estado != "ABIERTA" && Estado != "CERRADA")
                {
                    Console.WriteLine("Error: El estado de la incidencia debe ser ABIERTA o CERRADA.");
                    return false;
                }

                Console.WriteLine("Datos de la incidencia validados correctamente.");
                return true;
            }

        }
        class Entrega
        {
            private string codigo;
            public string Codigo
            {
                get { return codigo; }
                set { codigo = value; }
            }

            private Cliente cliente;
            public Cliente Cliente
            {
                get { return cliente; }
                set { cliente = value; }
            }

            private Paquete paquete;
            public Paquete Paquete
            {
                get { return paquete; }
                set { paquete = value; }
            }

            private Repartidor repartidor;
            public Repartidor Repartidor
            {
                get { return repartidor; }
                set { repartidor = value; }
            }

            private Vehiculo vehiculo;
            public Vehiculo Vehiculo
            {
                get { return vehiculo; }
                set { vehiculo = value; }
            }

            private List<Incidencia> incidencias;
            public List<Incidencia> Incidencias
            {
                get { return incidencias; }
                set { incidencias = value; }
            }

            private DateTime fechasolicitud;
            public DateTime Fechasolicitud
            {
                get { return fechasolicitud; }
                set { fechasolicitud = value; }
            }

            private double distanciaestimada;
            public double Distanciaestimada
            {
                get { return distanciaestimada; }
                set { distanciaestimada = value; }
            }

            private string tiposervicio;
            public string Tiposervicio
            {
                get { return tiposervicio; }
                set { tiposervicio = value; }
            }

            private string estado = "SOLICITADA";
            public string Estado
            {
                get { return estado; }
                set { estado = value; }
            }

            private string estadoanterior = "";
            public string Estadoanterior
            {
                get { return estadoanterior; }
                set { estadoanterior = value; }
            }

            private double tarifabase;
            public double Tarifabase
            {
                get { return tarifabase; }
                set { tarifabase = value; }
            }

            private double recargos;
            public double Recargos
            {
                get { return recargos; }
                set { recargos = value; }
            }

            private double descuentos;
            public double Descuentos
            {
                get { return descuentos; }
                set { descuentos = value; }
            }

            private double total;
            public double Total
            {
                get { return total; }
                set { total = value; }
            }

            private double calificacion;
            public double Calificacion
            {
                get { return calificacion; }
                set { calificacion = value; }
            }

            public Entrega(string codigo, Cliente cliente, Paquete paquete, double distanciaestimada) : this(codigo, cliente, paquete, distanciaestimada, "NORMAL")
            {

            }

            public Entrega(string codigo, Cliente cliente, Paquete paquete, double distanciaestimada, string tiposervicio)
            {
                Codigo = codigo;
                Cliente = cliente;
                Paquete = paquete;
                Distanciaestimada = distanciaestimada;
                Tiposervicio = tiposervicio;
                Incidencias = new List<Incidencia>();
                Fechasolicitud = DateTime.Now;
            }

            public double FactorServicio()
            {
                if (Tiposervicio == "PRIORITARIO")
                {
                    return 1.25;
                }

                if (Tiposervicio == "URGENTE")
                {
                    return 1.60;
                }

                return 1.00;
            }

            public bool EstaFinalizada()
            {
                if (Estado == "ENTREGADA" || Estado == "CANCELADA")
                {
                    return true;
                }
                return false;
            }

            public bool EstaActiva()
            {
                if (EstaFinalizada() == true)
                {
                    return false;
                }
                return true;
            }

            public bool TransicionPermitida(string actual, string nuevo)
            {
                if (actual == "SOLICITADA")
                {
                    if (nuevo == "ASIGNADA" || nuevo == "CANCELADA" || nuevo == "REPROGRAMADA" || nuevo == "CON INCIDENCIA")
                    {
                        return true;
                    }
                    return false;
                }

                if (actual == "ASIGNADA")
                {
                    if (nuevo == "RECOGIDA" || nuevo == "CANCELADA" || nuevo == "REPROGRAMADA" || nuevo == "CON INCIDENCIA")
                    {
                        return true;
                    }
                    return false;
                }

                if (actual == "RECOGIDA")
                {
                    if (nuevo == "EN RUTA" || nuevo == "CANCELADA" || nuevo == "CON INCIDENCIA")
                    {
                        return true;
                    }
                    return false;
                }

                if (actual == "EN RUTA")
                {
                    if (nuevo == "ENTREGADA" || nuevo == "CANCELADA" || nuevo == "CON INCIDENCIA")
                    {
                        return true;
                    }
                    return false;
                }

                if (actual == "REPROGRAMADA")
                {
                    if (nuevo == "ASIGNADA" || nuevo == "CANCELADA" || nuevo == "CON INCIDENCIA")
                    {
                        return true;
                    }
                    return false;
                }

                if (actual == "CON INCIDENCIA")
                {
                    if (nuevo == "CANCELADA" || nuevo == "REPROGRAMADA")
                    {
                        return true;
                    }

                    if (nuevo == Estadoanterior)
                    {
                        return true;
                    }

                    if (nuevo == "ENTREGADA" && Estadoanterior == "EN RUTA")
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }

            public bool CambiarEstado(string nuevoestado)
            {
                if (EstaFinalizada() == true)
                {
                    Console.WriteLine("Error: La entrega " + Codigo + " ya está " + Estado + " y no se puede modificar.");
                    return false;
                }

                if (TransicionPermitida(Estado, nuevoestado) == false)
                {
                    Console.WriteLine("Error: No se puede pasar de " + Estado + " a " + nuevoestado + ".");
                    return false;
                }

                Estadoanterior = Estado;
                Estado = nuevoestado;

                if (nuevoestado == "RECOGIDA" || nuevoestado == "EN RUTA")
                {
                    Paquete.Estado = "EN TRANSITO";
                }

                if (nuevoestado == "ENTREGADA")
                {
                    Paquete.Estado = "ENTREGADO";
                    Cliente.incrementarSolicitud();

                    if (Repartidor != null)
                    {
                        Repartidor.incrementarEntrega();
                        Repartidor.Estado = "DISPONIBLE";
                    }

                    if (Vehiculo != null)
                    {
                        Vehiculo.Estado = "DISPONIBLE";
                    }
                }

                return true;
            }

            public bool AsignarRepartidorYVehiculo(Repartidor repartidor, Vehiculo vehiculo)
            {
                if (Estado != "SOLICITADA" && Estado != "REPROGRAMADA")
                {
                    Console.WriteLine("Error: Solo se puede asignar a una entrega SOLICITADA o REPROGRAMADA.");
                    return false;
                }

                if (repartidor.Estado != "DISPONIBLE")
                {
                    Console.WriteLine("Error: El repartidor " + repartidor.NombreCompleto + " no está disponible.");
                    return false;
                }

                if (vehiculo.Estado != "DISPONIBLE")
                {
                    Console.WriteLine("Error: El vehículo " + vehiculo.MyCodigo + " no está disponible.");
                    return false;
                }

                if (repartidor.TieneLicencia(vehiculo.MytipoLicencia) == false)
                {
                    Console.WriteLine("Error: El repartidor tiene licencia " + repartidor.Tipolicencia + " y ese vehículo pide " + vehiculo.MytipoLicencia + ".");
                    return false;
                }

                Repartidor = repartidor;
                Vehiculo = vehiculo;
                repartidor.Estado = "ASIGNADO";
                vehiculo.Estado = "ASIGNADO";
                Paquete.Estado = "ASIGNADO";
                Estadoanterior = Estado;
                Estado = "ASIGNADA";
                return true;
            }

            public void CalcularTotal(double tarifadelpaquete)
            {
                Tarifabase = tarifadelpaquete * FactorServicio();
                Recargos = 0;

                if (Distanciaestimada > 50)
                {
                    Recargos = Recargos + 20.00;
                }

                Descuentos = 0;

                if (Cliente.Cantidad >= 5)
                {
                    Descuentos = Tarifabase * 0.10;
                }

                Total = Tarifabase + Recargos - Descuentos;
            }

            public void AgregarIncidencia(Incidencia incidencia)
            {
                Incidencias.Add(incidencia);

                if (EstaActiva() == true)
                {
                    Estadoanterior = Estado;
                    Estado = "CON INCIDENCIA";
                }
            }

            public bool Calificar(double nota)
            {
                if (Estado != "ENTREGADA")
                {
                    Console.WriteLine("Error: Solo se pueden calificar las entregas ya ENTREGADAS.");
                    return false;
                }

                if (nota < 1 || nota > 5)
                {
                    Console.WriteLine("Error: La calificación debe estar entre 1 y 5.");
                    return false;
                }

                Calificacion = nota;
                return true;
            }

            public void MostrarInformacionEntrega()
            {
                Console.WriteLine("Código: " + Codigo);
                Console.WriteLine("Fecha de solicitud: " + Fechasolicitud);
                Console.WriteLine("Cliente: " + Cliente.NombreCompleto);
                Console.WriteLine("Paquete: " + Paquete.Codigo + " - " + Paquete.Descripcion);
                Console.WriteLine("Distancia: " + Distanciaestimada + " km");
                Console.WriteLine("Tipo de servicio: " + Tiposervicio);
                Console.WriteLine("Estado: " + Estado);

                if (Repartidor == null)
                {
                    Console.WriteLine("Repartidor: sin asignar");
                }
                else
                {
                    Console.WriteLine("Repartidor: " + Repartidor.NombreCompleto);
                }

                if (Vehiculo == null)
                {
                    Console.WriteLine("Vehículo: sin asignar");
                }
                else
                {
                    Console.WriteLine("Vehículo: " + Vehiculo.MyCodigo + " " + Vehiculo.MyMarca);
                }

                Console.WriteLine("Tarifa base: Q" + Tarifabase);
                Console.WriteLine("Recargos: Q" + Recargos);
                Console.WriteLine("Descuentos: Q" + Descuentos);
                Console.WriteLine("Total: Q" + Total);
                Console.WriteLine("Incidencias: " + Incidencias.Count);
            }

            public bool ValidarDatos()
            {
                if (string.IsNullOrWhiteSpace(Codigo))
                {
                    Console.WriteLine("Error: El código de la entrega no puede estar vacío.");
                    return false;
                }

                if (Cliente == null)
                {
                    Console.WriteLine("Error: La entrega debe tener un cliente.");
                    return false;
                }

                if (Paquete == null)
                {
                    Console.WriteLine("Error: La entrega debe tener un paquete.");
                    return false;
                }

                if (Distanciaestimada <= 0)
                {
                    Console.WriteLine("Error: La distancia debe ser mayor a 0.");
                    return false;
                }

                if (Distanciaestimada > 100)
                {
                    Console.WriteLine("Error: GoXela solo cubre hasta 100 km a la redonda.");
                    return false;
                }

                if (Tiposervicio != "NORMAL" && Tiposervicio != "PRIORITARIO" && Tiposervicio != "URGENTE")
                {
                    Console.WriteLine("Error: El tipo de servicio debe ser NORMAL, PRIORITARIO o URGENTE.");
                    return false;
                }

                Console.WriteLine("Datos de la entrega validados correctamente.");
                return true;
            }

        }
        struct ResumenReporte
        {
            public int TotalEntregas;
            public int EntregasActivas;
            public int EntregasFinalizadas;
            public int EntregasCanceladas;
            public double TotalIngresos;
        }

        class SistemaGoXela
        {
            private List<Cliente> clientes;
            public List<Cliente> Clientes
            {
                get { return clientes; }
                set { clientes = value; }
            }

            private List<Repartidor> repartidores;
            public List<Repartidor> Repartidores
            {
                get { return repartidores; }
                set { repartidores = value; }
            }

            private List<Vehiculo> vehiculos;
            public List<Vehiculo> Vehiculos
            {
                get { return vehiculos; }
                set { vehiculos = value; }
            }

            private List<Paquete> paquetes;
            public List<Paquete> Paquetes
            {
                get { return paquetes; }
                set { paquetes = value; }
            }

            private List<Entrega> entregas;
            public List<Entrega> Entregas
            {
                get { return entregas; }
                set { entregas = value; }
            }

            private List<Incidencia> incidencias;
            public List<Incidencia> Incidencias
            {
                get { return incidencias; }
                set { incidencias = value; }
            }

            public SistemaGoXela()
            {
                Clientes = new List<Cliente>();
                Repartidores = new List<Repartidor>();
                Vehiculos = new List<Vehiculo>();
                Paquetes = new List<Paquete>();
                Entregas = new List<Entrega>();
                Incidencias = new List<Incidencia>();
            }

            private int correlativocliente = 0;
            private int correlativorepartidor = 0;
            private int correlativovehiculo = 0;
            private int correlativopaquete = 0;
            private int correlativoentrega = 0;
            private int correlativoincidencia = 0;

            public string SiguienteCodigoCliente()
            {
                correlativocliente = correlativocliente + 1;
                return "CLI" + correlativocliente.ToString("000");
            }

            public string SiguienteCodigoRepartidor()
            {
                correlativorepartidor = correlativorepartidor + 1;
                return "REP" + correlativorepartidor.ToString("000");
            }

            public string SiguienteCodigoVehiculo()
            {
                correlativovehiculo = correlativovehiculo + 1;
                return "VEH" + correlativovehiculo.ToString("000");
            }

            public string SiguienteCodigoPaquete()
            {
                correlativopaquete = correlativopaquete + 1;
                return "PAQ" + correlativopaquete.ToString("000");
            }

            public string SiguienteCodigoEntrega()
            {
                correlativoentrega = correlativoentrega + 1;
                return "ENT" + correlativoentrega.ToString("000");
            }

            public string SiguienteCodigoIncidencia()
            {
                correlativoincidencia = correlativoincidencia + 1;
                return "INC" + correlativoincidencia.ToString("000");
            }

            public Cliente BuscarCliente(string codigo)
            {
                for (int i = 0; i < Clientes.Count; i++)
                {
                    if (Clientes[i].Codigo == codigo)
                    {
                        return Clientes[i];
                    }
                }
                return null;
            }

            public Cliente BuscarCliente(int posicion)
            {
                if (posicion < 0 || posicion >= Clientes.Count)
                {
                    Console.WriteLine("Error: No existe un cliente en la posición " + posicion + ".");
                    return null;
                }
                return Clientes[posicion];
            }

            public Cliente BuscarClientePorTelefono(string telefono)
            {
                for (int i = 0; i < Clientes.Count; i++)
                {
                    if (Clientes[i].Telefono == telefono)
                    {
                        return Clientes[i];
                    }
                }
                return null;
            }

            public Repartidor BuscarRepartidor(string codigo)
            {
                for (int i = 0; i < Repartidores.Count; i++)
                {
                    if (Repartidores[i].Codigo == codigo)
                    {
                        return Repartidores[i];
                    }
                }
                return null;
            }

            public Vehiculo BuscarVehiculo(string codigo)
            {
                for (int i = 0; i < Vehiculos.Count; i++)
                {
                    if (Vehiculos[i].MyCodigo == codigo)
                    {
                        return Vehiculos[i];
                    }
                }
                return null;
            }

            public Paquete BuscarPaquete(string codigo)
            {
                for (int i = 0; i < Paquetes.Count; i++)
                {
                    if (Paquetes[i].Codigo == codigo)
                    {
                        return Paquetes[i];
                    }
                }
                return null;
            }

            public Entrega BuscarEntrega(string codigo)
            {
                for (int i = 0; i < Entregas.Count; i++)
                {
                    if (Entregas[i].Codigo == codigo)
                    {
                        return Entregas[i];
                    }
                }
                return null;
            }

            public Incidencia BuscarIncidencia(string codigo)
            {
                for (int i = 0; i < Incidencias.Count; i++)
                {
                    if (Incidencias[i].Codigo == codigo)
                    {
                        return Incidencias[i];
                    }
                }
                return null;
            }

            public int ContarRepartidoresDisponibles()
            {
                int cuantos = 0;
                for (int i = 0; i < Repartidores.Count; i++)
                {
                    if (Repartidores[i].Estado == "DISPONIBLE")
                    {
                        cuantos = cuantos + 1;
                    }
                }
                return cuantos;
            }

            public int ContarVehiculosDisponibles()
            {
                int cuantos = 0;
                for (int i = 0; i < Vehiculos.Count; i++)
                {
                    if (Vehiculos[i].Estado == "DISPONIBLE")
                    {
                        cuantos = cuantos + 1;
                    }
                }
                return cuantos;
            }

            public int ContarEntregasActivas()
            {
                int cuantas = 0;
                for (int i = 0; i < Entregas.Count; i++)
                {
                    if (Entregas[i].EstaActiva() == true)
                    {
                        cuantas = cuantas + 1;
                    }
                }
                return cuantas;
            }

            public bool AgregarCliente(Cliente cliente)
            {
                if (cliente.ValidarDatos() == false)
                {
                    return false;
                }

                if (BuscarCliente(cliente.Codigo) != null)
                {
                    Console.WriteLine("Error: Ya existe un cliente con el código " + cliente.Codigo + ".");
                    return false;
                }

                Clientes.Add(cliente);
                return true;
            }

            public bool AgregarRepartidor(Repartidor repartidor)
            {
                if (repartidor.ValidarDatos() == false)
                {
                    return false;
                }

                if (BuscarRepartidor(repartidor.Codigo) != null)
                {
                    Console.WriteLine("Error: Ya existe un repartidor con el código " + repartidor.Codigo + ".");
                    return false;
                }

                Repartidores.Add(repartidor);
                return true;
            }

            public bool AgregarVehiculo(Vehiculo vehiculo)
            {
                if (vehiculo.ValidarDatos() == false)
                {
                    return false;
                }

                if (BuscarVehiculo(vehiculo.MyCodigo) != null)
                {
                    Console.WriteLine("Error: Ya existe un vehículo con el código " + vehiculo.MyCodigo + ".");
                    return false;
                }

                Vehiculos.Add(vehiculo);
                return true;
            }

            public bool AgregarPaquete(Paquete paquete)
            {
                if (paquete.ValidarDatos() == false)
                {
                    return false;
                }

                if (BuscarPaquete(paquete.Codigo) != null)
                {
                    Console.WriteLine("Error: Ya existe un paquete con el código " + paquete.Codigo + ".");
                    return false;
                }

                Paquetes.Add(paquete);
                return true;
            }

            public bool AgregarEntrega(Entrega entrega)
            {
                if (entrega.ValidarDatos() == false)
                {
                    return false;
                }

                if (BuscarEntrega(entrega.Codigo) != null)
                {
                    Console.WriteLine("Error: Ya existe una entrega con el código " + entrega.Codigo + ".");
                    return false;
                }

                Entregas.Add(entrega);
                return true;
            }

            public bool AgregarIncidencia(Incidencia incidencia)
            {
                if (incidencia.ValidarDatos() == false)
                {
                    return false;
                }

                if (BuscarIncidencia(incidencia.Codigo) != null)
                {
                    Console.WriteLine("Error: Ya existe una incidencia con el código " + incidencia.Codigo + ".");
                    return false;
                }

                Entrega entrega = BuscarEntrega(incidencia.Codigoentrega);

                if (entrega == null)
                {
                    Console.WriteLine("Error: No existe la entrega " + incidencia.Codigoentrega + ".");
                    return false;
                }

                Incidencias.Add(incidencia);
                entrega.AgregarIncidencia(incidencia);
                return true;
            }

            public Entrega CrearEntrega(string codigocliente, string codigopaquete, double distancia, string tiposervicio)
            {
                Cliente cliente = BuscarCliente(codigocliente);

                if (cliente == null)
                {
                    Console.WriteLine("Error: No existe el cliente " + codigocliente + ".");
                    return null;
                }

                Paquete paquete = BuscarPaquete(codigopaquete);

                if (paquete == null)
                {
                    Console.WriteLine("Error: No existe el paquete " + codigopaquete + ".");
                    return null;
                }

                if (paquete.Estado != "REGISTRADO")
                {
                    Console.WriteLine("Error: El paquete " + codigopaquete + " ya está " + paquete.Estado + ".");
                    return null;
                }

                Entrega entrega = new Entrega(SiguienteCodigoEntrega(), cliente, paquete, distancia, tiposervicio);

                if (AgregarEntrega(entrega) == false)
                {
                    return null;
                }

                paquete.Estado = "ASIGNADO";
                return entrega;
            }

            public bool AsignarRepartidorYVehiculo(string codigoentrega, string codigorepartidor, string codigovehiculo)
            {
                Entrega entrega = BuscarEntrega(codigoentrega);

                if (entrega == null)
                {
                    Console.WriteLine("Error: No existe la entrega " + codigoentrega + ".");
                    return false;
                }

                Repartidor repartidor = BuscarRepartidor(codigorepartidor);

                if (repartidor == null)
                {
                    Console.WriteLine("Error: No existe el repartidor " + codigorepartidor + ".");
                    return false;
                }

                Vehiculo vehiculo = BuscarVehiculo(codigovehiculo);

                if (vehiculo == null)
                {
                    Console.WriteLine("Error: No existe el vehículo " + codigovehiculo + ".");
                    return false;
                }

                return entrega.AsignarRepartidorYVehiculo(repartidor, vehiculo);
            }

            public void LiberarRepartidorYVehiculo(Entrega entrega)
            {
                if (entrega.Repartidor != null)
                {
                    entrega.Repartidor.Estado = "DISPONIBLE";
                }

                if (entrega.Vehiculo != null)
                {
                    entrega.Vehiculo.Estado = "DISPONIBLE";
                }
            }

            public bool CambiarEstadoEntrega(string codigoentrega, string nuevoestado)
            {
                Entrega entrega = BuscarEntrega(codigoentrega);

                if (entrega == null)
                {
                    Console.WriteLine("Error: No existe la entrega " + codigoentrega + ".");
                    return false;
                }

                return entrega.CambiarEstado(nuevoestado);
            }

            public bool CancelarEntrega(string codigoentrega)
            {
                Entrega entrega = BuscarEntrega(codigoentrega);

                if (entrega == null)
                {
                    Console.WriteLine("Error: No existe la entrega " + codigoentrega + ".");
                    return false;
                }

                if (entrega.CambiarEstado("CANCELADA") == false)
                {
                    return false;
                }

                LiberarRepartidorYVehiculo(entrega);
                entrega.Paquete.Estado = "REGISTRADO";
                return true;
            }

            public bool ReprogramarEntrega(string codigoentrega)
            {
                Entrega entrega = BuscarEntrega(codigoentrega);

                if (entrega == null)
                {
                    Console.WriteLine("Error: No existe la entrega " + codigoentrega + ".");
                    return false;
                }

                if (entrega.CambiarEstado("REPROGRAMADA") == false)
                {
                    return false;
                }

                LiberarRepartidorYVehiculo(entrega);
                entrega.Repartidor = null;
                entrega.Vehiculo = null;
                return true;
            }

            public Incidencia RegistrarIncidencia(string codigoentrega, string tipo, string descripcion)
            {
                return RegistrarIncidencia(codigoentrega, tipo, descripcion, "Pendiente de revisión");
            }

            public Incidencia RegistrarIncidencia(string codigoentrega, string tipo, string descripcion, string acciontomada)
            {
                Entrega entrega = BuscarEntrega(codigoentrega);

                if (entrega == null)
                {
                    Console.WriteLine("Error: No existe la entrega " + codigoentrega + ".");
                    return null;
                }

                if (entrega.EstaFinalizada() == true)
                {
                    Console.WriteLine("Error: La entrega " + codigoentrega + " ya está " + entrega.Estado + ".");
                    return null;
                }

                Incidencia incidencia = new Incidencia(SiguienteCodigoIncidencia(), codigoentrega, tipo, descripcion, acciontomada);

                if (AgregarIncidencia(incidencia) == false)
                {
                    return null;
                }

                return incidencia;
            }

            public bool CerrarIncidencia(string codigoincidencia, string acciontomada)
            {
                Incidencia incidencia = BuscarIncidencia(codigoincidencia);

                if (incidencia == null)
                {
                    Console.WriteLine("Error: No existe la incidencia " + codigoincidencia + ".");
                    return false;
                }

                if (incidencia.Estado == "CERRADA")
                {
                    Console.WriteLine("Error: La incidencia " + codigoincidencia + " ya estaba cerrada.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(acciontomada))
                {
                    Console.WriteLine("Error: Hay que escribir qué se hizo para cerrar la incidencia.");
                    return false;
                }

                incidencia.CerrarIncidencia(acciontomada);
                return true;
            }

            public void RecalcularCalificacionRepartidor(Repartidor repartidor)
            {
                double suma = 0;
                int cuantas = 0;

                for (int i = 0; i < Entregas.Count; i++)
                {
                    if (Entregas[i].Repartidor == repartidor && Entregas[i].Calificacion > 0)
                    {
                        suma = suma + Entregas[i].Calificacion;
                        cuantas = cuantas + 1;
                    }
                }

                if (cuantas > 0)
                {
                    repartidor.Calificacion = suma / cuantas;
                }
            }

            public bool CalificarEntrega(string codigoentrega, double nota)
            {
                Entrega entrega = BuscarEntrega(codigoentrega);

                if (entrega == null)
                {
                    Console.WriteLine("Error: No existe la entrega " + codigoentrega + ".");
                    return false;
                }

                if (entrega.Calificar(nota) == false)
                {
                    return false;
                }

                if (entrega.Repartidor != null)
                {
                    RecalcularCalificacionRepartidor(entrega.Repartidor);
                }

                return true;
            }

            public ResumenReporte ObtenerResumen()
            {
                ResumenReporte resumen = new ResumenReporte();
                resumen.TotalEntregas = Entregas.Count;
                resumen.EntregasActivas = 0;
                resumen.EntregasFinalizadas = 0;
                resumen.EntregasCanceladas = 0;
                resumen.TotalIngresos = 0;

                for (int i = 0; i < Entregas.Count; i++)
                {
                    Entrega entrega = Entregas[i];

                    if (entrega.Estado == "ENTREGADA")
                    {
                        resumen.EntregasFinalizadas = resumen.EntregasFinalizadas + 1;
                        resumen.TotalIngresos = resumen.TotalIngresos + entrega.Total;
                    }
                    else if (entrega.Estado == "CANCELADA")
                    {
                        resumen.EntregasCanceladas = resumen.EntregasCanceladas + 1;
                    }
                    else
                    {
                        resumen.EntregasActivas = resumen.EntregasActivas + 1;
                    }
                }

                return resumen;
            }

            public double CalcularTarifaDelPaquete(Paquete paquete, double distancia)
            {
                if (paquete is Documento)
                {
                    Documento documento = (Documento)paquete;
                    return documento.CalcularTarifaBase(distancia);
                }

                if (paquete is PaqueteFragil)
                {
                    PaqueteFragil fragil = (PaqueteFragil)paquete;
                    return fragil.CalcularTarifaBase(distancia);
                }

                if (paquete is ProductoRefrigerado)
                {
                    ProductoRefrigerado refrigerado = (ProductoRefrigerado)paquete;
                    return refrigerado.CalcularTarifaBase(distancia);
                }

                if (paquete is PaqueteEstandar)
                {
                    PaqueteEstandar estandar = (PaqueteEstandar)paquete;
                    return estandar.CalcularTarifaBase(distancia);
                }

                return 0;
            }

            public bool CalcularTarifa(string codigoentrega)
            {
                Entrega entrega = BuscarEntrega(codigoentrega);

                if (entrega == null)
                {
                    Console.WriteLine("Error: No existe la entrega " + codigoentrega + ".");
                    return false;
                }

                double tarifadelpaquete = CalcularTarifaDelPaquete(entrega.Paquete, entrega.Distanciaestimada);

                if (tarifadelpaquete <= 0)
                {
                    Console.WriteLine("Error: No se pudo calcular la tarifa del paquete " + entrega.Paquete.Codigo + ".");
                    return false;
                }

                entrega.CalcularTotal(tarifadelpaquete);
                return true;
            }

        }
        static SistemaGoXela sistema = new SistemaGoXela();

        static void Titulo(string texto)
        {
            Console.WriteLine();
            Console.WriteLine("========================================================================");
            Console.WriteLine("  " + texto.ToUpper());
            Console.WriteLine("========================================================================");
        }

        static void Separador()
        {
            Console.WriteLine("------------------------------------------------------------------------");
        }

        static void MostrarError(string mensaje)
        {
            Console.WriteLine();
            Console.WriteLine("  *** " + mensaje);
        }

        static void MostrarExito(string mensaje)
        {
            Console.WriteLine();
            Console.WriteLine("  >>> " + mensaje);
        }

        static void Pausa()
        {
            Console.WriteLine();
            Console.Write("Presione ENTER para continuar...");
            Console.ReadLine();
        }

        static void Limpiar()
        {
            Console.Clear();
        }

        static string LeerTexto(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string texto = Console.ReadLine();

                if (texto != null)
                {
                    texto = texto.Trim();
                }

                if (string.IsNullOrWhiteSpace(texto) == false)
                {
                    return texto;
                }

                MostrarError("Este dato no puede quedar vacío.");
            }
        }

        static string LeerTextoOpcional(string mensaje)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();

            if (texto == null)
            {
                return "";
            }

            return texto.Trim();
        }

        static double LeerNumero(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string texto = Console.ReadLine();

                if (texto != null)
                {
                    texto = texto.Trim().Replace(",", ".");
                }

                double numero;

                if (double.TryParse(texto, out numero) == true)
                {
                    return numero;
                }

                MostrarError("Eso no es un número. Intente de nuevo.");
            }
        }

        static void MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("GOXELA DELIVERY");
                Console.WriteLine();
                Console.WriteLine("1. Clientes");
                Console.WriteLine("2. Repartidores");
                Console.WriteLine("3. Vehículos");
                Console.WriteLine("4. Paquetes");
                Console.WriteLine("5. Entregas");
                Console.WriteLine("6. Incidencias");
                Console.WriteLine("7. Reportes");
                Console.WriteLine("0. Salir");
                Console.WriteLine();

                string opcion = LeerTexto("Opción: ");

                if (opcion == "1")
                {
                    MenuClientes();
                }
                else if (opcion == "0")
                {
                    Console.WriteLine();
                    Console.WriteLine("Gracias por usar GoXela Delivery.");
                    return;
                }
                else if (opcion == "2")
                {
                    MenuRepartidores();
                }
                else if (opcion == "3")
                {
                    MenuVehiculos();
                }
                else if (opcion == "4")
                {
                    MenuPaquetes();
                }
                else if (opcion == "5")
                {
                    MenuEntregas();
                }
                else if (opcion == "6")
                {
                    MenuIncidencias();
                }
                else if (opcion == "7")
                {
                    MenuReportes();
                }
                else
                {
                    MostrarError("Opción no válida.");
                }
            }
        }

        static void MenuClientes()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("CLIENTES");
                Console.WriteLine();
                Console.WriteLine("1. Registrar cliente");
                Console.WriteLine("2. Consultar cliente");
                Console.WriteLine("3. Listar clientes");
                Console.WriteLine("4. Actualizar cliente");
                Console.WriteLine("0. Regresar");
                Console.WriteLine();

                string opcion = LeerTexto("Opción: ");

                if (opcion == "1")
                {
                    RegistrarCliente();
                }
                else if (opcion == "2")
                {
                    ConsultarCliente();
                }
                else if (opcion == "3")
                {
                    ListarClientes();
                }
                else if (opcion == "4")
                {
                    ActualizarCliente();
                }
                else if (opcion == "0")
                {
                    return;
                }
                else
                {
                    MostrarError("Opción no válida.");
                }
            }
        }

        static void MenuRepartidores()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("REPARTIDORES");
                Console.WriteLine();
                Console.WriteLine("1. Registrar repartidor");
                Console.WriteLine("2. Consultar repartidor");
                Console.WriteLine("3. Listar repartidores");
                Console.WriteLine("4. Cambiar estado");
                Console.WriteLine("0. Regresar");
                Console.WriteLine();

                string opcion = LeerTexto("Opción: ");

                if (opcion == "1")
                {
                    RegistrarRepartidor();
                }
                else if (opcion == "2")
                {
                    ConsultarRepartidor();
                }
                else if (opcion == "3")
                {
                    ListarRepartidores();
                }
                else if (opcion == "4")
                {
                    CambiarEstadoRepartidor();
                }
                else if (opcion == "0")
                {
                    return;
                }
                else
                {
                    MostrarError("Opción no válida.");
                }
            }
        }

        static void RegistrarRepartidor()
        {
            Console.WriteLine();
            Console.WriteLine("Registrar repartidor");
            Console.WriteLine();

            string codigo = sistema.SiguienteCodigoRepartidor();
            Console.WriteLine("Código asignado: " + codigo);
            Console.WriteLine();

            string nombre = LeerTexto("Nombre completo: ");
            string telefono = LeerTexto("Teléfono (8 dígitos): ");

            Console.WriteLine();
            Console.WriteLine("Licencias: NINGUNA (solo bicicleta), M (motos), A o B (todo)");
            string tipolicencia = LeerTexto("Tipo de licencia: ").ToUpper();

            string numerolicencia = "";

            if (tipolicencia != "NINGUNA")
            {
                numerolicencia = LeerTexto("Número de licencia: ");
            }

            Repartidor repartidor = new Repartidor(codigo, nombre, telefono, numerolicencia, tipolicencia);

            if (sistema.AgregarRepartidor(repartidor) == true)
            {
                MostrarExito("Repartidor " + codigo + " registrado.");
            }
            else
            {
                MostrarError("No se pudo registrar el repartidor.");
            }

            Pausa();
        }

        static void ConsultarRepartidor()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código del repartidor: ");
            Repartidor repartidor = sistema.BuscarRepartidor(codigo);

            if (repartidor == null)
            {
                MostrarError("No existe el repartidor " + codigo + ".");
            }
            else
            {
                Console.WriteLine();
                repartidor.MostrarInformacionRepartidor();
            }

            Pausa();
        }

        static void ListarRepartidores()
        {
            Console.WriteLine();
            Console.WriteLine("Repartidores registrados: " + sistema.Repartidores.Count + "   Disponibles: " + sistema.ContarRepartidoresDisponibles());
            Console.WriteLine();

            if (sistema.Repartidores.Count == 0)
            {
                Console.WriteLine("Todavía no hay repartidores.");
            }

            for (int i = 0; i < sistema.Repartidores.Count; i++)
            {
                Repartidor repartidor = sistema.Repartidores[i];
                Console.WriteLine(repartidor.Codigo + "   " + repartidor.NombreCompleto + "   licencia " + repartidor.Tipolicencia + "   " + repartidor.Estado + "   entregas: " + repartidor.Entregasrealizadas);
            }

            Pausa();
        }

        static void CambiarEstadoRepartidor()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código del repartidor: ");
            Repartidor repartidor = sistema.BuscarRepartidor(codigo);

            if (repartidor == null)
            {
                MostrarError("No existe el repartidor " + codigo + ".");
                Pausa();
                return;
            }

            if (repartidor.Estado == "ASIGNADO")
            {
                MostrarError("Está ASIGNADO a una entrega. Hay que cerrarla o cancelarla primero.");
                Pausa();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Estado actual: " + repartidor.Estado);
            Console.WriteLine();
            Console.WriteLine("1. DISPONIBLE");
            Console.WriteLine("2. FUERA DE SERVICIO");
            Console.WriteLine();

            string opcion = LeerTexto("Nuevo estado: ");

            if (opcion == "1")
            {
                repartidor.Estado = "DISPONIBLE";
                MostrarExito("Ahora está DISPONIBLE.");
            }
            else if (opcion == "2")
            {
                repartidor.Estado = "FUERA DE SERVICIO";
                MostrarExito("Ahora está FUERA DE SERVICIO.");
            }
            else
            {
                MostrarError("Opción no válida.");
            }

            Pausa();
        }

        static void RegistrarCliente()
        {
            Console.WriteLine();
            Console.WriteLine("Registrar cliente");
            Console.WriteLine();

            string codigo = sistema.SiguienteCodigoCliente();
            Console.WriteLine("Código asignado: " + codigo);
            Console.WriteLine();

            string nombre = LeerTexto("Nombre completo: ");
            string telefono = LeerTexto("Teléfono (8 dígitos): ");
            string correo = LeerTexto("Correo: ");
            string direccion = LeerTexto("Dirección: ");

            Cliente cliente = new Cliente(codigo, nombre, telefono, correo, direccion, 1);

            if (sistema.AgregarCliente(cliente) == true)
            {
                MostrarExito("Cliente " + codigo + " registrado.");
            }
            else
            {
                MostrarError("No se pudo registrar el cliente.");
            }

            Pausa();
        }

        static void ConsultarCliente()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código del cliente: ");
            Cliente cliente = sistema.BuscarCliente(codigo);

            if (cliente == null)
            {
                MostrarError("No existe el cliente " + codigo + ".");
            }
            else
            {
                Console.WriteLine();
                cliente.MostrarInformacionCliente();
            }

            Pausa();
        }

        static void ListarClientes()
        {
            Console.WriteLine();
            Console.WriteLine("Clientes registrados: " + sistema.Clientes.Count);
            Console.WriteLine();

            if (sistema.Clientes.Count == 0)
            {
                Console.WriteLine("Todavía no hay clientes.");
            }

            for (int i = 0; i < sistema.Clientes.Count; i++)
            {
                Cliente cliente = sistema.Clientes[i];
                Console.WriteLine(cliente.Codigo + "   " + cliente.NombreCompleto + "   " + cliente.Telefono + "   " + cliente.Correo);
            }

            Pausa();
        }

        static void ActualizarCliente()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código del cliente: ");
            Cliente cliente = sistema.BuscarCliente(codigo);

            if (cliente == null)
            {
                MostrarError("No existe el cliente " + codigo + ".");
                Pausa();
                return;
            }

            Console.WriteLine();
            cliente.MostrarInformacionCliente();
            Console.WriteLine();
            Console.WriteLine("Deje vacío lo que no quiera cambiar.");
            Console.WriteLine();

            string telefono = LeerTextoOpcional("Teléfono nuevo: ");

            if (telefono != "")
            {
                cliente.Telefono = telefono;
            }

            string correo = LeerTextoOpcional("Correo nuevo: ");

            if (correo != "")
            {
                cliente.Correo = correo;
            }

            string direccion = LeerTextoOpcional("Dirección nueva: ");

            if (direccion != "")
            {
                cliente.Direccion = direccion;
            }

            if (cliente.ValidarDatos() == true)
            {
                MostrarExito("Cliente actualizado.");
            }
            else
            {
                MostrarError("Quedaron datos inválidos, revise.");
            }

            Pausa();
        }

        static void MenuVehiculos()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("VEHICULOS");
                Console.WriteLine();
                Console.WriteLine("1. Registrar vehículo");
                Console.WriteLine("2. Consultar vehículo");
                Console.WriteLine("3. Listar vehículos");
                Console.WriteLine("4. Cambiar estado");
                Console.WriteLine("5. Probar si un repartidor puede manejarlo");
                Console.WriteLine("0. Regresar");
                Console.WriteLine();

                string opcion = LeerTexto("Opción: ");

                if (opcion == "1")
                {
                    RegistrarVehiculo();
                }
                else if (opcion == "2")
                {
                    ConsultarVehiculo();
                }
                else if (opcion == "3")
                {
                    ListarVehiculos();
                }
                else if (opcion == "4")
                {
                    CambiarEstadoVehiculo();
                }
                else if (opcion == "5")
                {
                    ProbarCompatibilidad();
                }
                else if (opcion == "0")
                {
                    return;
                }
                else
                {
                    MostrarError("Opción no válida.");
                }
            }
        }

        static void RegistrarVehiculo()
        {
            Console.WriteLine();
            Console.WriteLine("Registrar vehículo");
            Console.WriteLine();
            Console.WriteLine("1. Bicicleta");
            Console.WriteLine("2. Motocicleta");
            Console.WriteLine("3. Automóvil");
            Console.WriteLine();

            string tipo = LeerTexto("Tipo: ");

            if (tipo != "1" && tipo != "2" && tipo != "3")
            {
                MostrarError("Opción no válida.");
                Pausa();
                return;
            }

            string codigo = sistema.SiguienteCodigoVehiculo();
            Console.WriteLine();
            Console.WriteLine("Código asignado: " + codigo);
            Console.WriteLine();

            string placa = "SIN PLACA";

            if (tipo != "1")
            {
                placa = LeerTexto("Placa: ");
            }

            string marca = LeerTexto("Marca: ");
            string modelo = LeerTexto("Modelo: ");
            double carga = LeerNumero("Carga máxima en kg: ");
            double costo = LeerNumero("Costo por kilómetro: Q");

            Vehiculo vehiculo = null;

            if (tipo == "1")
            {
                vehiculo = new bicicleta(codigo, placa, marca, modelo, carga, costo, "NINGUNA");
            }
            else if (tipo == "2")
            {
                vehiculo = new Motocicleta(codigo, placa, marca, modelo, carga, costo, "M");
            }
            else
            {
                vehiculo = new automovil(codigo, placa, marca, modelo, carga, costo, "A o B");
            }

            if (sistema.AgregarVehiculo(vehiculo) == true)
            {
                MostrarExito("Vehículo " + codigo + " registrado.");
            }
            else
            {
                MostrarError("No se pudo registrar el vehículo.");
            }

            Pausa();
        }

        static void ConsultarVehiculo()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código del vehículo: ");
            Vehiculo vehiculo = sistema.BuscarVehiculo(codigo);

            if (vehiculo == null)
            {
                MostrarError("No existe el vehículo " + codigo + ".");
            }
            else
            {
                Console.WriteLine();
                vehiculo.MostrarInformacionVehiculo();
            }

            Pausa();
        }

        static void ListarVehiculos()
        {
            Console.WriteLine();
            Console.WriteLine("Vehículos registrados: " + sistema.Vehiculos.Count + "   Disponibles: " + sistema.ContarVehiculosDisponibles());
            Console.WriteLine();

            if (sistema.Vehiculos.Count == 0)
            {
                Console.WriteLine("Todavía no hay vehículos.");
            }

            for (int i = 0; i < sistema.Vehiculos.Count; i++)
            {
                Vehiculo vehiculo = sistema.Vehiculos[i];
                Console.WriteLine(vehiculo.MyCodigo + "   " + vehiculo.MyMarca + " " + vehiculo.MyModelo + "   " + vehiculo.Mycargamaxima + " kg   licencia " + vehiculo.MytipoLicencia + "   " + vehiculo.Estado);
            }

            Pausa();
        }

        static void CambiarEstadoVehiculo()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código del vehículo: ");
            Vehiculo vehiculo = sistema.BuscarVehiculo(codigo);

            if (vehiculo == null)
            {
                MostrarError("No existe el vehículo " + codigo + ".");
                Pausa();
                return;
            }

            if (vehiculo.Estado == "ASIGNADO")
            {
                MostrarError("Está ASIGNADO a una entrega. Hay que cerrarla o cancelarla primero.");
                Pausa();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Estado actual: " + vehiculo.Estado);
            Console.WriteLine();
            Console.WriteLine("1. DISPONIBLE");
            Console.WriteLine("2. EN MANTENIMIENTO");
            Console.WriteLine();

            string opcion = LeerTexto("Nuevo estado: ");

            if (opcion == "1")
            {
                vehiculo.Estado = "DISPONIBLE";
                MostrarExito("Ahora está DISPONIBLE.");
            }
            else if (opcion == "2")
            {
                vehiculo.Estado = "EN MANTENIMIENTO";
                MostrarExito("Ahora está EN MANTENIMIENTO.");
            }
            else
            {
                MostrarError("Opción no válida.");
            }

            Pausa();
        }

        static void ProbarCompatibilidad()
        {
            Console.WriteLine();
            string codigorepartidor = LeerTexto("Código del repartidor: ");
            Repartidor repartidor = sistema.BuscarRepartidor(codigorepartidor);

            if (repartidor == null)
            {
                MostrarError("No existe el repartidor " + codigorepartidor + ".");
                Pausa();
                return;
            }

            string codigovehiculo = LeerTexto("Código del vehículo: ");
            Vehiculo vehiculo = sistema.BuscarVehiculo(codigovehiculo);

            if (vehiculo == null)
            {
                MostrarError("No existe el vehículo " + codigovehiculo + ".");
                Pausa();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("El repartidor tiene licencia: " + repartidor.Tipolicencia);
            Console.WriteLine("El vehículo pide licencia   : " + vehiculo.MytipoLicencia);

            if (repartidor.TieneLicencia(vehiculo.MytipoLicencia) == true)
            {
                MostrarExito("Sí puede manejarlo.");
            }
            else
            {
                MostrarError("No puede manejarlo.");
            }

            Pausa();
        }

        static void MenuPaquetes()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("PAQUETES");
                Console.WriteLine();
                Console.WriteLine("1. Registrar paquete");
                Console.WriteLine("2. Consultar paquete");
                Console.WriteLine("3. Listar paquetes");
                Console.WriteLine("0. Regresar");
                Console.WriteLine();

                string opcion = LeerTexto("Opción: ");

                if (opcion == "1")
                {
                    RegistrarPaquete();
                }
                else if (opcion == "2")
                {
                    ConsultarPaquete();
                }
                else if (opcion == "3")
                {
                    ListarPaquetes();
                }
                else if (opcion == "0")
                {
                    return;
                }
                else
                {
                    MostrarError("Opción no válida.");
                }
            }
        }

        static void RegistrarPaquete()
        {
            Console.WriteLine();
            Console.WriteLine("Registrar paquete");
            Console.WriteLine();
            Console.WriteLine("1. Documento (máximo 2 kg)");
            Console.WriteLine("2. Estándar");
            Console.WriteLine("3. Frágil");
            Console.WriteLine("4. Refrigerado");
            Console.WriteLine();

            string tipo = LeerTexto("Tipo: ");

            if (tipo != "1" && tipo != "2" && tipo != "3" && tipo != "4")
            {
                MostrarError("Opción no válida.");
                Pausa();
                return;
            }

            string codigo = sistema.SiguienteCodigoPaquete();
            Console.WriteLine();
            Console.WriteLine("Código asignado: " + codigo);
            Console.WriteLine();

            string descripcion = LeerTexto("Descripción: ");
            double peso = LeerNumero("Peso en kg: ");
            double valor = LeerNumero("Valor declarado: Q");
            string origen = LeerTexto("Dirección de origen: ");
            string destino = LeerTexto("Dirección de destino: ");

            Paquete paquete = null;
            bool datosbuenos = false;

            if (tipo == "1")
            {
                Documento documento = new Documento(codigo, descripcion, peso, valor, origen, destino);
                datosbuenos = documento.ValidarDatos();
                paquete = documento;
            }
            else if (tipo == "2")
            {
                PaqueteEstandar estandar = new PaqueteEstandar(codigo, descripcion, peso, valor, origen, destino);
                datosbuenos = estandar.ValidarDatos();
                paquete = estandar;
            }
            else if (tipo == "3")
            {
                PaqueteFragil fragil = new PaqueteFragil(codigo, descripcion, peso, valor, origen, destino);
                datosbuenos = fragil.ValidarDatos();
                paquete = fragil;
            }
            else
            {
                double temperatura = LeerNumero("Temperatura máxima en grados: ");
                ProductoRefrigerado refrigerado = new ProductoRefrigerado(codigo, descripcion, peso, valor, origen, destino, temperatura);
                datosbuenos = refrigerado.ValidarDatos();
                paquete = refrigerado;
            }

            if (datosbuenos == false)
            {
                MostrarError("No se pudo registrar el paquete.");
                Pausa();
                return;
            }

            if (sistema.AgregarPaquete(paquete) == true)
            {
                MostrarExito("Paquete " + codigo + " registrado. Tarifa a 10 km: Q" + sistema.CalcularTarifaDelPaquete(paquete, 10));
            }
            else
            {
                MostrarError("No se pudo registrar el paquete.");
            }

            Pausa();
        }

        static void ConsultarPaquete()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código del paquete: ");
            Paquete paquete = sistema.BuscarPaquete(codigo);

            if (paquete == null)
            {
                MostrarError("No existe el paquete " + codigo + ".");
            }
            else
            {
                Console.WriteLine();
                paquete.MostrarInformacionPaquete();
                Console.WriteLine("Tarifa a 10 km: Q" + sistema.CalcularTarifaDelPaquete(paquete, 10));
            }

            Pausa();
        }

        static void ListarPaquetes()
        {
            Console.WriteLine();
            Console.WriteLine("Paquetes registrados: " + sistema.Paquetes.Count);
            Console.WriteLine();

            if (sistema.Paquetes.Count == 0)
            {
                Console.WriteLine("Todavía no hay paquetes.");
            }

            for (int i = 0; i < sistema.Paquetes.Count; i++)
            {
                Paquete paquete = sistema.Paquetes[i];
                Console.WriteLine(paquete.Codigo + "   " + paquete.Descripcion + "   " + paquete.Peso + " kg   Q" + paquete.Valordeclarado + "   " + paquete.Estado);
            }

            Pausa();
        }

        static void MenuEntregas()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("ENTREGAS");
                Console.WriteLine();
                Console.WriteLine("1. Crear solicitud de entrega");
                Console.WriteLine("2. Asignar repartidor y vehículo");
                Console.WriteLine("3. Consultar entrega");
                Console.WriteLine("4. Listar todas");
                Console.WriteLine("5. Listar solo las activas");
                Console.WriteLine("6. Cambiar estado");
                Console.WriteLine("7. Confirmar entrega");
                Console.WriteLine("8. Cancelar entrega");
                Console.WriteLine("9. Reprogramar entrega");
                Console.WriteLine("10. Calificar entrega");
                Console.WriteLine("11. Recalcular tarifa");
                Console.WriteLine("0. Regresar");
                Console.WriteLine();

                string opcion = LeerTexto("Opción: ");

                if (opcion == "1")
                {
                    CrearSolicitudDeEntrega();
                }
                else if (opcion == "2")
                {
                    AsignarRepartidorYVehiculo();
                }
                else if (opcion == "3")
                {
                    ConsultarEntrega();
                }
                else if (opcion == "4")
                {
                    ListarEntregas(false);
                }
                else if (opcion == "5")
                {
                    ListarEntregas(true);
                }
                else if (opcion == "6")
                {
                    ActualizarEstadoDeEntrega();
                }
                else if (opcion == "7")
                {
                    ConfirmarEntrega();
                }
                else if (opcion == "8")
                {
                    CancelarEntrega();
                }
                else if (opcion == "9")
                {
                    ReprogramarEntrega();
                }
                else if (opcion == "10")
                {
                    CalificarEntrega();
                }
                else if (opcion == "11")
                {
                    RecalcularTarifa();
                }
                else if (opcion == "0")
                {
                    return;
                }
                else
                {
                    MostrarError("Opción no válida.");
                }
            }
        }

        static void CrearSolicitudDeEntrega()
        {
            Console.WriteLine();
            Console.WriteLine("Crear solicitud de entrega");
            Console.WriteLine();

            if (sistema.Clientes.Count == 0)
            {
                MostrarError("Primero hay que registrar un cliente.");
                Pausa();
                return;
            }

            if (sistema.Paquetes.Count == 0)
            {
                MostrarError("Primero hay que registrar un paquete.");
                Pausa();
                return;
            }

            string codigocliente = LeerTexto("Código del cliente: ");
            string codigopaquete = LeerTexto("Código del paquete: ");
            double distancia = LeerNumero("Distancia estimada en km: ");

            if (distancia > 100)
            {
                MostrarError("GoXela solo cubre hasta 100 km a la redonda.");
                Pausa();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("1. NORMAL");
            Console.WriteLine("2. PRIORITARIO (25% más)");
            Console.WriteLine("3. URGENTE (60% más)");
            Console.WriteLine();

            string opcion = LeerTexto("Tipo de servicio: ");
            string tiposervicio = "NORMAL";

            if (opcion == "2")
            {
                tiposervicio = "PRIORITARIO";
            }
            else if (opcion == "3")
            {
                tiposervicio = "URGENTE";
            }

            Entrega entrega = sistema.CrearEntrega(codigocliente, codigopaquete, distancia, tiposervicio);

            if (entrega == null)
            {
                MostrarError("No se pudo crear la entrega.");
                Pausa();
                return;
            }

            sistema.CalcularTarifa(entrega.Codigo);

            MostrarExito("Entrega " + entrega.Codigo + " creada.");
            Console.WriteLine("Tarifa base: Q" + entrega.Tarifabase);
            Console.WriteLine("Recargos   : Q" + entrega.Recargos);
            Console.WriteLine("Descuentos : Q" + entrega.Descuentos);
            Console.WriteLine("Total      : Q" + entrega.Total);

            Pausa();
        }

        static void AsignarRepartidorYVehiculo()
        {
            Console.WriteLine();
            string codigoentrega = LeerTexto("Código de la entrega: ");
            Entrega entrega = sistema.BuscarEntrega(codigoentrega);

            if (entrega == null)
            {
                MostrarError("No existe la entrega " + codigoentrega + ".");
                Pausa();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Repartidores disponibles:");
            int cuantos = 0;

            for (int i = 0; i < sistema.Repartidores.Count; i++)
            {
                Repartidor repartidor = sistema.Repartidores[i];

                if (repartidor.Estado == "DISPONIBLE")
                {
                    Console.WriteLine("   " + repartidor.Codigo + "   " + repartidor.NombreCompleto + "   licencia " + repartidor.Tipolicencia);
                    cuantos = cuantos + 1;
                }
            }

            if (cuantos == 0)
            {
                MostrarError("No hay ningún repartidor disponible.");
                Pausa();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Vehículos disponibles:");
            cuantos = 0;

            for (int i = 0; i < sistema.Vehiculos.Count; i++)
            {
                Vehiculo vehiculo = sistema.Vehiculos[i];

                if (vehiculo.Estado == "DISPONIBLE")
                {
                    Console.WriteLine("   " + vehiculo.MyCodigo + "   " + vehiculo.MyMarca + " " + vehiculo.MyModelo + "   " + vehiculo.Mycargamaxima + " kg   pide licencia " + vehiculo.MytipoLicencia);
                    cuantos = cuantos + 1;
                }
            }

            if (cuantos == 0)
            {
                MostrarError("No hay ningún vehículo disponible.");
                Pausa();
                return;
            }

            Console.WriteLine();
            string codigorepartidor = LeerTexto("Código del repartidor: ");
            string codigovehiculo = LeerTexto("Código del vehículo: ");

            if (sistema.AsignarRepartidorYVehiculo(codigoentrega, codigorepartidor, codigovehiculo) == true)
            {
                MostrarExito("Entrega " + codigoentrega + " asignada.");
            }
            else
            {
                MostrarError("No se pudo asignar.");
            }

            Pausa();
        }

        static void ConsultarEntrega()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código de la entrega: ");
            Entrega entrega = sistema.BuscarEntrega(codigo);

            if (entrega == null)
            {
                MostrarError("No existe la entrega " + codigo + ".");
            }
            else
            {
                Console.WriteLine();
                entrega.MostrarInformacionEntrega();
            }

            Pausa();
        }

        static void ListarEntregas(bool soloactivas)
        {
            Console.WriteLine();

            if (soloactivas == true)
            {
                Console.WriteLine("Entregas activas: " + sistema.ContarEntregasActivas());
            }
            else
            {
                Console.WriteLine("Entregas registradas: " + sistema.Entregas.Count);
            }

            Console.WriteLine();

            for (int i = 0; i < sistema.Entregas.Count; i++)
            {
                Entrega entrega = sistema.Entregas[i];
                bool lamuestro = true;

                if (soloactivas == true && entrega.EstaActiva() == false)
                {
                    lamuestro = false;
                }

                if (lamuestro == true)
                {
                    string nombrerepartidor = "sin asignar";

                    if (entrega.Repartidor != null)
                    {
                        nombrerepartidor = entrega.Repartidor.NombreCompleto;
                    }

                    Console.WriteLine(entrega.Codigo + "   " + entrega.Cliente.NombreCompleto + "   " + entrega.Paquete.Codigo + "   " + entrega.Tiposervicio + "   Q" + entrega.Total + "   " + entrega.Estado + "   " + nombrerepartidor);
                }
            }

            Pausa();
        }

        static void ActualizarEstadoDeEntrega()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código de la entrega: ");
            Entrega entrega = sistema.BuscarEntrega(codigo);

            if (entrega == null)
            {
                MostrarError("No existe la entrega " + codigo + ".");
                Pausa();
                return;
            }

            if (entrega.EstaFinalizada() == true)
            {
                MostrarError("La entrega ya está " + entrega.Estado + " y no se puede mover.");
                Pausa();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Estado actual: " + entrega.Estado);
            Console.WriteLine();
            Console.WriteLine("1. RECOGIDA");
            Console.WriteLine("2. EN RUTA");
            Console.WriteLine("3. CON INCIDENCIA");
            Console.WriteLine();

            string opcion = LeerTexto("Nuevo estado: ");
            string nuevo = "";

            if (opcion == "1")
            {
                nuevo = "RECOGIDA";
            }
            else if (opcion == "2")
            {
                nuevo = "EN RUTA";
            }
            else if (opcion == "3")
            {
                nuevo = "CON INCIDENCIA";
            }
            else
            {
                MostrarError("Opción no válida.");
                Pausa();
                return;
            }

            if (sistema.CambiarEstadoEntrega(codigo, nuevo) == true)
            {
                MostrarExito("La entrega quedó en " + entrega.Estado + ".");
            }

            Pausa();
        }

        static void ConfirmarEntrega()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código de la entrega: ");
            Entrega entrega = sistema.BuscarEntrega(codigo);

            if (entrega == null)
            {
                MostrarError("No existe la entrega " + codigo + ".");
                Pausa();
                return;
            }

            if (sistema.CambiarEstadoEntrega(codigo, "ENTREGADA") == true)
            {
                MostrarExito("Entrega " + codigo + " confirmada. Se cobró Q" + entrega.Total);
                Console.WriteLine("El paquete quedó ENTREGADO y el repartidor y el vehículo volvieron a estar disponibles.");
            }

            Pausa();
        }

        static void CancelarEntrega()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código de la entrega: ");
            Entrega entrega = sistema.BuscarEntrega(codigo);

            if (entrega == null)
            {
                MostrarError("No existe la entrega " + codigo + ".");
                Pausa();
                return;
            }

            Console.WriteLine();
            entrega.MostrarInformacionEntrega();
            Console.WriteLine();

            string respuesta = LeerTexto("¿Seguro que la quiere cancelar? (s/n): ");

            if (respuesta.ToLower() != "s")
            {
                Console.WriteLine();
                Console.WriteLine("No se canceló nada.");
                Pausa();
                return;
            }

            if (sistema.CancelarEntrega(codigo) == true)
            {
                MostrarExito("Entrega " + codigo + " cancelada. El paquete quedó libre otra vez.");
            }

            Pausa();
        }

        static void ReprogramarEntrega()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código de la entrega: ");
            Entrega entrega = sistema.BuscarEntrega(codigo);

            if (entrega == null)
            {
                MostrarError("No existe la entrega " + codigo + ".");
                Pausa();
                return;
            }

            if (sistema.ReprogramarEntrega(codigo) == true)
            {
                MostrarExito("Entrega " + codigo + " reprogramada.");
                Console.WriteLine("Quedó sin repartidor ni vehículo, hay que asignarla de nuevo.");
            }

            Pausa();
        }

        static void CalificarEntrega()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código de la entrega: ");
            Entrega entrega = sistema.BuscarEntrega(codigo);

            if (entrega == null)
            {
                MostrarError("No existe la entrega " + codigo + ".");
                Pausa();
                return;
            }

            double nota = LeerNumero("Calificación del 1 al 5: ");

            if (sistema.CalificarEntrega(codigo, nota) == true)
            {
                MostrarExito("Gracias por calificar.");

                if (entrega.Repartidor != null)
                {
                    Console.WriteLine("El promedio de " + entrega.Repartidor.NombreCompleto + " quedó en " + entrega.Repartidor.Calificacion);
                }
            }

            Pausa();
        }

        static void RecalcularTarifa()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código de la entrega: ");
            Entrega entrega = sistema.BuscarEntrega(codigo);

            if (entrega == null)
            {
                MostrarError("No existe la entrega " + codigo + ".");
                Pausa();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Distancia actual: " + entrega.Distanciaestimada + " km");
            double distancia = LeerNumero("Distancia nueva en km: ");

            if (distancia <= 0 || distancia > 100)
            {
                MostrarError("La distancia debe estar entre 1 y 100 km.");
                Pausa();
                return;
            }

            entrega.Distanciaestimada = distancia;

            if (sistema.CalcularTarifa(codigo) == true)
            {
                MostrarExito("Tarifa recalculada.");
                Console.WriteLine("Tarifa base: Q" + entrega.Tarifabase);
                Console.WriteLine("Recargos   : Q" + entrega.Recargos);
                Console.WriteLine("Descuentos : Q" + entrega.Descuentos);
                Console.WriteLine("Total      : Q" + entrega.Total);
            }

            Pausa();
        }

        static void MenuIncidencias()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("INCIDENCIAS");
                Console.WriteLine();
                Console.WriteLine("1. Registrar incidencia");
                Console.WriteLine("2. Cerrar incidencia");
                Console.WriteLine("3. Consultar incidencia");
                Console.WriteLine("4. Listar todas");
                Console.WriteLine("5. Listar solo las abiertas");
                Console.WriteLine("6. Ver las de una entrega");
                Console.WriteLine("0. Regresar");
                Console.WriteLine();

                string opcion = LeerTexto("Opción: ");

                if (opcion == "1")
                {
                    RegistrarIncidencia();
                }
                else if (opcion == "2")
                {
                    CerrarIncidencia();
                }
                else if (opcion == "3")
                {
                    ConsultarIncidencia();
                }
                else if (opcion == "4")
                {
                    ListarIncidencias(false);
                }
                else if (opcion == "5")
                {
                    ListarIncidencias(true);
                }
                else if (opcion == "6")
                {
                    VerIncidenciasDeEntrega();
                }
                else if (opcion == "0")
                {
                    return;
                }
                else
                {
                    MostrarError("Opción no válida.");
                }
            }
        }

        static void RegistrarIncidencia()
        {
            Console.WriteLine();
            string codigoentrega = LeerTexto("Código de la entrega: ");
            Entrega entrega = sistema.BuscarEntrega(codigoentrega);

            if (entrega == null)
            {
                MostrarError("No existe la entrega " + codigoentrega + ".");
                Pausa();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("1. CLIENTE AUSENTE");
            Console.WriteLine("2. DIRECCION INCORRECTA");
            Console.WriteLine("3. PAQUETE DANADO");
            Console.WriteLine("4. VEHICULO AVERIADO");
            Console.WriteLine("5. RETRASO");
            Console.WriteLine("6. CLIMA");
            Console.WriteLine("7. RECHAZO");
            Console.WriteLine();

            string opcion = LeerTexto("Tipo: ");
            string tipo = "";

            if (opcion == "1")
            {
                tipo = "CLIENTE AUSENTE";
            }
            else if (opcion == "2")
            {
                tipo = "DIRECCION INCORRECTA";
            }
            else if (opcion == "3")
            {
                tipo = "PAQUETE DANADO";
            }
            else if (opcion == "4")
            {
                tipo = "VEHICULO AVERIADO";
            }
            else if (opcion == "5")
            {
                tipo = "RETRASO";
            }
            else if (opcion == "6")
            {
                tipo = "CLIMA";
            }
            else if (opcion == "7")
            {
                tipo = "RECHAZO";
            }
            else
            {
                MostrarError("Opción no válida.");
                Pausa();
                return;
            }

            string descripcion = LeerTexto("Qué pasó: ");
            string accion = LeerTextoOpcional("Qué se hizo (vacío si todavía no se resuelve): ");

            Incidencia incidencia = null;

            if (accion == "")
            {
                incidencia = sistema.RegistrarIncidencia(codigoentrega, tipo, descripcion);
            }
            else
            {
                incidencia = sistema.RegistrarIncidencia(codigoentrega, tipo, descripcion, accion);
            }

            if (incidencia == null)
            {
                MostrarError("No se pudo registrar la incidencia.");
            }
            else
            {
                MostrarExito("Incidencia " + incidencia.Codigo + " registrada.");
                Console.WriteLine("La entrega " + codigoentrega + " quedó en " + entrega.Estado + ".");
            }

            Pausa();
        }

        static void CerrarIncidencia()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código de la incidencia: ");
            Incidencia incidencia = sistema.BuscarIncidencia(codigo);

            if (incidencia == null)
            {
                MostrarError("No existe la incidencia " + codigo + ".");
                Pausa();
                return;
            }

            Console.WriteLine();
            incidencia.MostrarInformacionIncidencia();
            Console.WriteLine();

            string accion = LeerTexto("Qué se hizo para resolverla: ");

            if (sistema.CerrarIncidencia(codigo, accion) == true)
            {
                MostrarExito("Incidencia " + codigo + " cerrada.");
                Console.WriteLine("Ojo: la entrega sigue en CON INCIDENCIA. Hay que moverla desde el menú de entregas.");
            }

            Pausa();
        }

        static void ConsultarIncidencia()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código de la incidencia: ");
            Incidencia incidencia = sistema.BuscarIncidencia(codigo);

            if (incidencia == null)
            {
                MostrarError("No existe la incidencia " + codigo + ".");
            }
            else
            {
                Console.WriteLine();
                incidencia.MostrarInformacionIncidencia();
            }

            Pausa();
        }

        static void ListarIncidencias(bool soloabiertas)
        {
            Console.WriteLine();

            if (soloabiertas == true)
            {
                Console.WriteLine("Incidencias abiertas:");
            }
            else
            {
                Console.WriteLine("Incidencias registradas: " + sistema.Incidencias.Count);
            }

            Console.WriteLine();

            int cuantas = 0;

            for (int i = 0; i < sistema.Incidencias.Count; i++)
            {
                Incidencia incidencia = sistema.Incidencias[i];
                bool lamuestro = true;

                if (soloabiertas == true && incidencia.Estado != "ABIERTA")
                {
                    lamuestro = false;
                }

                if (lamuestro == true)
                {
                    Console.WriteLine(incidencia.Codigo + "   " + incidencia.Codigoentrega + "   " + incidencia.Tipo + "   " + incidencia.Estado);
                    cuantas = cuantas + 1;
                }
            }

            if (cuantas == 0)
            {
                Console.WriteLine("No hay nada que mostrar.");
            }

            Pausa();
        }

        static void VerIncidenciasDeEntrega()
        {
            Console.WriteLine();
            string codigo = LeerTexto("Código de la entrega: ");
            Entrega entrega = sistema.BuscarEntrega(codigo);

            if (entrega == null)
            {
                MostrarError("No existe la entrega " + codigo + ".");
                Pausa();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("La entrega " + codigo + " tiene " + entrega.Incidencias.Count + " incidencia(s).");
            Console.WriteLine();

            for (int i = 0; i < entrega.Incidencias.Count; i++)
            {
                entrega.Incidencias[i].MostrarInformacionIncidencia();
                Console.WriteLine();
            }

            Pausa();
        }

        static void MenuReportes()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("REPORTES");
                Console.WriteLine();
                Console.WriteLine("1. Entregas activas");
                Console.WriteLine("2. Entregas por repartidor");
                Console.WriteLine("3. Ingresos por tipo de servicio");
                Console.WriteLine("4. Paquetes por tipo");
                Console.WriteLine("5. Incidencias abiertas");
                Console.WriteLine("6. Resumen general");
                Console.WriteLine("0. Regresar");
                Console.WriteLine();

                string opcion = LeerTexto("Opción: ");

                if (opcion == "1")
                {
                    ReporteEntregasActivas();
                }
                else if (opcion == "2")
                {
                    ReporteEntregasPorRepartidor();
                }
                else if (opcion == "3")
                {
                    ReporteIngresos();
                }
                else if (opcion == "4")
                {
                    ReportePaquetesPorTipo();
                }
                else if (opcion == "5")
                {
                    ReporteIncidenciasAbiertas();
                }
                else if (opcion == "6")
                {
                    ReporteResumenGeneral();
                }
                else if (opcion == "0")
                {
                    return;
                }
                else
                {
                    MostrarError("Opción no válida.");
                }
            }
        }

        static void ReporteEntregasActivas()
        {
            Console.WriteLine();
            Console.WriteLine("Reporte 1 - Entregas activas");
            Console.WriteLine();

            int cuantas = 0;

            for (int i = 0; i < sistema.Entregas.Count; i++)
            {
                Entrega entrega = sistema.Entregas[i];

                if (entrega.EstaActiva() == true)
                {
                    string nombrerepartidor = "sin asignar";

                    if (entrega.Repartidor != null)
                    {
                        nombrerepartidor = entrega.Repartidor.NombreCompleto;
                    }

                    Console.WriteLine(entrega.Codigo + "   " + entrega.Cliente.NombreCompleto + "   " + entrega.Estado + "   Q" + entrega.Total + "   " + nombrerepartidor);
                    cuantas = cuantas + 1;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Total de entregas activas: " + cuantas);

            Pausa();
        }

        static void ReporteEntregasPorRepartidor()
        {
            Console.WriteLine();
            Console.WriteLine("Reporte 2 - Entregas por repartidor");
            Console.WriteLine();

            if (sistema.Repartidores.Count == 0)
            {
                Console.WriteLine("Todavía no hay repartidores.");
                Pausa();
                return;
            }

            for (int i = 0; i < sistema.Repartidores.Count; i++)
            {
                Repartidor repartidor = sistema.Repartidores[i];
                int asignadas = 0;

                for (int j = 0; j < sistema.Entregas.Count; j++)
                {
                    if (sistema.Entregas[j].Repartidor == repartidor)
                    {
                        asignadas = asignadas + 1;
                    }
                }

                Console.WriteLine(repartidor.Codigo + "   " + repartidor.NombreCompleto);
                Console.WriteLine("   entregas asignadas: " + asignadas + "   completadas: " + repartidor.Entregasrealizadas + "   calificación: " + repartidor.Calificacion);
            }

            Pausa();
        }

        static void ReporteIngresos()
        {
            Console.WriteLine();
            Console.WriteLine("Reporte 3 - Ingresos por tipo de servicio");
            Console.WriteLine();

            double normal = 0;
            double prioritario = 0;
            double urgente = 0;

            for (int i = 0; i < sistema.Entregas.Count; i++)
            {
                Entrega entrega = sistema.Entregas[i];

                if (entrega.Estado == "ENTREGADA")
                {
                    if (entrega.Tiposervicio == "PRIORITARIO")
                    {
                        prioritario = prioritario + entrega.Total;
                    }
                    else if (entrega.Tiposervicio == "URGENTE")
                    {
                        urgente = urgente + entrega.Total;
                    }
                    else
                    {
                        normal = normal + entrega.Total;
                    }
                }
            }

            Console.WriteLine("NORMAL      : Q" + normal);
            Console.WriteLine("PRIORITARIO : Q" + prioritario);
            Console.WriteLine("URGENTE     : Q" + urgente);
            Console.WriteLine();
            Console.WriteLine("Total cobrado: Q" + (normal + prioritario + urgente));
            Console.WriteLine("Solo cuenta las entregas ya ENTREGADAS.");

            Pausa();
        }

        static void ReportePaquetesPorTipo()
        {
            Console.WriteLine();
            Console.WriteLine("Reporte 4 - Paquetes por tipo");
            Console.WriteLine();

            int documentos = 0;
            int estandar = 0;
            int fragiles = 0;
            int refrigerados = 0;
            double pesototal = 0;

            for (int i = 0; i < sistema.Paquetes.Count; i++)
            {
                Paquete paquete = sistema.Paquetes[i];
                pesototal = pesototal + paquete.Peso;

                if (paquete is Documento)
                {
                    documentos = documentos + 1;
                }
                else if (paquete is PaqueteFragil)
                {
                    fragiles = fragiles + 1;
                }
                else if (paquete is ProductoRefrigerado)
                {
                    refrigerados = refrigerados + 1;
                }
                else
                {
                    estandar = estandar + 1;
                }
            }

            Console.WriteLine("Documentos  : " + documentos);
            Console.WriteLine("Estándar    : " + estandar);
            Console.WriteLine("Frágiles    : " + fragiles);
            Console.WriteLine("Refrigerados: " + refrigerados);
            Console.WriteLine();
            Console.WriteLine("Total de paquetes: " + sistema.Paquetes.Count + "   Peso total: " + pesototal + " kg");

            Pausa();
        }

        static void ReporteIncidenciasAbiertas()
        {
            Console.WriteLine();
            Console.WriteLine("Reporte 5 - Incidencias abiertas");
            Console.WriteLine();

            int cuantas = 0;

            for (int i = 0; i < sistema.Incidencias.Count; i++)
            {
                Incidencia incidencia = sistema.Incidencias[i];

                if (incidencia.Estado == "ABIERTA")
                {
                    Console.WriteLine(incidencia.Codigo + "   entrega " + incidencia.Codigoentrega + "   " + incidencia.Tipo);
                    Console.WriteLine("   " + incidencia.Descripcion);
                    cuantas = cuantas + 1;
                }
            }

            if (cuantas == 0)
            {
                Console.WriteLine("No hay incidencias abiertas.");
            }

            Console.WriteLine();
            Console.WriteLine("Total: " + cuantas);

            Pausa();
        }

        static void ReporteResumenGeneral()
        {
            Console.WriteLine();
            Console.WriteLine("Reporte 6 - Resumen general");
            Console.WriteLine();

            ResumenReporte resumen = sistema.ObtenerResumen();

            Console.WriteLine("Clientes registrados   : " + sistema.Clientes.Count);
            Console.WriteLine("Repartidores           : " + sistema.Repartidores.Count + "   (disponibles: " + sistema.ContarRepartidoresDisponibles() + ")");
            Console.WriteLine("Vehículos              : " + sistema.Vehiculos.Count + "   (disponibles: " + sistema.ContarVehiculosDisponibles() + ")");
            Console.WriteLine("Paquetes               : " + sistema.Paquetes.Count);
            Console.WriteLine("Incidencias            : " + sistema.Incidencias.Count);
            Console.WriteLine();
            Console.WriteLine("Entregas totales       : " + resumen.TotalEntregas);
            Console.WriteLine("   activas             : " + resumen.EntregasActivas);
            Console.WriteLine("   entregadas          : " + resumen.EntregasFinalizadas);
            Console.WriteLine("   canceladas          : " + resumen.EntregasCanceladas);
            Console.WriteLine();
            Console.WriteLine("Ingresos cobrados      : Q" + resumen.TotalIngresos);

            Pausa();
        }

        static void Main(string[] args)
        {
            MenuPrincipal();
        }
    }
}