using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabsComputingSystems.Models;
using LabsComputingSystems.Service;

namespace LabsComputingSystems
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void test_btn_Click(object sender, EventArgs e)
        {
            Host host = new Host("192.168.1.238", 8889);
            string res = host.Start("This");
            FromWorkerData fromWorkerData = new FromWorkerData(25, 5);
            string json = fromWorkerData.GetJson();
            FromWorkerData testObject = new FromWorkerData(json);
        }

        private void btn_start_mainHost_Click(object sender, EventArgs e)
        {
            label_ip.Text = "Адрес:" + Network.GetLocalIPAddressString();
            string function = txtBox_function.Text;
            double start = double.Parse(txtBox_start.Text);
            double end = double.Parse(txtBox_end.Text);
            int steps = int.Parse(txtBox_steps.Text);
            double step = (start - end) / steps;
            if (cB_mod.SelectedIndex == 1)
            {
                // работа главного узла в режиме "один"
                ToWorkerData toData = new ToWorkerData(function, start, end, steps);
                Worker worker = new Worker(0);
                FromWorkerData fromData = worker.WorkerFunction(toData);
                label_res.Text = fromData.Result.ToString();
                label_time.Text= fromData.Time.ToString();
            }
            else if(cB_mod.SelectedIndex == 0)
            {
                // работа главного узла в режиме "раскидал задачу другим"
                // TODO: создать список воркеров

                int countWorkers = 3;
                int steps_i = 0;
                double start_i = start, end_i = start;
                double result = 0;
                List<double> times = new List<double>();
                for (int i = countWorkers; i > 0; i--)
                {
                    end_i += step * steps_i;
                    if (i == 1)
                        steps_i = steps;
                    else
                        steps_i = steps/countWorkers;
                    // TODO: отправка данных на воркера (start_i, end_i, steps_i, step, function)

                    
                    start_i = end_i;
                }
                for (int i = countWorkers; i > 0; i--)
                {
                    // TODO: получение данных от воркера (result_i и time_i)
                    
                    
                    //result += result_i;
                    //times.Add(time_i);
                }
                label_res.Text = result.ToString();
                label_time.Text = times.Min().ToString();
            }
        }

        private void btn_start_worker_Click(object sender, EventArgs e)
        {
            textBox_logs_worker.Text = string.Empty;
            textBox_logs_worker.Text += "Начало работы, адрес: " + Network.GetLocalIPAddressString();
            double result = 0, time = 0;
            // TODO: стартануть воркера

            textBox_logs_worker.Text += "Результат: " + result.ToString();
            textBox_logs_worker.Text += "Время выполнения: " + time.ToString();
        }
    }
}
