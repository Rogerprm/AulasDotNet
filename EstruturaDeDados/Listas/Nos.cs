using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaDeDados.Listas
{
    public class Nos
    {
        public Nos Proximo { get; set; }
        public Nos Anterior { get; set; }
        public Dados dados { get; set; }
    }
}
