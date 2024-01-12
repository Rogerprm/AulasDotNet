using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AplicativoCinema
{
    public class Ingresso
    {
        public int IdIngresso { get; set; }
        public float Valorpago { get; set; }
        public Sessao sessao { get; set; }
        public Cliente cliente { get; set; }

    }
}
