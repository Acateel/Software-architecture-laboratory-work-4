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
    class ClubsLogic : IClubsLogic
    {
        private readonly IClubRepository repository;

        public ClubsLogic(IClubRepository repository)
        {
            this.repository = repository;
        }

        public void CreateClub(Club club)
        {
            repository.Insert(club);
        }

        public void DeleteClub(int id)
        {
            repository.Delete(id);
        }

        public IQueryable<Club> GetClubs()
        {
            return repository.GetAll();
        }

        public Club SetClub(int id)
        {
            throw new NotImplementedException();
        }
    }
}
