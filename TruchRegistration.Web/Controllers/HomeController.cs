using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TruckRegistration.Application.Interfaces;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Web.ViewModels;

namespace TruckRegistration.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITruckApplication _truckApplication;
        private readonly ITruckModelApplication _truckModelApplication;
        public HomeController(ITruckApplication truckApplication, ITruckModelApplication truckModelApplication, IMapper mapper)
        {
            _truckModelApplication = truckModelApplication;
            _truckApplication = truckApplication;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var trucks = _truckApplication.GetTrucks();

            var trucksViewModel = _mapper.Map<IEnumerable<TruckViewModel>>(trucks);

            return View(trucksViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var truckViewModel = LoadTruckModelViewModel();

            return View(truckViewModel);
        }

        [HttpPost]
        public IActionResult Create(TruckViewModel truckViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var truck = _mapper.Map<Truck>(truckViewModel);
                    _truckApplication.Add(truck);

                    return RedirectToAction("Index");
                }

                truckViewModel = LoadTruckModelViewModel();
                return View(truckViewModel);
            }
            catch (System.Exception ex)
            {
                truckViewModel = LoadTruckModelViewModel();
                ViewBag.Message = "Error create new Truck";

                return View(truckViewModel);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var truck = _truckApplication.Find(id);

            var trucksViewModel = _mapper.Map<TruckViewModel>(truck);
            trucksViewModel.TruckModels = LoadData();

            return View(trucksViewModel);
        }

        [HttpPost]
        public IActionResult Edit(TruckViewModel truckViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var truck = _mapper.Map<Truck>(truckViewModel);
                    _truckApplication.Update(truck);
                    return RedirectToAction("Index");
                }

                ViewBag.Message = "Invalid edit truck";
                return View();
            }
            catch (System.Exception)
            {
                ViewBag.Message = "Error edit truck";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var truck = _truckApplication.Find(id);

            var trucksViewModel = _mapper.Map<TruckViewModel>(truck);
            trucksViewModel.TruckModels = LoadData();

            return View(trucksViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var truck = _truckApplication.Find(id);

            var trucksViewModel = _mapper.Map<TruckViewModel>(truck);
            trucksViewModel.TruckModels = LoadData();

            return View(trucksViewModel);
        }

        [HttpPost]
        public IActionResult Delete(TruckViewModel truckViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var truck = _mapper.Map<Truck>(truckViewModel);
                    _truckApplication.Delete(truck);
                    return RedirectToAction("Index");
                }

                ViewBag.Message = "Invalid delete truck";
                return View();
            }
            catch (System.Exception)
            {
                ViewBag.Message = "Error delete truck";
                return View();
            }
        }

        private IList<TruckModelViewModel> LoadData()
        {
            var getList = GetListTruckModel().ToList();

            var isNotLoadFH = getList.FirstOrDefault(it => it.ModelDescription == "FH") == null;
            var isNotLoadFM = getList.FirstOrDefault(it => it.ModelDescription == "FM") == null;

            if (isNotLoadFH)
                _truckModelApplication.Add(new TruckModel { ModelDescription = "FH" });

            if (isNotLoadFM)
                _truckModelApplication.Add(new TruckModel { ModelDescription = "FM" });

            var getLoad = (isNotLoadFH && isNotLoadFM) ? GetListTruckModel().ToList() : getList;

            return getLoad;
        }

        private IEnumerable<TruckModelViewModel> GetListTruckModel()
        {
            foreach (var item in _truckModelApplication.GetList())
            {
                yield return new TruckModelViewModel
                {
                    TruckModelId = item.TruckModelId,
                    ModelDescription = item.ModelDescription
                };
            }
        }

        private TruckViewModel LoadTruckModelViewModel() =>
            new TruckViewModel { TruckModels = LoadData() };
    }
}
