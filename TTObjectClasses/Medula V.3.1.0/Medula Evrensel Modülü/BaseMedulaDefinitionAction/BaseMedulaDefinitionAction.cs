
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
    /// Temel Medula Tanım İşlemi
    /// </summary>
    public  abstract  partial class BaseMedulaDefinitionAction : BaseMedulaWLAction
    {
        protected void PreTransition_SentServer2Successfully()
        {
            // From State : SentServer   To State : Successfully
#region PreTransition_SentServer2Successfully
            
            
            
            
            if(((ITTObject)this).IsImported == false)
                throw new TTException(TTUtils.CultureService.GetText("M25300", "Bu aşama, sadece içeri alma esnasında kullanılabilir."));

#endregion PreTransition_SentServer2Successfully
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(BaseMedulaDefinitionAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == BaseMedulaDefinitionAction.States.SentServer && toState == BaseMedulaDefinitionAction.States.Successfully)
                PreTransition_SentServer2Successfully();
        }

    }
}