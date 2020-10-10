﻿using System;

namespace Privilege.Business.Models
{
    public class ProjectDto
    {
        public double Budget { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public string Description { get; set; }
        public long Id { get; set; }
        public string Title { get; set; }
    }
}