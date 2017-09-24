namespace SimplestSearchShortcut
{
    partial class SettingFrm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonGoogle = new System.Windows.Forms.RadioButton();
            this.radioButtonSougou = new System.Windows.Forms.RadioButton();
            this.radioButtonBaidu = new System.Windows.Forms.RadioButton();
            this.radioButtonBilbili = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonBilbili);
            this.panel1.Controls.Add(this.radioButtonGoogle);
            this.panel1.Controls.Add(this.radioButtonSougou);
            this.panel1.Controls.Add(this.radioButtonBaidu);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 123);
            this.panel1.TabIndex = 0;
            // 
            // radioButtonGoogle
            // 
            this.radioButtonGoogle.AutoSize = true;
            this.radioButtonGoogle.Location = new System.Drawing.Point(48, 64);
            this.radioButtonGoogle.Name = "radioButtonGoogle";
            this.radioButtonGoogle.Size = new System.Drawing.Size(47, 16);
            this.radioButtonGoogle.TabIndex = 2;
            this.radioButtonGoogle.TabStop = true;
            this.radioButtonGoogle.Text = "谷歌";
            this.radioButtonGoogle.UseVisualStyleBackColor = true;
            this.radioButtonGoogle.CheckedChanged += new System.EventHandler(this.radioButtonBaidu_CheckedChanged);
            this.radioButtonGoogle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.radioButtonGoogle_KeyPress);
            // 
            // radioButtonSougou
            // 
            this.radioButtonSougou.AutoSize = true;
            this.radioButtonSougou.Location = new System.Drawing.Point(48, 42);
            this.radioButtonSougou.Name = "radioButtonSougou";
            this.radioButtonSougou.Size = new System.Drawing.Size(47, 16);
            this.radioButtonSougou.TabIndex = 0;
            this.radioButtonSougou.TabStop = true;
            this.radioButtonSougou.Text = "搜狗";
            this.radioButtonSougou.UseVisualStyleBackColor = true;
            this.radioButtonSougou.CheckedChanged += new System.EventHandler(this.radioButtonBaidu_CheckedChanged);
            this.radioButtonSougou.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.radioButtonGoogle_KeyPress);
            // 
            // radioButtonBaidu
            // 
            this.radioButtonBaidu.AutoSize = true;
            this.radioButtonBaidu.Location = new System.Drawing.Point(48, 20);
            this.radioButtonBaidu.Name = "radioButtonBaidu";
            this.radioButtonBaidu.Size = new System.Drawing.Size(47, 16);
            this.radioButtonBaidu.TabIndex = 1;
            this.radioButtonBaidu.TabStop = true;
            this.radioButtonBaidu.Text = "百度";
            this.radioButtonBaidu.UseVisualStyleBackColor = true;
            this.radioButtonBaidu.CheckedChanged += new System.EventHandler(this.radioButtonBaidu_CheckedChanged);
            this.radioButtonBaidu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.radioButtonGoogle_KeyPress);
            // 
            // radioButtonBilbili
            // 
            this.radioButtonBilbili.AutoSize = true;
            this.radioButtonBilbili.Location = new System.Drawing.Point(48, 86);
            this.radioButtonBilbili.Name = "radioButtonBilbili";
            this.radioButtonBilbili.Size = new System.Drawing.Size(71, 16);
            this.radioButtonBilbili.TabIndex = 3;
            this.radioButtonBilbili.TabStop = true;
            this.radioButtonBilbili.Text = "Bilibili";
            this.radioButtonBilbili.UseVisualStyleBackColor = true;
            this.radioButtonBilbili.CheckedChanged += new System.EventHandler(this.radioButtonBaidu_CheckedChanged);
            this.radioButtonBilbili.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.radioButtonGoogle_KeyPress);
            // 
            // SettingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(169, 147);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonGoogle;
        private System.Windows.Forms.RadioButton radioButtonSougou;
        private System.Windows.Forms.RadioButton radioButtonBaidu;
        private System.Windows.Forms.RadioButton radioButtonBilbili;
    }
}