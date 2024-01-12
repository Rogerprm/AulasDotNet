using ClasseAbstrata.Produtos;


namespace ClasseAbstrata.Funcionario
{
    public class Controle
    {
        public List<Funcionario> FuncList { get; set; } = new List<Funcionario>();
        public List<Eletronico> EletList { get; set; } = new List<Eletronico>();

        public void ExibirMenuPrincipal()
        {
            Console.WriteLine("Escolha uma opcao: ");
            Console.WriteLine("1 - Inserir Gerente");
            Console.WriteLine("2 - Inserir Programador");
            Console.WriteLine("3 - Listar Funcionarios");
            Console.WriteLine("4 - Inserir Smartphone");
            Console.WriteLine("5 - Inserir Televisor");
            Console.WriteLine("6 - Listar Produtos");
            Console.WriteLine("0 - Sair");

            int a = Int32.Parse(Console.ReadLine());

            MenuPrincipal(a);
        }

        private void MenuPrincipal(int a)
        {

            switch (a)
            {
                case 0:
                    Sair();
                    break;
                case 1:
                    InserirGerente();
                    break;
                case 2:
                    InserirProgramador();
                    break;
                case 3:
                    ListarFuncionarios();
                    break;
                case 4:
                    AddSmartphone();
                    break;
                case 5:
                    AddTelevisor();
                    break;
                case 6:
                    ListarProdutos();
                    break;
            }
            if (a != 0)
            {
                ExibirMenuPrincipal();
            }
        }

        public void Sair()
        {
            Environment.Exit(0);
        }

        public void InserirProgramador()
        {
            var funcionario = new Programador();
            Console.WriteLine("Nome do Funcionario: ");
            funcionario.Nome = Console.ReadLine();
            funcionario.Cargo = "Programador";
            Console.WriteLine("Nivel de Senioridade: ");
            funcionario.Nivel = Console.ReadLine();
            string nivel = funcionario.Nivel;
            funcionario.AplicaNivel(nivel);
            funcionario.Salario = funcionario.SalarioProgramador(nivel);
            double sal = funcionario.Salario;
            funcionario.Dissidio(sal);

            FuncList.Add(funcionario);

        }

        public void InserirGerente()
        {
            var funcionario = new Gerente();
            Console.WriteLine("Nome do Funcionario: ");
            funcionario.Nome = Console.ReadLine();
            funcionario.Cargo = "Gerente";
            funcionario.Salario = funcionario.SalarioGerente();
            double sal = funcionario.Salario;
            funcionario.Dissidio(sal);
            FuncList.Add(funcionario);
        }

        public void ListarFuncionarios()
        {
            foreach (Funcionario funcionario in FuncList)
            {
                Console.WriteLine(funcionario.InformacoesFuncionario());
                //Console.WriteLine("Nome: " + funcionario.Nome + " Cargo: " + funcionario.Cargo + " Salario Base: " + funcionario.Salario + " Aumento: " + funcionario.Aumento + " Salario total: " + (funcionario.Salario + funcionario.Aumento) );
            }
        }

        public void AddTelevisor()
        {
            var produto = new Televisor();
            //produto.Tipo = "Televisor";
            Console.WriteLine("Marca: ");
            produto.Marca = Console.ReadLine();
            Console.WriteLine("Smart: ");
            produto.Smart = bool.Parse(Console.ReadLine());

            Console.WriteLine("Modelo: ");
            produto.Modelo = Console.ReadLine();
            Console.WriteLine("Valor: ");
            produto.Valor = int.Parse(Console.ReadLine());
            Console.WriteLine("Voltagem: ");
            int voltagem = int.Parse(Console.ReadLine());
            produto.SetVoltagem(voltagem);
            Console.WriteLine("Polegadas: ");
            produto.Marca = Console.ReadLine();

            EletList.Add(produto);
        }

        public void AddSmartphone()
        {
            var produto = new Smartphone();
            //produto.Tipo = "Smartphone";
            Console.WriteLine("Marca: ");
            produto.Marca = Console.ReadLine();
            Console.WriteLine("Modelo: ");
            produto.Modelo = Console.ReadLine();
            Console.WriteLine("Valor: ");
            produto.Valor = int.Parse(Console.ReadLine());
            Console.WriteLine("Tempo de recarga: ");
            produto.TempoRecarga = int.Parse(Console.ReadLine());
            Console.WriteLine("Voltagem: ");
            int voltagem = int.Parse(Console.ReadLine());
            produto.SetVoltagem(voltagem);
            Console.WriteLine("Polegadas: ");
            produto.Marca = Console.ReadLine();

            EletList.Add(produto);
        }

        public void ListarProdutos()
        {
            foreach (Eletronico eletronico in EletList)
            {
                if (eletronico.GetType() == typeof(Smartphone))
                {
                    var smart = eletronico as Smartphone;
                    Console.WriteLine(" Marca: " + smart.Marca + " Modelo: " + smart.Modelo + " Valor: " + smart.Valor + " Recarga: " + smart.TempoRecarga);
                }
                else
                {
                    var televisor = eletronico as Televisor;
                    Console.WriteLine(" Marca: " + televisor.Marca + " Modelo: " + televisor.Modelo + " Valor: " + televisor.Valor + " Smart: "  + televisor.Smart);
                }
            }
        }
    }
}
