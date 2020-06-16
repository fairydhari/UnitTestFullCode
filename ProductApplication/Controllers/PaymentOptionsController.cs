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
    public class PaymentOptionsController : ControllerBase
    {
      //  private readonly BusinessRulesDataEngineContext _context;
        private IPaymentOptionsRepository paymentOptionsRepository;
        //public PaymentOptionsController(BusinessRulesDataEngineContext context)
        //{
        //    _context = context;
        //}
         public PaymentOptionsController()
        {
            paymentOptionsRepository = new PaymentOptionsRepository(new BusinessRulesDataEngineContext()); ;
        }

     
        // POST: api/PaymentOptions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
       
        [HttpPost]
        public async Task<JsonResult> PostPaymentOptions(PaymentOptions paymentOptions)
        {
            string result = "";
            try
            {
                if (paymentOptions.Name == null || paymentOptions.Name == "")
                {
                    // return new JsonResult("Name is empty");
                    result = "Name is empty";
                }
                // logger.LogInformation("Start Post module");
                else
                {
                    if (await paymentOptionsRepository.IsPaymentExists(paymentOptions.Name))
                    {
                        var id = await paymentOptionsRepository.InsertPaymentOptions(paymentOptions);
                        if (id > 0)
                            result = "DataSved Successfully";
                        // return new JsonResult("DataSved Successfully");
                        else
                            //    return new JsonResult("Failed");
                            result = "Failed";
                    }
                    else
                    {
                        //   return new JsonResult("already Existed");
                        result = "already Existed";
                    }
                }
                //  logger.LogInformation("End Post module");
            }
            catch (Exception ex)
            {
              
            }
            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentOptions>>> Get()
        {
            return Ok(await paymentOptionsRepository.GetPaymentOptions());
        }
    }
}
