using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.UnitOfWorks.Interfaces;
using UnitOfWork.UnitOfWorks.Services;
using BusinessLogic.Interfaces;
using BusinessLogic.Servises;

namespace BusinessLogic
{
    public class Logic
    {
        public Logic(IUnitOfWork unitOfWork)
        {
            Club = new ClubLogic(unitOfWork.GetClubRepository(), unitOfWork.GetCartRepository());
            Clubs = new ClubsLogic(unitOfWork.GetClubRepository(), Club);
            Carts = new CartLogic(unitOfWork.GetCartRepository());
        }
        public IClubsLogic Clubs { get; private set; }
        public IClubLogic Club { get; private set; }
        public ICartLogic Carts { get; private set; }
    }
}
