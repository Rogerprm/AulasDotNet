using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace FilasGeneric
{
    public class MenuFilas
    {
        public void AbreMenu()
        {
            string a = "";
            Console.WriteLine("1 - Add Primeiro");
            Console.WriteLine("2 - Add Ultimo");
            Console.WriteLine("3 - Add por Index");

            Console.WriteLine("4 - Remover Primeiro");
            Console.WriteLine("5 - Remover Ultimo");
            Console.WriteLine("6 - Remover por Index");

            Console.WriteLine("7 - Consultar por nome");
            Console.WriteLine("8 - Consultar por index");

            Console.ReadLine();

            switch (a)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "7":
                    break;
                case "8":
                    break;
            }

            while (a != "0")
            { AbreMenu(); }

        }

    }
}
