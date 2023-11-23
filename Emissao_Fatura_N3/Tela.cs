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
    }
}
