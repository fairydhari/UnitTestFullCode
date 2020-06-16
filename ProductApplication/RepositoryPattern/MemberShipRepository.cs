using BusinessRuleApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.RepositoryPattern
{
    public class MemberShipRepository : IMemberShipRepository
    {
        private BusinessRulesDataEngineContext context;

        public MemberShipRepository(BusinessRulesDataEngineContext context)
        {
            this.context = context;
        }
        public async Task<int> ActivateMemberShip(MemberShip memberShip)
        {
            try
            {
                context.MemberShip.Add(memberShip);
                context.SaveChanges();
                return memberShip.MembershipId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public async Task<bool> IsMembershipExists(string email)
        {
           // MemberShip entity = context.Module.Where(u => u.Name == memberShip.Name).FirstOrDefault();
            MemberShip entity = context.MemberShip.FirstOrDefault(u => u.Email ==email);

            if (entity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpGradeMemberShip(MemberShip memberShip)
        {
            MemberShip entity = context.MemberShip.FirstOrDefault(u => u.MembershipId == memberShip.MembershipId);

            if (entity != null)
            {
                entity.Name = memberShip.Name;
                entity.IsActive = memberShip.IsActive;
                entity.DeactiveDate = memberShip.DeactiveDate;
                entity.Email = memberShip.Email;
                context.Entry(memberShip).State = EntityState.Modified;
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! (await IsMembershipExists(memberShip.Email)))
                    {
                        return false;
                    }
                    else
                    {
                        throw;
                    }
                }

                
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<MemberShip>> UpGradeMemberShipEmail()
        {
            try
            {
                //var query = context.MemberShip.Where(a => a.DeactiveDate.Date >= System.DateTime.Now.Date).ToList();
                return context.MemberShip.Where(a=>a.DeactiveDate.Date>=System.DateTime.Now.Date).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
