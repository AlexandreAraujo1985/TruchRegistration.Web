using System.Collections.Generic;
using TruckRegistration.Domain.Interfaces.Repositories;

namespace TruckRegistration.Domain.Services
{
    public class ServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }
        public TEntity Find(int id) => _repositoryBase.Find(id);

        public IEnumerable<TEntity> GetList() => _repositoryBase.GetList();

        public void Add(TEntity obj) => _repositoryBase.Add(obj);

        public void Update(TEntity obj) => _repositoryBase.Update(obj);

        public void Delete(TEntity obj) => _repositoryBase.Delete(obj);
    }
}
