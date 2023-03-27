
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
    /// Hizmet Malzeme Giriş
    /// </summary>
    public  partial class ProcedureMaterialAdding : EpisodeAction
    {
        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            
            if(ProcedureDefinition != null)
            {
                if(ProcedureDoctor == null)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26383", "Lütfen İşlemi Yapan Doktoru Seçiniz."));

                if (PStartDate == null || PEndDate == null)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(621));
                
                if(Common.DateDiffV2(0,Convert.ToDateTime(PEndDate),Convert.ToDateTime(PStartDate),false) < 0)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(337));
                
                // İki tarih arası hizmeti ekle
                for(int i = 0; i <= Common.DateDiffV2(0,Convert.ToDateTime(PEndDate),Convert.ToDateTime(PStartDate),false); i++)
                {
                    PMAddingProcedure PMAddingProc = new PMAddingProcedure(ObjectContext);
                    PMAddingProc.ActionDate = Common.RecTime();
                    PMAddingProc.PricingDate = Convert.ToDateTime(PStartDate).AddDays((double)i);
                    PMAddingProc.Amount = 1;
                    PMAddingProc.CurrentStateDefID = PMAddingProcedure.States.Completed;
                    PMAddingProc.ProcedureObject = ProcedureDefinition;
                    
                    PMAddingProc.SetPerformedDate();
                    
                    PMAddingProcedures.Add(PMAddingProc);
                    PMAddingProc.AccountOperation(AccountOperationTimeEnum.PREPOST);
                }
            }
    

#endregion PostTransition_New2Completed
        }

        protected void UndoTransition_New2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Completed
#region UndoTransition_New2Completed
            NoBackStateBack();
#endregion UndoTransition_New2Completed
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            base.Cancel();
#endregion PostTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
#region UndoTransition_Completed2Cancelled
            NoBackStateBack();
#endregion UndoTransition_Completed2Cancelled
        }

#region Methods
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.EpisodeAccountAction;
            }
        }
        
        public override void Cancel()
        {
            NoCancel();
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ProcedureMaterialAdding).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ProcedureMaterialAdding.States.New && toState == ProcedureMaterialAdding.States.Completed)
                PostTransition_New2Completed();
            else if (fromState == ProcedureMaterialAdding.States.Completed && toState == ProcedureMaterialAdding.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ProcedureMaterialAdding).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ProcedureMaterialAdding.States.New && toState == ProcedureMaterialAdding.States.Completed)
                UndoTransition_New2Completed(transDef);
            else if (fromState == ProcedureMaterialAdding.States.Completed && toState == ProcedureMaterialAdding.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
        }

    }
}