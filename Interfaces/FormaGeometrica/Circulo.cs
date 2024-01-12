using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.FormaGeometrica
{
    public class Circulo : IFormaGeometrica
    {
        public int Raio { get; set; }

        public double CalcularArea()
        {
            var area = Math.PI * (Raio * Raio);
            return area;
        }

        public double CalcularPerimetro()
        {
            var resultado = 2 * Math.PI * Raio;
            return resultado;
        }
    }
}
