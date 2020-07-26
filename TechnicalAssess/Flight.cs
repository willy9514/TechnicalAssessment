using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssess
{
    class Flight
    {
        private int number;
        private int day;
        private string departure;
        private string arrival;
        private Plane plane;
        private int currentcapacity;
        private List<Order> orders;

        public Flight(int number, int day, string departure, string arrival, Plane plane)
        {
            this.Day = day;
            this.Departure = departure;
            this.Arrival = arrival;
            this.Number = number;
            this.plane = plane;
            this.Currentcapacity = 0;
            this.orders = new List<Order>();

        }

        public int Day { get => day; set => day = value; }
        public string Departure { get => departure; set => departure = value; }
        public string Arrival { get => arrival; set => arrival = value; }
        public int Number { get => number; set => number = value; }
        public int Currentcapacity { get => currentcapacity; set => currentcapacity = value; }

        public void GetSchedule()
        {
            Console.WriteLine("Flight: {0}, departure: {1}, arrival: {2}, day {3}", this.Number, this.departure, this.arrival, this.day);
        }

        internal bool HasRoom()
        {
            return this.currentcapacity < this.plane.Capacity;
        }

        // return the order with an updated flight number
        public Order AddOrder(Order order)
        {
            // assign number
            order.Flightnumber = this.number;
            // add to list of orders for flight
            this.orders.Add(order);
            // add to cargo limit
            this.Currentcapacity++;
            return order;

        }
    }
}
