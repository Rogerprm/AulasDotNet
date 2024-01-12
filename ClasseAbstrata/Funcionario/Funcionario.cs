using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseAbstrata.Funcionario
{
    public abstract class Funcionario
    {
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public double Aumento { get; set; }

        public void Dissidio(double salario)
        {
            Aumento =+ (salario * 0.2);
        }

        public abstract string InformacoesFuncionario();
        public abstract void AplicaNivel(string nivel);


    }
}


/*
 * 4. *Sistema de Funcionários:*
   - Desenvolva uma classe abstrata "Funcionario" com propriedades como nome, cargo e salário.
   - Implemente métodos abstratos para calcular aumento salarial e exibir informações do funcionário.
   - Crie classes concretas como "Gerente" e "Programador" que herdam da classe abstrata.
 * 
 */