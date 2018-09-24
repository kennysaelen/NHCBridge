using NHCBridge.NHCCommands;

namespace NHCBridge.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.runSwitchCommand("executeactions", 16, "0");
            Program.runSwitchCommand("executeactions", 15, "0");
            System.Threading.Thread.Sleep(1500);
            Program.runSwitchCommand("executeactions", 16, "100");
            System.Threading.Thread.Sleep(2000);
            Program.runSwitchCommand("executeactions", 15, "100");
            Program.runListActionsCommand();
        }

        public static void runSwitchCommand(string command, int id, string value1)
        {
            Program.runCommand(new NHCSwitchLightCommand() 
                                        {
                                                Id = id
                                            ,   Value1 = value1
                                            ,   Command = command
                                        });
        }

        public static void runListActionsCommand()
        {
            Program.runCommand(new NHCSwitchLightCommand() 
                                        {
                                            Command = "listactions"
                                        });
        }

        public static void runCommand(INHCCommand command)
        {
            INHCCommandRunner runner =  new NHCCommandRunner() 
                                        {
                                            Command = command
                                        };

            runner.execute();

            if(command.CommandResult != null)
            {
                System.Console.WriteLine(System.String.Format("The command executed with the following result : \n\r {0}",command.CommandResult));
            }
            else
            {
                System.Console.WriteLine("The command executed with no returning result message");
            }
        }
    }
}
