using BusinessRuleApplication.Models;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.RepositoryPattern
{
    public class PaymentOptionsRepository : IPaymentOptionsRepository
    {
        private BusinessRulesDataEngineContext context;

        public PaymentOptionsRepository(BusinessRulesDataEngineContext context)
        {
            this.context = context;
        }

        public async Task<List<PaymentOptions>> GetPaymentOptions()
        {
            try
            {
                return context.PaymentOption.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> InsertPaymentOptions(PaymentOptions paymentOptions)
        {
            try
            {

                context.PaymentOption.Add(paymentOptions);
                context.SaveChanges();
                return paymentOptions.PaymentOptionId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> IsPaymentExists(string name)
        {
            PaymentOptions paymentOptions = context.PaymentOption.FirstOrDefault(u => u.Name == name);

            if (paymentOptions != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public Task<List<PaymentOptions>> GetPaymentOptions()
        //{
        //    try
        //    {
        //        return context.PaymentOption.ToList();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
