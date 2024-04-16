using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic
{
    internal class Admin : Cliente  {
        public string Nombre { get; set; }
        public string Password { get; set; }
        public Admin() { }

        public Admin( string nombre, string password) 
        {
            Nombre = nombre;
            Password = password;
        }
        public  void Menu()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Que desea hacer:");
                Console.WriteLine("1. Añadir Producto");
                Console.WriteLine("2. Eliminar producto");
                Console.WriteLine("3. Listar productos");
                Console.WriteLine("4. Salir");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1: //añadir
                        AñadirProducto();
                        break;
                    case 2://eliminar

                        Console.WriteLine("\n ---Lista de productos totales----");
                        Console.WriteLine("ID del contenido a eliminar: ");
                        int id_contenido = int.Parse(Console.ReadLine());

                        /*      Producto productoTemp = BuscarContenido(id_contenido);
                              Producto(productoTemp);
                          */

                        break;


                    case 3://listar
                        ListarProducto();
                        break;
                    default:
                        Console.WriteLine("opcion no validad");
                        break;

                }
            } while (opcion != 4);
        }
        public void AñadirProducto() //sale error porque todo esta comentado 
        {
            int opcion;
            do
            {
                Console.WriteLine("Añadir Productos:");
                Console.WriteLine("1. Alimentos");
                Console.WriteLine("2. Elementos electronicos");
                Console.WriteLine("3. Materiales preciosos");
                Console.WriteLine("4. Salir");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        /* Alimento a = new Alimento();
                         * a.SolicitarDetalles();
                         * listaproductos.Add(a);
                         */
                        break;
                    case 2:
                        /* ElementosElectronicos el = new ElementosElectronicos();
                         * el.SolicitarDetalles();
                         * listaproductos.Add(el);
                         * */
                        break;
                    case 3:
                        /*
                         * MaterialesPreciosos mp = new MaterialesPreciosos();
                         * mp.SolicitarDetalles();
                         * listaproductos.Add(mp)
                         * */
                        break;
                }

            } while (opcion != 4);

        }
        public void ListarProducto()
        {
            /*  Console.WriteLine("  --- Listado de productos ---  ");
              Console.WriteLine();
              if (listaProducto == null)
              {
                  Console.WriteLine("No hay ningún producto");

              }
              else
              {
                  foreach (Producto c in listaProducto)
                  {
                      if (c is Producto)
                      {
                          Console.WriteLine(c.MostrarDetalles());

                      }

                  }
              }*/
        }
        public void EliminarProducto()
        { //meter producto en el ()

            /* if (c != null)
             {
               ListarProducto.Remove(c);
                 Console.WriteLine("Producto eliminado");
             }
             else
             {
                 Console.WriteLine("No se ha encontrado ningún producto con el ID introducido.");
             }*/
        }
        public bool Login(string nombre, string password)
        {
            bool Usuario = false;
            Console.WriteLine("Buenos dias admin:");


            int contadorIntentos = 0;
            do
            {

                Console.WriteLine("Dime tu nombre");
                string Nickname = Console.ReadLine();
                Console.WriteLine("Dime tu contraseña");
                string Contraseña = Console.ReadLine();
                string nombreUsuario = nombre;
                string contraseña = password;
                if (nombreUsuario == Nickname && contraseña == Contraseña)
                {
                    Console.WriteLine("Eres admin:(comprobacion)");
                    Usuario = true;
                }
                else
                {
                    Console.WriteLine("Usuario o contraseña incorrecta");
                    contadorIntentos++;
                }
            } while (Usuario == false || contadorIntentos == 3);
            Console.WriteLine("ha alcanzado el numero de intentos");
            Console.WriteLine("Saliendo...");
            return Usuario;
        }
        public  void Salir()
        {
        }
    }
}
