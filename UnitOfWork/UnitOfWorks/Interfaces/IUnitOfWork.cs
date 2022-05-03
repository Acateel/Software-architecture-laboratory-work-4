using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;
using Entities;

namespace UnitOfWork.UnitOfWorks.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClubRepository GetClubRepository();
        ICartRepository GetCartRepository();

        void Save();

        List<T> ExecuteCustomQuery<T>(string command, params KeyValuePair<string, object>[] parameters);

        T Get<T>(int id) where T : Entity;
        IQueryable<T> GetAll<T>() where T : Entity;

        void AsNoLazyLoading();
    }
}
