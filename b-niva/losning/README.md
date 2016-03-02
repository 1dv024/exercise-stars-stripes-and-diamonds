# Lösning - nivå B

Programlogiken är här strukturerad i mindre moduler för logiskt avgränsade syften - i form av tre statiska medlemsmetoder i Programklassen. *"Separation of concerns"* är en viktig objektorienterad princip att följa för att skapa **förståbar**, **skalbar** och **återanvändbar** programkod. Att applicera åtkomstmodifieraren ```private``` på klassmedlemmarna följer en annan viktig OOP-princip kallad *inkapsling*, vilket innebär att klassen själv styr åtkomst för sin funktionalitet (medlemsmetoder) eller data (medlemsvariabler) som den eventuellt förfogar över. **Anser du att något attribut (data) skulle varit lämpligt att förse klassen med, och hur definieras i så fall detta lämpligast i klassen?**

Denna lösning, som är något mer flexibel än A-nivåns statiska program, erbjuder viss användarinteraktion. För både programmerare och användare är *användarvänliga* program eftersträvansvärda. För användarens del innebär detta hög felsäkerhet och tydlig information med såväl **_rätt_**- som **_fel_**-meddelanden. Felhanteringen bör vara heltäckande och den kommunikation som sker med användaren bör förstås vara så utformad att denne har en chans att förstå både vad som inträffat och vad som behöver göras för att avhjälpa felet. **Är aktuell programlösning tillfredställande i detta avseende?**

Undantagshantering är en kraftfull mekanism som förenklar livet för både användare och programmerare. En likformig och väl genomtänkt strategi för felhanteringen underlättar framförallt för programmeraren, då felsökning och underhåll av programvara är en stor del av dennes vardag. **Hur skulle felhanteringen kunna utvecklas i just denna lösning?**

Inom OOP är kodens förståbarhet en viktig kvalitetsfråga, men brister finns i programmets ofullständiga dokumentation, framförallt avseende de summerande xml-kommentarer som alltid bör dokumentera klassdefinitionen och dess medlemmar. Vi har slarvat, men hoppas att du i detta avseende **"gör om, gör bättre"!**

Programmets ```const```-användning gynnar felsäkerheten liksom det underlättar underhåll och utveckling av programvaran. Men här finns även onödiga beroenden som försvårar detsamma ... Förutom en hel del redundant utskriftskod, som bryter mot principen DRY (Don't Repeat Yourself), så finns också detaljer som hindrar en _enkel återanvändning_ av koden i annan miljö, exempelvis en webbaserad eller flerspråkig sådan. **Vilka problem kan du identifiera och vilka lösningar ser du på dem?** 

Ja, som synes finns mer att göra för att bättre uppfylla goda "OOP"-principer...   
**Lös uppgiften på C-nivå för att åstadkomma ett mer plattforms- och språk-oberoende program!**

```c#
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
```