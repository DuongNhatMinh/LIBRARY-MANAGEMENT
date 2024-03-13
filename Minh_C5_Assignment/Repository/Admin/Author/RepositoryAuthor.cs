using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryAuthor : RepositoryBase<Author>
    {
        public RepositoryAuthor()
        {
            Items = new List<Author>();
            Load();
        }

        public List<Author> Load()
        {
            Items = DatabaseFirst.Instance.db.Authors.ToList();
            return Items;
        }

        public Author GetByID(string ID)
        {
            return Items.FirstOrDefault(x => x.Id == ID);
        }

        public Author GetByName(string Name)
        {
            return Items.FirstOrDefault(x => x.Name == Name);
        }

        public static string GetNewID()
        {
            string id = "A";

            var number = DatabaseFirst.Instance.db.Authors.Select(i => i.Id.Substring(1)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(Author newAuthor)
        {
            Items.Add(newAuthor);
            DatabaseFirst.Instance.db.Authors.Add(newAuthor);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public void UpdateByID(string id, string name, string description, DateTime bof, string summary)
        {
            var authorDB = DatabaseFirst.Instance.db.Authors.FirstOrDefault(i => i.Id == id);
            authorDB.Name = name;
            authorDB.Description = description;
            authorDB.boF = bof;
            authorDB.Summary = summary; 
            authorDB.ModifiedAt = DateTime.Now;
            DatabaseFirst.Instance.db.SaveChanges();
        }
    }
}
