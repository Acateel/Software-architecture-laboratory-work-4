using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Clubs;

namespace UnitOfWork.Interfaces
{
    interface IClubRepository : IRepository<Club>
    {
        IQueryable<Club> GetAll();
        Club GetClub(long id);
    }
}
