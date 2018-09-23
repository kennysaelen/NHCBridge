using NHCBridge.NHCCommands;

namespace NHCBridge.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            INHCCommand command =   new NHCSwitchLightCommand() 
                                    {
                                            Id = 15
                                        ,   Value1 = "100"
                                        ,   Command = "executeactions"
                                    };

            INHCCommandRunner runner =  new NHCCommandRunner() 
                                        {
                                            Command = command
                                        };

            runner.execute();
        }
    }
}
