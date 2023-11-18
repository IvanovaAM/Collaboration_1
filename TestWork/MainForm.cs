using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestWork
{
    public partial class MainForm : Form
    {
        CollectData data = new CollectData();
        public MainForm()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.ContainerControl |
                          ControlStyles.OptimizedDoubleBuffer |
                          //ControlStyles.Opaque |
                          ControlStyles.SupportsTransparentBackColor
                          , true);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.DataBindY(data.DataForSeria1);
            chart1.Series[1].Points.DataBindY(data.DataForSeria2);
            chart1.Series[2].Points.DataBindY(data.DataForSeria3);

            //делает недействительной всю поверхность элемента управления Chart и вызывает перерисовку элемента управления Chart
            chart1.Invalidate();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //очистка серий от данных
            foreach (var series in chart1.Series)            
                series.Points.Clear();

            data.GenerateNewData();//генерация новых данных для отрисовки: серии 1 и 2 генерятся полностью с новыми зниачениями,
                                   //серия 3 удаляет первую точку и добавляет в конец новое значение
            chart1.Series[0].Points.DataBindY(data.DataForSeria1);
            chart1.Series[1].Points.DataBindY(data.DataForSeria2);
            chart1.Series[2].Points.DataBindY(data.DataForSeria3);
            //Перерисовка только серий
            chart1.Series.Invalidate();
        }
    }
}
