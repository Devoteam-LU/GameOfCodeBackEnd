using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Privilege.Database.DatabaseModels
{
    public class ContractStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Value { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    }
}