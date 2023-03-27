using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using System.ComponentModel;
using TTObjectClasses;
using Infrastructure.Filters;
using Core.Security;
using TTInstanceManagement;
using TTUtils;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class DrugPaymetFirmServiceController : Controller
    {
        [HttpPost]
        public List<DrugPaymentFirmList> GetDrugPaymentFirm(DrugPaymentInputDTO inputDTO)
        {
            int suppilerFlag = 0;
            int materialFlag = 0;
            string supplierObj = string.Empty;
            List<string> materialObjectID = new List<string>();
            List<DrugPaymentFirmList> returnList = new List<DrugPaymentFirmList>();
            if (inputDTO.SupplierObjectID != Guid.Empty)
            {
                suppilerFlag = 1;
                supplierObj = inputDTO.SupplierObjectID.ToString();
            }

            if (inputDTO.Materials.Count > 0)
            {
                materialFlag = 1;
                foreach (Material material in inputDTO.Materials)
                {
                    materialObjectID.Add(material.ObjectID.ToString());
                }
            }

            BindingList<ChattelDocumentWithPurchase.DrugPaymentFirmReportQuery_Class> drugPaymentFirmlist =
            ChattelDocumentWithPurchase.DrugPaymentFirmReportQuery(inputDTO.EndDate, inputDTO.StartDate, suppilerFlag, materialFlag, supplierObj, materialObjectID);

            foreach (ChattelDocumentWithPurchase.DrugPaymentFirmReportQuery_Class item in drugPaymentFirmlist)
            {
                DrugPaymentFirmList drugPaymentFirm = new DrugPaymentFirmList();
                drugPaymentFirm.Amount = item.Amount.ToString();
                drugPaymentFirm.Barcode = item.Barcode;
                drugPaymentFirm.Materialname = item.Materialname;
                drugPaymentFirm.Stockactionid = item.StockActionID.ToString();
                drugPaymentFirm.Suppliername = item.Suppliername;
                drugPaymentFirm.Transactiondate = item.TransactionDate.Value;
                returnList.Add(drugPaymentFirm);
            }

            return returnList;
        }
    }

}

namespace Core.Models
{
    public class DrugPaymentInputDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Material> Materials { get; set; }
        public Guid SupplierObjectID { get; set; }
    }

    public class DrugPaymentFirmList
    {
        public string Materialname { get; set; }
        public string Barcode { get; set; }
        public string Amount { get; set; }
        public DateTime Transactiondate { get; set; }
        public string Stockactionid { get; set; }
        public string Suppliername { get; set; }
    }
}
