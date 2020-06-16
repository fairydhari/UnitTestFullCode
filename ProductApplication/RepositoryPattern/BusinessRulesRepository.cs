using BusinessRuleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.RepositoryPattern
{
    public class BusinessRulesRepository : IBusinessRulesRepository
    {
        private BusinessRulesDataEngineContext context;

        public BusinessRulesRepository(BusinessRulesDataEngineContext context)
        {
            this.context = context;
        }
        public async Task<int> InsertBusinessRule(BusinessRules businessRules)
        {
            try
            {

                context.BusinessRule.Add(businessRules);
                context.SaveChanges();
                return businessRules.BusinessRuleId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> IsBusinessRuleExists(BusinessRules businessRules)
        {
            // UserDataAccess da = new UserDataAccess();

            BusinessRules businessRule = context.BusinessRule.FirstOrDefault(u => u.ModuleId == businessRules.ModuleId && u.PaymentOptionId== businessRules.PaymentOptionId);

            if (businessRule != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       

       
    }
}
