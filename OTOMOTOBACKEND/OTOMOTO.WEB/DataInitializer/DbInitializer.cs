

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OTOMOTO.CORE.Entities;
using OTOMOTO.INFRASTRUCTURE.Data;
using System.Collections.Generic;
using System.Linq;

namespace OTOMOTO.WEB.DataInitializer
{
    public class DbInitializer
    {
        public static void seedData(IApplicationBuilder applicationBuilder,UserManager<AppUser> userManager)
        {
            using (var servicescope=applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<ApplicationDbContext>();
                if(!context.AppUsers.Any())
                {
                    var user = new AppUser()
                    {
                        Id= "cf2da6d1-a82b-4a65-8ff6-f4480099b3f8",
                        UserName = "Admin",
                        Email = "Admin@gmail.com",
                        Address = "Poznan Poland",
                        PhoneNumber = "0048922889289"
                    };
                    context.AppUsers.Add(user);

                    userManager.CreateAsync(user,"Admin123@").Wait();
                }
            }

            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<ApplicationDbContext>();
                if (!context.Cars.Any())
                {
                    context.Cars.AddRange(
                        new Car() {
                           
                            Brand="Audi",Model="A6",Year=2018,MileAge=2000,Price=5000,
                            Description="Good State",
                            PicURL= "Audi-A6-1.png",
                            GearBox="Auto",State="Used",Color="Yellow",Doors=4,Logo="Audi.png",
                            UserId= "cf2da6d1-a82b-4a65-8ff6-f4480099b3f8",
                            Pictures=new List<Picture> { 
                                new Picture{
                                 Image="Audi-A6-2.png"
                                },
                                 new Picture{
                                 Image="Audi-A6-3.png"
                                },
                                  new Picture{
                                 Image="Audi-A6-4.png"
                                },
                                  new Picture{
                                 Image="Audi-A6-1.png"
                                }
                            }
                        },
                        new Car() {
                          
                            Brand="BMW",Model="I6",Year=2017,MileAge=3000,Price=6000,
                            Description="Good State",
                            PicURL= "BMW-I8-Standard-1.png",
                            GearBox="Auto",State="Used",Color="White",Doors=4,Logo="BMW.png",
                            UserId= "cf2da6d1-a82b-4a65-8ff6-f4480099b3f8",
                            Pictures = new List<Picture> {
                                new Picture{
                                 Image="BMW-I8-Standard-2.png"
                                },
                                 new Picture{
                                 Image="BMW-I8-Standard-3.png"
                                },
                                  new Picture{
                                 Image="BMW-I8-Standard-4.png"
                                },
                                  new Picture{
                                 Image="BMW-I8-Standard-1.png"
                                }
                            }
                        },
                        new Car() {
                            
                            Brand="BMW",Model="X7",Year=2018,MileAge=2000,Price=5000,
                            Description="Good State",
                            PicURL= "x7-B1.png",
                            GearBox="Auto",State="Used",Color="Black",Doors=4,Logo="BMW.png",
                            UserId= "cf2da6d1-a82b-4a65-8ff6-f4480099b3f8",
                            Pictures = new List<Picture> {
                                new Picture{
                                 Image="x7-B2.png"
                                },
                                 new Picture{
                                 Image="x7-B3.png"
                                },
                                  new Picture{
                                 Image="x7-B4.png"
                                },
                                  new Picture{
                                 Image="x7-B1.png"
                                }
                            }
                        },
                        new Car() {
                            
                            Brand="Audi",Model="Q5",Year=2018,MileAge=2000,Price=5000,
                            Description="Good State",
                            PicURL= "Audi-Q5-1.png",
                            GearBox="Auto",State="Used",Color="red",Doors=4,Logo="Audi.png",
                            UserId= "cf2da6d1-a82b-4a65-8ff6-f4480099b3f8",
                            Pictures = new List<Picture> {
                                new Picture{
                                 Image="Audi-Q5-2.png"
                                },
                                 new Picture{
                                 Image="Audi-Q5-3.png"
                                },
                                  new Picture{
                                 Image="Audi-Q5-4.png"
                                },
                                  new Picture{
                                 Image="Audi-Q5-1.png"
                                }
                            }
                        }

                        );
                    context.SaveChanges();


                }
            }


        }


    }
}
