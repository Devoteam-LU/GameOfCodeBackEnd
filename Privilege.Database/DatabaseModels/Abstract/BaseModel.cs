﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Privilege.Database.DatabaseModels.Abstract
{
    public class BaseModel
    {
        [Key]
        public long Id { get; set; }

        public DateTimeOffset CreationDate { get; set; }
    }
}