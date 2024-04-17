using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic
{
    internal abstract class Pagar
    {
        public double Precio { get; set; }
        public Pagar() { }
        public Pagar(double precio)
        {
            Precio = precio;
        }

        public abstract void ProcesarPago();


        // Pedimos al usuario el método de pago

        public void Menu()
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.Write($"El precio a pagar es: {Precio}");
                // Precio = ;
                Console.WriteLine("--- ¿Con qué quieres pagar? ---");
                Console.WriteLine("1. Pagar con tarjeta");
                Console.WriteLine("2. Pagar con efectivo");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        PagarTarjeta pago = new PagarTarjeta();
                        pago.ProcesarPago();
                        break;
                    case 2:
                        Console.Write("Ingrese el dinero entregado: ");
                        double dineroIngresado = double.Parse(Console.ReadLine());
                        PagarEfectivo pagoEfectivo = new PagarEfectivo();
                        pagoEfectivo.ProcesarPago();
                        break;
                    case 3:
                        Console.WriteLine("Opción no valida");
                        break;
                }
                Console.WriteLine("Presiona una tecla para continuar");
                Console.ReadKey();
            } while (opcion != 2);
        }
    }
}
