using BusinessRuleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.RepositoryPattern
{
  public  interface IModulesRepository
    {
        Task<int> InsertModule(Modules module);
        Task<bool> IsModuleExists(string name);
        Task<List<Modules>> GetModules();
    }
}
