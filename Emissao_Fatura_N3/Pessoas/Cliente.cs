using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emissao_Fatura_N3
{
    public class Cliente
    {
        protected string CodigoIdentificador;
        protected string Nome;
        protected string Telefone;
        protected Endereco Endereco;
        protected List<Servico> Servicos = new List<Servico>();
       // protected List<Fatura> Faturas = new List<Fatura>();
        public List<Servico> servicos { get => this.Servicos; }
        public string tel { get => this.Telefone; }
        public Endereco end { get => this.Endereco; }
        public string nome { get => this.Nome; }
    }
}
