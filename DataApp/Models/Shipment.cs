using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public class Shipment
    {
        public long Id { get; set; }
        public string ShipperName { get; set; }
        public string StartCity { get; set; }
        public string EndCity { get; set; }

        public IEnumerable<ProductShipmentJunction> ProductShipments { get; set; }
    }
}
