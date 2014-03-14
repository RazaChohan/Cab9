using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _110012_SQA_Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string location = null;
            locateMeGps locateMeGpsObj = new locateMeGps();
            location = locateMeGpsObj.CoordinatesToLocation(24.8600f, 67.0100f);
            Console.WriteLine("Main function Result: " +location);
            Console.ReadKey();

        }
    }
}
