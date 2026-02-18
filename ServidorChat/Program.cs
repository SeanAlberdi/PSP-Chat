using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServidorChat
{
    class Program
    {
        static List<TcpClient> listaClientes = new List<TcpClient>();

        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 8888);
            serverSocket.Start();
            Console.WriteLine("Zerbitzaria piztuta... bezeroak itxaroten.");

            while (true)
            {
                TcpClient clientSocket = serverSocket.AcceptTcpClient();
                listaClientes.Add(clientSocket);

                Console.WriteLine("Bezeroa konektatuta!");

                Thread clientThread = new Thread(ManejarCliente);
                clientThread.Start(clientSocket);
            }
        }

        public static void ManejarCliente(object obj)
        {
            TcpClient clientSocket = (TcpClient)obj;
            NetworkStream stream = clientSocket.GetStream();

            StreamReader reader = new StreamReader(stream);

            try
            {
                string mensaje;
                while ((mensaje = reader.ReadLine()) != null)
                {
                    Console.WriteLine("Recibido: " + mensaje);
                    Broadcast(mensaje, clientSocket);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Un usuario se ha desconectado forzosamente.");
            }
            finally
            {
                listaClientes.Remove(clientSocket);
                clientSocket.Close();
            }
        }

        public static void Broadcast(string mensaje, TcpClient clienteExcluido)
        {
            // Recorremos todos los clientes conectados
            foreach (TcpClient item in listaClientes)
            {

                try
                {
                    NetworkStream stream = item.GetStream();
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine(mensaje);
                    writer.AutoFlush = true; 
                }
                catch (Exception)
                {
                }
            }
        }
    }
}