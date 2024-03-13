using System.Collections.Generic;

namespace Minh_C5_Assignment
{
    class UserRoleViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryUserRole repoUserRole { get; set; }

        public UserRoleViewModel()
        {
            repoUserRole = unit.GetRepositoryUserRole;
        }

        public List<UserRole> GetItem()
        {
            return unit.GetRepositoryUserRole.Items;
        }

        public void Add(string iduser, string idrole)
        {
            repoUserRole.Add(iduser, idrole);
        }

        public void Edit(string id, string iduser, string idrole)
        {
            repoUserRole.UpdateIdRole(iduser, idrole, id);
        }
    }
}
