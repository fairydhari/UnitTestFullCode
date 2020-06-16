using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.Models
{
    public class PaymentOptions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentOptionId { get; set; }
        public string Name { get; set; }

       // public BusinessRules BusinessRules { get; set; }
    }
}
