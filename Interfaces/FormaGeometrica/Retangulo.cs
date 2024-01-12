using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.FormaGeometrica
{
    public class Retangulo : IFormaGeometrica
    {
        public int Base { get; set; }
        public int Altura { get; set; }
        public double CalcularArea()
        {
            double resultado;
            resultado = Base * Altura;

            return resultado;

        }

        public double CalcularPerimetro()
        {
            double resultado;
            resultado = 2 * (Base + Altura);

            return resultado;
        }
    }
}
