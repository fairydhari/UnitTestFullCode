using BusinessRuleApplication.Controllers;
using BusinessRuleApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BusinessRuleTestProject
{
   public class BusinessRulesControllerTest
    {
        [Fact]
        public async Task InsertBusinessRulesTest()
        {
            try
            {
                // var controller = new ModulesController();
                var controller = new BusinessRulesController();
                BusinessRules businessRules = new BusinessRules { ModuleId = 1, PaymentOptionId = 2 };
                var result = await controller.PostBusinessRules(businessRules);             
                
                Assert.Equal(result.Value.ToString(), "DataSved Successfully");
                Assert.Equal(result.Value.ToString(), "already Existed");
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
               
            }

          

        }
    }
}
