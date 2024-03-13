using System;
using System.Collections.Generic;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryPenaltyReason : RepositoryBase<PenaltyReason>
    {
        public RepositoryPenaltyReason()
        {
            Items = new List<PenaltyReason>();
            Load();
        }

        public List<PenaltyReason> Load()
        {
            Items = DatabaseFirst.Instance.db.PenaltyReasons.ToList();
            return Items;
        }

        public PenaltyReason GetByName(string name) => Items.Find(e => e.Name.ToLower().CompareTo(name.ToLower()) == 0);

        public static string GetNewID()
        {
            string id = "PR";

            var number = DatabaseFirst.Instance.db.PenaltyReasons.Select(i => i.Id.Substring(2)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(PenaltyReason newPenalty)
        {
            Items.Add(newPenalty);
            DatabaseFirst.Instance.db.PenaltyReasons.Add(newPenalty);
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public void UpdateByID(string id, string name, string description, decimal value)
        {
            //PenaltyReason penalty = Items.Find(i => i.Id == id);
            //penalty.Name = name;
            //penalty.Description = description;
            //penalty.Price = value;
            //penalty.ModifiedAt = DateTime.Now;

            var penaltyDB = DatabaseFirst.Instance.db.PenaltyReasons.FirstOrDefault(i => i.Id == id);
            penaltyDB.Name = name;
            penaltyDB.Description = description;
            penaltyDB.Price = value;
            penaltyDB.ModifiedAt = DateTime.Now;
            DatabaseFirst.Instance.db.SaveChanges();
        }

        public void Delete(PenaltyReason penalty)
        {
            Items.Remove(penalty);
            DatabaseFirst.Instance.db.PenaltyReasons.Remove(penalty);
            DatabaseFirst.Instance.db.SaveChanges();
        }
    }
}
