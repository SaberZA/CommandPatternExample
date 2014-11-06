using System;

namespace CommandPatternExample
{
    class CommandExecutor
    {
        public void ExecuteCommand(string[] args)
        {
            switch (args[0])
            {
                case "UpdateQuantity":
                    UpdateQuantity(int.Parse(args[1]));
                    break;
                case "CreateOrder":
                    CreateOrder();
                    break;
                case "ShipOrder":
                    ShipOrder();
                    break;
                default:
                    Console.WriteLine("Unrecognised command");
                    break;
            }
        }

        private void ShipOrder()
        {
            
        }

        private void CreateOrder()
        {
            
        }

        private void UpdateQuantity(int newQuantity)
        {
            //simulate updating db
            int oldQuantity = 5;
            Console.WriteLine("Database: Updated");

            //simulate logging
            Console.WriteLine("LOG: Updated order quantity from {0} to {1}",oldQuantity,newQuantity);
        }
    }
}