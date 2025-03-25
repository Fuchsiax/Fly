using Fly2._0.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly2._0.Core
{
    class ApplicationContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Airticket> Airtickets { get; set; }
        public DbSet<Flight>  Flights { get; set; }
        public DbSet<TicketType>  TicketTypes { get; set; }
        public DbSet<Address>  Addresses { get; set; }
        public DbSet<Contact>  Contacts { get; set; }
        public DbSet<Passport>  Passports { get; set; }
    }
}
