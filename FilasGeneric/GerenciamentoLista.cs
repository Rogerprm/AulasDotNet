using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FilasGeneric
{
    internal class GerenciamentoLista<T>
    {
        //remover primeiro, ultimo e por index
        //inserir primeiro, ultimo e por index
        //busca pelo index e pelo nome

        public Nos<T> Primeiro { get; set; }
        public Nos<T> Ultimo { get; set; }

        private int _contador = 0;

        public void AddPrimeiro(T dados)
        {
            var no = new Nos<T>() { dadosArmazenados = dados };

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

        public void AddUltimo(T dados)
        {
            var noUltimo = new Nos<T>() { dadosArmazenados = dados };

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

        public void RemPrimeiro()
        {
            var no = new Nos<T>();

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

            _contador--;
        }

        public void RemUltimo()
        {
            var no = new Nos<T>();

            if (Ultimo == Primeiro)
            {
                Primeiro = null;
                Ultimo = null;
            }
            else
            {
                var temp = Ultimo.Anterior;
                Ultimo = Ultimo.Anterior;
                Ultimo.Anterior.Proximo = null;
                Ultimo.Anterior = temp.Anterior;

            }
            _contador--;
        }

        public void BuscaIndex(int indice)
        {
            //Nos no;

            var posicao = Primeiro;
            int idx = 0;

            while (posicao.Proximo != null && idx < indice)
            {
                posicao = posicao.Proximo;
                idx++;
            }

            var a = posicao.dadosArmazenados;
            var b = posicao.Proximo.dadosArmazenados;
            var c = posicao.Anterior.dadosArmazenados;

            Console.WriteLine(c + " <- " + a + " -> " + b);

        }

        public void BuscaNome(string nome)
        {
            //Nos no;

            var posicao = Primeiro;
            int idx = 0;

            while (posicao.dadosArmazenados.ToString() != nome)
            {
                posicao = posicao.Proximo;
                idx++;
            }

            var a = posicao.dadosArmazenados;
            var b = posicao.Proximo.dadosArmazenados;
            var c = "";
            if (posicao.Anterior != null)
            {
                c = posicao.Anterior.dadosArmazenados.ToString();
            }
            else
                c = "";
            Console.WriteLine(c + " <- " + a + " -> " + b);

        }

        public void AddIndex(T dados, int indice)
        {
            var no = new Nos<T>() { dadosArmazenados = dados };

            if (Primeiro == null)
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
