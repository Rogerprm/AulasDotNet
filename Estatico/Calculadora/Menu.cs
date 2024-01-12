using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Menu
    {
        public int valor1 = 0, valor2 = 0, resultado = 0, valor3 = 0;
        public void MenuApp()
        {
            string a;
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtracao");
            Console.WriteLine("3 - Multiplicacao");           
            Console.WriteLine("4 - Divisao");
            Console.WriteLine("0 - Fechar");
            a = Console.ReadLine();

            switch (a) 
            {
                case "1":
                    ExecutarSoma();
                    break;
                case "2":
                    ExecutarSub();
                    break;
                case "3":
                    ExecutarMult();
                    break;
                case "4":
                    ExecutarDivisao();
                    break;
                case "0":
                    Sair();
                    break;
            }
            if (a != "0")
            {
                MenuApp();
            }
        }

        public void Sair()
        {
            Environment.Exit(0);
        }

        //public List<int> Valores()
        //{
        //    List<int> t = 
        //}
        private void ExecutarDivisao()
        {
            //int valor1=0, valor2=0, resultado=0;
            Console.WriteLine("Valor 1: ");
            valor1 = int.Parse(Console.ReadLine() );
            Console.WriteLine("Valor 2: ");
            valor2 = int.Parse(Console.ReadLine());
            resultado = Calculo.Divisao(valor1, valor2);
            Console.WriteLine("Divisao de {0} por {1} e {2} ", valor1, valor2, resultado  );
        }

        private void ExecutarMult()
        {
            Console.WriteLine("Valor 1: ");
            valor1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Valor 2: ");
            valor2 = int.Parse(Console.ReadLine());
            resultado = Calculo.Multiplicacao(valor1, valor2);
            Console.WriteLine("Multiplicacao de {0} por {1} e {2} ", valor1, valor2, resultado);
        }

        private void ExecutarSoma()
        {
            Console.WriteLine("Valor 1: ");
            valor1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Valor 2: ");
            valor2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Valor 3: ");
            valor3 = int.Parse(Console.ReadLine());
            resultado = Calculo.Soma(valor1, valor2, valor3);
            Console.WriteLine("Soma de {0} e {1} e {2} ", valor1, valor2, resultado);
        }

        private void ExecutarSub()
        {
            Console.WriteLine("Valor 1: ");
            valor1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Valor 2: ");
            valor2 = int.Parse(Console.ReadLine());
            resultado = Calculo.Subtracao(valor1, valor2);
            Console.WriteLine("Subtracao de {0} por {1} e {2} ", valor1, valor2, resultado);
        }
    }
}
