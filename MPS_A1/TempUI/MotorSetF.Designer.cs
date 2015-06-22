namespace MPS_A1.TempUI
{
    partial class MotorSetF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MotorSetF));
            this.tsTitle = new System.Windows.Forms.ToolStrip();
            this.tslTitle = new System.Windows.Forms.ToolStripLabel();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.btnTestCom = new System.Windows.Forms.Button();
            this.cbTestComName = new System.Windows.Forms.ComboBox();
            this.lblComName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPointInterval = new System.Windows.Forms.TextBox();
            this.lblPointInterval = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tsTitle.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsTitle
            // 
            this.tsTitle.AutoSize = false;
            this.tsTitle.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tsTitle.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsTitle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslTitle,
            this.tsbClose});
            this.tsTitle.Location = new System.Drawing.Point(0, 0);
            this.tsTitle.Name = "tsTitle";
            this.tsTitle.Size = new System.Drawing.Size(534, 42);
            this.tsTitle.TabIndex = 34;
            this.tsTitle.Text = "系统设置";
            // 
            // tslTitle
            // 
            this.tslTitle.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslTitle.ForeColor = System.Drawing.Color.White;
            this.tslTitle.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.tslTitle.Name = "tslTitle";
            this.tslTitle.Size = new System.Drawing.Size(63, 39);
            this.tslTitle.Text = "电机设置";
            // 
            // tsbClose
            // 
            this.tsbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(23, 39);
            this.tsbClose.Text = "关闭";
            // 
            // btnTestCom
            // 
            this.btnTestCom.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnTestCom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestCom.ForeColor = System.Drawing.Color.White;
            this.btnTestCom.Location = new System.Drawing.Point(228, 59);
            this.btnTestCom.Name = "btnTestCom";
            this.btnTestCom.Size = new System.Drawing.Size(81, 23);
            this.btnTestCom.TabIndex = 78;
            this.btnTestCom.Text = "测试";
            this.btnTestCom.UseVisualStyleBackColor = false;
            // 
            // cbTestComName
            // 
            this.cbTestComName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTestComName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTestComName.FormattingEnabled = true;
            this.cbTestComName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.cbTestComName.Location = new System.Drawing.Point(72, 60);
            this.cbTestComName.Name = "cbTestComName";
            this.cbTestComName.Size = new System.Drawing.Size(150, 20);
            this.cbTestComName.TabIndex = 77;
            // 
            // lblComName
            // 
            this.lblComName.AutoSize = true;
            this.lblComName.Location = new System.Drawing.Point(25, 64);
            this.lblComName.Name = "lblComName";
            this.lblComName.Size = new System.Drawing.Size(41, 12);
            this.lblComName.TabIndex = 76;
            this.lblComName.Text = "串口：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPointInterval);
            this.groupBox1.Controls.Add(this.lblPointInterval);
            this.groupBox1.Location = new System.Drawing.Point(21, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 106);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "电机";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 90;
            this.label1.Text = "mm";
            // 
            // txtPointInterval
            // 
            this.txtPointInterval.Location = new System.Drawing.Point(99, 28);
            this.txtPointInterval.MaxLength = 6;
            this.txtPointInterval.Name = "txtPointInterval";
            this.txtPointInterval.Size = new System.Drawing.Size(100, 21);
            this.txtPointInterval.TabIndex = 89;
            // 
            // lblPointInterval
            // 
            this.lblPointInterval.AutoSize = true;
            this.lblPointInterval.Location = new System.Drawing.Point(49, 31);
            this.lblPointInterval.Name = "lblPointInterval";
            this.lblPointInterval.Size = new System.Drawing.Size(41, 12);
            this.lblPointInterval.TabIndex = 88;
            this.lblPointInterval.Text = "一圈：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 93;
            this.label2.Text = "脉冲";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 56);
            this.textBox1.MaxLength = 6;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 92;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 91;
            this.label3.Text = "一圈：";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(188)))), ((int)(((byte)(89)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(418, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 42);
            this.btnCancel.TabIndex = 81;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(250)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(317, 229);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 42);
            this.btnOK.TabIndex = 80;
            this.btnOK.Text = "保存";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // MotorSetF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 289);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTestCom);
            this.Controls.Add(this.cbTestComName);
            this.Controls.Add(this.lblComName);
            this.Controls.Add(this.tsTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MotorSetF";
            this.Text = "MotorSetF";
            this.Load += new System.EventHandler(this.MotorSetF_Load);
            this.tsTitle.ResumeLayout(false);
            this.tsTitle.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsTitle;
        private System.Windows.Forms.ToolStripLabel tslTitle;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.Button btnTestCom;
        private System.Windows.Forms.ComboBox cbTestComName;
        private System.Windows.Forms.Label lblComName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPointInterval;
        private System.Windows.Forms.Label lblPointInterval;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}