using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift2_Josefin
{
    public static class InputChecks
    {
        

        /*public static string StringInput(string instructions)
        {
            bool validInput = false;
            string inputText = "hej";
            do
            {
                Console.WriteLine(instructions);
                inputText = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputText))
                {
                    validInput = true;
                }

            } while (!validInput);
            return inputText;
        }*/
        public static int IntInput(int inputText)
        {
            bool parseFailed = true;
            do
            {
                if (!Int32.TryParse(Console.ReadLine(), out int inputAge))
                {
                    Console.Write("Must type number");
                }/*else
                {
                    if (0 <= inputAge)
                    {
                        ageList.Add(inputAge);
                    }
                    else { Console.Write("Kan ej ta negativ ålder"); }

                }*/
            } while (parseFailed);
            return inputText;
        }
    }
}
