using AgendaEF.Migrations;
using AgendaEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEF
{
    public class AppManager
    {

        public void MenuAplicacao()
        {
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
            int codigo = Int32.Parse(Console.ReadLine());

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
        }

        public void AddReuniao()
        {

            Console.WriteLine("Digite o Assunto: ");
            string assunto = Console.ReadLine();
            Console.WriteLine("Digite a data: ");
            DateTime agendamento = DateTime.Parse(Console.ReadLine());

            var app = new Application();
            app.CriarReuniao(assunto, agendamento);

        }

        public void ComplementarReuniao()
        {
            var context = new AgendaContext();

            Console.WriteLine("Qual o ID da reuniao? ");
            int idReuniao = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Ata da Reuniao: ");
            string ata = Console.ReadLine();

            var reuniao = context.Reunioes.Find(idReuniao);
            reuniao.Ata = ata;

            context.Entry(reuniao).State = EntityState.Modified;
            context.SaveChanges();

            Console.WriteLine("Quantas tarefas serão criadas ? ");
            int QtdTarefas = int.Parse(Console.ReadLine());

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

            }



        }

        public void AddTarefa()
        {
            Console.WriteLine("Qual o ID da reuniao? ");
            int idReuniao = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual a tarefa? ");
            string tarefaPendente = Console.ReadLine();
            Console.WriteLine("Quem é o responsavel? ");
            string responsavelTarefa = Console.ReadLine();

            var app = new Application();
            app.CriarTarefa(idReuniao, tarefaPendente, responsavelTarefa);
        }

        public void ListarReunioes()
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

        public void ReagendarReuniao()
        {
            Console.WriteLine("Qual a reuniao que voce quer reagendar? ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual a nova data da reuniao ? ");
            DateTime agendamento = DateTime.Parse(Console.ReadLine());

            var app = new Application();
            app.ReagendarReuniao(id, agendamento);

        }

        public void EncerrarTarefa()
        {
            Console.WriteLine("Qual a tarefa que voce quer encerrar? ");
            int id = int.Parse(Console.ReadLine());

            var app = new Application();
            app.EncerrarTarefa(id);

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

            Console.WriteLine("Gerado com sucesso");
        }

        public void ImportarAgenda()
        {
            string path = "C:\\Users\\roger\\OneDrive\\Geral\\Documentos\\Estudo 2023\\dotnet\\Leandro\\AulasDotNet\\AgendaEF\\Arquivos\\arquivo.csv";
            StreamReader reader = new StreamReader(path);

            string linhaArquivo;
            while ((linhaArquivo = reader.ReadLine()) != null)
            {
                Console.WriteLine(linhaArquivo);
            }
            reader.Close();
        }

        //Correções 14/02:
            //Corrigir o reagendamento de datas que ja passaram
            //Exportacao do arquivo: buscar todas tarefas include reuniao
            //Cada linha é uma reuniao COM as tarefas
            //Incluir logs com AppEnd atraves de uma nova classe LogApp (metodo erro e info e estaticos)
            //se o arquivo ficar com mais de XX Bytes, criar um novo (length)


        //Não é necessariamente um CRUD
        //Alterar executor da tarefa- 
        //Encerrar tarefa - 
        //Cancelar ou Alterar a Reuniao -
        //Metodos especificos para tarefas especificas (Alterar Executor, Alterar data reuniao)
        //Criar um menu
        //Cria a reuniao, depois a Ata e por fim as tarefas
    }
}
