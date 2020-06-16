using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        [Required]
        public int  PaymentOptionId{ get; set; }

        public bool IsPaid { get; set; }
        public char Status { get; set; }

        

        public DateTime PaidDate { get; set; }
        public decimal PaidAmount { get; set; }
    }
}
