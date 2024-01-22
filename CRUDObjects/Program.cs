using CRUDObjects.Entidades;

namespace CRUDObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var dbManager = new CrudManagerObjects();
            string dataAtual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //C
            //var cliente1 = new Cliente() { CPF = "54214585471", Nome = "TESTE NOVO", DataNascimento = DateTime.Parse("1994-03-18") };
            //dbManager.Create(cliente1);

            //var usuario1 = new Usuario() { Login = "usuario1Login", Senha = "senhausuario1" };
            //dbManager.Create(usuario1);

            //var cliente2 = new Cliente() { CPF = "00024568541", Nome = "TESTE NOVO 2", DataNascimento = DateTime.Parse("1998-03-18") };
            //dbManager.Create(cliente2);

            //var produto = new Produto() { Nome = "Produto Teste", PrecoUnitario = 50.65M };
            //dbManager.Create(produto);

            //produto = new Produto() { Nome = "Produto Teste 2", PrecoUnitario = 28.75M };
            //dbManager.Create(produto);

            //var venda = new Venda() { IdCliente = 31, IdProduto = 37, DataVenda = DateTime.Parse(dataAtual), Quantidade = 5 };
            //dbManager.Create(venda);

            //venda = new Venda() { IdCliente = 32, IdProduto = 37, DataVenda = DateTime.Parse(dataAtual), Quantidade = 50 };
            //dbManager.Create(venda);

            //R
            //var select = new Cliente();
            //var retornoCliente = dbManager.Read(new Cliente() );
            //foreach (var item in retornoCliente)
            //{
            //    // Aqui, você pode acessar as propriedades do item, por exemplo:
            //    Console.WriteLine($" ID: {item.Id},  Nome: {item.Nome}, CPF: {item.CPF}, Ativo: {item.Ativo}" );
            //}

            ////var vendaSelect = new Venda();
            //var retornoVenda = dbManager.Read(new Venda());
            //foreach (var item in retornoVenda)
            //{
            //    // Aqui, você pode acessar as propriedades do item, por exemplo:
            //    Console.WriteLine($" Produto: {item.IdProduto}, Cliente: {item.IdCliente}, Qtd: {item.Quantidade}");
            //}


            //var retornoUsr = dbManager.Read(new Usuario());
            //foreach (var item in retornoUsr)
            //{
            //    // Aqui, você pode acessar as propriedades do item, por exemplo:
            //    Console.WriteLine($" ID: {item.Id},  Nome: {item.Login}, Senha: {item.Senha} ");
            //}


            //U

            //var updateCliente = new Cliente() { Id = 2, CPF = "54214585471", Nome = "TESTE UPDATE ID", DataNascimento = DateTime.Parse("2000-03-18") };
            //dbManager.Update(updateCliente);

            ////D
            var delCliente = new Cliente();
            int clientesDeletados = dbManager.Delete(delCliente, 31);
            Console.WriteLine(clientesDeletados);

            var delUsuario = new Usuario();
            int UsrDeletados = dbManager.Delete(delUsuario, 2);
            Console.WriteLine(UsrDeletados);

        }
    }
}
