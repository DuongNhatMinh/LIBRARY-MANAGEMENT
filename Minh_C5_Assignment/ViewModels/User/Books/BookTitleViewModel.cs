using System.Collections.Generic;

namespace Minh_C5_Assignment
{
    class BookTitleViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryBookTitle repoBookTitle { get; set; }

        public BookTitleViewModel()
        {
            repoBookTitle = unit.GetRepositoryBookTitle;
        }

        public List<BookTitle> GetItem()
        {
            return unit.GetRepositoryBookTitle.Items;
        }

        public void AddBookTitle(string Idcategory, string Name, string Summary)
        {
            repoBookTitle.Add(Idcategory, Name, Summary);
        }
    }
}
