
using OTOMOTO.CORE.Entities;
using OTOMOTO.CORE.Interfaces;
using OTOMOTO.INFRASTRUCTURE.Data;
using System.Collections.Generic;
using System.Linq;

namespace OTOMOTO.INFRASTRUCTURE.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<AppUser> getAllUsers()
        {
            return _context.AppUsers.ToList();
        }

        public AppUser getById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(AppUser user)
        {
            throw new System.NotImplementedException();
        }
    }
}
