using System;

namespace tp2.Console
{
    public interface IConsole
    {
        public string ReadInput();
        public void PrintOutput(string Output);
    }

    public class FalseConsole : IConsole
    {
        private string inp;
        public FalseConsole() { }
        public void SetReadInput(string Input)
        {
            inp = Input;
        }
        public string ReadInput()
        {
            return inp;
        }
        public void PrintOutput(string Output)
        {
            System.Console.WriteLine("> " + Output);
        }
    }
    public class TrueConsole : IConsole
    {
        public string ReadInput()
        {
            System.Console.Write("$ ");
            return System.Console.ReadLine();
        }
        public void PrintOutput(string Output)
        {
            System.Console.WriteLine(">" + Output);
        }
    }
}