namespace Privilege.Business.Models
{
    public class UserBorrowLendSituationDto
    {
        public double TotalBorrowingAmount { get; set; }
        public double TotalBorrowingWithInterestRate { get; set; }
        public double BorrowLossProfit { get => TotalBorrowingAmount - TotalBorrowingWithInterestRate; }
        public double TotalLendingAmount { get; set; }
        public double TotalLendingWithInterestRate { get; set; }
        public double LendLossProfit { get => TotalLendingWithInterestRate - TotalLendingAmount; }
        public double TotalLossProfit { get => BorrowLossProfit + LendLossProfit; }
    }
}