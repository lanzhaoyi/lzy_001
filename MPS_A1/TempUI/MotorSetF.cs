using MPS_A1.FormFunc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPS_A1.TempUI
{
    public partial class MotorSetF : Form
    {
        public MotorSetF()
        {
            InitializeComponent();
        }

        private void MotorSetF_Load(object sender, EventArgs e)
        {
            FormMoveFunc objFormMoveFunc = new FormMoveFunc(this, tsTitle);
            objFormMoveFunc.Show();

            cbTestComName.SelectedIndex = 0;
        }
    }
}
