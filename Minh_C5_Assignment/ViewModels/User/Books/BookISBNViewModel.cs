using System.Collections.Generic;
using System.Data;
using System.Windows;


namespace Minh_C5_Assignment
{
    class BookISBNViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryBookISBN repoBookISBN { get; set; }

        public BookISBNViewModel()
        {
            repoBookISBN = unit.GetRepositoryBookISBN;
        }

        public List<BookISBN> GetItem()
        {
            return unit.GetRepositoryBookISBN.Items;
        }

        public void AddBookISBN(string IdBookTitle, string IdAuthor, string Language)
        {
            repoBookISBN.Add(Language, IdAuthor, IdBookTitle);
        }

        public void Update(object bookISBN, int index)
        {
            
            BookISBN item  = bookISBN as BookISBN;
            repoBookISBN.UpdateStatusByISBN(false, item.ISBN);
            DataProvider.Instance.parameters = new string[] { "ISBN" };

            DataProvider.Instance.values = new object[] { item.ISBN };

            int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateBookISBN(1, item.ISBN));

            if (nRow != -1)
            {
                repoBookISBN.Items[index].Status = true;
            }
            else
            {
                MessageBox.Show("Records UnLock Failed!");
                return;
            }
        }
    }
}
