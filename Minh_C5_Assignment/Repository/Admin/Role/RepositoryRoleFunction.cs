using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace Minh_C5_Assignment
{
    class RepositoryRoleFunction :RepositoryBase<RoleFunction>
    {
        public RepositoryRoleFunction()
        {
            Items = new List<RoleFunction>();
            Load();
        }

        public List<RoleFunction> Load()
        {
            Items = DatabaseFirst.Instance.db.RoleFunctions.ToList();
            return Items;
        }

        public string GetNewID()
        {
            string id = "RF";

            int number = Items.Select(item => int.Parse(item.Id.Substring(2))).DefaultIfEmpty(0).Max() + 1;

            id += number;

            return id;
        }

        public void Add(string idRole, string idFunction)
        {
            string newID = GetNewID();

            var newRoleFunction = new RoleFunction()
            {
                Id = newID,
                IdFunction = idFunction,
                IdRole = idRole
            };

            Items.Add(newRoleFunction);

            DatabaseFirst.Instance.db.RoleFunctions.Add(newRoleFunction);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public RoleFunction GetById(string id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }

        public RoleFunction GetByIdFunction(string idfunction, string idrole)
        {
            return Items.FirstOrDefault(x => x.IdFunction == idfunction && x.IdRole == idrole);
        }

        public bool check(string id, string idrole)
        {
            foreach (var item in Items)
            {
                if (item.IdRole == "R1")
                    continue;
                if (id == item.IdFunction && item.IdRole == idrole)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetIndex(string id)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (id == Items[i].Id)
                {
                    return i;
                }
            }
            return -1;
        }

        public List<string> GetLast()
        {
            List<string> num = new List<string>();
            foreach(var item in Items)
            {
                string resultString = Regex.Match(item.Id, @"\d+").Value;
                Int32.Parse(resultString);
                num.Add(resultString);
            }
            return num;
        }
    }
}
