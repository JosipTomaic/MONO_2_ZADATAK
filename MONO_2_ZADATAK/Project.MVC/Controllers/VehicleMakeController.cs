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
    public class VehicleMakeController : Controller
    {
        private VehicleContext db = new VehicleContext();


        // GET: VehicleMake
        public ActionResult Index(string sortCondition, string currentFilter, string searchCondition, int? page)
        {
            ViewBag.CurrentSort = sortCondition;
            ViewBag.NameSortParm = sortCondition == "Name" ? "Name_desc" : "Name";
            var vehicles = VehicleService.GetInstance().SortVehicleMaker(sortCondition);
            if (searchCondition != null)
            {
                page = 1;
            }
            else
            {
                searchCondition = currentFilter;
            }
            ViewBag.CurrentFilter = searchCondition;

            if (!String.IsNullOrEmpty(searchCondition))
            {
                vehicles = VehicleService.GetInstance().SearchVehicleMaker(searchCondition);
            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(vehicles.ToPagedList(pageNumber, pageSize));
        }

        // GET: VehicleMake/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = VehicleService.GetInstance().FindVehicleMaker(id);
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
        public ActionResult Create([Bind(Include = "VMakeID,Name,Abrv")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                VehicleService.GetInstance().CreateVehicleMaker(vehicleMake);
                return RedirectToAction("Index");
            }

            return View(vehicleMake);
        }

        // GET: VehicleMake/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = VehicleService.GetInstance().FindVehicleMaker(id);
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
        public ActionResult Edit([Bind(Include = "VMakeID,Name,Abrv")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                VehicleService.GetInstance().UpdateVehicleMaker(vehicleMake);
                return RedirectToAction("Index");
            }
            return View(vehicleMake);
        }

        // GET: VehicleMake/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = VehicleService.GetInstance().FindVehicleMaker(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleService.GetInstance().DeleteVehicleMaker(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
