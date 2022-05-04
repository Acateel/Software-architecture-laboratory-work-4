using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Clubs;

namespace BusinessLogic.Interfaces
{
    interface IClubsLogic
    {
        IQueryable<Club> GetClubs();
        void SetClub(int id);
        void CreateClub(Club club);
        void DeleteClub(int id);
    }
}
