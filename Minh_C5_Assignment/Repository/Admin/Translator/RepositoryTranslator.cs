using System;
using System.Collections.Generic;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryTranslator : RepositoryBase<Translator>
    {
        public RepositoryTranslator()
        {
            Items = new List<Translator>();
            Load();
        }

        public List<Translator> Load()
        {
            Items = DatabaseFirst.Instance.db.Translators.ToList();
            return Items;
        }

        public Translator GetByID(string ID)
        {
            return Items.FirstOrDefault(x => x.Id == ID);
        }

        public Translator GetByName(string Name)
        {
            return Items.FirstOrDefault(x => x.Name == Name);
        }

        public static string GetNewID()
        {
            string id = "T";

            var number = DatabaseFirst.Instance.db.Translators.Select(i => i.Id.Substring(1)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(Translator newTranslator)
        {
            Items.Add(newTranslator);
            DatabaseFirst.Instance.db.Translators.Add(newTranslator);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public void UpdateByID(string id, string name, string description, DateTime bof, string summary)
        {

            var translatorDB = DatabaseFirst.Instance.db.Translators.FirstOrDefault(i => i.Id == id);
            translatorDB.Name = name;
            translatorDB.Description = description;
            translatorDB.boF = bof;
            translatorDB.Summary = summary;
            translatorDB.ModifiedAt = DateTime.Now;
            DatabaseFirst.Instance.db.SaveChanges();
        }
    }
}
