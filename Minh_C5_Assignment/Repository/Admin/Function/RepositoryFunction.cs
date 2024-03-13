using System.Collections.Generic;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryFunction : RepositoryBase<Function>
    {
        public RepositoryFunction()
        {
            Items = new List<Function>();
            Load();
        }

        public List<Function> Load()
        {
            Items = DatabaseFirst.Instance.db.Functions.ToList();
            return Items;
        }

        public void UpdateByID(string id, string name, string description, string IdParent, string urlImage)
        {
            Function function = Items.Find(i => i.Id == id);
            function.Name = name;
            function.Description = description;
            function.IdParent = IdParent;
            function.UrlImage = urlImage;

            var functionDB = DatabaseFirst.Instance.db.Functions.FirstOrDefault(i => i.Id == id);
            functionDB.Name = name;
            functionDB.Description = description;
            functionDB.IdParent = IdParent;
            functionDB.UrlImage = urlImage;

            DatabaseFirst.Instance.db.SaveChanges();
        }

        public int GetLast()
        {
            if (Items.Count == 0)
                return -1;
            return Items.Count;
        }

        public int GetIndex(string id)
        {
            for(int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Id == id)
                    return i;
            }
            return -1;
        }

        public Function getbyid(string id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }

        public Function getbyname(string name)
        {
            return Items.FirstOrDefault(x => x.Name == name);
        }
    }
}
