﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nsCommoner;
using System.Data.SQLite;
namespace sqltool
{
    class tets
    {
        public void testdata()
        {
            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
            //创建连接数据库实例，指定文件位置 
            SQLiteConnection con = new SQLiteConnection(dbPath);
            //打开数据库，若文件不存在会自动创建 
            con.Open();
            Console.WriteLine("ok");
            
        }
        public void writesql()
        {
            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
            SQLiteConnection con = new SQLiteConnection(dbPath);
            con.Open();
            string sql = "CREATE TABLE IF NOT EXISTS student(id integer, name varchar(20), sex varchar(2));";
            SQLiteCommand com = new SQLiteCommand(sql, con);
            com.ExecuteNonQuery();
        }
    }
    class Program
    {
       
        static void Main(string[] args)
        {
            //string path = "Data Source="+ System.Environment.CurrentDirectory + "\\test.db3"+";Version=3;";

            //CSqliteWrapper._S_Init(path);
            //CSqliteWrapper._S_ExecuteSql("hello");

            tets a = new tets();
            //a.testdata();
            a.writesql();
            
        }
    }
}
