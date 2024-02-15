using AgendaEF.Models;
using System;

namespace AgendaEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AGENDA");

            var aplicacao = new Application();


            var menu = new AppManager();
            menu.MenuAplicacao();

           
        }
    }
}
