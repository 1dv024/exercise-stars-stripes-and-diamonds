using System;

namespace StarsStripesAndDiamonds_C
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
            const byte MaxNumberOfAstericks = 79;

            byte count = 0;

            Console.Title = "Rita med asterisker - nivå C";

            do
            {
                Console.Clear();
                count = ReadOddByte(Strings.ReadOddByte_Prompt, MaxNumberOfAstericks);
                RenderDiamond(count);
            } while (IsContinuing());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static bool IsContinuing()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Strings.Continue_Prompt);
            Console.ResetColor();
            bool result = Console.ReadKey().Key != ConsoleKey.Escape;
            Console.CursorVisible = true;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        private static byte ReadOddByte(string prompt = null, byte maxValue = 255)
        {
            byte value = 0;

            while (true)
            {
                try
                {
                    if (!String.IsNullOrWhiteSpace(prompt))
                    {
                        Console.Write(prompt, maxValue);
                    }

                    Console.ForegroundColor = ConsoleColor.White;

                    value = byte.Parse(Console.ReadLine());

                    if (value % 2 != 1 ||
                        value > maxValue)
                    {
                        throw new ApplicationException();
                    }
                    return value;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(Strings.Error_Message, maxValue);
                }
                finally
                {
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxCount"></param>
        private static void RenderDiamond(byte maxCount)
        {
            Console.WriteLine();

            // Skriver ut toppen.
            for (int row = 0; row < maxCount; row += 2)
            {
                RenderRow(maxCount, row);
            }

            // Skriver ut botten. Genom att minska antalet rader (kolumner) med 3 
            // "maskas" mittenraden som redan skrivits ut, och samma metod som
            // ovan kan användas för att skriva ut en rad.
            for (int row = maxCount - 3; row >= 0; row -= 2)
            {
                RenderRow(maxCount, row);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxCount"></param>
        /// <param name="asteriskCount"></param>
        private static void RenderRow(int maxCount, int asteriskCount)
        {
            // Skriver ut inledande mellanslag.
            for (int whitespace = 0; whitespace < maxCount - asteriskCount - 1; whitespace += 2)
            {
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;

            // Skriver ut asterisker.
            for (int asterisk = 0; asterisk <= asteriskCount; asterisk++)
            {
                Console.Write("*");
            }

            Console.ResetColor();

            // Radbryter.
            Console.WriteLine();
        }
    }
}
