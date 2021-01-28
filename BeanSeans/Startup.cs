using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using BeanSeans.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BeanSeans
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
            services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            //change to false
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
               .AddRoles<IdentityRole>() //add role
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //add service provider
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)//add service provider
        {

            app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyHeader());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
               name: "MyAPI",
               pattern: "{api:exists}/{controller=Reservations}/{action=GetReservations}/{email?}");

                endpoints.MapControllerRoute(
                name: "MyArea",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");



               
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

                CreateRoles(serviceProvider);
        }

        //to create role when the program starts
        private void CreateRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles
            //get roleManager
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var ctxt = serviceProvider.GetRequiredService<ApplicationDbContext>();

            //array of roles
            string[] roleNames = { "Member", "Staff", "Manager" };
            foreach (var roleName in roleNames)
            {

                //check role exisit
                Task<bool> roleExists = roleManager.RoleExistsAsync(roleName);
                roleExists.Wait();
                if (!roleExists.Result)//not exisit
                {

                    Task<IdentityResult> result = roleManager.CreateAsync(new IdentityRole(roleName));
                    result.Wait();
                }

            }
            //to make instance once program starts
            //if it is class, we can use dependency injection but not here
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var user = new IdentityUser { UserName = "ma@ma.com", Email = "ma@ma.com", PhoneNumber = "0000000000" };

            Task<IdentityResult> userCreateResult = userManager.CreateAsync(user, "1954duswN.");
            userCreateResult.Wait();

            if (userCreateResult.Result.Succeeded)//if succeeded to add user to systme
            {   //then add to emp which contain administra
                //manager is a staff and manager!!



                //logic here-add manager, staff for a default manager
                string[] managerRoles = { "Staff", "Manager" };

                foreach (var roleName in managerRoles)
                {

                    //check role exisit
                    Task<bool> roleExists = userManager.IsInRoleAsync(user, roleName);

                    roleExists.Wait();

                    if (!roleExists.Result)//not exisit
                    {

                        Task<IdentityResult> roleCreateResult = userManager.AddToRoleAsync(user, roleName);

                        roleCreateResult.Wait();
                    }

                }


                //
                var staff = new Staff
                {
                    FirstName = "Edward",
                    LastName = "Staff",
                    UserId = user.Id,//connect employee to ASPUser
                    RestuarantId = 1,
                    Phone = user.PhoneNumber,
                    Email = user.Email



                };


                //from serviceProvider we are getting appDB+manager
                ctxt.Staffs.Add(staff);
                ctxt.SaveChanges();

            }
            //creating memeber

            //creating default member to test
            var user2 = new IdentityUser { UserName = "m@m.com", Email = "m@m.com", PhoneNumber = "0000000001" };

            Task<IdentityResult> userCreateResult2 = userManager.CreateAsync(user2, "1954duswN.");
            userCreateResult2.Wait();

            if (userCreateResult2.Result.Succeeded)//if succeeded to add user to systme
            {//then add to emp which contain administra

                Task<IdentityResult> roleCreateResult2 = userManager.AddToRoleAsync(user2, "Member");
                roleCreateResult2.Wait();
                var member1 = new Member
                {
                    FirstName = "Alex",
                    LastName = "Jones",
                    UserId = user2.Id,//connect employee to ASPUser
                    RestuarantId = 1,
                    Phone = user2.PhoneNumber,
                    Email = user2.Email

                };

                //from serviceProvider we are getting appDB+manager
                ctxt.Members.Add(member1);


                ctxt.SaveChanges();
            }

        }
    }
}