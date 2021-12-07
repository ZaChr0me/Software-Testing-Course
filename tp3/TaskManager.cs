using System.ComponentModel.DataAnnotations;
using System;
using Xunit;

using tp3;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace tp3
{
    public class TaskManager
    {
        
        
        public List<string> Tasks{get;private set;}
        
        public TaskManager(){
            Tasks=new List<string>();
        }

        public (char,string) Parse(string command){
            return (command[0],command.Remove(0,2));
        }
        public void AddTask(string command){
            Tasks.Add(command);
        }
    }
    public class TaskManagerTest
    {
        [Fact]
        public void Parse()
        {
            // Given
            string userInput="+ a description";
            (char, string) correctResult=('+', "a description");
            TaskManager manager=new TaskManager();

            // When
            (char, string)result=manager.Parse(userInput);
            // Then
            Assert.True(result==correctResult);
        }
        [Fact]
        public void AddTask()
        {
            // Given
            string task="a task";
            TaskManager manager=new TaskManager();
            List<string> correctTasks=new List<string>(){"a task"};
            // When
            manager.AddTask(task);
            // Then
            Assert.True(correctTasks.SequenceEqual(manager.Tasks));
        }
    }
}