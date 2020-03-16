using System;
using System.Runtime.InteropServices.ComTypes;

namespace Uppgift2_Josefin
{
    public class MainMenu
    {
        Inputs readLine = new Inputs();
        Outputs writeLine = new Outputs();
        GuestInfo guest = new GuestInfo();
        public MainMenu()
        {
           
        }
        public void RunProgram()
        {
            bool state;
            Console.WriteLine("Välkommen!\nVal:\n0 - Avsluta program\n1 - Pris\n2 - Gruppris\n3 - Multiplicera text\n4 - Plocka ut tredje ordet");
            do
            {
                string input = readLine.TakeInput();
                state = CheckInput(input);
            } while (state);
        }
        
        public bool CheckInput(string input)
        {
            bool running = true;
            switch (input)
            {
                case "0": 
                    running=false;
                    break;
                case "1":
                    guest.GetAge(1);
                    break;
                case "2": guest.GetAge(2);
                    break;
                case "3": guest.MultiplyText();
                    break;
                case "4": guest.SplitInput();
                    break;
                default: 
                    Console.WriteLine(errorMessage);
                    break;
                    
            }
            return running;
        }
        private const string errorMessage = "Wrong input. Try again"; //varför måste jag deklarera den längst ner?




    }
}