using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryUserInfor : RepositoryBase<UserInfo>
    {
        public RepositoryUserInfor()
        {
            Items = new List<UserInfo>();
            Load();
        }

        public List<UserInfo> Load()
        {
            Items = DatabaseFirst.Instance.db.UserInfoes.Include("User").ToList();
            return Items;
        }

        public string GetNewID()
        {
            string id = "U";

            int number = Items.Select(item => int.Parse(item.IdUser.Split('U')[1])).DefaultIfEmpty(0).Max() + 1;

            id += number;

            return id;
        }

        public void Add(string lName, string fName, string phone, string address)
        {
            string newID = GetNewID();

            var newUserInfo = new UserInfo
            {
                Address = address,
                FName = fName,
                IdUser = newID,
                LName = lName,
                Phone = phone,
            };

            Items.Add(newUserInfo);

            DatabaseFirst.Instance.db.UserInfoes.Add(newUserInfo);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public void UpdateByIdUser(string IdUser, string lName, string fName, string phone, string address)
        {
            UserInfo userInfo = Items.FirstOrDefault(i => i.IdUser == IdUser);

            userInfo.Address = address;
            userInfo.FName = fName;
            userInfo.LName = lName;
            userInfo.Phone = phone;

            var userInfoDB = DatabaseFirst.Instance.db.UserInfoes.FirstOrDefault(i => i.IdUser == IdUser);
            userInfoDB.Address = address;
            userInfoDB.FName = fName;
            userInfoDB.LName = lName;
            userInfoDB.Phone = phone;

            DatabaseFirst.Instance.db.SaveChanges();
        }

        public void Delete(string IdUser)
        {
            Items.Remove(Items.FirstOrDefault(i => i.IdUser == IdUser));
            DatabaseFirst.Instance.db.UserInfoes.Remove(DatabaseFirst.Instance.db.UserInfoes.FirstOrDefault(i => i.IdUser == IdUser));
        }

        public UserInfo GetByID(string ID)
        {
            return Items.FirstOrDefault(x => x.IdUser == ID);
        }
    }
}
