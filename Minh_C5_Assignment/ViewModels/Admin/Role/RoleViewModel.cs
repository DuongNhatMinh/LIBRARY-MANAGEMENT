using System.Collections.Generic;

namespace Minh_C5_Assignment
{
    class RoleViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryRole repoRole { get; set; }

        public RoleViewModel()
        {
            repoRole = unit.GetRepositoryRole;
        }

        public List<Role> GetItem()
        {
            return unit.GetRepositoryRole.Items;
        }

        public void Add(string name, string group)
        {
            repoRole.Add(name, group);
        }
    }
}
