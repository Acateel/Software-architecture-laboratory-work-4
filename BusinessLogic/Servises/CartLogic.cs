using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Clubs;
using Entities.Carts;
using Entities.TimeTables;
using BusinessLogic.Interfaces;
using UnitOfWork.Interfaces;

namespace BusinessLogic.Servises
{
    public class CartLogic : ICartLogic
    {
        private readonly ICartRepository repository;

        public CartLogic(ICartRepository repository)
        {
            this.repository = repository;
        }

        public void ChangeTimeTable(int cartId, ITimeTable timeTable)
        {
            Cart cart = repository.Get(cartId);
            cart.Table = timeTable;
            repository.Update(cart);
            repository.Save();
        }

        public IQueryable<Cart> GetCarts()
        {
            return repository.GetAll();
        }

        public ITimeTable GetTimeTable(int cartId)
        {
            Cart cart = repository.Get(cartId);
            return cart.Table;
        }

        public void RemoveCart(int cartId)
        {
            repository.Delete(cartId);
            repository.Save();
        }
    }
}
