using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Uppgift2_Josefin
{
    public class MainMenu
    {
        private const string errorMessage = "Wrong input. Try again";
        List<int> groupList = new List<int>();
        List<int> ageList = new List<int>();
        public bool isGroup = true;
        public bool state;

        enum PriceClasses
        {
            youth = 80, senior = 90, regular = 120
        }

        public void RunProgram()
        {

            Console.WriteLine("Välkommen!\nVal:\n0 - Avsluta program\n1 - Pris\n2 - Gruppris\n3 - Multiplicera text\n4 - Plocka ut tredje ordet");
            do
            {
                Console.Write("\nVälj Kommando: ");
                string input = Console.ReadLine();      //körs tills input=0
                state = CheckInput(input);
            } while (state);
        }

        private bool CheckInput(string input)
        {
            bool running = true;
            switch (input)
            {
                case "0":
                    running = false;
                    break;
                case "1":
                    GetAge(1);                  //vid en person
                    break;
                case "2":
                    GetAge(2);                  //Vid sällskap >1
                    break;
                case "3":
                    MultiplyText();
                    break;
                case "4":
                    SplitInput();
                    break;
                default:
                    Console.WriteLine(errorMessage);    //felaktig input - matchar inget menyval
                    break;

            }
            return running;                             //returnerar till state i do-while-loop
        }

        private void GetAge(int menuCase)              //(1 eller 2)
        {
            string priceMessage = "";
            int sum = 0;

            if (menuCase == 1)
            {
                isGroup = false;
            }
            GetGroupSize();
            string instructions;
            foreach (int person in groupList)
            {
                instructions= $"{person}. Ålder: ";                        //Vill skriva ut ålder: men avbryta om första är fel input
                InputChecks.StringInput(instructions);
                if (Int32.TryParse(Console.ReadLine(), out int inputAge))
                {

                    if (0 <= inputAge)
                    {
                        ageList.Add(inputAge);
                    }
                    else { Console.Write("Kan ej ta negativ ålder"); }
                }
                else { Console.Write(errorMessage); }
            }


            //Vill skriva ut ålder: men avbryta om första är fel input

            foreach (int age in ageList)
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
                Console.WriteLine($"Antal personer: {groupList.Count}\nTotalsumma: {sum}");

            }
            else
            {
                Console.WriteLine(priceMessage);
            }

            groupList.Clear();
            ageList.Clear();
            isGroup = true;
        }
        

        private void GetGroupSize()
        {

            if (isGroup)
            {
                Console.Write("Hur många? ");
                int numberOfPeople = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < numberOfPeople; i++)
                {
                    groupList.Add(i + 1);
                }
            }
            else
            {
                groupList.Add(1);
            }
            
            
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

        private void MultiplyText()
        {
            Console.Write("Skriv din text: ");

            TextProp = Console.ReadLine();
            Console.Write($"{TextProp}\n");
        }
        
        private void SplitInput()
        {
            Console.WriteLine("Skriv din mening: ");
            string inputText = Console.ReadLine();
            string[] words = inputText.Split(" ");
            //words.Length > 3 ? Console.WriteLine(words[2]) : Console.WriteLine("Mindre än tre ord!");
        }

        
    }
}