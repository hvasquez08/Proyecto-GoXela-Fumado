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

        static void Main(string[] args)
        {
            Console.WriteLine("Menu :D");
        }
    }
}