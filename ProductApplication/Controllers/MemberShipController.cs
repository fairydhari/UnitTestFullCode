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
    public class MemberShipController : ControllerBase
    {
        private IMemberShipRepository memberShipRepository;

        public MemberShipController()
        {
            //BusinessRulesDataEngineContext context = new BusinessRulesDataEngineContext();
            this.memberShipRepository = new MemberShipRepository(new BusinessRulesDataEngineContext());

        }
        

        // GET: api/MemberShip
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modules>>> GetMemberShip()
        {
            return Ok(await memberShipRepository.UpGradeMemberShipEmail());
        }
       
        // PUT: api/MemberShip/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<bool> UpGradeMemberShip(int id, MemberShip memberShip)
        {
            if (id != memberShip.MembershipId)
            {
                throw new ArgumentException("id miss match");
            }
           // memberShip.MembershipId = id;
            await memberShipRepository.UpGradeMemberShip(memberShip);
            return true;
        }

        // POST: api/MemberShip
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        
        [HttpPost]
        public async Task<JsonResult> PostMemberShip(MemberShip memberShip)
        {
            if (memberShip == null)
                throw new ArgumentNullException(" memberShip is Empty");
            string result = "";
            try
            {
                if (memberShip.Name == null || memberShip.Name == "")
                {                   
                    throw new ArgumentNullException("Name is empty");
                }
                else if (memberShip.Email == null || memberShip.Email == "")
                {                    
                    throw new ArgumentNullException("Email is empty");
                }
               
                else
                {
                    if (await memberShipRepository.IsMembershipExists(memberShip.Email))
                    {
                        var id = await memberShipRepository.ActivateMemberShip(memberShip);
                        if (id > 0)
                            result = "DataSved Successfully";
                        // return new JsonResult("DataSved Successfully");
                        else
                            //    return new JsonResult("Failed");
                            result = "Failed";
                    }
                    else
                    {
                       
                        result = "already Existed";
                    }
                }
                
            }
            catch (Exception ex)
            {
               
            }
            return new JsonResult(result);
        }

              
    }
}
