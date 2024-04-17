using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic
{
    internal class PagarTarjeta : Pagar
    {
        public int Cvv { get; set; }
        public int NumeroTarjeta { get; set; }
        public DateTime FechaCaducidad { get; set; }

        public PagarTarjeta() { }
        public PagarTarjeta(int cvv, int numeroTarjeta, DateTime fechaCaducidad, double precio) : base(precio)
        {
            Cvv = cvv;
            NumeroTarjeta = numeroTarjeta;
            FechaCaducidad = fechaCaducidad;
        }
        public override void ProcesarPago() // en el paréntesis tienen que ir el producto, tipo (Producto producto)
        {
            Console.Clear();
            // Pedimos los datos de la tarjeta
            Console.Write("Ingrese el número de tarjeta: ");
            int NumeroTarjeta = int.Parse(Console.ReadLine());
            Console.Write("Ingrese la fecha de caducidad (MM/AA): ");
            DateTime FechaCaducidad = DateTime.Parse(Console.ReadLine());
            Console.Write("Ingrese Cvv de la trajeta: ");
            int Cvv = int.Parse(Console.ReadLine());

            Console.WriteLine("--- Comprobando datos ---");
            Console.WriteLine("--- Realizando el cobro ---");
            Console.WriteLine("cargando...");
            Console.WriteLine("Pago realizado con éxito!!!!");
            Console.ReadKey();
        }
    }
}
