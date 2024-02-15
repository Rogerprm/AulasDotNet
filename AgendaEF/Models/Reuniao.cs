using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEF.Models
{
    public class Reuniao
    {
        public int ReuniaoId { get; set; }
        public string Assunto { get; set; }
        public string? Ata { get; set; }
        public DateTime DataReuniao { get; set; }
        public List<Tarefa> Tarefas { get; set; } = new List<Tarefa>();

        public bool ReuniaoAtiva { get; set; } = true;

    }
}
