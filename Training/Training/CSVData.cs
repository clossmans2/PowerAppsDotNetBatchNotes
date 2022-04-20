using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class CSVData
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public CSVData(string name, string phone, string addr)
        {
            this.Name = name;
            this.PhoneNumber = phone;
            this.Address = addr;
        }

        public override string ToString()
        {
            return $"Name: {this.Name} --- Address: {this.Address} --- Phone Number: {this.PhoneNumber}";
        }
    }
}
