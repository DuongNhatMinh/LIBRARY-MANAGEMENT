using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucStatictical.xaml
    /// </summary>
    public partial class ucStatictical : UserControl
    {
        public ucStatictical()
        {
            InitializeComponent();

            var quantityBorrowingBook = 0;
            if (DatabaseFirst.Instance.db.LoanSlips.Count() != 0)
                quantityBorrowingBook = DatabaseFirst.Instance.db.LoanSlips.Sum(i => i.LoanDetails.Count);
            lbborrowed.Content = quantityBorrowingBook.ToString();

            lbreserve.Content = (DatabaseFirst.Instance.db.Books.Where(i => i.IdBookStatus != "BS2").Count() - quantityBorrowingBook).ToString();

            lbLoan.Content = DatabaseFirst.Instance.db.LoanSlips.Count().ToString();

            lbHistory.Content = DatabaseFirst.Instance.db.LoanHistories.Count().ToString();

            lbExpLoan.Content = DatabaseFirst.Instance.db.LoanSlips.Where(i => DbFunctions.TruncateTime(DateTime.Now) > DbFunctions.TruncateTime(i.ExpDate)).Count().ToString();

            lbISBN.Content = GetMostBorrowedISBN();

            lbSpoil.Content = GetCount("BS3");

            lbLost.Content = GetCount("BS2");

            lbadult.Content = DatabaseFirst.Instance.db.Adults.Count().ToString();

            lbchild.Content = DatabaseFirst.Instance.db.Children.Count().ToString();
        }

        public int GetCount(string idbook)
        {
            int number = 0;

            foreach (var item in DatabaseFirst.Instance.db.Books)
            {
                if (item.IdBookStatus == idbook)
                    number++;
            }
            return number;
        }

        private string GetMostBorrowedISBN()
        {
            Dictionary<string, int> isbn = new Dictionary<string, int>();

            foreach (var item in DatabaseFirst.Instance.db.LoanDetails)
            {
                if (isbn.Keys.Contains(item.Book.ISBN))
                {
                    isbn[item.Book.ISBN]++;
                }
                else
                {
                    isbn.Add(item.Book.ISBN, 1);
                }
            }

            foreach (var item in DatabaseFirst.Instance.db.LoanDetailHistories)
            {
                if (isbn.Keys.Contains(item.Book.ISBN))
                {
                    isbn[item.Book.ISBN]++;
                }
                else
                {
                    isbn.Add(item.Book.ISBN, 1);
                }
            }
            return isbn.OrderByDescending(i => i.Value).FirstOrDefault().Key;
        }
    }
}
