
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
    /// Muh.Yet. Mutemetliği/Vezne/Fatura Servisi Açma
    /// </summary>
    public  partial class CashOfficeOpening : BaseAction, IWorkListBaseAction
    {
        protected void UndoTransition_New2CashOfficeOpened(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : CashOfficeOpened
#region UndoTransition_New2CashOfficeOpened
            NoBackStateBack();
#endregion UndoTransition_New2CashOfficeOpened
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CashOfficeOpening).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CashOfficeOpening.States.New && toState == CashOfficeOpening.States.CashOfficeOpened)
                UndoTransition_New2CashOfficeOpened(transDef);
        }

    }
}