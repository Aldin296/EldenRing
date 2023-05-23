using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRing_API_Client.Modles
{
    public class Scaling
    {
        public string name { get; set; }
        public string scaling { get; set; } 

        public Scaling(string name, string scaling) 
        {
            this.name = name;
            this.scaling = scaling;
        }
    }
}
