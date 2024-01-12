
using ClasseAbstrata.Funcionario;

namespace ClasseAbstrata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Classe abstrata!");

            var gerenciamentoapp = new Controle();
            gerenciamentoapp.ExibirMenuPrincipal();



        }
    }
}


