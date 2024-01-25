using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEF.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string Descricao { get; set; }
        public string Responsavel { get; set; }
        public int ReuniaoId { get; set; }
        public Reuniao Reuniao { get; set; }
    }
}
