using System;

namespace tp2.DateIndicator
{
    public interface IDateIndicator
    {
        public int GetCurrentTime();
    }

    public class FalseDateIndicator : IDateIndicator
    {
        private int falseHour;
        public FalseDateIndicator(int Hour)
        {
            falseHour = Hour;
        }
        public int GetCurrentTime()
        {
            return falseHour;
        }
    }
    public class DateIndicator : IDateIndicator
    {
        public int GetCurrentTime()
        {
            return new System.DateTime().Hour;
        }
    }
}