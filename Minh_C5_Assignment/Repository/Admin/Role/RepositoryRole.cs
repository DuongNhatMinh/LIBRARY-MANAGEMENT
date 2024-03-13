using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryRole: RepositoryBase<Role>
    {
        public RepositoryRole()
        {
            Items = new List<Role>();
            Load();
        }

        public List<Role> Load()
        {
            Items = DatabaseFirst.Instance.db.Roles.ToList();
            return Items;
        }

        public string GetNewID()
        {
            string id = "R";

            int number = Items.Select(item => int.Parse(item.Id.Split('R')[1])).DefaultIfEmpty(0).Max() + 1;

            id += number;

            return id;
        }

        public void Add(string roleName, string group)
        {
            string newID = GetNewID();

            var newRole = new Role()
            {
                Group = group,
                Id = newID,
                Name = roleName,
                Status = true
            };
            Items.Add(newRole);

            DatabaseFirst.Instance.db.Roles.Add(newRole);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public Role GetByID(string id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }

        public Role GetByName(string name)
        {
            return Items.FirstOrDefault(x => x.Name == name);
        }

        public Role GetLast()
        {
            if (Items.Count == 0)
                return null;
            return Items[Items.Count - 1];
        }
    }
}
