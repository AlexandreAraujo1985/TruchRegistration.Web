using System.Collections.Generic;
using TruckRegistration.Domain.Interfaces.Services;

namespace TruckRegistration.Application.Services
{
    public class ApplicationBase<TEntity> where TEntity : class
    {
        private IServiceBase<TEntity> _serviceBase;

        public ApplicationBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }
        public TEntity Find(int id) => _serviceBase.Find(id);

        public IEnumerable<TEntity> GetList() => _serviceBase.GetList();

        public void Add(TEntity obj) => _serviceBase.Add(obj);

        public void Update(TEntity obj) => _serviceBase.Update(obj);

        public void Delete(TEntity obj) => _serviceBase.Delete(obj);
    }
}
