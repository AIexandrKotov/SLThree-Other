using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    public static class PTest
    {
        private static readonly Func<Stopwatch, object> defaultswt = sw => sw.ElapsedMilliseconds;
        private static int i = 1;
        private static string testname => $"Test #{i++}: {{0}} ms";
        public static void Test(Action action, string name = null, Func<Stopwatch, object> swt = null, Action pre = null, Action post = null)
        {
            name = name ?? testname;
            swt = swt ?? defaultswt;
            var sw = new Stopwatch();
            pre?.Invoke();
            sw.Start();
            action();
            sw.Stop();
            post?.Invoke();
            Console.WriteLine(string.Format(name, swt(sw)));
        }
        public static void Test(Action action, int count = 1, string name = null, Func<Stopwatch, object> swt = null, Action pre = null, Action post = null)
        {
            name = name ?? testname;
            swt = swt ?? defaultswt;
            var sw = new Stopwatch();
            pre?.Invoke();
            sw.Start();
            for (var i = 0; i < count; i++)
                action();
            sw.Stop();
            post?.Invoke();
            Console.WriteLine(string.Format(name, swt(sw)));
        }
    }
}
