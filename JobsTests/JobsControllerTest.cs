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
        //creating a list for the companies
        private List<Company> _company = new List<Company>();


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
            _company.Add(new Company
            {
                Id = 100,
                Name = "Mock Company",
                Location = "Barrie",
                FieldOfWork = "IT",
            });
            
            _company.Add(new Company
            {
                Id = 200,
                Name = "Mock Company 2",
                Location = "Kitchener",
                FieldOfWork = "Furniture",
            });

            _company.Add(new Company
            {
                Id = 300,
                Name = "Mock Company 3",
                Location = "Toronto",
                FieldOfWork = "Automotive",
            });

            foreach (var company in _company)
            {
                _context.Companies.Add(company);
            }

            //saving the changes
            _context.SaveChanges();

            _controller = new JobsController(_context);
        }

        [TestMethod]
        public void CreateReturnsCorrectView()
        {
            var controller = _controller;
            var result = (ViewResult)controller.Create();
            Assert.AreEqual("Create",result.ViewName);
        }
        [TestMethod]
        public void CreateIsNotNull()
        {
            var controller = _controller;
            var result = controller.Create();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CreateIsHavingRightInfoOnCompanies()
        {
            //this test checks that the company ID and Name is sent to the view
            var controller = _controller;
            var result = (ViewResult)controller.Create();
            var mockCompanies = new SelectList(_context.Companies, "Id", "Name");
            Assert.ReferenceEquals(mockCompanies,result.ViewData["CompanyID"]);
        }
    }
}
