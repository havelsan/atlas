
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
    /// Personel Güncelleme
    /// </summary>
    public  partial class UpdateRespUserAction : BaseAction, IWorkListBaseAction
    {
        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PreTransition_New2Completed
            

            foreach (UpdateRespUserActionDetail updateRespUserActionDetail in UpdateRespUserActionDetails)
            {
                if (updateRespUserActionDetail.UpdateResUser != null && updateRespUserActionDetail.CMRAction.ResponsibleUser != updateRespUserActionDetail.UpdateResUser)
                {
                    updateRespUserActionDetail.CMRAction.ResponsibleUser = updateRespUserActionDetail.UpdateResUser;
                }
            }
            

#endregion PreTransition_New2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(UpdateRespUserAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == UpdateRespUserAction.States.New && toState == UpdateRespUserAction.States.Completed)
                PreTransition_New2Completed();
        }

    }
}