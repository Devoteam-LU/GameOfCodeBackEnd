﻿using Privilege.Database.DatabaseModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Privilege.Database.DatabaseModels
{
    public class BorrowerProject : BaseModel
    {
        [MaxLength(250)]
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public double Budget { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    }
}
