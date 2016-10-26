using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Project.Service.Models;
using Project.Service.ViewModels;

namespace Project.MVC.App_Start
{

    static public class MapperConfig
    {
        public static void config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<VehicleMake, VehicleMakeViewModel>().ReverseMap();
                cfg.CreateMap<VehicleModel, VehicleModelViewModel>().ReverseMap();
            });
        }
    }
}