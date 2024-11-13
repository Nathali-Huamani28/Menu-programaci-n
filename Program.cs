using System;
using System.Collections.Generic;
using System.Linq;

namespace DesayunoApp
{

    public class Desayuno
    {
        public string Nombre { get; set; }
        public string Cliente { get; set; }
        public decimal Precio { get; set; }
        public List<string> DiasDisponibles { get; set; }

        // Constructor de la clase Desayuno.
        public Desayuno(string nombre, string cliente)
        {
            Nombre = nombre;
            Cliente = cliente;
            Precio = ObtenerPrecioPorNombre(nombre);
            DiasDisponibles = ObtenerDiasDisponiblesPorNombre(nombre);
        }


        private decimal ObtenerPrecioPorNombre(string nombre)
        {
            switch (nombre)
            {
                case "El desayuno inglés":
                    return 15;
                case "El desayuno americano":
                    return 17;
                case "El desayuno suizo":
                    return 25;
                case "El desayuno singapurense":
                    return 30;
                default:
                    return 0;
            }
        }


        private List<string> ObtenerDiasDisponiblesPorNombre(string nombre)
        {
            switch (nombre)
            {
                case "El desayuno inglés":
                    return new List<string> { "Lunes", "Martes", "Miércoles" };
                case "El desayuno americano":
                    return new List<string> { "Martes", "Viernes", "Domingo" };
                case "El desayuno suizo":
                    return new List<string> { "Lunes", "Martes", "Miércoles" };
                case "El desayuno singapurense":
                    return new List<string> { "Jueves", "Sábado" };
                default:
                    return new List<string>();
            }
        }


        public override string ToString()
        {
            return $"{Nombre} - Cliente: {Cliente} - Precio: S/ {Precio} - Días disponibles: {string.Join(", ", DiasDisponibles)}";
        }
    }


    public class ProgramaDesayuno
    {
        private List<Desayuno> desayunos = new List<Desayuno>();
        private static readonly List<string> nombresDesayunos = new List<string>
        {
            "El desayuno inglés", "El desayuno americano", "El desayuno suizo", "El desayuno singapurense"
        };


        public void CrearDesayuno(string cliente)
        {
            Console.WriteLine("Seleccione un tipo de desayuno:");
            for (int i = 0; i < nombresDesayunos.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {nombresDesayunos[i]}");
            }

            int opcion;
            do
            {
                Console.Write("Ingrese el número del desayuno: ");
                if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 1 && opcion <= nombresDesayunos.Count)
                {
                    string nombreDesayuno = nombresDesayunos[opcion - 1];
                    Desayuno nuevoDesayuno = new Desayuno(nombreDesayuno, cliente);
                    desayunos.Add(nuevoDesayuno);
                    Console.WriteLine($"\n[✔] Desayuno '{nombreDesayuno}' creado y agregado a la lista para el cliente '{cliente}'.");
                    break;
                }
                else
                {
                    Console.WriteLine("[!] Opción inválida. Intente de nuevo.");
                }
            } while (true);
        }


        public void ListarDesayunos()
        {
            if (desayunos.Count == 0)
            {
                Console.WriteLine("No hay desayunos en la lista.");
            }
            else
            {
                foreach (var desayuno in desayunos)
                {
                    Console.WriteLine($"- {desayuno}");
                }
            }
        }


        public void SeleccionarDesayuno(string nombre, string dia)
        {
            Desayuno desayunoSeleccionado = desayunos.FirstOrDefault(d => d.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (desayunoSeleccionado != null)
            {
                if (desayunoSeleccionado.DiasDisponibles.Any(d => d.Equals(dia, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine($"\n[✔] Has seleccionado el desayuno '{nombre}' para el día '{dia}'.");
                }
                else
                {
                    Console.WriteLine($"\n[✖] El desayuno '{nombre}' no está disponible para el día '{dia}'. Intente con otro día.");
                }
            }
            else
            {
                Console.WriteLine($"\n[✖] No se encontró el desayuno con el nombre '{nombre}'. Por favor, verifica el nombre e intenta nuevamente.");
            }
        }
    }





}