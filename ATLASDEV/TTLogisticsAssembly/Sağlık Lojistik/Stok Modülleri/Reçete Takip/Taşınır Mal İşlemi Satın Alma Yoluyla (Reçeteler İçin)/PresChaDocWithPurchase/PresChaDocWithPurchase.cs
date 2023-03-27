
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
    /// Taşınır Mal İşlemi Satın Alma Yoluyla (Reçeteler İçin)
    /// </summary>
    public  partial class PresChaDocWithPurchase : ChattelDocumentWithPurchase, IBasePrescriptionTransaction, IChattelDocumentWithPurchase, IAutoDocumentRecordLog
    {
        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PreTransition_Completed2Cancelled
            

            foreach (PresChaDocDetWithPurchase presChaDocDetWithPurchase in PresChaDocDetailsWithPurchase)
                presChaDocDetWithPurchase.Status = StockActionDetailStatusEnum.Cancelled;

#endregion PreTransition_Completed2Cancelled
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PresChaDocWithPurchase).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PresChaDocWithPurchase.States.Completed && toState == PresChaDocWithPurchase.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }

    }
}