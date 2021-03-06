using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data {
    //colon for inheritance
    public class Dog : Animal, IComparable<Dog> {
        public bool Collar { get; set; }

        public Dog(string name, string color, bool collar) : base(name, color) {
            this.Collar = collar;
        }

        public override string Speak() {
            return "Bark";
        }

        public override string View() {
            return base.View() + $" Collar: {this.Collar}";
        }

        public override string Move(int distance) {
            return $"I ran {distance}";
        }

        public override string ToString() {
            return $"[Dog: {Name}, {Color}, {Collar}]";
        }

        public int CompareTo(Dog? other) {
            if (other == null) {
                return 0;
            }
            return String.Compare(this.Name, other.Name);
        }

        public void ThreadTest() {
            Console.WriteLine($"This is {this.Name}");
        }
    }
}
