using SLThree;
using SLThree.Embedding;
using System;

namespace ConsoleApp1
{
    public static class Program
    {
        public static void Main()
        {
            var e = default(ExecutionContext);
            PTest.Test(() => e = "using linq; return 1..1000000 |> linq.sum();".RunScript(), 5);
            Console.WriteLine(e.ReturnedValue);

            Console.ReadLine();
        }
    }
}