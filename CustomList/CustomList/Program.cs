namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Remove("2");
            list.Remove("3");
            list.Add("4");
            Console.WriteLine("Hello, World!");
        }
    }
}
