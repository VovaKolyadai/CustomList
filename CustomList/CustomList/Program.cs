namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var puppyList = new PuppyList<string>()
            {
                "str", "dd", "fff"
            };
            foreach (var p in puppyList)
                Console.WriteLine(p);
            Console.WriteLine(puppyList[0]);
            

            var list = new List<string>()
           {
               "str", "dd", "fff"
           };
            list.ForEach(p => Console.WriteLine(p));
        }
    }
}
