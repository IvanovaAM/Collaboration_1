using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestWork
{
    public partial class MainForm : Form
    {
        Random rnd = new Random();
        List<int> dataForSeria3 = new List<int>();

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
            for (int i = 0; i < 10; i++)
                chart1.Series[0].Points.AddXY(i, StrageFunctions.GetData(i));           

            for (int i = 0, j = 10; i < 10; i++, j--)            
                chart1.Series[1].Points.AddXY(i, StrageFunctions.GetData(i, j));

            for (int i = 0; i < 15; i++)
            {
                dataForSeria3.Add(i+rnd.Next(15));
            }
            chart1.Series[2].Points.DataBindY(dataForSeria3);

            chart1.Invalidate();

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            int x1 = rnd.Next(-20, 20);
            int x2 = rnd.Next(-30, 30);
            x2 = (x2 > x1) ? x2 : (x2 == x1) ? (int)Math.Abs(x2 * 1.5) : -x2;
            int y = rnd.Next(-30,30); 
            int seria = rnd.Next(2);  
            SetPoints(x1, x2, seria);

            x1 = rnd.Next(-10, 10);
            x2 = rnd.Next(-25, 25);
            x2 = (x2 > x1) ? x2 : (x2 == x1) ? (int)Math.Abs(x2 * 1.5) : -x2;
            y = rnd.Next(-5, 5);
            seria = rnd.Next(2);
            SetPoints(x1, x2, y, seria);

            dataForSeria3.RemoveAt(0);
            int N = rnd.Next(50);
            dataForSeria3.Insert(dataForSeria3.Count, rnd.Next(-30, 30));
            //Binding data
            chart1.Series[2].Points.DataBindY(dataForSeria3);
            //Redraw
            chart1.Series.Invalidate();

            //chart1.Invalidate();
        }

        void SetPoints(int x1, int x2, int seria)
        {
            for (int i = x1; i < x2; i++)
                chart1.Series[seria].Points.AddXY(i, StrageFunctions.GetData(i));
        }

        void SetPoints(int x1, int x2, int y, int seria)
        {
            for (int i = x1, j = y; i < x2; i++, j--)
                chart1.Series[seria].Points.AddXY(i, StrageFunctions.GetData(i, j));
        }
    }
}
