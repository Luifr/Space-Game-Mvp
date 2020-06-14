using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class Socket {
    static TcpClient connection;
    static UTF8Encoding encoder = new UTF8Encoding();

    public static void connect (string ip, int port) {
        Socket.connection = new TcpClient(ip, port);
    }

    public static void send (string message) {
        var stream = Socket.connection.GetStream();
        var buffer = Socket.encoder.GetBytes(message);
        stream.Write(buffer, 0, buffer.Length);
    }

    public static string receive () {
        var stream = Socket.connection.GetStream();
        var buffer = new byte[4096];
        stream.Read(buffer, 0, buffer.Length);
        return Socket.encoder.GetString(buffer);
    }
}
