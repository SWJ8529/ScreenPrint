namespace MyScreenPrint
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
            this.components = new System.ComponentModel.Container();
            this.operationPanel = new System.Windows.Forms.Panel();
            this.Clean_Point = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.printScrBtn = new System.Windows.Forms.Button();
            this.splitter_1 = new System.Windows.Forms.Label();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.operationPanel.SuspendLayout();
            this.picturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // operationPanel
            // 
            this.operationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.operationPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.operationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.operationPanel.Controls.Add(this.Clean_Point);
            this.operationPanel.Controls.Add(this.label1);
            this.operationPanel.Controls.Add(this.button2);
            this.operationPanel.Controls.Add(this.printScrBtn);
            this.operationPanel.Controls.Add(this.splitter_1);
            this.operationPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.operationPanel.Location = new System.Drawing.Point(1087, 12);
            this.operationPanel.Name = "operationPanel";
            this.operationPanel.Size = new System.Drawing.Size(109, 635);
            this.operationPanel.TabIndex = 1;
            // 
            // Clean_Point
            // 
            this.Clean_Point.Location = new System.Drawing.Point(2, 57);
            this.Clean_Point.Name = "Clean_Point";
            this.Clean_Point.Size = new System.Drawing.Size(102, 48);
            this.Clean_Point.TabIndex = 6;
            this.Clean_Point.Text = "清空坐标";
            this.Clean_Point.UseVisualStyleBackColor = true;
            this.Clean_Point.Click += new System.EventHandler(this.Clean_Point_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 48);
            this.button2.TabIndex = 4;
            this.button2.Text = "识别坐标";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // printScrBtn
            // 
            this.printScrBtn.Location = new System.Drawing.Point(2, 3);
            this.printScrBtn.Name = "printScrBtn";
            this.printScrBtn.Size = new System.Drawing.Size(102, 48);
            this.printScrBtn.TabIndex = 3;
            this.printScrBtn.Text = "设置坐标";
            this.printScrBtn.UseVisualStyleBackColor = true;
            this.printScrBtn.Click += new System.EventHandler(this.printScrBtn_Click);
            // 
            // splitter_1
            // 
            this.splitter_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter_1.Location = new System.Drawing.Point(4, 112);
            this.splitter_1.Name = "splitter_1";
            this.splitter_1.Size = new System.Drawing.Size(100, 1);
            this.splitter_1.TabIndex = 2;
            // 
            // picturePanel
            // 
            this.picturePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturePanel.AutoScroll = true;
            this.picturePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picturePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picturePanel.Controls.Add(this.label3);
            this.picturePanel.Controls.Add(this.textBox2);
            this.picturePanel.Controls.Add(this.label2);
            this.picturePanel.Controls.Add(this.textBox1);
            this.picturePanel.Location = new System.Drawing.Point(13, 12);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(1068, 635);
            this.picturePanel.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "识别日志:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(5, 364);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1045, 266);
            this.textBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "坐标日志:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 32);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1045, 266);
            this.textBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 659);
            this.Controls.Add(this.picturePanel);
            this.Controls.Add(this.operationPanel);
            this.Name = "Form1";
            this.Text = "图片数字识别工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.operationPanel.ResumeLayout(false);
            this.operationPanel.PerformLayout();
            this.picturePanel.ResumeLayout(false);
            this.picturePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel operationPanel;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.Label splitter_1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button printScrBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Clean_Point;
    }
}

