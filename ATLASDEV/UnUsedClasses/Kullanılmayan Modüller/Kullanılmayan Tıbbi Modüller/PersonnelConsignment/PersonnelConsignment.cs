
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
    /// Personel Sevk Muhtırası
    /// </summary>
    public  partial class PersonnelConsignment : EpisodeAction, IWorkListEpisodeAction
    {
        public partial class GetPersonnelConsignmentInfo_Class : TTReportNqlObject 
        {
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            Cancel();
#endregion PostTransition_Completed2Cancelled
        }

        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
#region PostTransition_New2Cancelled
            Cancel();
#endregion PostTransition_New2Cancelled
        }

#region Methods
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.PersonnelConsignment;
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PersonnelConsignment).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == States.Completed && toState == States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == States.New && toState == States.Cancelled)
                PostTransition_New2Cancelled();
        }

    }
}