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
        public Dictionary<int, (bool, string)> Tasks { get; private set; }
        private int currentIndex = 0;
        public TaskManager()
        {
            Tasks = new Dictionary<int, (bool, string)>();
        }

        public (char, string) Parse(string command)
        {
            return (command[0], command.Remove(0, 2));
        }
        public void AddTask(string command)
        {
            currentIndex++;
            Tasks.Add(currentIndex, (false, command));
        }
        public void DisplayAllTasks()
        {
            foreach (int key in Tasks.Keys)
            {
                //if Item1 (the tasks status) is true, write X, else _
                Console.WriteLine(key + " [" + ((Tasks[key].Item1) ? 'X' : ' ') + "] " + Tasks[key].Item2);
            }
        }
        public void WorkOnCommand(string command)
        {
            (char, string) splittedCommand = Parse(command);
            switch (splittedCommand.Item1)
            {
                case '+':
                    AddTask(splittedCommand.Item2);
                    break;
                case '-':
                    RemoveTask(splittedCommand.Item2);
                    break;
                case 'x':
                    ChangeTaskStatus(splittedCommand.Item2, true);
                    break;
                case 'o':
                    ChangeTaskStatus(splittedCommand.Item2, false);
                    break;
                default:
                    break;
            }
            DisplayAllTasks();
        }
        public void RemoveTask(string id)
        {
            int i;
            if (int.TryParse(id, out i)) this.Tasks.Remove(i);

        }
        public void ChangeTaskStatus(string id, bool status)
        {
            int i;
            if (int.TryParse(id, out i)) this.Tasks[i] = (status, this.Tasks[i].Item2);
        }
        public bool Equals(Dictionary<int, (bool, string)> d1, Dictionary<int, (bool, string)> d2)
        {
            if (d2 == null && d1 == null)
                return true;
            else if (d1 == null || d2 == null)
                return false;
            else if (d1.Keys.SequenceEqual(d2.Keys) && d1.Values.SequenceEqual(d2.Values))
                return true;
            else
                return false;
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
        public void ParseTest()
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
        public void AddTaskTest()
        {
            // Given
            string task = "a task";
            TaskManager manager = new TaskManager();
            Dictionary<int, (bool, string)> correctTasks = new Dictionary<int, (bool, string)>() { { 1, (false, "a task") } };
            // When
            manager.AddTask(task);
            // Then
            Assert.True(correctTasks.SequenceEqual(manager.Tasks));
        }

        [Fact]
        public void DisplayTasksTest()
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

        [Fact]
        public void InteractionLoop()
        {
            // Given
            List<string> multipleTasks = new List<string>(){
                "+ cook bread",
                "+ overcook bread",
                "+ burn bread",
                "+ cry over burnt bread",
                "x 1",
                "x 2",
                "x 3",
                "- 1",
                "- 2",
                "x 4",
                "o 3",
                "o 4",
                "q"
            };
            List<Dictionary<int, (bool, string)>> properTasksAtX = new List<Dictionary<int, (bool, string)>>(){
                new Dictionary<int, (bool, string)>(){
                    {1,(false,"cook bread")}
                },
                new Dictionary<int, (bool, string)>(){
                    {1,(false,"cook bread")},
                    {2,(false,"overcook bread")}
                },
                new Dictionary<int, (bool, string)>(){
                    {1,(false,"cook bread")},
                    {2,(false,"overcook bread")},
                    {3,(false,"burn bread")}
                },
                new Dictionary<int, (bool, string)>(){
                    {1,(false,"cook bread")},
                    {2,(false,"overcook bread")},
                    {3,(false,"burn bread")},
                    {4,(false,"cry over burnt bread")}
                },
                new Dictionary<int, (bool, string)>(){
                    {1,(true,"cook bread")},
                    {2,(false,"overcook bread")},
                    {3,(false,"burn bread")},
                    {4,(false,"cry over burnt bread")}
                },
                new Dictionary<int, (bool, string)>(){
                    {1,(true,"cook bread")},
                    {2,(true,"overcook bread")},
                    {3,(false,"burn bread")},
                    {4,(false,"cry over burnt bread")}
                },
                new Dictionary<int, (bool, string)>(){
                    {1,(true,"cook bread")},
                    {2,(true,"overcook bread")},
                    {3,(true,"burn bread")},
                    {4,(false,"cry over burnt bread")}
                },
                new Dictionary<int, (bool, string)>(){
                    {2,(true,"overcook bread")},
                    {3,(true,"burn bread")},
                    {4,(false,"cry over burnt bread")}
                },
                new Dictionary<int, (bool, string)>(){
                    {3,(true,"burn bread")},
                    {4,(false,"cry over burnt bread")}
                },
                new Dictionary<int, (bool, string)>(){
                    {3,(true,"burn bread")},
                    {4,(true,"cry over burnt bread")}
                },
                new Dictionary<int, (bool, string)>(){
                    {3,(false,"burn bread")},
                    {4,(true,"cry over burnt bread")}
                },
                new Dictionary<int, (bool, string)>(){
                    {3,(false,"burn bread")},
                    {4,(false,"cry over burnt bread")}
                },
            };
            TaskManager manager = new TaskManager();
            // When
            for (int i = 0; i < multipleTasks.Count; i++)
            {
                //multipleTasks simulates user entering tasks successively
                if (multipleTasks[i] != "q")
                {
                    manager.WorkOnCommand(multipleTasks[i]);
                    Assert.True(manager.Equals(properTasksAtX[i], manager.Tasks));
                }
            }
            // Then
        }
    }
}