
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
    /// Anestezi Konsültasyonu  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class AnesthesiaConsultation : EpisodeActionWithDiagnosis, IAllocateSpeciality, IWorkListEpisodeAction
    {
        public partial class AnesthesiaConsultationReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetAnesthesiaConsultation_Class : TTReportNqlObject 
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
                case "PROCESSDATE":
                    {
                        DateTime? value = (DateTime?)newValue;
#region PROCESSDATE_SetScript
                        if(value != null)
            {
//                foreach(AnesthesiaConsultationProcedure anesthesiaConsultationProcedure in this.AnesthesiaConsultationProcedures)
//                {
//                    if(anesthesiaConsultationProcedure.PerformedDate == null)
//                        anesthesiaConsultationProcedure.PerformedDate = value;
//                }
            }
#endregion PROCESSDATE_SetScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            
            if(CurrentStateDefID == AnesthesiaConsultation.States.Completed)
            {
                if(SubEpisode != null && SendToENabiz())
                    new SendToENabiz(ObjectContext,SubEpisode,SubEpisode.ObjectID,SubEpisode.ObjectDef.Name,"252",Common.RecTime());
            }
#endregion PostUpdate
        }

        protected void PostTransition_AnesthesiaConsultation2Cancelled()
        {
            // From State : AnesthesiaConsultation   To State : Cancelled
#region PostTransition_AnesthesiaConsultation2Cancelled
            Cancel();
#endregion PostTransition_AnesthesiaConsultation2Cancelled
        }

        protected void PostTransition_AnesthesiaConsultation2Approval()
        {
            // From State : AnesthesiaConsultation   To State : Approval
#region PostTransition_AnesthesiaConsultation2Approval
            
            
            if(ProcessDate==null)
                ProcessDate=Common.RecTime();
#endregion PostTransition_AnesthesiaConsultation2Approval
        }

        protected void PostTransition_AnesthesiaConsultation2Completed()
        {
            // From State : AnesthesiaConsultation   To State : Completed
#region PostTransition_AnesthesiaConsultation2Completed
            
            
            if(ProcessDate==null)
                ProcessDate=Common.RecTime();
#endregion PostTransition_AnesthesiaConsultation2Completed
        }

        protected void PostTransition_Request2Cancelled()
        {
            // From State : Request   To State : Cancelled
#region PostTransition_Request2Cancelled
            Cancel();
#endregion PostTransition_Request2Cancelled
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            Cancel();
#endregion PostTransition_Completed2Cancelled
        }

        protected void PostTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed
#region PostTransition_Approval2Completed
            
            
          // Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
          //  TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
          //  objectID.Add("VALUE", this.ObjectID.ToString());
          //  parameters.Add("TTOBJECTID",objectID);
          //  TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_AnesthesiaReport), true, 1, parameters);

#endregion PostTransition_Approval2Completed
        }

        protected void PostTransition_RequestAcception2Cancelled()
        {
            // From State : RequestAcception   To State : Cancelled
#region PostTransition_RequestAcception2Cancelled
            Cancel();
#endregion PostTransition_RequestAcception2Cancelled
        }

        protected void PreTransition_RequestAcception2AnesthesiaConsultation()
        {
            // From State : RequestAcception   To State : AnesthesiaConsultation
#region PreTransition_RequestAcception2AnesthesiaConsultation
            
            if(OlapDate == null)
                OlapDate = DateTime.Now ;

            AddAnesthesiaConsultationProcedure();
#endregion PreTransition_RequestAcception2AnesthesiaConsultation
        }

#region Methods
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.AnesthesiaConsultation;
            }
        }

       
        
        public AnesthesiaConsultation(TTObjectContext objectContext, EpisodeAction episodeAction): this(objectContext)
        {

            ActionDate = Common.RecTime();
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = AnesthesiaConsultation.States.Request;
            ProcedureSpeciality=episodeAction.ProcedureSpeciality;
            MasterAction = episodeAction;
            Episode = episodeAction.Episode;
        }
        
        public AnesthesiaConsultation(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable): this(objectContext)
        {

            ActionDate = Common.RecTime();
            FromResource = subactionProcedureFlowable.MasterResource;
            CurrentStateDefID = AnesthesiaConsultation.States.Request;
            MasterAction = subactionProcedureFlowable.EpisodeAction;
            ProcedureSpeciality=subactionProcedureFlowable.ProcedureSpeciality;
            Episode = subactionProcedureFlowable.Episode;
            
        }
      
        
        protected void AddAnesthesiaConsultationProcedure()
        {
            // Konsültasyon hizmeti oluşması için 
            //bool hizmetEkle = true;
            //Guid procedureGuid = ProcedureDefinition.ConsultationProcedureObjectId;

            //foreach (AnesthesiaConsultationProcedure anesthesiaConsultationProcedure in this.AnesthesiaConsultationProcedures)
            //{
            //    if (anesthesiaConsultationProcedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
            //    {
            //        if (anesthesiaConsultationProcedure.ProcedureObject.ObjectID == procedureGuid)
            //            hizmetEkle = false;
            //    }
            //}

            //AnesthesiaConsultationProcedure _anesthesiaConsultationProcedure = null;

            //if (hizmetEkle == true)
            //    _anesthesiaConsultationProcedure = new AnesthesiaConsultationProcedure(this, procedureGuid.ToString());
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(AnesthesiaConsultation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == AnesthesiaConsultation.States.RequestAcception && toState == AnesthesiaConsultation.States.AnesthesiaConsultation)
                PreTransition_RequestAcception2AnesthesiaConsultation();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(AnesthesiaConsultation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == AnesthesiaConsultation.States.AnesthesiaConsultation && toState == AnesthesiaConsultation.States.Cancelled)
                PostTransition_AnesthesiaConsultation2Cancelled();
            else if (fromState == AnesthesiaConsultation.States.AnesthesiaConsultation && toState == AnesthesiaConsultation.States.Approval)
                PostTransition_AnesthesiaConsultation2Approval();
            else if (fromState == AnesthesiaConsultation.States.AnesthesiaConsultation && toState == AnesthesiaConsultation.States.Completed)
                PostTransition_AnesthesiaConsultation2Completed();
            else if (fromState == AnesthesiaConsultation.States.Request && toState == AnesthesiaConsultation.States.Cancelled)
                PostTransition_Request2Cancelled();
            else if (fromState == AnesthesiaConsultation.States.Completed && toState == AnesthesiaConsultation.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == AnesthesiaConsultation.States.Approval && toState == AnesthesiaConsultation.States.Completed)
                PostTransition_Approval2Completed();
            else if (fromState == AnesthesiaConsultation.States.RequestAcception && toState == AnesthesiaConsultation.States.Cancelled)
                PostTransition_RequestAcception2Cancelled();
        }

    }
}