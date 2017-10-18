using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using System.IO;
using System.Text;


namespace SimplestSearchShortcut
{
    /// <summary>
    /// 用于操作记录的类
    /// 可储存日志到本地，读取本地日志，在日志中查询
    /// </summary>
    class Log
    {
        private ArrayList container = new ArrayList();     //用于去重比较

        /// <summary>
        /// 构造函数
        /// </summary>
        public Log()
        {
            logLoad();              //将本地日志写入比较器，比较器作为日志添加时的排重基准  
        }


        /// <summary>
        /// 将记录写入文件
        /// </summary>
        /// <param name="str">写入的内容</param>
        /// <returns>true为成功false为失败</returns>

        public bool logSave(String str)       
        {
            try
            {
                StreamWriter sw = new StreamWriter("log", true, Encoding.UTF8);
                if (!container.Contains(str))
                {
                    sw.WriteLine(str);
                } 
                sw.Close();
                container.Add(str);     //在将新的条目写入本地文件中后，同时将其加到内存的比较容器中，一遍能在不退出程序的情况下再次通过logFind方法获取结果
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 读取本地搜索记录
        /// </summary>
        /// <returns>true为读取成功false为失败</returns>
        public void logLoad()       
        {
            try
            {
                StreamReader sr = new StreamReader("log", Encoding.UTF8);
                while(!sr.EndOfStream)
                {
                    container.Add(sr.ReadLine());
                }
                sr.Close();
            }
            catch(Exception)
            {

            }
        }

        /// <summary>
        /// 查找匹配的记录
        /// </summary>
        /// <param name="str">要查找的字符串</param>
        /// <returns>以str字符串开头的所有值</returns>
        public ArrayList logFind(string str)
        {
            ArrayList findResult = new ArrayList();
            for (int i = 0; i < container.Count; i++)
            {
                if(container[i].ToString().StartsWith(str))
                {
                    findResult.Add(container[i]);
                }
            }
            return findResult;
        }

        /// <summary>
        /// 清除所有的日志
        /// </summary>
        public static void clearLog()
        {
            try
            {
                StreamWriter sw = new StreamWriter("log", false);
                sw.Close();
            }
            catch(Exception)
            {

            }
            
        }
    }
}
