using BusinessRuleApplication.Models;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.RepositoryPattern
{
    public class ModulesRepository : IModulesRepository
    {
        private BusinessRulesDataEngineContext context;

        public ModulesRepository(BusinessRulesDataEngineContext context)
        {
            this.context = context;
        }

        public async Task<List<Modules>> GetModules()
        {
            try
            {
               return context.Module.ToList();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> InsertModule(Modules module)
        {
            try
            {                
                context.Module.Add(module);
                context.SaveChanges();
                return module.ModuleId;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> IsModuleExists(string name)
        {
            // UserDataAccess da = new UserDataAccess();

            Modules module = context.Module.FirstOrDefault(u => u.Name == name);

            if (module != null)
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
