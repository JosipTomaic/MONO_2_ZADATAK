using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Models;

namespace Project.Service.Interfaces
{
    public interface IVehicleService
    {
        void CreateVehicleMaker(VehicleMake vehicleMaker);
        void UpdateVehicleMaker(VehicleMake vehicleMaker);
        VehicleMake FindVehicleMaker(int? id);
        void DeleteVehicleMaker(int? id);
        void CreateVehicleModel(VehicleModel vehicleModel);
        void UpdateVehicleModel(VehicleModel vehicleModel);
        VehicleModel FindVehicleModel(int? id);
        void DeleteVehicleModel(int? id);
        List<VehicleModel> SortVehicleModel(string sortCondition);
        List<VehicleModel> SearchVehicleModel(string searchCondition);
        List<VehicleMake> SortVehicleMaker(string sortCondition);
        List<VehicleMake> SearchVehicleMaker(string searchCondition);
    }
}
