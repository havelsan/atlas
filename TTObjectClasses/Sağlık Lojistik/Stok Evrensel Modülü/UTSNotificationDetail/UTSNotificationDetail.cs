
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
    public partial class UTSNotificationDetail : TTObject
    {
        protected override void PreInsert()
        {
            base.PreInsert();
            SetUTSNotificationDetailOfAccTrxs();
        }

        public void SetUTSNotificationDetailOfAccTrxs()
        {
            if (StockTransaction != null && StockTransaction.StockActionDetail != null && StockTransaction.StockActionDetail.SubActionMaterial != null && StockTransaction.StockActionDetail.SubActionMaterial.Count > 0)
            {
                SubActionMaterial sm = StockTransaction.StockActionDetail.SubActionMaterial[0];
                AccountTransaction accTrx = sm.AccountTransactions.FirstOrDefault(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled && 
                                                                                          x.AccountPayableReceivable.Type == APRTypeEnum.PAYER && 
                                                                                          x.StockOutTransaction != null &&
                                                                                          x.StockOutTransaction.ObjectID == StockTransaction.ObjectID && 
                                                                                          x.UTSNotificationDetail == null);

                if (accTrx != null)
                    accTrx.UTSNotificationDetail = this;
            }
        }
    }
}