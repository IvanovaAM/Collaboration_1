using System;
using System.Collections.Generic;

namespace TestWork
{
    internal class DataCollection
    {
        readonly List<double>[] listWithData = new List<double>[3];
        public List<double>[] ListWithData => listWithData;

        public DataCollection()
        {
            GenerateNewData(true);
        }

        public void GenerateNewData(bool firstLaunch = false)
        {
            var random = new Random();
            var rangeOfValues = new List<int>() { random.Next(-5, 5), random.Next(11, 21), random.Next(0, 5) };

            var seria = random.Next(2);//для рандомного вида серий 0 и 1

            listWithData[0] = (seria == 0) ?
                FillListWithData(rangeOfValues[0], rangeOfValues[1]) :
                FillListWithData(rangeOfValues[0], rangeOfValues[1], rangeOfValues[2]);
            listWithData[1] = (seria == 1) ?
                FillListWithData(rangeOfValues[0], rangeOfValues[1]) :
                FillListWithData(rangeOfValues[0], rangeOfValues[1], rangeOfValues[2]);
            FillListWithData(firstLaunch);
        }

        List<double> FillListWithData(int num1, int num2)
        {
            var listWithData = new List<double>();

            for (int i = num1; i < num2; i++)
            {
                listWithData.Add(DataGeneration.GenerateTestData(i));
            }
            return listWithData;
        }

        List<double> FillListWithData(int num1, int num2, int num3)
        {
            var listWithData = new List<double>();

            for (int i = num1, j = num3; i < num2; i++, j--)
            {
                listWithData.Add(DataGeneration.GenerateTestData(i, j));
            }
            return listWithData;
        }

        private void FillListWithData(bool firstLaunch)
        {
            if (firstLaunch)
            {
                listWithData[2] = new List<double>();

                for (int i = 0; i < new Random().Next(5, 10); i++)
                {
                    listWithData[2].Add(DataGeneration.GenerateTestData((double)i));
                }
                return;
            }

            listWithData[2].RemoveAt(0);
            listWithData[2].Add(DataGeneration.GenerateTestData());
        }
    }
}
