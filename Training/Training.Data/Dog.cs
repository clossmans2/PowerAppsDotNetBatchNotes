using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data {
    //colon for inheritance
    public class Dog : Animal {
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
    }
}
