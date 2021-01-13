namespace Uzduotis
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Generate = new System.Windows.Forms.Button();
            this.comboBox_CodeLength = new System.Windows.Forms.ComboBox();
            this.listView_Codes = new System.Windows.Forms.ListView();
            this.textBox_UseCode = new System.Windows.Forms.TextBox();
            this.button_UseCode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Server_Connection = new System.Windows.Forms.Button();
            this.serverThread = new System.ComponentModel.BackgroundWorker();
            this.textBox_Count = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_Log = new System.Windows.Forms.Label();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // button_Generate
            // 
            this.button_Generate.Location = new System.Drawing.Point(437, 66);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Size = new System.Drawing.Size(122, 21);
            this.button_Generate.TabIndex = 1;
            this.button_Generate.Text = "Generate";
            this.button_Generate.UseVisualStyleBackColor = true;
            this.button_Generate.Click += new System.EventHandler(this.button_Generate_Click);
            // 
            // comboBox_CodeLength
            // 
            this.comboBox_CodeLength.FormattingEnabled = true;
            this.comboBox_CodeLength.Items.AddRange(new object[] {
            "7",
            "8"});
            this.comboBox_CodeLength.Location = new System.Drawing.Point(347, 66);
            this.comboBox_CodeLength.Name = "comboBox_CodeLength";
            this.comboBox_CodeLength.Size = new System.Drawing.Size(84, 21);
            this.comboBox_CodeLength.TabIndex = 2;
            // 
            // listView_Codes
            // 
            this.listView_Codes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listView_Codes.HideSelection = false;
            this.listView_Codes.Location = new System.Drawing.Point(218, 91);
            this.listView_Codes.Name = "listView_Codes";
            this.listView_Codes.Size = new System.Drawing.Size(362, 97);
            this.listView_Codes.TabIndex = 3;
            this.listView_Codes.UseCompatibleStateImageBehavior = false;
            this.listView_Codes.View = System.Windows.Forms.View.Details;
            // 
            // textBox_UseCode
            // 
            this.textBox_UseCode.Location = new System.Drawing.Point(257, 204);
            this.textBox_UseCode.Name = "textBox_UseCode";
            this.textBox_UseCode.Size = new System.Drawing.Size(174, 20);
            this.textBox_UseCode.TabIndex = 4;
            // 
            // button_UseCode
            // 
            this.button_UseCode.Location = new System.Drawing.Point(437, 204);
            this.button_UseCode.Name = "button_UseCode";
            this.button_UseCode.Size = new System.Drawing.Size(122, 20);
            this.button_UseCode.TabIndex = 5;
            this.button_UseCode.Text = "Use Code";
            this.button_UseCode.UseVisualStyleBackColor = true;
            this.button_UseCode.Click += new System.EventHandler(this.button_UseCode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Length";
            // 
            // button_Server_Connection
            // 
            this.button_Server_Connection.Location = new System.Drawing.Point(290, 12);
            this.button_Server_Connection.Name = "button_Server_Connection";
            this.button_Server_Connection.Size = new System.Drawing.Size(233, 21);
            this.button_Server_Connection.TabIndex = 7;
            this.button_Server_Connection.Text = "Connect Server";
            this.button_Server_Connection.UseVisualStyleBackColor = true;
            this.button_Server_Connection.Click += new System.EventHandler(this.button_Server_Connection_Click);
            // 
            // serverThread
            // 
            this.serverThread.WorkerSupportsCancellation = true;
            this.serverThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.serverThread_DoWork);
            this.serverThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.serverThread_RunWorkerCompleted);
            // 
            // textBox_Count
            // 
            this.textBox_Count.Location = new System.Drawing.Point(257, 67);
            this.textBox_Count.Name = "textBox_Count";
            this.textBox_Count.Size = new System.Drawing.Size(84, 20);
            this.textBox_Count.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Count";
            // 
            // label_Log
            // 
            this.label_Log.AutoSize = true;
            this.label_Log.Location = new System.Drawing.Point(313, 238);
            this.label_Log.Name = "label_Log";
            this.label_Log.Size = new System.Drawing.Size(28, 13);
            this.label_Log.TabIndex = 10;
            this.label_Log.Text = "Log:";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Code";
            this.columnHeader2.Width = 298;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 301);
            this.Controls.Add(this.label_Log);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Count);
            this.Controls.Add(this.button_Server_Connection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_UseCode);
            this.Controls.Add(this.textBox_UseCode);
            this.Controls.Add(this.listView_Codes);
            this.Controls.Add(this.comboBox_CodeLength);
            this.Controls.Add(this.button_Generate);
            this.Name = "Form1";
            this.Text = "Akcijos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Generate;
        private System.Windows.Forms.ComboBox comboBox_CodeLength;
        private System.Windows.Forms.ListView listView_Codes;
        private System.Windows.Forms.TextBox textBox_UseCode;
        private System.Windows.Forms.Button button_UseCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Server_Connection;
        private System.ComponentModel.BackgroundWorker serverThread;
        private System.Windows.Forms.TextBox textBox_Count;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_Log;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

