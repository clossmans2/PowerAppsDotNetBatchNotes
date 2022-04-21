using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Threads {
    public class Person {
        private BankAccount Account;
        public string Name { get; set; }

        public Person(string name, BankAccount account) {
            this.Name = name;
            this.Account = account;
        }

        public void Add(double amt) {
            double newBalance = this.Account.AddMoney(this.Name, amt);
            //Console.WriteLine($"{this.Name} deposited {amt}, new balance is {newBalance}");
        }

        public void Withdraw(double amt) {
            double newBalance = this.Account.WithdrawMoney(this.Name, amt);
            //Console.WriteLine($"{this.Name} withdrew {amt}, new balance is {newBalance}");
        }
    }
}
