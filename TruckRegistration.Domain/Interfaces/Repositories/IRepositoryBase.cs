using System.Collections.Generic;

namespace TruckRegistration.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Find(int id);
        IEnumerable<TEntity> GetList();
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
    }
}
