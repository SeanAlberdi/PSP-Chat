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
        // Lista estática para guardar a todos los clientes conectados
        static List<TcpClient> listaClientes = new List<TcpClient>();

        static void Main(string[] args)
        {
            // Escuchamos en cualquier IP local, puerto 8888
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 8888);
            serverSocket.Start();
            Console.WriteLine("Zerbitzaria piztuta... bezeroak itxaroten.");

            while (true)
            {
                // El programa se detiene aquí hasta que alguien se conecta
                TcpClient clientSocket = serverSocket.AcceptTcpClient();
                listaClientes.Add(clientSocket);

                Console.WriteLine("Bezeroa konektatuta!");

                // Creamos un hilo separado para manejar a este usuario 
                // para que el bucle pueda volver a escuchar nuevos usuarios
                Thread clientThread = new Thread(ManejarCliente);
                clientThread.Start(clientSocket);
            }
        }

        public static void ManejarCliente(object obj)
        {
            TcpClient clientSocket = (TcpClient)obj;
            NetworkStream stream = clientSocket.GetStream();

            // Usamos StreamReader y StreamWriter para leer texto fácilmente
            StreamReader reader = new StreamReader(stream);

            try
            {
                string mensaje;
                // Bucle infinito mientras el cliente esté conectado
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
                // (Opcional) No enviamos el mensaje al que lo escribió, 
                // o sí, depende de como quieras que se vea. 
                // Aquí se lo enviamos a todos para simplificar.
                try
                {
                    NetworkStream stream = item.GetStream();
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine(mensaje);
                    writer.AutoFlush = true; // Importante para enviar el dato inmediatamente
                }
                catch (Exception)
                {
                    // Si falla el envío, probablemente el cliente se desconectó
                }
            }
        }
    }
}