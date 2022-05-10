using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;

namespace UnitOfWork.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ClubsContext db;

        protected Repository(ClubsContext context)
        {
            db = context;
        }

        public TEntity Get(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("id");

            TEntity entity = null;

            try
            {
                entity = GetEntity(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(string.Format("{0} with ID={1} was not found in the DB", typeof(TEntity).Name, id));
            }

            if (entity == null)
                throw new InvalidOperationException(string.Format("{0} with ID={1} was not found in the DB", typeof(TEntity).Name, id));

            return entity;
        }

        protected ClubsContext Db
        {
            get { return db; }
        }

        protected virtual TEntity GetEntity(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            db.Set<TEntity>().Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            TEntity entity = db.Set<TEntity>().Find(id);
            if(entity != null)
            {
                db.Set<TEntity>().Remove(entity);
            }
        }
        public void Save()
        {
            Db.SaveChanges();
        }
    }
}
