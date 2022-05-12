using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Clubs;

namespace BusinessLogic.Interfaces
{
    public interface IClubsLogic
    {
        IQueryable<Club> GetClubs();
        Club SetClub(int id);
        void CreateClub(Club club);
        void DeleteClub(int id);
    }
}
