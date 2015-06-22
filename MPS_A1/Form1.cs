using MPS_A1.CommonUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MPS_A1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        int mDeviceNumber = 0;
        int mDeviceID = 0;
        Series objSeries = null;

        Queue objQueue = new Queue();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            lbData.Items.Clear();
            txtDeviceNumber.Text = mDeviceNumber.ToString();
            mDeviceID = MPS_API.MPS_OpenDevice(mDeviceNumber);
            txtDeviceID.Text = mDeviceID.ToString();
            MPS_API.MPS_Configure(4, mDeviceID);
            //char[] str =new char[1024];

            //IntPtr ptrIn = Marshal.StringToHGlobalAnsi(" ");
            //int result = MPS_API.MPS_GetInformation(ptrIn, openStatus);
            //string retlust = Marshal.PtrToStringAnsi(ptrIn);
            int result = MPS_API.MPS_Start(mDeviceID);

            //IntPtr ptrDataBuf= Marshal.StringToHGlobalAnsi("");


         
            Task objTask = new Task(() =>
            {
                while (true)
                {
                    int[] ptrDataBuf = new int[128];
                    GCHandle handle = GCHandle.Alloc(ptrDataBuf, GCHandleType.Pinned);
                    IntPtr ptr = handle.AddrOfPinnedObject();
                    MPS_API.MPS_DataIn(ptr, 128, mDeviceID);
                    Marshal.Copy(ptr, ptrDataBuf, 0, 128);
                    foreach (int d in ptrDataBuf)
                    {
                        double dValue = ((double)d * 10 / 2147483648) * 10.0352;
                        objQueue.Enqueue(dValue);
                        //lbData.Items.Add(string.Format("{0}  {1}", index.ToString().PadLeft(4, '0'), dValue));

                        //Thread.Sleep(100);
                    }
                    handle.Free();
                }
            });
            objTask.Start();
           
            timer1.Start();
            //string retlust = Marshal.PtrToStringAnsi(ptrDataBuf);


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            MPS_API.MPS_Stop(mDeviceID);
            MPS_API.MPS_CloseDevice(mDeviceID);
            Application.Exit();
        }
        ChartArea objChartArea1 = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            objChartArea1 = chartContent.ChartAreas["ChartArea1"];
            chartContent.Legends[0].Enabled = false;//不显示图例
            objChartArea1.CursorX.AutoScroll = true;
            objChartArea1.AxisX.ScrollBar.Enabled = true;
            objChartArea1.CursorX.IsUserEnabled = true;
            objChartArea1.CursorX.IsUserSelectionEnabled = true;

            //GlobalInfo.g_AdjustLight = 1;

            objChartArea1.AxisX.Interval = 20;// mPositionInterval / 2;
            objChartArea1.AxisX.ScaleView.Zoomable = true;
            objChartArea1.AxisX.ScaleView.Position = 0;
            objChartArea1.AxisX.ScaleView.Scroll(ScrollType.Last);
            objChartArea1.AxisX.ScaleView.Size = 20 * 10;// mPositionInterval / 2 * 10;// GlobalInfo.g_MaxAdjustLightPointCount / GlobalInfo.g_ReactionGlassCount / GlobalInfo.g_AdjustLightStep / 2 * 6;
            objChartArea1.AxisX.Minimum = 0;

            objChartArea1.AxisY.Maximum = 100;
            objChartArea1.AxisY.Minimum = -10;

            objSeries = chartContent.Series[0];
        }

        int index = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (objQueue.Count <= 0)
                return;
            object dValue = objQueue.Dequeue();
            if (dValue != null)
            {
                objSeries.Points.AddXY(index, (double)dValue);

                objChartArea1.AxisX.ScaleView.Scroll(ScrollType.Last);
            }
            index++;
        }
    }

}
