using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVendingCosmic
{
    internal abstract class Usuario
    {
        public int Id { get; set; }


        public Usuario() { }
        public Usuario(int id)
        {

            Id = id;

        }

        public abstract void Menu();
        public abstract void Salir();


        //no usar excepto que queramos que el cliente tenga que registrarse
        /*  public bool Login(string nombre, string password)
          {
              bool Usuario = false;
              Console.WriteLine("¿Eres admin(1) o cliente (2)?");
              int opcion = int.Parse(Console.ReadLine());

              switch (opcion)
              {
                  case 1:
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
                          Console.WriteLine("Error en el usuario o contraseña");
                          Usuario= false;
                      }
                      break;
                      case 2:
                      Usuario = false;
                      break;

                      //pruea
              }
             return Usuario;  

          }*/
    }
}
