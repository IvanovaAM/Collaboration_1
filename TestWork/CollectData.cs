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
            var rnd = new Random();

            var x1 = rnd.Next(-5, 5);
            var x2 = rnd.Next(11, 21);
            var y = rnd.Next(0, 5);
            var seria = rnd.Next(2);

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
                for (int i = 0; i < rnd.Next(5, 10); i++)
                    DataForSeria3.Add(StorageFunctions.GetData() + ((i + 1) * (i + 2))); //генерация первоначального количества данных для серии3
            }
        }

        //заполнение листа данными с использованием функции GetData(int i)
        List<double> AddDataToList(int x1, int x2)
        {
            var tmpList = new List<double>();

            for (int i = x1; i < x2; i++)
                tmpList.Add(StorageFunctions.GetData(i));
            return tmpList;
        }

        //заполнение листа данными с использованием функции GetData(int i, int j)
        List<double> AddDataToList(int x1, int x2, int y)
        {
            var tmpList = new List<double>();

            for (int i = x1, j = y; i < x2; i++, j--)
                tmpList.Add(StorageFunctions.GetData(i, j));
            return tmpList;
        }
    }
}
