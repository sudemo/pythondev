﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using S7.Net;


namespace plcdemo
{
    class PlcHelper 
    {
        private static CpuType c = CpuType.S71500;
        public static string ip = "127.0.0.1";
        //public static string ip = "192.168.0.11";
        // private Plc plc_instance = new Plc(c, ip, 0, 1);
        public  Plc MyPlc;
       // public  static PlcHelper plcHelper_ins = new PlcHelper();



        //public PlcHelper() : base(CpuType.S71500, ip, 0, 1) { }



        public  PlcHelper()
        {
            MyPlc = new Plc(CpuType.S71500, "127.0.0.1", 0, 1);

        }

        //public PlcHelper GetInstance()
        //{
        //    if (plcHelper_ins == null)
        //    {
        //       return plcHelper_ins = new PlcHelper();

        //    }
        //    else
        //    {
        //        return plcHelper_ins;
        //    }
        //}


        #region MyRegion
        //public void Open()
        //{
        //    plc_instance.Open();
        //}

        //public void Open_async()
        //{
        //    plc_instance.OpenAsync();//zhege 才是真的异步的地方，其内部是异步的，此处往上封装 的都不是异步
        //}

        ////默认读取DB，需要参数DB number, startaddress,count
        //public object ReadDB(int db,int startaddr,int count)
        //    {
        //    return plc_instance.Read(DataType.DataBlock, db,startaddr, VarType.Byte, count);
        //    }

        //public object ReadDB_dint(int db, int startaddr, int count)
        //{
        //    return plc_instance.Read(DataType.DataBlock, db, startaddr, VarType.DInt, count);
        //}
        //public object ReadDB_int(int db, int startaddr, int count)
        //{
        //    return plc_instance.Read(DataType.DataBlock, db, startaddr, VarType.Int, count);
        //}
        //public object ReadDB_Word(int db, int startaddr, int count)
        //{
        //    return plc_instance.Read(DataType.DataBlock, db, startaddr, VarType.Word, count);
        //}

        ////异步读
        //public Task<object> ReadDB_Async(int db, int startaddr, int count)
        //{
        //    return plc_instance.ReadAsync(DataType.DataBlock, db, startaddr,VarType.DWord, count);
        //}

        //public Task<byte[]> ReadDB_Bytes_Async(int db, int startaddr, int count)
        //{
        //    return plc_instance.ReadBytesAsync(DataType.DataBlock,db,startaddr,count);
        //} 
        #endregion


    }

}
