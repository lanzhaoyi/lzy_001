using MPS_A1.DAO;
using MPS_A1.Entitys;
using MPS_A1.FormFunc;
using MPS_A1.SerialPortProcessor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MPS_A1.TempUI
{
    public partial class MianF : Form
    {
        public MianF()
        {
            mProbeDAO = new ProbeDAO();
            IList<MPS_Probe> probeList = mProbeDAO.GetAllObjectList();
            if (probeList != null)
            {
                StringBuilder strB = new StringBuilder();
                foreach (MPS_Probe probe in probeList)
                {
                    strB.AppendLine(probe.ProbeName);
                }
                MsgFunc.ShowMsgInfo(strB.ToString());
            }

            InitializeComponent();
        }
        
        private void MianF_Load(object sender, EventArgs e)
        {
            FormMoveFunc objFormMoveFunc = new FormMoveFunc(this, tsMainHead);
            objFormMoveFunc.Show();
            // 设定串口回调
            SerialPortDataProcessorFunc.MoveFixedPositionDataReviceProcessor = this.MoveFixedPosition;
           
            initCombox();
            initTab1Chart();
            initTab2Chart();
            initTab3Chart();
        }

        private ProbeDAO mProbeDAO;

        private void tsbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void initCombox()
        {
            cbMaterial.SelectedIndex = 0;
            cbPlatform.SelectedIndex = 0;
            cbProbe.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;

        }

        private void initTab1Chart()
        {
            ChartArea objChartArea1 = chartContent.ChartAreas["ChartArea1"];
            chartContent.Legends[0].Enabled = false;//不显示图例
            objChartArea1.CursorX.AutoScroll = true;
            objChartArea1.AxisX.ScrollBar.Enabled = true;
            objChartArea1.CursorX.IsUserEnabled = true;
            objChartArea1.CursorX.IsUserSelectionEnabled = true;

            objChartArea1.AxisX.Interval = 20;
            objChartArea1.AxisX.ScaleView.Zoomable = true;
            objChartArea1.AxisX.ScaleView.Position = 0;
            objChartArea1.AxisX.ScaleView.Scroll(ScrollType.Last);
            objChartArea1.AxisX.ScaleView.Size = 20 * 10;
            objChartArea1.AxisX.Minimum = 0;

            objChartArea1.AxisY.Maximum = 300;
            objChartArea1.AxisY.Minimum = 0;

            Series objSeries = chartContent.Series[0];
            objSeries.Points.AddXY(0, 0);
            objSeries.Points.AddXY(10, 50);
            objSeries.Points.AddXY(20, 100);
            objSeries.Points.AddXY(30, 130);
            objSeries.Points.AddXY(40, 140);
            objSeries.Points.AddXY(50, 100);
            objSeries.Points.AddXY(60, 90);
            objSeries.Points.AddXY(70, 80);
            objSeries.Points.AddXY(80, 60);
            objSeries.Points.AddXY(90, 50);
            objSeries.Points.AddXY(100, 10);
            objSeries.Points.AddXY(110, 10);
            objSeries.Points.AddXY(120, 10);
            objSeries.Points.AddXY(130, 10);
            objSeries.Points.AddXY(140, 10);
            objSeries.Points.AddXY(150, 10);
            //int yValue = 0;
            //for (int i = 0; i < 10; i++)
            //{
            //    if (i < 5)
            //    {
            //        yValue = i;
            //    }
            //    else
            //    {
            //        yValue = i--;
            //    }
            //    if (yValue < 0)
            //        yValue = 0;
            //    objSeries.Points.AddXY(i, yValue);
            //}

        }

        private void initTab2Chart()
        {
            ChartArea objChartArea1 = chartContent2.ChartAreas["ChartArea1"];
            chartContent2.Legends[0].Enabled = false;//不显示图例
            objChartArea1.CursorX.AutoScroll = true;
            objChartArea1.AxisX.ScrollBar.Enabled = true;
            objChartArea1.CursorX.IsUserEnabled = true;
            objChartArea1.CursorX.IsUserSelectionEnabled = true;

            objChartArea1.AxisX.Interval = 20;
            objChartArea1.AxisX.ScaleView.Zoomable = true;
            objChartArea1.AxisX.ScaleView.Position = 0;
            objChartArea1.AxisX.ScaleView.Scroll(ScrollType.Last);
            objChartArea1.AxisX.ScaleView.Size = 20 * 10;
            objChartArea1.AxisX.Minimum = 0;

            objChartArea1.AxisY.Maximum = 300;
            objChartArea1.AxisY.Minimum = 0;

            Series objSeries = chartContent2.Series[0];
            objSeries.Points.AddXY(0, 0);
            objSeries.Points.AddXY(10, 50);
            objSeries.Points.AddXY(20, 100);
            objSeries.Points.AddXY(30, 130);
            objSeries.Points.AddXY(40, 140);
            objSeries.Points.AddXY(50, 100);
            objSeries.Points.AddXY(60, 90);
            objSeries.Points.AddXY(70, 80);
            objSeries.Points.AddXY(80, 60);
            objSeries.Points.AddXY(90, 50);
            objSeries.Points.AddXY(100, 10);
            objSeries.Points.AddXY(110, 10);
            objSeries.Points.AddXY(120, 10);
            objSeries.Points.AddXY(130, 10);
            objSeries.Points.AddXY(140, 10);
            objSeries.Points.AddXY(150, 10);
        }

        private void initTab3Chart()
        {
            ChartArea objChartArea1 = chartContent3.ChartAreas["ChartArea1"];
            chartContent2.Legends[0].Enabled = false;//不显示图例
            objChartArea1.CursorX.AutoScroll = true;
            objChartArea1.AxisX.ScrollBar.Enabled = true;
            objChartArea1.CursorX.IsUserEnabled = true;
            objChartArea1.CursorX.IsUserSelectionEnabled = true;

            objChartArea1.AxisX.Interval = 20;
            objChartArea1.AxisX.ScaleView.Zoomable = true;
            objChartArea1.AxisX.ScaleView.Position = 0;
            objChartArea1.AxisX.ScaleView.Scroll(ScrollType.Last);
            objChartArea1.AxisX.ScaleView.Size = 20 * 10;
            objChartArea1.AxisX.Minimum = 0;

            objChartArea1.AxisY.Maximum = 300;
            objChartArea1.AxisY.Minimum = 0;

            Series objSeries = chartContent3.Series[0];
            objSeries.Points.AddXY(0, 0);
            objSeries.Points.AddXY(10, 50);
            objSeries.Points.AddXY(20, 100);
            objSeries.Points.AddXY(30, 130);
            objSeries.Points.AddXY(40, 140);
            objSeries.Points.AddXY(50, 100);
            objSeries.Points.AddXY(60, 90);
            objSeries.Points.AddXY(70, 80);
            objSeries.Points.AddXY(80, 60);
            objSeries.Points.AddXY(90, 50);
            objSeries.Points.AddXY(100, 10);
            objSeries.Points.AddXY(110, 10);
            objSeries.Points.AddXY(120, 10);
            objSeries.Points.AddXY(130, 10);
            objSeries.Points.AddXY(140, 10);
            objSeries.Points.AddXY(150, 10);

            Series objSeries2 = chartContent3.Series[0];
            objSeries2.Points.AddXY(0, 0);
            objSeries2.Points.AddXY(10, 10);
            objSeries2.Points.AddXY(20, 10);
            objSeries2.Points.AddXY(30, 10);
            objSeries2.Points.AddXY(40, 50);
            objSeries2.Points.AddXY(50, 70);
            objSeries2.Points.AddXY(60, 130);
            objSeries2.Points.AddXY(70, 140);
            objSeries2.Points.AddXY(80, 110);
            objSeries2.Points.AddXY(90, 100);
            objSeries2.Points.AddXY(100, 90);
            objSeries2.Points.AddXY(110, 50);
            objSeries2.Points.AddXY(120, 20);
            objSeries2.Points.AddXY(130, 10);
            objSeries2.Points.AddXY(140, 10);
            objSeries2.Points.AddXY(150, 10);
        }

        private void tsmiMotorSet_Click(object sender, EventArgs e)
        {
            TempUI.MotorSetF objMotorSetF = new MotorSetF();
            objMotorSetF.StartPosition = FormStartPosition.CenterScreen;
            objMotorSetF.ShowDialog();
        }

        private void tsmiDb_Click(object sender, EventArgs e)
        {
            TempUI.DbF objDbF = new DbF();
            objDbF.StartPosition = FormStartPosition.CenterScreen;
            objDbF.ShowDialog();
        }

        #region 串口操作数据返回处理
        
        /// <summary>
        /// 移动固定距离
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="result"></param>
        private void MoveFixedPosition(string datas, bool result)
        {
            MsgFunc.ShowMsgInfo(datas);
        }
        #endregion
    }
}
