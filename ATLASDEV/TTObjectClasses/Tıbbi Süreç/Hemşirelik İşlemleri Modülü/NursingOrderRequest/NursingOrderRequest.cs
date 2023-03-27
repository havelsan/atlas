
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
    /// Hemşire Hizmetleri İstek
    /// </summary>
    public  partial class NursingOrderRequest : TTObject
    {
        protected void PostTransition_Order2Completed()
        {
            // From State : Order   To State : Completed
#region PostTransition_Order2Completed
            //
//            foreach(NursingOrder no in this.PlannedActions)
//            {
//                if (no.Amount > 0 && no.OrderDetails.Count == 0)
//                {
//                    no.CreateOrderDetails();
//                }
//            }
#endregion PostTransition_Order2Completed
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(NursingOrderRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == NursingOrderRequest.States.Order && toState == NursingOrderRequest.States.Completed)
                PostTransition_Order2Completed();
        }

    }
}