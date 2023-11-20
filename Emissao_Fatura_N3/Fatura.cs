using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emissao_Fatura_N3
{
    public class Fatura
    {
        //private List<Servico> servicos = new List<Servico>();
        private List<string> Dados = new List<string>();
        private Endereco EnderecoCliente;
        public void AddDados(List<string> Dados)
        {
            this.Dados = Dados;
        }
        public void AddEndereco(Endereco endereco)
        {
            this.EnderecoCliente = endereco;
        }
        public double CalcutaTotal(List<Servico> servicos)
        {
            double total = 0.0;
            foreach(Servico servico in servicos)
            {
                total += servico.valor;
            }
            return total;
        }
        public void EmitirFatura(List<Servico> servicos)
        {
            foreach(string dados in Dados)
            {
                Console.WriteLine(dados);
            }
            foreach(Servico servico in servicos)
            {
                Console.WriteLine(servico.tipo + ": R$" + servico.valor);
            }
        }
    }
}
