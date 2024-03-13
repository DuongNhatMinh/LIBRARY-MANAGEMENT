using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryBookTitle : RepositoryBase<BookTitle>
    {
        public RepositoryBookTitle()
        {
            Items = new List<BookTitle>();
            Load();
        }

        public List<BookTitle> Load()
        {
            Items = DatabaseFirst.Instance.db.BookTitles.ToList();
            return Items;
        }

        public static string GetNewID()
        {
            string id = "BT";

            var number = DatabaseFirst.Instance.db.BookTitles.Select(bookTitle => bookTitle.Id.Substring(2)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(string categoryID, string name, string summary)
        {
            string newID = GetNewID();

            var newBookTitle = new BookTitle()
            {
                Id = newID,
                IdCategory = categoryID,
                Name = name,
                Summary = summary
            };

            DatabaseFirst.Instance.db.BookTitles.Add(newBookTitle);
            Items.Add(newBookTitle);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public BookTitle GetByID(string ID)
        {
            return Items.FirstOrDefault(x => x.Id == ID);
        }

        public BookTitle GetByIDCategory(string IdCategory)
        {
            return Items.FirstOrDefault(x => x.IdCategory == IdCategory);
        }

        public BookTitle GetByNameandIdCategory(string IdCategory, string name)
        {
            return Items.FirstOrDefault(x => x.IdCategory == IdCategory && x.Name == name);
        }

        public BookTitle GetByName(string Name)
        {
           return Items.FirstOrDefault(x => x.Name == Name);
        }

        public int GetLast()
        {
            if (Items.Count == 0)
                return -1;
            return Items.Count;
        }
    }
}
