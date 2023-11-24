using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emissao_Fatura_N3
{
    public class Tela
    {
        public static void DesenhaBorda(int x1, int y1, int x2, int y2,string texto)
        {
            
            Console.SetCursorPosition(x1,y1);
            Console.Write("+");
            Console.SetCursorPosition(x2, y1);
            Console.Write("+");
            Console.SetCursorPosition(x1, y2);
            Console.Write("+");
            Console.SetCursorPosition(x2, y2);
            Console.Write("+");
            for (int i = 1; i < x2; i++)
            {
                Console.SetCursorPosition(i, y1);
                Console.Write("-");
                Console.SetCursorPosition(i, y2);
                Console.Write("-");
            }
            for(int i = 1; i < y2; i++)
            {
                Console.SetCursorPosition(x1,i);
                Console.Write("|");
                Console.SetCursorPosition(x2,i);
                Console.Write("|");
            }
            Console.SetCursorPosition((x2 / 2) - (texto.Length / 2), y1);
            Console.WriteLine(texto);
        }
        public static void EscreveMenuOp(List<string> menu, int posy, string texto)
        {
            Tela.DesenhaBorda(0, posy - 1, menu[0].Length + 1, menu.Count + 1, texto);
            for (int i = 0; i < menu.Count; i++)
            {
                Console.SetCursorPosition(1, posy + i);
                Console.WriteLine(menu[i]);
                Console.SetCursorPosition(1, posy + i);
            }

            Console.SetCursorPosition(menu[menu.Count - 1].Length + 1, menu.Count);
        }
        public static void EscreveMenu(List<string> menu, int posx, int posy)
        {
            foreach (string texto in menu)
            {
                Console.SetCursorPosition(posx, posy);
                Console.Write(texto);
                posy++;
            }
        }
    }
}
