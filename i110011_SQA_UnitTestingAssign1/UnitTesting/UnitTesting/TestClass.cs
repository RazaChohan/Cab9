using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestFixture]
    public class TestClass
    {
        [TestCase]
        public void TestCase1()
        {
            DbOperations obj = new DbOperations();
            bool result = obj.AuthenticateUser("Waleed Bin Khalid", "123");
            Assert.AreEqual(true, result);
        }

        [TestCase]
        public void TestCase2()
        {
            DbOperations obj = new DbOperations();
            bool result = obj.AuthenticateUser("Muhammad Raza", "123");
            Assert.AreEqual(false, result);
            
        }
        [TestCase]
        public void TestCase3()
        {
            DbOperations obj = new DbOperations();
            bool result = obj.AuthenticateUser("Hadi Bin Masood", "123");
            Assert.AreEqual(false, result);
        }
        [TestCase]
        public void FareCalculationTest1()
        {
            Fare obj = new Fare();
            int result = obj.CalculateFare("1000");
            Assert.AreEqual(40, result);
        }
        [TestCase]
        public void FareCalculationTest2()
        {
            Fare obj = new Fare();
            int result = obj.CalculateFare("500");
            Assert.AreEqual(20, result);
        }
    }
}
