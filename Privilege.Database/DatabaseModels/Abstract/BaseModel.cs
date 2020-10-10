using System;
using System.ComponentModel.DataAnnotations;

namespace Privilege.Database.DatabaseModels.Abstract
{
    public class BaseModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(450)]
        public string CreatedByUserId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}