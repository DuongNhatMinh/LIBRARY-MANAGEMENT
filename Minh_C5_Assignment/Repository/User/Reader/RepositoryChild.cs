using System;
using System.Collections.Generic;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryChild : RepositoryBase<Child>
    {
        public RepositoryChild()
        {
            Items = new List<Child>();
            Load();
        }

        public List<Child> Load()
        {
            Items = DatabaseFirst.Instance.db.Children.ToList();
            return Items;
        }

        public void Add(string adultID)
        {
            string newID = RepositoryReader.GetNewID();

            var newChild = new Child()
            {
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IdAdult = adultID,
                Status = true,
                IdReader = newID
            };

            Items.Add(newChild);
            DatabaseFirst.Instance.db.Children.Add(newChild);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public Child GetByReaderID(string readerID)
        {
            return Items.FirstOrDefault(x => x.IdReader == readerID);
        }

        public Child GetLastReader()
        {
            if (Items.Count == 0)
                return null;
            return Items[Items.Count - 1];
        }

        public void Delete(string id)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].IdReader == id)
                    Items.Remove(Items[i]);
            }
        }
    }
}
