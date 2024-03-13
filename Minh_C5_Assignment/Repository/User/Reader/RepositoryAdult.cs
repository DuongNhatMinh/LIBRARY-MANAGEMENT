using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;

namespace Minh_C5_Assignment
{
    class RepositoryAdult : RepositoryBase<Adult>
    {
        public RepositoryAdult()
        {
            Items = new List<Adult>();
            Load();
        }

        public List<Adult> Load()
        {
            Items = DatabaseFirst.Instance.db.Adults.ToList();
            return Items;
        }

        public void Add(string identify, string address, string city, string phone, DateTime expDate, bool status, DateTime createdAt, DateTime modifiedAt)
        {
            string newID = RepositoryReader.GetNewID();
            var newAdult = new Adult()
            {
                Address = address,
                City = city,
                CreatedAt = createdAt,
                IdReader = newID,
                Identify = identify,
                ModifiedAt = modifiedAt,
                Phone = phone,
                ExpireDate = expDate,
                Status = true
            };
            Items.Add(newAdult);
            DatabaseFirst.Instance.db.Adults.Add(newAdult);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public void UpdateStatusById(int status, string id)
        {
            DataProvider.Instance.parameters = new string[] { "IdReader" };
            DataProvider.Instance.values = new object[] { id };

            int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, tSQL.UpdateAdult(status, id));

            if (nRow != -1)
            {
                foreach (var item in Items)
                {
                    if (item.IdReader == id)
                        item.Status = status == 0 ? false : true;
                }
            }
            else
                MessageBox.Show("Records Deleted Failed!");
        }

        public Adult GetByIdReader(string IdReader) => Items.Find(e => e.IdReader.CompareTo(IdReader) == 0);

        public void Delete(string id)
        {
            var entity = Items.Where(e => e.IdReader.CompareTo(id) == 0).FirstOrDefault();
            Items.Remove(entity);
            DatabaseFirst.Instance.db.Adults.Remove(entity);
            DatabaseFirst.Instance.db.SaveChanges();
        }

    }
}
