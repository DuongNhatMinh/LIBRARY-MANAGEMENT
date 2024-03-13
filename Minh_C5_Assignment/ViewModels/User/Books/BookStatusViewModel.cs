using System.Collections.Generic;

namespace Minh_C5_Assignment
{
    class BookStatusViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryBookStatus repoBookStatus { get; set; }

        public BookStatusViewModel()
        {
            repoBookStatus = unit.GetRepositoryBookStatus;
        }

        public List<BookStatu> GetItem()
        {
            return unit.GetRepositoryBookStatus.Items;
        }
    }
}
