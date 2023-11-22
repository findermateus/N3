using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anotacoes
{
    public class Livro
    {
        private string codigo;
        private string titulo;
        private string autor;
        private string editora;
        private int paginas;
        private List<Anotacao> notas = new List<Anotacao>();

        public string Codigo { get => codigo; private set => codigo = value; }
        public string Titulo { get => titulo; private set => titulo = value; }
        public string Autor { get => autor; private set => autor = value; }
        public string Editora { get => editora; private set => editora = value; }
        public int Paginas { get => paginas; private set => paginas = value; }
        public List<Anotacao> Notas { get => notas; private set => notas = value; }


        public Livro(string cod, string tit, string aut, string edi, int pag)
        {
            this.codigo = cod;
            this.titulo = tit;
            this.autor = aut;
            this.editora = edi;
            this.paginas = pag;
        }

        public Livro(string cod, string tit, string aut, string edi, int pag, List<Anotacao> nts)
        {
            this.codigo = cod;
            this.titulo = tit;
            this.autor = aut;
            this.editora = edi;
            this.paginas = pag;
            this.notas = nts;
        }
    }
}
