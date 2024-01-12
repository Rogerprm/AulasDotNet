using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoCinema
{
    public class GerenciamentoApp
    {
        public List<Filme> FilmeList { get; set; } = new List<Filme>(); //instanciar propriedade
        public List<Sala>? SalaList { get; set; } = new List<Sala>();
        public List<Cliente> ClienteList { get; set; } = new List<Cliente>();
        public List<Sessao> SessoesList { get; set; } = new List<Sessao> ();
        public List<Ingresso> IngressosList { get; set; } = new List<Ingresso> ();

        public void ExibirMenuPrincipal()
        {
            Console.WriteLine("Escolha uma opcao: ");
            Console.WriteLine("1 - Cadastro de Filmes");
            Console.WriteLine("2 - Listar Filmes");
            Console.WriteLine("3 - Cadastro de Salas");
            Console.WriteLine("4 - Listar salas");
            Console.WriteLine("5 - Cadastro de Sessao");
            Console.WriteLine("6 - Listar Sessoes");
            Console.WriteLine("7 - Cadastro de Clientes");
            Console.WriteLine("8 - Listar Clientes");
            Console.WriteLine("9 - Venda de Ingressos");
            Console.WriteLine("10 - Listar Ingressos");
            Console.WriteLine("0 - Sair");
            int a = Int32.Parse(Console.ReadLine());

            MenuPrincipal(a);
        }

        public void MenuPrincipal(int a)
        {
            Filme filme = new Filme();
            Sessao sessao = new Sessao();
            Ingresso ingresso = new Ingresso();
            Sala sala = new Sala();
            Cliente cliente = new Cliente();

            switch (a)
            {
                case 0:
                    Sair();
                    break;
                case 1:
                    CadastrarFilme();
                    break;
                case 2:
                    ListarFilmes();
                    break;
                case 3:
                    CadastrarSala();
                    break;
                case 4:
                    ListarSalas();
                    break;
                case 5:
                    CadastrarSessao(FilmeList, SalaList);
                    break;
                case 6:
                    ListarSessoes();
                    break;
                case 7:
                    CadastrarCliente();
                    break;
                case 8:
                    ListarClientes();
                    break;
                case 9:
                    VendaIngresso(SessoesList, ClienteList);
                    break;
                case 10:
                    ListarIngressosVendidos();
                    break;
            }
            if (a != 0)
            {
                ExibirMenuPrincipal();
            }
        }

        public void CadastrarFilme()
        {
            Console.WriteLine("Cadastro de filmes: ");

            Filme filme = new Filme();

            //Console.WriteLine("ID do filme: ");
            filme.IdFilme = FilmeList.Count + 1;
            Console.WriteLine("Nome do filme: ");
            filme.NomeFilme = Console.ReadLine();
            Console.WriteLine("Duracao do filme: ");
            filme.DuracaoFilme = Console.ReadLine();

            FilmeList.Add(filme);

        }

        public void ListarFilmes()
        {
            foreach (Filme filmes in FilmeList)
            {
                Console.WriteLine(filmes.IdFilme + " " + filmes.NomeFilme + " " + filmes.DuracaoFilme);
            }

        }

        public void Sair()
        {
            Environment.Exit(0);
        }


        public void CadastrarSala()
        {
            Console.WriteLine("Cadastro de salas: ");

            Sala sala = new Sala();

            sala.IdSala = SalaList.Count + 1; ;
            Console.WriteLine("Numero da sala: ");
            sala.NumeroSala = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Lotacao Maxima da sala: ");
            sala.LotacaoMaxima = Int32.Parse(Console.ReadLine());
            Console.WriteLine("SalaComAcessibilidade: ");
            sala.SalaComAcessibilidade = Char.Parse(Console.ReadLine());

            SalaList.Add(sala);
        }

        public void ListarSalas()
        {
            foreach (Sala salas in SalaList)
            {
                Console.WriteLine(salas.NumeroSala + " " + salas.LotacaoMaxima + " " + salas.SalaComAcessibilidade);
            }
        }

        public void CadastrarCliente()
        {
            Console.WriteLine("Cadastro de clientes: ");

            Cliente cliente = new Cliente();

            cliente.IdCliente = ClienteList.Count + 1;
            Console.WriteLine("Nome do cliente: ");
            cliente.NomeCliente = Console.ReadLine();
            Console.WriteLine("Data de nascimento: ");
            cliente.DataNascimentoCliente = DateTime.Parse(Console.ReadLine());


            ClienteList.Add(cliente);
        }

        public void ListarClientes()
        {
            foreach (Cliente clientes in ClienteList)
            {
                Console.WriteLine(clientes.IdCliente + " " + clientes.NomeCliente + " " + clientes.DataNascimentoCliente);

                //public int AutoIncremento() desnecessario
                //{            
                //    int a = FilmeList.Count();
                //    return ++a;
                //}

            }
        }

        public void CadastrarSessao(List<Filme> listaFilme, List<Sala> listaSala)
        {
            Console.WriteLine("Cadastro de sessoes: ");

            Sessao sessao = new Sessao();

            sessao.IdSessao = SessoesList.Count + 1;
            Console.WriteLine("Horario da sessao: ");
            sessao.HorarioSessao = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("ID do filme: ");
            var filmeId = Int32.Parse(Console.ReadLine());
            var filmeRetornado = listaFilme.Where(filme => filme.IdFilme == filmeId).FirstOrDefault();

            //Console.WriteLine(filmeRetornado);

            sessao.Filme = filmeRetornado;

            Console.WriteLine("Sala: ");
            var salaId = Int32.Parse(Console.ReadLine());
            var salaRetornada = listaSala.Where(sala => sala.IdSala == salaId).FirstOrDefault();
            Console.WriteLine(salaRetornada);
            sessao.Sala = salaRetornada;


            SessoesList.Add(sessao);
        }

        public void ListarSessoes()
        {
            foreach (Sessao sessoes in SessoesList)
            {
                Console.WriteLine(sessoes.HorarioSessao + " " + sessoes.Filme.NomeFilme + " " + sessoes.Filme.DuracaoFilme + " " + sessoes.Sala.NumeroSala);
            }
        }

        public void VendaIngresso(List<Sessao> listaSessao, List<Cliente> listacliente)
        {

            Console.WriteLine("Venda de ingressos: ");

            Ingresso ingresso = new Ingresso();

            ingresso.IdIngresso = IngressosList.Count + 1;
            Console.WriteLine("Valor pago: ");
            ingresso.Valorpago = float.Parse(Console.ReadLine());

            Console.WriteLine("ID da Sessao: ");
            var sessaoId = Int32.Parse(Console.ReadLine());
            var sessaoRetornada = listaSessao.Where(sessao => sessao.IdSessao == sessaoId).FirstOrDefault();

            ingresso.sessao = sessaoRetornada;

            Console.WriteLine("ID do cliente: ");
            var clienteId = Int32.Parse(Console.ReadLine());
            var clienteRetornado = listacliente.Where(listacliente => listacliente.IdCliente == clienteId).FirstOrDefault();

            ingresso.cliente = clienteRetornado;

            Console.WriteLine(sessaoRetornada);

            IngressosList.Add(ingresso);


        }

        public void ListarIngressosVendidos()
        {
            foreach (Ingresso ingressos in IngressosList)
            {
                Console.WriteLine(ingressos.cliente.NomeCliente + " " + ingressos.sessao.Filme.NomeFilme + " " + ingressos.Valorpago);
            }
        }

    }
}

