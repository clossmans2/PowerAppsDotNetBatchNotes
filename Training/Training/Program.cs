using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

using System;
using System.Collections;
using System.Collections.Generic;
//using System.Configuration;
using Training.Data;
using Training.Threads;

namespace Training {
    public class Program
    {
        /* 
            
        This is a mult-line comment

        The compiler ignores comments

         */
        public const string constName = "Dan Pickles";
        public static string staticName = "Seth";
        public string myName = "Miles"; //cannot access inside of a static method

        //comment
        //this is your main class
        public static void Main(string[] args) {
            //Console.WriteLine("Hello World!");

            //Day1Examples();
            //Day2Examples();
            //Day3Examples();
            //Day3Sorting();
            //Day3FileExamples d3 = new Day3FileExamples();
            //var data = d3.ReadCsvData();
            //foreach(var item in data) {
            //    Console.WriteLine(item.ToString());
            //}
            //var charInput = Console.Read();
            ////Console.WriteLine($"You pressed: {charInput}");
            ////Console.WriteLine("Type something");
            //var lineInput = Console.ReadLine();
            ////Console.WriteLine($"You said: {lineInput}");
            //var keyInput = Console.ReadKey();
            //Console.WriteLine("Press any key to continue...");
            //var appConfUsername = ConfigurationManager.AppSettings["UserName"];
            //var appConfPassword = ConfigurationManager.AppSettings["Password"];
            //Console.WriteLine($"My username is {appConfUsername} and my password is {appConfPassword}");

            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: false);

            //IConfiguration configuration = builder.Build();
            //var connString = configuration.GetSection("ConfigurationSetting").Get<ConfigurationSetting>();
            //Console.WriteLine(connString.ConnString);

            //Day4Singleton();
            //Day4Examples();

            //Day4Threading();
            Day4ProducerConsumer();

            //Console.ReadLine();
        }

        //issues can come up such as not enough producers, not enough consumers, etc. 
        //other common concurrency issues are the dining philosophers, or santa's workshop
        public static void Day4ProducerConsumer() {
            Random random = new Random();
            ProducerConsumer pcExample = new ProducerConsumer();

            Thread producer1 = new Thread(() => {
                    int val = random.Next(20, 51);

                    for (int i = 0; i < 5; i++) {
                        pcExample.AddProduce(val);
                        Thread.Sleep(1000);
                    }
                });

            Thread producer2 = new Thread(() => {
                    int val = random.Next(20, 51);

                    for (int i = 0; i < 5; i++) {
                        pcExample.AddProduce(val);
                        Thread.Sleep(1000);
                    }
                });

            Thread consumer1 = new Thread(() => {
                    int val = random.Next(40, 71);

                    for (int i = 0; i < 5; i++) {
                        pcExample.ConsumeProduce(val);
                        Thread.Sleep(1000);
                    }
                });

            Thread consumer2 = new Thread(() => {
                    int val = random.Next(40, 71);

                    for (int i = 0; i < 5; i++) {
                        pcExample.ConsumeProduce(val);
                        Thread.Sleep(1000);
                    }
                });

            producer1.Start();
            producer2.Start();
            consumer1.Start();
            consumer2.Start();

            producer1.Join();
            producer2.Join();
            consumer1.Join();
            consumer2.Join();
        }

