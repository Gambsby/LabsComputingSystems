using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsComputingSystems.Models
{
    class ConfigWorker
    {
        private string ip;
        private int port;

        public ConfigWorker(string ip, int port)
        {
            this.Ip = ip;
            this.Port = port;
        }

        public string Ip { get => ip; set => ip = value; }
        public int Port { get => port; set => port = value; }
    }
}
