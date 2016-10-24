using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Models;

namespace Project.Service.DAL
{
    public class VehicleInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            var VehicleMakeList = new List<VehicleMake>
            {
                InsertToVehicleMake("Ferrari", "/"),
                InsertToVehicleMake("Porsche", "/"),
                InsertToVehicleMake("Ford", "/"),
                InsertToVehicleMake("Chevrolet", "/"),
                InsertToVehicleMake("Volkswagen", "VW"),
                InsertToVehicleMake("Pontiac", "/"),
                InsertToVehicleMake("Pagani", "/"),
                InsertToVehicleMake("Chrysler", "/"),
                InsertToVehicleMake("Lamborghini", "/")
            };
            VehicleMakeList.ForEach(x => context.VehicleMakes.Add(x));
            context.SaveChanges();

            var VehicleModelList = new List<VehicleModel>
            {
                InsertToVehicleModel(1, "LaFerrari", "/"),
                InsertToVehicleModel(1, "488 Gran Turismo Berlinetta","488GTB"),
                InsertToVehicleModel(2, "365", "/"),
                InsertToVehicleModel(2, "Carrera GT type 980", "/"),
                InsertToVehicleModel(3, "Mustang", "/"),
                InsertToVehicleModel(4, "Camaro", "/"),
                InsertToVehicleModel(4, "Impala 1967", "/"),
                InsertToVehicleModel(5, "Volkswagen III TD 1.9", "/"),
                InsertToVehicleModel(6, "GTO", "/"),
                InsertToVehicleModel(7, "Zonda", "/"),
                InsertToVehicleModel(8, "300C", "/"),
                InsertToVehicleModel(9, "Aventador", "/")
            };
            VehicleModelList.ForEach(x => context.VehicleModel.Add(x));
            context.SaveChanges();
        }

        public VehicleMake InsertToVehicleMake(string name, string abrv)
        {
            return new VehicleMake { Name = name, Abrv = abrv };
        }

        public VehicleModel InsertToVehicleModel(int vmakeid, string model, string abrv)
        {
            return new VehicleModel { VMakeID = vmakeid, Model = model, Abrv = abrv };
        }
    }
}
