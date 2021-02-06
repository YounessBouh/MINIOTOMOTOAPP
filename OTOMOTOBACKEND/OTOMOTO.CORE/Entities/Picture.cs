

using System.ComponentModel.DataAnnotations;

namespace OTOMOTO.CORE.Entities
{
    public class Picture
    {
        public int id { get; set; }
        public string Image { get; set; }

        [Required]
        public Car Car { get; set; }
    }
}
