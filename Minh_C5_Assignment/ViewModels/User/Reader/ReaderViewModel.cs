using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace Minh_C5_Assignment
{
    class ReaderViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public List<Reader> ChildReaders { get; set; }
        public List<Child> childs { get; set; }
        public int check = 0;
        Utility ult = new Utility();
        public RepositoryReader repoReader { get; set; }
        public RepositoryAdult repoAdult { get; set; }
        public RepositoryChild repoChild { get; set; }
        public RepositoryParameter repoParameter { get; set; }

        public ReaderViewModel()
        {
            repoReader = unit.GetRepositoryReader;
            repoAdult = unit.GetRepositoryAdult;
            repoChild = unit.GetRepositoryChild;
            repoParameter = unit.GetRepositoryParameter;
        }

        public List<Reader> GetItem()
        {
            return unit.GetRepositoryReader.Items;
        }

        public void AddReader(string Lname, string Fname, DateTime selectedDate, bool readerType)
        {
            repoReader.Add(Lname, Fname, selectedDate, readerType, true, DateTime.Now, DateTime.Now);
        }

        public void Lock(object reader, int index)
        {
            ChildReaders = new List<Reader>();
            childs = new List<Child>();
            #region Lock
            Reader item = reader as Reader;
            if (item.ReaderType == true)
            {
                Adult adult = repoAdult.GetByIdReader(item.Id);
                if (ult.checkQuantity(adult) != -1)
                {
                    ult.CheckChildQuantity(adult, unit.reader.Items, unit.child.Items, ChildReaders, childs);
                    frmUpdate window = new frmUpdate(item, adult, ChildReaders, 0);
                    window.ShowDialog();
                    if (window.value == "No")
                        return;
                    else if (window.value == "Yes")
                    {
                        DataProvider.Instance.parameters = new string[] { "Id" };

                        DataProvider.Instance.values = new object[] { item.Id };

                        int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateReader(0, item.Id));

                        if (nRow != -1)
                        {
                            repoReader.Items[index].Status = false;
                        }
                        else
                        {
                            MessageBox.Show("Records Lock Failed!");
                            return;
                        }

                        DataProvider.Instance.parameters = new string[] { "IdReader" };

                        DataProvider.Instance.values = new object[] { adult.IdReader };

                        nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateAdult(0, adult.IdReader));

                        if (nRow != -1)
                        {
                            int idx = ult.getIndex(item.Id, unit.adult.Items);
                            repoAdult.Items[idx].Status = false;
                        }
                        else
                        {
                            MessageBox.Show("Records Lock Failed!");
                            return;
                        }

                        for (int i = 0; i < ChildReaders.Count; i++)
                        {
                            DataProvider.Instance.parameters = new string[] { "Id" };

                            DataProvider.Instance.values = new object[] { ChildReaders[i].Id };

                            nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateReader(0, ChildReaders[i].Id));

                            if (nRow != -1)
                            {
                                int idx = ult.getIndex(ChildReaders[i].Id, repoReader.Items);
                                repoReader.Items[idx].Status = false;
                            }
                            else
                            {
                                MessageBox.Show("Records Lock Failed!");
                                return;
                            }
                        }

                        for (int j = 0; j < childs.Count; j++)
                        {
                            DataProvider.Instance.parameters = new string[] { "IdReader" };

                            DataProvider.Instance.values = new object[] { childs[j].IdReader };

                            nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateChild(0, childs[j].IdReader));

                            if (nRow != -1)
                            {
                                int idx = ult.getIndex(childs[j].IdReader, repoChild.Items);
                                repoChild.Items[idx].Status = false;
                            }
                            else
                            {
                                MessageBox.Show("Records Lock Failed!");
                                return;
                            }
                        }
                        MessageBox.Show("Lock Adult reader successfully!", "Notify", MessageBoxButton.OK);
                    }
                }
                else
                {
                    DataProvider.Instance.parameters = new string[] { "Id" };

                    DataProvider.Instance.values = new object[] { item.Id };

                    int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateReader(0, item.Id));

                    if (nRow != -1)
                    {
                        repoReader.Items[index].Status = false;
                    }
                    else
                    {
                        MessageBox.Show("Records Lock Failed!");
                        return;
                    }

                    DataProvider.Instance.parameters = new string[] { "IdReader" };

                    DataProvider.Instance.values = new object[] { adult.IdReader };

                    nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateAdult(0, adult.IdReader));

                    if (nRow != -1)
                    {
                        int idx = ult.getIndex(item.Id, repoAdult.Items);
                        repoAdult.Items[idx].Status = false;
                    }
                    else
                    {
                        MessageBox.Show("Records Lock Failed!");
                        return;
                    }

                    MessageBox.Show("Lock Adult reader successfully!", "Notify", MessageBoxButton.OK);
                }
            }
            else
            {
                Child child = repoChild.GetByReaderID(item.Id);
                DataProvider.Instance.parameters = new string[] { "Id" };

                DataProvider.Instance.values = new object[] { item.Id };

                int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateReader(0, item.Id));

                if (nRow != -1)
                {
                    repoReader.Items[index].Status = false;
                }
                else
                {
                    MessageBox.Show("Records Lock Failed!");
                    return;
                }

                DataProvider.Instance.parameters = new string[] { "IdReader" };

                DataProvider.Instance.values = new object[] { child.IdReader };

                nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateChild(0, child.IdReader));

                if (nRow != -1)
                {
                    int idx = ult.getIndex(item.Id, repoChild.Items);
                    repoChild.Items[idx].Status = false;
                }
                else
                {
                    MessageBox.Show("Records Lock Failed!");
                    return;
                }
                MessageBox.Show("Lock Child reader successfully!", "Notify", MessageBoxButton.OK);
            }
            #endregion
        }

        public void UnLock(object reader, int index)
        {
            ChildReaders = new List<Reader>();
            childs = new List<Child>();
            #region UnLock
            Reader item = reader as Reader;
            if (item.ReaderType == true)
            {
                Adult adult = repoAdult.GetByIdReader(item.Id);
                if (ult.checkQuantity(adult) != -1)
                {
                    ult.CheckChildQuantity(adult, unit.reader.Items, unit.child.Items, ChildReaders, childs);
                    frmUpdate window = new frmUpdate(item, adult, ChildReaders, 1);
                    window.ShowDialog();
                    if (window.value == "No")
                        return;
                    else if (window.value == "Yes")
                    {
                        DataProvider.Instance.parameters = new string[] { "Id" };

                        DataProvider.Instance.values = new object[] { item.Id };

                        int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateReader(1, item.Id));

                        if (nRow != -1)
                        {
                            repoReader.Items[index].Status = true;
                        }
                        else
                        {
                            MessageBox.Show("Records UnLock Failed!");
                            return;
                        }

                        DataProvider.Instance.parameters = new string[] { "IdReader" };

                        DataProvider.Instance.values = new object[] { adult.IdReader };

                        nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateAdult(1, adult.IdReader));

                        if (nRow != -1)
                        {
                            int idx = ult.getIndex(item.Id, repoAdult.Items);
                            repoAdult.Items[idx].Status = true;
                        }
                        else
                        {
                            MessageBox.Show("Records UnLock Failed!");
                            return;
                        }

                        for (int i = 0; i < ChildReaders.Count; i++)
                        {
                            DataProvider.Instance.parameters = new string[] { "Id" };

                            DataProvider.Instance.values = new object[] { ChildReaders[i].Id };

                            nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateReader(1, ChildReaders[i].Id));

                            if (nRow != -1)
                            {
                                int idx = ult.getIndex(ChildReaders[i].Id, repoReader.Items);
                                repoReader.Items[idx].Status = true;
                            }
                            else
                            {
                                MessageBox.Show("Records UnLock Failed!");
                                return;
                            }
                        }
                        for (int j = 0; j < childs.Count; j++)
                        {
                            DataProvider.Instance.parameters = new string[] { "IdReader" };

                            DataProvider.Instance.values = new object[] { childs[j].IdReader };

                            nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateChild(1, childs[j].IdReader));

                            if (nRow != -1)
                            {
                                int idx = ult.getIndex(childs[j].IdReader, repoChild.Items);
                                repoChild.Items[idx].Status = true;
                            }
                            else
                            {
                                MessageBox.Show("Records UnLock Failed!");
                                return;
                            }
                        }
                        MessageBox.Show("UnLock Adult reader successfully!", "Notify", MessageBoxButton.OK);
                    }
                }
                else
                {
                    DataProvider.Instance.parameters = new string[] { "Id" };

                    DataProvider.Instance.values = new object[] { item.Id };

                    int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateReader(1, item.Id));

                    if (nRow != -1)
                    {
                        repoReader.Items[index].Status = true;
                    }
                    else
                    {
                        MessageBox.Show("Records UnLock Failed!");
                        return;
                    }

                    DataProvider.Instance.parameters = new string[] { "IdReader" };

                    DataProvider.Instance.values = new object[] { adult.IdReader };

                    nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateAdult(1, adult.IdReader));

                    if (nRow != -1)
                    {
                        int idx = ult.getIndex(item.Id, repoAdult.Items);
                        repoAdult.Items[idx].Status = true;
                    }
                    else
                    {
                        MessageBox.Show("Records UnLock Failed!");
                        return;
                    }

                    MessageBox.Show("UnLock Adult reader successfully!", "Notify", MessageBoxButton.OK);
                }
            }
            else
            {
                Child child = repoChild.GetByReaderID(item.Id);
                Adult adult = repoAdult.GetByIdReader(child.IdAdult);

                Parameter parameter = repoParameter.GetByID("QD1");
                int value = int.Parse(parameter.Value);
                int Quantity = 0;

                for (int j = 0; j < repoChild.Items.Count; j++)
                {
                    if (Quantity == 2)
                    {
                        check = 1;
                        return;
                    }
                    if (adult.IdReader == repoChild.Items[j].IdAdult)
                    {
                        Quantity++;
                    }
                }

                if (adult.Status == false)
                {
                    MessageBox.Show("Guardian is Lock!");
                    return;
                }
                else
                {
                    DataProvider.Instance.parameters = new string[] { "Id" };

                    DataProvider.Instance.values = new object[] { item.Id };

                    int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateReader(1, item.Id));

                    if (nRow != -1)
                    {
                        repoReader.Items[index].Status = true;
                    }
                    else
                    {
                        MessageBox.Show("Records UnLock Failed!");
                        return;
                    }

                    DataProvider.Instance.parameters = new string[] { "IdReader" };

                    DataProvider.Instance.values = new object[] { child.IdReader };

                    nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateChild(1, child.IdReader));

                    if (nRow != -1)
                    {
                        int idx = ult.getIndex(item.Id, repoChild.Items);
                        repoChild.Items[idx].Status = true;
                    }
                    else
                    {
                        MessageBox.Show("Records UnLock Failed!");
                        return;
                    }
                    MessageBox.Show("UnLock Child reader successfully!", "Notify", MessageBoxButton.OK);
                }
            }
            #endregion
        }
    }
}
