using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VeiculosApp
{
    public class Veiculo
    {
        public int AnoFabricacao { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public Carro QtdPortas { get; set; }

        public void LigarVeiculo(Veiculo veic) 
        {
            Console.WriteLine("Veiculo Ligado... " + Marca);
        }

        public void DesligarVeiculo(Veiculo veic)
        {
            Console.WriteLine("Veiculo Desligado... " + Marca);
        }

        public void InformVeiculo(Veiculo veic)
        {
            Console.WriteLine("Veiculo " + Marca + " " + Modelo + " " + AnoFabricacao);
        }

    }
}
