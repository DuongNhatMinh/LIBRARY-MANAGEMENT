using System.Collections.Generic;

namespace Minh_C5_Assignment
{
    class Utility
    {
        AdultViewModel adultVM { get; set; }
        ChildViewModel childVM { get; set; }
        ParameterViewModel parameterVM { get; set; }
        public int Quantity = 0;
        public string idAdult = string.Empty;

        public Utility()
        {
            adultVM = new AdultViewModel();
            childVM = new ChildViewModel();
            parameterVM = new ParameterViewModel();
        }

        public int checkQuantity( Adult adult)
        {
            Quantity = 0;
            Parameter parameter = parameterVM.repoParameter.GetByID("QD1");
            int value = int.Parse(parameter.Value);

            for (int j = 0; j < childVM.repoChild.Items.Count; j++)
            {
                if (adult.IdReader == childVM.repoChild.Items[j].IdAdult)
                {
                    Quantity++;
                    if (Quantity <= value)
                    {
                        return 1;
                    }
                }
            }
            return -1;
        }

        public int getIndex(string id, List<Child> childs)
        {
            for(int i = 0; i < childs.Count; i++)
            {
                if (childs[i].IdReader == id)
                    return i;
            }
            return -1;
        }

        public int getIndex(string id, List<Adult> adults)
        {
            for (int i = 0; i < adults.Count; i++)
            {
                if (adults[i].IdReader == id)
                    return i;
            }
            return -1;
        }

        public int getIndex(string id, List<Reader> readers)
        {
            for (int i = 0; i < readers.Count; i++)
            {
                if (readers[i].Id == id)
                    return i;
            }
            return -1;
        }

        public int getQuantity(Adult adult)
        {
            int Quantity = 0;

            for (int j = 0; j < childVM.repoChild.Items.Count; j++)
            {
                if (adult.IdReader == childVM.repoChild.Items[j].IdAdult)
                {
                    Quantity++;
                }
            }
            return Quantity;
        }

        public void CheckChildQuantity(Adult adult, List<Reader> ItemChildReaders, List<Child>ItemChilds, List<Reader> ChildReaders, List<Child> childs)
        {
            for (int j = 0; j < ItemChilds.Count; j++)
            {
                if (adult.IdReader == ItemChilds[j].IdAdult)
                {
                    for (int i = 0; i < ItemChildReaders.Count; i++)
                    {
                        if (ItemChilds[j].IdReader == ItemChildReaders[i].Id)
                        {
                            ChildReaders.Add(ItemChildReaders[i]);
                            childs.Add(ItemChilds[j]);
                        }
                    }
                }
            }
        }

    }
}
