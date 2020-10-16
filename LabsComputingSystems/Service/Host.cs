using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LabsComputingSystems.Service
{
    class Host : Network
    {
        private string workerAddress;
        private int workerPort;
        private TcpClient client;
        private NetworkStream stream;

        public Host(string workerAddress, int workerPort)
        {
            //Адрес куда отправлять
            this.workerAddress = workerAddress;
            //Порт куда отправлять
            this.workerPort = workerPort;
            // Инициализация
            client = new TcpClient(this.workerAddress, this.workerPort);
        }
        public string Start(string message)
        {
            Byte[] data = Encoding.UTF8.GetBytes(message);
            stream = client.GetStream();
            try
            {
                // Отправка сообщения
                stream.Write(data, 0, data.Length);
                // Получение ответа
                Byte[] readingData = new Byte[1024];
                StringBuilder responseMessage = new StringBuilder();
                int numberOfBytesRead = 0;
                do
                {
                    numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);
                    responseMessage.AppendFormat("{0}", Encoding.UTF8.GetString(readingData, 0, numberOfBytesRead));
                }
                while (stream.DataAvailable);
                String responseData = responseMessage.ToString();
                return responseData;
            }
            finally
            {
                stream.Close();
                client.Close();
            }
        }
    }
}
