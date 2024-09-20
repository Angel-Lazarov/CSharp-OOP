using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        private List<string> collection;
        public MyList() 
        {
            collection = new();        
        }

        public int Add(string item)
        {
            collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string removed = collection[0];
            collection.RemoveAt(0);
            return removed;
        }

        public int Used() => collection.Count;
        //{
        //    return collection.Count;
        //}
    }
}
