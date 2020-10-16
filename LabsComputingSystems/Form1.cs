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
    }
}
