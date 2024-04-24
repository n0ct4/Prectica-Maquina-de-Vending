using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

            //ProductosAlimenticios a = new ProductosAlimenticios(stockProductos.Count + 1, "patata", 1, 20, "rica", 100, 10, 1);
            //stockProductos.Add(a);


            Admin admin = new Admin("admin", "admin", stockProductos);
            usuarioAdmin.Add(admin);

            int opcion = 0;
            CargarContenidosDeArchivo();

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
                        Cliente c = new Cliente(stockProductos);//parametro stockproductos
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

        private static bool CargarContenidosDeArchivo() {
            bool productosCargados = false;
            try {
                if (File.Exists("productos.txt")) {
                    StreamReader sr = new StreamReader("productos.txt");
                    string linea;
                    while ((linea = sr.ReadLine()) != null) {
                        productosCargados = true;
                        string[] datos = linea.Split('|');
                        if (datos[1] == "Alimento") {
                            ProductosAlimenticios a = new ProductosAlimenticios(int.Parse(datos[0]), datos[2], int.Parse(datos[3]), double.Parse(datos[4]), datos[5], int.Parse(datos[6]), int.Parse(datos[7]), int.Parse(datos[8]));
                            stockProductos.Add(a);
                        }
                        else if (datos[1] == "ProductoElectronico") {
                            MaterialE materialE = new MaterialE();
                            switch (datos[5]) {
                                case "Aluminio":
                                    materialE = MaterialE.Aluminio;
                                    break;
                                case "Plastico":
                                    materialE = MaterialE.Plastico;
                                    break;
                                case "Metal":
                                    materialE = MaterialE.Metal;
                                    break;
                                case "Titanio":
                                    materialE = MaterialE.Titanio;
                                    break;
                                default:
                                    materialE = MaterialE.Metal;
                                    break;
                            }

                            ProductosElectronicos productoE = new ProductosElectronicos(int.Parse(datos[0]), datos[2], int.Parse(datos[3]), double.Parse(datos[4]), datos[5], materialE, bool.Parse(datos[7]), bool.Parse(datos[8]));
                            stockProductos.Add(productoE);

                        }
                        else {
                            Material material = new Material();
                            switch (datos[7]) {
                                case "Oro":
                                    material = Material.Oro;
                                    break;
                                case "Plata":
                                    material = Material.Plata;
                                    break;
                                case "Hierro":
                                    material = Material.Hierro;
                                    break;
                                case "Diamante":
                                    material = Material.Diamante;
                                    break;
                                default:
                                    break;
                                  
                            }

                            MaterialesPreciosos materialP = new MaterialesPreciosos(int.Parse(datos[0]), datos[2], int.Parse(datos[3]), double.Parse(datos[4]), datos[5], int.Parse(datos[6]), material);
                            stockProductos.Add(materialP);
                        }
                    }
                    sr.Close();
                }
                else {
                    File.Create("productos.txt").Close();
                }
            }
            catch (FileNotFoundException ex) {
                Console.WriteLine("No se encuentra el archivo de productos: " + ex.Message);
            }
            catch (IOException ex) {
                Console.WriteLine("Error de E/S: " + ex.Message);
            }
            return productosCargados;
        }
    }
}
