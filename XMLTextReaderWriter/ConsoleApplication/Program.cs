using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlTextReading xmlR = new XmlTextReading();
            xmlR.Read(".\\baum.xml");
            Management.Instance.Print();
            XmlTextWriting xmlW = new XmlTextWriting();
            xmlW.Write(Management.Instance.ParkList, ".\\dest.xml");
            Console.ReadKey();

        }
    }
}
