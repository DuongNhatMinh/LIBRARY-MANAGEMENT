using System.Collections.Generic;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryLoanDetailHistory : RepositoryBase<LoanDetailHistory>
    {
        public RepositoryLoanDetailHistory()
        {
            Items = new List<LoanDetailHistory>();
            Load();
        }

        public List<LoanDetailHistory> Load()
        {
            Items = DatabaseFirst.Instance.db.LoanDetailHistories.ToList();
            return Items;
        }

        public static string GetNewID()
        {
            string id = "LDTH";

            var number = DatabaseFirst.Instance.db.LoanDetailHistories.Select(i => i.Id.Substring(1)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(LoanDetailHistory loanDetailHistory)
        {
            Items.Add(loanDetailHistory);

            DatabaseFirst.Instance.db.LoanDetailHistories.Add(loanDetailHistory);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public LoanDetailHistory GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);

        public int GetLast()
        {
            if (Items.Count == 0)
                return -1;
            return Items.Count;
        }

        public List<LoanDetailHistory> GetListByIdLoan(string idloan)
        {
            List<LoanDetailHistory> lstdetail = new List<LoanDetailHistory>();
            foreach (var item in Items)
            {
                if (item.IdLoanHistory == idloan)
                    lstdetail.Add(item);
            }
            return lstdetail;
        }
    }
}
