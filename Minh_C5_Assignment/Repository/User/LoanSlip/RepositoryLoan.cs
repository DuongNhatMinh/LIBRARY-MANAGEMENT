using System.Collections.Generic;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryLoan : RepositoryBase<LoanSlip>
    {
        public RepositoryLoan()
        {
            Items = new List<LoanSlip>();
            Load();
        }

        public List<LoanSlip> Load()
        {
            Items = DatabaseFirst.Instance.db.LoanSlips.ToList();
            return Items;
        }

        public static string GetNewID()
        {
            string id = "L";

            var number = DatabaseFirst.Instance.db.LoanSlips.Select(i => i.Id.Substring(1)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(LoanSlip newLoanSlip)
        {
            Items.Add(newLoanSlip);
            DatabaseFirst.Instance.db.LoanSlips.Add(newLoanSlip);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public void Delete(LoanSlip loan)
        {

            Items.Remove(loan);
            DatabaseFirst.Instance.db.LoanSlips.Remove(loan);
            DatabaseFirst.Instance.db.SaveChanges();

            //var entity = Items.Where(e => e.Id.CompareTo(id) == 0).FirstOrDefault();
            //Items.Remove(entity);
        }

        public LoanSlip GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);

        public LoanSlip GetByIDReader(string idreader) => Items.Find(e => e.IdReader.CompareTo(idreader) == 0);

        public List<LoanSlip> GetListByIDReader(string idreader)
        {
            List<LoanSlip> lstloan = new List<LoanSlip>();
            foreach(var item in Items)
            {
                if (item.IdReader == idreader)
                    lstloan.Add(item);
            }
            return lstloan;
        }
    }
}
