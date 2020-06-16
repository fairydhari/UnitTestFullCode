using BusinessRuleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.RepositoryPattern
{
  public  interface IBusinessRulesRepository
    {
        Task<int> InsertBusinessRule(BusinessRules businessRules);
        Task<bool> IsBusinessRuleExists(BusinessRules businessRules);
        //void GeneratePackingSlip(int ProductId);
        //void GenerateDuplicatePackingSlip(int ProductId);
        //void UpgradeMembership(int ProductId);
        //void SendEmail(int ProductId);
    }
}
