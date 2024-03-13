using System.Collections.Generic;
using System.Linq;

namespace Minh_C5_Assignment
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public List<T> Items { get; set; }

        public RepositoryBase()
        {
            Items = new List<T>();
        }

        public int Length()
        {
            return Items.Count();
        }

        public List<T> Gets()
        {
            return Items;
        }

        public T GetByIndex(int index)
        {
            return Items[index];
        }

        public void BulkInsert(List<T> entities)
        {
            Items.AddRange(entities);
        }
    }
}
