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
    public class TruckApplicationTest
    {
        private readonly DbContextOptions<TruckRegistrationContext> options = new DbContextOptions<TruckRegistrationContext>();
        private TruckRegistrationContext db;
        private ITruckApplication _truckApplication;
        private ITruckService _truckService;
        private ITruckRepository _truckRepository;

        [TestInitialize]
        public void Initalize()
        {
            db = new TruckRegistrationContext(options: options);
            _truckRepository = new TruckRepository(db);
            _truckService = new TruckService(_truckRepository);
            _truckApplication = new TruckApplication(_truckService);

            LoadData();
        }

        public void LoadData()
        {
            db.Trucks.Add(new Truck { NameTruck = "", TruckId = 1, TruckModelId = 1, YearManufacture = 2020, YearModel = 2021 });
            db.SaveChanges();
        }

        [TestMethod]
        public void TestGetAllTrucksRepository()
        {
            var trucks = _truckRepository.GetList().ToList();
            Assert.IsNotNull(trucks.ToList());
        }

        [TestMethod]
        public void TestGetTrucksRepository()
        {
            var trucks = _truckRepository.GetTrucks().ToList();
            Assert.IsNotNull(trucks.ToList());
        }

        [TestMethod]
        public void TestFindTruckRepository()
        {
            var truck = _truckRepository.Find(1);
            Assert.IsTrue(truck != null);
        }

        [TestMethod]
        public void TestUpdateTruckRepository()
        {
            var truck = new Truck { NameTruck = "Test", TruckId = 1, TruckModelId = 1, YearManufacture = 2020, YearModel = 2021 };
            _truckRepository.Update(truck);
            var truckUpadated = db.Trucks.Find(1).NameTruck == "Test";
            Assert.IsTrue(truckUpadated);
        }

        [TestMethod]
        public void TestAddTruckRepository()
        {
            var truck = new Truck { Model = new TruckModel { ModelDescription = "FH", TruckModelId = 1 }, NameTruck = "Test", TruckId = 2, TruckModelId = 1, YearManufacture = 2020, YearModel = 2021 };
            _truckRepository.Add(truck);
            var truckInsert = db.Trucks.Find(2);
            Assert.IsNotNull(truckInsert);
        }

        [TestMethod]
        public void TestDeleteTruckRepository()
        {
            var truck = new Truck { NameTruck = "", TruckId = 1, TruckModelId = 1, YearManufacture = 2020, YearModel = 2021 };
            _truckRepository.Delete(truck);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestGetAllTrucksService()
        {
            var trucks = _truckService.GetList().ToList();
            Assert.IsNotNull(trucks.ToList());
        }

        [TestMethod]
        public void TestGetTrucksService()
        {
            var trucks = _truckService.GetTrucks().ToList();
            Assert.IsNotNull(trucks.ToList());
        }

        [TestMethod]
        public void TestFindTruckService()
        {
            var truck = _truckService.Find(1);
            Assert.IsTrue(truck != null);
        }

        [TestMethod]
        public void TestUpdateTruckService()
        {
            var a = db.Trucks.Add(new Truck { NameTruck = "Test", TruckId = 1, TruckModelId = 1, YearManufacture = 2020, YearModel = 2021 });

            var truck = new Truck { NameTruck = "Test", TruckId = 1, TruckModelId = 1, YearManufacture = 2020, YearModel = 2021 };
            _truckService.Update(truck);
            var truckUpadated = db.Trucks.Find(1).NameTruck == "Test";
            Assert.IsTrue(truckUpadated);
        }

        [TestMethod]
        public void TestAddTruckService()
        {
            var truck = new Truck { Model = new TruckModel { ModelDescription = "FH", TruckModelId = 1 }, NameTruck = "Test", TruckId = 2, TruckModelId = 1, YearManufacture = 2020, YearModel = 2021 };
            _truckService.Add(truck);
            var truckInsert = db.Trucks.Find(2);
            Assert.IsNotNull(truckInsert);
        }

        [TestMethod]
        public void TestDeleteTruckService()
        {
            var truck = new Truck { NameTruck = "", TruckId = 1, TruckModelId = 1, YearManufacture = 2020, YearModel = 2021 };
            _truckService.Delete(truck);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestGetAllTrucksApplication()
        {
            var trucks = _truckApplication.GetList().ToList();
            Assert.IsNotNull(trucks.ToList());
        }

        [TestMethod]
        public void TestGetTrucksApplication()
        {
            var trucks = _truckApplication.GetTrucks().ToList();
            Assert.IsNotNull(trucks.ToList());
        }

        [TestMethod]
        public void TestFindTruckApplication()
        {
            var truck = _truckApplication.Find(1);
            Assert.IsTrue(truck != null);
        }

        [TestMethod]
        public void TestUpdateTruckApplication()
        {
            var truck = new Truck { NameTruck = "Test", TruckId = 1, TruckModelId = 1, YearManufacture = 2020, YearModel = 2021 };
            _truckApplication.Update(truck);
            var truckUpadated = db.Trucks.Find(1).NameTruck == "Test";
            Assert.IsTrue(truckUpadated);
        }

        [TestMethod]
        public void TestAddTruckApplication()
        {
            var truck = new Truck { Model = new TruckModel { ModelDescription = "FH", TruckModelId = 1 }, NameTruck = "Test", TruckId = 2, TruckModelId = 1, YearManufacture = 2020, YearModel = 2021 };
            _truckApplication.Add(truck);
            var truckInsert = db.Trucks.Find(2);
            Assert.IsNotNull(truckInsert);
        }

        [TestMethod]
        public void TestDeleteTruckApplication()
        {
            var truck = new Truck { NameTruck = "", TruckId = 1, TruckModelId = 1, YearManufacture = 2020, YearModel = 2021 };
            _truckApplication.Delete(truck);
            Assert.IsTrue(true);
        }
    }
}
