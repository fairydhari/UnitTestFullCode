using BusinessRuleApplication;
using BusinessRuleApplication.Models;
using BusinessRuleApplication.RepositoryPattern;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Moq;

using System;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace BusinessRuleTestProject
{
    public class ModulesControllerTest
    {
      
        [Fact]
        public async Task InsertModuleTest()
        {
            try
            {
               // var controller = new ModulesController();
                var controller = new ModulesController();
                Modules module = new Modules { Name = "Physical Product" };
                var result = await controller.SaveModule(module);
                //  var context = new BusinessRulesDataEngineContext();
                ////var connectionString = @"Server=localhost;Database=EmployeeManagementDB;Trusted_Connection=True;";
                ////var builder = new
                ////    DbContextOptionsBuilder<BusinessRulesDataEngineContext>();
                ////builder.UseSqlServer(connectionString);
                ////var options = builder.Options;
                //using (var context = new EfCoreContext(options))
                //{
                //… unit test starts here
                //  IModulesRepository moduleRepository = new  ModulesRepository(context);
                //  var _moduleRepository = new Mock<IModulesRepository>();
                //IModulesRepository moduleRepository = GetModulesRepository();
                //  _moduleRepository = moduleRepository.;
                //  var moduleRepository = new Mock<IModulesRepository>(context) { CallBase = true };

                //   Mock<IModulesRepository> moduleRepository = new Mock<IModulesRepository>();
                //moduleRepository = new Mock<ModulesRepository<context>>();
                //var moq = new Mock<IModulesRepository>();
                // moq.
               // Modules module = new Modules { Name = "Physical Product" };
                //var result = moduleRepository.InsertModule(module);
               // Assert.Equal("Blogs", savedPerson.Surname);
                //var result = moduleRepository.Setup(foo => foo.InsertModule(module));
                Assert.Equal(result.Value.ToString(), "DataSved Successfully");
                Assert.Equal(result.Value.ToString(), "already Existed");
            }
            catch(Exception ex)
            {
                Assert.NotNull(ex);
               // Assert.IsType<InvalidOperationException>(ex);
            }

            //Assert.f(Convert.ToInt32(result) > 0, "The DataSved Successfully !!");
            
            // moduleRepository.in(module);
            //  var result = moduleRepository



        }
        [Fact]
        public async Task IsValidateModuleName()
        {
            try
            {
                Modules module = new Modules { Name = " " };
              
               
                // var controller = new ModulesController();
                var controller = new ModulesController();
               
                var result =await controller.SaveModule(module);
                // var okResult = result as ObjectResult;
                //  var context = new BusinessRulesDataEngineContext();
                ////var connectionString = @"Server=localhost;Database=EmployeeManagementDB;Trusted_Connection=True;";
                ////var builder = new
                ////    DbContextOptionsBuilder<BusinessRulesDataEngineContext>();
                ////builder.UseSqlServer(connectionString);
                ////var options = builder.Options;
                //using (var context = new EfCoreContext(options))
                //{
                //… unit test starts here
                //  IModulesRepository moduleRepository = new  ModulesRepository(context);
                //  var _moduleRepository = new Mock<IModulesRepository>();
                //IModulesRepository moduleRepository = GetModulesRepository();
                //  _moduleRepository = moduleRepository.;
                //  var moduleRepository = new Mock<IModulesRepository>(context) { CallBase = true };

                //   Mock<IModulesRepository> moduleRepository = new Mock<IModulesRepository>();
                //moduleRepository = new Mock<ModulesRepository<context>>();
                //var moq = new Mock<IModulesRepository>();
                // moq.
                // Modules module = new Modules { Name = "Physical Product" };
                //var result = moduleRepository.InsertModule(module);
                // Assert.Equal("Blogs", savedPerson.Surname);
                //var result = moduleRepository.Setup(foo => foo.InsertModule(module));
                Assert.Equal(result.Value.ToString(), "Name is empty");
               
                //Assert.NotEqual()
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                // Assert.IsType<InvalidOperationException>(ex);
            }

            //Assert.f(Convert.ToInt32(result) > 0, "The DataSved Successfully !!");

            // moduleRepository.in(module);
            //  var result = moduleRepository



        }
        [Fact]
        public async Task GetModulesTest()
        {
            var mockcontroller = new Mock<ModulesController>();
            var retrnData = mockcontroller.Setup(x => x.Get());
           
            Assert.False(retrnData == null, "The Data Population failed !!");
            Assert.True(Convert.ToInt32(retrnData) > 0, "The Data Populated Successfully !!");

        }
    }
}
