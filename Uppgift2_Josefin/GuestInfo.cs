using System;
using System.Collections.Generic;

namespace Uppgift2_Josefin
{
    internal class GuestInfo
    {
        Inputs Line = new Inputs();
        List<int> group = new List<int>();
        List<int> ages = new List<int>();
        internal void GetAge()
        {
            
            //string priceMessage;
            GetCompany();

            foreach (int person in group)
            {
                Console.Write($"{person}. Please write your age: ");
                ages.Add(Convert.ToInt32(Line.TakeInput()));
                //Console.WriteLine(person);
            }
            
            //Console.Write("Please write your age: ");
            //int age = Convert.ToInt32(Line.TakeInput());
            //if (age < 20)
            //{
            //    priceMessage = "Ungdomspris: 80kr";
            //}
            //else if (age > 64)
            //{
            //    priceMessage = "Pensionärspris: 90kr";
            //}
            //else
            //{
            //    priceMessage = "Standardpris: 120kr";
            //}
            //Console.WriteLine(priceMessage);
           
            
            
        }

        private void GetCompany()
        {
            
            Console.Write("How many? ");
            int numberOfPeople = Convert.ToInt32(Line.TakeInput());
            for (int i = 0; i < numberOfPeople; i++)
            {
                group.Add(i + 1);
            }
            
        }
    }
}