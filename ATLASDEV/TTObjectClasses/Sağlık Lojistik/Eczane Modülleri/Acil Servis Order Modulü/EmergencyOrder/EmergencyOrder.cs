
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
    /// Acil Servis Order
    /// </summary>
    public  partial class EmergencyOrder : TTObject
    {
        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DrugOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == EmergencyOrder.States.New && toState == EmergencyOrder.States.Approve)
                PreTransition_New2Approve();
            else if (fromState == EmergencyOrder.States.Approve && toState == EmergencyOrder.States.Completed)
                PreTransition_Approve2Completed();
            else if (fromState == EmergencyOrder.States.Approve && toState == EmergencyOrder.States.Cancelled)
                PreTransition_ApproveCancelled();
            else if (fromState == EmergencyOrder.States.Completed && toState == EmergencyOrder.States.Cancelled)
                PreTransition_Completed2Cancelled();


        }
        protected void PreTransition_New2Approve()
        {
            // From State : New   To State : Approve
            #region PreTransition_New2Approve
            
            #endregion PreTransition_New2Approve
        }

        protected void PreTransition_Approve2Completed()
        {
            // From State : Approve   To State : Completed
            #region PreTransition_Approve2Completed
            //Subactionmaterial yaratýlacak Statusu 1 olan detaylar için
            #endregion PreTransition_Approve2Completed
        }

        protected void PreTransition_ApproveCancelled()
        {
            // From State : Approve   To State : Cancelled
            #region PreTransition_ApproveCancelled

            #endregion PreTransition_ApproveCancelled
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_Completed2Cancelled

            #endregion PreTransition_Completed2Cancelled
        }
    }

   
}