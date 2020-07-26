using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssess
{
    class Airport
    {
        private string location; 
        private List<Flight> flights;

        public string Location { get => location; set => location = value; }

        public Airport(string location) 
        {
            this.location = location;
            this.flights = new List<Flight>();
        }

        public void GetFlightSchedule()
        {
            foreach(Flight flight in flights.OrderBy(x => x.Number))
            {
                flight.GetSchedule();
            }
            Console.ReadKey();
        }

        public Boolean AddFlight(Flight flight)
        {
            flights.Add(flight);
            return true;
        }

        public Flight GetFlight(int flightnumber)
        {
            return flights.FirstOrDefault(x => x.Number == flightnumber);
        }

        public List<Order> LoadOrders(List<Order> orders)
        {
            // new list of updated orders
            List<Order> neworders = new List<Order>();

            foreach(Order order in orders)
            {
                Order updatedorder = null;
                // Get all flights are flighting to the correct location and Has room
                List<Flight> flights = this.flights.Where(x => x.Arrival == order.Destination && x.HasRoom()).ToList();
                foreach(Flight flight in flights.OrderBy(x => x.Day))
                {
                     // Add order to the flight and return the order with a new flight number
                     updatedorder = flight.AddOrder(order);
                     break;
                }
                // if the order has not been updated then no flight was available, return old order
                if(updatedorder == null)
                {
                    neworders.Add(order);
                }
                // add new updated order
                else
                {
                    neworders.Add(updatedorder);
                }
            }

            // return list of orders with flight number assigned.
            return neworders;
        }
    }
}
