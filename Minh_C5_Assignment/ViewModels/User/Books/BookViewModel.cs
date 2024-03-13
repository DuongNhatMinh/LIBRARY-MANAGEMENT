using System;
using System.Collections.Generic;
using System.Windows;

namespace Minh_C5_Assignment
{
    class BookViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryBook repoBook { get; set; }
        int check = 0;

        public BookViewModel()
        {
            repoBook = unit.GetRepositoryBook;
        }

        public List<Book> GetItem()
        {
            return unit.GetRepositoryBook.Items;
        }

        public void AddBook(string ISBN, string idpublisher, string idtranslator, string language, DateTime publishdate, int quantity, decimal price, string idstatus)
        {
            repoBook.Add(ISBN, idpublisher, idtranslator, language, publishdate, price, idstatus);
            check++;
            if(check == quantity)
            {
                MessageBox.Show("Add Book successfully!", "Notify", MessageBoxButton.OK);
                check = 0;
            }
        }
    }
}
