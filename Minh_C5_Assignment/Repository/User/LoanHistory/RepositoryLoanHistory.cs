using System.Collections.Generic;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryLoanHistory : RepositoryBase<LoanHistory>
    {
        public RepositoryLoanHistory()
        {
            Items = new List<LoanHistory>();
            Load();
        }

        public List<LoanHistory> Load()
        {
            Items = DatabaseFirst.Instance.db.LoanHistories.ToList();
            return Items;
        }

        public static string GetNewID()
        {
            string id = "LH";

            var number = DatabaseFirst.Instance.db.LoanHistories.Select(i => i.Id.Substring(2)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(LoanHistory loanHistory)
        {
            Items.Add(loanHistory);
            DatabaseFirst.Instance.db.LoanHistories.Add(loanHistory);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public LoanHistory GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
    }
}
