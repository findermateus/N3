using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emissao_Fatura_N3
{
    public class Endereco
    {
        protected string Estado;
        protected string Cidade;
        protected string Cep;
        protected string Complemento;

        public Endereco(string Estado,string Cidade, string Cep, string Complemento)
        {
            this.Estado = Estado;
            this.Cidade = Cidade;
            this.Cep = Cep;
            this.Complemento = Complemento;
        }
    }
}
