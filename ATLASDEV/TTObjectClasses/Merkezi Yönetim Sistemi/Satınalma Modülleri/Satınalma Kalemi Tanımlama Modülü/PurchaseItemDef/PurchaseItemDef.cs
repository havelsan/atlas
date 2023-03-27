
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Satınalma Kalemi Tanımlama
    /// </summary>
    public  partial class PurchaseItemDef : TerminologyManagerDef
    {
        public partial class PIDefinitionFormNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetPurchaseItemDefs_Class : TTReportNqlObject 
        {
        }

        
                    
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "STOCKCARD":
                    {
                        StockCard value = (StockCard)newValue;
#region STOCKCARD_SetParentScript
                        if(value == null)
                return;
            
            if(value.DistributionType == null)
                return;
            
            TempDistributionType = value.DistributionType.DistributionType;
#endregion STOCKCARD_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

#region Methods
        public override string ToString()
        {
            return ItemName;
        }
        
        public double GetItemStocks(Store store)
        {
            double totalInheld = 0;
            foreach (Material m in StockCard.Materials.Select(""))
            {
                IList stockList = m.Stocks.Select("STORE = " + ConnectionManager.GuidToString(store.ObjectID));
                foreach (Stock stock in stockList)
                    totalInheld += (double)stock.Inheld;
            }
            return totalInheld;
        }


        public double GetItemConsumption(DateTime startDate, DateTime endDate)
        {
            double totalConsumption = 0;
            Material m = null;

            foreach (Material material in StockCard.Materials)
            {
            }

            return totalConsumption;
        }

        public string GetNSN()
        {
            string nsn = null;
            if(StockCard != null)
                return StockCard.NATOStockNO;
            else
                return string.Empty;
        }

        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.PurchaseItemDefinitionInfo;
        }
        
#endregion Methods

    }
}