        public static void Day4Threading() {
            Console.WriteLine("Now on to threads");
            //original singleton is not thread safe

            //can be run in multiple ways
            //one way:
            //Thread t1 = new Thread(new ThreadStart(Method));
            //easier way:
            //hand it a lambda function
            //Thread t1 = new Thread(() => { code });
            //lambda syntax () => ... is the same as
            //void AnonymousMethod() {
            //    SomeOtherMethod(parameters);
            //}
            
            Thread thread1 = new Thread(() => Console.WriteLine("Singleton: " + MySingleton2.Instance.GetHashCode()));
            Thread thread2 = new Thread(() => Console.WriteLine("Singleton: " + MySingleton2.Instance.GetHashCode()));
            Thread thread3 = new Thread(() => Console.WriteLine("Singleton: " + MySingleton2.Instance.GetHashCode()));

            //how you start a thread
            thread1.Start();
            thread2.Start();
            thread3.Start();

            //also have to collect the threads when they finish
            thread1.Join();
            thread2.Join();
            thread3.Join();

            BankAccount act1 = new BankAccount(100);
            BankAccount act2 = new BankAccount(100);
            BankAccount act3 = new BankAccount(100);
            Person p1 = new Person("Dan Pickles", act1);
            Person p2 = new Person("Ann Pickles", act1);
            Person p3 = new Person("John Doe", act2);
            Person p4 = new Person("Bruce Wayne", act3);
            Person p5 = new Person("Alfred", act3);
            Dog dog = new Dog("Sparky", "Golden", true);
            Dog dog2 = new Dog("Fiddo", "Grey", true);
            Random rand = new Random();
            List<Thread> tasks = new List<Thread>();

            Thread t1 = new Thread(() => ManageAccount(p1, rand));
            tasks.Add(t1);
            Thread t2 = new Thread(() => ManageAccount(p2, rand));
            tasks.Add(t2);
            Thread t3 = new Thread(() => ManageAccount(p3, rand));
            tasks.Add(t3);
            Thread t4 = new Thread(() => ManageAccount(p4, rand));
            tasks.Add(t4);
            Thread t5 = new Thread(() => {
                    //can also type code directly into the lambda
                    for (int i = 0; i < 4; i++) {
                        //random values between 40 and 60
                        double val = rand.NextDouble() * (60 - 40) + 40;
                        p5.Add(val);
                        Thread.Sleep(2000);
                        val = rand.NextDouble() * (60 - 40) + 40;
                        p5.Withdraw(val);
                    }
                });
            tasks.Add(t5);
            Thread t6 = new Thread(dog.ThreadTest);
            tasks.Add(t6);
            Thread t7 = new Thread(dog2.ThreadTest);
            tasks.Add(t7);

            foreach (Thread t in tasks) {
                t.Start();
            }

            foreach (Thread th in tasks) {
                th.Join();
            }

            Console.WriteLine("All Threads are finished");

            Thread newThread = new Thread(() => { Thread.Sleep(1200000000); });

            newThread.Start();

            newThread.Interrupt();
            Console.WriteLine("Thread interrupted");

            newThread.Join();
        }

        public static void ManageAccount(Person p, Random rando) {
            for (int i = 0; i < 4; i++) {
                //random values between 40 and 60
                double val = rando.NextDouble() * (60 - 40) + 40;
                p.Add(val);
                Thread.Sleep(2000);
                val = rando.NextDouble() * (60 - 40) + 40;
                p.Withdraw(val);
            }
        }

        public static async void Day4Examples() {
            await BreakfastAsync.MakeBreakfast();

            //to show catching async errors
            //cannot await void, because it does not return anything
            Console.WriteLine("Async Errors");
            BreakfastAsync.ExecuteErrors();
        }

        public static void Day4Singleton() {
            Console.WriteLine("Singleton: " + MySingleton.Instance.GetHashCode());
            Console.WriteLine("Singleton: " + MySingleton.Instance.GetHashCode());
            Console.WriteLine("Singleton: " + MySingleton.Instance.GetHashCode());
        }

        public struct Day3Struct {
            //public int id { get; init; }
            //public string name { get; init; }
            public int id;
            public string name;
            private string otherName;
            private List<string> colors;

            public Day3Struct(int id, string name) {
                this.id = id;
                this.name = name;
                this.otherName = name;
                colors = new List<string>();
            }

            public void AddId(int num) {
                this.id += num;
            }

            public void AddColor(string color) {
                colors.Add(color);
            }

            public void Print() {
                foreach (string color in colors) {
                    Console.WriteLine(color);
                }
            }
        }

        public static void WontChange(Day3Struct mystruct) {
            mystruct.id = 75;
        }

        public static void Day3Examples() {
            Day3Struct testStruct = new Day3Struct(1, "Joe");
            Day3Struct testStruct2 = testStruct with { name = "Test", id = 4 };

            Console.WriteLine(testStruct.id);
            WontChange(testStruct);
            Console.WriteLine(testStruct2.id);

            testStruct.AddColor("blue");
            testStruct.AddColor("red");

            testStruct.Print();

            //Day2 newDay2 = new Day2();
            //newDay2.name = "My New Name";

            //access an inner class, by going through the parent class
            //Day3<int>.Node myNode = new Day3<int>.Node(3);

            Day3<int> userList1 = new Day3<int>();
            Day3<string> userList2 = new Day3<string>();

            userList1.AddHead(1);
            userList1.AddHead(2);
            userList1.AddHead(3);

            userList2.AddHead("One");
            userList2.AddHead("Two");
            userList2.AddHead("Three");

            userList1.Print();
            userList2.Print();

            Console.WriteLine($"Second elemnt: {userList1.Get(1)}");
            Console.WriteLine($"Second elemnt: {userList2.Get(1)}");
        }

