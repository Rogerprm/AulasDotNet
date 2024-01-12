using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoCinema
{
    public class Sala
    {
        public int IdSala { get; set; }
        public int NumeroSala { get; set; }
        public int LotacaoMaxima { get; set; }
        public char SalaComAcessibilidade { get; set; }       

        public List<Sala>? SalaList { get; set; }

        //public Sala()
        //{
        //    SalaList = new List<Sala>();
        //}

        

    }

    
}
