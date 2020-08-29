using System.Collections.Generic;
using System.Linq;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Domain.Interfaces.Repositories;
using TruckRegistration.Infra.Data.Contexts;

namespace TruckRegistration.Infra.Data.Repositories
{
    public class TruckRepository : RepositoryBase<Truck>, ITruckRepository
    {
        public TruckRepository(TruckRegistrationContext db) : base(db)
        {
        }

        public IEnumerable<Truck> GetTrucks()
        {
            var trucks = _db.Trucks.ToList()
                .Select(it =>
                {
                    return new Truck
                    {
                        TruckId = it.TruckId,
                        NameTruck = it.NameTruck,
                        Model = _db.TruckModels.Find(it.TruckModelId),
                        TruckModelId = it.TruckModelId,
                        YearManufacture = it.YearManufacture,
                        YearModel = it.YearModel
                    };
                });
            return trucks;
        }
    }
}
