using System;
using System.Linq;

namespace StorageMaster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StorageMaster storageMaster = new StorageMaster();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] splittedCommand = command.Split();
                try
                {
                    switch (splittedCommand[0])
                    {
                        case "AddProduct":
                            Console.WriteLine(storageMaster.AddProduct(splittedCommand[1],double.Parse(splittedCommand[2])));
                            break;
                        case "RegisterStorage":
                            Console.WriteLine(storageMaster.RegisterStorage(splittedCommand[1],splittedCommand[2]));
                            break;
                        case "SelectVehicle":
                            Console.WriteLine(storageMaster.SelectVehicle(splittedCommand[1], int.Parse(splittedCommand[2])));
                            break;
                        case "LoadVehicle":
                            Console.WriteLine(storageMaster.LoadVehicle(splittedCommand.Skip(1)));
                            break;
                        case "SendVehicleTo":
                            Console.WriteLine
                                (storageMaster
                                .SendVehicleTo(splittedCommand[1], int.Parse(splittedCommand[2]),splittedCommand[3])
                                );
                            break;
                        case "UnloadVehicle":
                            Console.WriteLine(storageMaster.UnloadVehicle(splittedCommand[1], int.Parse(splittedCommand[2])));
                            break;
                        case "GetStorageStatus":
                            Console.WriteLine(storageMaster.GetStorageStatus(splittedCommand[1]));
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            Console.WriteLine(storageMaster.GetSummary());
        }
    }
}
