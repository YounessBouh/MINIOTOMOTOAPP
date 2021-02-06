

using Microsoft.AspNetCore.Http;
using OTOMOTO.CORE.Entities;
using System.Collections.Generic;

namespace OTOMOTO.WEB.Dtos.Car
{
    public class CarCreateDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int MileAge { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public IFormFile PicURL { get; set; }
        public string GearBox { get; set; }
        public string State { get; set; }
        public string Color { get; set; }
        public int Doors { get; set; }
        public string Logo { get; set; }

        public List<IFormFile> Pictures { get; set; }
    }
}
