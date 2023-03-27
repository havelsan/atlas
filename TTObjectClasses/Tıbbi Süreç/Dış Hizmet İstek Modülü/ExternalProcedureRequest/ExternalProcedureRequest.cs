
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
    /// Dış Hizmet İstek
    /// </summary>
    public  partial class ExternalProcedureRequest : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public partial class ExternalRequestInfoReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class ExternalProcedureRequestListByDate_Class : TTReportNqlObject 
        {
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();

#endregion PostInsert
        }

        protected void PostTransition_ResultEntry2Completed()
        {
            // From State : ResultEntry   To State : Completed
#region PostTransition_ResultEntry2Completed
            
            if(Paid() == false)
                throw new TTUtils.TTException(SystemMessage.GetMessage(141));

#endregion PostTransition_ResultEntry2Completed
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ExternalProcedureRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ExternalProcedureRequest.States.ResultEntry && toState == ExternalProcedureRequest.States.Completed)
                PostTransition_ResultEntry2Completed();
        }

    }
}