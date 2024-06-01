using System;
using System.Diagnostics;
using SLThree;

namespace ConsoleApp1
{
    public class Program
    {
        public class TestClass
        {
            public int A;
            public string B { get; set; }
            public long C;
            public string D;

            public TestClass() { }

            public TestClass(int a, string b, long c, string d)
            {
                A = a;
                B = b;
                C = c;
                D = d;
            }

            public override string ToString() => $"{A}, {B}, {C}, {D}";
        }

        public class SmallClass
        {
            public int A;
            public string B;
            public int C;
            public string D;

            public SmallClass() { }
            public SmallClass(int a, string b, int c, string d)
            {
                A = a;
                B = b;
                C = c;
                D = d;
            }
        }
        public class MediumClass
        {
            public int A1;
            public string B1;
            public int C1;
            public string D1;
            public int A2;
            public string B2;
            public int C2;
            public string D2;
            public int A3;
            public string B3;
            public int C3;
            public string D3;
            public int A4;
            public string B4;
            public int C4;
            public string D4;
            public int A5;
            public string B5;
            public int C5;
            public string D5;
            public int A6;
            public string B6;
            public int C6;
            public string D6;
            public int A7;
            public string B7;
            public int C7;
            public string D7;
            public int A8;
            public string B8;
            public int C8;
            public string D8;

            public MediumClass() { }
            public MediumClass(int a1, string b1, int c1, string d1, int a2, string b2, int c2, string d2, int a3, string b3, int c3, string d3, int a4, string b4, int c4, string d4, int a5, string b5, int c5, string d5, int a6, string b6, int c6, string d6, int a7, string b7, int c7, string d7, int a8, string b8, int c8, string d8)
            {
                A1 = a1;
                B1 = b1;
                C1 = c1;
                D1 = d1;
                A2 = a2;
                B2 = b2;
                C2 = c2;
                D2 = d2;
                A3 = a3;
                B3 = b3;
                C3 = c3;
                D3 = d3;
                A4 = a4;
                B4 = b4;
                C4 = c4;
                D4 = d4;
                A5 = a5;
                B5 = b5;
                C5 = c5;
                D5 = d5;
                A6 = a6;
                B6 = b6;
                C6 = c6;
                D6 = d6;
                A7 = a7;
                B7 = b7;
                C7 = c7;
                D7 = d7;
                A8 = a8;
                B8 = b8;
                C8 = c8;
                D8 = d8;
            }
        }

