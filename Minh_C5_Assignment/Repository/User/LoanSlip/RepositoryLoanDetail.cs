using System.Collections.Generic;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryLoanDetail : RepositoryBase<LoanDetail>
    {
        public RepositoryLoanDetail()
        {
            Items = new List<LoanDetail>();
            Load();
        }

        public List<LoanDetail> Load()
        {
            Items = DatabaseFirst.Instance.db.LoanDetails.ToList();
            return Items;
        }

        public static string GetNewID()
        {
            string id = "LDT";

            var number = DatabaseFirst.Instance.db.LoanDetails.Local.Select(i => i.Id.Substring(3)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public int GetLast()
        {
            if (Items.Count == 0)
                return -1;
            return Items.Count;
        }

        public void Add(LoanDetail loanDetail)
        {
            Items.Add(loanDetail);
            DatabaseFirst.Instance.db.LoanDetails.Add(loanDetail);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public void Delete(LoanDetail loanDetail)
        {
            Items.Remove(loanDetail);
            DatabaseFirst.Instance.db.LoanDetails.Remove(loanDetail);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public LoanDetail GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);

        public LoanDetail GetByIDLoan(string idloan) => Items.Find(e => e.IdLoan.CompareTo(idloan) == 0);

        public List<LoanDetail> GetListByIdLoan(string idloan)
        {
            List<LoanDetail> lstdetail = new List<LoanDetail>();
            foreach (var item in Items)
            {
                if(item.IdLoan == idloan)
                    lstdetail.Add(item);
            }
            return lstdetail;
        }
    }
}
