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
                    result += Fuction(Data.Fuction, i * Data.Long_step + Data.Start) / 2;
                else
                    result += Fuction(Data.Fuction, i * Data.Long_step + Data.Start);
            }
            return result * Data.Long_step;
        }

        private double Fuction(string function, double x)
        {
            switch (function)
            {
                case "x^4 + x^3 + x^2":
                    return Math.Pow(x, 4) + Math.Pow(x, 3) + Math.Pow(x, 2);
                case "ln(x^4 + x^3 + x^2)":
                    return Math.Log(Math.Pow(x, 4) + Math.Pow(x, 3) + Math.Pow(x, 2));
                case "sin(ln((x^4 + x^3) / x^2))":
                    return Math.Sin(Math.Log((Math.Pow(x, 4) + Math.Pow(x, 3)) / Math.Pow(x, 2)));
                case "cos(ln((x^4 + x^3) / x^2))":
                    return Math.Cos(Math.Log((Math.Pow(x, 4) + Math.Pow(x, 3)) / Math.Pow(x, 2)));
            }
            return Math.Pow(Math.Log(x), 4); //пример для тестов
        }

        private double Pow(double x, int y)
        {
            double res = x;
            if (y == 0) return 1;
            for (int i = 1; i < Math.Abs(y); i++)
            {
                res *= x;
            }
            if (y < 0)
            {
                res = 1 / res;
            }
            return res;
        }
    }
}
