using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRing_API_Client.Modles
{
    public class Attribute
    {
        public string name { get; set; }
        public int amount { get; set; }

        public Attribute() { }
        public Attribute(string name, int amount) 
        {
            this.name = name;
            this.amount = amount;
        }
    }
}
