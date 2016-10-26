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
using Project.Service.ViewModels;

namespace Project.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private VehicleService vehicleService;

        public VehicleMakeController()
        {
            this.vehicleService = VehicleService.GetInstance();
        }

        // GET: VehicleMake
        public ActionResult Index(string sortCondition, string currentFilter, string searchCondition, int? page)
        {
            ViewBag.CurrentSort = sortCondition;
            ViewBag.NameSortParm = sortCondition == "Name" ? "Name_desc" : "Name";
            ViewBag.AbrvSortParm = sortCondition == "Abrv" ? "Abrv_desc" : "Abrv";
            ViewBag.CurrentFilter = searchCondition;
            var vehicles = vehicleService.SearchSortVehicleMaker(sortCondition, page, searchCondition, currentFilter);
            
            return View(vehicles);
        }

        // GET: VehicleMake/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMakeViewModel vehicleMake = vehicleService.FindVehicleMaker(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // GET: VehicleMake/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMake/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VMakeID,Name,Abrv")] VehicleMakeViewModel vehicleMake)
        {
            if (ModelState.IsValid)
            {
                vehicleService.CreateVehicleMaker(vehicleMake);
                return RedirectToAction("Index");
            }

            return View(vehicleMake);
        }

        // GET: VehicleMake/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMakeViewModel vehicleMake = vehicleService.FindVehicleMaker(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMake/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VMakeID,Name,Abrv")] VehicleMakeViewModel vehicleMake)
        {
            if (ModelState.IsValid)
            {
                vehicleService.UpdateVehicleMaker(vehicleMake);
                return RedirectToAction("Index");
            }
            return View(vehicleMake);
        }

        // GET: VehicleMake/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMakeViewModel vehicleMake = vehicleService.FindVehicleMaker(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            vehicleService.DeleteVehicleMaker(id);
            return RedirectToAction("Index");
        }
    }
}
