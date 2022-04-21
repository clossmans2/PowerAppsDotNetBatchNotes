using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Threads {
    //thread safe singleton
    public class MySingleton2 {
        private static MySingleton2 instance = null;
        private static readonly object mutex = new object();

        private MySingleton2() { }

        public static MySingleton2 Instance {
            get {
                //critical section
                //any section that only one thread at a time should be able to run
                lock (mutex) {
                    if (instance == null) {
                        instance = new MySingleton2();
                    }
                    return instance;
                }
            }
        }
    }
}
