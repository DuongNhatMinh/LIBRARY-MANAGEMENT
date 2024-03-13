using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace Minh_C5_Assignment
{
    class TranslatorViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryTranslator repoTranslator { get; set; }

        public TranslatorViewModel()
        {
            repoTranslator = unit.GetRepositoryTranslator;
        }

        public List<Translator> GetItem()
        {
            return unit.GetRepositoryTranslator.Items;
        }

        public void UnLock(Translator translator, int index)
        {
            string message = string.Format("You want Update {0}?", translator.Name);
            string caption = "Confirmation";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                DataProvider.Instance.parameters = new string[] { "Id" };

                DataProvider.Instance.values = new object[] { translator.Id };

                int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateTranslator(1, translator.Id));

                if (nRow != -1)
                {
                    repoTranslator.Items[index].Status = true;
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

        public void Lock(Translator translator, int index)
        {
            string message = string.Format("You want Update {0}?", translator.Name);
            string caption = "Confirmation";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                DataProvider.Instance.parameters = new string[] { "Id", "ModifiedAt" };

                DataProvider.Instance.values = new object[] { translator.Id, DateTime.Now };

                int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateTranslator(0, translator.Id));

                if (nRow != -1)
                {
                    repoTranslator.Items[index].Status = false;
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
            repoTranslator.UpdateByID(id, name, description, bof, sumamary);
        }
    }
}
