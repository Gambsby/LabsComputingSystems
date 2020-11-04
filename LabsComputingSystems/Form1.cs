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
using System.Diagnostics;

namespace LabsComputingSystems
{
    public partial class Form1 : Form
    {
        private List<ConfigWorker> configWorkers { get; set; }

        public Form1()
        {
            InitializeComponent();
            label_time_all.Text = string.Empty;
            label_time.Text = string.Empty;
            label_res.Text = string.Empty;
            cB_mod.SelectedIndex = 0;
            configWorkers = new List<ConfigWorker>();
        }

        //кнопка Славы ( TODO: удалить потом )
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
                List<Host> hosts = new List<Host>();
                List<Task<String>> tasks = new List<Task<String>>();

                int steps_i = 0;
                double start_i = start, end_i = start;
                double result = 0;
                List<double> times = new List<double>();

                // Засекаем время
                Stopwatch sWatch = new Stopwatch();
                sWatch.Start();

                for (int i = configWorkers.Count; i > 0; i--)
                {
                    Host curHost = new Host(configWorkers[i-1].Ip, configWorkers[i-1].Port);

                    end_i += step * steps_i;
                    if (i == 1)
                        steps_i = steps;
                    else
                        steps_i = steps/configWorkers.Count;
                    ToWorkerData toWorkerData = new ToWorkerData(function, start_i, end_i, step);
                    Task<String> hostTask = new Task<String>(() => curHost.Start(toWorkerData.GetJson()));
                    hosts.Add(curHost);
                    tasks.Add(hostTask);
                    hostTask.Start();

                    start_i = end_i;
                }
                List<bool> completed = new List<bool>(tasks.Count);
                for (int i = 0; i < tasks.Count; i++)
                {
                    if (tasks[i].IsCompleted)
                    {
                        FromWorkerData recieveData = new FromWorkerData(tasks[i].Result);
                        result += recieveData.Result;
                        times.Add(recieveData.Time);
                        completed[i] = true;
                    }
                    Application.DoEvents();
                    if (completed.All(x => x == true)) break;
                    if (i == tasks.Count - 1)  i = 0;
                }

                // Останавливаем время
                sWatch.Stop();
                TimeSpan ts = sWatch.Elapsed;
                
                label_time_all.Text = ts.TotalSeconds.ToString();
                label_res.Text = result.ToString();
                label_time.Text = times.Min().ToString();
            }
        }

        private void btn_start_worker_Click(object sender, EventArgs e)
        {
            textBox_logs_worker.Text = string.Empty;
            textBox_logs_worker.Text += "Начало работы, адрес: " + Network.GetLocalIPAddressString();
            // TODO: запихать в task

            Worker worker = new Worker(8888);
            Task<FromWorkerData> workerTask = new Task<FromWorkerData>(() => worker.Start());
            while(!workerTask.IsCompleted)
            {
                Application.DoEvents();
            }
            FromWorkerData res = workerTask.Result;

            textBox_logs_worker.Text += "Результат: " + res.Result.ToString();
            textBox_logs_worker.Text += "Время выполнения: " + res.Time.ToString();
        }

        private void check_compleet()
        {
            if ((txtBox_function.Text.Length > 0) && (txtBox_start.Text.Length > 0) && (txtBox_end.Text.Length > 0) && (txtBox_steps.Text.Length > 0))
                btn_start_mainHost.Enabled = true;
            else
                btn_start_mainHost.Enabled = false;
        }

        private void txtBox_function_TextChanged(object sender, EventArgs e)
        {
            check_compleet();
        }

        private void txtBox_start_TextChanged(object sender, EventArgs e)
        {
            check_compleet();
        }

        private void txtBox_end_TextChanged(object sender, EventArgs e)
        {
            check_compleet();
        }

        private void txtBox_steps_TextChanged(object sender, EventArgs e)
        {
            check_compleet();
        }

        private void cB_mod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cB_mod.SelectedIndex == 0)
            {
                label_time_all_text.Visible = true;
                btn_add_workers.Visible = true;
            }
            else
            {
                btn_add_workers.Visible = false;
                label_time_all_text.Visible = false;
            }
        }

        private void btn_add_workers_Click(object sender, EventArgs e)
        {
            Form_adress dialog_redact_addres = new Form_adress(this.configWorkers);
            dialog_redact_addres.ShowDialog();
        }
    }
}
