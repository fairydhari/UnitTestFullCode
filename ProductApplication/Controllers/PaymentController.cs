using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessRuleApplication.Models;
using BusinessRuleApplication.RepositoryPattern;

namespace BusinessRuleApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
      //  private readonly BusinessRulesDataEngineContext _context;
        private IPaymentRepository paymentRepository;
      
        public PaymentController()
        {
            paymentRepository = new PaymentRepository(new BusinessRulesDataEngineContext()); ;
        }
        // Post: api/GenerateProductSlip
        [HttpPost]
        public async Task<JsonResult> GenerateProductSlip(int moduleId, Payment payment, SlipDeatils slipDeatils)
        {
           var result= await paymentRepository.GenerateSlip(moduleId, payment, slipDeatils, 'P');
            return new JsonResult(result);
        }
        // Post: api/GenerateBookSlip
        [HttpPost]
        public async Task<JsonResult> GenerateBookSlip(int moduleId, Payment payment, SlipDeatils slipDeatils)
        {
            var result = await paymentRepository.GenerateSlip(moduleId, payment, slipDeatils, 'B');
            return new JsonResult(result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentOptions>>> GetPaymentOptionsById(int moduleId)
        {
            return Ok(await paymentRepository.GetPaymentOptionsById(moduleId));
        }
        // Post: api/SendEmail
        [HttpPost]
        public async Task<JsonResult> SendEmail(Payment payment)
        {
            var result = await paymentRepository.SendEmail(payment);
            return new JsonResult(result);
        }
        // Post: api/SaveVideoPayment
        [HttpPost]
        public async Task<JsonResult> SaveVideoPayment(Payment payment)
        {
            var result = await paymentRepository.SaveVideoPayment(payment);
            return new JsonResult(result);
        }
        // Post: api/ActiveMembershipPayment
        [HttpPost]
        public async Task<JsonResult> ActiveMembershipPayment(Payment payment,MemberShip memberShip)
        {
            var result = await paymentRepository.MembershipPayment(payment, memberShip,'S');
            return new JsonResult(result);
        }
        // Post: api/UpgradeMembershipPayment
        [HttpPost]
        public async Task<JsonResult> UpgradeMembershipPayment(Payment payment, MemberShip memberShip)
        {
            var result = await paymentRepository.MembershipPayment(payment, memberShip, 'U');
            return new JsonResult(result);
        }
    }
}
