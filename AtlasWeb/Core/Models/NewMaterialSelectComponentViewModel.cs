using System;
using System.Collections.Generic;
using TTDataDictionary;
using TTObjectClasses;

namespace Core.Models
{
    public class NewMaterialSelectComponentViewModel
    {

    }

    public class NewMaterialSelectDTO
    {
        public Material Material { get; set; }
        public StockCard StockCard { get; set; }
        public StockLevelType StockLevelType { get; set; }
        public Currency StoreStock { get; set; }
        public Currency DestinationStoreStock { get; set; }
        public Currency DestinationStoreMaxLevel { get; set; }
        public double? VatRate { get; set; }
    }

    [Serializable]
    public class MaterialSelectorInput
    {
        public MKYS_EMalzemeGrupEnum? MaterialGroup { get; set; }
        public DateTime? TicketDate { get; set; }
        public TransactionTypeEnum? TransactionType { get; set; }
        public Guid? StoreID { get; set; }
    }
}