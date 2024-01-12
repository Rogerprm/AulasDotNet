using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoCinema
{
    public class Sessao
    {
        public int IdSessao { get; set; }

        public DateTime HorarioSessao { get; set; }

        public Filme Filme { get; set; }

        public Sala Sala { get; set; }

        //public List<Sessao> sessoesList { get; set; }

        //public Sessao()
        //{
        //    sessoesList = new List<Sessao>();
        //}
        
    }
}
