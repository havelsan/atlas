
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
    /// İhale Tarih ve Kayıt No Güncelleme
    /// </summary>
    public  partial class TenderDateUpdate : BaseDataCorrection, IWorkListBaseAction
    {
        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PreTransition_New2Completed
            
            if (StockAction != null)
            {
                if (StockAction is ChattelDocumentWithPurchase)
                {
                    ((ChattelDocumentWithPurchase)StockAction).AuctionDate = AuctionDate;
                    ((ChattelDocumentWithPurchase)StockAction).RegistrationAuctionNo  = RegistrationAuctionNo;
                    
                }
            }

#endregion PreTransition_New2Completed
        }

        protected void UndoTransition_New2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Completed
#region UndoTransition_New2Completed
            NoBackStateBack();
#endregion UndoTransition_New2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(TenderDateUpdate).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == TenderDateUpdate.States.New && toState == TenderDateUpdate.States.Completed)
                PreTransition_New2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(TenderDateUpdate).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == TenderDateUpdate.States.New && toState == TenderDateUpdate.States.Completed)
                UndoTransition_New2Completed(transDef);
        }

    }
}