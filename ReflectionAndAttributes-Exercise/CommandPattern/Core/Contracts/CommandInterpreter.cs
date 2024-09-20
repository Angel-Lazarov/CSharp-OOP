using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Contracts
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandArguments = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = commandArguments[0];

            Type commandType = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(c => c.Name == $"{commandName}Command");

            if( commandType == null ) 
            {
                throw new ArgumentException("Unknown command");
            }

            ICommand commandInstance = Activator.CreateInstance(commandType) as ICommand;

            string result = commandInstance.Execute(commandArguments.Skip(1).ToArray());

            return result;
        }
    }
}
