using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class Day2 {
        public void Log(string msg) {
            Console.WriteLine(msg);
            Console.WriteLine("Some test Code, to be deleted");
        }

        public void Log(int msg) {
            Console.WriteLine(msg);
        }

        public void Log(double msg) {
            Console.WriteLine(msg);
        }

        public void Log(float msg) {
            Console.WriteLine(msg);
            Console.WriteLine("Some test Code, to be deleted");
        }

        public void Log(object msg) {
            Console.WriteLine(msg.ToString());
        }

        public void Log(string msg, int logType) {
            string[] myArray = new string[] { "Miles", "Seth", "Tom" };
            int[] numberArray = new int[] { 1, 2, 3, 4 };

            foreach (var item in myArray) {
                Log(item);
                Log(msg);
                Log(logType);
            }

            for (int i = 0; i < myArray.Length; i++) {
                Log(myArray[i]);
            }

            //passes a reference, anything done to numArray2 will change numberArray and vice-versa
            //int[] numArray2 = numberArray;

            //two ways to copy an array
            int[] numArray2 = new int[numberArray.Length];
            //Array.Copy(numberArray, numArray2, numberArray.Length);
            numberArray.CopyTo(numArray2, 0);
            //numberArray.ToList().ForEach(Console.WriteLine);

            numArray2[0] = 7;
            numArray2[1] = 5;

            int j = 0;
            while (j < numberArray.Length) {
                Console.WriteLine($"numberArray: {numberArray[j]}");
                Console.WriteLine($"numArray2: {numArray2[j]}");
                j++; //j = j + 1
            }
        }

        //objects are pass by ref
        public void ChangeDay1(Day1 item) {
            item.Id = 75;
        }

        //are able to pass primitives as a reference
        //public void WillChange(ref int num) {
        //    num = 75;
        //}

        //primitives are pass by value
        public void WontChange(int num) {
            num = 75;
        }
    }
}
