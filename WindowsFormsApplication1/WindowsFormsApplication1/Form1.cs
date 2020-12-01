using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private int m_nTimeCount = 0;
        Random clsRanom = new Random();        

        public Form1()
        {
            InitializeComponent();

            // 設定ChartArea
            ChartArea chtArea = new ChartArea("ViewArea");
            chtArea.AxisX.Minimum = 0; //X軸數值從0開始
            chtArea.AxisX.ScaleView.Size = 10; //設定視窗範圍內一開始顯示多少點
            chtArea.AxisX.Interval = 5;
            chtArea.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chtArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All; //設定scrollbar
            chart1.ChartAreas[0] = chtArea; // chart new 出來時就有內建第一個chartarea

            Timer clsTimer = new Timer();
            clsTimer.Tick += new EventHandler(RefreshChart);
            clsTimer.Interval = 300;
            clsTimer.Start();
        }     
        
        private void RefreshChart(object sender, EventArgs e)
        {
            chart1.Series[0].Points.AddXY(m_nTimeCount, clsRanom.Next(0, 100));
            if(m_nTimeCount > 10)
            {
                chart1.ChartAreas[0].AxisX.ScaleView.Position = m_nTimeCount-10;
            }
            m_nTimeCount++;
        }
    }
}
