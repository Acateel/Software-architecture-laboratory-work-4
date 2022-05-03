using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Carts;

namespace UnitOfWork.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        IQueryable<Cart> GetAll();
        Cart GetCart(long id);
    }
}
