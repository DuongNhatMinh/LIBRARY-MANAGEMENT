using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace Minh_C5_Assignment
{
    class AuthorViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryAuthor repoAuthor { get; set; }

        public AuthorViewModel()
        {
            repoAuthor = unit.GetRepositoryAuthor;
        }

        public List<Author> GetItem()
        {
            return unit.GetRepositoryAuthor.Items;
        }

        public void UnLock(Author author, int index)
        {
            string message = string.Format("You want Update {0}?", author.Name);
            string caption = "Confirmation";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                DataProvider.Instance.parameters = new string[] { "Id" };

                DataProvider.Instance.values = new object[] { author.Id };

                int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateAuthor(1, author.Id));

                if (nRow != -1)
                {
                    repoAuthor.Items[index].Status = true;
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

        public void Lock(Author author, int index)
        {
            string message = string.Format("You want Update {0}?", author.Name);
            string caption = "Confirmation";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                DataProvider.Instance.parameters = new string[] { "Id", "ModifiedAt" };

                DataProvider.Instance.values = new object[] {   author.Id, DateTime.Now };

                int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateAuthor(0, author.Id));

                if (nRow != -1)
                {
                    repoAuthor.Items[index].Status = false;
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

        public void Edit(string name, string description, DateTime bof, string sumamary, string id)
        {
            repoAuthor.UpdateByID(id, name, description, bof, sumamary);
        }
    }
}
