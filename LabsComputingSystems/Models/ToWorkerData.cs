using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace LabsComputingSystems.Models
{
    class ToWorkerData
    {
        private string fuction;
        private double start;
        private double end;
        private int steps;
        private double long_step;

        public ToWorkerData()
        {

        }

        public ToWorkerData(string fuction, double start, double end, int steps, double long_step)
        {
            this.Fuction = fuction;
            this.Start = start;
            this.End = end;
            this.Steps = steps;
            this.Long_step = long_step;
        }

        public ToWorkerData(string fuction, double start, double end, int steps)
        {
            this.Fuction = fuction;
            this.Start = start;
            this.End = end;
            this.Steps = steps;
            this.Long_step = (end - start) / steps;
        }

        public ToWorkerData(string json)
        {
            ToWorkerData tmp = JsonSerializer.Deserialize<ToWorkerData>(json);
            this.Fuction = tmp.Fuction;
            this.Start = tmp.Start;
            this.End = tmp.End;
            this.Steps = tmp.Steps;
            this.Long_step = tmp.Long_step;
        }

        public string Fuction { get => fuction; set => fuction = value; }
        public double Start { get => start; set => start = value; }
        public double End { get => end; set => end = value; }
        public int Steps { get => steps; set => steps = value; }
        public double Long_step { get => long_step; set => long_step = value; }

        public string GetJson()
        {
            return JsonSerializer.Serialize<ToWorkerData>(this);
        }
    }
}
