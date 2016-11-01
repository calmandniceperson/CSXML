/*
 * Author(s): Michael Koeppl
 */

using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            XMLReaderCS.Read("baum.xml");
            //XmlTextReading.Read("baum.xml");
            Management.Instance.Print();
            //XMLWriterCS.Write(Management.Instance.ParkList, "out.xml");
        }
    }
}
