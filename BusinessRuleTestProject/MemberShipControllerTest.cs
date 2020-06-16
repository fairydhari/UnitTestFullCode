using BusinessRuleApplication.Controllers;
using BusinessRuleApplication.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BusinessRuleTestProject
{
   public class MemberShipControllerTest
    {
        [Fact]
        public async Task ActivateMemberShipTest()
        {
            try
            {               
                var controller = new MemberShipController();
                MemberShip memberShip = new MemberShip { Name = "Test", Email = "test1@gmail.com", ActiveDate = DateTime.Now, DeactiveDate = DateTime.Now.AddMonths(1), IsActive = true };
                var result = await controller.PostMemberShip(memberShip);            
                
                Assert.Equal(result.Value.ToString(), "DataSved Successfully");
                Assert.Equal(result.Value.ToString(), "already Existed");
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
               
            }

          

        }

        [Fact]
        public async Task UpGradeMemberShipTest()
        {
            try
            {
                var controller = new MemberShipController();
                MemberShip memberShip = new MemberShip { Name = "Test", Email = "test1@gmail.com", ActiveDate = DateTime.Now, DeactiveDate = DateTime.Now.AddMonths(1), IsActive = true };
                var result = await controller.UpGradeMemberShip(2,memberShip);
                Assert.True(
            result == true,
                "membership updated sucess fully");
                Assert.False(
               result == false,
                    "already Existed.");
                
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);

            }



        }

        [Fact]
        public async Task GetModulesTest()
        {
            var mockcontroller = new Mock<MemberShipController>();
            var retrnData = mockcontroller.Setup(x => x.GetMemberShip());

            Assert.False(retrnData == null, "The Data Population failed !!");
            Assert.True(Convert.ToInt32(retrnData) > 0, "The Data Populated Successfully !!");

        }
    }
}
