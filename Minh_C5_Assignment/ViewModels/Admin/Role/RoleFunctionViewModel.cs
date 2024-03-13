using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace Minh_C5_Assignment
{
    class RoleFunctionViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryRoleFunction repoRoleFunction { get; set; }
        public int flag = 0;

        public RoleFunctionViewModel()
        {
            repoRoleFunction = unit.GetRepositoryRoleFunction;
        }

        public List<RoleFunction> GetItem()
        {
            return unit.GetRepositoryRoleFunction.Items;
        }

        public void Add(string idrole, string idfunction)
        {
            repoRoleFunction.Add(idrole, idfunction);
        }

        public void Delete(string id)
        {
            DataProvider.Instance.parameters = new string[] { "Id" };

            DataProvider.Instance.values = new object[] { id };

            int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.DeleteRoleFunction(id));

            if (nRow != -1)
            {
                RoleFunction rolefunction = repoRoleFunction.GetById(id);
                repoRoleFunction.Items.Remove(rolefunction);
            }
            else
            {
                MessageBox.Show("Records Inserted Failed!");
                return;
            }
            if (flag == 0)
            {
                MessageBox.Show("Set Function for Role successfully!", "Notify", MessageBoxButton.OK);
                flag = 1;
            }
        }
    }
}
