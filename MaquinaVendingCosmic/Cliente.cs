using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic
{
    internal class Cliente
    {
        public static List<Producto> stockProductos = new List<Producto>();
        public static List<int> carrito = new List<int>();
        
        public Cliente() { }
        
        //public Cliente()//List<Producto> _stockProductos
        //{
            //stockProductos = _stockProductos;
        //}
        public virtual void Menu()
        {
            bool comprarProducto = true;
            int opcion;
            do
            {
               
                Console.Clear();

                Console.WriteLine("Buenos dias que desea comprar: ");
                Console.WriteLine("Alimentos");
                ListarAlimentos();
                Console.WriteLine("Productos Electronicos");
             //  ListarProductosE();
                Console.WriteLine("Materiales preciosos");
               // ListaProductosMP();
                Console.WriteLine(" ");
                Console.WriteLine("Elija el producto deseado: ");
                Console.WriteLine("De al numero 15 para salir: ");
                opcion = int.Parse(Console.ReadLine());

                AddCarrito(opcion);
                    
                Console.WriteLine("El producto a sido añadido al carrito");
                Console.WriteLine("¿Quiere seguir comprando? (1.Si 2.No)");
                char salir = char.Parse(Console.ReadLine());
                if(salir == 'n' || salir == 'N')
                {
                    comprarProducto = false;
                }
                Console.ReadKey();
                //ADDCarrito
               
            } while (comprarProducto !=true || opcion !=15);
        }
        public void ListarAlimentos()
        {
            Console.WriteLine("  --- Listado de productos ---  ");
            Console.WriteLine();
            if (stockProductos == null) {
                Console.WriteLine("No hay ningún producto");
            }
            else {
                foreach (Producto c in stockProductos) {
                    if (c is Producto) {
                        Console.WriteLine($"{c.Id} --- {c.Nombre}" );
                    }
                }
                Console.ReadKey();
            }

        }
      /* public void ListarProductosE()
        {
            bool 
            if()
            foreach (ProductosElectronicos p in stockProductos)
            {
                Console.WriteLine($"(ID) - {p.Id}: {p.Nombre}\n");
            }
        }
        public void ListaProductosMP()
        {
            foreach (MaterialesPreciosos p in stockProductos)
            {
                Console.WriteLine($"(ID) - {p.Id}: {p.Nombre}\n");
            }
        }*/



       public void AddCarrito(int idElegido)
        {
            int carritoMaximo = 12;
            if (carritoMaximo >= carrito.Count)
            {
                carrito.Add(idElegido);
                Console.WriteLine($"IDSSSS ----->>>>>> {idElegido}");
            }
            else
            {
                { Console.WriteLine("No hay mas productos bro"); }
            }
        }
        public virtual void Salir()
        {
            //terminar
        }   
    }
}
