
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
    /// Hemşire Takip Gözlem Uygulaması (Klinik İşlemleri)
    /// </summary>
    public  partial class NursingOrderDetail : BaseNursingOrderDetails, IWorkListEpisodeAction, ITreatmentMaterialCollection, IWorkListInpatient
    {
        public partial class GetByNursingOrderDetail_Class : TTReportNqlObject 
        {
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            TTObjectContext objContext = new TTObjectContext(true);
            BaseNursingOrderDetails originalNOD = objContext.GetObject(ObjectID, ObjectDef, false) as BaseNursingOrderDetails;

            if (originalNOD != null)
            {
                if (originalNOD.CurrentStateDefID == NursingOrderDetail.States.Cancelled && CurrentStateDefID == NursingOrderDetail.States.Completed)
                {
                    CreateMyVitalSign();//VT de ki state cancel am ayeni state completed ise (Undo trsansationdan gelmiştir.)
                }
            }
            base.PostUpdate();

#endregion PostUpdate
        }

        protected override void PreDelete()
        {
#region PreDelete
            
            base.PreDelete();
            throw new Exception((SystemMessage.GetMessage(1166)));
#endregion PreDelete
        }

        protected override void PreInsert()
        {
            #region PreInsert
            if (controlPreDischargedDate())
                base.PreInsert();

            #endregion PreInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            if (controlPreDischargedDate())
                base.PreUpdate();

            #endregion PreUpdate
        }

        protected bool controlPreDischargedDate()
        {
            if (CurrentStateDefID == NursingOrderDetail.States.Execution || CurrentStateDefID == NursingOrderDetail.States.Completed)
            {
                DateTime _date = ExecutionDate.HasValue == false ? WorkListDate.Value : ExecutionDate.Value;
                DateTime? _dischargedDate = null;

                if (NursingApplication.EmergencyIntervention != null && NursingApplication.EmergencyIntervention.DischargeTime != null)
                    _dischargedDate = NursingApplication.EmergencyIntervention.DischargeTime;
                else if(NursingApplication.InPatientTreatmentClinicApp != null)
                    _dischargedDate = NursingApplication.InPatientTreatmentClinicApp.ClinicDischargeDate;
                if (_dischargedDate < _date)
                    throw new Exception("Hasta " + _dischargedDate + " tarihinde taburcu olduğu için bu tarihten sonrasına herhangi bir order eklenemez / değiştirilemez.");
                else
                    return true;
            }

            return true;
        }

        protected void PostTransition_Execution2Completed()
        {
            // From State : Execution   To State : Completed
            #region PostTransition_Execution2Completed
            ExecuteOrderDetail();
            SetPerformedDate();
            #endregion PostTransition_Execution2Completed
        }

        protected void UndoTransition_Execution2Completed()
        {
            Result = null;
            ResultBloodPressure = null;
            Result_Pulse = null;
            Result_SPO2 = null;

            CancelVitalSigns();//sonucu silince vitalsign kaydını da sil
        }

        protected void UndoTransition_Execution2Cancelled()
        {
            //this.ObjectContext.Update();
        }

        #region Methods
        #region ITreatmentMaterialCollection Members
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection GetTreatmentMaterials()
        {
            return TreatmentMaterials;
        }
        #endregion
        public NursingOrderDetail(NursingOrder nursingOrder): this(nursingOrder.ObjectContext)
        {
            CurrentStateDefID = NursingOrderDetail.States.Execution;
            ProcedureObject = nursingOrder.ProcedureObject;
            ActionDate = Common.RecTime().Date;
            MasterResource = (ResSection)nursingOrder.MasterResource;
            FromResource = (ResSection)nursingOrder.FromResource;
            Episode = (Episode)nursingOrder.Episode;
            NursingApplication=nursingOrder.NursingApplication;
            //CreateMyVitalSign(); Bu Kod  Formdan Value irişi yapılıp kaydedilirken çağırılmalı
        }

        public NursingOrderDetail(TTObjectContext objectContext, NursingOrder nursingOrder, NursingOrderDetail nursingOrderDetail) : this(nursingOrder.ObjectContext)
        {
            CurrentStateDefID = NursingOrderDetail.States.Execution;
            ProcedureObject = nursingOrder.ProcedureObject;
            ActionDate = Common.RecTime().Date;
            MasterResource = (ResSection)nursingOrder.MasterResource;
            FromResource = (ResSection)nursingOrder.FromResource;
            Episode = (Episode)nursingOrder.Episode;
            NursingApplication = nursingOrder.NursingApplication;
            WorkListDate = nursingOrderDetail.WorkListDate;

            AppointmentWithoutResource appointmentWithoutResource = new AppointmentWithoutResource(ObjectContext);
            appointmentWithoutResource.CurrentStateDefID = AppointmentWithoutResource.States.New;
            appointmentWithoutResource.AppDateTime = Convert.ToDateTime(nursingOrderDetail.WorkListDate);
            AppointmentWithoutResources.Add(appointmentWithoutResource);
        }

        public override void SetMyPropertiesByMasterAction(EpisodeAction episodeAction)
        {
            EpisodeAction = episodeAction;
            CurrentStateDefID = NursingOrderDetail.States.Execution;
            ActionDate = Common.RecTime().Date;
            MasterResource = (ResSection)episodeAction.MasterResource;
            FromResource = (ResSection)episodeAction.FromResource;
            Episode = (Episode)episodeAction.Episode;
        }

        public override void Cancel()
        {
            //Cancelled stateine geçerken yapılan şeyler yapılacak
            CancelOrderDetail();
            CancelVitalSigns();
            base.Cancel();
        }
        
        public override Resource SpecialResourceForStore()
        {
            if(TTObjectClasses.SystemParameter.GetParameterValue("UseSecMasterResourceAsSpecialResourceForStore", "TRUE") == "FALSE") // Hastanın tedavi gördüğü birim
            {
                Resource tgb= null;
                if (EpisodeAction is NursingApplication)
                {
                    if(((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp != null)
                        return (Resource)(((NursingApplication)EpisodeAction).InPatientTreatmentClinicApp.MasterResource);
                }
            }
            return SecondaryMasterResource == null ? MasterResource : SecondaryMasterResource ;
        }

        public void CancelVitalSigns()
        {
            if (this is NursingOrderDetail)
            {
                int _count = SubVitalSigns.Count;
                ObjectContext.FullPartialllyLoadedObjects(); //TODO : İncelenecek MA
                while (_count > 0)
                {
                    ((ITTObject)SubVitalSigns[_count - 1]).Delete();
                    _count--;
                }

            }
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(NursingOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == NursingOrderDetail.States.Execution && toState == NursingOrderDetail.States.Completed)
                PostTransition_Execution2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(NursingOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == NursingOrderDetail.States.Execution && toState == NursingOrderDetail.States.Completed)
                UndoTransition_Execution2Completed();
            if (fromState == NursingOrderDetail.States.Completed && toState == NursingOrderDetail.States.Cancelled)
                UndoTransition_Execution2Cancelled();
        }

        public override void SetPerformedDate()
        {
            if (CreationDate == null || CreationDate > ExecutionDate)
                CreationDate = ExecutionDate;
            if (PerformedDate == null)
                PerformedDate = ExecutionDate;

        }

    }
}