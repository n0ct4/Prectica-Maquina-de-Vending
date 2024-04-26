using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic {
    internal class Cliente {

        //public static List<Producto> stockProductos = new List<Producto>();
        public static List<int> carrito = new List<int>();

        public List<Producto> stockProductos;

        public Cliente() { }

        public Cliente(List<Producto> listaProductos) {
            stockProductos = listaProductos;
        }


        //public Cliente()//List<Producto> _stockProductos
        //{
        //stockProductos = _stockProductos;
        //}
        public virtual void Menu() {
            int salir;
            int opcion = 0;
            do {

                Console.Clear();

                Console.WriteLine("------------------------------------");
                Console.WriteLine(" - Buenos días! - ");
                Console.WriteLine(" - ¿Qué deseas comprar? - ");
                Console.WriteLine("------------------------------------");

                //Console.WriteLine("Alimentos");
                ListarAlimentos();
                Console.WriteLine("Productos Electronicos");
                //ListarProductosE();
                Console.WriteLine("Materiales preciosos");
                //ListaProductosMP();

                Console.WriteLine(" ");
                Console.WriteLine("Elija el producto deseado: ");
                Console.WriteLine("De al numero 15 para salir: ");
                opcion = int.Parse(Console.ReadLine());
                if (opcion != 15) {
                    //AddCarrito(opcion);
                    Console.WriteLine("El producto a sido añadido al carrito");
                    Console.WriteLine("¿Quiere seguir comprando? (1.Si 2.No)");
                    salir = int.Parse(Console.ReadLine());

                    if (salir == 2) {


                        if (salir == 2) {


                            Pagos p = new Pagos();
                            p.Menu();
                        }
                        //el salir no funciona pero una vez se haga carrito y pagar 
                        //le metemos un if y si selecciona dos que le envia a pagar y no ha salir
                    }
                    else {
                        salir = 2;
                    }


                    Console.ReadKey();
                    //ADDCarrito

                }
            } while (opcion != 15);
        }

            public void ListarAlimentos() {
                Console.WriteLine("  --- Listado de productos ---  ");
                Console.WriteLine();
                if (stockProductos == null) {
                    Console.WriteLine("No hay ningún producto");
                }
                else {
                    foreach (Producto c in stockProductos) {
                        if (c is Producto) {

                            Console.WriteLine($"({c.Id}) - Producto: {c.Nombre}\t\nPrecio: {c.PrecioUnitario}\n");

                        }
                    }
                    Console.ReadKey();
                }
        
            }
            /*

            public void AddCarrito(int idElegido) {


                public void ListarProductosE() {
                    Console.WriteLine("  --- Listado de productos ---  ");
                    Console.WriteLine();
                    if (stockProductos == null) {
                        Console.WriteLine("No hay ningún producto");
                    }
                    else {
                        foreach (Producto c in stockProductos) {
                            if (c is Producto) {
                                Console.WriteLine($"{c.Id} --- {c.Nombre}");
                            }
                        }
                        Console.ReadKey();
                    }
                }
                public void ListaProductosMP() {
                    Console.WriteLine("  --- Listado de productos ---  ");
                    Console.WriteLine();
                    if (stockProductos == null) {
                        Console.WriteLine("No hay ningún producto");
                    }
                    else {
                        foreach (Producto c in stockProductos) {
                            if (c is Producto) {
                                Console.WriteLine($"{c.Id} --- {c.Nombre}");
                            }
                        }
                        Console.ReadKey();
                    }
                }



                public void AddCarrito(int idElegido) {

                    int carritoMaximo = 12;
                    if (carritoMaximo >= carrito.Count) {
                        carrito.Add(idElegido);
                        Console.WriteLine($"IDSSSS ----->>>>>> {idElegido}");
                    }
                    else {
                        { Console.WriteLine("No hay mas productos bro"); }
                    }
                } 
            } 
        }
        */


        public virtual void Salir() { }

    } 
}
    



/*public void ListarProductosE()

 {
     Console.WriteLine("  --- Listado de productos ---  ");
     Console.WriteLine();
     if (stockProductos == null)
     {
         Console.WriteLine("No hay ningún producto");
     }
     else
     {
         foreach (Producto c in stockProductos)
         {
             if (c is Producto)
             {
                 Console.WriteLine($"{c.Id} --- {c.Nombre}");
             }
         }
         Console.ReadKey();
     }
 }
 public void ListaProductosMP()
 {
     Console.WriteLine("  --- Listado de productos ---  ");
     Console.WriteLine();
     if (stockProductos == null)
     {
         Console.WriteLine("No hay ningún producto");
     }
     else
     {
         foreach (Producto c in stockProductos)
         {
             if (c is Producto)
             {
                 Console.WriteLine($"{c.Id} --- {c.Nombre}");
             }
         }
         Console.ReadKey();
     }
 }


*/





