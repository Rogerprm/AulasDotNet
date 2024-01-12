using EstruturaDeDados.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaDeDados.Filas
{


    public class Fila : EstruturaDeDados
    {
        Dados dados = new Dados();
        public void Add(Dados dados)
        {
            AddPrimeiro(dados);
        }

        public Dados Remover()
        {
            var dados = RemUltimo();
            return dados;
        }


    }
}
