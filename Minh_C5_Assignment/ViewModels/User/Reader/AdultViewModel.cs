using System;
using System.Collections.Generic;

namespace Minh_C5_Assignment
{
    class AdultViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryAdult repoAdult { get; set; }

        public AdultViewModel()
        {
            repoAdult = unit.GetRepositoryAdult;
        }

        public List<Adult> GetItem()
        {
            return unit.GetRepositoryAdult.Items;
        }

        public void Add(string identidy, string address, string city, string phone, string expDate)
        {
            repoAdult.Add(identidy, address, city, phone, DateTime.Parse(expDate), true, DateTime.Now, DateTime.Now);
            //MessageBox.Show("Add Adult reader successfully!", "Notify", MessageBoxButton.OK);
        }
    }
}
