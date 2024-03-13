using System.Collections.Generic;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryBookStatus : RepositoryBase<BookStatu>
    {
        public RepositoryBookStatus()
        {
            Items = new List<BookStatu>();
            Load();
        }

        public List<BookStatu> Load()
        {
            Items = DatabaseFirst.Instance.db.BookStatus.ToList();
            return Items;
        }

        public BookStatu GetByName(string name) => Items.Find(e => e.Name.ToLower().CompareTo(name.ToLower()) == 0);
    }
}
