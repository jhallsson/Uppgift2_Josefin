using System;

namespace Uppgift2_Josefin
{
    
    public static class Inputs
    {
        private const string errorMessage = "Wrong input. Try again"; 
        static GuestInfo guest = new GuestInfo();

        public static string TakeInput()
        {
            return Console.ReadLine();
        }
        public static bool CheckInput(string input)
        {
            bool running = true;
            switch (input)
            {
                case "0":
                    running = false;
                    break;
                case "1":
                    guest.GetAge(1);
                    break;
                case "2":
                    guest.GetAge(2);
                    break;
                case "3":
                    guest.MultiplyText();
                    break;
                case "4":
                    guest.SplitInput();
                    break;
                default:
                    Console.WriteLine(errorMessage);
                    break;
            }
            return running;
        }
    }
}