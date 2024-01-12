namespace CRUDMultiTabela
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CRUD 2 ");


            var listaColunasCliente = new List<string>() { "CPF", "Nome", "DataNascimento", "Ativo" };
            var listaColunasProduto = new List<string>() { "Nome", "PrecoUnitario", "Ativo"};
            var listaColunasVenda = new List<string>() { "IdCliente", "IdProduto", "DataVenda", "Quantidade", "PrecoTotal", "Ativo" };
            
            var dbManager = new DatabaseManagerMultiTable();

            //if (dbManager.Testconnection())
            //{
            //    Console.WriteLine("OK");
            //}

            string dataAtual = DateTime.Now.ToString();

            bool clienteAtivo = true;

            //C
            dbManager.Create("cliente", listaColunasCliente, new List<string>() { "0000000000", "roger", "1994-03-18", "1" });
            dbManager.Create("produto", listaColunasProduto, new List<string>() { "mesa de jantar", "284.34", "1" });
            dbManager.Create("venda", listaColunasVenda, new List<string>() { "2", "3", dataAtual, "5", "0.00", "1" });


            //R
            var clientes = dbManager.Read("Cliente");
            foreach (var item in clientes)
            {
                Console.WriteLine($"CPF: {clientes["CPF"]}, Nome: {clientes["Nome"]}, Data Nascimento: {clientes["DataNascimento"]} ");
            }

            var produtos = dbManager.Read("Produto");
            foreach (var item in produtos)
            {
                Console.WriteLine($"Nome: {produtos["Nome"]}, Preço: {produtos["PrecoUnitario"]} ");
            }

            var vendas = dbManager.Read("Venda");
            foreach (var item in vendas)
            {
                Console.WriteLine($"Cliente: {vendas["IdCliente"]}, Produto: {vendas["IdProduto"]}, Data Venda: {vendas["DataVenda"]}, Quantidade: {vendas["Quantidade"]} ");
            }

            //U



            //D

            dbManager.Delete("Cliente", 11); //Avaliar o delete
            dbManager.Delete("Produto", 8);

        }
    }
}


//"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="C:\Users\roger\OneDrive\Geral\Documentos\Estudo 2023\dotnet\Leandro\AulasDotNet\CRUDMultiTabela\CrudNovo.mdf";Integrated Security=True"