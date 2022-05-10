using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Clubs;
using Entities.TimeTables;
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
                return Db.Clubs.Include("Table");
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
                return Db.Clubs.Include("Table").FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetClub() failed: {0}", ex);
                throw;
            }
        }

        public override void Insert(Club entity)
        {
            base.Insert(entity);
            Db.TimeTables.Add(entity.Table);
        }

        public override void Update(Club entity)
        {
            base.Update(entity);
            Db.TimeTables.Attach(entity.Table);
            Db.Entry(entity.Table).State = EntityState.Modified;
        }

        public override void Delete(int id)
        {
            Club entity = Db.Set<Club>().Find(id);
            TimeTable table = Db.TimeTables.Find(entity.Table_Id);
            if (entity != null)
            {
                Db.Set<Club>().Remove(entity);
            }
            if (table != null)
            {
                Db.TimeTables.Remove(table);
            }
        }
    }
}
