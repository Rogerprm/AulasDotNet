using EstruturaDeDados.Filas;
using EstruturaDeDados.Listas;
using EstruturaDeDados.Pilhas;
using Fila = EstruturaDeDados.Filas.Fila;

namespace EstruturaDeDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            //dados
            var d1 = new Dados() { Id = 1, Descricao = "Desc 1" };
            var d2 = new Dados() { Id = 2, Descricao = "Desc 2" };
            var d3 = new Dados() { Id = 3, Descricao = "Desc 3" };
            var d4 = new Dados() { Id = 4, Descricao = "Desc 4" };


            //fila
            var fila = new Fila();
            fila.Add(d1);
            var ultimoRemovido = fila.Remover();
            Console.WriteLine(ultimoRemovido.Descricao);


            //pilha
            var pilha = new Pilha();
            pilha.Empilhar(d1);
            pilha.Empilhar(d3);
            var desempilhado = pilha.Desempilhar();
            Console.WriteLine(desempilhado.Descricao);

            Console.WriteLine( " FIM ");

        }
    }
}
