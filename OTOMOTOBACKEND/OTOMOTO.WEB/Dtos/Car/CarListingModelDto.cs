using OTOMOTO.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTOMOTO.WEB.Dtos.Car
{
    public class CarListingModelDto
    {
        public int id {get;set;}
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int MileAge { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string PicURL { get; set; }
        public string GearBox { get; set; }
        public string State { get; set; }
        public string Color { get; set; }
        public int Doors { get; set; }
        public string Logo { get; set; }




        public List<string> Pictures { get; set; }
    }
}
