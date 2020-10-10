using Privilege.Database.DatabaseModels.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Privilege.Database.DatabaseModels
{
    public class Contract : BaseModel
    {
        public long BorrowerProjectId { get; set; }
        public int ContractStatusId { get; set; }
        public long LenderProjectId { get; set; }
        public DateTimeOffset Expiration { get; set; }
        public string Clause { get; set; }
        public double Amount { get; set; }
        public double InterestRate { get; set; }

        #region Virtuals

        [Required]
        [ForeignKey(nameof(BorrowerProjectId))]
        public virtual BorrowerProject BorrowerProject { get; set; }

        [Required]
        [ForeignKey(nameof(ContractStatusId))]
        public virtual ContractStatus ContractStatus { get; set; }

        [Required]
        [ForeignKey(nameof(LenderProjectId))]
        public virtual LenderProject LenderProject { get; set; }

        #endregion Virtuals
    }
}