        public static void Day3Sorting() {
            Dog dog = new Dog("Test Dog", "Black", true);

            //uses tostring by default
            Console.WriteLine(dog);
            Console.WriteLine(dog.ToString());

            List<Dog> dogList = new List<Dog>();
            dogList.Add(new Dog("Princess", "Orange", true));
            dogList.Add(new Dog("Bob", "Blue", true));
            dogList.Add(new Dog("Mark", "Black", false));

            List<Dog> dogList2 = new List<Dog>(dogList);

            Console.WriteLine($"[{String.Join(", ", dogList)}]");
            Console.WriteLine($"[{String.Join(", ", dogList2)}]");
            dogList.Sort();
            dogList2.Sort(new DogComparer());
            Console.WriteLine($"[{String.Join(", ", dogList)}]");
            Console.WriteLine($"[{String.Join(", ", dogList2)}]");
        }

        public static void Day2Examples() {
            var day2 = new Day2();
            day2.Log("My message");
            day2.Log("My new message", 145);

            //C# is pass by ref for objects and pass by value for primitives
            Day1 testItem = new Day1(3, "Test");

            //passes a reference or pointer to the object into the method
            //this has side-effects
            Console.WriteLine($"Starting ID: {testItem.Id}");
            day2.ChangeDay1(testItem);
            Console.WriteLine($"Ending ID: {testItem.Id}");

            int testInt = 0;
            Console.WriteLine($"Starting int: {testInt}");
            //can be changed with a reference type
            //day2.WillChange(ref testInt);
            day2.WontChange(testInt);
            Console.WriteLine($"Ending int: {testInt}");

            day2.ThrowExample(-1);
            //day2.Log("My message");
            //day2.Log("My new message", 145);
            Day3StackExample();
            //Day1Examples();
        }

        /// <summary>
        /// documentation comment changed
        /// </summary>
        public static void Day1Examples()
        {
            Console.WriteLine("Day 1 stuff");

            int _int = 1; //in is your whole numbers

            //generally double
            //may see float, and may see decimal
            //double suffix d/D
            //float suffix f/F
            //decimal suffix m/M
            double _double = 2.0, _double2 = 2.0d;
            float _float = 3.0f;
            decimal _decimal = 4.0m;

            //must cast to work together
            double total = _double + (double)_float + (double)_decimal;

            //very JS or python like, but can define variables as var
            var anything = "string";
            string name = "Test";

            bool _bool = true;
            char _char = 'A', _char2 = 'a';

            Console.WriteLine(_char.Equals(_char2));

            //same namespace
            Day1 sameNamespace = new Day1();

            //constName = "new name"; cannot reassign constants
            staticName = "Seth Clossman"; //can reassign statics
            sameNamespace.PositiveNum = (int)_double;
            sameNamespace.Name = staticName;
            Console.WriteLine("Same Namespace ID: " + sameNamespace.PositiveNum);
            //Console.WriteLine(sameNamespace.SayHello());

            Day1 same2 = new Day1(1, "Dan Pickles");

            Console.WriteLine(@"some random filepath: C:\Skillstorm\Seth Lessons\ConsoleApp1");

            Console.WriteLine(sameNamespace.SayHello());
            Console.WriteLine(same2.SayHello());

            IEnumerable<int> anyEnumerable = sameNamespace.CovariantReturn();

            //examples of covariance, works because they all implement animal
            //can use all of the shared methods between them
            //cannot instantiate an abstract class
            //Animal animal = new Animal();
            Animal dog = new Dog("Fiddo", "Grey", false);
            Animal cat = new Cat("Kitty", "Black", "Green");

            Console.WriteLine(dog.GetType());
            Console.WriteLine(cat.GetType());
            Console.WriteLine(dog.View());
            Console.WriteLine(cat.View());

            Console.WriteLine($"I am {dog.Color} and my name is {dog.Name}");
            //need tyo cast it to use dog specific methods and variables
            Dog sameDog = dog as Dog;
            Console.WriteLine($"Has collar: {sameDog.Collar}");

            Dog stillSameDog = (Dog)dog;
            Console.WriteLine($"Has collar: {stillSameDog.Collar}");

            Console.WriteLine(dog.Speak());
            Console.WriteLine(cat.Speak());
            Console.WriteLine(dog.Move(5));
            Console.WriteLine(cat.Move(5));

            //cannot instantiate an interface
            IAnimal bear = new Bear("Yogi", "Brown");

            //do not need an instance of the class to call static methods
            Console.WriteLine(StaticClass.Greet());

            StaticClass c1 = new StaticClass("Tim");
            StaticClass c2 = new StaticClass("Bob");
            StaticClass c3 = new StaticClass("Joe");
            StaticClass.count = StaticClass.count + 1; // dont need an instance of the class

            Console.WriteLine($"{c1.Name}: " + c1.NumOfClasses());
            Console.WriteLine($"{c2.Name}: " + c2.NumOfClasses());
            Console.WriteLine($"{c3.Name}: " + c3.NumOfClasses());
        }

