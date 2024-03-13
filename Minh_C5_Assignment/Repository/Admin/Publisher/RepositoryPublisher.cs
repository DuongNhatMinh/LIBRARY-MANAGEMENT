using System.Collections.Generic;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryPublisher : RepositoryBase<Publisher>
    {
        public RepositoryPublisher()
        {
            Items = new List<Publisher>();
            Load();
        }

        public List<Publisher> Load()
        {
            Items = DatabaseFirst.Instance.db.Publishers.ToList();
            return Items;
        }

        public string GetID()
        {
            string id = "P";

            var number = DatabaseFirst.Instance.db.Publishers.Select(i => i.Id.Substring(1)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public Publisher GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);

        public static string GetNewID()
        {
            string id = "P";

            var number = DatabaseFirst.Instance.db.Publishers.Select(i => i.Id.Substring(1)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(Publisher newPublisher)
        {
            Items.Add(newPublisher);
            DatabaseFirst.Instance.db.Publishers.Add(newPublisher);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public void UpdateByID(string id, string name, string phone, string address)
        {

            var publisherDB = DatabaseFirst.Instance.db.Publishers.FirstOrDefault(i => i.Id == id);
            publisherDB.Name = name;
            publisherDB.Phone = phone;
            publisherDB.Address = address;
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public void Delete(Publisher publisher)
        {
            Items.Remove(publisher);
            DatabaseFirst.Instance.db.Publishers.Remove(publisher);
            DatabaseFirst.Instance.db.SaveChanges();
        }
    }
}
