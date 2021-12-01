using System;

namespace tp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.TrueConsole c = new Console.TrueConsole();

            new Ohce.OhceHandler().OhceLoop(c.ReadInput(), c, new DateIndicator.DateIndicator());

        }
    }
}
