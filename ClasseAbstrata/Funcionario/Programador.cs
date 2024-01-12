using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseAbstrata.Funcionario
{
    public class Programador : Funcionario
    {
        public string Nivel { get; set; }
        public string HoraExtra { get; set; }


        public override void AplicaNivel(string nivel)
        {
            Nivel = nivel;
        }

        public override string InformacoesFuncionario()
        {
            return "O nome do funcionario é: " + Nome + " e o cargo é: " + Cargo;
        }

        public double SalarioProgramador(string nivel)
        {
            double salario = 0;

            if (nivel == "jr")
            {
                 salario = 1000;
            }
            else if (nivel == "pl")
            {
                 salario = 2000;
            }
            else if (nivel == "sr")
            {
                 salario = 2000;
            }

            return salario;

        }
    }
}


