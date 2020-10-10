using Privilege.Database.DatabaseModels.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Privilege.Database.DatabaseModels
{
    public class UserInterest : BaseModel
    {
        [Required]
        [MaxLength(250)]
        public string Interest { get; set; }
        public string UserId { get; set; }
    }
}