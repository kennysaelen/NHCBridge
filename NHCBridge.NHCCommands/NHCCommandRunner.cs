using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NHCBridge.NHCCommands
{
    public class NHCCommandRunner : INHCCommandRunner
    {
        public INHCCommand Command { get; set; }

        public void execute()
        {
            StringBuilder myCompleteMessage = new StringBuilder();

            JsonSerializerSettings settings = new JsonSerializerSettings()
                                                    {
                                                        ContractResolver =  new JsonLowercaseContractResolver()
                                                    };

            string json = JsonConvert.SerializeObject(Command, settings);
            var bytesToSend = Encoding.ASCII.GetBytes(json);
            
            using (TcpClient theClient = new TcpClient())
            {
                theClient.ConnectAsync("192.168.2.51", 8000).Wait();
                
                using(NetworkStream theStream = theClient.GetStream())
                {
                    // Write the JSON command to the NHC IP interface
                    theStream.Write(bytesToSend, 0, bytesToSend.Length);

                    // Receive the response from the NHC IP interface
                    int numberOfBytesRead = 0;
                    byte[] myReadBuffer = new byte[1024];
                    
                    do
                    {
                        numberOfBytesRead = theStream.Read(myReadBuffer, 0, myReadBuffer.Length);
                        myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
                    }
                    while (theStream.DataAvailable);

                    theStream.Flush();
                }

                theClient.Close();
            }

            // Store the incoming JSON as a response in the command
            Command.CommandResult = myCompleteMessage.ToString();
        }
    }
}