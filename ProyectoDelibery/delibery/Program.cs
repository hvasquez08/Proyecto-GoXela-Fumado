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

            }

        }
            static void Main(string[] args)
            {
            }
        }
    }