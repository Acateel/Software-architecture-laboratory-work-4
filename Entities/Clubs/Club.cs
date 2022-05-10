using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.TimeTables;
using Entities.Timers;
using Entities.Carts;

namespace Entities.Clubs
{
    public abstract class Club : Entity
    {
        public int Table_Id { get; set; }
        public TimeTable Table { get; set; }

        protected Club(TimeTable table)
        {
            this.Table = table;
            if (Table != null)
            {
                this.Table_Id = Table.Id;
            }
        }

        public void Visit()
        {
            throw new ClubException("Cannot visit club without cart");
        }
        public abstract bool Visit(Cart cart);
        public abstract Cart BuyClubCart(TimeTable timeTable);
        public abstract Cart BuySpecialCart(TimeTable timeTable);
        public abstract Cart SingUp(int time);
        public abstract bool SingUp(Cart cart, int time);
    }
}
