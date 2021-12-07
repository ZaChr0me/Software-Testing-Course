using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using tp3;
using Xunit;
using Xunit.Abstractions;

namespace tp3
{
    public class TaskManager
    {
        public List<(bool,string)> Tasks { get; private set; }

        public TaskManager()
        {
            Tasks = new List<(bool,string)>();
        }

        public (char, string) Parse(string command)
        {
            return (command[0], command.Remove(0, 2));
        }
        public void AddTask(string command)
        {
            Tasks.Add((false,command));
        }
        public void DisplayAllTasks()
        {
            for (int i = 0; i < Tasks.Count; i++)
            {
                //if Item1 (the tasks status) is true, write X, else _
                Console.WriteLine((i+1)+" ["+((Tasks[i].Item1)?'X':' ')+"] "+Tasks[i].Item2);
            }
        }
    }
    public class TaskManagerTest
    {

        private readonly ITestOutputHelper testOutputHelper;
        public TaskManagerTest(ITestOutputHelper outputHelper)
        {
            testOutputHelper = outputHelper;
        }

        [Fact]
        public void Parse()
        {
            // Given
            string userInput = "+ a description";
            (char, string) correctResult = ('+', "a description");
            TaskManager manager = new TaskManager();

            // When
            (char, string) result = manager.Parse(userInput);
            // Then
            Assert.True(result == correctResult);
        }
        [Fact]
        public void AddTask()
        {
            // Given
            string task = "a task";
            TaskManager manager = new TaskManager();
            List<(bool,string)> correctTasks = new List<(bool,string)>() { (false,"a task") };
            // When
            manager.AddTask(task);
            // Then
            Assert.True(correctTasks.SequenceEqual(manager.Tasks));
        }

        [Fact]
        public void DisplayTasks()
        {
            // Given
            string task1 = "first task";
            string expectedOutput = "1 [ ] first task";

            //to capture console output
            var output = new StringWriter();
            Console.SetOut(output);
            TaskManager manager = new TaskManager();
            // When
            manager.AddTask(task1);
            manager.DisplayAllTasks();
            // Then
            Assert.Contains(expectedOutput, output.ToString());
        }
    }
}