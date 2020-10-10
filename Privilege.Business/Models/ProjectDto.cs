using Privilege.Business.Models.Enum;
using System;

namespace Privilege.Business.Models
{
    public class ProjectDto
    {
        public double Budget { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Id { get; set; }
        public string Title { get; set; }
        public ProjectType ProjectType;
    }
}