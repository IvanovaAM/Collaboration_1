using System;
using System.Collections.Generic;

namespace TestWork
{
    internal class CollectData
    {
        public List<double> DataForSeria1 { get; set; } = new List<double>();
        public List<double> DataForSeria2 { get; set; } = new List<double>();
        public List<double> DataForSeria3 { get; set; } = new List<double>();

        public CollectData()
        {
            GenerateNewData(0);
        }

        //генерация новых данных для отображения
        public void GenerateNewData(int first = 1)
        {
            var random = new Random();

            var x1 = random.Next(-5, 5);
            var x2 = random.Next(11, 21);
            var y = random.Next(0, 5);
            var seria = random.Next(2);

            //для рандомного отображения серий 1 и 2 
            DataForSeria1 = (seria == 0) ? AddDataToList(x1, x2) : AddDataToList(x1, x2, y);
            DataForSeria2 = (seria == 1) ? AddDataToList(x1, x2) : AddDataToList(x1, x2, y);

            if (first == 1)
            {
                DataForSeria3.RemoveAt(0);//удаление из листа первого значения
                DataForSeria3.Add(StorageFunctions.GetData());//дабавление в конец листа одного нового значения
            }
            else //генерация данных для серии3 при инициализации класса
            {
                for (int i = 0; i < random.Next(5, 10); i++)
                    DataForSeria3.Add(StorageFunctions.GetData() + ((i + 1) * (i + 2))); //генерация первоначального количества данных для серии3
            }
        }

        //заполнение листа данными с использованием функции GetData(int i)
        List<double> AddDataToList(int x1, int x2)
        {
            var temproryDataList = new List<double>();

            for (int i = x1; i < x2; i++)
                temproryDataList.Add(StorageFunctions.GetData(i));
            return temproryDataList;
        }

        //заполнение листа данными с использованием функции GetData(int i, int j)
        List<double> AddDataToList(int x1, int x2, int y)
        {
            var temproryDataList = new List<double>();

            for (int i = x1, j = y; i < x2; i++, j--)
                temproryDataList.Add(StorageFunctions.GetData(i, j));
            return temproryDataList;
        }
    }
}
