using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseAbstrata.Produtos
{
    public abstract class Eletronico
    {
        public int Voltagem { get; private set; }
        public int Valor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }        
        public int Polegadas { get; set; }

        public void SetVoltagem(int voltagem)
        {
            Voltagem = voltagem;
        }


    }
}
