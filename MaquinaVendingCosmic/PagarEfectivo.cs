using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic
{
    internal class PagarEfectivo : Pagar
    {
        public double Vuelta { get; set; }
        public double DineroIngresado { get; set; }
        public PagarEfectivo() { }
        public PagarEfectivo(double vuelta, double dineroIngresado, double precio) : base(precio)
        {
            Vuelta = vuelta;
            DineroIngresado = dineroIngresado;
        }
        public override void ProcesarPago()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el dinero entregado: ");
            double dineroIngresado = double.Parse(Console.ReadLine());
            Vuelta = dineroIngresado - Precio;
            if (Vuelta < 0)
            {
                Console.WriteLine("El dinero ingresado es insuficiente");
            }
            else
            {
                Console.WriteLine($"El cambio es de: {Vuelta}, monedas");
                DevolverCambio(Vuelta);
            }
            Console.ReadKey();
        }
        public void DevolverCambio(double Vuelta)
        {
            int[] monedas = { 50, 20, 10, 5, 2, 1 }; // son todos los valores del céntimo que hay
            Console.WriteLine("Se devuelve el cambio en monedas: ");
            foreach (int moneda in monedas)
            {
                int cantidadMonedas = (int)(Vuelta / moneda);
                if (cantidadMonedas > 0)
                {
                    Console.WriteLine($"{0} monedas de {1}", cantidadMonedas, moneda);
                    Vuelta -= cantidadMonedas * moneda;
                }
            }
            Console.ReadKey();
        }
    }
}
