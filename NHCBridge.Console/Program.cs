using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NHCBridge.TCP.Commands;

namespace NHCBridge.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient theClient = new TcpClient();
            Task connectClientTask = theClient.ConnectAsync("192.168.2.51", 8000);
            connectClientTask.Wait();

            NetworkStream theStream = theClient.GetStream();

            NHCSwitchLightCommand command = new NHCSwitchLightCommand() 
                                                    {
                                                            Id = 15
                                                        ,   Value1 = "100"
                                                        ,   Command = "executeactions"
                                                    };

            JsonSerializerSettings settings = new JsonSerializerSettings()
                                                    {
                                                        ContractResolver =  new JsonLowercaseContractResolver()
                                                    };

            string json = JsonConvert.SerializeObject(command, settings);
            var bytesToSend = Encoding.ASCII.GetBytes(json);
            
            //var bytesToSend = Encoding.ASCII.GetBytes("{\"cmd\":\"listactions\"}");
            
            theStream.Write(bytesToSend, 0, bytesToSend.Length);
            theStream.Flush();

            theClient.Close();
        }
    }
}
