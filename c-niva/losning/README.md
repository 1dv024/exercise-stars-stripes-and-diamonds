# Lösning - nivå C

Även denna lösning har sina brister, men är konceptuellt mer generaliserad och renodlad än på A- och B-nivå. Programklassens fyra privata statiska metoder hanterar sinsemellan logiskt avgränsade uppgifter, för att så långt möjligt stödja den objektorienterade principen om *"Separation of concerns"*. Även här framhåller vi dess vikt för att skapa **förståbar**, **skalbar** och **återanvändbar** programkod. 

Även om förutsättningarna för detta program är detaljerat beskrivna, så bör redan en titt på klassdiagrammet ge en intuitiv bild av programmets design avseende ansvarsfördelning för olika typer av programlogik. Ansvaret för programmets s.k. affärslogik (att rita ut diamanter) har lagts i en övergripande modul,  ```RenderDiamond```, som samverkar med en underordnad sådan, ```RenderRow```, för  presentation i aktuellt gränssnitt (utritning i konsollen). Interaktion med användaren har fördelats i två metoder för input-logik, dels en för inläsning och validering av data, ```ReadOddByte```, dels ```IsContinuing```, med vars hjälp ```Main```-metoden styr programkörningen. **Anser du att någon alternativ design, avseende såväl medlemsvariabler som medlemsmetoder kunde varit mera lämplig?** 

Åtkomstmodifieraren ```private``` stödjer OOP-principen om *inkapsling*, vilken framförallt är viktig för klassens möjlighet att skydda data (medlemsvariabler/attribut) som den eventuellt förfogar över. Så är inte fallet i just denna uppgift, men **vilken datamedlem skulle kunna vara aktuell i en alternativ lösning enligt frågan ovan? Hur borde denna i så fall definieras?** 

Denna programlösning har fortfarande en stark koppling till konsoll-miljön i alla medlemsmetoder. Metoden ```IsContinuing``` avlastar dock programmet från en större mängd utskriftskod, vilket gör lösningen mer koncis och enklare att överblicka. Den största vinsten är dock användningen av en separat resursfil för programmets alla strängkonstanter (text-meddelanden). Detta bidrar inte bara till en renare programkod, utan erbjuder också  större flexibilitet angående språkval, då flera resursfiler ger möjlighet till enkelt byte av språk enligt användarens behov. **Hur skulle aktuell lösning för övrigt behöva förändras, för att t.ex. möjliggöra en engelskspråkig applikation?**

Liksom i föregående B-lösning finns stora brister i programmets dokumentation, som framförallt är ofullständig avseende de xml-kommentarer ("summary") som alltid ska finnas till klassdefinitionen och dess medlemmar. Vi hoppas att du i detta avseende "gör om och gör bättre" än vårt slarv. **Hur ser du på rådet att alltid dokumentera din kod på engelska?**

Läs mer om hur **xml-kommentarer** (se format i lösningen nedan) kan underlätta livet i Visual Studio-editorn med löpande kod-tips medan du arbetar! Eller hur du automatgenererar din välskrivna XML-dokumentation till en separat xml-fil:  

+ Essential C# 6.0, 414-418.

```c#
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
