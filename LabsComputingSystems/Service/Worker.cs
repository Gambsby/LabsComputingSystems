using LabsComputingSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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
            // Адрес сервера
            this.localAddress = GetLocalIPAddress();
            // Порт приема
            this.port = port;
            // Создаем листенер для сервера
            this.server = new TcpListener(localAddress, this.port);
        }

        public FromWorkerData Start()
        {
            FromWorkerData tmp = null;
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
                            tmp = WorkerFunction(recieveMessage.ToString());
                            string json = tmp.GetJson();
                            Byte[] responseData = Encoding.UTF8.GetBytes(json);

                            stream.Write(responseData, 0, responseData.Length);
                        }
                    }
                    finally
                    {
                        stream.Close();
                        client.Close();
                        server.Stop();
                    }
                }
                catch
                {
                    stream.Close();
                    client.Close();
                    server.Stop();
                    break;
                }
            }

            return tmp;

        }

        private FromWorkerData WorkerFunction(string json)
        {
            // Реализация "Работника"
            Stopwatch sWatch = new Stopwatch();
            ToWorkerData toWorkerData = new ToWorkerData(json);
            double result = 0, time = 0;
            
            // Засекаем время
            sWatch.Start();
            
            // Счетаем интеграл методом трапеций
            result = Integral(toWorkerData);

            // Останавливаем время
            sWatch.Stop();
            TimeSpan ts = sWatch.Elapsed;
            time = ts.TotalSeconds;

            return new FromWorkerData(result, time);
            //return fromWorkerData.GetJson();
        }

        public FromWorkerData WorkerFunction(ToWorkerData toWorkerData)
        {
            // Реализация "Работника"
            Stopwatch sWatch = new Stopwatch();
            double result = 0, time = 0;

            // Засекаем время
            sWatch.Start();

            // Счетаем интеграл методом трапеций
            result = Integral(toWorkerData);

            // Останавливаем время
            sWatch.Stop();
            TimeSpan ts = sWatch.Elapsed;
            time = ts.TotalSeconds;

            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //                                    ts.Hours, ts.Minutes, ts.Seconds,
            //                                    ts.Milliseconds / 10);

            return new FromWorkerData(result, time);
        }

        private double Integral(ToWorkerData Data)
        {
            double result = 0;
            for (int i = 0; i < Data.Steps; i++)
            {
                if (i == 0 || i == Data.Steps - 1)
                    result += Fuction(Data.Fuction, i * Data.Long_step + Data.Start)/2;
                else
                    result += Fuction(Data.Fuction, i * Data.Long_step + Data.Start);
            }
            return result*Data.Long_step;
        }

        private double Fuction(string fuction, double x)
        {
            // TODO: fuction(x) (нужно выполнить string функции)

            return Math.Pow(Math.Log(x), 4); //пример для тестов
        }
    }
}
