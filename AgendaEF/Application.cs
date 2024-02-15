using AgendaEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEF
{
    public class Application
    {
        public Application()
        {
            var appManager = new AppManager();
        }

        //C
        public void CriarReuniao(string assunto, DateTime agendamento)
        {
            var reuniao = new Reuniao();
            reuniao.Assunto = assunto;
            reuniao.DataReuniao = agendamento;
            reuniao.Tarefas = new List<Tarefa>();

            var context = new AgendaContext();
            context.Add(reuniao);
            context.SaveChanges();
        }
         
        
        public void CriarTarefa(int idReuniao, string tarefaPendente, string responsavelTarefa)
        {

            var tarefa = new Tarefa();
            tarefa.Descricao = tarefaPendente;
            tarefa.Responsavel = responsavelTarefa;
            tarefa.ReuniaoId = idReuniao;

            var context = new AgendaContext();
            context.Add(tarefa);
            context.SaveChanges();
        }

        //R
        public List<Reuniao> SelecionarReunioes()
        {
            var appManager = new AppManager();
            var context = new AgendaContext();
            //var listaTarefas = context.Tarefas.ToList();
            var listaReunioes = context.Reunioes
                .Include(r => r.Tarefas)
                .Where(r => r.ReuniaoAtiva != false)
                .ToList();

            return listaReunioes ;
        }

        public List<Tarefa> ExportarReunioesTarefas()
        {
           // var appManager = new AppManager();
            var context = new AgendaContext();

            var listaReunioesTarefas = context.Tarefas
                .Include("Reuniao")
                //.Where(r => r.TarefaAtiva != false)
                .ToList();

            return listaReunioesTarefas;
        }

        public void ReagendarReuniao(int id, DateTime agendamento)
        {
            var context = new AgendaContext();
            var buscaReuniao = context.Reunioes.Find(id);

            if (buscaReuniao != null)
            {
                buscaReuniao.DataReuniao = agendamento;
            }

            context.Entry(buscaReuniao).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void EncerrarTarefa(int id)
        {
            var context = new AgendaContext();
            var buscaTarefa = context.Tarefas.Find(id);

            if (buscaTarefa != null)
            {
                buscaTarefa.TarefaAtiva = false;
            }

            context.Entry(buscaTarefa).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void CancelarReuniao(int id) 
        {
            var context = new AgendaContext();
            var buscaReuniao = context.Reunioes.Find(id);

            if (buscaReuniao != null)
            {
                buscaReuniao.ReuniaoAtiva = false;
            }

            context.Entry(buscaReuniao).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void TrocaResponsavel(int id, string executor)
        {
            var context = new AgendaContext();
            var buscaTarefa = context.Tarefas.Find(id);

            if (buscaTarefa != null)
            {
                buscaTarefa.Responsavel = executor;
            }

            context.Entry(buscaTarefa).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
