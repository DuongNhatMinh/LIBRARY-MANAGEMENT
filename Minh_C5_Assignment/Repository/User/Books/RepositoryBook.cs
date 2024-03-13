using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;

namespace Minh_C5_Assignment
{
    class RepositoryBook : RepositoryBase<Book>
    {
        public RepositoryBook()
        {
            Items = new List<Book>();
            Load();
        }

        public List<Book> Load()
        {
            Items = DatabaseFirst.Instance.db.Books.ToList();
            return Items;
        }

        public void UpdateStatusByISBN(int status, string isbn)
        {
            DataProvider.Instance.parameters = new string[] { "ISBN" };
            DataProvider.Instance.values = new object[] { isbn };

            int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateStatusBook(status, isbn));

            if (nRow != -1)
            {
                foreach (var item in Items)
                {
                    if (item.ISBN == isbn)
                        item.Status = status == 0 ? false : true;
                }
            }
            else
                MessageBox.Show("Records Deleted Failed!");
        }

        public void UpdateStatusByID(int status, int id)
        {
            DataProvider.Instance.parameters = new string[] { "Id" };
            DataProvider.Instance.values = new object[] { id };

            int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateStatusBookId(status, id));

            if (nRow != -1)
            {
                foreach (var item in Items)
                {
                    if (item.Id == id)
                        item.Status = status == 0 ? false : true;
                }
            }
            else
                MessageBox.Show("Records Deleted Failed!");
        }

        public void UpdateIdBookStatusByID(string idstatus, int id)
        {
            DataProvider.Instance.parameters = new string[] { "Id" };
            DataProvider.Instance.values = new object[] { id };

            int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateIdStatusBookId(idstatus, id));

            if (nRow != -1)
            {
                foreach (var item in Items)
                {
                    if (item.Id == id)
                        item.IdBookStatus = idstatus;
                }
            }
            else
                MessageBox.Show("Records Deleted Failed!");
        }

        public void UpdatePriceById(decimal price, string isbn)
        {
            DataProvider.Instance.parameters = new string[] { "ISBN" };
            DataProvider.Instance.values = new object[] { isbn };

            int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdatePriceBook(price, isbn));

            if (nRow != -1)
            {
                foreach (var item in Items)
                {
                    if (item.ISBN == isbn)
                        item.PriceCurrent = price;
                }
            }
            else
                MessageBox.Show("Records Deleted Failed!");
        }

        public static int GetNewID()
        {
            string id = string.Empty;

            var number = DatabaseFirst.Instance.db.Books.Select(book => book.Id).Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return int.Parse(id);
        }


        public void Add(string isbn, string idpublisher, string idtranslator, string language, DateTime publishdate, decimal bookPrice, string idstatus)
        {
            int newID = GetNewID();

            var newBook = new Book()
            {
                Id = newID,
                ISBN = isbn,
                IdPublisher = idpublisher,
                IdTranslator = idtranslator,
                Language = language,
                PublishDate = publishdate,
                Price = bookPrice,
                PriceCurrent = bookPrice,
                Status = true,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IdBookStatus = idstatus
            };
            Items.Add(newBook);
            DatabaseFirst.Instance.db.Books.Add(newBook);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public int GetQuantity(string ISBN)
        {
            int quantity = 0;
            for(int i = 0; i < Items.Count; i++)
            {
                if(Items[i].ISBN == ISBN && Items[i].Status == true)
                {
                    quantity++;
                }
            }
            return quantity;
        }

        public Book GetByISBN(string ISBN)
        {
            return Items.FirstOrDefault(x => x.ISBN == ISBN);
        }

        public Book GetById(int id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }

        public ObservableCollection<Book> GetListByISBN(string ISBN)
        {
            ObservableCollection<Book> lstbook = new ObservableCollection<Book>();
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].ISBN == ISBN && Items[i].Status == true)
                    lstbook.Add(Items[i]);
            }
            return lstbook;
        }

        public int GetLast()
        {
            if (Items.Count == 0)
                return -1;
            return Items.Count;
        }
    }
}
