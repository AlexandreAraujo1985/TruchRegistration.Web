using System;
using System.Collections.Generic;
using System.Linq;
using TruckRegistration.Domain.Interfaces.Repositories;
using TruckRegistration.Infra.Data.Contexts;

namespace TruckRegistration.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : class
    {
        protected readonly TruckRegistrationContext _db;
        public RepositoryBase(TruckRegistrationContext db)
        {
            _db = db;
        }

        public TEntity Find(int id) => _db.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetList() => _db.Set<TEntity>().ToList();

        public void Add(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);
            _db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _db.Set<TEntity>().Update(obj);
            _db.SaveChanges();
        }

        public void Delete(TEntity obj)
        {
            _db.Set<TEntity>().Remove(obj);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
