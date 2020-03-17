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
        public static int IntInput(string instructions)
        {
            bool parseSucces;
            int ageAnswer;
            do
            {
                Console.Write(instructions);                                    //vilket input som eftergfrågas
                parseSucces = Int32.TryParse(Console.ReadLine(), out ageAnswer);   //int omvandling true/false
                if (!parseSucces)                                                    //tryparse=false
                {
                    Console.Write("Must type number\n");

                }
            } while (!parseSucces);                                                  //do så länge tryparse inte funkar
            /*if (ageAnswer <0)
            {
                Console.Write("Kan ej ta negativ ålder"); 
            }*/
            return ageAnswer;                                                   //när tryparse lyckas skickas inputsvaret
        }
    }
}
