using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {

         public IList<Flight> Flights = new List<Flight>();

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            //var query = from f in Flights
            //            group f by f.Destination;
            //lambda
            var query = Flights.GroupBy(f => f.Destination);
         foreach (var item in query)
            {
                Console.WriteLine("Destination"+item.Key);
                foreach  (var a in item)
                {
                    Console.WriteLine("Décollage"+a.FlightDate);
                }


            }
            return query;
        }

        public double DurationAverage(string destination)
        {
            //var req= from f in Flights
            //         where f.Destination == destination
            //         select f.EstimatedDuration;

            //return req.Average();
            // lambda
            return Flights.Where(i => i.Destination == destination).Average(f => f.EstimatedDuration);
            
        }

        public IList<DateTime> GetFlightDates(string destination)
        {
            //IList<DateTime> Result = new List<DateTime>();
            // // foreach -- item = Flight
            // foreach (var item in Flights)
            // {
            //     if (item.Destination == destination)
            //         Result.Add(item.FlightDate);
            // }
            // return Result;


            /* Le langage Linq 
             * var query = from instance in Collection
             *                  (A-X-P-item) in Flights (A= Flight)
             *             where condition ( A.Destination== destination
             *             select   A.FlightDate;
             * return query */
       
             

            //with linq
            //var query = from item in Flights
            //            where item.Destination == destination
            //            select item.FlightDate;
            //return query.ToList();
            //lambda
            //return Collection.Where(instance=>instance.condition)....

           return Flights.Where(item=> item.Destination == destination)
                .Select(item=> item.FlightDate).ToList();
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
           //linq
           //var query= from item in Flights
           //           orderby item.EstimatedDuration descending
           //           select item;
           // return query;
           //lambda
           return Flights.OrderByDescending(f=> f.EstimatedDuration);

        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //var query= from f in Flights
            //           where (f.FlightDate - startDate).TotalDays<=7
            //           select f;
            //return query.Count();
            //lambda
            // return Flights.Where(f=> (f.FlightDate - startDate).TotalDays <= 7).Count();
            return Flights.Count(f => (f.FlightDate - startDate).TotalDays <= 7);
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            //var query=from f in flight.Passengers.OfType<Traveller>()
            //          orderby f.BirthDate descending
            //          select f;
            //return query.Take(3);
            //lambda
            return flight.Passengers.OfType<Traveller>().OrderByDescending(b=>b.BirthDate).Take(3);
        }
        
        public void ShowFlightDetails(Plane plane)
        {
            //linq
            //var req = from item in Flights
            //          where item.Plane == plane 
            //          select new { item.Destination, item.FlightDate};
            //lambda
            var req= Flights.Where(a => a.Plane == plane).Select(item => new { item.Destination, item.FlightDate });
           foreach (var r in req)
            {
                Console.WriteLine("destination"+r.Destination+"FlightDate"+r.FlightDate);
            }


         
        }
    }

        
        }
    

