using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    abstract class Club
    {
        public abstract bool Visit();
        public abstract bool Visit(Cart cart);
        public abstract Cart BuyClubCart();
        public abstract Cart BuySpecialCart();
        public abstract Cart SingUp();
        public abstract bool SingUp(Cart cart);
    }
}
