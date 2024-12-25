namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var puppyList = new PuppyList<int>()
            {
                1, 22, 57, 100, 0
            };
            puppyList.Where(x => x > 1).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("-----");
            var sortedPuppyList = puppyList.OrderBy(x => x).ToList();
            sortedPuppyList.ForEach(Console.WriteLine);
            Console.WriteLine("-----");


            var list = new List<string>()
           {
               "str", "dd", "fff"
           };
            list.ForEach(p => Console.WriteLine(p));
        }
    }
}
