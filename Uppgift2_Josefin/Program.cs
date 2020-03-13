using System;
using System.ComponentModel.DataAnnotations;

namespace Uppgift2_Josefin
{
    class Program
    {
        static void Main(string[] args)
        {
            //MainMenu menu = new MainMenu();

            //menu.RunProgram();

            Car car = new Car("ABC123");        //deklarerar = instanserar nytt klassobjekt?
                                                //och skickar med värde för regNo som efterfrågas 
                                                //för att kunna skapa objektet (ctrl+shift+mellanslag)
            Car car2 = new Car();               //Eller så får man skapa den utan värde
            car.Nr = 5;
            int n = car.Nr;
            
            
        }
    }
}
