using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseAbstrata.Funcionario
{
    public class Gerente : Funcionario
    {
        public override void AplicaNivel(string nivel)
        {
        }

        public double SalarioGerente()
        {
            return 10000; 
        }


        public override string InformacoesFuncionario()
        {
            return "O nome do funcionario é: " + Nome + " e o cargo é: " + Cargo; 
        }
    }
}
