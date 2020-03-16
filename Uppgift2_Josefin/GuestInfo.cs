using System;
using System.Collections.Generic;

namespace Uppgift2_Josefin
{
    public class GuestInfo
    {
        List<int> group = new List<int>();
        List<int> ages = new List<int>();
        bool isGroup = true;
        enum PriceClasses
        {
            youth = 80, senior = 90, regular = 120
        }
        internal void GetAge(int menuCase)
        {
            string priceMessage = "";      //Händer hela tiden nu? vad gör jag fel?
            int sum = 0;

            if (menuCase == 1)
            {
                isGroup = false;
            }
            GetGroupSize();

            foreach (int person in group)
            {
                Console.Write($"{person}. Ålder: ");
                ages.Add(Convert.ToInt32(Inputs.TakeInput()));

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

            } else
            {
                Console.WriteLine(priceMessage);
            }

            group.Clear();
            ages.Clear();
            isGroup = true;
        }

        internal void SplitInput()
        {
            Console.WriteLine("Skriv din mening: ");
            string inputText = Inputs.TakeInput();
            string[] words = inputText.Split(" ");
            Console.WriteLine(words[2]);
        }

        private string outPutString;
        public string TextProp
        {
            get
            {
                return outPutString;
            }
            set {
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
            
            TextProp = Inputs.TakeInput();
            Console.Write(TextProp);
        }
        private void GetGroupSize()
        {
            if (isGroup)
            {
                Console.Write("Hur många? ");
                int numberOfPeople = Convert.ToInt32(Inputs.TakeInput());
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