using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace Minh_C5_Assignment
{
    class UserViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryUser repoUser { get; set; }

        public UserViewModel()
        {
            repoUser = unit.GetRepositoryUser;
        }

        public List<User> GetItem()
        {
            return unit.GetRepositoryUser.Items;
        }

        public void Add(string username, string password)
        {
            repoUser.Add(username, password);
        }

        public void Lock(object user, int index)
        {
            User usertemp = user as User;
            string message = string.Format("You want Update {0}?", usertemp.Username);
            string caption = "Confirmation";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                DataProvider.Instance.parameters = new string[] { "Id", "ModifiedAt" };

                DataProvider.Instance.values = new object[] { usertemp.Id, DateTime.Now };

                int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateUser(0, usertemp.Id));

                if (nRow != -1)
                {
                    repoUser.Items[index].Status = false;
                    repoUser.Items[index].ModifiedAt = DateTime.Now;
                }
                else
                {
                    MessageBox.Show("Records Lock Failed!");
                    return;
                }
            }
            else
            {
                return;
            }
        }

        public void UnLock(int index)
        {
            string message = string.Format("You want Update {0}?", repoUser.Items[index].Username);
            string caption = "Confirmation";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                DataProvider.Instance.parameters = new string[] { "Id" };

                DataProvider.Instance.values = new object[] { repoUser.Items[index].Id };

                int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateUser(1, unit.user.Items[index].Id));

                if (nRow != -1)
                {
                    repoUser.Items[index].Status = true;
                    repoUser.Items[index].ModifiedAt = DateTime.Now;
                }
                else
                {
                    MessageBox.Show("Records Lock Failed!");
                    return;
                }
            }
            else
            {
                return;
            }
        }

        public void Edit(User user, string username, string password, int index)
        {
            repoUser.UpdateByID(user.Id, username, password);
            DataProvider.Instance.parameters = new string[] { "Id", "UserName", "Password", "Status" };

            DataProvider.Instance.values = new object[] { user.Id, username, password, true };

            int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.EditUser(username, password, user.Id));

            if (nRow != -1)
            {
                repoUser.Items[index].Username = username;
                repoUser.Items[index].Password = password;
                repoUser.Items[index].ModifiedAt = DateTime.Now;
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
