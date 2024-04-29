using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic {
    public enum TipoProducto { Alimentos, ProductosElectronicos, MaterialesPreciosos }
    internal abstract class Producto {

        public static int ultimoId = 0;

        public int Id { get; private set; }
        public string Nombre { get; set; }
        public int Unidades { get; set; }
        public double PrecioUnitario { get; set; }
        public string Descripcion { get; set; }
        public TipoProducto tipo {  get; set; }
        public Producto() { }

        public Producto(string nombre, int unidades, double precioUnitario, string descripcion, TipoProducto tipo = default)
        {
            Id = ultimoId++;
            Nombre = nombre;
            Unidades = unidades;
            PrecioUnitario = precioUnitario;
            Descripcion = descripcion;
            this.tipo = tipo;
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
