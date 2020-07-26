using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssess
{
    class Order
    {
        private string name;
        private string destination;
        private int flightnumber;

        public Order()
        {

        }

        public string Name { get => name; set => name = value; }
        public string Destination { get => destination; set => destination = value; }
        public int Flightnumber { get => flightnumber; set => flightnumber = value; }

    }
}