        public static void WrapPerfomance()
        {
            Console.WriteLine("===> Wrap");
            var test_variable1 = new SmallClass(1, "345", 228, "3242334");
            {
                Console.WriteLine("Small size:");

                var sw1 = new Stopwatch();
                sw1.Start();
                Wrapper<SmallClass>.Wrap(test_variable1);
                sw1.Stop();

                var sw2 = new Stopwatch();
                sw2.Start();
                NewWrapper<SmallClass>.Wrap(test_variable1);
                sw2.Stop();

                var sw3 = new Stopwatch();
                sw3.Start();
                for (var i = 0; i < 100000; i++)
                    Wrapper<SmallClass>.Wrap(test_variable1);
                sw3.Stop();

                var sw4 = new Stopwatch();
                sw4.Start();
                for (var i = 0; i < 100000; i++)
                    NewWrapper<SmallClass>.Wrap(test_variable1);
                sw4.Stop();

                Console.WriteLine($"    Init old: {sw1.Elapsed.TotalMilliseconds}");
                Console.WriteLine($"    Init new: {sw2.Elapsed.TotalMilliseconds}");
                Console.WriteLine($"    100k old: {sw3.ElapsedMilliseconds}");
                Console.WriteLine($"    100k new: {sw4.ElapsedMilliseconds}");
                Console.WriteLine($"---------------------------------------------");
            }
            var test_variable2 = new MediumClass(1, "345", 228, "3242334", 1, "345", 228, "3242334", 1, "345", 228, "3242334", 1, "345", 228, "3242334", 1, "345", 228, "3242334", 1, "345", 228, "3242334", 1, "345", 228, "3242334", 1, "345", 228, "3242334");
            {
                Console.WriteLine("Big size:");

                var sw1 = new Stopwatch();
                sw1.Start();
                Wrapper<MediumClass>.Wrap(test_variable2);
                sw1.Stop();

                var sw2 = new Stopwatch();
                sw2.Start();
                NewWrapper<MediumClass>.Wrap(test_variable2);
                sw2.Stop();

                var sw3 = new Stopwatch();
                sw3.Start();
                for (var i = 0; i < 100000; i++)
                    Wrapper<MediumClass>.Wrap(test_variable2);
                sw3.Stop();

                var sw4 = new Stopwatch();
                sw4.Start();
                for (var i = 0; i < 100000; i++)
                    NewWrapper<MediumClass>.Wrap(test_variable2);
                sw4.Stop();

                Console.WriteLine($"    Init old: {sw1.Elapsed.TotalMilliseconds}");
                Console.WriteLine($"    Init new: {sw2.Elapsed.TotalMilliseconds}");
                Console.WriteLine($"    100k old: {sw3.ElapsedMilliseconds}");
                Console.WriteLine($"    100k new: {sw4.ElapsedMilliseconds}");
                Console.WriteLine($"---------------------------------------------");
            }
        }
        public static void UnwrapPerfomance()
        {
            Console.WriteLine("===> Unwrap");
            var test_variable1 = Wrapper<SmallClass>.Wrap(new SmallClass(1, "345", 228, "3242334"));
            {
                Console.WriteLine("Small size:");

                var sw3 = new Stopwatch();
                sw3.Start();
                for (var i = 0; i < 100000; i++)
                    Wrapper<SmallClass>.Unwrap(test_variable1);
                sw3.Stop();

                var sw4 = new Stopwatch();
                sw4.Start();
                for (var i = 0; i < 100000; i++)
                    NewWrapper<SmallClass>.Unwrap(test_variable1);
                sw4.Stop();

                Console.WriteLine($"    100k old: {sw3.ElapsedMilliseconds}");
                Console.WriteLine($"    100k new: {sw4.ElapsedMilliseconds}");
                Console.WriteLine($"---------------------------------------------");
            }
            var test_variable2 = Wrapper<MediumClass>.Wrap(new MediumClass(1, "345", 228, "3242334", 1, "345", 228, "3242334", 1, "345", 228, "3242334", 1, "345", 228, "3242334", 1, "345", 228, "3242334", 1, "345", 228, "3242334", 1, "345", 228, "3242334", 1, "345", 228, "3242334"));
            {
                Console.WriteLine("Big size:");

                var sw3 = new Stopwatch();
                sw3.Start();
                for (var i = 0; i < 100000; i++)
                    Wrapper<MediumClass>.Unwrap(test_variable2);
                sw3.Stop();

                var sw4 = new Stopwatch();
                sw4.Start();
                for (var i = 0; i < 100000; i++)
                    NewWrapper<MediumClass>.Unwrap(test_variable2);
                sw4.Stop();

                Console.WriteLine($"    100k old: {sw3.ElapsedMilliseconds}");
                Console.WriteLine($"    100k new: {sw4.ElapsedMilliseconds}");
                Console.WriteLine($"---------------------------------------------");
            }
        }

        public class TC
        {
            [WrapperContextName]
            [NewWrapper.Name]
            public string Name { get; set; } = "TC_Name";

            [NewWrapper.Context]
            public TestClass arr;
            public override string ToString() => $"{Name}\n {arr}";
        }

        public static void Main()
        {
            Wrapper<TC>.Wrap(new TC());
            NewWrapper<TC>.Wrap(new TC());
            WrapPerfomance();
            UnwrapPerfomance();
            //Console.WriteLine(NewWrapper<TC>.Unwrap("arr = new context; arr.A = 2i32; arr.B = \"25\";".RunScript()));
            //Console.WriteLine(e.Representation());
            Console.ReadLine();
        }
    }
}