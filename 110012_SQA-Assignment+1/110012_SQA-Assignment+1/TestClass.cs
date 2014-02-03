using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _110012_SQA_Assignment_1
{
    [TestFixture]
    class TestClass
    {
        public string location=null;
        [TestCase]
        public void IsbCoordinatesCodeTest()
        {
            string chk = "Nazim-ud-din Road, F-7/4, Blue Area, Islamabad, Pakistan, \n";
            locateMeGps locateMeGpsObj=new locateMeGps();
            location = locateMeGpsObj.CoordinatesToLocation(33.7167f, 73.0667f);
            Assert.AreEqual(chk,location);
        }

        [TestCase]
        public void LhrCoordinatesCodeTest()
        {
            string chk = "Mall Road, Lahore, Pakistan, \n";
            locateMeGps locateMeGpsObj = new locateMeGps();
            location = locateMeGpsObj.CoordinatesToLocation(31.5497f, 74.3436f);
            Assert.AreEqual(chk, location);
        }

        [TestCase]
        public void KarachiCoordinatesTest()
        {
            string chk = "Princes Street, Saddar Town, Karachi, Pakistan, \n";
            locateMeGps locateMeGpsObj = new locateMeGps();
            location = locateMeGpsObj.CoordinatesToLocation(24.8600f, 67.0100f);
            Assert.AreEqual(chk, location);
        }

    }
}
