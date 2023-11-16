using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emissao_Fatura_N3
{
    public class ClienteFisico: Cliente
    {
        private string Cpf;

        public ClienteFisico(string cpf, string telefone, Endereco endereco, string codigoIdentificador,string nome)
        {
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.Endereco = endereco;
            this.Nome = nome;
            this.CodigoIdentificador = codigoIdentificador;
        }
        public string cpf {get => this.Cpf;}
        public string codigoIdentificador { get => this.CodigoIdentificador; }
    }
}
