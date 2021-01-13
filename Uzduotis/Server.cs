using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml;
using System.ComponentModel;

namespace Uzduotis
{
    public static class Server
    {
        /// <summary>
        /// Starts client server and opens a network stream for comunication
        /// </summary>
        public static void Start()
        {
            TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 1302);
            listener.Start();
            while (true)
            {

                TcpClient client = listener.AcceptTcpClient(); //client conncetion


                NetworkStream stream = client.GetStream();

                StreamReader sr = new StreamReader(client.GetStream()); //used to read stream input
                StreamWriter sw = new StreamWriter(client.GetStream()); //used to write into stream
                

                try
                {
                    byte[] buffer = new byte[1024];
                    stream.Read(buffer, 0, buffer.Length);
                    int recv = 0;


                    foreach (byte b in buffer)
                    {
                        if (b != 0)
                        {
                            recv++; //calculating number of read bytes
                        }
                    }

                    string request = Encoding.UTF8.GetString(buffer, 0, recv);

                    string[] parts = request.Split(';');

                    //Generation or usage
                    switch (parts[0])
                    {
                        case "Generate":
                            

                            byte Lenght = Convert.ToByte(parts[1]);
                            ushort Count = Convert.ToUInt16(parts[2]);

                            //Tries to generate codes and returns boolean value based on status
                            if (ServerOperations.GenerateCodes(Lenght, Count))
                            {
                                sw.WriteLine("Generate;Codes generated");
                            }
                            else
                                sw.WriteLine("Generate;Code generation failed");



                            break;

                        case "UseCode":
                           
                            string Code = parts[1];

                            //Tries to use the code and returns a single byte based on status
                            switch (ServerOperations.UseCode(Code))
                            {
                                case 0:
                                    sw.WriteLine("UseCode;Code used succesfully.");
                                    break;
                                case 1:
                                    sw.WriteLine("UseCode;Code has already been used.");
                                    break;
                                case 2:
                                    sw.WriteLine("UseCode;Code not found.");
                                    break;
                                case 3:
                                    sw.WriteLine("UseCode;Generate the codes first!");
                                    break;
                            }

                            break;
                    }

                    sw.Flush();
                }
                catch (Exception ex)
                {
                    
                }

            }
        }

        

    }
}
