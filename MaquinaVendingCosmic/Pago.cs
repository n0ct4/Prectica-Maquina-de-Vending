using MaquinaVendingCosmic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MaquinaVendingCosmic
{
    internal class Pago
    {
        public double Precio { get; set; }
        public double Vuelta { get; set; }
        public double DineroIngresado { get; set; }
        public string Cvv { get; set; }
        public string NumeroTarjeta { get; set; }
        public string FechaCaducidad { get; set; }

        public Pago() { }

        public Pago(double precio, double vuelta, double dineroIngresado, string cvv, string numeroTarjeta, string fechaCaducidad)
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
                Console.Clear();
                Precio = 10;
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
            Console.WriteLine("Dime el numero de la tarjeta: ");
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
            double vueltas = Vuelta;
            Console.WriteLine("Va a pagar a 1.Billetes o 2.Monedas");
            int opcionCash = 0;
            if(opcionCash == 1)
            {
                
                do
                {
                    Console.WriteLine($"Debes {Precio}$");
                    Console.WriteLine($"Has metido:{llevaPagado}");
                    Console.WriteLine("¿Con que billete va a pagar?");
                    Console.WriteLine("1. 50$");
                    Console.WriteLine("2. 20$");
                    Console.WriteLine("3. 10$");
                    Console.WriteLine("4. 5$");
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
                        case 4: llevaPagado = llevaPagado + 5;
                            break;

                    }
                } while (dineroDebe >= llevaPagado);
                if(dineroDebe == llevaPagado)
                {
                    Console.WriteLine("Gracias por su compra :) ");
                }
                else if (dineroDebe < llevaPagado)
                {
                    vueltas = llevaPagado - dineroDebe;
                    Console.WriteLine($"sus vueltas son: {vueltas}");
                    Console.WriteLine("Muchas gracias por su compra");
                }
            }
            else if (opcionCash == 2) 
            {
                Console.WriteLine($"Debes {Precio}$");
                Console.WriteLine($"Has metido:{llevaPagado}");
                Console.WriteLine("¿Con que monedas va a pagar?");
                Console.WriteLine("1. 2$");
                Console.WriteLine("2. 1$");
                Console.WriteLine("3. 0.50$");
                Console.WriteLine("4. 0.20$");
                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        llevaPagado = llevaPagado + 2;
                        break;
                    case 2:
                        llevaPagado = llevaPagado + 1;
                        break;
                    case 3:
                        llevaPagado = llevaPagado + 0.50;
                        break;
                    case 4:
                        llevaPagado = llevaPagado + 0.20;
                        break;

                }
            } while (dineroDebe >= llevaPagado) ;
            if (dineroDebe == llevaPagado)
            {
                Console.WriteLine("Gracias por su compra :) ");
            }
            else if (dineroDebe < llevaPagado)
            {
                vueltas = llevaPagado - dineroDebe;
                Console.WriteLine($"sus vueltas son: {vueltas}");
                Console.WriteLine("Muchas gracias por su compra");
            }
        }
        }
        /*public  void ProcesarPago()
        {

        }*/


        // Pedimos al usuario el método de pago

        
    }

