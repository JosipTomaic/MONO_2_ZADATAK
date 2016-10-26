using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.ViewModels
{
    public class VehicleModelViewModel
    {
        [Key]
        public Guid VModelID { get; set; }
        public Guid VMakeID { get; set; }
        public string Model { get; set; }
        public string Abrv { get; set; }

        public virtual VehicleMakeViewModel VehicleMake { get; set; }
    }
}
