using System;
using System.Collections.Generic;

namespace Uppgift2_Josefin
{
    internal class GuestInfo
    {
        enum PriceClasses
        {
            youth = 80, senior = 90, regular = 120
        }
        Inputs Line = new Inputs();
        List<int> group = new List<int>();
        List<int> ages = new List<int>();
        bool isGroup = true;
        internal void GetAge(int menuCase)
        {
            string priceMessage="";                 //Händer hela tiden nu? vad gör jag fel?
            int sum=0;
            

            if (menuCase == 1)
            {
                isGroup = false;
            }
            GetGroupSize();

            foreach (int person in group)
            {
                Console.Write($"{person}. Ålder: ");
                ages.Add(Convert.ToInt32(Line.TakeInput()));
              
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
                //sum = 0;              //funkar inte
            }else
            {
                Console.WriteLine(priceMessage);
            }
            //isGroup?  Console.WriteLine(sum): Console.WriteLine(priceMessage); //???

            group.Clear();
            ages.Clear();
            //sum = 0;          //Lägger bara på summan ändå? Vart?

        }

        private void GetGroupSize()
        {
            if (isGroup)
            {
                Console.Write("Hur många? ");
                int numberOfPeople = Convert.ToInt32(Line.TakeInput());
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