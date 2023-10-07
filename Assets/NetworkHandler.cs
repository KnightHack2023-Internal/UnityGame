using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

#nullable enable
public class NetworkHandler
{
    private TcpClient client;
    private Thread? thread;
    public NetworkHandler(string? ip) {
        client = new();
        client.Connect(ip ?? "10.173.200.58", 2048);
    }
    public void setCallback(Action<int> callback)
    {
        thread?.Abort();
        thread = new Thread(() => threadHandler(client.GetStream(), callback));
        thread.Start();
    }
    private void threadHandler(NetworkStream stream, Action<int> callback)
    {
        while (true)
        {
            byte[] buffer = new byte[4];
            int recSize = stream.Read(buffer, 0, 4);
            string msg = Encoding.UTF8.GetString(buffer, 0, recSize);
            callback(int.Parse(msg.TrimStart('0')));
        }
    }

}
