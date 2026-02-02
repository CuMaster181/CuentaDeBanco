using CuentaDeBanco;
using System;
using System.Collections.Generic;

namespace BancoPOO
{
    class Program
    {
        public static List<Titular> listaTitulares = new List<Titular>();

        static int SeleccionTitulares(List<Titular> lista)
        {
            if (lista == null || lista.Count == 0)
            {
                Console.WriteLine("No hay Titulares Registrados.");
                return -1;
            }

            Console.WriteLine("\n--- Titulares Registrados ---");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {lista[i].Nombre} (ID: {lista[i].ID})");
            }

            Console.Write("Seleccione el titular por número (o 0 para cancelar): ");
            if (int.TryParse(Console.ReadLine(), out int seleccion) && seleccion > 0 && seleccion <= lista.Count)
            {
                return seleccion - 1;
            }
            return -1;
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
                        Console.Write("Ingrese el ID del titular: ");
                        string id = Console.ReadLine();
                        Titular nuevoTitular = new Titular(nombre, id);
                        listaTitulares.Add(nuevoTitular);
                        Console.WriteLine("Titular registrado exitosamente.");
                        break;
                    case 2:
                        int indiceDeposito = SeleccionTitulares(listaTitulares);
                        if (indiceDeposito != -1)
                        {
                            Console.Write("Ingrese el monto a depositar: ");
                            if (Double.TryParse(Console.ReadLine(), out Double montoDeposito))
                            {
                                listaTitulares[indiceDeposito].DepositarFondos(montoDeposito);
                            }
                            else
                            {
                                Console.WriteLine("Monto inválido.");
                            }
                        }
                        break;
                    case 3:
                        int indiceRetiro = SeleccionTitulares(listaTitulares);
                        if (indiceRetiro != -1)
                        {
                            Console.Write("Ingrese el monto a retirar: ");
                            if (Double.TryParse(Console.ReadLine(), out Double montoRetiro))
                            {
                                listaTitulares[indiceRetiro].RetirarFondos(montoRetiro);
                            }
                            else
                            {
                                Console.WriteLine("Monto inválido.");
                            }
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
