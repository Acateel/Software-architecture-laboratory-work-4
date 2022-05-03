using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entities.Clubs;
using Entities.Carts;

namespace UnitOfWork
{
    public class ClubsContext : DbContext
    {
        public ClubsContext() : base ("ProductDBConnectionString")
        {
        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Cart> Carts { get; set; }

        static ClubsContext()
        {
            Database.SetInitializer<ClubsContext>(new CreateDatabaseIfNotExists<ClubsContext>());
        }


    }
}
