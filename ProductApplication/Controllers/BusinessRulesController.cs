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
    public class BusinessRulesController : ControllerBase
    {
        private readonly BusinessRulesDataEngineContext _context;
        private IBusinessRulesRepository businessRulesRepository;
        public BusinessRulesController()
        {
            this.businessRulesRepository = new BusinessRulesRepository(new BusinessRulesDataEngineContext());
        }

        // GET: api/BusinessRules
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<BusinessRules>>> GetBusinessRule()
        //{
        //    return await _context.BusinessRule.ToListAsync();
        //}

        // GET: api/BusinessRules/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<BusinessRules>> GetBusinessRules(int id)
        //{
        //    var businessRules = await _context.BusinessRule.FindAsync(id);

        //    if (businessRules == null)
        //    {
        //        return NotFound();
        //    }

        //    return businessRules;
        //}

        // PUT: api/BusinessRules/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBusinessRules(int id, BusinessRules businessRules)
        //{
        //    if (id != businessRules.BusinessRuleId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(businessRules).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BusinessRulesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/BusinessRules
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
       
        public async Task<JsonResult> PostBusinessRules(BusinessRules businessRules)
        {
            if (businessRules == null)
                throw new ArgumentNullException(" business Rules is Empty");
            string result = "";
            try
            {
                if (businessRules.ModuleId <= 0 || businessRules.PaymentOptionId<=0)
                {
                    // return new JsonResult("Name is empty");
                    //   result = "Name is empty";
                    throw new ArgumentNullException("business Rules is invalid");
                }
                // logger.LogInformation("Start Post module");
                else
                {
                    if (await businessRulesRepository.IsBusinessRuleExists(businessRules))
                    {
                        var id = await businessRulesRepository.InsertBusinessRule(businessRules);
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
                // logger.LogInformation(ex.ToString());
                //result= - 2;
                // return BadRequest(ex);
            }
            return new JsonResult(result);
        }
        // DELETE: api/BusinessRules/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<BusinessRules>> DeleteBusinessRules(int id)
        //{
        //    var businessRules = await _context.BusinessRule.FindAsync(id);
        //    if (businessRules == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.BusinessRule.Remove(businessRules);
        //    await _context.SaveChangesAsync();

        //    return businessRules;
        //}

        //private bool BusinessRulesExists(int id)
        //{
        //    return _context.BusinessRule.Any(e => e.BusinessRuleId == id);
        //}
    }
}
