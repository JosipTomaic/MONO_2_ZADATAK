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
        private VehicleContext db = new VehicleContext();

        // GET: VehicleModel
        public ActionResult Index(string sortCondition, string searchCondition, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortCondition;
            var vehicleModel = db.VehicleModel.Include(v => v.VehicleMake);
            ViewBag.ModelSortParm = String.IsNullOrEmpty(sortCondition) ? "Model_desc" : "";      
            ViewBag.AbrvSortParm = sortCondition == "Abrv" ? "Abrv_desc" : "Abrv";
            if (searchCondition != null)
            {
                page = 1;
            }
            else
            {
                searchCondition = currentFilter;
            }

            ViewBag.CurrentFilter = searchCondition;
            var vehicles = from x in db.VehicleModel select x;
            if (!String.IsNullOrEmpty(searchCondition))
            {
                vehicles = vehicles.Where(x => x.VehicleMake.Name.Contains(searchCondition) || x.Model.Contains(searchCondition));
            }
            switch (sortCondition)
            {
                case "Model_desc":
                    vehicles = vehicles.OrderByDescending(x => x.Model);
                    break;
                case "Abrv":
                    vehicles = vehicles.OrderBy(x => x.Abrv);
                    break;
                case "Abrv_desc":
                    vehicles = vehicles.OrderByDescending(x => x.Abrv);
                    break;
                default:
                    vehicles = vehicles.OrderBy(x => x.VModelID);
                    break;
            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(vehicles.ToPagedList(pageNumber, pageSize));
        }

        // GET: VehicleModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.VehicleModel.Find(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // GET: VehicleModel/Create
        public ActionResult Create()
        {
            ViewBag.VMakeID = new SelectList(db.VehicleMakes, "VMakeID", "Name");
            return View();
        }

        // POST: VehicleModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VModelID,VMakeID,Name,Abrv")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                db.VehicleModel.Add(vehicleModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VMakeID = new SelectList(db.VehicleMakes, "VMakeID", "Name", vehicleModel.VMakeID);
            return View(vehicleModel);
        }

        // GET: VehicleModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.VehicleModel.Find(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.VMakeID = new SelectList(db.VehicleMakes, "VMakeID", "Name", vehicleModel.VMakeID);
            return View(vehicleModel);
        }

        // POST: VehicleModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VModelID,VMakeID,Name,Abrv")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VMakeID = new SelectList(db.VehicleMakes, "VMakeID", "Name", vehicleModel.VMakeID);
            return View(vehicleModel);
        }

        // GET: VehicleModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.VehicleModel.Find(id);
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
            VehicleModel vehicleModel = db.VehicleModel.Find(id);
            db.VehicleModel.Remove(vehicleModel);
            db.SaveChanges();
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
