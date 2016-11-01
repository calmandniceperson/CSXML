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
            Management.Instance.Print();
        }
    }
}
