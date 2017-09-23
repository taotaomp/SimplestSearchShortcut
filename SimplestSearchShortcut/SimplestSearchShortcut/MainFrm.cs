using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplestSearchShortcut
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        String str = @"https://www.sogou.com/web?ie=UTF-8&query=";

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                
                if (textBox1.Text == "exit")
                {
                    this.Close();
                }
                else if(textBox1.Text == "setting")
                {
                    SettingFrm s = new SettingFrm();
                    s.ShowDialog();
                    str = SettingFrm.item;
                    textBox1.Text = String.Empty;
                }
                else
                {
                    textBox1.Text = textBox1.Text.Replace("#", "%23");
                    System.Diagnostics.Process.Start("chrome.exe", str +textBox1.Text);
                    textBox1.Text = String.Empty;
                }
                
                
            }
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            textBox1.Size = this.Size;
            textBox1.ImeMode = ImeMode.OnHalf;      //使文本框在输入时输入法始终是中文
        }
    }
}
