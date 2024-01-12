namespace Filas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var d1 = new Dados() { Id = 1, Descricao = "Desc 1" };
            var d2 = new Dados() { Id = 2, Descricao = "Desc 2" };
            var d3 = new Dados() { Id = 3, Descricao = "Desc 3" };
            var d4 = new Dados() { Id = 4, Descricao = "Desc 4" };
            var d5 = new Dados() { Id = 5, Descricao = "Desc 5" };
            var d6 = new Dados() { Id = 6, Descricao = "Desc 6" };
            var d7 = new Dados() { Id = 7, Descricao = "Desc 7" };

            var gerenciamento = new GerenciamentoLista();
            gerenciamento.AddPrimeiro(d1);
            //gerenciamento.BuscaIndex(10);
            //gerenciamento.AddPrimeiro(d2);
            //gerenciamento.AddPrimeiro(d4);
            //gerenciamento.AddPrimeiro(d3);
            //var ultimo = gerenciamento.RemUltimo();
            //Console.WriteLine(ultimo.Descricao);
            gerenciamento.AddIndex(d7, 100);
            gerenciamento.AddUltimo(d5);
            //gerenciamento.BuscaIndex(1);
            //var retorno = gerenciamento.BuscaNome("Desc 2");
            //Console.WriteLine(retorno.Descricao);
            //gerenciamento.AddUltimo(d6);    
            //var primeiro = gerenciamento.RemPrimeiro();
            //Console.WriteLine(primeiro.Descricao);
            //ultimo = gerenciamento.RemUltimo();
            //Console.WriteLine(ultimo.Descricao);
            //ultimo = gerenciamento.RemUltimo();
            //Console.WriteLine(ultimo.Descricao);

            Console.WriteLine("FIM");
        }
    }
}
