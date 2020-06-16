using BusinessRuleApplication.Models;
using BusinessRuleApplication.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BusinessRuleTestProject
{
   public class BusinessRulesRepositoryTest
    {
        private IBusinessRulesRepository GetBusinessRulesRepository()
        {

            BusinessRulesDataEngineContext context = new BusinessRulesDataEngineContext();

            return new BusinessRulesRepository(context);
        }
        [Fact]
        public async Task InsertBusinessRulesTest()
        {
            try
            {
               

                IBusinessRulesRepository businessRulesRepository = GetBusinessRulesRepository();               
                BusinessRules businessRules = new BusinessRules { ModuleId =1,PaymentOptionId=1 };
                var result = await businessRulesRepository.InsertBusinessRule(businessRules);
               
                Assert.True(Convert.ToInt32(result) > 0, "The DataSved Successfully !!");
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsType<InvalidOperationException>(ex);
            }


        }
        [Fact]
        public async Task ModulenameExistsTest()
        {
            IBusinessRulesRepository businessRulesRepository = GetBusinessRulesRepository();

            BusinessRules businessRules = new BusinessRules { ModuleId = 1, PaymentOptionId = 1 };
            var result = await businessRulesRepository.IsBusinessRuleExists(businessRules);
            Assert.True(
            result == true,
                "rule is exist.");

            Assert.False(
           result == false,
                "rule should not exist.");
        }
    }
}
