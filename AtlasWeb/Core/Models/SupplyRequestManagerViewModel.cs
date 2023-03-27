using System;
using System.Collections.Generic;
using TTDataDictionary;

namespace Core.Models
{
    public class SupplyRequestManagerViewModel
    {
        public List<SupplyRequestStatus> SupplyRequestStatusList { get; set; }
        public List<SupplyRequestStatusFastSoft> SupplyRequestStatusFastSoftList { get; set; }
    }

    public class SupplyRequestStatus
    {
        public string stockActionID { get; set; }
        public DateTime stockActionDate { get; set; }
        public bool isImmediate { get; set; }
        public string requestedUser { get; set; }
        public string description { get; set; }
        public string XXXXXXKayitId { get; set; }
        public List<IslemSonuc> islemSonucs { get; set; }
    }

    public class IslemSonuc {
        public int etkilenenAdetField { get; set; }
        public bool islemBasariliField { get; set; }
        public string mesajField { get; set; }
        public int kayitIDField { get; set; }
        public int tabloPkIdField { get; set; }
    }

    public class SupplyRequestStatusFastSoft
    {
        public string InvoiceNumber { get; set; }
        public DateTime ActionDate { get; set; }
        public string SupplierName { get; set; }
        public int ItemCount { get; set; }
        public List<SupplyRequestStatusFastSoftItemInfo> ItemInfos { get; set; }
        public string Status { get; set; }
    }


    public class SupplyRequestStatusFastSoftItemInfo
    {
        public string MaterialName { get; set; }
        public string Barcode { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
    }
}
