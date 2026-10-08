using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroilanVargas
{
    internal class Program
    {
        const int N = 13;

        static int[] numeros = new int[N];
        static string[] nombres = new string[N];
        static int[] urgencias = new int[N];

        static int cantidad = 0;

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                MostrarMenu();
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarPaciente();
                        break;

                    case 2:
                        ModificarUrgencia();
                        break;

                    case 3:
                        EliminarPaciente();
                        break;

                    case 4:
                        ConsultarPacientes();
                        break;

                    case 5:
                        MostrarReporte();
                        break;

                    case 6:
                        Console.WriteLine("Fin del programa.");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine();

            } while (opcion != 6);
        }


        static void MostrarMenu()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("       HOSPITAL SAN RAFAEL");
            Console.WriteLine("       AISLAMIENTO CRÍTICO");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Registrar paciente");
            Console.WriteLine("2. Modificar nivel de urgencia");
            Console.WriteLine("3. Eliminar paciente");
            Console.WriteLine("4. Consultar pacientes");
            Console.WriteLine("5. Reporte de pacientes");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
        }


        static void RegistrarPaciente()
        {
            if (cantidad < N)
            {
                Console.Write("Número del paciente: ");
                numeros[cantidad] = int.Parse(Console.ReadLine());

                Console.Write("Nombre del paciente: ");
                nombres[cantidad] = Console.ReadLine();

                do
                {
                    Console.Write("Nivel de urgencia (1 al 5): ");
                    urgencias[cantidad] = int.Parse(Console.ReadLine());

                    if (urgencias[cantidad] < 1 || urgencias[cantidad] > 5)
                    {
                        Console.WriteLine("Urgencia inválida. Debe estar entre 1 y 5.");
                    }

                } while (urgencias[cantidad] < 1 || urgencias[cantidad] > 5);

                cantidad++;

                Console.WriteLine("Paciente registrado correctamente.");
            }
            else
            {
                Console.WriteLine("No hay espacio disponible.");
                Console.WriteLine("Se alcanzó el límite de 13 pacientes.");
            }
        }


        static void ModificarUrgencia()
        {
            int numeroBuscar;
            int nuevaUrgencia;
            bool encontrado = false;

            Console.Write("Ingrese el número del paciente: ");
            numeroBuscar = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidad; i++)
            {
                if (numeros[i] == numeroBuscar)
                {
                    encontrado = true;

                    do
                    {
                        Console.Write("Ingrese el nuevo nivel de urgencia (1 al 5): ");
                        nuevaUrgencia = int.Parse(Console.ReadLine());

                        if (nuevaUrgencia < 1 || nuevaUrgencia > 5)
                        {
                            Console.WriteLine("Urgencia inválida. Debe estar entre 1 y 5.");
                        }

                    } while (nuevaUrgencia < 1 || nuevaUrgencia > 5);

                    urgencias[i] = nuevaUrgencia;

                    Console.WriteLine("Nivel de urgencia actualizado.");
                }
            }

            if (encontrado == false)
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }


        static void EliminarPaciente()
        {
            int numeroBuscar;
            bool encontrado = false;

            Console.Write("Ingrese el número del paciente: ");
            numeroBuscar = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidad; i++)
            {
                if (numeros[i] == numeroBuscar)
                {
                    encontrado = true;

                    for (int j = i; j < cantidad - 1; j++)
                    {
                        numeros[j] = numeros[j + 1];
                        nombres[j] = nombres[j + 1];
                        urgencias[j] = urgencias[j + 1];
                    }

                    cantidad--;

                    Console.WriteLine("Paciente eliminado correctamente.");
                    break;
                }
            }

            if (encontrado == false)
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }


        static void ConsultarPacientes()
        {
            if (cantidad > 0)
            {
                Console.WriteLine("===== PACIENTES REGISTRADOS =====");

                for (int i = 0; i < cantidad; i++)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Número: " + numeros[i]);
                    Console.WriteLine("Nombre: " + nombres[i]);
                    Console.WriteLine("Nivel de urgencia: " + urgencias[i]);
                }
            }
            else
            {
                Console.WriteLine("No hay pacientes registrados.");
            }
        }


        static void MostrarReporte()
        {
            Console.WriteLine("===== REPORTE DE PACIENTES =====");
            Console.WriteLine("Cantidad de pacientes: " + cantidad);

            if (cantidad > 0)
            {
                for (int i = 0; i < cantidad; i++)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Número: " + numeros[i]);
                    Console.WriteLine("Nombre: " + nombres[i]);
                    Console.WriteLine("Nivel de urgencia: " + urgencias[i]);
                }
            }
            else
            {
                Console.WriteLine("No hay pacientes registrados.");
            }
        }
    }
}