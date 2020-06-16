using BusinessRuleApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.RepositoryPattern
{
    public class PaymentRepository : IPaymentRepository
    {
        private BusinessRulesDataEngineContext context;
        private IMemberShipRepository memberShipRepository;

        public PaymentRepository(BusinessRulesDataEngineContext context)
        {
            this.context = context;
            this.memberShipRepository = new MemberShipRepository(new BusinessRulesDataEngineContext());
        }
        public async Task<List<PaymentOptions>> GetPaymentOptionsById(int moduleId)
        {
           return(from br in context.BusinessRule
                    join po in context.PaymentOption on br.PaymentOptionId equals po.PaymentOptionId

                    select po).ToList();
        }

        //public bool SaveData(string actionName, Payment payment, SlipDeatils slipDeatils, MemberShip memberShip,string VideoType)
        //{
        //    switch (actionName)
        //    {
        //        case "Product":
        //            GenerateProductSlip(payment, slipDeatils, 'P');

        //            //Generate Commission
        //            break;
        //        case "Book":
        //            GenerateProductSlip(payment, slipDeatils, 'B');
        //            //Generate Commission
        //            // Statements executed if expression(or variable) = value1
        //            break;
        //        case "Activate":
        //            MembershipPayment(payment, memberShip, 'S');
        //            //Generate Commission
        //            // Statements executed if expression(or variable) = value1
        //            break;
        //        case "Upgrade":
        //            MembershipPayment(payment, memberShip, 'U');
        //            //Generate Commission
        //            // Statements executed if expression(or variable) = value1
        //            break;
        //        case "UpgradeEmail":
        //            SendEmail(payment);
        //            //Generate Commission
        //            // Statements executed if expression(or variable) = value1
        //            break;
        //            break;
        //        case "Video":
        //         if(VideoType=="First Aid")
        //            {
        //                SaveVideoPayment(payment);
        //            }
        //            break;
        //        default:
        //            break;
        //            // Statements executed if no case matches
        //    }
        //    throw new NotImplementedException();
        //}
        public async Task<bool> GenerateSlip(int moduleId, Payment payment, SlipDeatils slipDeatils, Char slipType)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Payment.Add(payment);
                    context.SaveChanges();
                    slipDeatils.PaymentId = payment.PaymentId;
                    slipDeatils.SlipType = slipType;
                    context.SlipDeatil.Add(slipDeatils);
                    context.SaveChanges();
                    var query = context.Agents.Where(a => a.ModuleId == moduleId);
                    if (query != null)
                    {
                        decimal commision = payment.PaidAmount * (Convert.ToDecimal(query.Select(a => a.CommisionPercentage)) / 100);

                        AgentCommission agentCommission = new AgentCommission();
                        agentCommission.AgentId = Convert.ToInt32(query.Select(a => a.AgentId));
                        agentCommission.CommisionAmount = commision;
                        context.AgentCommission.Add(agentCommission);
                        context.SaveChanges();

                       
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
        public async Task<bool> MembershipPayment(Payment payment, MemberShip memberShip, Char ActionType)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Payment.Add(payment);
                    context.SaveChanges();
                    if (ActionType == 'S')
                    {                       
                        if (payment.PaymentId > 0)
                        {
                            context.MemberShip.Add(memberShip);
                            context.SaveChanges();
                        }
                       
                    }
                    if (ActionType == 'U')
                    {
                        if (payment.PaymentId > 0)
                        {
                           var entity= context.MemberShip.Where(a=>a.MembershipId== memberShip.MembershipId).FirstOrDefault();
                            if(entity!=null)
                            {
                                context.Entry(memberShip).State = EntityState.Modified;
                            }
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<bool> SendEmail(Payment payment)
        {
            context.Payment.Add(payment);
            context.SaveChanges();
            var email=  memberShipRepository.UpGradeMemberShipEmail();

            return true;
        }
        public async Task<bool> SaveVideoPayment(Payment payment)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Payment.Add(payment);
                    context.SaveChanges();
                    //slipDeatils.PaymentId = payment.PaymentId;
                    //slipDeatils.SlipType = slipType;
                    //context.SlipDeatil.Add(slipDeatils);
                    //context.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        //public async Task<bool> SaveCommission(int moduleId,decimal paidAmount)
        //{
        //    using (var transaction = context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            var query = context.Agents.Where(a => a.ModuleId == moduleId);
        //            if (query != null)
        //            {
        //                decimal commision = paidAmount * (Convert.ToDecimal(query.Select(a => a.CommisionPercentage)) / 100);

        //                AgentCommission agentCommission = new AgentCommission();
        //                agentCommission.AgentId = Convert.ToInt32(query.Select(a => a.AgentId));
        //                agentCommission.CommisionAmount = commision;
        //                context.AgentCommission.Add(agentCommission);
        //                context.SaveChanges();

        //                transaction.Commit();
        //                return true;
        //            }
        //            else
        //                return false;
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            return false;
        //        }
        //    }
        //}

        //public Task<bool> ActivateMembership(Payment payment, MemberShip memberShip, char ActionType)
        //{
        //    throw new NotImplementedException();
        //}
    }
   
}
