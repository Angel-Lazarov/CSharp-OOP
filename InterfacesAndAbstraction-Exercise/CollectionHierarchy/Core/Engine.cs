using CollectionHierarchy.Core.Interfaces;
using CollectionHierarchy.Models.Interfaces;
using CollectionHierarchy.Models;

namespace CollectionHierarchy.Core
{
    internal class Engine : IEngine
    {
        public void Run()
        {
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IAddCollection addCollection = new AddCollection();
                IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
                IMyList myList = new MyList();


                List<int> addResult = new List<int>();

                List<int> addRemoveResult = new List<int>();
                List<string> addRemoveRemovedItems = new List<string>();

                List<int> myListResult = new List<int>();
                List<string> myListRemovedItems = new List<string>();

                for (int i = 0; i < input.Length; i++)
                {
                    int addIndex = addCollection.Add(input[i]);
                    addResult.Add(addIndex);

                    int addRemoveIndex = addRemoveCollection.Add(input[i]);
                    addRemoveResult.Add(addRemoveIndex);


                    int myListIndex = myList.Add(input[i]);
                    myListResult.Add(myListIndex);
                }

                int removeCount = int.Parse(Console.ReadLine());

                for (int i = 0; i < removeCount; i++)
                {
                    string removed = addRemoveCollection.Remove();
                    addRemoveRemovedItems.Add(removed);

                    removed = myList.Remove();
                    myListRemovedItems.Add(removed);
                }

                Console.WriteLine(string.Join(" ", addResult));
                Console.WriteLine(string.Join(" ", addRemoveResult));
                Console.WriteLine(string.Join(" ", myListResult));
                Console.WriteLine(string.Join(" ", addRemoveRemovedItems));
                Console.WriteLine(string.Join(" ", myListRemovedItems));

            }
        }
    }
}
