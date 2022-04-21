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

        //do not want these to hapoen at the same time
        public double AddMoney(double amt) {
            Balance += amt;
            return Balance;
        }

        public double WithdrawMoney(double amt) {
            Balance -= amt;
            return Balance;
        }
    }
}
