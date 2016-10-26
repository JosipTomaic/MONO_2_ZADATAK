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
using Project.Service.ViewModels;
using AutoMapper;

namespace Project.Service.Models
{
    public class VehicleService : IVehicleService
    {
        private static VehicleService vehicleService;
        private VehicleContext db = new VehicleContext();
        private VehicleMakeViewModel vehicleMake;
        private VehicleModelViewModel vehicleModel;
        private int page_size = 4;
        IPagedList vehicles_list;

        private VehicleService() { }
        public static VehicleService GetInstance()
        {
            if (vehicleService == null)
            {
                vehicleService = new VehicleService();
                return vehicleService;
            }
            else return vehicleService;
        }
        public void CreateVehicleMaker(VehicleMakeViewModel vehicleMaker)
        {

            db.VehicleMakes.Add(Mapper.Map<VehicleMake>(vehicleMaker));
            db.SaveChanges();
        }

        public void CreateVehicleModel(VehicleModelViewModel vehicleModel)
        {
            db.VehicleModel.Add(Mapper.Map<VehicleModel>(vehicleModel));
            db.SaveChanges();
        }

        public VehicleMakeViewModel FindVehicleMaker(Guid? id)
        {
            return vehicleMake = Mapper.Map<VehicleMake, VehicleMakeViewModel>(db.VehicleMakes.Find(id));
        }

        public VehicleModelViewModel FindVehicleModel(Guid? id)
        {
            return vehicleModel = Mapper.Map<VehicleModel, VehicleModelViewModel>(db.VehicleModel.Find(id));
        }

        public void DeleteVehicleMaker(Guid? id)
        {
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            db.VehicleMakes.Remove(vehicleMake);
            db.SaveChanges();
        }

        public void DeleteVehicleModel(Guid? id)
        {
            VehicleModel vehicleModel = db.VehicleModel.Find(id);
            db.VehicleModel.Remove(vehicleModel);
            db.SaveChanges();
        }

        public void UpdateVehicleMaker(VehicleMakeViewModel vehicleMaker)
        {
            db.Set<VehicleMake>().AddOrUpdate(Mapper.Map<VehicleMake>(vehicleMaker));
            db.SaveChanges();
        }

        public void UpdateVehicleModel(VehicleModelViewModel vehicleModel)
        {
            db.Set<VehicleModel>().AddOrUpdate(Mapper.Map<VehicleModel>(vehicleModel));
            db.SaveChanges();
        }

        public IPagedList SearchSortVehicleModel(string sortCondition, int? page, string searchCondition, string currentFilter)
        {
            var vehicles = db.VehicleModel.AsQueryable();

            if (searchCondition == null || searchCondition.Equals(""))
            {
                searchCondition = currentFilter;
                vehicles = db.VehicleModel.AsQueryable();
            }
            else
            {
                page = 1;
                vehicles = db.VehicleModel.Where(x => x.VehicleMake.Name.Contains(searchCondition) || x.Model.Contains(searchCondition));
            }
            //vehicles_list = Mapper.Map<IEnumerable<VehicleModelViewModel>>(vehicles.Where(x => x.VehicleMake.Name.Contains(searchCondition) || x.Model.Contains(searchCondition)).OrderBy(x => x.VehicleMake.Name)).ToPagedList(page ?? 1, page_size);

            switch (sortCondition)
            {
                case "Name":
                    vehicles_list = Mapper.Map<IEnumerable<VehicleModelViewModel>>(vehicles.OrderBy(x => x.VehicleMake.Name)).ToPagedList(page ?? 1, page_size);
                    break;
                case "Name_desc":
                    vehicles_list = Mapper.Map<IEnumerable<VehicleModelViewModel>>(vehicles.OrderByDescending(x => x.VehicleMake.Name)).ToPagedList(page ?? 1, page_size);
                    break;
                case "Model":
                    vehicles_list = Mapper.Map<IEnumerable<VehicleModelViewModel>>(vehicles.OrderBy(x => x.Model)).ToPagedList(page ?? 1, page_size);
                    break;
                case "Model_desc":
                    vehicles_list = Mapper.Map<IEnumerable<VehicleModelViewModel>>(vehicles.OrderByDescending(x => x.Model)).ToPagedList(page ?? 1, page_size);
                    break;
                case "Abrv":
                    vehicles_list = Mapper.Map<IEnumerable<VehicleModelViewModel>>(vehicles.OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, page_size);
                    break;
                case "Abrv_desc":
                    vehicles_list = Mapper.Map<IEnumerable<VehicleModelViewModel>>(vehicles.OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, page_size);
                    break;
                default:
                    vehicles_list = Mapper.Map<IEnumerable<VehicleModelViewModel>>(vehicles.OrderBy(x => x.Model)).ToPagedList(page ?? 1, page_size);
                    break;
            }
            return vehicles_list;
        }
        public IPagedList SearchSortVehicleMaker(string sortCondition, int? page, string searchCondition, string currentFilter)
        {
            var vehicles = db.VehicleMakes.AsQueryable();

            if (searchCondition == null || searchCondition.Equals(""))
            {
                searchCondition = currentFilter;
                vehicles = db.VehicleMakes.AsQueryable();
            }
            else
            {
                page = 1;
                vehicles = db.VehicleMakes.Where(x => x.Name.Contains(searchCondition));
            }
            //vehicles_list = Mapper.Map<IEnumerable<VehicleMakeViewModel>>(vehicles.Where(x => x.Name.Contains(searchCondition)).OrderBy(x => x.Name)).ToPagedList(page ?? 1, page_size);

            switch (sortCondition)
            {
                case "Name":
                    vehicles_list = Mapper.Map<IEnumerable<VehicleMakeViewModel>>(vehicles.OrderBy(x => x.Name)).ToPagedList(page ?? 1, page_size);
                    break;
                case "Name_desc":
                    vehicles_list = Mapper.Map<IEnumerable<VehicleMakeViewModel>>(vehicles.OrderByDescending(x => x.Name)).ToPagedList(page ?? 1, page_size);
                    break;
                case "Abrv":
                    vehicles_list = Mapper.Map<IEnumerable<VehicleMakeViewModel>>(vehicles.OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, page_size);
                    break;
                case "Abrv_desc":
                    vehicles_list = Mapper.Map<IEnumerable<VehicleMakeViewModel>>(vehicles.OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, page_size);
                    break;
                default:
                    vehicles_list = Mapper.Map<IEnumerable<VehicleMakeViewModel>>(vehicles.OrderBy(x => x.VMakeID)).ToPagedList(page ?? 1, page_size);
                    break;
            }
            return vehicles_list;
        }

        //public IPagedList SearchVehicleModel(string searchCondition, string currentFilter, int? page)
        //{
        //    var vehicles = db.VehicleModel;

        //    return vehicles_list;
        //}

        //public IPagedList SortVehicleMaker(string sortCondition, int? page, )
        //{
        //    var vehicles = db.VehicleMakes;

        //    return vehicles_list;
        //}

        //public IPagedList SearchVehicleMaker(string searchCondition, string currentFilter, int? page)
        //{

        //    return vehicles_list;
        //}

        public List<VehicleMake> GetAllVehicleMake()
        {
            List<VehicleMake> vehicleMakeList =  db.VehicleMakes.ToList();
            return vehicleMakeList;
        }
    }
}
