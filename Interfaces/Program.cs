using Interfaces.FormaGeometrica;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
            *Exercício 1: Interfaces de Forma Geométrica
            Crie uma interface chamada "FormaGeometrica" com métodos para calcular área e perímetro.
            Implemente classes como "Círculo" e "Retângulo" que implementam essa interface. 
            * 
            */

            Controle controle = new Controle();
            controle.Menu();
        }

    }
}