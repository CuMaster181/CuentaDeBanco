using cuenta_bancaria;
using System;
using System.Collections.Generic;


namespace BancoPOO
{
    class Program
    {
        public static List<Titular> listaTitulares = new List<Titular>();

        static int SeleccionTitulares<Titular>(List<Titular> lista)
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay Titulares Registrados.");
                return -1;
            }

            Console.WriteLine("\n--- Titulares Registrados ---");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {lista[i].Nombre} (ID: {lista[i].ID})");
            }

            Console.Write("Seleccione el producto por número (o 0 para cancelar): ");
            if (int.TryParse(Console.ReadLine(), out int seleccion) && seleccion > 0 && seleccion <= lista.Count)
            {
                return seleccion - 1;
            }
            return -1;
        }

    }
}
