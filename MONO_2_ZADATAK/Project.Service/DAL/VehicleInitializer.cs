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
                InsertToVehicleMake(Guid.NewGuid(), "Ferrari", "/"),
                InsertToVehicleMake(Guid.NewGuid(), "Porsche", "/"),
                InsertToVehicleMake(Guid.NewGuid(), "Ford", "/"),
                InsertToVehicleMake(Guid.NewGuid(), "Chevrolet", "/"),
                InsertToVehicleMake(Guid.NewGuid(), "Volkswagen", "VW"),
                InsertToVehicleMake(Guid.NewGuid(), "Pontiac", "/"),
                InsertToVehicleMake(Guid.NewGuid(), "Pagani", "/"),
                InsertToVehicleMake(Guid.NewGuid(), "Chrysler", "/"),
                InsertToVehicleMake(Guid.NewGuid(), "Lamborghini", "/")
            };
            VehicleMakeList.ForEach(x => context.VehicleMakes.Add(x));
            context.SaveChanges();

            //var VehicleModelList = new List<VehicleModel> ZAŠTO OVO NE RADI?
            //{
            //    InsertToVehicleModel(Guid.NewGuid(), "LaFerrari", "/"),
            //    InsertToVehicleModel(Guid.NewGuid(), "488 Gran Turismo Berlinetta","488GTB"),
            //    InsertToVehicleModel(Guid.NewGuid(), "365", "/"),
            //    InsertToVehicleModel(Guid.NewGuid(), "Carrera GT type 980", "/"),
            //    InsertToVehicleModel(Guid.NewGuid(), "Mustang", "/"),
            //    InsertToVehicleModel(Guid.NewGuid(), "Camaro", "/"),
            //    InsertToVehicleModel(Guid.NewGuid(), "Impala 1967", "/"),
            //    InsertToVehicleModel(Guid.NewGuid(), "Volkswagen III TD 1.9", "/"),
            //    InsertToVehicleModel(Guid.NewGuid(), "GTO", "/"),
            //    InsertToVehicleModel(Guid.NewGuid(), "Zonda", "/"),
            //    InsertToVehicleModel(Guid.NewGuid(), "300C", "/"),
            //    InsertToVehicleModel(Guid.NewGuid(), "Aventador", "/")
            //};
            //VehicleModelList.ForEach(x => context.VehicleModel.Add(x));
            //context.SaveChanges();
            base.Seed(context);
        }

        public VehicleMake InsertToVehicleMake(Guid vmakeid, string name, string abrv)
        {
            return new VehicleMake { VMakeID = vmakeid ,Name = name, Abrv = abrv };
        }

        public VehicleModel InsertToVehicleModel(Guid vmakeid, string model, string abrv)
        {
            return new VehicleModel { VMakeID = vmakeid, Model = model, Abrv = abrv };
        }
    }
}
