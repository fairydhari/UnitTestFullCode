using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.Models
{
    public class SlipDeatils
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SlipDetailsId { get; set; }
        public int PaymentId { get; set; }
        public string SlipAddress { get; set; }

        public string ContactNumber { get; set; }

        public Char SlipType { get; set; }
    }
}
