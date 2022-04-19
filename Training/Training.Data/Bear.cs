using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data {
    public class Bear : IAnimal {
        //must implemenet these too
        public string Name { get; set; }
        public string Color { get; set; }

        public Bear(string name, string color) {
            this.Name = name;
            this.Color = color;
            Console.WriteLine("Some test Code, to be deleted");
        }

        public string Move(int distance) {
            return $"lumbers {distance} to bicycle";
        }

        public string Speak() {
            return "Growl";
        }

        public string View() {
            return $"I am a {this.Color} animal, my name is {this.Name}";
        }
    }
}
