using Microsoft.VisualStudio.TestTools.UnitTesting;

using BeanSeans.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Xunit;
using System.Linq;
using SQLitePCL;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Assert = Xunit.Assert;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeanSeans.Areas.Administration.Tests
{

    public class StaffSittingControllerCreateActionTest: IDisposable

    {

        private readonly SignInManager<IdentityUser> sm;
        private readonly UserManager<IdentityUser> um;
        private readonly ApplicationDbContext _context;
        public StaffSittingControllerCreateActionTest()
        {
            var serviceProvider = new ServiceCollection()
                                     .AddEntityFrameworkInMemoryDatabase()
                                     .BuildServiceProvider();


            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                               .UseInternalServiceProvider(serviceProvider)
                               .UseInMemoryDatabase("_context")
                                .Options;

            _context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();

        }


        [Fact]
        public async Task GetCreateAction_ReturnView()
        {
            //Arrange
            var controller = new SittingController(sm, um, _context);
            //Act
            var result = await controller.Create();
            //Asser
            var view = result as ViewResult;
           

            Assert.NotNull(view);
         

        }


        [Fact]
        public async Task GetCreateAction_ConvertingToViewResult()
        {
            //Arrange
            var controller = new SittingController(sm, um, _context);
            //Act
            var result = await controller.Create() as ViewResult;
            

           
            Assert.IsType<ViewResult>(result);
            }



        [Fact]
        public async Task GetCreateAction_ViewBagNotNull()
        {
            //Arrange
            var controller = new SittingController(sm, um, _context);
            var result =await controller.Create();
            //Act
            var viewBag = controller.ViewBag.SittingTypeId;

            Assert.NotNull(viewBag);
        }

        [Fact]
        public async Task GetCreateAction_ReturnsSelectList()
        {
            //Arrange
            var controller = new SittingController(sm, um, _context);
            var result = await controller.Create();
            //Act
            var viewBag = controller.ViewBag.SittingTypeId;

            Assert.IsType<SelectList>(viewBag);
        }

        [Fact]
        public async Task GetCreateAction_ViewBagCount()
        {
            //Arrange
            var controller = new SittingController(sm, um, _context);
            var result = await controller.Create();
            //Act
            var viewBag =  controller.ViewBag.SittingTypeId;

            Assert.True(viewBag.count() > 0);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

    }
}