
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
    /// Tedarik Talebi
    /// </summary>
    public  partial class SupplyRequest : StockAction
    {
        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SupplyRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SupplyRequest.States.Approval && toState == SupplyRequest.States.Completed)
                PreTransition_Approval2Completed();
        }


        protected void PreTransition_Approval2Completed()
        {

            #region PreTransition_Approval2Completed

            if (IsImmediate == true)
            {
                foreach(SupplyRequestDetail detail in SupplyRequestDetails)
                {
                    detail.IsImmediateMat = true;
                }
            }

            #endregion PreTransition_Approval2Completed
        }

    }
}