        public static void Day3ListExample()
        {
            // IEnumerable
            var MyList = new List<string>();
            var firstItem = MyList[0];
            MyList.Add("Seth");
            string[] names = { "Miles", "Josh", "Jim", "Sarah", "Charlotte" };
            MyList.AddRange(names);

            for (int i = 0; i < MyList.Count; i++)
            {
                if (MyList[i] == "Charlotte")
                {
                    MyList.Remove(MyList[i]);
                }

                if (MyList[i] == "Charlotte")
                {
                    MyList.RemoveAt(i);
                }

                MyList.ForEach(item => MyList.Remove(item));
            }

            foreach (var item in MyList)
            {
                if (item == "Charlotte")
                {
                    MyList.Remove(item);
                }
            }
        }

        public static void Day3DictionaryExample()
        {
            var cities = new Dictionary<string, string>();
            cities.Add("North Carolina", "Charlotte");
            cities.Add("South Carolina", "Columbia");
            cities.Add("West Virginia", "Charleston");
            var charlotte = cities["North Carolina"];
            cities.Remove("South Carolina");

            foreach (KeyValuePair<string, string> kvp in cities)
            {
                Console.WriteLine($"The state is {kvp.Key} and it's city is {kvp.Value}");
            }

            cities.Clear();
            cities["North Carolina"] = "Raleigh";
            var cityNames = cities.Values;
            var stateNames = cities.Keys;
        }

        public static void Day3SortedListExample()
        {
            var cities = new SortedList<string, string>();
            cities.Add("North Carolina", "Charlotte");
            cities.Add("South Carolina", "Columbia");
            cities.Add("West Virginia", "Charleston");
            var charlotte = cities["North Carolina"];
            cities.Remove("South Carolina");
            //cities.Add("North Carolina", "Raleigh");
            cities.Clear();
            cities["North Carolina"] = "Raleigh";
            var cityNames = cities.Values;
            var stateNames = cities.Keys;
            var wVA = cities.Values[2];
        }

        public static void Day3QueueExample()
        {
            // FIFO
            var myQueue = new Queue<string>();
            myQueue.Enqueue("Seth");
            myQueue.Enqueue("Miles");
            myQueue.Enqueue("Charlotte");
            myQueue.Enqueue("James");

            var name = myQueue.Dequeue();
            myQueue.Peek();
            myQueue.Clear();
            string[] queueOfNames = { "" };
            myQueue.CopyTo(queueOfNames, 0);

        }

        public static void Day3StackExample()
        {
            // LIFO
            var myStack = new Stack<int>();
            myStack.Push(42);
            myStack.Push(13);
            myStack.Push(21);
            myStack.Push(35);
            //int number = myStack.Pop();
            int[] numArray = { };
            //myStack.CopyTo(numArray, 0);
            //myStack.Clear();
            if (myStack.Contains(13))
            {

            }
            Console.WriteLine(myStack.ToString());
            foreach(var item in myStack)
            {
                Console.WriteLine(item);
                myStack.Pop();
            }
            

        }
    }
}