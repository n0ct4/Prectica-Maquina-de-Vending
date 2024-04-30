using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MaquinaVendingCosmic
{
    internal class Cliente
    {
        List<Producto> carrito = new List<Producto>();

        public List<Producto> stockProductos;

        public Cliente() { }

        public Cliente(List<Producto> listaProductos)
        {
            stockProductos = listaProductos;
        }
        public virtual void Menu()
        {
            int salir;
            int opcion = 0;
            do
            {

                Console.Clear();

                Console.WriteLine("------------------------------------");
                Console.WriteLine(" - Buenos días! - ");
                Console.WriteLine(" - ¿Qué deseas comprar? - ");
                Console.WriteLine("------------------------------------");

                Console.WriteLine("Alimentos");
                /* Lista.Where(a => a.tipo/nombre/id == " " ).ToList()
                lo que hace es buscar con la variable que has metido, el nombre, el tipo o el id, de lo que quieras buscar
                para luego hacer una lista únicamente con lo que has seleccionado*/
                ListarProductos("Alimentos", stockProductos.Where(a => a.tipo == TipoProducto.Alimentos).ToList()); 
                Console.WriteLine("Productos Electronicos");
                ListarProductos("Productos Electronicos", stockProductos.Where(a => a.tipo == TipoProducto.ProductosElectronicos).ToList());
                Console.WriteLine("Materiales preciosos");
                ListarProductos("Materiales preciosos", stockProductos.Where(a => a.tipo == TipoProducto.MaterialesPreciosos).ToList());

                Console.WriteLine(" ");
                Console.WriteLine("Elija el producto deseado: ");
                Console.WriteLine("De al numero 15 para salir: ");
                opcion = int.Parse(Console.ReadLine());
                if (opcion != 15)
                {
                    AgregarAlCarrito(opcion);
                    Console.WriteLine("¿Quiere seguir comprando? (1.Si 2.No)");
                    salir = int.Parse(Console.ReadLine());
                    if (salir == 2)
                    {
                        Pagos p = new Pagos();
                        p.Menu(carrito, stockProductos);
                    }
                    Console.ReadKey();
                }
            } while (opcion != 15);
        }
        // Lista general, que luego la divides en los productos de cada tipo
        public void ListarProductos(string tipo, List<Producto> productos)
        {
            Console.WriteLine($"  --- Listado de productos {tipo} ---  ");
            Console.WriteLine();
            if (stockProductos == null)
            {
                Console.WriteLine("No hay ningún producto");
            }
            else
            {
                foreach (Producto c in productos)
                {
                    if (c is Producto)
                    {
                        Console.WriteLine($"({c.Id}) - Producto: {c.Nombre}\t\nPrecio: {c.PrecioUnitario}\n Unidades: {c.Unidades}\n");
                    }
                }
                Console.ReadKey();
            }
        }

        public void AgregarAlCarrito(int id)
        {
            Producto p = BuscarProducto(id);

            if (p != null)
            {
                carrito.Add(p);
                Console.WriteLine($"Producto '{p.Nombre}' agregado al carrito.");
            }
            else
            {
                Console.WriteLine($"No se encontró ningún producto con el ID {id}.");
            }
        }
        public Producto BuscarProducto(int id)
        {
            Producto productoTemp = null;
            foreach (Producto p in stockProductos)
            {
                if (p.Id == id)
                {
                    productoTemp = p;
                }
            }
            return productoTemp;
        }
        public virtual void Salir() { }

    }
}






