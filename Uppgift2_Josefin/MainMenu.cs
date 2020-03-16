using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Uppgift2_Josefin
{
    public class MainMenu
    {
        private const string errorMessage = "Wrong input. Try again";
        List<int> group = new List<int>();
        List<int> ages = new List<int>();
        bool isGroup = true;

        enum PriceClasses
        {
            youth = 80, senior = 90, regular = 120
        }

        public void RunProgram()
        {
            bool state;
            Console.WriteLine("Välkommen!\nVal:\n0 - Avsluta program\n1 - Pris\n2 - Gruppris\n3 - Multiplicera text\n4 - Plocka ut tredje ordet");
            do
            {
                string input = Console.ReadLine();
                state = CheckInput(input);
            } while (state);
        }
        
        public bool CheckInput(string input)
        {
            bool running = true;
            switch (input)
            {
                case "0":
                    running = false;
                    break;
                case "1":
                    GetAge(1);
                    break;
                case "2":
                    GetAge(2);
                    break;
                case "3":
                    MultiplyText();
                    break;
                case "4":
                    SplitInput();
                    break;
                default:
                    Console.WriteLine(errorMessage);
                    break;

            }
            return running;
        }
        internal void SplitInput()
        {
            Console.WriteLine("Skriv din mening: ");
            string inputText = Console.ReadLine();
            string[] words = inputText.Split(" ");
            Console.WriteLine(words[2]);
        }
        
        internal void GetAge(int menuCase)
        {
            string priceMessage = "";      
            int sum = 0;

            if (menuCase == 1)
            {
                isGroup = false;
            }
            GetGroupSize();

            foreach (int person in group)
            {
                Console.Write($"{person}. Ålder: ");
                ages.Add(Convert.ToInt32(Console.ReadLine()));

            }
            foreach (int age in ages)
            {
                if (age < 20)
                {
                    priceMessage = "Ungdomspris: 80kr";             //KOLLA UPP om jag vill skriva ut ages + string?
                    sum += Convert.ToInt32(PriceClasses.youth);
                }
                else if (age > 64)
                {
                    priceMessage = "Pensionärspris: 90kr";
                    sum += Convert.ToInt32(PriceClasses.senior);
                }
                else
                {
                    priceMessage = "Standardpris: 120kr";
                    sum += Convert.ToInt32(PriceClasses.regular);
                }

            }

            if (isGroup)
            {
                Console.WriteLine($"Antal personer: {group.Count}\nTotalsumma: {sum}");

            }
            else
            {
                Console.WriteLine(priceMessage);
            }

            group.Clear();
            ages.Clear();
            isGroup = true;
        }

        private string outPutString;
        public string TextProp
        {
            get
            {
                return outPutString;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int n = i + 1;
                        outPutString += ($"{n}.{value} ");
                    }
                }
            }
        }
        public void MultiplyText()
        {
            Console.Write("Skriv din text: ");

            TextProp = Console.ReadLine();
            Console.Write(TextProp);
        }
        private void GetGroupSize()
        {
            if (isGroup)
            {
                Console.Write("Hur många? ");
                int numberOfPeople = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < numberOfPeople; i++)
                {
                    group.Add(i + 1);
                }
            }
            else
            {
                group.Add(1);
            }


        }
    }
}