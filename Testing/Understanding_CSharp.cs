using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    [TestClass]
    public class Understanding_CSharp
    {
        public int MyProperty { get; set; } = 2;
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public class House
        {
            private int floors/*, doors*/;
            private string color/*, type*/;

            public House(int numFloors/*, int doors*/, string houseColor) //Constructor
            {
                floors = numFloors;
                houseColor = color;
            }

            [TestMethod]
            public void BuildHouse()
            {
                House bigYellowHouse = new House(2,5, "yellow");
                Assert.IsTrue(bigYellowHouse.floors == 2);
            }
        }
       

        [TestMethod]
        public void BasicTest()
        {
            Assert.AreNotEqual(1, 2);
        }
        [TestMethod]
        private void WithMethod()
        {
            double x = 0.9, y = 1;
            x += 0.1;
            Assert.AreEqual(y, x);
            Assert.AreEqual(y, x, 0.1);
        }
        [TestMethod]
        internal void PropertyTest()
        {
            Understanding_CSharp test = new Understanding_CSharp();
            test.Name = "Kalle";
            Assert.AreEqual(2, test.MyProperty);
            Assert.AreEqual("Kalle", test.Name);
        }
        
    }
}
