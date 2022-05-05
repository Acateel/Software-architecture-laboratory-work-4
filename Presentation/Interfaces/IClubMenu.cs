using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    interface IClubMenu
    {
        void GetClubInfo();
        void ChangeInfo();
        void VisitClub();

        void BuyClubCart();
        void BuySpecialCart();

        void SingUp();
    }
}
