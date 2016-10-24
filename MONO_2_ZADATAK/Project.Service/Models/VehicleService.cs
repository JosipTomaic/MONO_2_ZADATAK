using Project.Service.Interfaces;
using Project.Service.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Data.Entity;

namespace Project.Service.Models
{
    public class VehicleService : IVehicleService
    {
        private static VehicleService vehicleService;
        private VehicleContext db = new VehicleContext();
        private VehicleMake vehicleMake;
        private VehicleModel vehicleModel;

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
            db.Entry(vehicleMake).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdateVehicleModel(VehicleModel vehicleModel)
        {
            db.Entry(vehicleModel).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
