using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Am.Infra
{
    internal class AmContext:DbContext

    { // prop + dbset
        public DbSet<Flight> Flights  { get; set; }
        public DbSet<Passenger> Passengers  { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Plane> Planes { get; set; }

        //override void onConfiguring 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; 
            Initial Catalog=AirportManagement;
            Integrated Security=true");
           
            base.OnConfiguring(optionsBuilder);
        }
       

    }
}
