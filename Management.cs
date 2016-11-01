/*
 * Author(s): Michael Koeppl
 */

using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    // Class Management implemented as Singleton.
    public class Management
    {
        private static Management instance;
        private Management() {
            this.ParkList = new List<Park>();
        }
        
        public static Management Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Management();
                }
                return instance;
            }
        }
        
        public List<Park> ParkList { get; }
        
        public void Print()
        {
            ParkList.ForEach( x => { Console.WriteLine(x.ToString()); });
        }
    }
}