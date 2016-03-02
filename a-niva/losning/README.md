# Lösning - nivå A

En elementär lösning som utnyttjar två nästlade ```for```-loopar för att åstadkomma 25 rader med vardera 39 kolumner (asterisker). Indentering av "varannan" rad sker genom att med restoperatorn (%) undersöka om ```row```-värdet är "udda eller jämnt" (dvs. delbart med 2). På samma sätt används rest-värdet för att i ```switch```-satsens villkorsloop sätta stjärnmönstrets olikfärgade rader.
   
Experimentera gärna vidare med dessa verktyg (for, switch, % ...) för att **rita mer avancerade mönster i de användarinteraktiva programmen på B- och C-nivå!**

```c#
using System;

namespace StarsStripesAndDiamonds_A
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Title = "Rita med asterisker - nivå A";

            for (int row = 0; row < 25; row++)
            {
                if (row % 2 == 1)
                {
                    Console.Write(" ");
                }

                switch (row % 3)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;

                    case 1:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                }

                for (int col = 0; col < 39; col++)
                {
                    Console.Write("* ");
                }
                Console.ResetColor();

                Console.WriteLine();
            }
        }
    }
}
```