using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.Models
{
    public class Agent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgentId { get; set; }
        public string Name { get; set; }
        public decimal CommisionPercentage { get; set; }

        public int ModuleId { get; set; }
        // public BusinessRules BusinessRules { get; set; }
    }
}
