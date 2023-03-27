
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
    /// Son Kullanma Tarihi Güncelleme
    /// </summary>
    public  partial class ExpirationDateCorrectionAction : BaseDataCorrection, IWorkListBaseAction, IExpirationDateCorrectionAction
    {
        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PreTransition_New2Completed
            
            

            DateTime newExpirationDate = Common.GetLastDayOfMounth((DateTime)NewExpirationDate);
            foreach (FirstInStockAction firstInStockAction in FirstInStockActions)
            {
                if ((bool)firstInStockAction.SelectedStockAction)
                {
                    StockTransaction firstInTrx = (StockTransaction)ObjectContext.GetObject((Guid)firstInStockAction.StockTransactionObjectID, typeof(StockTransaction));
                    firstInTrx.ExpirationDate = newExpirationDate;
                    foreach (InStockAction inStockAction in firstInStockAction.InStockActions)
                    {
                        StockTransaction inTrx = (StockTransaction)ObjectContext.GetObject((Guid)inStockAction.StockTransactionObjectID, typeof(StockTransaction));
                        inTrx.ExpirationDate = newExpirationDate;
                    }
                }
            }
                

#endregion PreTransition_New2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ExpirationDateCorrectionAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ExpirationDateCorrectionAction.States.New && toState == ExpirationDateCorrectionAction.States.Completed)
                PreTransition_New2Completed();
        }

    }
}