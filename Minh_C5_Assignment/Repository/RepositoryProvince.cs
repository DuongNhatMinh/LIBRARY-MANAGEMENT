using System.Collections.Generic;
using System.Linq;

namespace Minh_C5_Assignment
{
    class RepositoryProvince : RepositoryBase<Province>
    {
        public RepositoryProvince()
        {
            Items = new List<Province>();
            Load();
        }

        public List<Province> Load()
        {
            Items = DatabaseFirst.Instance.db.Provinces.ToList();
            return Items;
        }
    }
}
