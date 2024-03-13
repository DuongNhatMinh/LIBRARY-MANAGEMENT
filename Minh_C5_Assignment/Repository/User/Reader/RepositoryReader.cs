using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;

namespace Minh_C5_Assignment
{
    class RepositoryReader : RepositoryBase<Reader>
    {
        public RepositoryReader()
        {
            Items = new List<Reader>();
            Load();
        }

        public List<Reader> Load()
        {
            Items = DatabaseFirst.Instance.db.Readers.ToList();
            return Items;
        }

        public void Add(string lName, string fName, DateTime boF, bool readerType, bool status, DateTime createdAt, DateTime modifiedAt)
        {
            string newID = GetNewID();

            var newReader = new Reader()
            {
                boF = boF,
                CreatedAt = createdAt,
                ModifiedAt = modifiedAt,
                FName = fName,
                LName = lName,
                Id = newID,
                ReaderType = readerType,
                Status = status
            };

            DatabaseFirst.Instance.db.Readers.Add(newReader);
            Items.Add(newReader);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public void UpdateStatusById(bool status, string id)
        {
            var bookISBN = DatabaseFirst.Instance.db.Readers.FirstOrDefault(i => i.Id == id);
            bookISBN.Status = status;

            var item = GetById(id);
            item.Status = status;
            DatabaseFirst.Instance.db.SaveChanges();

            DataProvider.Instance.parameters = new string[] { "Id" };
            DataProvider.Instance.values = new object[] { id };
            int nRow;
            if(status == true)
                nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateReader(1, id));
            else
                nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateReader(0, id));
            if (nRow != -1)
            {
                foreach (var item2 in Items)
                {
                    if (item2.Id == id)
                        item2.Status = status;
                }
            }
            else
                MessageBox.Show("Records Deleted Failed!");
        }

        public Reader GetById(string id) => Items.Find(e => e.Id.ToLower().CompareTo(id.ToLower()) == 0);

        public static string GetNewID()
        {
            string id = "R";

            var number = DatabaseFirst.Instance.db.Readers.Select(reader => reader.Id.Substring(1)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public Reader GetFirstReader()
        {
            if (Items.Count == 0)
                return null;
            return Items[0];
        }

        public void Delete(string id)
        {
            var entity = Items.Where(e => e.Id.CompareTo(id) == 0).FirstOrDefault();
            Items.Remove(entity);
        }
    }
}
