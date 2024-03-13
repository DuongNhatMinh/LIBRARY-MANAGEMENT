using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace Minh_C5_Assignment
{
    class ParameterViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryParameter repoParameter { get; set; }

        public ParameterViewModel()
        {
            repoParameter = unit.GetRepositoryParameter;
        }
        
        public List<Parameter> GetItem()
        {
            return unit.GetRepositoryParameter.Items;
        }

        public void UnLock(Parameter paramenter, int index)
        {
            string message = string.Format("You want Update {0}?", paramenter.Name);
            string caption = "Confirmation";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                DataProvider.Instance.parameters = new string[] { "Id" };

                DataProvider.Instance.values = new object[] { paramenter.Id };

                int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateParamenter(1, paramenter.Id));

                if (nRow != -1)
                {
                    repoParameter.Items[index].Status = true;
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

        public void Lock(object paramenter, int index)
        {
            Parameter paramentertemp = paramenter as Parameter;
            string message = string.Format("You want Update {0}?", paramentertemp.Name);
            string caption = "Confirmation";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                DataProvider.Instance.parameters = new string[] { "Id", "ModifiedAt" };

                DataProvider.Instance.values = new object[] { paramentertemp.Id, DateTime.Now };

                int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateParamenter(0, paramentertemp.Id));

                if (nRow != -1)
                {
                    repoParameter.Items[index].Status = false;
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

        public void Edit(string name, string description, string value, string id)
        {
            repoParameter.UpdateByID(id, name, description, value);
        }
    }
}
