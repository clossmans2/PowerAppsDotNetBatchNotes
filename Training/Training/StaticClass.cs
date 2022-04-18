using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training {
    public class StaticClass {
        //static variables are the same for every instance of a class
        public static int count = 0;
        //variables are different per instance of a class
        public string Name { get; set; }

        public StaticClass(string name) {
            this.Name = name;
            count = count + 1;
        }

        public string NumOfClasses() {
            return $"There are {count} StaticClasses";
        }

        public static string Greet() {
            return "Hello from the static method";
        }
    }
}
