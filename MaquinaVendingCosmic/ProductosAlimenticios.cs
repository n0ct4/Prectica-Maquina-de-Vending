using MaquinaVendingCosmic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic {
    internal class ProductosAlimenticios : Producto {
        public int Calorias { get; set; }
        public string Grasa { get; set; }
        public string Azucar { get; set; }
        public ProductosAlimenticios(double precioUnitario) : base(precioUnitario) { }

        public ProductosAlimenticios(int id) : base(id) { }
        public ProductosAlimenticios(int id, string nombre, int unidades, double precioUnitario, string descripcion, int calorias, string grasa, string azucar)
            : base(nombre, unidades, precioUnitario, descripcion) {
            Calorias = calorias;
            Grasa = grasa;
            Azucar = azucar;
        }
        public override string MostrarDetalles() {
            return base.MostrarDetalles() + $"\t\nCalorias: {Calorias}\t\nGrasa: {Grasa}\t\nAzucar: {Azucar}";
        }
        public override void SolicitarDetalles() {
            base.SolicitarDetalles();
            Console.WriteLine("Calorias: ");
            Calorias = int.Parse(Console.ReadLine());
            Console.WriteLine("Grasa: ");
            Grasa = Console.ReadLine();
            Console.WriteLine("Azucar: ");
            Azucar = Console.ReadLine();
        }
    }
}
