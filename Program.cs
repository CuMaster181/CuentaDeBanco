using CuentaDeBanco;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoPOO
{
    class Program
    {
        public static List<Titular> listaTitulares = new List<Titular>();
        public static string GenerarID()
        {
            Random rnd = new Random();
            int numero = rnd.Next(100, 1000);
            return numero.ToString();
        }


        static void Main(string[] args)
        {

            int caso = -1;
            do
            {
                Console.WriteLine("\n--- Menú de Banco POO ---");
                Console.WriteLine("0. Salir");
                Console.WriteLine("1. Registrar Titular");
                Console.WriteLine("2. Depositar");
                Console.WriteLine("3. Retirar");
                if (!int.TryParse(Console.ReadLine(), out caso))
                {
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    Console.Clear();
                    continue;
                }
                switch (caso)
                {
                    case 1:
                        Console.Write("Ingrese el nombre del titular: ");
                        string nombre = Console.ReadLine();

                        string idGenerado = GenerarID();

                        Titular nuevoTitular = new Titular(nombre, idGenerado);
                        listaTitulares.Add(nuevoTitular);
                        Console.WriteLine($"Titular registrado exitosamente. ID asignado: {idGenerado}");

                        break;
                    case 2:
                        Console.Write("Ingrese el ID del titular: ");
                        string idBuscado = Console.ReadLine()?.Trim();

                        // Línea corregida: comparar con la propiedad ID
                        Titular titularSeleccionado = listaTitulares.FirstOrDefault(t => t.ID == idBuscado);

                        if (titularSeleccionado != null)
                        {
                            Console.Write("Ingrese el monto: ");
                            if (double.TryParse(Console.ReadLine(), out double monto))
                            {
                                titularSeleccionado.DepositarFondos(monto);
                            }
                            else
                            {
                                Console.WriteLine("Monto inválido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontró un titular con ese ID.");
                        }
                        break;
                    case 3:
                        Console.Write("Ingrese el ID del titular: ");
                        string idBuscadoRetiro = Console.ReadLine();
                        Titular titularSeleccionadoRetiro = listaTitulares.FirstOrDefault(t => t.ID == idBuscadoRetiro);
                        if (titularSeleccionadoRetiro != null)
                        {
                            Console.Write("Ingrese el monto a retirar: ");
                            if (double.TryParse(Console.ReadLine(), out double montoRetiro))
                            {
                                titularSeleccionadoRetiro.RetirarFondos(montoRetiro);
                            }
                            else
                            {
                                Console.WriteLine("Monto inválido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontró un titular con ese ID.");
                        }
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa.");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            } while (caso != 0);
        }
    }
}
