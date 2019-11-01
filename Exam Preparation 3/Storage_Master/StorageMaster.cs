using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster
{
    public class StorageMaster
    {
        public StorageMaster()
        {
            this.productsGpus = new List<Product>();
            this.productsHardDrives = new List<Product>();
            this.productsRams = new List<Product>();
            this.productsSolidStateDrivers = new List<Product>();
            this.storages = new List<Storage>();
            this.vehicle = null;
        }

        private Vehicle vehicle;
        private List<Product> productsGpus;
        private List<Product> productsHardDrives;
        private List<Product> productsRams;
        private List<Product> productsSolidStateDrivers;
        private List<Storage> storages;

        public string AddProduct(string type, double price)
        {
            switch (type)
            {
                case "Gpu":
                    this.productsGpus.Add(new Gpu(price));
                    break;
                case "HardDrive":
                    this.productsHardDrives.Add(new HardDrive(price));
                    break;
                case "Ram":
                    this.productsRams.Add(new Ram(price));
                    break;
                case "SolidStateDrive":
                    this.productsSolidStateDrivers.Add(new SolidStateDrive(price));
                    break;
                default:
                    throw new InvalidOperationException("Invalid product type!");
            }

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            switch (type)
            {
                case "AutomatedWarehouse":
                    this.storages.Add(new AutomatedWarehouse(name));
                    break;
                case "DistributionCenter":
                    this.storages.Add(new DistributionCenter(name));
                    break;
                case "Warehouse":
                    this.storages.Add(new Warehouse(name));
                    break;
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            this.vehicle = this.storages.Single(x => x.Name == storageName).GetVehicle(garageSlot);
            return $"Selected {this.vehicle.GetType().Name}"; // CHECK LATER !!!
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsNumber = 0;
            foreach (var productType in productNames)
            {
                if (this.vehicle.IsFull)
                {
                    break;
                }
                switch (productType)
                {
                    case "Gpu":
                        if (this.productsGpus.Count == 0)
                        {
                            throw new InvalidOperationException($"{productType} is out of stock!");
                        }
                        this.vehicle.LoadProduct(this.productsGpus.Last());
                        this.productsGpus.RemoveAt(this.productsGpus.Count - 1);
                        loadedProductsNumber++;
                        break;
                    case "HardDrive":
                        if (this.productsHardDrives.Count == 0)
                        {
                            throw new InvalidOperationException($"{productType} is out of stock!");
                        }
                        this.vehicle.LoadProduct(this.productsHardDrives.Last());
                        this.productsHardDrives.RemoveAt(this.productsHardDrives.Count - 1);
                        loadedProductsNumber++;
                        break;
                    case "Ram":
                        if (this.productsRams.Count == 0)
                        {
                            throw new InvalidOperationException($"{productType} is out of stock!");
                        }
                        this.vehicle.LoadProduct(this.productsRams.Last());
                        this.productsRams.RemoveAt(this.productsRams.Count - 1);
                        loadedProductsNumber++;
                        break;
                    case "SolidStateDrive":
                        if (this.productsSolidStateDrivers.Count == 0)
                        {
                            throw new InvalidOperationException($"{productType} is out of stock!");
                        }
                        this.vehicle.LoadProduct(this.productsSolidStateDrivers.Last());
                        this.productsSolidStateDrivers.RemoveAt(this.productsSolidStateDrivers.Count - 1);
                        loadedProductsNumber++;
                        break;
                }
            }

            return $"Loaded {loadedProductsNumber}/{productNames.Count()} products into {this.vehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var sourceStorage = this.storages.SingleOrDefault(st => st.Name == sourceName);
            var destinationStorage = this.storages.SingleOrDefault(st => st.Name == destinationName);
            if (sourceStorage == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            if (destinationStorage == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }
            string typeOfVehicle = sourceStorage.GetVehicle(sourceGarageSlot).GetType().Name;
            int destinationGarageSlot = sourceStorage
                .SendVehicleTo(sourceGarageSlot, this.storages.Single(st => st.Name == destinationName));
            return $"Sent {typeOfVehicle} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var sourceStorage = this.storages.Single(st => st.Name == storageName);
            int productsInVehicle = sourceStorage.GetVehicle(garageSlot).Trunk.Count;
            int unloadedProductsCount = sourceStorage.UnloadVehicle(garageSlot);
            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
            //CHECH AGAIN WHICH PRODUCTSINTVEHICLE
        }

        public string GetStorageStatus(string storageName)
        {
            return this.storages.Single(st => st.Name == storageName).ToString();
        }

        public string GetSummary()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var storage in this.storages.OrderByDescending(st => st.Products.Sum(pr => pr.Price)))
            {
                stringBuilder.AppendLine($"{storage.Name}:");
                stringBuilder.AppendLine($"Storage worth: ${storage.Products.Sum(pr => pr.Price):f2}");
            }
            return stringBuilder.ToString().Trim();
        }

    }
}
