using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEditor;
using UnityEngine;

public static class NetworkHandler
{
    public static int distance = 15;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadNetwork()
    {
        if (Application.isEditor) return;
        TcpClient client = new();
        client.Connect("10.173.200.58", 2048);
        Thread thread = new Thread(() => threadHandler(client.GetStream()));
        thread.Start();
    }
    private static void threadHandler(NetworkStream stream)
    {
        while (true)
        {
            byte[] buffer = new byte[4];
            int recSize = stream.Read(buffer, 0, 4);
            string msg = Encoding.UTF8.GetString(buffer, 0, recSize);
            NetworkHandler.distance = int.Parse(msg.TrimStart('0'));
        }
    }

}
