using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Uppgift2_Josefin
{
    public class MainMenu
    {
        private const string errorMessage = "Wrong input. Try again";
        List<int> groupList = new List<int>();      //private default
        List<int> ageList = new List<int>();
        public bool isGroup = true;             //kapsla in beteenden, privetisera 
        public bool state;                  //behöver inte vara global används bara i runprogram
                                            //ska inte användas utanför
        enum PriceClasses                   //private default? kan ligga i egen fil (men här används bara i mainmenu)
        {                                   //ligger som egen "klass", inte i klass
            youth = 80, senior = 90, regular = 120
        }

        public void RunProgram()        //bra
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
                case "1":                       //byt metodnamn ex bool company, ta bort isgroup, skippa magisk siffra
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
            int inputAge;
            foreach (int person in groupList)
            {
                instructions= $"{person}. Ålder: ";                        //Vill skriva ut ålder: men avbryta om första är fel input
                inputAge= InputChecks.IntInput(instructions);               //returnerar input som är parsed
                                                                            //if (Int32.TryParse(Console.ReadLine(), out int inputAge))
                                                                            //{

                //if (0 <= inputAge)
                //{
                    ageList.Add(inputAge);
                //}
                //else { Console.Write("Kan ej ta negativ ålder"); }
                
            }

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
        
        private void GetGroupSize()     //bryt ut logik för uträkning av priser sen kalla på groupsize
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
        public string TextProp              //hur man hanterar innehållet innanför och utanför klass
        {                                   //textprop metod istället när det används i samma klass
            get                             //klass-hus property-dörr (kommer in i klassen/byter dörren)
            {
                return outPutString;        //isf deklarera i 
            }
            set
            {
                if (!String.IsNullOrEmpty(value))       //metodanrop med värde ist och returnera ex. string
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int n = i + 1;
                        outPutString += ($"{n}.{value} "); //vill inte skapa ny string i varje loopning "immutable string"
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
            string s = words.Length > 3 ? words[2] : "Mindre än tre ord!"; //båda val måste vara sträng/int/annat/samma
            Console.WriteLine(s);
        }   
        //måste få tillbaka ett resultat 
        //returnera två strängvärden
    }
}