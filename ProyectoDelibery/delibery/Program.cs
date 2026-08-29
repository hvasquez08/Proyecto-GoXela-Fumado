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
            public bool ValidarDatos()
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
                codigo = MyCodigo;
                placa = MyPlaca;
                marca = MyMarca;
                modelo = MyModelo;
                cargaMaxima = Mycargamaxima;
                costoOperativo = MycostoOperativo;
                tipoLicencia = MytipoLicencia;
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
        static void Main(string[] args)
        {
            Console.WriteLine("Menu :D");
        }
    }
}