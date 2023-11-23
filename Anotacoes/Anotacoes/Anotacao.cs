using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anotacoes
{
    public class Anotacao
    {
        // campos
        private DateTime dataHora;
        private string nota;

        // propriedades
        public DateTime DataHora { get => dataHora; private set => dataHora = value; }
        public string Nota { get => nota; private set => nota = value; }


        // método construtor
        public Anotacao(DateTime dat, string not)
        {
            this.dataHora = dat;
            this.nota = not;
        }
    }
}
