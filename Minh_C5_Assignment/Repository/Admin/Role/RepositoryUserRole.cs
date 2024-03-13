using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace Minh_C5_Assignment
{
    class RepositoryUserRole : RepositoryBase<UserRole>
    {
        public RepositoryUserRole()
        {
            Items = new List<UserRole>();
            Load();
        }

        public List<UserRole> Load()
        {
            Items = DatabaseFirst.Instance.db.UserRoles.Include("User").Include("Role").ToList();
            return Items;
        }

        public string GetNewID()
        {
            string id = "UR";

            int number = Items.Select(item => int.Parse(item.Id.Substring(2))).DefaultIfEmpty(0).Max() + 1;

            id += number;

            return id;
        }

        public void DeleteByIdUser(string IdUser)
        {
            if (Items.Where(i => i.IdUser == IdUser).ToList().Count == 0)
            {
                return;
            }

            var items = Items.Where(i => i.IdUser == IdUser).ToList();
            for (int index = items.Count - 1; index >= 0; index--)
            {
                Items.Remove(items[index]);
            }

            DatabaseFirst.Instance.db.UserRoles.RemoveRange(DatabaseFirst.Instance.db.UserRoles.Where(i => i.IdUser == IdUser));
        }

        public void Add(string idUser, string idRole)
        {
            string newID = GetNewID();

            var newUserRole = new UserRole()
            {
                Id = newID,
                IdRole = idRole,
                IdUser = idUser
            };

            Items.Add(newUserRole);

            DatabaseFirst.Instance.db.UserRoles.Add(newUserRole);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public void UpdateIdRole(string IdUser, string IdRole, string newIdRole)
        {
            var item = Items.FirstOrDefault(i => i.IdRole == IdRole && i.IdUser == IdUser);
            item.IdRole = newIdRole;

            var userRole = DatabaseFirst.Instance.db.UserRoles.FirstOrDefault(i => i.IdRole == IdRole && i.IdUser == IdUser);
            userRole.IdRole = newIdRole;
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public UserRole GetById(string id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }

        public UserRole GetByIdUser(string iduser)
        {
            return Items.FirstOrDefault(x => x.IdUser == iduser);
        }

        public List<string> GetLast()
        {
            List<string> num = new List<string>();
            foreach (var item in Items)
            {
                string resultString = Regex.Match(item.Id, @"\d+").Value;
                Int32.Parse(resultString);
                num.Add(resultString);
            }
            return num;
        }
    }
}
