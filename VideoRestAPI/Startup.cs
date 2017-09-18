using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VideoMenuBLL;
using VideoMenuBLL.BusinessObjects;

namespace VideoRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var facade = new BllFacade();
                facade.VideoService.Create(new VideoBO(){Name = "Bye Bye Birdie", Genre = EGenreBO.Comedy});
                facade.VideoService.Create(new VideoBO(){Name = "Skyfall", Genre = EGenreBO.Action});

                var user1 = facade.UserService.Create(new UserBO {Username = "user", Password = "user"});
                var user2 = facade.UserService.Create(new UserBO {Username = "admin", Password = "admin"});

                facade.ProfileService.Update(new ProfileBO
                {
                    Id = user1.Id,
                    FirstName = "User",
                    LastName = "Profile",
                    Address = "UserDrive"
                });

                facade.ProfileService.Update(new ProfileBO()
                {
                    Id = user2.Id,
                    FirstName = "Admin",
                    LastName = "Profile",
                    Address = "AdminDrive"
                });

                facade.RentalService.Create(new RentalBO {From = DateTime.Today.AddDays(-2.0), To = DateTime.Now.AddDays(3.0)});
                facade.RentalService.Create(new RentalBO {From = DateTime.Today.AddDays(-1.0), To = DateTime.Now.AddDays(2.0)});
                facade.RentalService.Create(new RentalBO {From = DateTime.Today, To = DateTime.Now.AddDays(5.0)});
                
            }

            app.UseMvc();
        }
    }
}
