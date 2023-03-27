
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
    /// Malzeme Muvazene İstek
    /// </summary>
    public  partial class MaterialStabilityAction : BaseCentralAction
    {
        public partial class GetMaterialStabilityAction_Class : TTReportNqlObject 
        {
        }

        
                    
        protected void PreTransition_CreateStability2Completed()
        {
            // From State : CreateStability   To State : Completed
#region PreTransition_CreateStability2Completed
            
            //MaterialStabilityAction.RemoteMethods.SendMaterialStabilityAction(this.FromSite.ObjectID, this);

#endregion PreTransition_CreateStability2Completed
        }

        protected void PreTransition_CreateStability2Cancelled()
        {
            // From State : CreateStability   To State : Cancelled
#region PreTransition_CreateStability2Cancelled
            
            
            //MaterialStabilityAction.RemoteMethods.SendMaterialStabilityAction(this.FromSite.ObjectID, this);

#endregion PreTransition_CreateStability2Cancelled
        }

        protected void PreTransition_RequestStability2CreateStability()
        {
            // From State : RequestStability   To State : CreateStability
#region PreTransition_RequestStability2CreateStability
            
            //MaterialStabilityAction.RemoteMethods.SendMaterialStabilityAction(this.FromSite.ObjectID, this);

#endregion PreTransition_RequestStability2CreateStability
        }

        protected void PreTransition_Request2RequestStability()
        {
            // From State : Request   To State : RequestStability
#region PreTransition_Request2RequestStability
            

           // MaterialStabilityAction.RemoteMethods.SendMaterialStabilityAction(this.ToSite.ObjectID, this);

#endregion PreTransition_Request2RequestStability
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MaterialStabilityAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MaterialStabilityAction.States.CreateStability && toState == MaterialStabilityAction.States.Completed)
                PreTransition_CreateStability2Completed();
            else if (fromState == MaterialStabilityAction.States.CreateStability && toState == MaterialStabilityAction.States.Cancelled)
                PreTransition_CreateStability2Cancelled();
            else if (fromState == MaterialStabilityAction.States.RequestStability && toState == MaterialStabilityAction.States.CreateStability)
                PreTransition_RequestStability2CreateStability();
            else if (fromState == MaterialStabilityAction.States.Request && toState == MaterialStabilityAction.States.RequestStability)
                PreTransition_Request2RequestStability();
        }

    }
}