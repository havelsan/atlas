
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
    public  abstract  partial class BaseMedulaAction : BaseMedulaWLAction
    {
        public partial class GetBaseMedulaActionForMedulaTransfer_RQ_Class : TTReportNqlObject 
        {
        }

        protected void PreTransition_SentServer2New()
        {
            // From State : SentServer   To State : New
#region PreTransition_SentServer2New
            
            
#if MEDULA
            if ((this.HealthFacility.IsXXXXXXExist.HasValue && this.HealthFacility.IsXXXXXXExist.Value) == false)
                throw new TTException("Bu işlem XXXXXX kullanmayan sahalarda yapılamaz.");
#endif


#endregion PreTransition_SentServer2New
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(BaseMedulaAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == BaseMedulaAction.States.SentServer && toState == BaseMedulaAction.States.New)
                PreTransition_SentServer2New();
        }

    }
}