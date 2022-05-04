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
    public class ClubLogic : IClubLogic
    {
        private readonly IClubRepository clubRepository;
        private readonly ICartRepository cartRepository;
        public Club Club { get; set; }

        public ClubLogic(IClubRepository clubRepository, ICartRepository cartRepository)
        {
            this.clubRepository = clubRepository;
            this.cartRepository = cartRepository;
        }

        public Cart BuyClubCart(ITimeTable timeTable)
        {
            var cart = Club.BuyClubCart(timeTable);
            cartRepository.Insert(cart);
            cartRepository.Save();
            return cart;
        }

        public Cart BuySpecialCart(ITimeTable timeTable)
        {
            var cart = Club.BuySpecialCart(timeTable);
            cartRepository.Insert(cart);
            cartRepository.Save();
            return cart;
        }

        public void ChangeInfo(Club club)
        {
            Club = club;
            clubRepository.Update(club);
            clubRepository.Save();
        }

        public string GetClubInfo()
        {
            return Club.ToString();
        }

        public Cart SingUp(int time)
        {
            var cart = Club.SingUp(time);
            cartRepository.Insert(cart);
            cartRepository.Save();
            return cart;
        }

        public bool SingUp(Cart cart, int time)
        {
            bool singing = Club.SingUp(cart, time);
            if (singing)
            {
                cartRepository.Update(cart);
                cartRepository.Save();
            }
            return singing;
        }

        public bool VisitClub()
        {
            Club.Visit();
            return false;
        }

        public bool VisitClub(Cart cart)
        {
            bool visit = Club.Visit(cart);
            if((cart is TempCart) && visit)
            {
                cartRepository.Delete(cart.Id);
                cartRepository.Save();
            }
            
            return visit;
        }
    }
}
