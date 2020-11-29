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

namespace LabsComputingSystems
{
    partial class Form_adress : Form
    {
        private List<ConfigWorker> workersConfig;

        public Form_adress(List<ConfigWorker> config)
        {
            InitializeComponent();
            this.workersConfig = config;
        }

        private void Form_adress_Load(object sender, EventArgs e)
        {
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "IP адрес"; //текст в шапке
            column1.Width = 150; //ширина колонки
            column1.Name = "ip_addr"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column1.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Порт";
            column2.Name = "port";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            
            for (int i = 0; i < workersConfig.Count; ++i)
            {
                dataGridView1.Rows.Add(workersConfig[i].Ip.ToString(), workersConfig[i].Port.ToString());
            }
        }
        
        private void btn_save_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                int port = 8888;
                if (dataGridView1[1, i].Value != null)
                    port = int.Parse(dataGridView1[1, i].Value.ToString());
                ConfigWorker new_config = new ConfigWorker(dataGridView1[0, i].Value.ToString(), port);
                workersConfig.Add(new_config);
            }
            this.Close();
        }
    }
}
