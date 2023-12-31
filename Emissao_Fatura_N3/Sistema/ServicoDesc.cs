﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Emissao_Fatura_N3.Sistema
{
    public static class ServicoDesc
    {
        private static string[] Tipos = new string[5] { "Internet    ",
                                                        "Telefonia   ", 
                                                        "Modem       ",
                                                        "Dados Moveis",
                                                        "Suporte     " };
        private static double[] Valor = new double[5] { 125.50, 150, 160, 75, 100 };
        private static string[] Descricao = new string[5] {"Servico de internet","Servico de telefonia",
        "Instalacao de modem","Plano de dados moveis", "Servico de suporte ao cliente" };
        private static double[] Icms = new double[5] { 8.75, 9.32, 12, 11.20, 9.60 };

        public static string[] tipos { get => Tipos; }
        public static double[] valor { get => Valor; }
        public static string[] descricao { get => Descricao; }
        public static double[] icms { get => Icms; }
    }
}
