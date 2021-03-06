﻿using System;

namespace Privilege.Business.Models
{
    public class ContractDto
    {
        public long Id { get; set; }
        public long BorrowerProjectId { get; set; }
        public int ContractStatusId { get; set; }
        public long LenderProjectId { get; set; }
        public DateTimeOffset Expiration { get; set; }
        public DateTime CreationDate { get; set; }
        public string Clause { get; set; }
        public double Amount { get; set; }
        public double InterestRate { get; set; }
        public string ProjectOwnerFirstName { get; set; }
        public string ProjectOwnerLastName { get; set; }
        public string DealerFirstName { get; set; }
        public string DealerLastName { get; set; }
        public string ProjectTitle { get; set; }
    }
}
