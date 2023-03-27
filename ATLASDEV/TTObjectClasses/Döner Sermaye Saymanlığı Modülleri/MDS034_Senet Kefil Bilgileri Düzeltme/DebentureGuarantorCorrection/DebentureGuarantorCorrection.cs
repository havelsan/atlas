
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
    /// Kefil Bilgileri Düzeltme
    /// </summary>
    public  partial class DebentureGuarantorCorrection : EpisodeAction, IWorkListEpisodeAction
    {
        public partial class DebentureDebtReportQuery_Class : TTReportNqlObject 
        {
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

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DebentureGuarantorCorrection).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DebentureGuarantorCorrection.States.New && toState == DebentureGuarantorCorrection.States.Completed)
                UndoTransition_New2Completed(transDef);
        }

    }
}