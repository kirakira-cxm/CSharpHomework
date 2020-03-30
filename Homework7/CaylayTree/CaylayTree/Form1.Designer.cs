namespace CaylayTree
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textDepth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textLength = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBarRTh = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBarLTh = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxRPer = new System.Windows.Forms.TextBox();
            this.textBoxLPer = new System.Windows.Forms.TextBox();
            this.rperValue = new System.Windows.Forms.Label();
            this.lperValue = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonPenColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRTh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLTh)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "递归深度";
            // 
            // textDepth
            // 
            this.textDepth.Location = new System.Drawing.Point(16, 32);
            this.textDepth.Name = "textDepth";
            this.textDepth.Size = new System.Drawing.Size(100, 25);
            this.textDepth.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "主干长度 ";
            // 
            // textLength
            // 
            this.textLength.Location = new System.Drawing.Point(16, 102);
            this.textLength.Name = "textLength";
            this.textLength.Size = new System.Drawing.Size(100, 25);
            this.textLength.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "右分支角度";
            // 
            // trackBarRTh
            // 
            this.trackBarRTh.Location = new System.Drawing.Point(16, 168);
            this.trackBarRTh.Maximum = 180;
            this.trackBarRTh.Name = "trackBarRTh";
            this.trackBarRTh.Size = new System.Drawing.Size(104, 56);
            this.trackBarRTh.TabIndex = 6;
            this.trackBarRTh.Scroll += new System.EventHandler(this.trackBarRPer_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "左分支角度";
            // 
            // trackBarLTh
            // 
            this.trackBarLTh.Location = new System.Drawing.Point(16, 245);
            this.trackBarLTh.Maximum = 180;
            this.trackBarLTh.Name = "trackBarLTh";
            this.trackBarLTh.Size = new System.Drawing.Size(104, 56);
            this.trackBarLTh.TabIndex = 8;
            this.trackBarLTh.Scroll += new System.EventHandler(this.trackBarLPer_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "右分支长度比";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "左分支长度比";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(183, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 538);
            this.panel1.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(862, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxRPer
            // 
            this.textBoxRPer.Location = new System.Drawing.Point(16, 321);
            this.textBoxRPer.Name = "textBoxRPer";
            this.textBoxRPer.Size = new System.Drawing.Size(100, 25);
            this.textBoxRPer.TabIndex = 17;
            // 
            // textBoxLPer
            // 
            this.textBoxLPer.Location = new System.Drawing.Point(16, 403);
            this.textBoxLPer.Name = "textBoxLPer";
            this.textBoxLPer.Size = new System.Drawing.Size(100, 25);
            this.textBoxLPer.TabIndex = 18;
            // 
            // rperValue
            // 
            this.rperValue.AutoSize = true;
            this.rperValue.Location = new System.Drawing.Point(122, 168);
            this.rperValue.Name = "rperValue";
            this.rperValue.Size = new System.Drawing.Size(0, 15);
            this.rperValue.TabIndex = 19;
            // 
            // lperValue
            // 
            this.lperValue.AutoSize = true;
            this.lperValue.Location = new System.Drawing.Point(122, 245);
            this.lperValue.Name = "lperValue";
            this.lperValue.Size = new System.Drawing.Size(0, 15);
            this.lperValue.TabIndex = 20;
            // 
            // buttonPenColor
            // 
            this.buttonPenColor.Location = new System.Drawing.Point(16, 488);
            this.buttonPenColor.Name = "buttonPenColor";
            this.buttonPenColor.Size = new System.Drawing.Size(129, 35);
            this.buttonPenColor.TabIndex = 21;
            this.buttonPenColor.Text = "选择画笔颜色";
            this.buttonPenColor.UseVisualStyleBackColor = true;
            this.buttonPenColor.Click += new System.EventHandler(this.buttonPenColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 615);
            this.Controls.Add(this.buttonPenColor);
            this.Controls.Add(this.trackBarRTh);
            this.Controls.Add(this.lperValue);
            this.Controls.Add(this.rperValue);
            this.Controls.Add(this.textBoxLPer);
            this.Controls.Add(this.textBoxRPer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackBarLTh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textDepth);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRTh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLTh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDepth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBarRTh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBarLTh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxRPer;
        private System.Windows.Forms.TextBox textBoxLPer;
        private System.Windows.Forms.Label rperValue;
        private System.Windows.Forms.Label lperValue;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonPenColor;
    }
}

