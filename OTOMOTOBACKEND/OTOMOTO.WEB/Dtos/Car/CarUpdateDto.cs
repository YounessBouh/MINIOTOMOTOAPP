

using OTOMOTO.CORE.Entities;
using System.Collections.Generic;

namespace OTOMOTO.WEB.Dtos.Car
{
    public class CarUpdateDto
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Rok { get; set; }
        public int MileAge { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string PicURL { get; set; }
        public string GearBox { get; set; }
        public string Stan { get; set; }
        public string Color { get; set; }
        public int Doors { get; set; }
        public string Logo { get; set; }


        public AppUser appUser { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}
