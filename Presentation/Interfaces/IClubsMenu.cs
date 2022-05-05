using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Presentation.Interfaces
{
    interface IClubsMenu
    {
        void ShowMenu();
        void Start();
        void GetClubs();
        void SetClub();
        void CreateClub();
        void DeleteClub();
        
        void CartMenu();
    }
}
