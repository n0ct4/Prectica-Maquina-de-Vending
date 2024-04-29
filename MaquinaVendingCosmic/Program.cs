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

           /* ProductosAlimenticios p = new ProductosAlimenticios(0, "patata", 1, 150, "rica", 12, 10, 0);
            stockProductos.Add(p); */
            //ProductosAlimenticios a = new ProductosAlimenticios(stockProductos.Count + 1, "patata", 1, 20, "sabrosa", 2, 0, 20);
            //stockProductos.Add(a);
            
            //Admin admin = new Admin("admin", "admin");

            usuarioAdmin.Add(admin);

            int opcion = 0;
            CargarContenidosDeArchivo();

            do {
                Console.Clear();
                Console.WriteLine("------------------------------------");
                Console.WriteLine(" - Máquina Expendedora Cósmica - ");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("\t1. Comprar productos");
                Console.WriteLine("\t2. Mostrar información del producto");

                Console.WriteLine("\t4. Salir");
                Console.Write("\nSeleccione una opción: ");
                try {
                    opcion = int.Parse(Console.ReadLine());
                    switch (opcion) {
                        case 1:
                            Cliente c = new Cliente(stockProductos);//parametro stockproductos
                            c.Menu();
                            break;
                        case 2:
                            // Menu id producto y mostrar info
                            // Crea cliente para llamar a la funcion Listar y poder ver los productos
                            Cliente c2 = new Cliente(stockProductos);
                            c2.ListarAlimentos();

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
                }
                catch (FormatException e) {
                    Console.WriteLine("Error: Opción inválida. Por favor, ingrese un número válido.");
                }
                catch (Exception ex) {
                    Console.WriteLine("Error: " + ex.Message);
                }
            } while (opcion != 4);
        }

        public static void LoginAdmin() {
            Console.Clear();
            Console.WriteLine("------------------------------------");
            Console.WriteLine(" - Login de Admin - ");
            Console.WriteLine("------------------------------------");
            Console.Write("Nombre de usuario: ");
            string nombre = Console.ReadLine();
            Console.Write("Constraseña: ");
            string password = Console.ReadLine();

            bool usuarioEncontrado = false;
            foreach(Admin a in usuarioAdmin) {
                if (a.Login(nombre, password)) {
                    usuarioEncontrado = true;
                    a.Menus();
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
                        if (datos[0] == "Alimento") {
                            ProductosAlimenticios a = new ProductosAlimenticios(datos[1], int.Parse(datos[2]), double.Parse(datos[3]), datos[4], int.Parse(datos[5]), int.Parse(datos[6]), int.Parse(datos[7]));
                            //"Alimento|{Nombre}|{Unidades}|{PrecioUnitario}|{Descripcion}|{Calorias}|{Grasa}|{Azucar}
                            stockProductos.Add(a);
                        }
                        else if (datos[0] == "ProductoElectronico") {
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

                            ProductosElectronicos productoE = new ProductosElectronicos(datos[1], int.Parse(datos[2]), double.Parse(datos[3]), datos[4], materialE, bool.Parse(datos[6]), bool.Parse(datos[7]));
                            stockProductos.Add(productoE);

                        }
                        else {
                            Material material = new Material();
                            switch (datos[6]) {
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

                            MaterialesPreciosos materialP = new MaterialesPreciosos(datos[1], int.Parse(datos[2]), double.Parse(datos[3]), datos[4], int.Parse(datos[5]), material);
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
