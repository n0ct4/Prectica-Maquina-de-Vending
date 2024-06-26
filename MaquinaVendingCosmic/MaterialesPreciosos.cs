﻿using MaquinaVendingCosmic;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MaquinaVendingCosmic
{
    public enum Material { Oro, Plata, Hierro, Diamante }
    internal class MaterialesPreciosos : Producto
    {

        public int Peso { get; set; }
        public Material Material { get; set; }

        public MaterialesPreciosos() { }

        public MaterialesPreciosos(string nombre, int unidades, double precioUnitario, string descripcion, int peso, Material material)
           : base(nombre, unidades, precioUnitario, descripcion, TipoProducto.MaterialesPreciosos)
        {
            Peso = peso;
            Material = material;
        }
        public override string MostrarDetalles()
        {
            return base.MostrarDetalles() + $"\t\nMaterial: {Material} - Peso: {Peso}";
        }

        /* 
         1. Pasar enum por parametro de solictardetalles
         2. Hacer switch case para elegir el enum 
         */

        public override void SolicitarDetalles()
        {
            base.SolicitarDetalles();
            Console.Write("Peso: ");
            Peso = int.Parse(Console.ReadLine());
            Console.Write("Que tipo de material es?: ");

            Console.WriteLine("1. Oro");
            Console.WriteLine("2. Plata");
            Console.WriteLine("3. Hierro");
            Console.WriteLine("4. Diamante");

            int opcionMaterial = int.Parse(Console.ReadLine());
            switch (opcionMaterial)
            {
                case 1:
                    Material = Material.Oro;
                    break;
                case 2:
                    Material = Material.Plata;
                    break;
                case 3:
                    Material = Material.Hierro;
                    break;
                case 4:
                    Material = Material.Diamante;
                    break;
            }
        }
        public override string ToString()
        {
            return $"MaterialPrecioso,{Nombre},{Unidades},{PrecioUnitario},{Descripcion},{Peso},{Material}";

        }

        public override void ToFile()
        {
            using (StreamWriter sw = new StreamWriter("MaterialPreciosos.csv", true))
            {
                sw.WriteLine(ToString());
            }
        }
    }
}


