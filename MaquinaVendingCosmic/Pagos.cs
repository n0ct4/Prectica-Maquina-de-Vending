using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic
{
    internal class Pagos
    {
        public double Precio { get; set; }
        public double Vuelta { get; set; }
        public double DineroIngresado { get; set; }
        public string Cvv { get; set; }
        public string NumeroTarjeta { get; set; }
        public string FechaCaducidad { get; set; }
        public double totalPrecio { get; set; }
        public static List<Producto> stockProductos;
        public Pagos() { }

        public Pagos(double precio, double vuelta, double dineroIngresado, string cvv, string numeroTarjeta, string fechaCaducidad)
        {
            Precio = precio;
            Vuelta = vuelta;
            DineroIngresado = dineroIngresado;
            Cvv = cvv;
            NumeroTarjeta = numeroTarjeta;
            FechaCaducidad = fechaCaducidad;
        }        
        public void Menu(List<Producto> carrito,List<Producto> stockProductos)
        {
            int opcion = 0;
            do
            {
                foreach (var producto in carrito)
                {
                    totalPrecio += producto.PrecioUnitario;
                }
                Console.Clear();
                Console.Write($"El precio a pagar es: {totalPrecio}");
                Console.WriteLine("--- ¿Con qué quieres pagar? ---");
                Console.WriteLine("1. Pagar con tarjeta");
                Console.WriteLine("2. Pagar con efectivo");
                Console.WriteLine("Opción: ");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        stockProductos = PagarTarjeta(carrito, stockProductos);
                        opcion = 2;
                        break;
                    case 2:
                        stockProductos = PagarEfectivo(carrito, stockProductos);
                        break;
                    case 3:
                        Console.WriteLine("Opción no valida");
                        break;
                }
                Console.WriteLine("Presiona una tecla para continuar");
                Console.ReadKey();
            } while (opcion != 2);
        }
        public List<Producto> PagarTarjeta(List<Producto> carrito, List<Producto> stockProductos)
        {
            Console.WriteLine("Dime el numero de la tarjeta (16num): ");
            NumeroTarjeta = Console.ReadLine();
            Console.WriteLine("Fecha de caducidad (Ejemplo: 24/25): ");
            FechaCaducidad = Console.ReadLine();
            Console.WriteLine("Dime el CVV ");
            Cvv = Console.ReadLine();
            if (ValidarTarjeta(NumeroTarjeta) && ValidarCVV(Cvv) && ValidarFechaCaducidad(FechaCaducidad))
            {
                Console.WriteLine("--- Comprobando datos ---");
                Console.WriteLine("cargando...");
                Console.WriteLine("--- Realizando el cobro ---");

                Console.WriteLine("¡Pago exitoso!");
                Console.WriteLine("Gracias por su compra, que tenga un buen día");
            }
            else
            {
                Console.WriteLine("--- Comprobando datos ---");
                Console.WriteLine("cargando...");
                Console.WriteLine("Tarjeta no válida. Por favor, verifica los datos e intenta nuevamente.");
            }
            stockProductos = EliminarProductos(carrito, stockProductos);
            carrito = null;
            return stockProductos;
        }
        static bool ValidarTarjeta(string numeroTarjeta)
        {
            // Verificar si el número de tarjeta tiene 16 dígitos
            // .Lenght sirve para verificar si el string recibido por parametro sirve para comprobar si la tarjeta tiene 16 digitos
            return numeroTarjeta.Length == 16;
        }
        static bool ValidarCVV(string cvv)
        {
            // Verificar si el CVV tiene 3 dígitos
            return cvv.Length == 3;
        }
        static bool ValidarFechaCaducidad(string FechaCaducidad)
        {
            // Verificar si la fecha de caducidad tiene el formato MM/YY
            if (FechaCaducidad.Length != 5 || FechaCaducidad[2] != '/')
            {
                return false;

            }
            return true;
        }
        public List<Producto> PagarEfectivo(List<Producto> carrito, List<Producto> stockProductos)
        {
            double dineroDebe = totalPrecio;
            double llevaPagado = DineroIngresado;
            do
            {
                Console.Clear();
                Console.WriteLine($"Debes {totalPrecio}$");
                Console.WriteLine($"Has metido:{llevaPagado}");
                Console.WriteLine("Indique como va a pagar?");
                Console.WriteLine("Billetes");
                Console.WriteLine("1. 50$");
                Console.WriteLine("2. 20$");
                Console.WriteLine("3. 10$");
                Console.WriteLine("4. 5$");
                Console.WriteLine("Monedas");
                Console.WriteLine("5. 2$");
                Console.WriteLine("6. 1$");
                Console.WriteLine("7. 0.50$");
                Console.WriteLine("8. 0.20$");
                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        llevaPagado = llevaPagado + 50;
                        break;
                    case 2:
                        llevaPagado = llevaPagado + 20;
                        break;
                    case 3:
                        llevaPagado = llevaPagado + 10;
                        break;
                    case 4:
                        llevaPagado = llevaPagado + 5;
                        break;
                    case 5:
                        llevaPagado = llevaPagado + 2;
                        break;
                    case 6:
                        llevaPagado += 1;
                        break;
                    case 7:
                        llevaPagado += 0.5;
                        break;
                    case 8:
                        llevaPagado += 0.20;
                        break;
                }
            } while (dineroDebe > llevaPagado);
            if (dineroDebe == llevaPagado)
            {
                Console.WriteLine("Gracias por su compra :), que tenga un buen día ");
            }
            else if (dineroDebe < llevaPagado)
            {
                Console.Clear();
                Console.WriteLine($"Pago {llevaPagado}");
                Vueltas(dineroDebe, llevaPagado);
            }
            stockProductos = EliminarProductos(carrito, stockProductos);
            carrito = null;
            return stockProductos;
        }

        public void Vueltas(double montoAPagar, double montoIngresado)
        {
            // Calculamos las vueltas
            double vueltas = Math.Round(montoIngresado - montoAPagar, 2);

            // Definimos el valor de cada moneda
            double[] monedas = { 2.0, 1.0, 0.50, 0.20, 0.10 };

            // Recorremos el array de monedas para calcular la cantidad de cada una
            foreach (double moneda in monedas)
            {
                int cantidad = (int)(vueltas / moneda);
                vueltas -= cantidad * moneda;
                if (cantidad > 0)
                {
                    Console.WriteLine($"Se le han devuelto  {cantidad}  monedas de  {moneda} euros.");
                    Console.WriteLine("Gracias por su compra, que tenga un buen día");
                }
            }
        }
        //Elimina del stock de productos el producto comprado y lo vacia del carrito
        public static List<Producto> EliminarProductos(List<Producto> carrito, List<Producto> stock)
        {
            //Cada producto comprado lo quitamos de las unidades del stock
            foreach (Producto producto in carrito)
            {
                foreach (Producto prodStock in stock)
                {
                    if (producto.Nombre == prodStock.Nombre)
                    {
                        prodStock.Unidades--;
                    }
                }
            }
            return stock;
        }
    }
}


