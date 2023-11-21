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
            FillSeriesOfPoints();
        }

        private void RedrawChartControl_Tick(object sender, EventArgs e)
        {
            CleanSeriesOfPoints();
            testData.GenerateNewData();
            FillSeriesOfPoints();
        }

        void FillSeriesOfPoints()
        {
            var i = 0;
            foreach (var seriesOfPoints in chartControl.Series)
            {
                seriesOfPoints.Points.DataBindY(testData.ListWithData[i]);
                i++;
            }
            chartControl.Series.Invalidate();
        }

        void CleanSeriesOfPoints()
        {
            foreach (var seriesOfPoints in chartControl.Series)
            {
                seriesOfPoints.Points.Clear();
            }
        }
    }
}
