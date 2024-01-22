using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDObjects.Entidades
{
    public class Venda
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public DateTime DataVenda { get; set; }
        public int Quantidade { get; set; }
        //public decimal? PrecoTotal { get; set; }
        public char Ativo { get; set; }

    }
}
