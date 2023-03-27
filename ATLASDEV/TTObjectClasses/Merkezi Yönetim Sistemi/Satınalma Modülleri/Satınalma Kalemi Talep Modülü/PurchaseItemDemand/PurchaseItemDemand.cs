
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
    /// Satınalma Kalemi Talep
    /// </summary>
    public  partial class PurchaseItemDemand : BaseCentralAction
    {
        
                    
        protected void PostTransition_Approval2Cancelled()
        {
            // From State : Approval   To State : Cancelled
#region PostTransition_Approval2Cancelled
            
            
           // PurchaseItemDemand.RemoteMethods.SendPurchaseItemDemand(this.FromSite.ObjectID,this);

#endregion PostTransition_Approval2Cancelled
        }

        protected void PostTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed
#region PostTransition_Approval2Completed
            
            
          //  PurchaseItemDemand.RemoteMethods.SendPurchaseItemDemand(this.FromSite.ObjectID,this);
            PurchaseItemDef pItem = new PurchaseItemDef(ObjectContext);
            pItem.ItemName = ItemName;
            NewPurchaseItemDef = pItem;
            TerminologyManagerDef.RunSendWithTerminologyManagerDef(NewPurchaseItemDef);

#endregion PostTransition_Approval2Completed
        }

        protected void PostTransition_New2Approval()
        {
            // From State : New   To State : Approval
#region PostTransition_New2Approval
            
            
         //   PurchaseItemDemand.RemoteMethods.SendPurchaseItemDemand(Sites.SiteMerkezSagKom,this);

#endregion PostTransition_New2Approval
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PurchaseItemDemand).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PurchaseItemDemand.States.Approval && toState == PurchaseItemDemand.States.Cancelled)
                PostTransition_Approval2Cancelled();
            else if (fromState == PurchaseItemDemand.States.Approval && toState == PurchaseItemDemand.States.Completed)
                PostTransition_Approval2Completed();
            else if (fromState == PurchaseItemDemand.States.New && toState == PurchaseItemDemand.States.Approval)
                PostTransition_New2Approval();
        }

    }
}