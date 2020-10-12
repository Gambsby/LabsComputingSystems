using LabsComputingSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LabsComputingSystems.Service
{
    class Worker : Network
    {
        private IPAddress localAddress;
        private int port;
        private TcpClient client;
        private NetworkStream stream;
        private TcpListener server;

        public Worker(int port)
        {
            //Адрес сервера
            this.localAddress = GetLocalIPAddress();
            //Порт приема
            this.port = port;
            //Создаем листенер для сервера
            this.server = new TcpListener(localAddress, this.port);
        }

        public void Start()
        {
            // Запуск в работу
            server.Start();
            // Запуск в работу
            server.Start();
            // Бесконечный цикл
            while (true)
            {
                try
                {
                    // Подключение клиента
                    client = server.AcceptTcpClient();
                    stream = client.GetStream();
                    // Обмен данными
                    try
                    {
                        if (stream.CanRead)
                        {
                            byte[] readBuffer = new byte[1024];
                            StringBuilder recieveMessage = new StringBuilder();
                            int numberOfBytesRead = 0;
                            do
                            {
                                numberOfBytesRead = stream.Read(readBuffer, 0, readBuffer.Length);
                                recieveMessage.AppendFormat("{0}", Encoding.UTF8.GetString(readBuffer, 0, numberOfBytesRead));
                            }
                            while (stream.DataAvailable);
                            Byte[] responseData = Encoding.UTF8.GetBytes(WorkerFunction(recieveMessage.ToString()));
                            stream.Write(responseData, 0, responseData.Length);
                        }
                    }
                    finally
                    {
                        stream.Close();
                        client.Close();
                    }
                }
                catch
                {
                    server.Stop();
                    break;
                }
            }

        }

        private string WorkerFunction(string json)
        {
            //Реализация "Работника"
            ToWorkerData toWorkerData = new ToWorkerData(json);
            //Тут обработка
            FromWorkerData fromWorkerData = new FromWorkerData();
            return fromWorkerData.GetJson();
        }
    }
}
