using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessRuleApplication.Models;
using BusinessRuleApplication.RepositoryPattern;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusinessRuleApplication
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ModulesController : Controller
    {
        private IModulesRepository modulesRepository;
       
        public ModulesController()
        {
            //BusinessRulesDataEngineContext context = new BusinessRulesDataEngineContext();
            this.modulesRepository = new ModulesRepository(new BusinessRulesDataEngineContext());
           
        }
        
        // POST api/<controller>
        [HttpPost]
        public async Task<JsonResult> SaveModule(Modules modules)
        {
            if (modules == null)
                throw new ArgumentNullException(" Module is Empty");
            string result="";
            try
            {
                if (modules.Name==null || modules.Name == "")
                {
                   // return new JsonResult("Name is empty");
                 //   result = "Name is empty";
                    throw new ArgumentNullException("Name is empty");
                }
                // logger.LogInformation("Start Post module");
                else                {
                    if (await modulesRepository.IsModuleExists(modules.Name))
                    {
                       var id=  await modulesRepository.InsertModule(modules);
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
            catch(Exception ex)
            {
                // logger.LogInformation(ex.ToString());
                //result= - 2;
               // return BadRequest(ex);
            }
            return new JsonResult(result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modules>>> Get()
        {
            return Ok(await modulesRepository.GetModules());
        }

    }
}
