using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEF.Models
{
    public class AgendaContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Reuniao> Reunioes { get; set; }
        private string _conn;

        public AgendaContext()
        {
                _conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\roger\\OneDrive\\Geral\\Documentos\\Estudo 2023\\dotnet\\Leandro\\AulasDotNet\\AgendaEF\\AgendaDB.mdf\";Integrated Security=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conn);
        }
        

        
    }
}
