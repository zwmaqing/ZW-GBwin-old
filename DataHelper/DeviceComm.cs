using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace DataHelper
{
    public class udpReceiver
    {
        /// <summary>
        /// udpReceiveServices
        /// </summary>
        UdpClient udpReceiveService = new UdpClient();

        //标识客户端是否关闭
        private bool isClose = false;


        /// <summary>
        /// 用于控制异步接收消息
        /// </summary>
        private ManualResetEvent doReceive = new ManualResetEvent(false);

        /// <summary>
        /// 客户端接收消息触发的事件
        /// </summary>
        public event Action<IPAddress, Byte[], string> Received;


        public bool StartUdpReceive(IPAddress localIP, int port, bool isJoinGroup = false, IPAddress groupIP = null)
        {
            IPEndPoint localIpEndPoint = new IPEndPoint(localIP, port);

            if (!isClose && ((IPEndPoint)udpReceiveService.Client.LocalEndPoint) == localIpEndPoint)
            {
                return false;//已经打开了同样的UDP接收端口
            }


            udpReceiveService = new UdpClient(localIpEndPoint);
            if (isJoinGroup && groupIP != null)
            {
                udpReceiveService.JoinMulticastGroup(groupIP);
                udpReceiveService.Ttl = 50;
            }
            isClose = false;
            ThreadPool.QueueUserWorkItem(x =>
            {
                while (!isClose)
                {
                    try
                    {
                        Thread.Sleep(20);
                        ReceiveAsync(port);
                        Thread.Sleep(20);
                    }
                    catch (Exception)
                    {
                        Close();
                    }
                }
            });
            return true;
        }

        private void ReceiveAsync(int port)
        {
            doReceive.Reset();
            UdpState state = new UdpState();
            state.Client = udpReceiveService;
            state.IpEndPoint = new IPEndPoint(IPAddress.Any, port);

            udpReceiveService.BeginReceive(new AsyncCallback(ReceiveCallback), state);

            doReceive.WaitOne();
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            UdpClient u = (UdpClient)((UdpState)(ar.AsyncState)).Client;
            IPEndPoint e = (IPEndPoint)((UdpState)(ar.AsyncState)).IpEndPoint;

            Byte[] receiveBytes = null;

            try
            {
                receiveBytes = u.EndReceive(ar, ref e);
                doReceive.Set();
                string receiveString = Encoding.UTF8.GetString(receiveBytes);

                Received?.Invoke(e.Address, receiveBytes, receiveString);
            }
            catch (System.ObjectDisposedException ex)
            {

            }
        }

        public void Close()
        {
            udpReceiveService.Close();
            isClose = true;
        }
    }


    /// <summary>
    /// 接收到的数据报文
    /// </summary>
    public class rceivedReport : EventArgs
    {
        /// <summary>
        /// The report buff
        /// </summary>
        public readonly byte[] reportBuff;
        /// <summary>
        /// str
        /// </summary>
        public readonly string reportString;
        /// <summary>
        /// Initializes a new instance of the <see cref="rceivedReport"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="arrayBuff">The array buff.</param>
        public rceivedReport(byte[] arrayBuff, string str)
        {
            reportBuff = arrayBuff;
            reportString = str;
        }
    }

    public class UdpState
    {
        public UdpClient Client { get; set; }
        public IPEndPoint IpEndPoint { get; set; }
    }

}
