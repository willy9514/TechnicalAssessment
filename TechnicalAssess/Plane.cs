using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssess
{
    class Plane
    {
        private string name;

        private int capacity;

        public Plane(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
    }
}
