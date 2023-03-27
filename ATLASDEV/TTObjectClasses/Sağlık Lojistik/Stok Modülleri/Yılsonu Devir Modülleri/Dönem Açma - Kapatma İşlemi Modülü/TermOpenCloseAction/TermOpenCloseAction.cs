
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
    /// Dönem Açma / Kapatma İşlemi
    /// </summary>
    public  partial class TermOpenCloseAction : BaseAction, IWorkListBaseAction
    {
        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PreTransition_New2Completed
            
            

            if (OpenTerm.EndDate > OpenTerm.StartDate)
            {
                if((OpenTerm.IsFirstTerm.HasValue && OpenTerm.IsFirstTerm.Value) == false)
                    CloseTerm.Status = AccountingTermStatusEnum.HalfOpen;
                OpenTerm.Status = AccountingTermStatusEnum.Open;
                OpenTerm.PrevTerm = CloseTerm;
            }
            else
            {
                throw new TTException(SystemMessage.GetMessage(925));
            }



#endregion PreTransition_New2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(TermOpenCloseAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == TermOpenCloseAction.States.New && toState == TermOpenCloseAction.States.Completed)
                PreTransition_New2Completed();
        }

    }
}