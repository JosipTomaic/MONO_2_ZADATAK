using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Models;
using System.Collections;

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
        IEnumerable SortVehicleModel(string sortCondition, int? page);
        IEnumerable SearchVehicleModel(string searchCondition, string currentFilter, int? page);
        IEnumerable SortVehicleMaker(string sortCondition, int? page);
        IEnumerable SearchVehicleMaker(string searchCondition, string currentFilter, int? page);
        List<VehicleMake> GetAllVehicleMake();
    }
}
