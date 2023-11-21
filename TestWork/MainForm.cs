using System;
using System.Windows.Forms;

namespace TestWork
{
    public partial class MainForm : Form
    {
        readonly DataCollection testData = new DataCollection();
        public MainForm()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.ContainerControl |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.Opaque |
                          ControlStyles.SupportsTransparentBackColor
                          , true);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FillSeriesData();
        }

        private void RedrawChartControl_Tick(object sender, EventArgs e)
        {
            CleanSeriesData();
            testData.GenerateNewData();
            FillSeriesData();
        }

        void FillSeriesData()
        {
            for (int i = 0; i < 3; i++)
            {
                chartControl.Series[i].Points.DataBindY(testData.ListWithData[i]);
            }
            chartControl.Series.Invalidate();
        }

        void CleanSeriesData()
        {
            foreach (var series in chartControl.Series)
                series.Points.Clear();
        }
    }
}
