using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Storage
{
    class DistributionCenter : Storage
    {
        public DistributionCenter(string name)
            : base(name, 2, 5, new Vehicle[] { new Van(), new Van(), new Van() })
        {
        }
    }
}
