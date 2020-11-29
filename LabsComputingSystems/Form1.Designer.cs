namespace LabsComputingSystems
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMainHost = new System.Windows.Forms.TabPage();
            this.btn_start_mainHost = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_add_workers = new System.Windows.Forms.Button();
            this.groupBox_Function = new System.Windows.Forms.GroupBox();
            this.txtBox_function = new System.Windows.Forms.ComboBox();
            this.txtBox_steps = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBox_end = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBox_start = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cB_mod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_time_all = new System.Windows.Forms.Label();
            this.label_time_all_text = new System.Windows.Forms.Label();
            this.label_res = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabWorkerHost = new System.Windows.Forms.TabPage();
            this.btn_start_worker = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox_logs_worker = new System.Windows.Forms.TextBox();
            this.label_ip = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabMainHost.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox_Function.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabWorkerHost.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMainHost);
            this.tabControl.Controls.Add(this.tabWorkerHost);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tabControl.ItemSize = new System.Drawing.Size(200, 30);
            this.tabControl.Location = new System.Drawing.Point(2, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(726, 332);
            this.tabControl.TabIndex = 1;
            // 
            // tabMainHost
            // 
            this.tabMainHost.Controls.Add(this.btn_start_mainHost);
            this.tabMainHost.Controls.Add(this.groupBox3);
            this.tabMainHost.Controls.Add(this.groupBox2);
            this.tabMainHost.Location = new System.Drawing.Point(4, 34);
            this.tabMainHost.Name = "tabMainHost";
            this.tabMainHost.Padding = new System.Windows.Forms.Padding(3);
            this.tabMainHost.Size = new System.Drawing.Size(718, 294);
            this.tabMainHost.TabIndex = 0;
            this.tabMainHost.Text = "Хозяин";
            this.tabMainHost.UseVisualStyleBackColor = true;
            // 
            // btn_start_mainHost
            // 
            this.btn_start_mainHost.Enabled = false;
            this.btn_start_mainHost.Location = new System.Drawing.Point(484, 262);
            this.btn_start_mainHost.Name = "btn_start_mainHost";
            this.btn_start_mainHost.Size = new System.Drawing.Size(106, 27);
            this.btn_start_mainHost.TabIndex = 2;
            this.btn_start_mainHost.Text = "Начать";
            this.btn_start_mainHost.UseVisualStyleBackColor = true;
            this.btn_start_mainHost.Click += new System.EventHandler(this.btn_start_mainHost_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_add_workers);
            this.groupBox3.Controls.Add(this.groupBox_Function);
            this.groupBox3.Controls.Add(this.cB_mod);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(10, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 282);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Начальные данные";
            // 
            // btn_add_workers
            // 
            this.btn_add_workers.Location = new System.Drawing.Point(12, 238);
            this.btn_add_workers.Name = "btn_add_workers";
            this.btn_add_workers.Size = new System.Drawing.Size(320, 27);
            this.btn_add_workers.TabIndex = 10;
            this.btn_add_workers.Text = "Редактировать список работников";
            this.btn_add_workers.UseVisualStyleBackColor = true;
            this.btn_add_workers.Click += new System.EventHandler(this.btn_add_workers_Click);
            // 
            // groupBox_Function
            // 
            this.groupBox_Function.Controls.Add(this.txtBox_function);
            this.groupBox_Function.Controls.Add(this.txtBox_steps);
            this.groupBox_Function.Controls.Add(this.label3);
            this.groupBox_Function.Controls.Add(this.groupBox1);
            this.groupBox_Function.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_Function.Location = new System.Drawing.Point(12, 21);
            this.groupBox_Function.Name = "groupBox_Function";
            this.groupBox_Function.Size = new System.Drawing.Size(328, 168);
            this.groupBox_Function.TabIndex = 0;
            this.groupBox_Function.TabStop = false;
            this.groupBox_Function.Text = "Функция";
            // 
            // txtBox_function
            // 
            this.txtBox_function.FormattingEnabled = true;
            this.txtBox_function.Location = new System.Drawing.Point(6, 23);
            this.txtBox_function.Name = "txtBox_function";
            this.txtBox_function.Size = new System.Drawing.Size(314, 24);
            this.txtBox_function.TabIndex = 7;
            // 
            // txtBox_steps
            // 
            this.txtBox_steps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBox_steps.Location = new System.Drawing.Point(210, 130);
            this.txtBox_steps.Name = "txtBox_steps";
            this.txtBox_steps.Size = new System.Drawing.Size(110, 26);
            this.txtBox_steps.TabIndex = 6;
            this.txtBox_steps.TextChanged += new System.EventHandler(this.txtBox_steps_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Число шагов интегрирования:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBox_end);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBox_start);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 67);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Диапазон";
            // 
            // txtBox_end
            // 
            this.txtBox_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBox_end.Location = new System.Drawing.Point(186, 28);
            this.txtBox_end.Name = "txtBox_end";
            this.txtBox_end.Size = new System.Drawing.Size(87, 26);
            this.txtBox_end.TabIndex = 4;
            this.txtBox_end.TextChanged += new System.EventHandler(this.txtBox_end_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "До:";
            // 
            // txtBox_start
            // 
            this.txtBox_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBox_start.Location = new System.Drawing.Point(56, 28);
            this.txtBox_start.Name = "txtBox_start";
            this.txtBox_start.Size = new System.Drawing.Size(87, 26);
            this.txtBox_start.TabIndex = 2;
            this.txtBox_start.TextChanged += new System.EventHandler(this.txtBox_start_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "От:";
            // 
            // cB_mod
            // 
            this.cB_mod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cB_mod.FormattingEnabled = true;
            this.cB_mod.Items.AddRange(new object[] {
            "Вычислительный кластер",
            "Один узел"});
            this.cB_mod.Location = new System.Drawing.Point(133, 204);
            this.cB_mod.Name = "cB_mod";
            this.cB_mod.Size = new System.Drawing.Size(199, 24);
            this.cB_mod.TabIndex = 1;
            this.cB_mod.SelectedIndexChanged += new System.EventHandler(this.cB_mod_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(22, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Режим работы:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_time_all);
            this.groupBox2.Controls.Add(this.label_time_all_text);
            this.groupBox2.Controls.Add(this.label_res);
            this.groupBox2.Controls.Add(this.label_time);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(362, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 250);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Результаты";
            // 
            // label_time_all
            // 
            this.label_time_all.AutoSize = true;
            this.label_time_all.Location = new System.Drawing.Point(205, 93);
            this.label_time_all.Name = "label_time_all";
            this.label_time_all.Size = new System.Drawing.Size(0, 16);
            this.label_time_all.TabIndex = 12;
            // 
            // label_time_all_text
            // 
            this.label_time_all_text.AutoSize = true;
            this.label_time_all_text.Location = new System.Drawing.Point(16, 93);
            this.label_time_all_text.Name = "label_time_all_text";
            this.label_time_all_text.Size = new System.Drawing.Size(177, 16);
            this.label_time_all_text.TabIndex = 11;
            this.label_time_all_text.Text = "Время с распределением:";
            // 
            // label_res
            // 
            this.label_res.AutoSize = true;
            this.label_res.Location = new System.Drawing.Point(205, 32);
            this.label_res.Name = "label_res";
            this.label_res.Size = new System.Drawing.Size(0, 16);
            this.label_res.TabIndex = 10;
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(205, 62);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(0, 16);
            this.label_time.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Время выполнения:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Результат интегрирования:";
            // 
            // tabWorkerHost
            // 
            this.tabWorkerHost.Controls.Add(this.btn_start_worker);
            this.tabWorkerHost.Controls.Add(this.groupBox7);
            this.tabWorkerHost.Location = new System.Drawing.Point(4, 34);
            this.tabWorkerHost.Name = "tabWorkerHost";
            this.tabWorkerHost.Padding = new System.Windows.Forms.Padding(3);
            this.tabWorkerHost.Size = new System.Drawing.Size(718, 294);
            this.tabWorkerHost.TabIndex = 1;
            this.tabWorkerHost.Text = "Работник";
            this.tabWorkerHost.UseVisualStyleBackColor = true;
            // 
            // btn_start_worker
            // 
            this.btn_start_worker.Location = new System.Drawing.Point(302, 262);
            this.btn_start_worker.Name = "btn_start_worker";
            this.btn_start_worker.Size = new System.Drawing.Size(106, 27);
            this.btn_start_worker.TabIndex = 10;
            this.btn_start_worker.Text = "Начать работу узла";
            this.btn_start_worker.UseVisualStyleBackColor = true;
            this.btn_start_worker.Click += new System.EventHandler(this.btn_start_worker_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox_logs_worker);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox7.Location = new System.Drawing.Point(9, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(702, 250);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Логи";
            // 
            // textBox_logs_worker
            // 
            this.textBox_logs_worker.Location = new System.Drawing.Point(6, 21);
            this.textBox_logs_worker.Multiline = true;
            this.textBox_logs_worker.Name = "textBox_logs_worker";
            this.textBox_logs_worker.ReadOnly = true;
            this.textBox_logs_worker.Size = new System.Drawing.Size(690, 223);
            this.textBox_logs_worker.TabIndex = 0;
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Location = new System.Drawing.Point(12, 344);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(0, 13);
            this.label_ip.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 337);
            this.Controls.Add(this.label_ip);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Вычислительные системы: вычислительный кластер.                                До" +
    "выденко, Хнюнин. АСМ-20";
            this.tabControl.ResumeLayout(false);
            this.tabMainHost.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox_Function.ResumeLayout(false);
            this.groupBox_Function.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabWorkerHost.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMainHost;
        private System.Windows.Forms.TabPage tabWorkerHost;
        private System.Windows.Forms.GroupBox groupBox_Function;
        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cB_mod;
        private System.Windows.Forms.TextBox txtBox_steps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBox_end;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBox_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_start_mainHost;
        private System.Windows.Forms.Label label_res;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_start_worker;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox textBox_logs_worker;
        private System.Windows.Forms.Label label_time_all;
        private System.Windows.Forms.Label label_time_all_text;
        private System.Windows.Forms.Button btn_add_workers;
        private System.Windows.Forms.ComboBox txtBox_function;
    }
}

