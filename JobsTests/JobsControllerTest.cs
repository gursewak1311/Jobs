using Jobs.Controllers;
using Jobs.Data;
using Jobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsTests
{
    [TestClass]
    public class JobsControllerTest
    //this is testing Create (GET) function
    {
        private JobsController _controller;
        private ApplicationDbContext _context;
        private Company _company;


        //will run before each test method
        [TestInitialize]
        public void TestInitialize()
        {
            // Mock db
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(dbOptions);

            // Mock company
            _company = new Company
            {
                Id = 100,
                Name = "Mock Company",
                Location = "Barrie",
                FieldOfWork = "IT",
            };
            _context.Companies.Add(_company);

            _company = new Company
            {
                Id = 200,
                Name = "Mock Company 2",
                Location = "Kitchener",
                FieldOfWork = "Furniture",
            };
            _context.Companies.Add(_company);

           //saving the changes
            _context.SaveChanges();

            _controller = new JobsController(_context);
        }

        [TestMethod]
        public void IndexReturnsCorrectView()
        {
            var controller = _controller;
            var result = (ViewResult)controller.Create();
            Assert.AreEqual("Create",result.ViewName);
        }
        [TestMethod]
        public void IndexIsNotNull()
        {
            var controller = _controller;
            var result = controller.Create();
            Assert.IsNotNull(result);
        }
    }
}
