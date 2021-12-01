using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
namespace Kata
{
    public class KataHandler
    {
        public List<int> stack{get;private set;}
        public KataHandler(){
            stack=new List<int>();
        }
        public int Evaluate(Expression expression){
            int intType=0;
            foreach (var item in expression.expressions)
            {  
                if(item.GetType()==intType.GetType()) stack.Add(Convert.ToInt32(item));
                else
                {
                    switch (Convert.ToString(item))
                    {
                        case "+":
                            int[] addValues=new int[2]{stack[0],stack[1]};
                            stack.RemoveRange(0,2);
                            stack.Add(addValues[0]+addValues[1]);
                        break;
                        case "-":
                            int[] subValues=new int[2]{stack[1],stack[1]};
                            stack.RemoveRange(0,2);
                            stack.Add(subValues[0]-subValues[1]);
                        break;
                        case "max":
                            int max=0;
                            foreach (int number in stack)
                            {
                                max=(max<number)?number:max;
                            }
                            stack.Clear();
                            stack.Add(max);
                        break;
                        case "sqrt":
                            int value=stack.First();
                            stack.Remove(0);
                            stack.Add(Convert.ToInt32( System.Math.Sqrt(value)));
                        break;
                        default:
                        break;
                    }
                }
                string text = string.Join(",", stack);
                Console.WriteLine(text);
            }
            return this.stack[0];
        }
    }
    public class Expression
    {
        public List<Object> expressions;
        public Expression(string exp){
            expressions=new List<object>();
            try
            {
                string[] expArray=exp.Split(' ');
                foreach (string item in expArray)
                {
                    int temp;
                    expressions.Add(((int.TryParse(item,out temp))?temp:item));
                }
            }
            catch (System.Exception)
            {
                Console.Write("incorrect expression");
            }
        }
    }
}