using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryUser : RepositoryBase<User>
    {
        public RepositoryUser()
        {
            Items = new List<User>();
            Load();
        }

        public List<User> Load()
        {
            Items = DatabaseFirst.Instance.db.Users.Include("UserInfo").ToList();
            return Items;
        }

        public string GetNewID()
        {
            string id = "U";

            int number = Items.Select(item => int.Parse(item.Id.Split('U')[1])).DefaultIfEmpty(0).Max() + 1;

            id += number;

            return id;
        }

        public void Add(string username, string password)
        {
            string newID = GetNewID();

            DateTime createdAt = DateTime.Now;

            string id = GetNewID();

            var newUser = new User
            {
                Id = id,
                Status = true,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Username = username,
                Password = password
            };

            Items.Add(newUser);
            DatabaseFirst.Instance.db.Users.Add(newUser);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public void Delete(string id)
        {
            Items.Remove(Items.FirstOrDefault(i => i.Id == id));

            DatabaseFirst.Instance.db.Users.Remove(DatabaseFirst.Instance.db.Users.FirstOrDefault(i => i.Id == id));
        }

        public void UpdateByID(string id, string username, string password)
        {
            User user = Items.FirstOrDefault(i => i.Id == id);
            user.Username = username;
            user.Password = password;
            user.ModifiedAt = DateTime.Now;

            var userDB = DatabaseFirst.Instance.db.Users.FirstOrDefault(i => i.Id == id);
            userDB.Username = username;
            userDB.Password = password;
            userDB.ModifiedAt = DateTime.Now;

            DatabaseFirst.Instance.db.SaveChanges();
        }

        public User GetByID(string ID)
        {
            return Items.FirstOrDefault(x => x.Id == ID);
        }

        public User GetByUserPass(string user, string pass)
        {
            return Items.FirstOrDefault(x => x.Username == user && x.Password == pass);
        }

        public User GetLast()
        {
            if (Items.Count == 0)
                return null;
            return Items[Items.Count - 1];
        }
    }
}
