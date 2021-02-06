using OTOMOTO.CORE.Entities;
using OTOMOTO.CORE.Interfaces;
using OTOMOTO.INFRASTRUCTURE.Data;


namespace OTOMOTO.INFRASTRUCTURE.Services
{
    public class PictureRepository : IPictureRepository
    {
        private readonly ApplicationDbContext _context;
        public PictureRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void add(Picture picture)
        {
           _context.Pictures.Add(picture);
            _context.SaveChanges();
        }

        
    }
}
