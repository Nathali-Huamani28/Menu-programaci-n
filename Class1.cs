using System;

namespace DesayunoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProgramaDesayuno programa = new ProgramaDesayuno(); // Instancia única

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("      MENU DE DESAYUNOS");
                Console.WriteLine("=================================");
                Console.WriteLine("1) Crear desayuno");
                Console.WriteLine("2) Listar desayunos");
                Console.WriteLine("3) Seleccionar desayuno");
                Console.WriteLine("4) Salir");
                Console.WriteLine("=================================");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el nombre del cliente: ");
                        string cliente = Console.ReadLine();
                        programa.CrearDesayuno(cliente);
                        break;

                    case "2":
                        programa.ListarDesayunos();
                        break;

                    case "3":
                        Console.Write("Ingrese el nombre del desayuno: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese el día para el desayuno: ");
                        string dia = Console.ReadLine();
                        programa.SeleccionarDesayuno(nombre, dia);
                        break;

                    case "4":
                        Console.WriteLine("¡Gracias por usar el programa! Saliendo...");
                        return;

                    default:
                        Console.WriteLine("[!] Opción no válida, por favor intente nuevamente.");
                        break;
                }

                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}