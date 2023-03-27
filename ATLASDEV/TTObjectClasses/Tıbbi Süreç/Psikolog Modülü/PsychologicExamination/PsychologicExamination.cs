
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
    public partial class PsychologicExamination : EpisodeAction
    {

        override public Guid ProcedureRequestStartedStateDefID()
        {
            return (Guid)PsychologicExamination.States.Therapy;
        }

        override public void DoMyActionControlsForProcedureRequest()
        {

        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
           
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PsychologicExamination.States.Therapy  && toState == PsychologicExamination.States.Cancelled)
                PostTransition_Therapy2Cancelled();
        }
        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
           
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PsychologicExamination.States.Therapy && toState == PsychologicExamination.States.Cancelled)
                NoBackStateBack();
            else if (fromState == PsychologicExamination.States.Therapy && toState == PsychologicExamination.States.Completed)
            {
                foreach (PsychologyTest test in PsychologyTests)
                {
                    test.PerformedDate = null;
                }
            }
            
        }



        protected void PostTransition_Therapy2Cancelled()
        {
           
            Cancel();
            
        }

        public override void Cancel()
        {
            base.Cancel();
        }

        public virtual ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.PsychologicExamination;
            }
        }
    }
}