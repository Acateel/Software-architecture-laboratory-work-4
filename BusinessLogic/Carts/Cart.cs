using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.TimeTables;
using Entities.Clubs;

namespace Entities.Carts
{
    public abstract class Cart
    {
        public ITimeTable Table { get; protected set; }

        protected Cart(ITimeTable table)
        {
            this.Table = table;
        }

        public abstract bool CheckCart(Club club);

        public bool CheckTime(int time)
        {
            return !Table.IsTimeFree(time);
        }

        public bool VisitClub(Club club, int time)
        {
            if(CheckCart(club) && CheckTime(time))
            {
                ResetTemporaty(time);
                return true;
            }
            return false;
        }

        private void ResetTemporaty(int time)
        {
            if (Table.IsTimeTemporary(time))
            {
                Table.SetFree(time);
            }
        }
    }
}
