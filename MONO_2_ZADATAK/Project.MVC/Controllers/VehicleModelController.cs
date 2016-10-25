using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Service.DAL;
using Project.Service.Models;
using PagedList;

namespace Project.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        private VehicleService vehicleService;

        public VehicleModelController()
        {
            vehicleService = VehicleService.GetInstance();
        }

        // GET: VehicleModel
        public ActionResult Index(string sortCondition, string searchCondition, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortCondition;
            ViewBag.NameSortParm = sortCondition == "Name" ? "Name_desc" : "Name";
            ViewBag.ModelSortParm = sortCondition == "Model" ? "Model_desc" : "Model";
            ViewBag.AbrvSortParm = sortCondition == "Abrv" ? "Abrv_desc" : "Abrv";
            var vehicles = vehicleService.SortVehicleModel(sortCondition, page);
            ViewBag.CurrentFilter = searchCondition;

            if (!string.IsNullOrEmpty(searchCondition))
            {
                vehicles = vehicleService.SearchVehicleModel(searchCondition, currentFilter, page);
            }
            return View(vehicles);
        }

        // GET: VehicleModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = vehicleService.FindVehicleModel(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // GET: VehicleModel/Create
        public ActionResult Create()
        {
            ViewBag.VMakeID = vehicleService.GetAllVehicleMake();
            return View();
        }

        // POST: VehicleModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VModelID,VMakeID,Name,Model,Abrv")]VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                vehicleService.CreateVehicleModel(vehicleModel);
                return RedirectToAction("Index");
            }

            ViewBag.VMakeID = vehicleService.GetAllVehicleMake();
            return View(vehicleModel);
        }

        // GET: VehicleModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = vehicleService.FindVehicleModel(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.VMakeID = vehicleService.GetAllVehicleMake();
            return View(vehicleModel);
        }

        // POST: VehicleModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VModelID,VMakeID,Name,Model,Abrv")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                vehicleService.UpdateVehicleModel(vehicleModel);
                return RedirectToAction("Index");
            }
            ViewBag.VMakeID = vehicleService.GetAllVehicleMake();
            return View(vehicleModel);
        }

        // GET: VehicleModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = vehicleService.FindVehicleModel(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: VehicleModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehicleService.DeleteVehicleModel(id);
            return RedirectToAction("Index");
        }
    }
}
