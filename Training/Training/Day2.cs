using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class Day2
    {

        // Method overloading
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
                //Log(item);
                //Log(msg);
                //Log(logType);
            }
            
            for (int i = 0; i < myArray.Length; i++)
            {
                //Log(myArray[i]);
                myArray.ToList().ForEach(item => Log(msg));
            }
            

            string[] arr = { "Apple", "Banana", "Orange" };

            int[,] arr2 = { { 1, 2 }, { 2, 3 }, { 3, 4 }, { 4, 5 } };
            List<int> arr3 = arr2.Cast<int>().ToList();
            arr3.ForEach(Console.WriteLine);

            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    Log(arr2[i,j]);
                }
            }
        }

        public void DoWhile()
        {
            int i = 0;
            do
            {
                Console.WriteLine("Happens before the while check and then again after");
                i += 1;
                ++i;
                --i;
                i++;
            }
            while (i < 10);
        }


        // If Else
        public void IfExample(int numberToCheck)
        {
            if (numberToCheck < 0)
            {

            }
            else if (numberToCheck < 10)
            {

            }
            else
            {

            }

        }


        // Case Switch Break Default Example
        public string CaseSwitchExample(int testNum)
        {
            
            string retVal = "";

            try
            {
                switch (testNum)
                {
                    case 1:
                        throw new ArgumentException();
                        break;

                    case 2:
                        retVal = "Two";
                        break;

                    default:
                        retVal = "Zero";
                        break;
                }
            }
            catch (NullReferenceException ex)
            {
                Log($"A null reference exception occured {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Log($"A argument null exception occured: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log($"An exception occured outside of the types specified {ex.Message}");
            }
            finally
            {
                Log("Finally step ran");
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            return retVal;

            
        }

        // Throw
        public void ThrowExample(int testNum)
        {
            if (testNum < 0)
            {
                throw new Exception("You did something wrong!");
            }
        }

        // Custom Exceptions
        // Here be dragons
        public class MyCustomException : Exception
        {
            public MyCustomException(string msg) : base(msg)
            {

            }
        }
    }
}
