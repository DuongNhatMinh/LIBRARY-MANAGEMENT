using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryCategory : RepositoryBase<Category>
    {
        public RepositoryCategory()
        {
            Items = new List<Category>();
            Load();
        }

        public List<Category> Load()
        {
            Items = DatabaseFirst.Instance.db.Categories.ToList();
            return Items;
        }

        public Category GetByID(string ID)
        {
            return Items.FirstOrDefault(x => x.Id == ID);
        }

        public Category GetByName(string Name)
        {
            return Items.FirstOrDefault(x => x.Name == Name);
        }

        public static string GetNewID()
        {
            string id = "C";

            var number = DatabaseFirst.Instance.db.Categories.Select(i => i.Id.Substring(1)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(Category newCategory)
        {
            Items.Add(newCategory);
            DatabaseFirst.Instance.db.Categories.Add(newCategory);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public void UpdateByID(string id, string name)
        {

            var categoryDB = DatabaseFirst.Instance.db.Categories.FirstOrDefault(i => i.Id == id);
            categoryDB.Name = name;
            categoryDB.ModifiedAt = DateTime.Now;
            DatabaseFirst.Instance.db.SaveChanges();
        }
    }
}
