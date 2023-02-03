internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Please Enter a Number");

        for (int i = 1; i < 10; i++)
        {
            if (i == 4)
                break;
            Console.WriteLine(i);
        }
        for (int i = 1; i < 10; i++)
        {
            if (i == 4)
                continue;
            Console.WriteLine(i);
        }


    }
}