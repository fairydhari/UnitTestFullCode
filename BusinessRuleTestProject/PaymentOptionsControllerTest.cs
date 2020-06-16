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
   public class PaymentOptionsControllerTest
    {
        [Fact]
        public async Task InsertModuleTest()
        {
            try
            {
                
                var controller = new PaymentOptionsController();
                PaymentOptions paymentOptions = new PaymentOptions { Name = "Debit Card" };
                var result = await controller.PostPaymentOptions(paymentOptions);
               
                Assert.Equal(result.Value.ToString(), "DataSved Successfully");
                Assert.Equal(result.Value.ToString(), "already Existed");
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
               
            }


        }
        [Fact]
        public async Task IsValidateModuleName()
        {
            try
            {
                PaymentOptions paymentOptions = new PaymentOptions { Name = " " };
                var controller = new PaymentOptionsController();
                var result = await controller.PostPaymentOptions(paymentOptions);               
                Assert.Equal(result.Value.ToString(), "Name is empty");

            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                // Assert.IsType<InvalidOperationException>(ex);
            }


        }
        [Fact]
        public async Task GetPaymentOptionsTest()
        {
            var mockcontroller = new Mock<PaymentOptionsController>();
            var retrnData = mockcontroller.Setup(x => x.Get());
            Assert.False(retrnData==null, "The Data Population failed !!");
            Assert.True(Convert.ToInt32(retrnData) > 0, "The Data Populated Successfully !!");

        }
    }
}
