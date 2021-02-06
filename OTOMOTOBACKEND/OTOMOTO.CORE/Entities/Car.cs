

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OTOMOTO.CORE.Entities
{
   public class Car
    {

        public int Id{ get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int MileAge { get; set; }
        public double Price  { get; set; }
        public string Description { get; set; }
        public string PicURL { get; set; }
        public string GearBox { get; set; }
        public string State { get; set; }
        public string Color { get; set; }
        public int Doors { get; set; }
        public string Logo { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser appUser { get; set; }


        public ICollection<Picture> Pictures { get; set; }
    }
}
