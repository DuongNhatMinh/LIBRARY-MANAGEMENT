using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryBookISBN : RepositoryBase<BookISBN>
    {
        public RepositoryBookISBN()
        {
            Items = new List<BookISBN>();
            Load();
        }

        public List<BookISBN> Load()
        {
            Items = DatabaseFirst.Instance.db.BookISBNs.ToList();
            return Items;
        }

        public void UpdateStatusByISBN(bool status, string isbn)
        {
            var bookISBN = DatabaseFirst.Instance.db.BookISBNs.FirstOrDefault(i => i.ISBN == isbn);
            bookISBN.Status = status;

            var item = GetByISBN(isbn);
            item.Status = status;
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public static string GetNewISBN()
        {
            string id = "ISBN";

            var number = DatabaseFirst.Instance.db.BookISBNs.Select(i => i.ISBN.Substring(4)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(string language, string authorID, string bookTitleID)
        {
            string newISBN = GetNewISBN();

            var newBookISBN = new BookISBN()
            {
                ISBN = newISBN,
                IdAuthor = authorID,
                IdBookTitle = bookTitleID,
                Status = false,
                OriginLanguage = language
            };

            Items.Add(newBookISBN);
            DatabaseFirst.Instance.db.BookISBNs.Add(newBookISBN);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public BookISBN GetByISBN(string ISBN)
        {
            return Items.FirstOrDefault(x => x.ISBN == ISBN);
        }

        public BookISBN GetByIdTitle(string IdTitle)
        {
            return Items.FirstOrDefault(x => x.IdBookTitle == IdTitle);
        }

        public ObservableCollection<BookISBN> GetListByIdTitle(string IdTitle)
        {
            ObservableCollection<BookISBN> lstBookISBN = new ObservableCollection<BookISBN>();
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].IdBookTitle == IdTitle)
                    lstBookISBN.Add(Items[i]);
            }
            return lstBookISBN;
        }

        public int GetLast()
        {
            if (Items.Count == 0)
                return -1;
            return Items.Count;
        }
    }
}
