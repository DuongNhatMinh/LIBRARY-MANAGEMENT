using System.Collections.Generic;

namespace Minh_C5_Assignment
{
    class ChildViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryChild repoChild { get; set; }

        public ChildViewModel()
        {
            repoChild = unit.GetRepositoryChild;
        }

        public List<Child> GetItem()
        {
            return unit.GetRepositoryChild.Items;
        }

        public void AddChild(string idadult)
        {
            repoChild.Add(idadult);
        }
    }
}
