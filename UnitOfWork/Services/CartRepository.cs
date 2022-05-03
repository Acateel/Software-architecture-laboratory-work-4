using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Carts;
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
                return Db.Carts;
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
                return Db.Carts.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetClub() failed: {0}", ex);
                throw;
            }
        }
    }
}
