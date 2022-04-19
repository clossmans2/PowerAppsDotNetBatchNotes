using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class Day2
    {
        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Log(int msg)
        {
            Console.WriteLine(msg);
        }

        public void Log(double msg)
        {
            Console.WriteLine(msg);
        }

        public void Log(float msg)
        {
            Console.WriteLine(msg);
        }

        public void Log(object msg)
        {
            Console.WriteLine(msg.ToString());
        }

        public void Log(string msg, int logType)
        {
            string[] myArray = new string[] { "Miles", "Seth", "Tom" };
            int[] numberArray = new int[] { 1, 2, 3, 4 };
            
            foreach (var item in myArray)
            {
                Log(item);
                Log(msg);
                Log(logType);
            }
            
            for (int i = 0; i < myArray.Length; i++)
            {
                Log(myArray[i]);
            }



        }
    }
}
