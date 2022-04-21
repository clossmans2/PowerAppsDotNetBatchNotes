using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Threads {
    public class BreakfastAsync {
        public static async Task MakeBreakfast() {
            //in this case inefficient because the food/ the coffee would be cold
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0) {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask) {
                    Console.WriteLine("eggs are ready");
                } else if (finishedTask == baconTask) {
                    Console.WriteLine("bacon is ready");
                } else if (finishedTask == toastTask) {
                    Console.WriteLine("toast is ready");
                }
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        private static Juice PourOJ() {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) {
            Console.WriteLine("Putting jam on the toast");
        }

        private static void ApplyButter(Toast toast) {
            Console.WriteLine("Putting butter on the toast");
        }

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int number) {
            Toast toast = new Toast();

            //how you would catch an exception and fail gracefully
            try {
                toast = await ToastBreadAsync(number);
            } catch (Exception e) {
                Console.WriteLine("Caught the fire");
                Console.WriteLine("{0}:\n {1}", e.GetType().Name, e.Message);
            }

            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static async Task<Toast> ToastBreadAsync(int slices) {
            for (int slice = 0; slice < slices; slice++) {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting....");

            //does not automatically stop execution
            //Console.WriteLine("Fire! Toast is ruined!");
            //throw new InvalidOperationException("The toaster is on fire!");

            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices) {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++) {
                Console.WriteLine("flipping a slice of bacon");
            }

            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany) {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee() {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        //this is an eample of catching aggregate exceptions thrown in tasks
        public static void ExecuteErrors() {
            try {
                ExecuteTasks();
            } catch (AggregateException ae) {
                foreach (var e in ae.InnerExceptions) {
                    Console.WriteLine("{0}:\n   {1}", e.GetType().Name, e.Message);
                }
            }
        }

        //the tasks are errors to demonstrate the point
        private static void ExecuteTasks() {
            List<Task> tasks = new List<Task>();

            tasks.Add(Task.Run(() => {
                throw new ArgumentException("The system root is not a valid path.");
            }));

            tasks.Add(Task.Run(() => {
                throw new NotImplementedException("This operation has not been implemented.");
            }));

            try {
                Task.WaitAll(tasks.ToArray());
            } catch (AggregateException ae) {
                throw ae.Flatten();
            }
        }

        private class Juice { }
        private class Toast { }
        private class Bacon { }
        private class Egg { }
        private class Coffee { }
    }
}
