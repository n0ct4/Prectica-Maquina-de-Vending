using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic {
    internal class Admin : Cliente {
        public string Nombre { get; set; }
        public string Password { get; set; }
        public Admin() { }

        public Admin(string nombre, string password) {
            Nombre = nombre;
            Password = password;
        }
        public void Menu() {
            int opcion;
            do {
                Console.Clear();
                Console.WriteLine("Que desea hacer:");
                Console.WriteLine("1. Añadir Producto");
                Console.WriteLine("2. Eliminar producto");
                Console.WriteLine("3. Listar productos");
                Console.WriteLine("4. Salir");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion) {
                    case 1: //añadir
                        AddProducto();
                        break;
                    case 2://eliminar

                      Console.WriteLine("\n ---Lista de productos totales----");
                        Console.WriteLine("ID del contenido a eliminar: ");
                        ListarProductos();
                        int c = int.Parse(Console.ReadLine());
                        Producto w = BuscarProducto(c);
                        EliminarProducto(w);
                        
                       
                        

                        break;


                    case 3://listar
                        ListarProductos();
                        break;
                    default:
                        Console.WriteLine("opcion no validad");
                        break;

                }
            } while (opcion != 4);
        }
        public void AddProducto() 
        {
            if (stockProductos.Count >= 12) {
                Console.WriteLine("No se pueden añadir mas productos. La maquina esta llena");
                return;
            }
            int opcion;
            do {
                Console.WriteLine("Añadir Productos:");
                Console.WriteLine("1. Alimentos");
                Console.WriteLine("2. Productos electronicos");
                Console.WriteLine("3. Materiales preciosos");
                Console.WriteLine("4. Salir");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion) {
                    case 1:
                        ProductosAlimenticios pa = new ProductosAlimenticios(stockProductos.Count);
                        pa.SolicitarDetalles();
                        stockProductos.Add(pa);
                        break;
                    case 2:
                        ProductosElectronicos pe = new ProductosElectronicos(stockProductos.Count);
                        pe.SolicitarDetalles();
                        stockProductos.Add(pe);
                        break;
                    case 3:
                        MaterialesPreciosos mp = new MaterialesPreciosos(stockProductos.Count);
                        mp.SolicitarDetalles();
                        stockProductos.Add(mp);
                        break;
                    default: 
                        break;
                }
            } while (opcion != 4);
        }
        
        public void ListarProductos() {
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
                      Console.WriteLine(c.MostrarDetalles());
                  }
              }
              Console.ReadKey();
            }
    }

    public void EliminarProducto(Producto c)
    { 

         if (c != null)
         {
           stockProductos.Remove(c);
             Console.WriteLine("Producto eliminado");
         }
         else
         {
             Console.WriteLine("No se ha encontrado ningún producto con el ID introducido.");
         }
    }
        public static Producto BuscarProducto(int id)
        {
            Producto productoTemp = null;
            foreach(Producto p in stockProductos)
            {
                if(p.Id == id)
                {
                    productoTemp = p;
                }
            }
            return productoTemp;
        }
            
       
    
        //public bool Login(string nombre, string password) {
        /*bool Usuario = false;
        Console.WriteLine("Buenos dias admin:");


        int contadorIntentos = 0;
        do {

            Console.WriteLine("Dime tu nombre");
            string Nickname = Console.ReadLine();
            Console.WriteLine("Dime tu contraseña");
            string Contraseña = Console.ReadLine();
            string nombreUsuario = nombre;
            string contraseña = password;
            if (nombreUsuario == Nickname && contraseña == Contraseña) {
                Console.WriteLine("Eres admin:(comprobacion)");
                Usuario = true;
            }
            else {
                Console.WriteLine("Usuario o contraseña incorrecta");
                contadorIntentos++;
            }
        } while (Usuario == false || contadorIntentos == 3);
        Console.WriteLine("ha alcanzado el numero de intentos");
        Console.WriteLine("Saliendo...");
        return Usuario;

      }

    /*/

        public bool Login(string nombre, string password) {
            return Nombre == nombre && Password == password;
        }

        public void Salir() {
        }
    }
}

