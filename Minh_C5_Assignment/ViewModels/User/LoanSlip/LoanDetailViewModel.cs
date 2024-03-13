using System.Collections.Generic;

namespace Minh_C5_Assignment
{
    class LoanDetailViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryLoanDetail repoLoanDetail { get; set; }

        public LoanDetailViewModel()
        {
            repoLoanDetail = unit.GetRepositoryLoanDetail;
        }

        public List<LoanDetail> GetItem()
        {
            return unit.GetRepositoryLoanDetail.Items;
        }

        public void AddLoanSlip(LoanDetail loandetail)
        {
            repoLoanDetail.Add(loandetail);
        }
    }
}
