using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emissao_Fatura_N3.Pessoas
{
    public class ClienteJuridico: Cliente
    {
        private string Cnpj;

        public ClienteJuridico(string cnpj, string telefone, Endereco endereco, string codigoIdentificador, string nome)
        {
            this.Cnpj = cnpj;
            this.Telefone = telefone;
            this.Endereco = endereco;
            this.Nome = nome;
            this.CodigoIdentificador = codigoIdentificador;
        }
        public string cnpj { get => this.Cnpj; }
        public string codigoIdentificador { get => this.CodigoIdentificador;}
    }
}
