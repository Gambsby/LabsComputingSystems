using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.CompilerServices;

namespace LabsComputingSystems.Models
{
    class FromWorkerData
    {
        private double result;
        private double time;

        public FromWorkerData()
        {

        }

        public FromWorkerData(double result, double time)
        {
            this.Result = result;
            this.Time = time;
        }

        public FromWorkerData(string json)
        {
            FromWorkerData tmp = JsonSerializer.Deserialize<FromWorkerData>(json);
            this.Result = tmp.Result;
            this.Time = tmp.Time;
        }

        public double Result { get => result; set => result = value; }
        public double Time { get => time; set => time = value; }

        public string GetJson()
        {
            return JsonSerializer.Serialize<FromWorkerData>(this);
        }
    }
}
