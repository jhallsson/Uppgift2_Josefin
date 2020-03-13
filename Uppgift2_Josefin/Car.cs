namespace Uppgift2_Josefin
{
    internal class Car                      //klassen, mallen
    {

        //1.
        private string regNo;               

        public string GetRegNo()            //För att nå klassen och dess egenskaper
        {
            //To something
            return regNo;                   
        } 
        
        public void SetRegNo(string regNo)      //För att ändra/sätta klassens egenskaper
        {
            //Validering etc                    //Se till att det är rätt input?
             this.regNo = regNo;
        }

        //2
        private int nr;

        public int Nr                           //Mindre variant
        {
            get { return nr; }
            set { nr = value; }
        }

        //3
        public int Siffra { get; set; }     //Minsta


        public Car(string regNo)            //Klassens konstruktor. Kör alltid det första som görs med programmet
        {
            this.regNo = regNo;             //Ser till att rätt input fåtts
        }

        public Car()                        //default: tillåter att skapa klass-objekt
        {                                   //utan parametrar

        }

    }
}