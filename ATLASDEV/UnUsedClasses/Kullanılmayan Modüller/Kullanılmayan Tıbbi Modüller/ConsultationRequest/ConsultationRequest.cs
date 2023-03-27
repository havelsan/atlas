
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
    /// Konsültasyon İstek İşleminin Yapıldığı Temel Nesnedir
    /// </summary>
    public  partial class ConsultationRequest : EpisodeAction, IReasonOfReject, IWorkListEpisodeAction
    {
        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();

#endregion PostInsert
        }

        protected void PostTransition_Request2Completed()
        {
            // From State : Request   To State : Completed
#region PostTransition_Request2Completed
            
            if(Episode.EmergencyPatientStatusInfo != null)
                Episode.EmergencyPatientStatusInfo.PatientStatus = EmergencyPatientStatusInfoEnum.ConsultationRequested;

#endregion PostTransition_Request2Completed
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            
            Cancel();
#endregion PostTransition_Completed2Cancelled
        }

#region Methods
        public ConsultationRequest(TTObjectContext objectContext, EpisodeAction episodeAction): this(objectContext)
        {

            ActionDate = Common.RecTime();
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            //Episodeun AfterSetinde  this.InPatientPhysicianApplication==null kontrolü olduğu için SetMandatoryEpisodeActionProperties()kullanılmadı.
            //this.SetMandatoryEpisodeActionProperties((EpisodeAction)inPatientPhysicianApplication,inPatientPhysicianApplication.MasterResource,inPatientPhysicianApplication.MasterResource,false);
            CurrentStateDefID = ConsultationRequest.States.Request;
            //this.InPatientPhysicianApplication=inPatientPhysicianApplication;
            Episode = episodeAction.Episode;
            ProcedureSpeciality=episodeAction.ProcedureSpeciality;
            MasterAction = episodeAction;
        }
        
        public ConsultationRequest(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable): this(objectContext)
        {

            ActionDate = Common.RecTime();
            MasterResource = subactionProcedureFlowable.MasterResource;
            FromResource = subactionProcedureFlowable.MasterResource;
            //Episodeun AfterSetinde  this.InPatientPhysicianApplication==null kontrolü olduğu için SetMandatoryEpisodeActionProperties()kullanılmadı.
            //this.SetMandatoryEpisodeActionProperties((EpisodeAction)inPatientPhysicianApplication,inPatientPhysicianApplication.MasterResource,inPatientPhysicianApplication.MasterResource,false);
            CurrentStateDefID = ConsultationRequest.States.Request;
            //this.InPatientPhysicianApplication=inPatientPhysicianApplication;
            Episode = subactionProcedureFlowable.Episode;
            ProcedureSpeciality=subactionProcedureFlowable.ProcedureSpeciality;
            MasterAction = subactionProcedureFlowable.EpisodeAction;
        }
        
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.Consultation;
            }
        }
        public override void Cancel()
        {
//            foreach(Consultation consultation in this.Consultations)
//                if (consultation.CurrentStateDefID != Consultation.States.Cancelled)
//                throw new Exception(SystemMessage.GetMessage(638));
            base.Cancel();
        }
        
        

        
        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList= base.OldActionPropertyList();
            if(propertyList==null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();

            
            //-------------------------------------
            // propertyList.Add(new OldActionPropertyObject("İstek Tarihi",Common.ReturnObjectAsString(RequestDate)));
            // propertyList.Add(new OldActionPropertyObject("Acil",Common.ReturnObjectAsString(Emergency)));
            //            propertyList.Add(new OldActionPropertyObject("Yatağında",Common.ReturnObjectAsString(InPatientBed)));
            //            if(ConsultedSubject != null)
            //                propertyList.Add(new OldActionPropertyObject("Danışılan Konu",Common.ReturnObjectAsString(ConsultedSubject.ConsultedSubject)));
            if(MasterResource != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject("İstek Yapan Birim",Common.ReturnObjectAsString(MasterResource.Name)));
            if(ProcedureDoctor != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject("İsteği Yapan Doktor",Common.ReturnObjectAsString(ProcedureDoctor.Name)));
            //            propertyList.Add(new OldActionPropertyObject("İstek Açıklaması",Common.ReturnObjectAsString(RequestDescription)));
            //---------------------------------------
            return propertyList;
        }
        
        public override bool SetMyProcedureDoctorToMySubactionProcedure()
        {
            return false;
        }
        
       
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ConsultationRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == States.Request && toState == States.Completed)
                PostTransition_Request2Completed();
            else if (fromState == States.Completed && toState == States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

    }
}