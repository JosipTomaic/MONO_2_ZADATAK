using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Models;
using Project.Service.DAL;
using System.Collections;
using Project.Service.ViewModels;
using PagedList;

namespace Project.Service.Interfaces
{
    public interface IVehicleService
    {
        void CreateVehicleMaker(VehicleMakeViewModel vehicleMaker);
        void UpdateVehicleMaker(VehicleMakeViewModel vehicleMaker);
        VehicleMakeViewModel FindVehicleMaker(Guid? id);
        void DeleteVehicleMaker(Guid? id);
        void CreateVehicleModel(VehicleModelViewModel vehicleModel);
        void UpdateVehicleModel(VehicleModelViewModel vehicleModel);
        VehicleModelViewModel FindVehicleModel(Guid? id);
        void DeleteVehicleModel(Guid? id);
        IPagedList SearchSortVehicleModel(string sortCondition, int? page, string searchCondition, string currentFilter);
        IPagedList SearchSortVehicleMaker(string sortCondition, int? page, string searchCondition, string currentFilter);
        //IPagedList SearchVehicleModel(string searchCondition, string currentFilter, int? page);
        //IPagedList SortVehicleMaker(string sortCondition, int? page);
        //IPagedList SearchVehicleMaker(string searchCondition, string currentFilter, int? page);
        List<VehicleMake> GetAllVehicleMake();
    }
}
