using OTOMOTO.CORE.Entities;
using System.Collections.Generic;


namespace OTOMOTO.CORE.Interfaces
{
   public  interface IUserRepository
    {
        IEnumerable<AppUser> getAllUsers();
        AppUser getById(int id);
        void Remove(int id);
        void Update(AppUser user);
    }
}
