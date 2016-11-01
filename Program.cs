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
            //Read Köppl
            XMLReaderCS.Read("baum.xml");
            //Read Poul
            //XmlTextReading.Read("baum.xml");
            //Allgemeines Printen des Eingelesenen
            Management.Instance.Print();
            //Write Köppl
            XMLWriterCS.Write(Management.Instance.ParkList, "out.xml");
        }
    }
}
