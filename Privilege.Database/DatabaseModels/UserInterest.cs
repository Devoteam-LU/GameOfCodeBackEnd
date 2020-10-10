using Privilege.Database.DatabaseModels.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Privilege.Database.DatabaseModels
{
    public class UserInterest : BaseModel
    {
        [Required]
        [MaxLength(250)]
        public string Interest { get; set; }

        [ForeignKey(nameof(BaseModel.CreatedByUserId))]
        public virtual ApplicationUser User { get; set; }
    }
}