using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace Minh_C5_Assignment
{
    class UserInforViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryUserInfor repoUserInfo { get; set; }

        public UserInforViewModel()
        {
            repoUserInfo = unit.GetRepositoryUserInfor;
        }
        
        public List<UserInfo> GetItems()
        {
            return unit.GetRepositoryUserInfor.Items;
        }

        public void Add(string lname, string fname, string address, string phone)
        {
            repoUserInfo.Add(lname, fname, phone, address);
        }

        public void Edit(User user, string lname, string fname, string address, string phone, int index)
        {
            repoUserInfo.UpdateByIdUser(user.Id, lname, fname, phone, address);
            DataProvider.Instance.parameters = new string[] { "IdUser", "LName", "FName", "Phone", "Address", };

            DataProvider.Instance.values = new object[] { user.Id, lname, fname, phone, address };

            int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.EditUserInfo(lname, fname, address, phone, user.Id));

            if (nRow != -1)
            {
                repoUserInfo.Items[index].LName = lname;
                repoUserInfo.Items[index].FName = fname;
                repoUserInfo.Items[index].Address = address;
                repoUserInfo.Items[index].Phone = phone;
            }
            else
            {
                MessageBox.Show("Records Inserted Failed!");
                return;
            }

            //MessageBox.Show("Edit User successfully!", "Notify", MessageBoxButton.OK);
        }

    }
}
