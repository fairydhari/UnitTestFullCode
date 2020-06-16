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
    public class MemberShipRepositoryTest
    {
        
        IMemberShipRepository memberShipRepository;
        public MemberShipRepositoryTest()
        {
            memberShipRepository = GetMembershipRepository();
        }
        private IMemberShipRepository GetMembershipRepository()
        {
            
            BusinessRulesDataEngineContext context = new BusinessRulesDataEngineContext();
           
            return new MemberShipRepository(context);
        }
        [Fact]
        public async Task ActivateMemberShipTest()
        {
            try
            {             
      
        MemberShip memberShip = new MemberShip { Name = "Test",Email="test@gmail.com", ActiveDate=DateTime.Now, DeactiveDate= DateTime.Now.AddMonths(1), IsActive=true };
                var result = await memberShipRepository.ActivateMemberShip(memberShip);              
                Assert.True(Convert.ToInt32(result) > 0, "The DataSved Successfully !!");
            }
            catch(Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsType<InvalidOperationException>(ex);
            }         

        }
        [Fact]
        public async Task IsMembershipExistsTest()
        { 
            var result = await memberShipRepository.IsMembershipExists("test@gmail.com");
            Assert.True(
            result == true,
                "member is exist.");

            Assert.False(
           result == false,
                "member should not exist.");
        }
        [Fact]
        public async Task UpGradeMemberShip()
        {
            try
            {
                MemberShip memberShip = new MemberShip {MembershipId=1, Name = "Test", Email = "test@gmail.com", ActiveDate = DateTime.Now, DeactiveDate = DateTime.Now.AddMonths(1), IsActive = true };
                var result = await memberShipRepository.UpGradeMemberShip(memberShip);
                Assert.True(result==true, "The Data updated Successfully !!");
                Assert.False(
          result == false,
               "updation failed.");
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsType<InvalidOperationException>(ex);
            }

        }
        [Fact]
        public async Task UpGradeMemberShipEmailTest()
        {
            // IModulesRepository moduleRepository = GetModulesRepository();
            var mockRepo = new Mock<IMemberShipRepository>();
            mockRepo.Setup(x => x.UpGradeMemberShipEmail());

            var memberShipRepository = new MemberShipRepository(new BusinessRulesDataEngineContext());
            var retrnData = memberShipRepository.UpGradeMemberShipEmail();

            Assert.True(Convert.ToInt32(retrnData) > 0, "The Data Populated Successfully !!");
        }
    }
}
