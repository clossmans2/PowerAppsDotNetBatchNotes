using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Data {
    public class DogComparer : IComparer<Dog> {
        public int Compare(Dog? x, Dog? y) {
            if (x == null || y == null) {
                return 0;
            }

            return x.Color.CompareTo(y.Color);
        }
    }
}
