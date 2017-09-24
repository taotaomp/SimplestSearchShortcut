using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace SimplestSearchShortcut
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        String str = @"https://www.sogou.com/web?ie=UTF-8&query=";
        ArrayList buff = new ArrayList();   //缓存输入过的内容
        int index ;  //缓冲读取索引

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
                    //加入缓冲，刷新缓冲读取索引
                    buff.Add(textBox1.Text);
                    index = buff.Count;

                    textBox1.Text = textBox1.Text.Replace("#", "%23");      //将#替换为替代符，使浏览器能识别，下同
                    textBox1.Text = textBox1.Text.Replace(" ", "+");

                    System.Diagnostics.Process.Start("chrome.exe", str +textBox1.Text);
                    textBox1.Text = "";
                } 
            }
            if (e.KeyChar == 27)        //esc
            {
                this.Close();
            }
            try
            {

                if (e.KeyChar == 26)        //ctrl + z  向上回滚
                {
                    //只有在非底部才可以向上
                    index--;
                    if (index < 0) throw new rollBackUpException("超出下限");
                    textBox1.Text = buff[index].ToString();
                }
                if (e.KeyChar == 24)        //ctrl + x  向下
                {
                    //只有在非顶部才可以向下
                    index++;
                    if (index > buff.Count -1) throw new rollBackDownException("超出上限");
                    textBox1.Text = buff[index].ToString();

                }
                if (e.KeyChar == 1)     //ctrl + a
                {
                    textBox1.SelectAll();
                }
            }
            catch(rollBackUpException)
            {
                index = 0;
            }
            catch(rollBackDownException)
            {
                index = buff.Count;
                textBox1.Text = "";
            }
            
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            textBox1.Size = this.Size;
            textBox1.ImeMode = ImeMode.OnHalf;      //使文本框在输入时输入法始终是中文
        }

       
    }
}
