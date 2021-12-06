using System;
using Xunit;

using tp2.Console;
using tp2.DateIndicator;
using tp2.Ohce;
namespace tp2.Ohce.Test
{
    public class OhceTest
    {

    }
    public class ConsoleTest
    {
        [Fact]
        public void ReadInputTest(){
            //arrange
            FalseConsole console=new FalseConsole();
            string anInput="test",testedInput="";
            console.SetReadInput(anInput);
            //act
            testedInput=console.ReadInput();
            //assert
            Assert.True(anInput==testedInput,"The input is correct");
        }
        [Fact]
        public void WriteOutputTest()
        {
        //Given
        
        //When
        
        //Then
        }
    }
    public class DateIndicatorTest
    {

    }
}