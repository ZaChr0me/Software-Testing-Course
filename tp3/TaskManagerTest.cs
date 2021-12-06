using System.Threading.Tasks;
using System;
using Xunit;

using tp3;
namespace tp3.Test
{
    public class TaskManagerTest
    {
        [Fact]
        public void AddParse()
        {
            // Given
            string userInput="+ a description";
            (string, string) correctResult=("+", "a description");
            TaskManager manager=new TaskManager();

            // When
            (string, string)result=manager.Parse(userInput);
            // Then
            Xunit.Assert.True(result==correctResult);
        }
    }

}