using System.Collections.Generic;

namespace Minh_C5_Assignment
{
    class PenaltyReasonViewModel
    {
        private static readonly UnitofWork unit = new UnitofWork();
        public RepositoryPenaltyReason repoPenalty { get; set; }

        public PenaltyReasonViewModel()
        {
            repoPenalty = unit.GetRepositoryPenaltyReason;
        }

        public List<PenaltyReason> GetItem()
        {
            return unit.GetRepositoryPenaltyReason.Items;
        }

        public void Edit(string name, string description, decimal value, string id)
        {
            repoPenalty.UpdateByID(id, name, description, value);
        }
    }
}
