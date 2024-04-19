using MaquinaVendingCosmic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic {
    public enum MaterialE { Aluminio, Plastico, Metal, Titanio }
    internal class ProductosElectronicos : Producto {
        public MaterialE MaterialE { get; set; }
        public bool Pilas { get; set; }
        public bool Precargado { get; set; }

        public ProductosElectronicos(int id) : base(id) { }
        public ProductosElectronicos(int id, string nombre, int unidades, double precioUnitario, string descripcion, MaterialE materialE, bool pilas, bool precargado)
            : base(nombre, unidades, precioUnitario, descripcion) {
            MaterialE = materialE;
            Pilas = pilas;
            Precargado = precargado;
        }
        public override string MostrarDetalles() {
            return base.MostrarDetalles() + $"\t\nMaterial: {MaterialE} - \t\nPilas: {Pilas} - Precargado: {Precargado}";
        }
        public override void SolicitarDetalles() {
            base.SolicitarDetalles();
            Console.Write("Que tipo de material es?: ");

            Console.WriteLine("1. Aluminio");
            Console.WriteLine("2. Plastico");
            Console.WriteLine("3. Metal");
            Console.WriteLine("4. Titanio");

            int opcionMaterial = int.Parse(Console.ReadLine());
            switch (opcionMaterial) {
                case 1:
                    MaterialE = MaterialE.Aluminio;
                    break;
                case 2:
                    MaterialE = MaterialE.Plastico;
                    break;
                case 3:
                    MaterialE = MaterialE.Metal;
                    break;
                case 4:
                    MaterialE = MaterialE.Titanio;
                    break;
            }
            Console.Write("Tiene pilas?: ");
            Pilas = bool.Parse(Console.ReadLine());
            Console.Write("Esta precargado el articulo?: ");
            Precargado = bool.Parse(Console.ReadLine());
        }

        public override string ToString() {
            return $"{Id},ProductoElectronico,{Nombre},{Unidades},{PrecioUnitario},{Descripcion},{MaterialE},{Pilas},{Precargado}";
        }

        public override void ToFile() {
            using (StreamWriter sw = new StreamWriter("ProductosElectronicos.csv", true)) {
                sw.WriteLine(ToString());
            }
        }


    }
}
