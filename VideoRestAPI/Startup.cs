using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VideoMenuBLL;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL.Context;

namespace VideoRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //services.AddDbContext<VideoAppContext>(opt => opt.UseSqlServer(Configuration["secretConnectString"]));
            VideoAppContext.ConnectionString = Configuration["secretConnectString"];

            //Enabling CORS.
            services.AddCors();

            //Making use of https.
            //services.Configure<MvcOptions>(options => { options.Filters.Add(new RequireHttpsAttribute()); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //var facade = new BllFacade();
                //var genreComedy = facade.GenreService.Create(new GenreBO { Name = "Comedy" });
                //var genreAction = facade.GenreService.Create(new GenreBO { Name = "Action" });

                //var video1 = facade.VideoService.Create(new VideoBO() { Name = "Bye Bye Birdie", GenreId = genreComedy.Id });
                //var video2 = facade.VideoService.Create(new VideoBO() { Name = "Skyfall", GenreId = genreAction.Id });

                //var user1 = facade.UserService.Create(new UserBO { Username = "user", Password = "user" });
                //var user2 = facade.UserService.Create(new UserBO { Username = "admin", Password = "admin" });

                //facade.ProfileService.Update(new ProfileBO {
                //    Id = user1.Id,
                //    FirstName = "User",
                //    LastName = "Profile",
                //    Address = "UserDrive"
                //});

                //facade.ProfileService.Update(new ProfileBO() {
                //    Id = user2.Id,
                //    FirstName = "Admin",
                //    LastName = "Profile",
                //    Address = "AdminDrive"
                //});

                //var rental1 = facade.RentalService.Create(new RentalBO {
                //    From = DateTime.Today.AddDays(-2.0),
                //    To = DateTime.Now.AddDays(3.0),
                //    UserId = user1.Id,
                //    VideoId = video1.Id

                //});
                //var rental2 = facade.RentalService.Create(new RentalBO {
                //    From = DateTime.Today.AddDays(-1.0),
                //    To = DateTime.Now.AddDays(2.0),
                //    UserId = user1.Id,
                //    VideoId = video2.Id
                //});
                //var rental3 = facade.RentalService.Create(new RentalBO {
                //    From = DateTime.Today,
                //    To = DateTime.Now.AddDays(5.0),
                //    UserId = user2.Id,
                //    VideoId = video2.Id
                //});
            }



            //Not recommended
            //app.UseCors(builder => builder.AllowAnyOrigin());

            //Allow PUT and DELETE http methods for the specified website.
            app.UseCors(builder => builder.WithOrigins("http://www.test-cors.org").AllowAnyMethod());

            app.UseMvc();
        }
    }
}