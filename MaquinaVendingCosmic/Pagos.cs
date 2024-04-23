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

        public void Menu()
        {
            int opcion = 0;
            do
            {
                //Falta declarar unicamente el carrito los metodo de pago y vueltas ya estan
                Cliente c = new Cliente();

                Console.Clear();
                Precio = 10.00;
                Console.Write($"El precio a pagar es: {Precio}");
                // Precio = ;
                Console.WriteLine("--- ¿Con qué quieres pagar? ---");
                Console.WriteLine("1. Pagar con tarjeta");
                Console.WriteLine("2. Pagar con efectivo");
                Console.WriteLine("Opción: ");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        PagarTarjeta();
                        Console.WriteLine("Gracias Por su compra");
                        break;
                    case 2:
                        PagarEfectivo();
                        break;
                    case 3:
                        Console.WriteLine("Opción no valida");
                        break;
                }
                Console.WriteLine("Presiona una tecla para continuar");
                Console.ReadKey();
            } while (opcion != 2);
        }
        public void PagarTarjeta()
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
            }
            else
            {
                Console.WriteLine("--- Comprobando datos ---");
                Console.WriteLine("cargando...");
                Console.WriteLine("Tarjeta no válida. Por favor, verifica los datos e intenta nuevamente.");
            }

        }
        static bool ValidarTarjeta(string numeroTarjeta)
        {
            // Verificar si el número de tarjeta tiene 16 dígitos
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
        public void PagarEfectivo()
        {
            double dineroDebe = Precio;
            double llevaPagado = DineroIngresado;
       
            do
            {
                Console.Clear();
                Console.WriteLine($"Debes {Precio}$");
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
                Console.WriteLine("Gracias por su compra :) ");
            }
            else if (dineroDebe < llevaPagado)
            {
                Console.Clear();
                Console.WriteLine($"Pago {llevaPagado}");
                Vueltas(dineroDebe, llevaPagado);
                /*double moneda2 = 0;
                double moneda1 = 0;
                double moneda50 = 0;
                double moneda01 = 0;
                vueltas = llevaPagado - dineroDebe;
                do
                {
                    int nmonedas2;
                    int nmonedas1;  
                    int nmonedas50;
                    int nmonedas01;
                    if (vueltas >= 2)
                    { //poner numero de monedas a devolver Para tenerlo ya hecho
                        
                        moneda2 = +1;
                        vueltas -= 2;
                        
                    }
                    else if (vueltas < 2 && vueltas >= 1)
                    {
                        moneda1 = +1;
                        vueltas -= 1;

                    }
                    else if (vueltas < 1 && vueltas >= 0.50)
                    {
                        moneda50 = +1;
                        vueltas -= 0.50;

                    }
                    else
                    {
                        moneda01 = +1;
                        vueltas -= 0.01;
                    }
                    
                    
                } while (vueltas != 0);
                Console.WriteLine($"{moneda2}, {moneda1}, {moneda50} , {moneda01}"); */
              
                   /* vueltas = llevaPagado - dineroDebe;
                    Console.WriteLine($"sus vueltas son: {vueltas}");
                    Console.WriteLine("Muchas gracias por su compra");*/
           

            }

        }
        public void Vueltas(double dineroDebe, double llevaPagado)
        {
            double vueltas;
            double moneda2 = 0;
            double moneda1 = 0;
            double moneda50 = 0;
            double moneda01 = 0;
            vueltas = llevaPagado - dineroDebe;
            do
            {
              
                if (vueltas >= 2)
                { //poner numero de monedas a devolver Para tenerlo ya hecho

                    moneda2 = 1 + moneda2;
                    vueltas -= 2;

                }
                else if (vueltas < 2 && vueltas >= 1)
                {
                    moneda1 = 1 + moneda1;
                    vueltas -= 1;

                }
                else if (vueltas < 1 && vueltas >= 0.50)
                {
                    moneda50 = 1 + moneda50;
                    vueltas -= 0.50;

                }
                else if(vueltas < 0.50 && vueltas > 0)
                {
                    moneda01 = 1 + moneda01;
                    vueltas -= 0.01;
                }

              

            } while (vueltas != 0 ); //ni idea de porque no funciona
            Console.WriteLine("Muchas gracias por su compra");
            Console.WriteLine($"Monedas de 2$: {moneda2}\n Monedas de 1$: {moneda1}\n Monedas de 0.50$: {moneda50} \n Monedas de 0.01$: {moneda01}");
        }

    }
}
