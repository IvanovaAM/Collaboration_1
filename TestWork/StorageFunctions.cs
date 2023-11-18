using System;

namespace TestWork
{
    public static class StorageFunctions
    {
        public static double GetData(int i)
        {
            return new Random().Next(0, 10) - i*i*i*0.005 ;
        }

        public static double GetData(int i, int j)
        {
            return new Random().Next(-5,1) + (i-j) * (-j)*0.05;
        }

        public static double GetData()
        {
            return -1 * new Random().Next(-10, 10);
        }
    }
}
