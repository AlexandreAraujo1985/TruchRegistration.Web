using TruckRegistration.Domain.Entities;
using TruckRegistration.Domain.Interfaces.Repositories;
using TruckRegistration.Infra.Data.Contexts;

namespace TruckRegistration.Infra.Data.Repositories
{
    public class TruckModelRepository : RepositoryBase<TruckModel>, ITruckModelRepository
    {
        public TruckModelRepository(TruckRegistrationContext db) : base(db)
        {
        }
    }
}
