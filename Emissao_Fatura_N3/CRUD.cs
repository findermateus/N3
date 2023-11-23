using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emissao_Fatura_N3
{
    public static class CRUD
    {

        public static void EscreveMenuOp(List<string> menu, int posy,string texto)
        {
            Tela.DesenhaBorda(0, 0, menu[0].Length + 1, menu.Count + 1, texto);
            for (int i = 0; i < menu.Count; i++)
            {
                Console.SetCursorPosition(1, posy + i);
                Console.WriteLine(menu[i]);
                Console.SetCursorPosition(1, posy + i);
            }

            Console.SetCursorPosition(menu[menu.Count - 1].Length, menu.Count);
        }
    }
}
