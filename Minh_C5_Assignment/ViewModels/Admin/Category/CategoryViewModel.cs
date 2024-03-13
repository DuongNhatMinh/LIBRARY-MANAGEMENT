using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace Minh_C5_Assignment
{
    class CategoryViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryCategory repoCat { get; set; }

        public CategoryViewModel()
        {
            repoCat = unit.GetRepositoryCategory;
        }

        public List<Category> GetItem()
        {
            return unit.GetRepositoryCategory.Items;
        }

        public void UnLock(Category category, int index)
        {
            string message = string.Format("You want Update {0}?", category.Name);
            string caption = "Confirmation";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                DataProvider.Instance.parameters = new string[] { "Id" };

                DataProvider.Instance.values = new object[] { category.Id };

                int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateCategory(1, category.Id));

                if (nRow != -1)
                {
                    repoCat.Items[index].Status = true;
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

        public void Lock(Category category, int index)
        {
            string message = string.Format("You want Update {0}?", category.Name);
            string caption = "Confirmation";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                DataProvider.Instance.parameters = new string[] { "Id", "ModifiedAt" };

                DataProvider.Instance.values = new object[] { category.Id, DateTime.Now };

                int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateCategory(0, category.Id));

                if (nRow != -1)
                {
                    repoCat.Items[index].Status = false;
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

        public void Edit(string name, string id)
        {
            repoCat.UpdateByID(id, name);
        }
    }
}
