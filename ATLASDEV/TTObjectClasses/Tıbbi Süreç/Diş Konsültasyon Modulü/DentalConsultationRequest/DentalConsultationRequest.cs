
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
    /// Diş Konsültasyon İstek
    /// </summary>
    public  partial class DentalConsultationRequest : EpisodeAction
    {
        protected void PostTransition_Request2Cancelled()
        {
            // From State : Request   To State : Cancelled
#region PostTransition_Request2Cancelled
            Cancel();
#endregion PostTransition_Request2Cancelled
        }

        protected void PostTransition_Request2Completed()
        {
            // From State : Request   To State : Completed
#region PostTransition_Request2Completed
            //foreach (DentalConsultationDepartment dep in this.Department) {
            //    bool isInsertedBefore = false;
            //    if (this.DentalExamination != null && this.DentalExamination.Consultations != null && this.DentalExamination.Consultations.Count > 0) {
            //        foreach(DentalConsultation cons in this.DentalExamination.DentalConsultations) {
            //            if (!cons.ToString().Contains("Hatalı") && cons.MasterResource.Equals(dep.ResSection) && cons.DescriptionForWorkList.Equals(Common.GetTextOfRTFString(this.RequestDescription))) {
            //                isInsertedBefore = true;
            //                break;
            //            }
            //        }
            //    }
            //    if (!isInsertedBefore) {
            //        DentalConsultation newConsultation = new DentalConsultation(this.ObjectContext);
            //        newConsultation.CurrentStateDefID = TTObjectClasses.DentalConsultation.States.New;
            //        newConsultation.MasterResource = dep.ResSection;
            //        newConsultation.Episode = this.Episode;
            //        newConsultation.DescriptionForWorkList = Common.GetTextOfRTFString(this.RequestDescription.ToString());
            //        newConsultation.SelectedToothNumbers = this.SelectedToothNumbers;
            //        if (this.DentalExamination!= null)
            //            this.DentalExamination.DentalConsultations.Add(newConsultation);
            //    }
            //}
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
        public DentalConsultationRequest(TTObjectContext objectContext, EpisodeAction episodeAction): this(objectContext)
        {

            ActionDate = Common.RecTime();
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            //Episodeun AfterSetinde  this.InPatientPhysicianApplication==null kontrolü olduğu için SetMandatoryEpisodeActionProperties()kullanılmadı.
            //this.SetMandatoryEpisodeActionProperties((EpisodeAction)inPatientPhysicianApplication,inPatientPhysicianApplication.MasterResource,inPatientPhysicianApplication.MasterResource,false);
            CurrentStateDefID = DentalConsultationRequest.States.Request;
            //this.InPatientPhysicianApplication=inPatientPhysicianApplication;
            Episode = episodeAction.Episode;
            ProcedureSpeciality = episodeAction.ProcedureSpeciality;
            MasterAction = episodeAction;
        }
        
        public DentalConsultationRequest(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable): this(objectContext)
        {

            ActionDate = Common.RecTime();
            MasterResource = subactionProcedureFlowable.MasterResource;
            FromResource = subactionProcedureFlowable.MasterResource;
            //Episodeun AfterSetinde  this.InPatientPhysicianApplication==null kontrolü olduğu için SetMandatoryEpisodeActionProperties()kullanılmadı.
            //this.SetMandatoryEpisodeActionProperties((EpisodeAction)inPatientPhysicianApplication,inPatientPhysicianApplication.MasterResource,inPatientPhysicianApplication.MasterResource,false);
            CurrentStateDefID = DentalConsultationRequest.States.Request;
            //this.InPatientPhysicianApplication=inPatientPhysicianApplication;
            Episode = subactionProcedureFlowable.Episode;
            ProcedureSpeciality = subactionProcedureFlowable.ProcedureSpeciality;
            MasterAction = subactionProcedureFlowable.EpisodeAction;
        }
        
        protected override void OnConstruct()
        {
            base.OnConstruct();
            if(CurrentStateDefID == null)
                 CurrentStateDefID = DentalConsultationRequest.States.Request;
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalConsultationRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalConsultationRequest.States.Request && toState == DentalConsultationRequest.States.Cancelled)
                PostTransition_Request2Cancelled();
            else if (fromState == DentalConsultationRequest.States.Request && toState == DentalConsultationRequest.States.Completed)
                PostTransition_Request2Completed();
            else if (fromState == DentalConsultationRequest.States.Completed && toState == DentalConsultationRequest.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

    }
}