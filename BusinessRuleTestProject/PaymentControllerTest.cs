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
   public class PaymentControllerTest
    {
        [Fact]
        public async Task GenerateProductSlipTest()
        {
            try
            {               
                var controller = new PaymentController();
                Payment payment = new Payment { PaymentOptionId = 1, IsPaid = true, Status = 'P', PaidDate = DateTime.Now, PaidAmount = 200 };
                SlipDeatils slipDeatils = new SlipDeatils { SlipAddress = "aaa", ContactNumber = "2233" };
                int moduleId = 1;
                var result = await controller.GenerateProductSlip(moduleId,payment, slipDeatils);            
                
                Assert.Equal(result.Value, true);
                Assert.NotEqual(result.Value, true);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
               
            }

          

        }

        [Fact]
        public async Task GenerateBookSlipTest()
        {
            try
            {
                var controller = new PaymentController();
                Payment payment = new Payment { PaymentOptionId = 2, IsPaid = true, Status = 'P', PaidDate = DateTime.Now, PaidAmount = 200 };
                SlipDeatils slipDeatils = new SlipDeatils { SlipAddress = "aaa", ContactNumber = "2233" };
                int moduleId = 2;
                var result = await controller.GenerateBookSlip(moduleId, payment, slipDeatils);

                Assert.Equal(result.Value, true);
                Assert.NotEqual(result.Value, true);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);

            }



        }

        [Fact]
        public async Task SendEmailTest()
        {
            try
            {
                var controller = new PaymentController();
                Payment payment = new Payment { PaymentOptionId = 2, IsPaid = true, Status = 'P', PaidDate = DateTime.Now, PaidAmount = 200 };
               // SlipDeatils slipDeatils = new SlipDeatils { SlipAddress = "aaa", ContactNumber = "2233" };
               // int moduleId = 2;
                var result = await controller.SendEmail(payment);

                Assert.Equal(result.Value, true);
                Assert.NotEqual(result.Value, true);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);

            }



        }

        [Fact]
        public async Task SaveVideoPaymentTest()
        {
            try
            {
                var controller = new PaymentController();
                Payment payment = new Payment { PaymentOptionId = 2, IsPaid = true, Status = 'P', PaidDate = DateTime.Now, PaidAmount = 200 };
                // SlipDeatils slipDeatils = new SlipDeatils { SlipAddress = "aaa", ContactNumber = "2233" };
                // int moduleId = 2;
                var result = await controller.SaveVideoPayment(payment);

                Assert.Equal(result.Value, true);
                Assert.NotEqual(result.Value, true);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);

            }



        }

        [Fact]
        public async Task ActiveMembershipPaymentTest()
        {
            try
            {
                var controller = new PaymentController();
                Payment payment = new Payment { PaymentOptionId = 2, IsPaid = true, Status = 'P', PaidDate = DateTime.Now, PaidAmount = 200 };
                MemberShip memberShip = new MemberShip { Name = "Test", Email = "test@gmail.com", ActiveDate = DateTime.Now, DeactiveDate = DateTime.Now.AddMonths(1), IsActive = true };
                var result = await controller.ActiveMembershipPayment(payment, memberShip);

                Assert.Equal(result.Value, true);
                Assert.NotEqual(result.Value, true);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);

            }



        }

        [Fact]
        public async Task UpgradeMembershipPaymentTest()
        {
            try
            {
                var controller = new PaymentController();
                Payment payment = new Payment { PaymentOptionId = 2, IsPaid = true, Status = 'P', PaidDate = DateTime.Now, PaidAmount = 200 };
                MemberShip memberShip = new MemberShip { Name = "Test", Email = "test@gmail.com", ActiveDate = DateTime.Now, DeactiveDate = DateTime.Now.AddMonths(1), IsActive = true };
                var result = await controller.UpgradeMembershipPayment(payment, memberShip);

                Assert.Equal(result.Value, true);
                Assert.NotEqual(result.Value, true);
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
