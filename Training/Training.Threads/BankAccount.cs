using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Threads {
    public class BankAccount {
        private readonly object mutex = new object();
        //do not want two threads to access this at the same time
        public double Balance { get; set; }

        public BankAccount(double balance) {
            this.Balance = balance;
        }

        //do not want these to happen at the same time
        public double AddMoney(string name, double amt) {
            lock (mutex) {
                Balance += amt;
                Console.WriteLine($"{name} deposited {amt}, new balance is {Balance}");
            }
            return Balance;
        }

        public double WithdrawMoney(string name, double amt) {
            lock (mutex) {
                if (amt <= Balance) {
                    Balance -= amt;
                    Console.WriteLine($"{name} withdrew {amt}, new balance is {Balance}");
                } else {
                    Console.WriteLine($"{name} wanted to withdraw {Balance}, and couldn't");
                }
            }
            return Balance;
        }
    }
}
