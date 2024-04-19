using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic {
    internal abstract class Producto {
        public int Id { get; private set; }
        public string Nombre { get; set; }
        public int Unidades { get; set; }
        public double PrecioUnitario { get; set; }
        public string Descripcion { get; set; }

        public Producto(double precioUnitario)
        {
            PrecioUnitario = precioUnitario;
        }
        public Producto(int id) { Id = id + 1; }
        public Producto(string nombre, int unidades, double precioUnitario, string descripcion) {
            Nombre = nombre;
            Unidades = unidades;
            PrecioUnitario = precioUnitario;
            Descripcion = descripcion;
        }

        public virtual string MostrarDetalles() {
            return $"({Id}) | Nombre: {Nombre} - Unidades: {Unidades}\t\n Precio: {PrecioUnitario}\t\n Descripción: {Descripcion}";
        }

        public virtual void SolicitarDetalles() {
            Console.Clear();
            Console.WriteLine("  --- Añadiendo nuevo producto --- ");
            Console.WriteLine();
            Console.Write("Nombre: ");
            Nombre = Console.ReadLine();
            Console.Write("Unidades: ");
            Unidades = int.Parse(Console.ReadLine());
            Console.Write("Precio unitario: ");
            PrecioUnitario = double.Parse(Console.ReadLine());
            Console.Write("Descripcion: ");
            Descripcion = Console.ReadLine();
        }
        public abstract void ToFile();
    }
}
