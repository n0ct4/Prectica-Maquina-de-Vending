using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic
{
    internal class Cliente
    {
        public Cliente() { }
        public Cliente(int id)
        {
        }
        public  void Menu()
        {

            int opcion;
            do
            {
                Console.Clear();

                Console.WriteLine("Buenos dias que desea comprar: ");
                Console.WriteLine("Alimentos");
                //listar alimentos
                Console.WriteLine("Productos Electronicos");
                //listar productos electronicos
                Console.WriteLine("Materiales preciosos");
                //listar Materiales preciosos
                Console.WriteLine(" ");
                Console.WriteLine("Elija el producto deseado: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: //alimentos

                        break;
                    case 2: //materiales electronicos
                        break;
                    case 3: // materiales preciosos
                        break;
                }
                //alimentos / productos electronicos / materiales preciosos
            } while (opcion != 4);
        }
        public void ComprarAlimentos()
        {
            Console.Clear();

            Console.WriteLine("  --- Listado de productos ---  ");
            //una vez tenga la lista de productos cargarla para que salten unicamento los alimentos
            Console.WriteLine("Seleccione el id del elemento que desea comprar:");
            int seleccionAlimento = int.Parse(Console.ReadLine());

            /*     if (seleccionAlimento == )
                 {


                 }*/
            //necesito el resto del codigo para esto 
            //una vez echo este es copia y pega con Comprar el resto de las cosas cambienado nombre y variables

            return;

        }
        public  void Salir()
        {
            //terminar
        }   
    }
}
