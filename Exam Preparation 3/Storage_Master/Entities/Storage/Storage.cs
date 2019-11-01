using StorageMaster.Entities.Vehicles;
using System.Linq;
using System.Collections.Generic;
using System;
using StorageMaster.Entities.Products;

namespace StorageMaster.Entities.Storage
{
    abstract class Storage
    {
        private Vehicle[] garage;
        private List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new Vehicle[this.GarageSlots];
            int i = 0;
            foreach (var vehicle in vehicles) // REFACTOR LATER !!!
            {
                this.garage[i] = vehicle;
                i++;
            }
            this.products = new List<Product>();

        }

        public string Name { get; }

        public int Capacity { get; }

        public int GarageSlots { get; }

        public bool IsFull => this.products.Sum(pr => pr.Weight) >= this.Capacity; // ACESS MODIF!!!

        public IReadOnlyCollection<Vehicle> Garage // CHECK FOR STRUCTURE !!!
        {
            get { return Array.AsReadOnly(this.garage); }
        }

        public IReadOnlyCollection<Product> Products // CHECK FOR STRUCTURE !!!
        {
            get { return this.products.AsReadOnly(); }
        }

        private bool IsTherePlaceInGarage => this.garage.Any(vehicle => vehicle == null);

        private int GetFirstFreeSlotIndex()
        {
            for (int i = 0; i < this.garage.Count(); i++)
            {
                if (this.garage[i] == null)
                {
                    return i;
                }
            }
            throw new ArgumentException("ERRORINCODEDANI!!!");
        }

        public Vehicle GetVehicle(int garageSlot) // CHECK FOR ACESS MODIFYER !!!
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }
            return this.garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicleToBeSended = this.GetVehicle(garageSlot);
            if (deliveryLocation.IsTherePlaceInGarage == false)
            {
                throw new InvalidOperationException("No room in garage!");
            }
            this.garage[garageSlot] = null;
            int freeGarageSlotIndex = deliveryLocation.GetFirstFreeSlotIndex();
            deliveryLocation.garage[freeGarageSlotIndex] = vehicleToBeSended;
            return freeGarageSlotIndex;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }
            Vehicle vehicleToBeUnloaded = this.GetVehicle(garageSlot);
            int numberOfUnloadedProducts = 0;
            while (vehicleToBeUnloaded.Trunk.Count != 0)
            {
                Product product = vehicleToBeUnloaded.Unload();
                if (this.IsFull)
                {
                    vehicleToBeUnloaded.LoadProduct(product);
                    break;
                }

                this.products.Add(product);
                numberOfUnloadedProducts++;
            }
            return numberOfUnloadedProducts;
        }

        public override string ToString()
        {
            Dictionary<string, List<Product>> groupedProductsByType = new Dictionary<string, List<Product>>();
            foreach (var product in this.products)
            {
                if (groupedProductsByType.ContainsKey(product.GetType().Name) == false)
                {
                    groupedProductsByType.Add(product.GetType().Name, new List<Product>());
                }
                groupedProductsByType[product.GetType().Name].Add(product);
            }
            groupedProductsByType = groupedProductsByType.OrderByDescending(kvp => kvp.Value.Count).ThenBy(kvp => kvp.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            List<string> productTypesInfo = new List<string>();

            foreach (KeyValuePair<string, List<Product>> kvp in groupedProductsByType)
            {
                productTypesInfo.Add($"{kvp.Key} ({kvp.Value.Count})");
            }

            string firstLine =
                $"Stock ({this.products.Sum(pr => pr.Weight)}/{this.Capacity}): [{string.Join(", ", productTypesInfo)}]";

            List<string> listOfGarageOutput = new List<string>();
            foreach (var vehicle in this.garage)
            {
                if (vehicle == null) //CHECK LATER !!!
                {
                    listOfGarageOutput.Add("empty");
                }
                else
                {
                    listOfGarageOutput.Add(vehicle.GetType().Name);
                }
            }
            string secondLine = $"Garage: [{string.Join("|", listOfGarageOutput)}]";

            return firstLine + Environment.NewLine + secondLine;
        }
    }
}

