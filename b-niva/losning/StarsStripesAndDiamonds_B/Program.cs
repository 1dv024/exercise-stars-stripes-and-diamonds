using System;

namespace StarsStripesAndDiamonds_B
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
            const string ContinuePrompt = "\nTryck tangent för att fortsätta - Esc avslutar.";

            byte count = 0;

            Console.Title = "Rita med asterisker - nivå B";

            do
            {
                count = ReadOddByte();
                RenderTriangle(count);

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(ContinuePrompt);
                Console.ResetColor();
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static byte ReadOddByte()
        {
            const string ReadOddBytePrompt = "Ange det udda antalet asterisker (max 79) i triangelns bas: ";
            const string ErrorMessage = "\nFEL! Det inmatade värdet är inte ett udda heltal mellan 1 och 79.\n";
            const byte MaxNumberOfAstericks = 79;

            byte value = 0;

            while (true)
            {
                try
                {
                    Console.Write(ReadOddBytePrompt);
                    value = byte.Parse(Console.ReadLine());

                    if (value % 2 != 1 ||
                        value > MaxNumberOfAstericks)
                    {
                        throw new ApplicationException();
                    }
                    return value;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(ErrorMessage, MaxNumberOfAstericks);
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cols"></param>
        private static void RenderTriangle(byte cols)
        {
            Console.WriteLine();

            for (byte row = 0; row < cols; row += 2)
            {
                // Skriver ut inledande mellanslag.
                for (byte whitespace = 0; whitespace < cols - row - 1; whitespace += 2)
                {
                    Console.Write(" ");
                }

                Console.ForegroundColor = ConsoleColor.White;

                // Skriver ut asterisker.
                for (byte asterisk = 0; asterisk <= row; asterisk++)
                {
                    Console.Write("*");
                }

                Console.ResetColor();

                // Radbryter.
                Console.WriteLine();
            }
        }
    }
}
