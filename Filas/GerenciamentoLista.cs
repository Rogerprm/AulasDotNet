namespace Filas
{
    internal class GerenciamentoLista
    {
        //remover primeiro, ultimo e por index
        //inserir primeiro, ultimo e por index
        //busca pelo index e pelo nome
        //Corrigir lista vazia em todos os removes
        //Teste completo add numeros grandes, chamar removes, chamar buscas com numeros impossiveis, add varios elementos e remover

        public Nos Primeiro { get; set; }
        public Nos Ultimo { get; set; }
        private int _contador = 0;

        public void AddPrimeiro(Dados dados)
        {
            var no = new Nos() { dados = dados };

            if (Primeiro == null)
            {
                Primeiro = no;
                Ultimo = no;
            }
            else
            {
                if (Primeiro == Ultimo)
                {
                    var temp = Primeiro;
                    Ultimo = temp;
                    Primeiro = no;
                    temp.Anterior = no;
                    Primeiro.Proximo = temp;
                }
                else
                {
                    Primeiro.Anterior = no;
                    no.Proximo = Primeiro;
                    Primeiro = no;
                }
            }
            _contador++;
        }

        public void AddUltimo(Dados dados)
        {
            var noUltimo = new Nos() { dados = dados };

            if (Primeiro == null)
            {
                Primeiro = noUltimo;
                Ultimo = noUltimo;
            }
            else
            {
                if (Primeiro == Ultimo)
                {
                    var temp = Ultimo;
                    Primeiro = temp;
                    Ultimo = noUltimo;
                    temp.Proximo = noUltimo;
                }
                else
                {
                    Ultimo.Proximo = noUltimo;
                    noUltimo.Anterior = Ultimo;
                    Ultimo = noUltimo;
                }
            }
            _contador++;
        }

        public Dados RemPrimeiro()
        {
            var no = new Nos();
            var dados = Primeiro.dados;
            if (Primeiro == null)
            {
                throw new ArgumentException("Lista Vazia");
            }
            else
            {
                if (Ultimo == Primeiro)
                {
                    Primeiro = null;
                    Ultimo = null;
                }
                else
                {
                    var temp = Primeiro.Proximo;
                    Primeiro.Proximo.Anterior = null;
                    Primeiro.Proximo = null;
                    Primeiro = temp;

                }
            }

            _contador--;
            return dados;
        }

        public Dados RemUltimo()
        {
            var no = new Nos();
            var dados = Ultimo.dados;
            if (Primeiro == null)
            {
                throw new ArgumentException("Lista Vazia");
            }
            else
            {
                if (Ultimo == Primeiro)
                {
                    Primeiro = null;
                    Ultimo = null;
                }
                else
                {
                    var temp = Ultimo.Anterior;
                    Ultimo = Ultimo.Anterior;
                    if (Ultimo.Anterior == null)
                    {
                        Ultimo = Primeiro;
                    }
                    else
                    {
                        Ultimo.Anterior.Proximo = null;
                        Ultimo.Anterior = temp.Anterior;
                    }

                }
            }
            _contador--;
            return dados;
        }

        public string BuscaIndex(int indice)
        {
            var posicao = Primeiro;
            //var desc = posicao.dados.Descricao;
            int idx = 0;

            while (posicao.Proximo != null && idx < indice)
            {
                posicao = posicao.Proximo;
                idx++;
            }

            return posicao.dados.Descricao;

            //return desc;
            //Console.WriteLine( desc );

        }

        public Dados BuscaNome(string nome)
        {
            Nos no;

            var posicao = Primeiro;
            int idx = 0;

            while (posicao.dados.Descricao != nome)
            {
                if (posicao.Proximo != null)
                {
                    posicao = posicao.Proximo;
                    idx++;
                }
                else
                {
                    throw new Exception(nome + " Não encontrado");
                }
            }

            return posicao.dados;

        }

        public void AddIndex(Dados dados, int indice)
        {
            var no = new Nos() { dados = dados };

            if (_contador < indice)
            {
                AddUltimo(dados);
            }

            else if (Primeiro == null)
            {
                Primeiro = no;
                Ultimo = no;
            }
            else
            {

                var posicao = Primeiro;
                int idx = 0;
                while (posicao.Proximo != null && idx < indice)
                {
                    posicao = posicao.Proximo;
                    idx++;
                }


                no.Proximo = posicao;
                no.Anterior = posicao.Anterior;

                posicao.Anterior.Proximo = no;
                posicao.Anterior = no;


            }
            _contador++;
        }

    }
}
