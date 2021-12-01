using System;
using Kata;
namespace kata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            KataHandler kataH=new KataHandler();
            kataH.Evaluate(new Expression("5 5 +"));
        }
    }
}
