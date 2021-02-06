

using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OTOMOTO.CORE.Entities
{
    public class AppUser: IdentityUser
    {
  
        public string Address { get; set; }

        public ICollection<Car> cars { get; set; }
    }
}
