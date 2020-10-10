using Privilege.Database.DatabaseModels.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Privilege.Database.DatabaseModels
{
    public class UserDetailTrain : BaseModel
    {
        public int Age { get; set; }
        public int Dependants { get; set; }
        public int Education { get; set; }
        public int NumberOfCars { get; set; }
        public int NumberOfProperties { get; set; }
        public int EmploymentType { get; set; }
        public int NumberOfLends { get; set; }
        public int NumberOfBorrows { get; set; }
        public int JobClass { get; set; }
        public double Income { get; set; }
        public double Debt { get; set; }
        public double Lending { get; set; }
        public double SocialStability { get; set; }
        public double SocialExposure { get; set; }
        public double SocialQuality { get; set; }
        public double CreditScore { get; set; }
        public double AvgIncomeOver2Years { get; set; }
        public double AvgIncomeOver5Years { get; set; }
        public double AvgIncomeOver10Years { get; set; }
        public double Savings { get; set; }
        public double AvgSavingsOver2Years { get; set; }
        public double AvgSavingsOver5Years { get; set; }
        public double AvgSavingsOver10Years { get; set; }
        [MaxLength(5)]
        [Required]
        public string Gender { get; set; }
        public bool Married { get; set; }
    }
}