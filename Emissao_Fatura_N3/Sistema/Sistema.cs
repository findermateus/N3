﻿using Emissao_Fatura_N3.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emissao_Fatura_N3.Sistema
{
    public class Sistema
    {
        private List<Servico> Servicos = new List<Servico>();
        private List<ClienteFisico> ClientesFisicos = new List<ClienteFisico>();
        private List<ClienteJuridico> ClientesJuridicos = new List<ClienteJuridico>();
        public int Dia, Mes;

        public void SetaData(int dia, int mes)
        {
            
            this.Dia = dia;
            
            this.Mes = mes;
        }
        public List<Servico> servicos { get => this.Servicos; }
        public List<ClienteFisico> clientesFisicos { get => this.ClientesFisicos; }
        public List<ClienteJuridico> clientesJuridicos { get => this.ClientesJuridicos; }
    }
}
