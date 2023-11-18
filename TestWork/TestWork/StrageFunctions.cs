namespace TestWork
{
    public static class StrageFunctions
    {
        public static double GetData(int i)
        {
            return 4.3 + 6.7 * i + 1.9 * i * i/300 - 1.7 * i * i * i/10000;
        }

        public static double GetData(int i, int j)
        {
            return -19.5+(i*j*2.54);
        }
    }
}
