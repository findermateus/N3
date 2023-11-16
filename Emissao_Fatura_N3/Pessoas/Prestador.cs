using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emissao_Fatura_N3.Pessoas
{
    public class Prestador: Pessoa
    {
        private List<string> Tipos = new List<string>();
        private List<Servico> Servicos = new List<Servico>();

        public Prestador(string codigoIdentificador, string nome, string telefone, Endereco endereco, List<string> Tipos)
        {
            this.CodigoIdentificador = codigoIdentificador;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Endereco = endereco;
            this.Tipos = Tipos;
        }
    }
}
