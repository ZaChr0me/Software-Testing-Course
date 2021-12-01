using System;
using Xunit;
namespace Kata.Test
{
    public class ExpressionTest
    {
        [Fact]
        public void Sh()
        {
        //Given
        
        //When
        
        //Then
        }
    }
    public class KataHandlerTest{
        [Fact]
        public void AddingExpression()
        {
            KataHandler handler=new KataHandler();

            Assert.Equal(8,handler.Evaluate(new Expression("4 4 +")));

        //Given
        
        //When
        
        //Then
        }
        [Fact]
        public void SubstractingExpression(){

        }
        [Fact]
        public void MaxExpression()
        {
        //Given
        
        //When
        
        //Then
        }
        [Fact]
        public void SquareRootExpression()
        {
        //Given
        
        //When
        
        //Then
        }
    }

}