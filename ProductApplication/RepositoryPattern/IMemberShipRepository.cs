using BusinessRuleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.RepositoryPattern
{
  public  interface IMemberShipRepository
    {
        Task<int> ActivateMemberShip(MemberShip memberShip);
        Task<bool> IsMembershipExists(string email);
        // Task<bool> IsMembershipExists(MemberShip memberShip);
        Task<bool> UpGradeMemberShip(MemberShip memberShip);
        Task<List<MemberShip>> UpGradeMemberShipEmail();
    }
}
