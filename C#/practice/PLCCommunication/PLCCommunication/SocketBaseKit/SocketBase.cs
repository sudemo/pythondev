﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace PLCCommunicationLibrary.SocketBaseKit
{
    class SocketBase
    {
        public Socket PLCClient; //字段
        private bool ConnectionStatus;


        #region creat socket client
        public ReturnStatus<Socket> CreatandConnect(string ip, int port)//创建并连接socket,此client
        {

            PLCClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try

            {
                //timeout = 100;这里无法设置连接的超时时间，可能会造成该线程卡住20s-40s(在地址错误的时候）
                //PLCClient.ReceiveTimeout = 100;
                PLCClient.Connect(ip, port);
                //Console.WriteLine("ok1{0}",ReturnStatus.CreatSuccessStatus(PLCClient));
                return ReturnStatus.CreatSuccessStatus(PLCClient);
            }
            catch (Exception e)
            {
                PLCClient?.Close();
                //log
                Console.Write(new ReturnStatus<Socket>(e.Message));
                Console.ReadKey();
                return new ReturnStatus<Socket>(e.Message);
            }
        }

        #endregion
        #region read send
        public ReturnStatus SocketSend(byte[] arg)
        {
            PLCClient.Send(arg);
            return ReturnStatus.CreatSuccessStatus<bool>();
        }

        public ReturnStatus SocketRec()
        {
            byte[] receiveBuffer = new byte[1024];
            PLCClient.Receive(receiveBuffer, receiveBuffer.Length, SocketFlags.None);

            //Console.Write(Encoding.UTF8.GetString(receiveBuffer));
            return ReturnStatus.CreatSuccessStatus<bool>();
        }
        #endregion



        public virtual string IpAddress
        {
            get
            {
                return ipAddress;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    //IPAddress address = new IPAddress();
                    if (!IPAddress.TryParse(value, out IPAddress address))
                    {
                        throw new Exception(StringResources.LanguageSet.IpAddresError);
                    }
                    ipAddress = value;
                }
                else
                {
                    ipAddress = "127.0.0.1";
                }
            }
        }




        #region Private Member

        //private TTransform byteTransform;                // 数据变换的接口
        private string ipAddress = "127.0.0.1";          // 连接的IP地址
        private int port = 102;                        // 端口号
        private int connectTimeOut = 100;              // 连接超时时间设置
        private string connectionId = string.Empty;      // 当前连接
        private bool isUseSpecifiedSocket = false;       // 指示是否使用指定的网络套接字访问数据

        /// <summary>
        /// 接收数据的超时时间
        /// </summary>
        protected int receiveTimeOut = 10000;            // 数据接收的超时时间
        /// <summary>
        /// 是否是长连接的状态
        /// </summary>
        protected bool isPersistentConn = false;         // 是否处于长连接的状态
        /// <summary>
        /// 交互的混合锁
        /// </summary>
        protected SimpleHybirdLock InteractiveLock;      // 一次正常的交互的互斥锁
        /// <summary>
        /// 当前的socket是否发生了错误
        /// </summary>
        protected bool IsSocketError = false;            // 指示长连接的套接字是否处于错误的状态

        #endregion

    }
}
