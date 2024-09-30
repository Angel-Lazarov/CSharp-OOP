using CollectionHierarchy.Core.Interfaces;
using CollectionHierarchy.Models.Interfaces;
using CollectionHierarchy.Models;

namespace CollectionHierarchy.Core
{
    internal class Engine2 : IEngine
    {
        public void Run()
        {
            IAddCollection addCollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyList myList = new MyList();

            Dictionary<string, List<int>> addedIndexes = new()
            {
                { "AddCollection", new List<int>() },
                { "AddRemoveCollection", new List<int>() },
                { "MyList", new List<int>() },
            };

            Dictionary<string, List<string>> removedItems = new()
            {
                { "AddCollection", new List<string>() },
                { "AddRemoveCollection", new List<string>() },
                { "MyList", new List<string>() },
            };

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                addedIndexes["AddCollection"].Add(addCollection.Add(input[i]));

                addedIndexes["AddRemoveCollection"].Add(addRemoveCollection.Add(input[i]));

                addedIndexes["MyList"].Add(myList.Add(input[i]));
            }

            int removeCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < removeCount; i++)
            {
                removedItems["AddRemoveCollection"].Add(addRemoveCollection.Remove());
                removedItems["MyList"].Add(myList.Remove());
            }

            Console.WriteLine(string.Join(" ", addedIndexes["AddCollection"]));
            Console.WriteLine(string.Join(" ", addedIndexes["AddRemoveCollection"]));
            Console.WriteLine(string.Join(" ", addedIndexes["MyList"]));

            Console.WriteLine(string.Join(" ", removedItems["AddRemoveCollection"]));
            Console.WriteLine(string.Join(" ", removedItems["MyList"]));
        }
    }
}
