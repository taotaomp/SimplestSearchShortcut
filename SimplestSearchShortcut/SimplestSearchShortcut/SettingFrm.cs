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
    public partial class SettingFrm : Form
    {
        public SettingFrm()
        {
            InitializeComponent();
        }
        public static String item = String.Empty;

        private void radioButtonBaidu_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.Equals(radioButtonBaidu))
            {
                item = @"https://www.baidu.com/s?wd=";
            }
            else if (sender.Equals(radioButtonSougou))
            {
                item = @"https://www.sogou.com/web?ie=UTF-8&query=";
            }
            else if (sender.Equals(radioButtonGoogle))
            {
                item = @"https://www.google.co.jp/search?source=hp&q=";
            }
            else if (sender.Equals(radioButtonBilbili))
            {
                item = @"https://search.bilibili.com/all?keyword=";
            }
            
        }

        private void radioButtonGoogle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Close();
            }
        }
    }
}
