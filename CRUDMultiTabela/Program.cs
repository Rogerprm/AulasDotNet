namespace CRUDMultiTabela
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CRUD 2 ");


            var listaColunasCliente = new List<string>() { "CPF", "Nome", "DataNascimento" };
            var listaColunasProduto = new List<string>() { "Nome", "PrecoUnitario"};
            var listaColunasVenda = new List<string>() { "IdCliente", "IdProduto", "DataVenda", "Quantidade", "PrecoTotal"};
            
            var dbManager = new DatabaseManagerMultiTable();

            string dataAtual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            ///bool clienteAtivo = true;

            //C
            dbManager.Create("cliente", listaColunasCliente, new List<string>() { "0000000000", "roger", "1994-03-18"});
            dbManager.Create("produto", listaColunasProduto, new List<string>() { "mesa de jantar", "284.34"});
            dbManager.Create("venda", listaColunasVenda, new List<string>() { "2", "3", dataAtual , "5", "0.00" });


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
            dbManager.Update("cliente", 2, listaColunasCliente,new List<string>() { "55544477788", "ROGER", "2000-03-03" });


            //D
            dbManager.Delete("Cliente", 11); 
            dbManager.Delete("Produto", 8);
        }
    }
}