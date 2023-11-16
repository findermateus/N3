using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emissao_Fatura_N3
{
    public class Pessoa
    {
        protected string CodigoIdentificador;
        protected string Nome;
        protected string Telefone;
        protected Endereco Endereco;

        public string tel { get => this.Telefone; }
        public Endereco end { get => this.Endereco; }
        public string nome { get => this.Nome; }
    }
        
}
