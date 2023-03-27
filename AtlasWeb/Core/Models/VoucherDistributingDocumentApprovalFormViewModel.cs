namespace Core.Models
{
    public class VoucherDistributingDocumentApprovalFormViewModel
    {
        public TTObjectClasses.VoucherDistributingDocument _VoucherDistributingDocument
        {
            get;
            set;
        }

        public TTObjectClasses.VoucherDistributingDocumentMaterial[] StockActionOutDetailsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.StockCard[] StockCards
        {
            get;
            set;
        }

        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.StockLevelType[] StockLevelTypes
        {
            get;
            set;
        }

        public TTObjectClasses.Store[] Stores
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }
    }
}