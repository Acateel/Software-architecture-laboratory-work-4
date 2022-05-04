using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Carts;
using Entities.TimeTables;
using BusinessLogic.Interfaces;
using UnitOfWork.Interfaces;
using Entities.Clubs;

namespace BusinessLogic.Servises
{
    class ClubLogic : IClubLogic
    {
        public Club Club { get; set; }

        public Cart BuyClubCart(ITimeTable timeTable)
        {
            return Club.BuyClubCart(timeTable);
        }

        public Cart BuySpecialCart(ITimeTable timeTable)
        {
            return Club.BuySpecialCart(timeTable);
        }

        public void ChangeInfo(Club club)
        {
            Club = club;
        }

        public string GetClubInfo()
        {
            return Club.ToString();
        }

        public Cart SingUp(int time)
        {
            return Club.SingUp(time);
        }

        public bool SingUp(Cart cart, int time)
        {
            return Club.SingUp(cart, time);
        }

        public bool VisitClub()
        {
            Club.Visit();
            return false;
        }

        public bool VisitClub(Cart cart)
        {
            return Club.Visit(cart);
        }
    }
}
