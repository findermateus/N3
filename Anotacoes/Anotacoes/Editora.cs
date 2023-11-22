using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anotacoes
{
    public class Editora
    {
        // campos
        private string codigo;
        private string nome;

        // propriedades
        public string Codigo { get => codigo; private set => codigo = value; }
        public string Nome { get => nome; private set => nome = value; }

        // método construtor
        public Editora(string cod, string nom) 
        {
            this.codigo = cod;
            this.nome = nom;
        }

    }
}
