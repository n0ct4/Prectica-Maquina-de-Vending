using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic {
    internal class Program {
        static void Main(string[] args) {

            int opcion = 0;

            do {
                Console.Clear();
                Console.WriteLine("--- Máquina Expendedora ---");
                Console.WriteLine("1. Comprar productos");
                Console.WriteLine("2. Mostrar información del producto");

                Console.WriteLine("4. Salir");
                Console.Write("\nSeleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion) {
                    case 1:
                        // Comprar producto
                        break;
                    case 2:
                        // Menu id producto y mostrar info
                        break;
                    case 3:
                        // Menu admin
                        break;
                    case 4:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
            } while (opcion != 4);
        }
    }
}
