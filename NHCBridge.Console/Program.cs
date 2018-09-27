using NHCBridge.NHCCommands;

namespace NHCBridge.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.runStartEventsCommand();
            Program.runSwitchCommand(16, "0");
            Program.runSwitchCommand(15, "0");
            System.Threading.Thread.Sleep(1500);
            Program.runSwitchCommand(16, "100");
            System.Threading.Thread.Sleep(2000);
            Program.runSwitchCommand(15, "100");
            Program.runListActionsCommand();
            Program.runListLocationsCommand();
            Program.runSystemInfoCommand();
        }

        public static void runSwitchCommand(int id, string value1)
        {
            Program.runCommand(new NHCSwitchLightCommand() 
                                        {
                                                Id = id
                                            ,   Value1 = value1
                                        });
        }

        public static void runListActionsCommand()
        {
            Program.runCommand(new NHCListActionsCommand());
        }

        public static void runStartEventsCommand()
        {
            Program.runCommand(new NHCStartEventsCommand());
        }

        public static void runListLocationsCommand()
        {
            Program.runCommand(new NHCListLocationsCommand());
        }

        public static void runSystemInfoCommand()
        {
            Program.runCommand(new NHCSystemInfoCommand());
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
