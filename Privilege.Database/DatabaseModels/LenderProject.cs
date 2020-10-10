using Privilege.Database.DatabaseModels.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Privilege.Database.DatabaseModels
{
    public class LenderProject : BaseModel
    {
        [MaxLength(250)]
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public double Budget { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();

        [ForeignKey(nameof(BaseModel.CreatedByUserId))]
        public virtual ApplicationUser User { get; set; }
    }
}