
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
    /// Sevk Süresi Uzatma
    /// </summary>
    public  partial class EpisodeProtocolDayLimitChange : EpisodeAccountAction, IWorkListEpisodeAction
    {
        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            /*
            EpisodeProtocol myEP = null;
            foreach (EpisodeProtocolDayLimitChangeDetail EPDayLimDet in this.EpisodeProtocolDayLimitChangeDetails)
            {
                myEP = (EpisodeProtocol) EpisodeProtocol.GetByObjectID(this.ObjectContext, EPDayLimDet.EPOBJECTID.ToString())[0];
                myEP.UpdateDayLimit( (int) EPDayLimDet.DAYLIMIT);
            }
            */
            

#endregion PostTransition_New2Completed
        }

        protected void UndoTransition_New2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Completed
#region UndoTransition_New2Completed
            NoBackStateBack();
#endregion UndoTransition_New2Completed
        }

#region Methods
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.EpisodeAccountAction;
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(EpisodeProtocolDayLimitChange).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == EpisodeProtocolDayLimitChange.States.New && toState == EpisodeProtocolDayLimitChange.States.Completed)
                PostTransition_New2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(EpisodeProtocolDayLimitChange).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == EpisodeProtocolDayLimitChange.States.New && toState == EpisodeProtocolDayLimitChange.States.Completed)
                UndoTransition_New2Completed(transDef);
        }

    }
}