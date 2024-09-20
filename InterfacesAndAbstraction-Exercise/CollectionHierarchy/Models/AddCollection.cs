using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        private List<string> collection;

        public AddCollection()
        {
            collection = new List<string>();
        }


        int IAddCollection.Add(string item)
        {
            int position = collection.Count;
            collection.Add(item);
            return position;

            //return collection.Count - 1;
        }
    }
}
