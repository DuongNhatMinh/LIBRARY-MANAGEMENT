using System.Collections.Generic;

namespace Minh_C5_Assignment
{
    class ProvinceViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryProvince repoProvince { get; set; }

        public ProvinceViewModel()
        {
            repoProvince = unit.GetRepositoryProvince;
        }

        public List<Province>GetItem()
        {
            return unit.GetRepositoryProvince.Items;
        }
    }
}
