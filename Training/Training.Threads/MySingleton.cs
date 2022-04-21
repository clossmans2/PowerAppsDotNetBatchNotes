using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Threads {
    //only ever want there to be one instance of this class at any point in time
    public sealed class MySingleton {
        //private constructor so that nothing else can call it

        //this single instance that should be created
        private static MySingleton instance = null;

        private MySingleton() { }

        public static MySingleton Instance {
            get { 
                if (instance == null) {
                    instance = new MySingleton();
                }
                return instance; 
            }
        }
    }
}
