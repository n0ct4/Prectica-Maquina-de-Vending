using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic {
    internal class Program {

        static List<Producto> stockProductos;
        static List<Admin> usuarioAdmin;

        static void Main(string[] args) {

            stockProductos = new List<Producto>();
            usuarioAdmin = new List<Admin>();

            ProductosAlimenticios a = new ProductosAlimenticios(stockProductos.Count + 1, "patata", 1, 20, "sabrosa", 2, 0, 20);
            stockProductos.Add(a);
            
            Admin admin = new Admin("admin", "admin");
            usuarioAdmin.Add(admin);

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
                        Cliente c = new Cliente();//parametro stockproductos
                        c.Menu();
                        break;
                    case 2:
                        // Menu id producto y mostrar info
                        break;
                    case 3:
                        // Menu admin
                        //Admin admin = new Admin("admin", "admin");
                        LoginAdmin();
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

        public static void LoginAdmin() {
            Console.Write("Nombre de usuario: ");
            string nombre = Console.ReadLine();
            Console.Write("Constraseña: ");
            string password = Console.ReadLine();

            bool usuarioEncontrado = false;
            foreach(Admin a in usuarioAdmin) {
                if (a.Login(nombre, password)) {
                    usuarioEncontrado = true;
                    a.Menu();
                }
                if (!usuarioEncontrado) {
                    Console.WriteLine("Usuario o contraseña incorrectos");
                }
            }
        }
    }
}
