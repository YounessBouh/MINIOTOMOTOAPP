
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OTOMOTO.CORE.Entities;
using OTOMOTO.CORE.Interfaces;
using OTOMOTO.WEB.Dtos.Car;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OTOMOTO.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _ICarRepo;
        private readonly IPictureRepository _IPicRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        public CarController(ICarRepository ICarRepo, UserManager<AppUser> userManager, 
                                                 IPictureRepository IPicRepo,
                                                 IHttpContextAccessor httpContextAccessor)
        {
            _ICarRepo = ICarRepo;
            _userManager = userManager;
            _IPicRepo = IPicRepo;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            var model = _ICarRepo.getAllCars().Select(p => new CarListingModelDto
            {
                id=p.Id,
                Brand = p.Brand,
                Model = p.Model,
                Year = p.Year,
                MileAge = p.MileAge,
                Price = p.Price,
                Description = p.Description,
                PicURL = p.PicURL,
                GearBox = p.GearBox,
                State = p.State,
                Color = p.Color,
                Doors = p.Doors,
                Logo = p.Logo,       

                Pictures = p.Pictures.Select(x => x.Image).ToList()
            }) ;
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {

            var car = _ICarRepo.getById(id);
            var user = getUser(car.UserId);

            if (car == null) return NotFound();
            var model = new CarIndexDto
            {
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                MileAge = car.MileAge,
                Price = car.Price,
                Description = car.Description,
                PicURL = car.PicURL,
                GearBox = car.GearBox,
                State = car.State,
                Color = car.Color,
                Doors = car.Doors,
                Logo = car.Logo,
                FullName= user.Result.UserName,
                Mobile=user.Result.PhoneNumber,
                Address=user.Result.Address,

                Pictures = car.Pictures.Select(x => x.Image).ToList()
            };


            return Ok(model);
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> add([FromForm]CarCreateDto car)
        {
            if(car.PicURL==null && car.Pictures.Count<=0)
            {
                return BadRequest();
            }

            var PicturesList = new List<Picture>();
            for (int x = 0; x < car.Pictures.Count; x++)
            {
                string picName = Guid.NewGuid().ToString() + Path.GetExtension(car.Pictures[x].FileName);
                // the oryginal Path==>  string Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", picName);
                string path = Path.Combine(@"C:\Users\User\Documents\Projects\AutoMoto-Clone\OTOMOTO\OTOMOTOFRONT\src\assets\Images", picName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    car.Pictures[x].CopyTo(stream);
                }
                var PicModel = new Picture
                {
                    Image = picName
                };
                PicturesList.Add(PicModel);
            }

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(car.PicURL.FileName);
            // the oryginal Path==>  string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", ImageName);
            string SavePath = Path.Combine(@"C:\Users\User\Documents\Projects\AutoMoto-Clone\OTOMOTO\OTOMOTOFRONT\src\assets\Images", ImageName);
            using (var stream = new FileStream(SavePath, FileMode.Create))
            {
                car.PicURL.CopyTo(stream);
            }

            if (car == null) return NotFound();
            var model = new Car {
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                MileAge = car.MileAge,
                Price = car.Price,
                Description = car.Description,
                PicURL = ImageName,
                GearBox = car.GearBox,
                State = car.State,
                Color = car.Color,
                Doors = car.Doors,
                Logo = car.Logo,
                appUser = await _userManager.FindByIdAsync(userId),
                 Pictures=PicturesList
              };
             var carId=  await _ICarRepo.add(model);
           

            return Ok("added");
        }

        [Authorize]
        [HttpDelete("Delete/{id}")]
        public IActionResult Remove(int id)
        {
            var model = _ICarRepo.getById(id);
            if (model == null) return NotFound();
            _ICarRepo.remove(id);
            return Ok();
        }

        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(CarUpdateDto car)
        {
            if (car == null) return NotFound();
            var model = new Car
            {
                Brand = car.Marka,
                Model = car.Model,
                Year = car.Rok,
                MileAge = car.MileAge,
                Price = car.Price,
                Description = car.Description,
                PicURL = car.PicURL,
                GearBox = car.GearBox,
                State = car.Stan,
                Color = car.Color,
                Doors = car.Doors,
                Logo = car.Logo,

                Pictures = car.Pictures
            };
           await _ICarRepo.Update(model);
            return Ok();
            
        }

        private async Task<AppUser> getUser(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
    }
}
