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
