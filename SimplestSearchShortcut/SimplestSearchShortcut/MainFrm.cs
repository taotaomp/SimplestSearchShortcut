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
        Log logOperator = new Log();
        FlowLayoutPanel buttonContainer;     //记录容器
        int index ;  //缓冲读取索引


        #region 按键事件
 
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if (e.KeyChar == 13)    //enter
            {
                if (textBox1.Text == "exit")                //退出
                {
                    this.Close();
                }
                else if (textBox1.Text.StartsWith("￥"))     //以“￥”开头表示打开系统应用
                {
                    buff.Add(textBox1.Text);        //将搜索的内容加入缓存
                    logOperator.logSave(textBox1.Text);     //将搜索的内容写入本地
                    index = buff.Count;
                                                       //去掉“￥”后的子串
                    System.Diagnostics.Process.Start(textBox1.Text.Substring(1)+".exe");
                    textBox1.Text = "";
                    
                }
                else if (textBox1.Text == "shutdown")       //关机
                {
                    buff.Add(textBox1.Text);
                    
                    index = buff.Count;

                    System.Diagnostics.Process.Start(@"D:\普软\启动\关机.bat");
                    textBox1.Text = "";
                }
                else if(textBox1.Text == "setting")         //设置搜索引擎
                {
                    SettingFrm s = new SettingFrm();
                    s.ShowDialog();
                    str = SettingFrm.item;
                    textBox1.Text = String.Empty;
                }
                else if(textBox1.Text == "clearLog")        //清理日志
                {
                    Log.clearLog();
                }
                else
                {
                    //加入缓冲，刷新缓冲读取索引
                    buff.Add(textBox1.Text);
                    index = buff.Count;
                    logOperator.logSave(textBox1.Text);     //将搜索的内容写入本地

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

            if (e.KeyChar == 1)     //ctrl + a
            {
                textBox1.SelectAll();
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

        #endregion

        private void MainFrm_Load(object sender, EventArgs e)
        {
            textBox1.Size = this.Size;
            textBox1.ImeMode = ImeMode.OnHalf;      //使文本框在输入时输入法始终是中文

            buttonContainer = new FlowLayoutPanel();        //实例化记录容器
            buttonContainer.Width = 284;
            buttonContainer.Height = 212;
            buttonContainer.Location = new Point(0, 40);
            buttonContainer.AllowDrop = true;
            this.Controls.Add(buttonContainer);

            logContent = new ArrayList();       //实例化用于存储，通过log查找方法，查找到的记录的容器
        }

        ArrayList logContent;   //用于存储，通过log查找方法，查找到的记录的容器

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text!= String.Empty)
            {
                logContent.Clear();
                logContent = logOperator.logFind(textBox1.Text);    //查找文本框中的文本在记录中出现的条目，并将全部条目返回到记录容器中

                if (logContent.Count != 0)      //在本地找到以前搜索的条目时
                {
                    this.Height = 212;
                }
                if (logContent.Count == 0)      //未在本地找到以前搜索的条目时
                {
                    buttonContainer.Controls.Clear();       //清空记录容器
                    this.Height = 40;
                }

                    Button logContentContainer;     //用于存储记录信息的按钮的引用
                try
                {
                    for (int i = 0; i < logContent.Count; i++)
                    {
                        logContentContainer = new Button();     //实例化存储记录信息的按钮
                        logContentContainer.Width = 284;
                        logContentContainer.Height = 30;
                        logContentContainer.TextAlign = ContentAlignment.MiddleLeft;
                        logContentContainer.FlatStyle = FlatStyle.Flat;
                        logContentContainer.Font = new Font("微软雅黑", 12, FontStyle.Bold);
                        logContentContainer.FlatAppearance.MouseOverBackColor = Color.Gray;
                        logContentContainer.Margin = new Padding(0);
                        logContentContainer.BackColor = Color.White;
                        //logContentContainer.MouseEnter += new EventHandler(logContentContainer_MouseEnter);
                        //logContentContainer.MouseLeave += new EventHandler(logContentContainer_MouseLeave);
                        logContentContainer.KeyPress += new KeyPressEventHandler(logContentContainer_KeyPress);
                        logContentContainer.Click += new EventHandler(logContentContainer_Click);
                        logContentContainer.Text = logContent[i].ToString();
                        buttonContainer.Controls.Add(logContentContainer);
                    }
                }
                catch (Exception)
                { }
            }
            
            if (textBox1.Text == String.Empty)
            {
                buttonContainer.Controls.Clear();       //清空记录容器
                this.Height = 40;
            }

        }
        #region logContentContainer事件集中区
        //private void logContentContainer_MouseEnter(object sender, EventArgs e)
        //{
        //    Button virtualButton = (Button)sender;
        //    virtualButton.BackColor = Color.Blue;
        //}

        //private void logContentContainer_MouseLeave(object sender, EventArgs e)
        //{
        //    Button virtualButton = (Button)sender;
        //    virtualButton.BackColor = Color.White;
        //}

        private void logContentContainer_KeyPress(object sender, KeyPressEventArgs e)
        {
            Button virtualButton = (Button)sender;
            if (e.KeyChar == 13)
            {
                System.Diagnostics.Process.Start("chrome.exe", str + virtualButton.Text);
                textBox1.Text = "";
                this.Height = 40;
            }
        }

        private void logContentContainer_Click(object sender, EventArgs e)
        {
            Button virtualButton = (Button)sender;
            System.Diagnostics.Process.Start("chrome.exe", str + virtualButton.Text);
            textBox1.Text = "";
            this.Height = 40;
        }
        #endregion
    }
}
