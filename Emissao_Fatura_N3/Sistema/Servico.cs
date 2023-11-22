using Emissao_Fatura_N3.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Emissao_Fatura_N3
{
    public class Servico
    {
        
        private string TipoServico;
        private double Valor;
        private string Descricao;
        private double Icms;
        //private int mes;
        public Servico(int opcao)
        {
                this.Valor = ServicoDesc.valor[opcao - 1];
                this.Icms = ServicoDesc.icms[opcao - 1];
                this.Descricao = ServicoDesc.descricao[opcao - 1];
                this.TipoServico = ServicoDesc.tipos[opcao - 1];   
        
        }
        public double valor { get => this.Valor; }
        public double icms { get => this.Icms; }
        public string descricao { get => this.Descricao; }
        public string tipo { get => this.TipoServico; }
        
    }
}
