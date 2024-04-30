using MaquinaVendingCosmic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic
{
    internal class ProductosAlimenticios : Producto
    {
        public int Calorias { get; set; }
        public int Grasa { get; set; }
        public int Azucar { get; set; }
        public ProductosAlimenticios() { }
        public ProductosAlimenticios(string nombre, int unidades, double precioUnitario, string descripcion, int calorias, int grasa, int azucar)
            : base(nombre, unidades, precioUnitario, descripcion, TipoProducto.Alimentos)
        {
            Calorias = calorias;
            Grasa = grasa;
            Azucar = azucar;
        }
        public override string MostrarDetalles()
        {
            return base.MostrarDetalles() + $"\t\nCalorias: {Calorias}\t\nGrasa: {Grasa} gramos.\t\nAzucar: {Azucar} gramos.";
        }
        public override void SolicitarDetalles()
        {
            base.SolicitarDetalles();
            Console.Write("Calorias: ");
            Calorias = int.Parse(Console.ReadLine());
            Console.Write("Grasa: ");
            Grasa = int.Parse(Console.ReadLine());
            Console.Write("Azucar: ");
            Azucar = int.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            return $"Alimento,{Nombre},{Unidades},{PrecioUnitario},{Descripcion},{Calorias},{Grasa},{Azucar}";
        }

        public override void ToFile()
        {
            using (StreamWriter sw = new StreamWriter("ProductosAlimenticios.csv", true))
            {
                sw.WriteLine(ToString());
            }
        }
    }
}
