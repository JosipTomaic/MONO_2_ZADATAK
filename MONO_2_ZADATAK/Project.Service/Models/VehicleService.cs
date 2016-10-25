using Project.Service.Interfaces;
using Project.Service.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using PagedList;
using System.Collections;

namespace Project.Service.Models
{
    public class VehicleService : IVehicleService
    {
        private static VehicleService vehicleService;
        private VehicleContext db = new VehicleContext();
        private VehicleMake vehicleMake;
        private VehicleModel vehicleModel;
        private int page_size = 4;

        private VehicleService() { }
        public static VehicleService GetInstance()
        {
            if(vehicleService == null)
            {
                vehicleService = new VehicleService();
                return vehicleService;
            }
            else return vehicleService;
        }
        public void CreateVehicleMaker(VehicleMake vehicleMaker)
        {
            db.VehicleMakes.Add(vehicleMaker);
            db.SaveChanges();
        }

        public void CreateVehicleModel(VehicleModel vehicleModel)
        {
            db.VehicleModel.Add(vehicleModel);
            db.SaveChanges();
        }

        public VehicleMake FindVehicleMaker(int? id)
        {
            return vehicleMake = db.VehicleMakes.Find(id);
        }

        public VehicleModel FindVehicleModel(int? id)
        {
            return vehicleModel = db.VehicleModel.Find(id);
        }

        public void DeleteVehicleMaker(int? id)
        {
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            db.VehicleMakes.Remove(vehicleMake);
            db.SaveChanges();
        }

        public void DeleteVehicleModel(int? id)
        {
            VehicleModel vehicleModel = db.VehicleModel.Find(id);
            db.VehicleModel.Remove(vehicleModel);
            db.SaveChanges();
        }

        public void UpdateVehicleMaker(VehicleMake vehicleMaker)
        {
            db.Set<VehicleMake>().AddOrUpdate(vehicleMaker);
            db.SaveChanges();
        }

        public void UpdateVehicleModel(VehicleModel vehicleModel)
        {
            db.Set<VehicleModel>().AddOrUpdate(vehicleModel);
            db.SaveChanges();
        }

        public IEnumerable SortVehicleModel(string sortCondition, int? page)
        {
            IEnumerable vehicles_list;
            var vehicles = db.VehicleModel.AsQueryable();
            switch (sortCondition)
            {
                case "Name":
                    vehicles_list = vehicles.OrderBy(x => x.VehicleMake.Name).ToPagedList(page ?? 1, page_size);
                    break;
                case "Name_desc":
                    vehicles_list = vehicles.OrderByDescending(x => x.VehicleMake.Name).ToPagedList(page ?? 1, page_size);
                    break;
                case "Model":
                    vehicles_list = vehicles.OrderBy(x => x.Model).ToPagedList(page ?? 1, page_size);
                    break;
                case "Model_desc":
                    vehicles_list = vehicles.OrderByDescending(x => x.Model).ToPagedList(page ?? 1, page_size);
                    break;
                case "Abrv":
                    vehicles_list = vehicles.OrderBy(x => x.Abrv).ToPagedList(page ?? 1, page_size);
                    break;
                case "Abrv_desc":
                    vehicles_list = vehicles.OrderByDescending(x => x.Abrv).ToPagedList(page ?? 1, page_size);
                    break;
                default:
                    vehicles_list = vehicles.OrderBy(x => x.VModelID).ToPagedList(page ?? 1, page_size);
                    break;
            }
            return vehicles_list;
        }

        public IEnumerable SearchVehicleModel(string searchCondition, string currentFilter, int? page)
        {
            IEnumerable vehicles_list;
            var vehicles = db.VehicleModel.AsQueryable();
            if (searchCondition != null)
            {
                page = 1;
            }
            else
            {
                searchCondition = currentFilter;
            }
            vehicles_list = vehicles.Where(x => x.VehicleMake.Name.Contains(searchCondition) || x.Model.Contains(searchCondition)).OrderBy(x => x.VehicleMake.Name).ToPagedList(page ?? 1, page_size);
            return vehicles_list;
        }

        public IEnumerable SortVehicleMaker(string sortCondition, int? page)
        {
            IEnumerable vehicles_list;
            var vehicles = db.VehicleMakes.AsQueryable();
            switch (sortCondition)
            {
                case "Name":
                    vehicles_list = vehicles.OrderBy(x => x.Name).ToPagedList(page ?? 1, page_size);
                    break;
                case "Name_desc":
                    vehicles_list = vehicles.OrderByDescending(x => x.Name).ToPagedList(page ?? 1, page_size);
                    break;
                case "Abrv":
                    vehicles_list = vehicles.OrderBy(x => x.Abrv).ToPagedList(page ?? 1, page_size);
                    break;
                case "Abrv_desc":
                    vehicles_list = vehicles.OrderByDescending(x => x.Abrv).ToPagedList(page ?? 1, page_size);
                    break;
                default:
                    vehicles_list = vehicles.OrderBy(x => x.VMakeID).ToPagedList(page ?? 1, page_size);
                    break;
            }
            return vehicles_list;
        }

        public IEnumerable SearchVehicleMaker(string searchCondition, string currentFilter, int? page)
        {
            IEnumerable vehicles_list;
            var vehicles = db.VehicleMakes.AsQueryable();
            if (searchCondition != null)
            {
                page = 1;
            }
            else
            {
                searchCondition = currentFilter;
            }
            vehicles_list = vehicles.Where(x => x.Name.Contains(searchCondition)).OrderBy(x => x.Name).ToPagedList(page ?? 1, page_size);
            return vehicles_list;
        }

        public List<VehicleMake> GetAllVehicleMake()
        {
            List<VehicleMake> vehicleMakeList =  db.VehicleMakes.ToList();
            return vehicleMakeList;
        }
    }
}
