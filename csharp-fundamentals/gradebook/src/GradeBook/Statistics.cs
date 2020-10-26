using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double High;
        public double Low;

        public double Sum;
        public int Count;
        public char Letter
        {
            get
            {
                switch(Average)
                {   
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }
    public void Add(double number)
    {
        Sum += number;
        Count += 1;
        Low = Math.Min(number, Low);
        High = Math.Max(number, High);
    }
    public void ShowStatistics() {
        System.Console.WriteLine($"The average value: {Average}");
        System.Console.WriteLine($"The high value: {High}");
        System.Console.WriteLine($"The low value: {Low}");
        System.Console.WriteLine($"The letter value: {Letter}");
    }
    public Statistics()
    {   
        Count = 0;
        High = double.MinValue;
        Low = double.MaxValue;
    }
  }
}