using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Livro 
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }

        public Autor Autor { get; set; }

        public Editora Editora { get; set; }


    }
}
