//$90F91828
namespace Core.Models
{
    public class BaseVoucherDistributingDocumentFormViewModel
    {
        public TTObjectClasses.VoucherDistributingDocument _VoucherDistributingDocument
        {
            get;
            set;
        }

        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList
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