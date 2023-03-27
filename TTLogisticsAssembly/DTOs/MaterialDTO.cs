using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTDataDictionary;

namespace TTObjectClasses.DTOs
{
    public class MaterialDTO
    {
        public Guid ObjectID { get; set; }
        public Guid MaterialID { get; set; }
        public string Name { get; set; }
        public string NATOStockNO { get; set; }
        public string Barcode { get; set; }
        public string DistributionTypeName { get; set; }
        public decimal? Amount { get; set; }
        public decimal? UnitPriceWithOutVat { get; set; }
        public decimal VatRate { get; set; }
        public decimal? UnitPriceWithInVat { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? Price { get; set; }
        public string LotNo { get; set; }
        public string ReceiveNotificationID { get; set; }
        public string SerialNo { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? RetrievalYear { get; set; }
        public DateTime? ProductionDate { get; set; }
        public decimal? NotDiscountedUnitPrice { get; set; }
        public Guid? MaterialSupplierId { get; set; }
        public string MaterialSupplier { get; set; }
        public Guid? MaterialSupplierNumber { get; set; }
    }

}
