using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Clubs;
using Entities.Carts;
using Entities.TimeTables;

namespace BusinessLogic.Interfaces
{
    public interface ICartLogic
    {
        IQueryable<Cart> GetCarts();
        ITimeTable GetTimeTable(int cartId);

        Cart GetCart(int cartId);

        void ChangeTimeTable(int cartId, ITimeTable timeTable);

        void RemoveCart(int cartId);
    }
}
