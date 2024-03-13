using System.Collections.Generic;

namespace Minh_C5_Assignment
{
    class PublisherViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryPublisher repoPublisher { get; set; }

        public PublisherViewModel()
        {
            repoPublisher = unit.GetRepositoryPublisher;
        }

        public List<Publisher> GetItem()
        {
            return unit.GetRepositoryPublisher.Items;
        }

        public void Edit(string name, string phone, string address, string id)
        {
            repoPublisher.UpdateByID(id, name, phone, address);
        }
    }
}
