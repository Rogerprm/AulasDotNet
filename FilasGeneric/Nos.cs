using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilasGeneric
{
    public class Nos<T>
    {
        public Nos<T> Proximo { get; set; }
        public Nos<T> Anterior { get; set; }
        public T dadosArmazenados { get; set; }

    }
}
