
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
    /// Planlı Tıbbi İşlem İstek
    /// </summary>
    public  partial class PlannedMedicalActionRequest : EpisodeActionWithDiagnosis, IAllocateSpeciality, IReasonOfReject
    {
        public partial class GetPlannedMedicalActionRequest_Class : TTReportNqlObject 
        {
        }

        #region IAllocateSpeciality Members
        public Episode GetEpisode()
        {
            return Episode;
        }

        public void SetEpisode(Episode value)
        {
            Episode = value;
        }

        public EpisodeAction GetMyEpisodeAction()
        {
            return MyEpisodeAction;
        }

        public void SetMyEpisodeAction(EpisodeAction value)
        {
            MyEpisodeAction = value;
        }

        public SubActionProcedure GetMySubActionProcedure()
        {
            return MySubActionProcedure;
        }

        public void SetMySubActionProcedure(SubActionProcedure value)
        {
            MySubActionProcedure = value;
        }

        public SpecialityDefinition GetProcedureSpeciality()
        {
            return ProcedureSpeciality;
        }

        public void SetProcedureSpeciality(SpecialityDefinition value)
        {
            ProcedureSpeciality = value;
        }

        #endregion

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "INPATIENTBED":
                    {
                        ResBed value = (ResBed)newValue;
#region INPATIENTBED_SetParentScript
                        if(value != null)
            {
                if(value.Room != null && value.Room.RoomGroup != null)                    
                    SecondaryMasterResource = value.Room.RoomGroup.Ward;
            }
#endregion INPATIENTBED_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            
            Cancel();
#endregion PostTransition_Completed2Cancelled
        }

        protected void PreTransition_Request2Completed()
        {
            // From State : Request   To State : Completed
#region PreTransition_Request2Completed
            
            
            
            if(ProcedureDoctor == null)
                throw new Exception(SystemMessage.GetMessage(633));
            
            if (PlannedMedicalActionOrders.Count==0)
            {
                throw new Exception(SystemMessage.GetMessage(1243));
            }
#endregion PreTransition_Request2Completed
        }

#region Methods
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.PlannedMedicalActionRequest;
            }
        }
        
        public override void Cancel()
        {
            
            foreach (PlannedMedicalActionOrder PlannedMedicalActionOrder in PlannedMedicalActionOrders)
            {
                if (PlannedMedicalActionOrder.CurrentStateDef.Status != StateStatusEnum.Cancelled && PlannedMedicalActionOrder.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
                {
                    throw new Exception(SystemMessage.GetMessage(1244));
                }
            }
            base.Cancel();
        }

        public PlannedMedicalActionRequest(TTObjectContext objectContext, EpisodeAction episodeAction) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = PlannedMedicalActionRequest.States.Request;
            MasterAction=episodeAction;
            Episode = episodeAction.Episode;
        }
//        
//        public override List<int> AllowedMedulaTedaviTipi()
//        {
////            List<int> typeList=new List<int>();
////            typeList.Add(2);//Fiziksel Tedavi ve Rehabilitasyon
////            return typeList;
//        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PlannedMedicalActionRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PlannedMedicalActionRequest.States.Request && toState == PlannedMedicalActionRequest.States.Completed)
                PreTransition_Request2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PlannedMedicalActionRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PlannedMedicalActionRequest.States.Completed && toState == PlannedMedicalActionRequest.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

    }
}