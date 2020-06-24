using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Training38.ViewModels
{
    public class Vehicle
    {
        [Required(ErrorMessage = "Nama Tidak Boleh Kosong")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Wheel { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Category { get; set; }
        public string Fuel { get; set; }
    }
    public class EditVehicle
    {
        public string IdVehicle { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Wheel { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
        public string Fuel { get; set; }
    }
}