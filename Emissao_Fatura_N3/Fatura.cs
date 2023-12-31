﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Emissao_Fatura_N3
{
    public class Fatura
    {
        //private List<Servico> servicos = new List<Servico>();
        private List<string> Dados = new List<string>();
        private Endereco EnderecoCliente;
        private int[] Vencimento = new int[2];
        public List<string> dados { get => this.dados; }
        public void CalculaVencimento(int dia, int mes)
        {
            int vencimento = mes + 1;
            vencimento %= 13;
            if (vencimento < 1) vencimento++;
            this.Vencimento[1] = vencimento;
            this.Vencimento[0] = dia;

        }
        public void AddDados(List<string> dados)
        {
            this.Dados = dados;
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
                total += servico.valor + ((servico.icms/100)*servico.valor);
            }
            return total;
        }
        public void EmitirFatura(List<Servico> servicos)
        {
            Tela.DesenhaBorda(0,0,79,24,"Fatura");
            Tela.EscreveMenu(this.Dados,1,1);
            Tela.EscreveMenu(EnderecoCliente.Dados(),1, this.Dados.Count + 1);
            List<string> lista = new List<string>();
            foreach(Servico servico in servicos)
            {
                lista.Add(servico.tipo + ": R$" + servico.valor + " + ICMS: %"+servico.icms);
            }
            lista.Add("Valor total: " + CalcutaTotal(servicos).ToString());
            lista.Add("Data de vencimento: " + this.Vencimento[0] + "/" + this.Vencimento[1]);
            Tela.EscreveMenu(lista,1,(this.Dados.Count+1)+(EnderecoCliente.Dados().Count+1));
        }
       
    }
}
