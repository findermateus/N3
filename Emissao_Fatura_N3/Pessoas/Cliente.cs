using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emissao_Fatura_N3
{
    public class Cliente : Pessoa
    {
        protected List<Servico> Servicos = new List<Servico>();
       // protected List<Fatura> Faturas = new List<Fatura>();
       /* public void AddFatura(Fatura fatura)
        {
            Faturas.Add(fatura);
        }
        public void ConsutaFatura(List<Fatura> faturas) 
        {
            foreach (Fatura fatura in faturas)
            {
                faturas.Add(fatura);
            }
        }*/
    }
}
