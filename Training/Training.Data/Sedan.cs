using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data {
    public class Sedan {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        public Sedan(string make, string model, string year) {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public string StartEngine() {
            return "Vroom";
        }

        public string GetInfo() {
            return $"I am a {this.Year} {this.Make} {this.Model}";
        }

        public int GetMileage() {
            throw new NotImplementedException();
        }
    }
}
