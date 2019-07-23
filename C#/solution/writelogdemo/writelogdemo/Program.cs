﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Threading;

namespace writelogdemo
{
    class Program
    { 
         public static void Page_Load()
        {
        try
            {
                LogHelper.WriteLog("this is a error log1 ");
                string a = "13";
            int b = Convert.ToInt32(a);
                LogHelper.WriteLog("this is a error log2 ");
                LogHelper.Infor("log3");
                LogHelper.InfoFormatted("sss");
                //Console.WriteLine("ok");
                Console.ReadKey();
            }
        catch (Exception ex)
            {
                LogHelper.WriteLog("this is a error log ");
                LogHelper.WriteLog(ex.Message.ToString(), ex);
            }
        }

        public static void Main(string[] args)

        {
            Page_Load();
            LogHelper.Infor("starting");
            Console.WriteLine(string.Format("当前时间为{0}.", DateTime.Now.ToString()));
            Console.WriteLine("当前时间为{0}.", DateTime.Now.ToString());
            LogHelper.WriteLog(string.Format("当前时间为{0}.", DateTime.Now.ToString()));
            Console.ReadKey();
        }
    }
}

