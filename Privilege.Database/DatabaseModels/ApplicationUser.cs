using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Privilege.Database.DatabaseModels
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CreditScore { get; set; }
        public double Apy { get; set; }

        public virtual ICollection<BorrowerProject> BorrowerProjects { get; set; } = new HashSet<BorrowerProject>();
        public virtual ICollection<LenderProject> LenderProjects { get; set; } = new HashSet<LenderProject>();
        public virtual ICollection<UserInterest> UserInterests { get; set; } = new HashSet<UserInterest>();
        public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    }
}