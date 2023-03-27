
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
    public  abstract  partial class BaseDataCorrection : BaseAction
    {
        protected void UndoTransition_New2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Completed
#region UndoTransition_New2Completed
            
                NoBackStateBack();

#endregion UndoTransition_New2Completed
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PreTransition_Completed2Cancelled
            
            NoCancel();

#endregion PreTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
#region UndoTransition_Completed2Cancelled
            
            NoBackStateBack();

#endregion UndoTransition_Completed2Cancelled
        }

#region Methods
        protected override void OnConstruct()
        {
            if(!(this is TenderDateUpdate))
            CheckOnlySuperUserAction();

            base.OnConstruct();
        }

        public override void Cancel()
        {
            base.NoCancel();
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(BaseDataCorrection).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == BaseDataCorrection.States.Completed && toState == BaseDataCorrection.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(BaseDataCorrection).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == BaseDataCorrection.States.New && toState == BaseDataCorrection.States.Completed)
                UndoTransition_New2Completed(transDef);
            else if (fromState == BaseDataCorrection.States.Completed && toState == BaseDataCorrection.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
        }

    }
}