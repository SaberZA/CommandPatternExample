namespace CommandPatternExample.Commands
{
    internal class CreateOrderCommand : ICommand, ICommandFactory
    {
        public string CommandName { get { return "CreateOrder"; } }
        public string Description { get; private set; }
        public ICommand MakeCommand(string[] arguments)
        {
            throw new System.NotImplementedException();
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}