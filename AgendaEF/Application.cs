using AgendaEF.Logs;
using AgendaEF.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace AgendaEF
{
    public class Application
    {
        public Application()
        {
            var appManager = new AppManager();
        }

        public string CriarReuniao(string assunto, DateTime agendamento)
        {
            string retornoUsuario = null;
            try
            {
                var reuniao = new Reuniao();
                reuniao.Assunto = assunto;
                reuniao.DataReuniao = agendamento;
                reuniao.Tarefas = new List<Tarefa>();

                var context = new AgendaContext();
                context.Add(reuniao);
                context.SaveChanges();
                LogApp.LogInfo($"Reuniao {reuniao} agendada com sucesso!");
                retornoUsuario = $"Reuniao {reuniao} agendada com sucesso!";
            }
            catch (Exception ex)
            {
                LogApp.LogErro(ex.Message);
                retornoUsuario = "Erro no agendamento. Tente novamente. ";
            }

            return retornoUsuario;
        }
         
        
        public string CriarTarefa(int idReuniao, string tarefaPendente, string responsavelTarefa)
        {
            string retornoUsuario = null;
            try
            {
                var tarefa = new Tarefa();
                tarefa.Descricao = tarefaPendente;
                tarefa.Responsavel = responsavelTarefa;
                tarefa.ReuniaoId = idReuniao;

                var context = new AgendaContext();
                context.Add(tarefa);
                context.SaveChanges();
                retornoUsuario = "Tarefa criada com sucesso";
                LogApp.LogInfo(retornoUsuario);
            }
            catch (Exception ex)
            {
                retornoUsuario = "Erro na criação da tarefa.";
                LogApp.LogErro(ex.Message);
            }

            return retornoUsuario;
        }

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
                .ToList();

            return listaReunioesTarefas;
        }

        public string ReagendarReuniao(int id, DateTime agendamento)
        {
            var context = new AgendaContext();
            var buscaReuniao = context.Reunioes.Find(id);
            string retornoUsuario = null;

            if (buscaReuniao != null)
            {
                if (buscaReuniao.DataReuniao <= DateTime.Now && agendamento > DateTime.Now)
                {
                    buscaReuniao.DataReuniao = agendamento;
                    context.Entry(buscaReuniao).State = EntityState.Modified;
                    context.SaveChanges();
                    LogApp.LogInfo($"Reunião {id} reagendada para {agendamento}!");                    
                    retornoUsuario = $"Reunião {id} reagendada para {agendamento}!";                    
                    AppManager menu = new AppManager();
                    menu.MenuAplicacao();
                }
                else
                {
                    if (buscaReuniao.DataReuniao > DateTime.Now)
                    {                        
                        retornoUsuario = $"Impossivel reagendar uma reunião que ja passou ({buscaReuniao.DataReuniao}) ! ";
                    }
                    else if (agendamento < DateTime.Now)
                    {                        
                        retornoUsuario = $"Impossivel reagendar uma reunião para uma data ({agendamento}) anterior a hoje! ";
                    }                    
                    var reagendar = new AppManager();
                    reagendar.ReagendarReuniao();
                }
            }
            else
            {
                //logAppUser.LogInformationUser("INFO", $"Reunião {id} não encontrada. Tente novamente!");
                retornoUsuario = $"Impossivel reagendar uma reunião para uma data ({agendamento}) anterior a hoje! ";
                var reagendar = new AppManager();
                reagendar.ReagendarReuniao();
            }

            return retornoUsuario;
        }

        public string EncerrarTarefa(int id)
        {
            string retornoUsuario = null;
            try
            {
                var context = new AgendaContext();
                var buscaTarefa = context.Tarefas.Find(id);

                if (buscaTarefa != null)
                {
                    buscaTarefa.TarefaAtiva = false;
                }

                context.Entry(buscaTarefa).State = EntityState.Modified;
                context.SaveChanges();
                retornoUsuario = $"Tarefa {id} encerrada com sucesso";
                LogApp.LogInfo(retornoUsuario);
            }
            catch (Exception ex)
            {
                LogApp.LogErro(ex.Message);
                retornoUsuario = "Erro ao encerrar a tarefa";
            }

            return retornoUsuario;
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
