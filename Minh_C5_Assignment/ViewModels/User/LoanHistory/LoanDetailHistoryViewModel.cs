using System.Collections.Generic;

namespace Minh_C5_Assignment
{
    class LoanDetailHistoryViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryLoanDetailHistory repoLoanDetailHistory { get; set; }

        public LoanDetailHistoryViewModel()
        {
            repoLoanDetailHistory = unit.GetRepositoryLoanDetailHistory;
        }

        public List<LoanDetailHistory> GetItem()
        {
            return unit.GetRepositoryLoanDetailHistory.Items;
        }

        public void AddLoanDetailHistory(LoanDetailHistory loan)
        {
            repoLoanDetailHistory.Add(loan);
        }
    }
}
