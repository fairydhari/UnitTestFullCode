using BusinessRuleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.RepositoryPattern
{
 public   interface IPaymentOptionsRepository
    {
        Task<int> InsertPaymentOptions(PaymentOptions paymentOptions);
        Task<bool> IsPaymentExists(string name);
        Task<List<PaymentOptions>> GetPaymentOptions();

        
    }
}
