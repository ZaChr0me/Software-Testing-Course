using System;

namespace tp3
{
    public class TaskManager
    {
        public (string,string) Parse(string command){
            return (command[0].ToString(),command.Remove(0,2));
        }
    }
}