using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace WpfChallenge.Models
{
    class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }

        public Customer()
        {
        }

        public Customer(Customer other)
        {
            id = other.id;
            name = other.name;
            phone = other.phone;
            address = other.address;
        }
    }
}
