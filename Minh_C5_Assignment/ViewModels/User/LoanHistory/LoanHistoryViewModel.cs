using System.Collections.Generic;

namespace Minh_C5_Assignment
{
    class LoanHistoryViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryLoanHistory repoLoanHistory { get; set; }

        public LoanHistoryViewModel()
        {
            repoLoanHistory = unit.GetRepositoryLoanHistory;
        }

        public List<LoanHistory> GetItem()
        {
            return unit.GetRepositoryLoanHistory.Items;
        }

        public void AddLoanHistory(LoanHistory loan)
        {
            repoLoanHistory.Add(loan);
        }
    }
}
