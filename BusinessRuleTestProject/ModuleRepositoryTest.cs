using BusinessRuleApplication.Models;
using BusinessRuleApplication.RepositoryPattern;
using Microsoft.EntityFrameworkCore;

using Moq;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace BusinessRuleTestProject
{
    public class ModuleRepositoryTest
    {
        // private BusinessRulesDataEngineContext _dbContext;
        // private IModulesRepository _testDatabaseStrategy;
        //private ModulesRepository modulesRepository;
        // private IAdventureWorksDbContext _context;
        //public  ModuleRepositoryTest()
        //{
        //    Mock<IModulesRepository> modulesRepository = new Mock<IModulesRepository>();
        //}
        IModulesRepository moduleRepository;
        public ModuleRepositoryTest()
        {
             moduleRepository = GetModulesRepository();
        }
        private IModulesRepository GetModulesRepository()
        {
            
            BusinessRulesDataEngineContext context = new BusinessRulesDataEngineContext();
           
            return new ModulesRepository(context);
        }
        [Fact]
        public async Task InsertModuleTest()
        {
            try
            {
                //Modules module1 = new Modules { Name = "Physical Product" };
                //Mock<IModulesRepository> modulesRepository = new Mock<ModulesRepository>();
                //var result1 = modulesRepository.Setup(r => r.InsertModule(module1));
                //Assert.True(Convert.ToInt32(result1) > 0, "The DataSved Successfully !!");
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
                IModulesRepository moduleRepository = GetModulesRepository();
                //  _moduleRepository = moduleRepository.;
                //  var moduleRepository = new Mock<IModulesRepository>(context) { CallBase = true };

                //   Mock<IModulesRepository> moduleRepository = new Mock<IModulesRepository>();
                //moduleRepository = new Mock<ModulesRepository<context>>();
                //var moq = new Mock<IModulesRepository>();
                // moq.
                Modules module = new Modules { Name = "Physical Product" };
                var result = await moduleRepository.InsertModule(module);
               // Assert.Equal("Blogs", savedPerson.Surname);
                //var result = moduleRepository.Setup(foo => foo.InsertModule(module));
                Assert.True(Convert.ToInt32(result) > 0, "The DataSved Successfully !!");
            }
            catch(Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsType<InvalidOperationException>(ex);
            }

            //Assert.f(Convert.ToInt32(result) > 0, "The DataSved Successfully !!");
            
            // moduleRepository.in(module);
            //  var result = moduleRepository



        }
        [Fact]
        public async Task ModulenameExistsTest()
        {
           

            string moduleNameThatShouldExist = "Physical Producn";
            // string modulenameThatShouldNotExist = "benday2";
            var result = await moduleRepository.IsModuleExists(moduleNameThatShouldExist);
            Assert.True(
            result == true,
                "Module name is exist.");

            Assert.False(
           result == false,
                "Module name should not exist.");
        }

        [Fact]
        public async Task GetModulesTest()
        {
            // IModulesRepository moduleRepository = GetModulesRepository();
            var mockRepo = new Mock<IModulesRepository>();
            mockRepo.Setup(x => x.GetModules());

            var companyObject = new ModulesRepository(new BusinessRulesDataEngineContext());
            var retrnData = companyObject.GetModules();

            //var mockedCtxVolunteer = new Mock<IModulesRepository>();
            //mockedCtxVolunteer.Setup(m => m.GetModules());
            //var result = await moduleRepository.GetModules();
            Assert.True(Convert.ToInt32(retrnData) > 0, "The Data Populated Successfully !!");
        }
    }
}
