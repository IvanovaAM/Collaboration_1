using System;

namespace TestWork
{
    public static class DataGeneration
    {
        public static double GenerateTestData(int num)
        {
            return new Random().Next(0, 10) - num * num * num * 0.005;
        }

        public static double GenerateTestData(int num1, int num2)
        {
            return new Random().Next(-5, 1) + (num1 - num2) * (-num2) * 0.05;
        }

        public static double GenerateTestData(double num = 0.3)
        {
            return Math.Round(-1 * new Random().Next(-10, 10) + (num + 1) * new Random().NextDouble(), 1);
        }
    }
}
