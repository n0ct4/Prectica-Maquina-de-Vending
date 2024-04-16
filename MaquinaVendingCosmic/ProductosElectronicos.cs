using MaquinaVendingCosmic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic {
    public enum MaterialE { Oro, Plata, Hierro, Diamante }
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
            return base.MostrarDetalles() + $"\t\nPilas: {Pilas} - Precargado: {Precargado}";
        }
        public override void SolicitarDetalles() {
            base.SolicitarDetalles();
            Console.Write("Tiene pilas?: ");
            Pilas = bool.Parse(Console.ReadLine());
            Console.Write("Esta precargado el articulo?: ");
            Precargado = bool.Parse(Console.ReadLine());
        }
    }
}
