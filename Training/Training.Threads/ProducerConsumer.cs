using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Threads {
    public class ProducerConsumer {
        //this is a supermarket example
        //an actual one would have more moving pieces, but this works for concurrency
        private readonly object mutex = new object();
        private int Produce { get; set; }

        public ProducerConsumer() {
            this.Produce = 0;
        }

        //farmer basically
        public void AddProduce(int amt) {
            lock (mutex) {
                Console.WriteLine($"Producer {Thread.CurrentThread.ManagedThreadId} is adding {amt} to produce");
                Produce += amt;
                Console.WriteLine($"Producer {Thread.CurrentThread.ManagedThreadId} finished");

                Monitor.Pulse(mutex);
            }
        }

        //average customer
        public void ConsumeProduce(int amt) {
            lock (mutex) {
                Console.WriteLine($"Consumer {Thread.CurrentThread.ManagedThreadId} is trying to consume {amt}");
                while (Produce < amt) {
                    Console.WriteLine($"Consumer {Thread.CurrentThread.ManagedThreadId} is waiting for produce");
                    Monitor.Wait(mutex);
                    Console.WriteLine($"Consumer {Thread.CurrentThread.ManagedThreadId} woke up");
                } 

                Produce -= amt;
                Console.WriteLine($"Consumer {Thread.CurrentThread.ManagedThreadId} is consumed to {amt}");
            }
        }
    }
}
