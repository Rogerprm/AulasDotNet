using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.FormaGeometrica
{
    public class Controle
    {
        public void Menu()
        {
            int a;
            Console.WriteLine("1 - Area do Retangulo");
            Console.WriteLine("2 - Perimetro do Retangulo");
            Console.WriteLine("3 - Area do Circulo");
            Console.WriteLine("4 - Perimetro do Circulo");


            a = Int32.Parse(Console.ReadLine());

            switch (a)
            {
                case 1:
                    CalculoRetangulo(a);
                    break;

                case 2:
                    CalculoRetangulo(a);
                    break;
                case 3:
                    CalculoCirculo(a);
                    break;
                case 4:
                    CalculoCirculo(a);
                    break;
            }
        }

        public void CalculoRetangulo(int a)
        {
            Console.WriteLine("Largura: ");
            int larg = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Comprimento: ");
            int comp = Int32.Parse(Console.ReadLine());

            Retangulo retangulo = new Retangulo() { Altura = larg, Base = comp };

            if (a == 1)
            {
                var resultado = retangulo.CalcularArea();
                Console.WriteLine(resultado.ToString());
            }
            else if (a == 2)
            {
                var resultado = retangulo.CalcularPerimetro();
                Console.WriteLine(resultado.ToString());
            }
        }

        public void CalculoCirculo(int a)
        {
            Console.WriteLine("raio: ");
            int raio = int.Parse(Console.ReadLine());

            Circulo circulo = new Circulo() { Raio = raio };

            if (a == 3)
            {
                var resultado = circulo.CalcularArea();
                Console.WriteLine(resultado.ToString());
            }
            else if (a == 4)
            {
                var resultado = circulo.CalcularPerimetro();
                Console.WriteLine(resultado.ToString());
            }
        }
    }
}
