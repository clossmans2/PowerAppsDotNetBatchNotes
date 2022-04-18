using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training {
    public class Day1 {
        //C# getter and setter
        //can type prop, tab, tab to set these up
        public int Id { get; set; }
        public string Name { get; set; }

        private int _positiveNum;
        public int PositiveNum {
            get { return _positiveNum; }
            set {
                if (value >= 0) {
                    this._positiveNum = value;
                }
            }
        }

        //private string name;

        //public string getName() {
        //    return name;
        //}

        //public void setName(string name) {
        //    this.name = name;
        //}

        //default constructor and non-default constructor
        public Day1() { }

        public Day1(int id, string name) {
            this.Id = id;
            this.Name = name;
        }

        public string SayHello() {
            //the basic way to return a string
            //return "Hello my name is " + this.Name;

            //way to keep your formatting/ not need to type escape characters
            //return @"Hello
            //         my 
            //         name
            //         is
            //         " + this.Name
            //         + @" and
            //         my id
            //         is " + this.Id;

            //can use string builder
            //StringBuilder sb = new StringBuilder();
            //sb.Append("Hello");
            //sb.AppendLine("and my name is" + Id);
            //return sb.ToString();

            //another way to format it
            return $"Hello my name is {this.Name} and my id is {this.Id}";
        }

        public IEnumerable<int> CovariantReturn() {
            //can returna anything that implements IEnumerable();
            return new List<int>();
            //return new LinkedList<int>();
            //return new HashSet<int>();
        }
    }
}
