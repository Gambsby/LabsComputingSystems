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

        double last_time_one = 0;

        public Form1()
        {
            InitializeComponent();
            label_time_all.Text = string.Empty;
            label_time.Text = string.Empty;
            label_res.Text = string.Empty;
            cB_mod.SelectedIndex = 0;
            configWorkers = new List<ConfigWorker>();

            string[] functions = new string[4];
            functions[0] = "x^4 + x^3 + x^2";
            functions[1] = "ln(x^4 + x^3 + x^2)";
            functions[2] = "sin(ln((x^4 + x^3) / x^2))";
            functions[3] = "cos(ln((x^4 + x^3) / x^2))";

            txtBox_function.Items.AddRange(functions);

            label_def.Visible = false;
            label_def_text.Visible = false;
        }

        /*кнопка Test
        private void test_btn_Click(object sender, EventArgs e)
        {
            ToWorkerData toData = new ToWorkerData("test", 0, 1, 1000);
            Host host = new Host("192.168.43.2", 8888);
            string res = host.Start(toData.GetJson());
            FromWorkerData fromWorkerData = new FromWorkerData(res);
        }
        */

        private void btn_start_mainHost_Click(object sender, EventArgs e)
        {
            label_ip.Text = "Адрес:" + Network.GetLocalIPAddressString();
            string function = txtBox_function.Text;
            double start = double.Parse(txtBox_start.Text);
            double end = double.Parse(txtBox_end.Text);
            int steps = int.Parse(txtBox_steps.Text);
            double step = (end - start) / steps;
            if (cB_mod.SelectedIndex == 1)
            {
                // работа главного узла в режиме "один"
                ToWorkerData toData = new ToWorkerData(function, start, end, steps);
                Worker worker = new Worker(0);
                FromWorkerData fromData = worker.WorkerFunction(toData);
                label_res.Text = fromData.Result.ToString();
                label_time.Text= fromData.Time.ToString() + "с";

                last_time_one = fromData.Time;
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

                    if (i == 1)
                        steps_i = steps - (steps / configWorkers.Count * (configWorkers.Count-1));
                    else
                        steps_i = steps/configWorkers.Count;
                    end_i += step * steps_i;

                    ToWorkerData toWorkerData = new ToWorkerData(function, start_i, end_i, steps_i, step);
                    Task<String> hostTask = new Task<String>(() => curHost.Start(toWorkerData.GetJson()));
                    //FromWorkerData recieveData = new FromWorkerData(curHost.Start(toWorkerData.GetJson()));
                    hosts.Add(curHost);
                    tasks.Add(hostTask);
                    hostTask.Start();
                    start_i = end_i;
                }
                bool[] completed = new bool[tasks.Count];


                for (int i = 0; i < tasks.Count; i++)
                {
                    if (tasks[i].IsCompleted && !completed[i])
                    {
                        FromWorkerData recieveData = new FromWorkerData(tasks[i].Result);
                        result += recieveData.Result;
                        times.Add(recieveData.Time);
                        completed[i] = true;
                    }
                    Application.DoEvents();
                    if (completed.All(x => x == true)) break;
                    if (i == tasks.Count - 1)  i = -1;
                }

                // Останавливаем время
                sWatch.Stop();
                TimeSpan ts = sWatch.Elapsed;
                
                label_time_all.Text = ts.TotalSeconds.ToString();
                label_res.Text = result.ToString();
                label_time.Text = times.Max().ToString();

                if (last_time_one != 0)
                {
                    label_def.Text = (last_time_one - times.Max()).ToString() + "c";
                    label_def.Visible = true;
                    label_def_text.Visible = true;
                }
                else
                {
                    label_def.Visible = false;
                    label_def_text.Visible = false;
                }
            }
        }

        private void btn_start_worker_Click(object sender, EventArgs e)
        {
            Worker worker = new Worker(8888);
            textBox_logs_worker.Text = string.Empty;
            while(true)
            {
                textBox_logs_worker.Text += "Начало работы:\tAдрес: " + Network.GetLocalIPAddressString() + "\tПорт: 8888" + Environment.NewLine;
                Task<FromWorkerData> workerTask = new Task<FromWorkerData>(() => worker.Start());
                btn_start_worker.Enabled = false;
                workerTask.Start();
                while (!workerTask.IsCompleted)
                {
                    Application.DoEvents();
                }
                FromWorkerData res = workerTask.Result;
                //FromWorkerData res = worker.Start();

                textBox_logs_worker.Text += "Результат: " + res.Result.ToString() + Environment.NewLine;
                textBox_logs_worker.Text += "Время выполнения: " + res.Time.ToString() + "с" + Environment.NewLine;
            }
            //btn_start_worker.Enabled = true;
        }

        private void check_compleet()
        {
            if ((txtBox_function.Text.Length > 0) && (txtBox_start.Text.Length > 0) && (txtBox_end.Text.Length > 0) && (txtBox_steps.Text.Length > 0))
                if ((configWorkers.Count > 0 && cB_mod.SelectedIndex == 0) || cB_mod.SelectedIndex == 1)
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
                label_time_all.Visible = true;
                label_time_all.Text = null;
                check_compleet();
            }
            else
            {
                btn_add_workers.Visible = false;
                label_time_all_text.Visible = false;
                label_time_all.Visible = false;
                check_compleet();
            }
        }

        private void btn_add_workers_Click(object sender, EventArgs e)
        {
            Form_adress dialog_redact_addres = new Form_adress(this.configWorkers);
            dialog_redact_addres.ShowDialog();
            check_compleet();
        }
    }
}
