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
   public class PaymentRepositoryTest
    {
        private IPaymentRepository GetPaymentRepository()
        {
            BusinessRulesDataEngineContext context = new BusinessRulesDataEngineContext();
            return new PaymentRepository(context);
        }
        [Fact]
        public async Task GetPaymentOptionsByIdTest()
        {
            // IModulesRepository moduleRepository = GetModulesRepository();
            var mockRepo = new Mock<IPaymentRepository>();
            mockRepo.Setup(x => x.GetPaymentOptionsById(1));

            var paymentRepository = new PaymentRepository(new BusinessRulesDataEngineContext());
            var retrnData = paymentRepository.GetPaymentOptionsById(1);

            Assert.True(Convert.ToInt32(retrnData) > 0, "The Data Populated Successfully !!");
        }

        [Fact]
        public async Task GenerateSlipTest()
        {
            try
            {
                
                Payment payment = new Payment { PaymentOptionId = 1, IsPaid = true, Status='P', PaidDate = DateTime.Now, PaidAmount = 200 };
                SlipDeatils slipDeatils = new SlipDeatils { SlipAddress="aaa", ContactNumber="2233"};
                IPaymentRepository paymentRepository = GetPaymentRepository();
                var result = await paymentRepository.GenerateSlip(1,payment, slipDeatils,'P');
                Assert.True(Convert.ToInt32(result) > 0, "The DataSved Successfully !!");
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsType<InvalidOperationException>(ex);
            }

        }
        [Fact]
        public async Task MembershipPaymentTest()
        {
            try
            {

                Payment payment = new Payment { PaymentOptionId = 1, IsPaid = true, Status = 'P', PaidDate = DateTime.Now, PaidAmount = 200 };
                MemberShip memberShip = new MemberShip { Name = "Test", Email = "test@gmail.com", ActiveDate = DateTime.Now, DeactiveDate = DateTime.Now.AddMonths(1), IsActive = true };
                IPaymentRepository paymentRepository = GetPaymentRepository();
                var result = await paymentRepository.MembershipPayment(payment, memberShip, 'S');
                Assert.True(result==true, "The DataSved Successfully !!");
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsType<InvalidOperationException>(ex);
            }

        }

        [Fact]
        public async Task SendEmailTest()
        {
            // IModulesRepository moduleRepository = GetModulesRepository();
            Payment payment = new Payment { PaymentOptionId = 1, IsPaid = true, Status = 'P', PaidDate = DateTime.Now, PaidAmount = 200 };
            var mockRepo = new Mock<IPaymentRepository>();
            mockRepo.Setup(x => x.SendEmail(payment));

            var paymentRepository = new PaymentRepository(new BusinessRulesDataEngineContext());
            var retrnData = paymentRepository.SendEmail(payment);

            Assert.True(retrnData.Result==true, "Email send !!");
        }

        [Fact]
        public async Task SaveVideoPayment()
        {
            // IModulesRepository moduleRepository = GetModulesRepository();
            Payment payment = new Payment { PaymentOptionId = 1, IsPaid = true, Status = 'P', PaidDate = DateTime.Now, PaidAmount = 200 };
            var mockRepo = new Mock<IPaymentRepository>();
            mockRepo.Setup(x => x.SaveVideoPayment(payment));

            var paymentRepository = new PaymentRepository(new BusinessRulesDataEngineContext());
            var retrnData = paymentRepository.SaveVideoPayment(payment);

            Assert.True(retrnData.Result == true, "Paid !!");
        }
        //[Fact]
        //public async Task SaveCommission()
        //{
        //    // IModulesRepository moduleRepository = GetModulesRepository();
        //   // Payment payment = new Payment { PaymentOptionId = 1, IsPaid = true, Status = 'P', PaidDate = DateTime.Now, PaidAmount = 200 };
        //    var mockRepo = new Mock<IPaymentRepository>();
        //    mockRepo.Setup(x => x.SaveCommission(1,10));

        //    var paymentRepository = new PaymentRepository(new BusinessRulesDataEngineContext());
        //    var retrnData = paymentRepository.SaveCommission(1,10);

        //    Assert.True(retrnData.Result == true, "Commission  saved !!");
        //}
    }
}
