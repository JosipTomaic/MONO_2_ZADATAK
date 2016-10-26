using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.ViewModels
{
    public class VehicleMakeViewModel
    {
        [Key]
        public Guid VMakeID { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
