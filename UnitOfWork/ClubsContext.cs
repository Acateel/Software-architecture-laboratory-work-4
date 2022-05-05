using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
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
            //Database.SetInitializer<ClubsContext>(new DropCreateDatabaseAlways<ClubsContext>());
        }

        public ObjectResult<T> ExecuteStoreQuery<T>(string commandText, params object[] paramenters)
        {
            return ObjectContext.ExecuteStoreQuery<T>(commandText, paramenters);
        }

        public ObjectContext ObjectContext
        {
            get { return ((IObjectContextAdapter)this).ObjectContext; }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
