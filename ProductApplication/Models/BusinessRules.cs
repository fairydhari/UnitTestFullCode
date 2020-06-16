using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.Models
{
    public class BusinessRules
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BusinessRuleId { get; set; }
        public int ModuleId { get; set; }
        public int PaymentOptionId { get; set; }

        public virtual Modules Module { get; set; }
        public virtual PaymentOptions PaymentOptions { get; set; }

        //public ICollection<Modules> Module { get; set; }
        //public ICollection<PaymentOptions> PaymentOption { get; set; }
    }
}
