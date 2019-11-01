using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storage
{
    class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(string name)
            : base(name, 1, 2, new Vehicle[] { new Truck()})
        {
        }
    }
}
