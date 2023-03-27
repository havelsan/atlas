
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
    /// Taşınır Mal İşlemi Giriş (Reçeteler İçin)
    /// </summary>
    public  partial class PresChaDocInputWithAccountancy : ChattelDocumentInputWithAccountancy, IBasePrescriptionTransaction, IAutoDocumentNumber, IAutoDocumentRecordLog, IChattelDocumentInputWithAccountancy, ICheckStockActionInDetail, IStockInTransaction
    {
        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PreTransition_Completed2Cancelled
            
            
                        foreach (PresChaDocInputDetWithAccountancy presChaDocInputDetWithAccountancy in PresChaDocInputWithAccountancyDetails)
                            presChaDocInputDetWithAccountancy.Status = StockActionDetailStatusEnum.Cancelled;

#endregion PreTransition_Completed2Cancelled
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PresChaDocInputWithAccountancy).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PresChaDocInputWithAccountancy.States.Completed && toState == PresChaDocInputWithAccountancy.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }

    }
}