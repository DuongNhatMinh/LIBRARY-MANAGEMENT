using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryParameter : RepositoryBase<Parameter>
    {
        public RepositoryParameter()
        {
            Items = new List<Parameter>();
            Load();
        }

        public List<Parameter> Load()
        {
            Items = DatabaseFirst.Instance.db.Parameters.ToList();
            return Items;
        }

        public static string GetNewID()
        {
            string id = "QD";

            var number = DatabaseFirst.Instance.db.Parameters.Select(i => i.Id.Substring(2)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(Parameter newParameter)
        {
            Items.Add(newParameter);
            DatabaseFirst.Instance.db.Parameters.Add(newParameter);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public Parameter GetByID(string ID)
        {
            return Items.FirstOrDefault(x => x.Id == ID);
        }

        public void UpdateByID(string id, string name, string description, string value )
        {
            Parameter parameter = Items.Find(i => i.Id == id);
            parameter.Name = name;
            parameter.Description = description;
            parameter.Value = value;
            parameter.ModifiedAt = DateTime.Now;

            var parameterDB = DatabaseFirst.Instance.db.Parameters.FirstOrDefault(i => i.Id == id);
            parameterDB.Name = name;
            parameterDB.Description = description;
            parameterDB.Value = value;
            parameterDB.ModifiedAt = DateTime.Now;
            DatabaseFirst.Instance.db.SaveChanges();
        }
    }
}
