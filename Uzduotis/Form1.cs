using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Xml;

namespace Uzduotis
{
    public partial class Form1 : Form
    {
        private const String filename = "Codes.xml";
        public Form1()
        {
            InitializeComponent();
            comboBox_CodeLength.SelectedIndex = 0;
            DisableControls();
        }

        /// <summary>
        /// Launches and closes the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Server_Connection_Click(object sender, EventArgs e)
        {
            switch (button_Server_Connection.Text)
            {
                case "Connect Server":
                    button_Server_Connection.Text = "Disconnect Server";
                    serverThread = new BackgroundWorker();
                    serverThread.DoWork += serverThread_DoWork;
                    serverThread.RunWorkerAsync();
                    EnableControls();
                    break;

                case "Disconnect Server":
                    button_Server_Connection.Text = "Connect Server";
                    serverThread.Dispose();
                    serverThread = null;
                    DisableControls();
                    break;
            }
        }

        private void EnableControls()
        {
            button_Generate.Enabled = true;
            button_UseCode.Enabled = true;
        }

        private void DisableControls()
        {
            listView_Codes.Items.Clear();
            button_Generate.Enabled = false;
            button_UseCode.Enabled = false;
        }


        /// <summary>
        /// Connects to the server and prepares for comms
        /// </summary>
        /// <param name="messageToSend"></param>
        private void TcpConnection(string messageToSend)
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 1302);
                
                int byteCount = Encoding.ASCII.GetByteCount(messageToSend + 1);

                byte[] sendData = new byte[byteCount];
                sendData = Encoding.ASCII.GetBytes(messageToSend);

                NetworkStream stream = client.GetStream();
                stream.Write(sendData, 0, sendData.Length); 


                
                StreamReader sr = new StreamReader(stream); //used to receive answerrs from stream
                string response = sr.ReadLine();

                response = response.Remove(0, response.IndexOf(';')+1);


                //fill the listview with codes
                if(response.Equals("Codes generated"))
                {
                    listView_Codes.Items.Clear();
                    Task fill = Task.Factory.StartNew(() => doStuff());
                    fill.Start();
                    Task.WaitAll(fill);
                }

                

                label_Log.Text = "Log: " + response;

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                
            }
        }

        /// <summary>
        /// Fills listView control with codes
        /// </summary>
        private void doStuff()
        {
            
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            List<ListViewItem> temp = new List<ListViewItem>();
            
            foreach (XmlNode node in doc.LastChild.ChildNodes)
            {
                temp.Add(new ListViewItem(node.InnerText));   
            }


            this.BeginInvoke(new MethodInvoker(delegate
            {
                listView_Codes.Items.AddRange(temp.ToArray());
            }));
            
        }


        /// <summary>
        /// Starts the server thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serverThread_DoWork(object sender, DoWorkEventArgs e)
        {
            Server.Start();
        }


        /// <summary>
        /// Generate request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Generate_Click(object sender, EventArgs e)
        {
            int count = int.Parse(textBox_Count.Text);
            if (count >= 1000 && count <= 2000)
            {
                TcpConnection("Generate;" + comboBox_CodeLength.Text + ";" + 1000);
            }
            else
                MessageBox.Show("Entered count value is wrong!");
            
            
        }

        /// <summary>
        /// UseCode request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_UseCode_Click(object sender, EventArgs e)
        {
            TcpConnection("UseCode;" + textBox_UseCode.Text);
        }

        private void serverThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
            {
                DisableControls();
            }
        }
    }
}
