namespace ConsoleApp1
{
    internal class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.ReadKey();

            Parallel.For(1, 2, Factorial);

            Console.ReadLine();
        }

        static void Factorial(int x)
        {
            
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }


            Console.WriteLine($"Task executing {Task.CurrentId}");
            Thread.Sleep(3000);
            Console.WriteLine($"Factorial {x} = {result}");

            Parallel.Invoke(
                () => 
                {
                    Console.WriteLine($"{result} has {result.ToString().Length} numbers");
                }, 
                () =>
                {
                    string tmp = result.ToString();
                    List<int> nums = new List<int>();
                    for(int i = 0; i < tmp.Length; i++)
                    {
                        nums.Add(Convert.ToInt32(tmp[i]));
                    }
                    foreach(var i in nums)
                    {
                        Console.WriteLine(i);
                    }
                    int res = 0;
                    foreach(var i in nums)
                    {
                        res += i;
                    }
                    Console.WriteLine($"number {result} has the next sum of numbers :  {nums.Sum()}");
                });

        }
    }
}