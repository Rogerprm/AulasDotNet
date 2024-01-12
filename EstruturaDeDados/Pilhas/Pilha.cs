using EstruturaDeDados.Filas;
using EstruturaDeDados.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaDeDados.Pilhas
{

    public partial class Pilha //: Fila
    {
        //Herança: A classe pai é chamada de Base Class
        //Partial Class é "um pedaço" de uma classe, pode ter outras classes e arquivos com o mesmo nome

        //public void Empilhar()
        //{

        //}
    }





    public partial class Pilha : EstruturaDeDados
    {
        Dados dados = new Dados();

        public void Empilhar(Dados dados)
        {        
            AddPrimeiro(dados);
        }

        public Dados Desempilhar()
        {
            var retornarDesempilhado = RemPrimeiro();
            return retornarDesempilhado;
        }
    }
}
