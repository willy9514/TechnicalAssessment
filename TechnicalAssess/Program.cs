using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssess
{
    class Program
    {
        static void Main(string[] args)
        {
            Airport airport = Init();
            Task1(airport);
            Task2(airport);
        }

        private static Airport Init()
        {
            Airport airport = new Airport("YUL");

            Plane plane = new Plane("A100", 20);
            Flight flight = new Flight(1, 1, "YUL", "YYZ", plane);
            airport.AddFlight(flight);
            flight = new Flight(4, 2, "YUL", "YYZ", plane);
            airport.AddFlight(flight);


            plane = new Plane("A200", 20);
            flight = new Flight(2, 1, "YUL", "YYC", plane);
            airport.AddFlight(flight);
            flight = new Flight(5, 2, "YUL", "YYC", plane);
            airport.AddFlight(flight);

            plane = new Plane("A300", 20);
            flight = new Flight(3, 1, "YUL", "YVR", plane);
            airport.AddFlight(flight);
            flight = new Flight(6, 2, "YUL", "YVR", plane);
            airport.AddFlight(flight);

            return airport;
        }

        private static void Task1(Airport airport)
        {
            // Get Flight Schedule
            airport.GetFlightSchedule();

        }

        private static void Task2(Airport airport)
        {
        
            List<Order> orders = new List<Order>();
            // Get Order List;
            using (StreamReader r = new StreamReader(@"..\..\Data\coding-assigment-orders.json"))
            {
                string json = r.ReadToEnd();
                dynamic ordersobject = JsonConvert.DeserializeObject(json);
                foreach(var orderobject in ordersobject)
                {
                    Order order = new Order();
                    order.Name = orderobject.Name;
                    var orderobject2 = orderobject.First;
                    order.Destination = orderobject2.destination;
                    orders.Add(order);
                }
            }

            // Assign the orders to the flights
            orders = airport.LoadOrders(orders);
            // print each order
            foreach(Order order in orders)
            {
                // Get the flight from the order number
                Flight flight = airport.GetFlight(order.Flightnumber);
                if(flight != null)
                {
                    Console.WriteLine("order: {0}, flightNumber: {1}, departure: {2}, arrival city: {3}, day: {4}", order.Name, flight.Number, flight.Departure, flight.Arrival, flight.Day);
                }
                else
                {
                    Console.WriteLine("order: {0}, flightNumber: not scheduled", order.Name);
                }
            }

            Console.ReadKey();
            

        }
    }
}
