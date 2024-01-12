using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Calculo
    {
        public static int Soma (int valor1, int valor2, int valor3)
        {
            return valor1 + valor2 + valor3;
        }

        public static int Subtracao(int valor1, int valor2)
        {
            return valor1 - valor2;
        }

        public static int Multiplicacao(int valor1, int valor2)
        {
            return valor1 * valor2;
        }

        public static int Divisao(int valor1, int valor2)
        {
            return valor1 / valor2;
        }

    }
}
