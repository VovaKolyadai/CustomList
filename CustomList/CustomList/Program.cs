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
            puppyList.ExpandedEvent += Grow;

            puppyList.Where(x => x > 1).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("-----");
            var sortedPuppyList = puppyList.OrderBy(x => x).ToList();
            sortedPuppyList.ForEach(Console.WriteLine);
            Console.WriteLine("-----");
            for (int i = 0; i < 100; i++)
            {
                puppyList.Add(1);
            }

            var list = new List<string>()
           {
               "str", "dd", "fff"
           };
            list.ForEach(Console.WriteLine);
        }
        public static void Grow(object sender, EventArgs e)
        {
            Console.WriteLine("GROOOOW");
        }
    }
}
