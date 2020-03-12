using System;
using System.Runtime.InteropServices.ComTypes;

namespace Uppgift2_Josefin
{
    public class MainMenu
    {
        Inputs readLine = new Inputs();
        GuestInfo guest = new GuestInfo();
        public MainMenu()
        {
           
        }
        public void RunProgram()
        {
            
            
            bool state;
            Console.WriteLine("Welcome!\nPlease choose an action:\n0 - Quit program\n1 - Age");
            do
            {
                //Console.WriteLine(errorMessage);
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
                    
                    guest.GetAge();
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