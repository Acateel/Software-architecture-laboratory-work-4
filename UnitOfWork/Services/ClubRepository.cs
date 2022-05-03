using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Clubs;
using UnitOfWork.Interfaces;

namespace UnitOfWork.Services
{
    public class ClubRepository : Repository<Club>, IClubRepository
    {
        public ClubRepository(ClubsContext context) : base(context) { }

        public IQueryable<Club> GetAll()
        {
            try
            {
                return Db.Clubs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAll() failed: {0}", ex);
                throw;
            }
        }

        public Club GetClub(long id)
        {
            try
            {
                return Db.Clubs.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetClub() failed: {0}", ex);
                throw;
            }
        }
    }
}
