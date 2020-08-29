using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TruckRegistration.Application.Interfaces;
using TruckRegistration.Application.Services;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Domain.Interfaces.Repositories;
using TruckRegistration.Domain.Interfaces.Services;
using TruckRegistration.Domain.Services;
using TruckRegistration.Infra.Data.Contexts;
using TruckRegistration.Infra.Data.Repositories;

namespace TruckRegistration.Test
{

    [TestClass]
    public class TruckModelApplicationTest
    {
        private readonly DbContextOptions<TruckRegistrationContext> options = new DbContextOptions<TruckRegistrationContext>();
        private TruckRegistrationContext db;
        private ITruckModelApplication _truckModelApplication;
        private ITruckModelService _truckModelService;
        private ITruckModelRepository _truckModelRepository;

        [TestInitialize]
        public void Initalize()
        {
            db = new TruckRegistrationContext(options: options);
            _truckModelRepository = new TruckModelRepository(db);
            _truckModelService = new TruckModelService(_truckModelRepository);
            _truckModelApplication = new TruckModelApplication(_truckModelService);

            LoadData();
        }

        public void LoadData()
        {
            db.TruckModels.Add(new TruckModel { TruckModelId = 1, ModelDescription = "FH" });
            db.SaveChanges();
        }

        [TestMethod]
        public void TestGetAllTrucksRepository()
        {
            var trucks = _truckModelRepository.GetList().ToList();
            Assert.IsNotNull(trucks.ToList());
        }

        [TestMethod]
        public void TestFindTruckRepository()
        {
            
            var truck = _truckModelRepository.Find(1);
            Assert.IsTrue(truck != null);
        }

        [TestMethod]
        public void TestUpdateTruckRepository()
        {
            db.TruckModels.AddRange(new TruckModel { TruckModelId = 2, ModelDescription = "FH" });
            db.SaveChanges();

            var truck = new TruckModel { TruckModelId = 2, ModelDescription = "FHA" };

            _truckModelRepository.Update(truck);
            var truckUpadated = db.Trucks.Find(1).NameTruck == "Test";
            Assert.IsTrue(truckUpadated);
        }

        [TestMethod]
        public void TestAddTruckRepository()
        {
            var truck = new TruckModel { ModelDescription = "FH", TruckModelId = 1 };
            _truckModelRepository.Add(truck);
            var truckInsert = db.Trucks.Find(2);
            Assert.IsNotNull(truckInsert);
        }

        [TestMethod]
        public void TestDeleteTruckRepository()
        {
            var truck = new TruckModel { ModelDescription = "FH", TruckModelId = 1 };
            _truckModelRepository.Delete(truck);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestGetAllTrucksService()
        {
            var trucks = _truckModelService.GetList().ToList();
            Assert.IsNotNull(trucks.ToList());
        }

        [TestMethod]
        public void TestFindTruckService()
        {
            var truck = _truckModelService.Find(1);
            Assert.IsTrue(truck != null);
        }

        [TestMethod]
        public void TestUpdateTruckService()
        {
            var truck = new TruckModel { TruckModelId = 1, ModelDescription = "FH", Trucks = null };
            _truckModelService.Update(truck);
            var truckUpadated = db.Trucks.Find(1).NameTruck == "Test";
            Assert.IsTrue(truckUpadated);
        }

        [TestMethod]
        public void TestAddTruckService()
        {

            var truck = new TruckModel { ModelDescription = "FH", TruckModelId = 1 };
            _truckModelService.Add(truck);
            var truckInsert = db.Trucks.Find(2);
            Assert.IsNotNull(truckInsert);
        }

        [TestMethod]
        public void TestDeleteTruckService()
        {
            var truck = new TruckModel { ModelDescription = "FH", TruckModelId = 1 };
            _truckModelService.Delete(truck);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestGetAllTrucksApplication()
        {
            var trucks = _truckModelApplication.GetList().ToList();
            Assert.IsNotNull(trucks.ToList());
        }

        [TestMethod]
        public void TestFindTruckApplication()
        {
            var truck = _truckModelApplication.Find(1);
            Assert.IsTrue(truck != null);
        }

        [TestMethod]
        public void TestUpdateTruckApplication()
        {
            var truck = new TruckModel { ModelDescription = "FH", TruckModelId = 1 };
            _truckModelApplication.Update(truck);
            var truckUpadated = db.Trucks.Find(1).NameTruck == "Test";
            Assert.IsTrue(truckUpadated);
        }

        [TestMethod]
        public void TestAddTruckApplication()
        {
            var truck = new TruckModel { ModelDescription = "FH", TruckModelId = 1 };
            _truckModelApplication.Add(truck);
            var truckInsert = db.Trucks.Find(2);
            Assert.IsNotNull(truckInsert);
        }

        [TestMethod]
        public void TestDeleteTruckApplication()
        {
            var truck = new TruckModel { ModelDescription = "FH", TruckModelId = 1 };
            _truckModelApplication.Delete(truck);
            Assert.IsTrue(true);
        }
    }
}
