using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPatternExample.Commands;

namespace CommandPatternExample
{
    public class Program2
    {
        public static void Run(string[] args)
        {
            var availableCommands = GetAvailableCommands();

            if (args.Length == 0)
            {
                PrintUsage(availableCommands);
                return;
            }

            var parser = new CommandParser(availableCommands);
            var command = parser.ParseCommand(args);

            if (command != null)
            {
                command.Execute();
            }
        }

        private static IEnumerable<ICommandFactory> GetAvailableCommands()
        {
            return new ICommandFactory[]
                {
                    new CreateOrderCommand(),
                    new UpdateQuantityCommand(),
                    new ShipOrderCommand()
                };
        }

        private static void PrintUsage(IEnumerable<ICommandFactory> availableCommands)
        {
            Console.WriteLine("Usage: LoggingDemo CommandName Arguments");
            Console.WriteLine("Commands:");
            foreach (var command in availableCommands)
            {
                Console.WriteLine("  {0}",command.Description);
            }
        }
    }

    public class CommandParser
    {
        private IEnumerable<ICommandFactory> availableCommands;

        public CommandParser(IEnumerable<ICommandFactory> availableCommands)
        {
            this.availableCommands = availableCommands;
        }

        public ICommand ParseCommand(string[] args)
        {
            var requestedCommandName = args[0];

            var command = FindRequestedCommand(requestedCommandName);

            if (command == null)
            {
                return new NotFoundCommand {Name = requestedCommandName};
            }

            return command.MakeCommand(args);
        }

        private ICommandFactory FindRequestedCommand(string requestedCommandName)
        {
            return availableCommands
                .FirstOrDefault(cmd => cmd.CommandName == requestedCommandName);
        }
    }

    public class NotFoundCommand : ICommand
    {
        public string Name { get; set; }

        public void Execute()
        {
            Console.WriteLine("Couldn't find command: "+Name);
        }
    }
}
