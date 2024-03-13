using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace Minh_C5_Assignment
{
    class FunctionViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryFunction repoFunction { get; set; }

        public FunctionViewModel()
        {
            repoFunction = unit.GetRepositoryFunction;
        }

        public List<Function> GetItem()
        {
            return unit.GetRepositoryFunction.Items;
        }

        public void Edit(string name, string description, string idparent, string urlimage, string id)
        {
            repoFunction.UpdateByID(id, name, description, idparent, urlimage);
        }

        public void Lock(object function, int index)
        {
            Function functiontemp = function as Function;
            string message = string.Format("You want Update {0}?", functiontemp.Name);
            string caption = "Confirmation";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                DataProvider.Instance.parameters = new string[] { "Id", "ModifiedAt" };

                DataProvider.Instance.values = new object[] { functiontemp.Id, DateTime.Now };

                int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateFunction(0, functiontemp.Id));

                if (nRow != -1)
                {
                    repoFunction.Items[index].Status = false;
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
            string message = string.Format("You want Update {0}?", unit.function.Items[index].Name);
            string caption = "Confirmation";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                DataProvider.Instance.parameters = new string[] { "Id" };

                DataProvider.Instance.values = new object[] { unit.function.Items[index].Id };

                int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateFunction(1, unit.function.Items[index].Id));

                if (nRow != -1)
                {
                    repoFunction.Items[index].Status = true;
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
    }
}
