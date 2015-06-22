using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPS_A1.FormFunc
{
    public class FormMoveFunc
    {
        public FormMoveFunc(Form form, Control control)
        {
            if (form == null || control == null)
                return;
            mForm = form;
            mControl = control;
        }

        Form mForm;
        Control mControl;
        Point downPoint;

        public void Show()
        {
            if (mForm == null || mControl == null)
                return;
            mControl.MouseDown += control_MouseDown;
            mControl.MouseMove += control_MouseMove;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            downPoint = new Point(e.X, e.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mForm.Location = new Point(mForm.Location.X + e.X - downPoint.X,
                    mForm.Location.Y + e.Y - downPoint.Y);
            }
        }
    }
}
