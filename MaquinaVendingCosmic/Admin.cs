﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic
{

    internal class Admin : Cliente
    {

        public string Nombre { get; set; }
        public string Password { get; set; }
        public Admin() { }
       
        public Admin(string nombre, string password, List<Producto> listaProductos) : base(listaProductos)
        {
            Nombre = nombre;
            Password = password;

        }
        public void Menus()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------------");
                Console.WriteLine(" - Bienvenido, Admin! - ");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1. Añadir Producto");
                Console.WriteLine("2. Eliminar producto");
                Console.WriteLine("3. Listar productos");
                Console.WriteLine("4. Comprar Productos");
                Console.WriteLine("5. Salir");
                
                    opcion = int.Parse(Console.ReadLine());
                    switch (opcion) {
                        case 1: //añadir
                            AddProducto();
                            break;
                        case 2://eliminar

                            Console.WriteLine("\n ---Lista de productos totales----");
                            ListarProductos();
                            Console.WriteLine("ID del contenido a eliminar: ");
                            int id_contenido = int.Parse(Console.ReadLine());
                            Producto productoTemp = BuscarProducto(id_contenido);
                            EliminarProducto(productoTemp);

                            break;
                        case 3://listar
                            ListarProductos();
                            break;
                        case 4:
                            Cliente c = new Cliente();
                            c.Menu();
                            break;
                        case 5:
                            Salir();
                            break;

                        default:
                            Console.WriteLine("opcion no valida");
                            break;
                    }
                

            } while (opcion != 5);
        }
        public void AddProducto()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Añadir Productos:");
                Console.WriteLine("1. Alimentos");
                Console.WriteLine("2. Productos electronicos");
                Console.WriteLine("3. Materiales preciosos");
                Console.WriteLine("4. Salir");

                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        ProductosAlimenticios pa = new ProductosAlimenticios();
                        pa.SolicitarDetalles();
                        stockProductos.Add(pa);
                        pa.ToFile();
                        break;
                    case 2:
                        ProductosElectronicos pe = new ProductosElectronicos();
                        pe.SolicitarDetalles();
                        stockProductos.Add(pe);
                        pe.ToFile();
                        break;
                    case 3:
                        MaterialesPreciosos mp = new MaterialesPreciosos();
                        mp.SolicitarDetalles();
                        stockProductos.Add(mp);
                        mp.ToFile();
                        break;
                    default:
                        break;
                }

            } while (opcion != 4);
        }

        public void ListarProductos()
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
                        Console.WriteLine(c.MostrarDetalles());
                    }
                }
                Console.ReadKey();
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

        public void EliminarProducto(Producto producto)
        {
            if (producto != null)
            {
                stockProductos.Remove(producto);
                Console.WriteLine("Producto eliminado");               
            }
            else
            {
                Console.WriteLine("No se ha encontrado ningun prodcuto con el ID introducido.");
            }
        }

        public bool Login(string nombre, string password)
        {
            return Nombre == nombre && Password == password;
        }

        public override void Salir()
        {
            if (stockProductos.Count > 0)
            {
                File.Create("productos.csv").Close();
                using (StreamWriter sw = new StreamWriter("productos.csv"))
                {
                    foreach (Producto p in stockProductos)
                    {
                        p.ToFile();
                        sw.WriteLine(p);
                    }
                }

            }
        }
    }
}

