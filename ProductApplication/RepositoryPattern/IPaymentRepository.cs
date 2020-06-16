using BusinessRuleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.RepositoryPattern
{
   public interface IPaymentRepository
    {
      //  bool SaveData(string actionName,Payment payment, SlipDeatils slipDeatils, MemberShip memberShip, string VideoType);
        Task<bool> GenerateSlip(int moduleId,Payment payment, SlipDeatils slipDeatils, Char slipType);
       // Task<bool> ActivateMembership(Payment payment, MemberShip memberShip, Char ActionType);
        Task<List<PaymentOptions>> GetPaymentOptionsById(int moduleId);
        Task<bool> SendEmail(Payment payment);
        Task<bool> SaveVideoPayment(Payment payment);
        Task<bool> MembershipPayment(Payment payment, MemberShip memberShip, Char ActionType);
       // Task<bool> SaveCommission(int moduleId, decimal paidAmount);
    }
}
