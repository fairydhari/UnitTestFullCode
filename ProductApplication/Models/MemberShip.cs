using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.Models
{
    public class MemberShip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MembershipId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime ActiveDate { get; set; }
        public DateTime DeactiveDate { get; set; }
        public bool IsActive { get; set; }
    }
}
