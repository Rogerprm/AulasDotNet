using Biblioteca;
using ConsoleApp1;
using ProdutosApp;
using VeiculosApp;

namespace Instancia
{
    internal class Program
    {
        static void Main(string[] args)
        {
          //produtos
            var roupa = new Roupas();
            roupa.Id = 1;
            roupa.Valor = 2;
            roupa.Modelo = 'F';
            roupa.Tamanho = 3;

            var eletronico = new Eletronicos();
            eletronico.Id = 2;
            eletronico.Valor = 3;
            eletronico.Modelo = "C";

            Console.WriteLine(roupa.Id.ToString() + " " + roupa.Modelo.ToString());
            Console.WriteLine(eletronico.Id.ToString() + " " + eletronico.Modelo.ToString() + " " + eletronico.Valor.ToString());

            //VeiculosApp
            var v1 = new Carro();
            v1.Marca = "GM";
            v1.Modelo = "Onix";
            v1.AnoFabricacao = 2023;
            v1.Cambio = 'A';
            v1.QtdPortas = 4;

            v1.InformVeiculo(v1);

            //Veiculos eletricos
            var carroelel = new CarroEletrico();
            carroelel.Autonomia = 100;
            carroelel.CarregamentoRapido = true;
            carroelel.Montadora = "BYD";
            carroelel.Modelo = "XXX";


            var bikelel = new BicicletaEletrica();
            bikelel.Autonomia = 10;
            bikelel.VelocidadeMaxima = 30;
            bikelel.Montadora = "Caloi";
            bikelel.Modelo = "XXXK";

            Console.WriteLine(carroelel.Autonomia.ToString() + " " + carroelel.Montadora.ToString());
            Console.WriteLine(bikelel.Autonomia.ToString() + " " + bikelel.Montadora.ToString());

            //Biblioteca

            var livro = new Livro();
            livro.Titulo = "Titulo ABC";
            livro.Genero = "Genero Y";
            var editora = new Editora();
            editora.NomeEditora = "Editora X";
            var autor = new Autor();
            autor.Nome = "TEste";

            livro.Autor = autor;

            livro.Editora = editora;


            ImprimeNomeAutor(livro);



            Console.WriteLine(livro.Titulo.ToString() + " " + autor.Nome.ToString() + " " + editora.NomeEditora.ToString() + " " + livro.Genero.ToString());

            void ImprimeNomeAutor(Livro l)
            {
                Console.WriteLine(l.Autor.Nome);

            }


        }
    }
}
