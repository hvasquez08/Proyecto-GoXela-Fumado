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
                // YA ESTA LA CLASE VEHICULO, YA Podes HACER LA CLASE REPARTIDOR XDDD

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
        }
        class Motocicleta : Vehiculo
        {
            public Motocicleta(string codigo, string placa, string marca, string modelo, double cargaMaxima, double costoOperativo, string tipoLicencia) : base(codigo, placa, marca, modelo, cargaMaxima, costoOperativo, tipoLicencia)

            {

            }
        }
        class automovil : Vehiculo
        {
            public automovil(string codigo, string placa, string marca, string modelo, double cargaMaxima, double costoOperativo, string tipoLicencia) : base(codigo, placa, marca, modelo, cargaMaxima, costoOperativo, tipoLicencia)

            {

            }
        }
        static void Main(string[] args)
        {
            console.WriteLine("Prueba de que funciona mi rama :D");
            Console.WriteLine("Menu :D");
        }
    }
}