﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace scoketdemo4server
{
    class Program
    {

        public  static void listenclient(object i)
        {
            var socketex = i as Socket; //? 检测类型是否正确
            while (true)
            {
                var server = socketex.Accept();
                var sendport = server.RemoteEndPoint.ToString();
                Console.WriteLine($"{sendport} connected");
                //new thread for recving
                Thread thread = new Thread(recvmsg);
                thread.IsBackground = true;
                thread.Start(server);

                Thread thread1 = new Thread(sendmsg);
                thread1.IsBackground = true;
                thread1.Start(server);
            }
        }


        public static void recvmsg(object i)
        {
            var server = i as Socket;
            while (true)
            {
                try    //为什么无法捕获错误,SocketException,System.Net.Sockets.SocketException不同
                {
                    //recv
                    byte[] buffer = new byte[1024];

                    var str = server.Receive(buffer);                    
                    if (str == 0)
                    {
                        break;
                    }
                    var str1 = Encoding.UTF8.GetString(buffer, 0, str);
                    

                    Console.WriteLine("recv from client {0}",str1);
                    
                }
                catch (System.Net.Sockets.SocketException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }


            }
        }



        public static void sendmsg(object o)
        {
            var server = o as Socket;
            while (true)
            {
                try
                {
                    Console.WriteLine("server plz input:");
                    var strinput = Console.ReadLine();
                    var str = Encoding.Unicode.GetBytes(strinput);
                    server.Send(str);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
            }
        }




        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Any;
            IPEndPoint port = new IPEndPoint(ip,49091);
            //bind
            server.Bind(port);
            Console.WriteLine("listen success");
            server.Listen(4);

            //开启线程
            Thread thread = new Thread(listenclient);
            thread.IsBackground = true;
            thread.Start(server);
            Console.ReadKey();
            
        }

    }
}