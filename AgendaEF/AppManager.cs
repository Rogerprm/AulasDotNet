using AgendaEF.Logs;
using AgendaEF.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaEF
{
    public class AppManager
    {

        public void MenuAplicacao()
        {
            Console.WriteLine("AGENDA");

            int codigo = 0;

            Console.WriteLine("1 - Add Reuniao");
            Console.WriteLine("2 - Complementar Reuniao");
            Console.WriteLine("3 - Reagendar Reuniao");
            Console.WriteLine("4 - Listar Reunioes");
            Console.WriteLine("5 - Encerrar Tarefa");
            Console.WriteLine("6 - Cancelar Reuniao");
            Console.WriteLine("7 - Alterar executor da Tarefa");
            Console.WriteLine("8 - Exportar agenda");
            Console.WriteLine("9 - Add Tarefa");
            Console.WriteLine("10 - Importar agenda");
            Console.WriteLine("0 - Sair");
            try
            {
                codigo = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no codigo informado!");
                LogApp.LogErro(ex.Message);
            }

            switch (codigo)
            {
                case 0:
                    Sair();
                    break;
                case 1:
                    AddReuniao();
                    break;
                case 2:
                    ComplementarReuniao();
                    break;
                case 3:
                    ReagendarReuniao();
                    break;
                case 4:
                    ListarReunioes();
                    break;
                case 5:
                    EncerrarTarefa();
                    break;
                case 6:
                    CancelarReuniao();
                    break;
                case 7:
                    AlterarExecutorTarefa();
                    break;
                case 8:
                    ExportarAgenda();
                    break;
                case 9:
                    AddTarefa();
                    break;
                case 10:
                    ImportarAgenda();
                    break;
            }
            if (codigo != 0)
            {
                MenuAplicacao();
            }
        }

        public void Sair()
        {
            Environment.Exit(0);
            LogApp.LogInfo("Programa agenda foi Finalizado!");
        }

        public void AddReuniao()
        {
            DateTime agendamento = DateTime.Now;
            string assunto = null;
            try
            {
                Console.WriteLine("Digite o Assunto: ");
                assunto = Console.ReadLine();

                Console.WriteLine("Digite a data: ");
                agendamento = DateTime.Parse(Console.ReadLine());

                LogApp.LogInfo($"Solicitado criacao de reuniao nova com assunto: {assunto} no dia {agendamento} ");
                var app = new Application();
                var novaReuniao = app.CriarReuniao(assunto, agendamento);
                Console.WriteLine(novaReuniao.ToString());
            }
            catch (Exception ex)
            {
                //logAppUser.LogInformationUser("Erro", $"A data informada não é valida para reuniao. Tente novamente");
                Console.WriteLine($"Não foi possivel criar uma nova reuniao com os parametros informados data: {agendamento} e assunto {assunto}");
                LogApp.LogErro(ex.Message);
                AddReuniao();
            }
        }

        public void ComplementarReuniao()
        {
            var context = new AgendaContext();
            int idReuniao = 0;
            int QtdTarefas = 0;
            string ata = null;
            try
            {
                Console.WriteLine("Qual o ID da reuniao? ");
                idReuniao = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite a Ata da Reuniao: ");
                ata = Console.ReadLine();

                var reuniao = context.Reunioes.Find(idReuniao);
                if (reuniao != null)
                {
                    reuniao.Ata = ata;
                    context.Entry(reuniao).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Reuniao não encontrada!");
                    ComplementarReuniao();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir ata da reuniao! ");
                LogApp.LogErro(ex.Message);
            }

            try
            {
                Console.WriteLine("Quantas tarefas serão criadas ? ");
                QtdTarefas = int.Parse(Console.ReadLine());

                for (int i = 0; i < QtdTarefas; i++)
                {
                    Console.WriteLine("Qual a tarefa? ");
                    string tarefaPendente = Console.ReadLine();
                    Console.WriteLine("Quem é o responsavel? ");
                    string responsavelTarefa = Console.ReadLine();

                    var tarefa = new Tarefa();
                    tarefa.Descricao = tarefaPendente;
                    tarefa.Responsavel = responsavelTarefa;
                    tarefa.ReuniaoId = idReuniao;

                    context.Add(tarefa);
                    context.SaveChanges();
                    Console.WriteLine($"Tarefa {tarefaPendente} inserida com sucesso");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir as tarefas.");
                LogApp.LogErro(ex.Message);
            }
        }

        public void AddTarefa()
        {
            int idReuniao = 0;
            string tarefaPendente = null;
            string responsavelTarefa = null;
            string retornoUsuario = null;
            try
            {
                Console.WriteLine("Qual o ID da reuniao? ");
                idReuniao = int.Parse(Console.ReadLine());
                Console.WriteLine("Qual a tarefa? ");
                tarefaPendente = Console.ReadLine();
                Console.WriteLine("Quem é o responsavel? ");
                responsavelTarefa = Console.ReadLine();

                var app = new Application();
                retornoUsuario = app.CriarTarefa(idReuniao, tarefaPendente, responsavelTarefa);
                LogApp.LogInfo($"tarefa {tarefaPendente} inserida com sucesso para o {responsavelTarefa} na reuniao {idReuniao}");
                Console.WriteLine(retornoUsuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(retornoUsuario);
                LogApp.LogErro(ex.Message);
            }

        }

        public void ListarReunioes()
        {
            try
            {
                var reunioes = new Application();
                var reunioesAgendadas = reunioes.SelecionarReunioes();

                foreach (var reuniao in reunioesAgendadas)
                {
                    Console.WriteLine($" Id: {reuniao.ReuniaoId} Assunto: {reuniao.Assunto} Data: {reuniao.DataReuniao} ");

                    foreach (var tarefa in reuniao.Tarefas)
                    {
                        Console.WriteLine($" Id: {tarefa.TarefaId} Tarefa: {tarefa.Descricao}");
                    }
                }
            }
            catch (Exception ex)
            {
                LogApp.LogErro(ex.Message);
                Console.WriteLine("Não foi possivel listar as reunioes.");
            }


        }

        public void ReagendarReuniao()
        {
            int id = 0;
            DateTime agendamento = DateTime.Now;

            Console.WriteLine("Qual a reuniao que voce quer reagendar? ");
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                //logAppUser.LogInformationUser("Erro", $"{id} não é um ID valido para reuniao. Tente novamente");
                Console.WriteLine($"Este não é um ID valido para reuniao. Tente novamente");
                LogApp.LogErro(ex.Message);
                ListarReunioes();
                ReagendarReuniao();
            }

            try
            {
                Console.WriteLine("Qual a nova data da reuniao ? ");
                agendamento = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                //logAppUser.LogInformationUser("Erro", $"{agendamento} não é uma data valida para reuniao. Tente novamente");
                Console.WriteLine($"{agendamento} não é uma data valida para reuniao. Tente novamente");
                LogApp.LogErro(ex.Message);
                ReagendarReuniao();
            }

            var app = new Application();
            var reagendamento = app.ReagendarReuniao(id, agendamento);
            Console.WriteLine(reagendamento.ToString());
        }

        public void EncerrarTarefa()
        {
            int id = 0;
            string retornoUsuario = null;
            try
            {
                Console.WriteLine("Qual a tarefa que voce quer encerrar? ");
                id = int.Parse(Console.ReadLine());

                var app = new Application();
                retornoUsuario = app.EncerrarTarefa(id);
                LogApp.LogInfo(retornoUsuario);
            }
            catch (Exception ex)
            {
                LogApp.LogErro(ex.Message);
                Console.WriteLine("Erro no encerramento da tarefa: " + retornoUsuario + " Tente novamente");
                EncerrarTarefa();
            }
        }

        public void CancelarReuniao()
        {
            Console.WriteLine("Qual a Reuniao que voce quer encerrar? ");
            int id = int.Parse(Console.ReadLine());

            var app = new Application();
            app.CancelarReuniao(id);


        }

        public void AlterarExecutorTarefa()
        {
            Console.WriteLine("Qual a tarefa que voce quer altear o Executor? ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o novo Executor? ");
            string executor = Console.ReadLine();

            var app = new Application();
            app.TrocaResponsavel(id, executor);
        }

        public void ExportarAgenda()
        {
            try
            {
                string path = "C:\\Users\\roger\\OneDrive\\Geral\\Documentos\\Estudo 2023\\dotnet\\Leandro\\AulasDotNet\\AgendaEF\\Arquivos\\arquivo.csv";
                StreamWriter writer = new StreamWriter(path);

                var reunioes = new Application();
                var reunioesTarefasAgendadas = reunioes.ExportarReunioesTarefas();

                writer.WriteLine($"AssuntoReuniao,Ata,DataReuniao,ReuniaoAtiva,DescricaoTarefa,ResponsavelTarefa,TarefaAtiva");

                foreach (var reuniao in reunioesTarefasAgendadas)
                {
                    writer.WriteLine($"{reuniao.Reuniao.Assunto},{reuniao.Reuniao.Ata},{reuniao.Reuniao.DataReuniao},{reuniao.Reuniao.ReuniaoAtiva},{reuniao.Descricao},{reuniao.Responsavel},{reuniao.TarefaAtiva}");
                }

                writer.Close();
                LogApp.LogInfo("Arquivo gerado com sucesso");
                Console.WriteLine("Gerado com sucesso");
            }
            catch (Exception ex)
            {
                LogApp.LogErro(ex.Message);
                Console.WriteLine("Erro na geração do arquivo");
            }

        }

        public void ImportarAgenda()
        {
            try
            {
                string path = "C:\\Users\\roger\\OneDrive\\Geral\\Documentos\\Estudo 2023\\dotnet\\Leandro\\AulasDotNet\\AgendaEF\\Arquivos\\arquivo.csv";
                StreamReader reader = new StreamReader(path);

                string linhaArquivo;
                reader.ReadLine();
                while ((linhaArquivo = reader.ReadLine()) != null)
                {
                    string[] Reunioes = linhaArquivo.Split(',');
                    foreach (var item in Reunioes)
                    {
                        Console.WriteLine($"{item[0]} - {item[3]} ");
                    }

                }
                reader.Close();
                LogApp.LogInfo("Arquivo gerado");
            }
            catch (Exception ex)
            {
                LogApp.LogErro(ex.Message);
                Console.WriteLine("Erro na leitura do arquivo");
            }
            
        }


    }
}
