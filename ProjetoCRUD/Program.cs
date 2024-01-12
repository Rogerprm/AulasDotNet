using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace ProjetoCRUD
{
    internal class Program
    {

        // 1 tabela com o CRUD funcionando e com o codigo corrigido
        // 1 gerenciador de database para mais de uma tabela
        // 1 campo string, um decimal, um data
        static void Main(string[] args)
        {
            Console.WriteLine("CRUD");

            var dbManager = new DataBaseManager();
            if (dbManager.Testconnection())
            {
                Console.WriteLine("OK");
            }


            //Create
            dbManager.Create("Cadeira", 29.45M);
            dbManager.Create("Mesa", 150.28M);
            dbManager.Create("Livro", 12.25M);
            dbManager.Create("Cama", 129.45M);
            dbManager.Create("Toalha", 10M);
            dbManager.Create("Televisao", 1238.25M);

            //Read
            var Retorno = dbManager.Read();
            foreach (var item in Retorno)
            {
                Console.WriteLine($"ID: {Retorno["Id"]} , Produto: {Retorno["nome"]} , Preco: {Retorno["preco"]} , Data de Inclusao/Alteracao: {Retorno["DataInclusaoAlteracao"]}");
            }

            //Update
            dbManager.Update(1, 800.32M);
            //Console.WriteLine(Alterado);

            //Delete
            dbManager.Delete(2);


            Console.WriteLine("FIM");

        }
    }
}
