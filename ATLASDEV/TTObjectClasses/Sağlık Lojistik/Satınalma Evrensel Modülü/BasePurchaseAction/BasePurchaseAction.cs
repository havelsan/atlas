
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
    /// Tüm Tedarik Modüllerinin Ana Sınıflarının Temelidir.
    /// </summary>
    public  abstract  partial class BasePurchaseAction : BaseAction
    {
#region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
        }

        public List<BasePurchaseAction.AccountancyInheldInfo> SendAmountRequestToAllSitesForPurchaseItem(PurchaseItemDef purchaseItemDef)
        {
            List<BasePurchaseAction.AccountancyInheldInfo> retValue = new List<BasePurchaseAction.AccountancyInheldInfo>();
            //            foreach (Sites site in Sites.AllActiveSites.Values)
            //            {
            //                AccountancyInheldInfo accountancyInheldInfo = PurchaseItemDef.RemoteMethods.GetPurchaseItemAccountancyAmounts(site.ObjectID, purchaseItemDef.ObjectID);
            //                if(accountancyInheldInfo != null)
            //                    retValue.Add(accountancyInheldInfo);
            //            }
            return retValue;
        }
        
        [Serializable]
        public class AccountancyInheldInfo
        {
            public Guid AccountancyID;
            public double Inheld;
        }
        
        [Serializable]
        public class AccountancySurplusInfo
        {
            public Guid AccountancyID;
            public double SurPlusAmount;
        }
        
#endregion Methods

    }
}