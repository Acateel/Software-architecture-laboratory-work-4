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
        private readonly IClubLogic clubLogic;

        public ClubsLogic(IClubRepository repository, IClubLogic clubLogic)
        {
            this.repository = repository;
            this.clubLogic = clubLogic;
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

        public void SetClub(int id)
        {
            clubLogic.Club = repository.Get(id);
        }
    }
}
