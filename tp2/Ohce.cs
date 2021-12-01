using System;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using tp2.DateIndicator;

namespace tp2.Ohce
{
    class OhceHandler
    {
        public OhceHandler()
        {
        }
        public int OhceLoop(string userName, tp2.Console.IConsole Console, tp2.DateIndicator.IDateIndicator DateIndicator)
        {
            string input = "";
            Console.PrintOutput(GreetUser(DateIndicator.GetCurrentTime()) + userName + "!");
            input = Console.ReadInput();
            do
            {
                Console.PrintOutput(new String(input.Reverse().ToArray()));
                IsPalindrome(input, Console);
                input = Console.ReadInput();
            } while (input != "Stop !");
            Console.PrintOutput("Adios " + userName);
            return 0;
        }

        private string GreetUser(int time)
        {
            string returnValue = "";
            if (time > 20 || time < 6)
                returnValue = "¡Buenas noches ";
            else if (time >= 6 && time < 12)
                returnValue = "¡Buenas días ";
            else
                returnValue = "¡Buenas tardes ";
            return returnValue;
        }
        private void IsPalindrome(string text, tp2.Console.IConsole Console)
        {
            if (new String(text.ToLower().Reverse().ToArray()) == text.ToLower()) Console.PrintOutput("¡Bonita palabra!");
        }
    }
}