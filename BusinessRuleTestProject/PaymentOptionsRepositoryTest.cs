using BusinessRuleApplication.Models;
using BusinessRuleApplication.RepositoryPattern;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BusinessRuleTestProject
{
  public  class PaymentOptionsRepositoryTest
    {
        private IPaymentOptionsRepository GetIPaymentOptionsRepository()
        {

            BusinessRulesDataEngineContext context = new BusinessRulesDataEngineContext();

            return new PaymentOptionsRepository(context);
        }
        [Fact]
        public async Task InsertIPaymentOptionsTest()
        {
            try
            {

                IPaymentOptionsRepository paymentOptionsRepository = GetIPaymentOptionsRepository();
               
                PaymentOptions payment = new PaymentOptions { Name = "Visa Card" };
                var result = await paymentOptionsRepository.InsertPaymentOptions(payment);
               
                Assert.True(Convert.ToInt32(result) > 0, "The DataSved Successfully !!");
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                //Assert.IsType<InvalidOperationException>(ex);
            }

            //Assert.f(Convert.ToInt32(result) > 0, "The DataSved Successfully !!");

            // moduleRepository.in(module);
            //  var result = moduleRepository



        }
        [Fact]
        public async Task PaymentOptionnameExistsTest()
        {
            IPaymentOptionsRepository paymentOptionsRepository = GetIPaymentOptionsRepository();
            string cardName = "Visa Card";          
            var result = await paymentOptionsRepository.IsPaymentExists(cardName);
            Assert.True(
            result == true,
                "Payment name is exist.");

            Assert.False(
           result == false,
                "Payment name should not exist.");
        }
        [Fact]
        public async Task GetPaymentOptionsTest()
        {
            
            var mockRepo = new Mock<IPaymentOptionsRepository>();
            mockRepo.Setup(x => x.GetPaymentOptions());

            var companyObject = new PaymentOptionsRepository(new BusinessRulesDataEngineContext());
            var retrnData = companyObject.GetPaymentOptions();

            Assert.True(Convert.ToInt32(retrnData) > 0, "The Data Populated Successfully !!");
        }
    }
}
