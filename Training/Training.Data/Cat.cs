using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data {
    public class Cat : Animal {
        public string EyeColor { get; set; }

        public Cat(string name, string color, string eye) : base(name, color) {
            this.EyeColor = eye;
        }

        public override string Speak() {
            return "Meow";
        }

        public override string Move(int distance) {
            return "No";
        }
    }
}
