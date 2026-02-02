using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaDeBanco
{
    internal class Titular
    {
        public string Nombre { get; set; }
        public string ID { get; set; }
        private Double saldoCuenta = 0.0;

        public Titular(string nombre, string iD)
        {
            Nombre = nombre;
            ID = iD;
        }
        public virtual string MostrarInformacion()
        {
            return $"Nombre: {Nombre} \n" +
                $"Con ID: {ID}";
        }
        public void DepositarFondos(Double monto)
        {
            if (monto > 0)
            {
                saldoCuenta += monto;
                Console.WriteLine($"\nDepósito exitoso. Nuevo saldo de cuenta: {saldoCuenta}");
            }
            else
            {
                Console.WriteLine("\nEl monto a depositar debe ser mayor que cero.");
            }
        }
        public void RetirarFondos(Double monto)
        {
            if (monto > 0 && monto <= saldoCuenta)
            {
                saldoCuenta -= monto;
                Console.WriteLine($"\nRetiro exitoso. Nuevo saldo de cuenta: {saldoCuenta}");
            }
            else
            {
                Console.WriteLine("\nFondos insuficientes o monto inválido para el retiro.");
            }
        }
    }
}
