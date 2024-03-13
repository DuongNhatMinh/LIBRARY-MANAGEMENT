using System.Collections.Generic;

namespace Minh_C5_Assignment
{
    class LoanViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryLoan repoLoan { get; set; }

        public LoanViewModel()
        {
            repoLoan = unit.GetRepositoryLoan;
        }

        public List<LoanSlip> GetItem()
        {
            return unit.GetRepositoryLoan.Items;
        }

        public void AddLoanSlip(LoanSlip loan)
        {
            repoLoan.Add(loan);
        }
    }
}
