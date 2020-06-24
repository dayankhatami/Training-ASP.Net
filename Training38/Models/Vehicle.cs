using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training38.Models
{
    public class Vehicle
    {
        [Key]
        public string IdVehicle { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Wheel { get; set; }
        public string Color { get; set; }
        public string Fuel { get; set; }
        public Category Category { get; set; }
    }
}
public class Category
{
    [Key]
    public string IdCategory { get; set; }
    public string Title { get; set; }
}
