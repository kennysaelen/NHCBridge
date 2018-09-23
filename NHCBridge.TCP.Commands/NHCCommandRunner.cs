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
            TcpClient theClient = new TcpClient();
            theClient.ConnectAsync("192.168.2.51", 8000).Wait();
            NetworkStream theStream = theClient.GetStream();

            JsonSerializerSettings settings = new JsonSerializerSettings()
                                                    {
                                                        ContractResolver =  new JsonLowercaseContractResolver()
                                                    };

            string json = JsonConvert.SerializeObject(Command, settings);
            var bytesToSend = Encoding.ASCII.GetBytes(json);
            
            //var bytesToSend = Encoding.ASCII.GetBytes("{\"cmd\":\"listactions\"}");
            
            theStream.Write(bytesToSend, 0, bytesToSend.Length);
            theStream.Flush();

            theClient.Close();
        }
    }
}