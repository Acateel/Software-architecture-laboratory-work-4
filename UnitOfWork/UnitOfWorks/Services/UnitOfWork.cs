using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UnitOfWork.UnitOfWorks.Interfaces;
using UnitOfWork.Interfaces;
using UnitOfWork.Services;
using Entities;

namespace UnitOfWork.UnitOfWorks.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private IClubRepository clubRepository;
        private ICartRepository cartRepository;
        private bool _disposed;
        protected readonly ClubsContext Db;

        public UnitOfWork()
        {
            Db = new ClubsContext();
        }

        public IClubRepository GetClubRepository()
        {
            return clubRepository ?? (clubRepository = new ClubRepository(Db));
        }

        public ICartRepository GetCartRepository()
        {
            return cartRepository ?? (cartRepository = new CartRepository(Db));
        }

        public List<T> ExecuteCustomQuery<T>(string command, params KeyValuePair<string, object>[] parameters)
        {
            var _params = new object[parameters.Length];
            for (var i = 0; i < parameters.Length; ++i)
                _params[i] = new SqlParameter(parameters[i].Key, parameters[i].Value);

            return Db.ExecuteStoreQuery<T>(command, _params).ToList();
        }

        public T Get<T>(int id) where T : Entity
        {
            var result = Db.Set<T>().Find(id);
            if (result == null)
            {
                Console.WriteLine("Entity {0}:{1} not found in database", typeof(T), id);
                throw new Exception(string.Format("Entity {0}:{1} not found in database", typeof(T), id));
            }

            return result;
        }

        public IQueryable<T> GetAll<T>() where T : Entity
        {
            var result = Db.Set<T>();
            if (result == null)
            {
                Console.WriteLine("Entity type {0} not found in database", typeof(T));
                throw new Exception(string.Format("Entity type {0} not found in database", typeof(T)));
            }

            return result;
        }

        public void AsNoLazyLoading()
        {
            Db.Configuration.LazyLoadingEnabled = false;
            Db.Configuration.ProxyCreationEnabled = false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Db.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
