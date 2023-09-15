using System.Text.Json;
using System.Text.Json.Nodes;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();

            
            List<string> list = JsonSerializer.Deserialize<List<string>>(File.ReadAllText("C:\\Users\\mka.STEP.000\\source\\repos\\ConsoleApp1\\ConsoleApp2\\13"));
            List<int> list1 = JsonSerializer.Deserialize<List<int>>(File.ReadAllText("C:\\Users\\mka.STEP.000\\source\\repos\\ConsoleApp1\\ConsoleApp2\\dobutok13"));

            foreach (var I in list)
            {
                Console.WriteLine(I);
            }
            Console.ReadLine();

            Parallel.Invoke(() =>
            {
                Console.WriteLine(list1.Sum());
            },
            () =>
            {
                Console.WriteLine(list1.Min());
            },
            () =>
            {
                Console.WriteLine(list1.Max());
            },
            () =>
            {
                Console.WriteLine(list1.Average());
            },);

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

        }


        public static void MultiplyTable(int right)
        {
            List<string> listtofile= new List<string>();
            List<int> dobutoks = new List<int>();
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{right} * {i} = {right * i}");
                listtofile.Add($"{right} * {i} = {right * i}");
                dobutoks.Add(right * i);
            }
            string a = JsonSerializer.Serialize(listtofile);
            string b = JsonSerializer.Serialize(dobutoks);
            Console.Write(a);
            File.WriteAllText($"C:\\Users\\mka.STEP.000\\source\\repos\\ConsoleApp1\\ConsoleApp2\\{Task.CurrentId}", a);
            File.WriteAllText($"C:\\Users\\mka.STEP.000\\source\\repos\\ConsoleApp1\\ConsoleApp2\\dobutok{Task.CurrentId}", b);
        }
    }
}