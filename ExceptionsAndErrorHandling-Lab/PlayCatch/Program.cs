namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            IndexOutOfRangeException outOfRangeException = new IndexOutOfRangeException("The index does not exist!");

            int catchedExceptions = 0;

            while (catchedExceptions < 3)
            {
                string[] commandInfo = Console.ReadLine().Split();
                string command = commandInfo[0];

                try
                {
                    switch (command)
                    {
                        case "Replace":
                            int index = int.Parse(commandInfo[1]);
                            int element = int.Parse(commandInfo[2]);


                            if (index < 0 || index > array.Length - 1)
                            {

                                throw outOfRangeException;
                            }

                            array[index] = element;

                            break;

                        case "Print":
                            int startIndex = int.Parse(commandInfo[1]);
                            int endIndex = int.Parse(commandInfo[2]);

                            if (startIndex < 0 || endIndex > array.Length - 1)
                            {

                                throw outOfRangeException;
                            }

                            //for (int i = startIndex; i <= endIndex - 1; i++)
                            //{
                            //    Console.WriteLine(array[i] + ", ");
                            //}
                            //Console.WriteLine(array[endIndex]);

                            List<int> filtered = new();

                            for (int i = startIndex; i < endIndex + 1; i++)
                            {
                                filtered.Add(array[i]);
                            }

                            Console.WriteLine(string.Join(", ", filtered));

                            break;

                        case "Show":
                            int showIndex = int.Parse(commandInfo[1]);

                            if (showIndex < 0 || showIndex > array.Length - 1)
                            {

                                throw outOfRangeException;
                            }

                            Console.WriteLine(array[showIndex]);

                            break;
                    }

                }
                catch (FormatException)
                {
                    catchedExceptions++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
                catch (IndexOutOfRangeException ex)
                {
                    catchedExceptions++;
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }
    }
}
