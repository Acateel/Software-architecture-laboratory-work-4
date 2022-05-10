using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Carts;
using Entities.TimeTables;
using UnitOfWork.Interfaces;

namespace UnitOfWork.Services
{
    class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(ClubsContext context) : base(context) { }

        public IQueryable<Cart> GetAll()
        {
            try
            {
                return Db.Carts.Include("Table");
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAll() failed: {0}", ex);
                throw;
            }
        }

        public Cart GetCart(long id)
        {
            try
            {
                return Db.Carts.Include("Table").FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetClub() failed: {0}", ex);
                throw;
            }
        }

        public override void Insert(Cart entity)
        {
            base.Insert(entity);
            Db.TimeTables.Add(entity.Table);
        }

        public override void Update(Cart entity)
        {
            base.Update(entity);
            Db.TimeTables.Attach(entity.Table);
            Db.Entry(entity.Table).State = EntityState.Modified;
        }

        public override void Delete(int id)
        {
            Cart entity = Db.Set<Cart>().Find(id);
            TimeTable table = Db.TimeTables.Find(entity.Table_Id);
            if (entity != null)
            {
                Db.Set<Cart>().Remove(entity);
            }
            if(table != null)
            {
                Db.TimeTables.Remove(table);
            }
        }
    }
}
