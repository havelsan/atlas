
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
    /// Sağlık Kurulu Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public partial class HealthCommitteeExamination : PatientExamination, IPatientWorkList, IAppointmentDef, IAllocateSpeciality, IWorkListEpisodeAction, IOAHealthCommitteeExaminatios, IOAHealthCommittee, INumaratorAppointment
    {
        public partial class GetCurrentHCExamination_Class : TTReportNqlObject
        {
        }

        public partial class GetHCExamsByMResource_Class : TTReportNqlObject
        {
        }

        public partial class GetHCExaminationByMasterAction_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetHealthCommitteeDetails_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetHealthCommitteeExamination_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledHealthCommitteeExamination_Class : TTReportNqlObject
        {
        }

        public partial class GetBackHCExaminationByDate_Class : TTReportNqlObject
        {
        }

        #region INumaratorAppointment Members

        public AppointmentTypeEnum GetNumaratorAppointmentType()
        {
            return NumaratorAppointmentType;
        }

        public Resource GetNumaratorAppointmentMasterResource()
        {
            return NumaratorAppointmentMasterResource;
        }

        public Resource GetNumaratorAppointmentResource()
        {
            return NumaratorAppointmentResource;
        }
        #endregion

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

        protected override void PostInsert()
        {
            #region PostInsert

            base.PostInsert();
            SetDescriptionForWorkList();

            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            base.PreUpdate();

            if (((TransDef != null) && (TransDef.ToStateDefID == HealthCommitteeExamination.States.Completed /*|| this.TransDef.ToStateDefID == HealthCommitteeExamination.States.ExaminationCompleted || this.TransDef.ToStateDefID == PatientExamination.States.ProcedureRequested*/)))
            {
                foreach (PatientExaminationProcedure patientExaminationProcedure in PatientExaminationProcedures.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled))
                {
                    patientExaminationProcedure.SetPerformedDate();
                }
            }
        }

            protected void PostTransition_Examination2Cancelled()
        {
            // From State : Examination   To State : Cancelled
            #region PostTransition_Examination2Cancelled

            CheckMasterActionPrivilege();
            base.Cancel();
            #endregion PostTransition_Examination2Cancelled
        }

        protected void PostTransition_Examination2Completed()
        {
            // From State : Examination   To State : Completed
            #region PostTransition_Examination2Completed

            //işlemi yapan doktor
            //SetProcedureDoctorAsCurrentResource();

            #endregion PostTransition_Examination2Completed
        }

        protected void UndoTransition_Examination2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Examination   To State : Completed
            #region UndoTransition_Examination2Completed

            CheckMasterActionPrivilege();
            #endregion UndoTransition_Examination2Completed
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled

            CheckMasterActionPrivilege();
            base.Cancel();
            #endregion PostTransition_Completed2Cancelled
        }

        protected void PreTransition_New2Examination()
        {
            // From State : New   To State : Examination
            #region PreTransition_New2Examination

            //HealthCommitteeExaminationProcedure pProcedure = new HealthCommitteeExaminationProcedure(this, ProcedureDefinition.ExaminationProcedureObjectId.ToString());

            #endregion PreTransition_New2Examination
        }

        protected void PostTransition_New2Examination()
        {
            // From State : New   To State : Examination
            #region PostTransition_New2Examination

            CompleteMyExaminationQueueItems();
            #endregion PostTransition_New2Examination
        }

        protected void PostTransition_New2PatientNoShown()
        {
            // From State : New   To State : PatientNoShown
            #region PostTransition_New2PatientNoShown

            CancelMyExaminationQueueItems();
            Cancel();
            #endregion PostTransition_New2PatientNoShown
        }

        protected void PostTransition_InsertedIntoQueue2Examination()
        {
            // From State : InsertedIntoQueue   To State : Examination
            #region PostTransition_InsertedIntoQueue2Examination

            CompleteMyExaminationQueueItems();
            #endregion PostTransition_InsertedIntoQueue2Examination
        }

        protected void PostTransition_InsertedIntoQueue2PatientNoShown()
        {
            // From State : InsertedIntoQueue   To State : PatientNoShown
            #region PostTransition_InsertedIntoQueue2PatientNoShown

            CancelMyExaminationQueueItems();
            Cancel();
            #endregion PostTransition_InsertedIntoQueue2PatientNoShown
        }

        #region Methods

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.HealthCommitteeExamination);
                if (appDefList.Count > 0)
                {
                    appDef = (AppointmentDefinition)appDefList[0];
                    foreach (AppointmentCarrier appCarrier in appDef.AppointmentCarriers)
                    {
                        _appointmentList.Add(appCarrier);
                    }
                }

                if (_appointmentList.Count == 0)
                {
                    AppointmentCarrier carrier = new AppointmentCarrier(context);
                    carrier.MasterResource = "ResPoliclinic";
                    carrier.SubResource = "ResUser";
                    carrier.RelationParentName = "";
                    carrier.AppointmentDefinition = appDef;
                    _appointmentList.Add(carrier);
                }
                //her app carrier listenin başında çağırılmalı.
                ClearAppointmentCarrierDynamicFields(_appointmentList);
                foreach (AppointmentCarrier appointmentCarrier in _appointmentList)
                {
                    if (MasterResource != null)
                    {
                        appointmentCarrier.MasterResourceFilter = " OBJECTID = '" + MasterResource.ObjectID.ToString() + "'";
                    }
                    else
                    {
                        appointmentCarrier.MasterResourceFilter = "";
                    }
                    break;
                }
                return _appointmentList;
            }
        }

        #region IAppointmentDef Members
        public List<AppointmentCarrier> GetAppointmentCarrierList()
        {
            return AppointmentCarrierList;
        }
        #endregion

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.HealthCommitteeExamination;
            }
        }

        public AppointmentTypeEnum NumaratorAppointmentType
        {
            get { return AppointmentTypeEnum.Examination; }
        }

        public Resource NumaratorAppointmentMasterResource
        {
            get { return MasterResource; }// İşlemin yapıuldığı Poliklinik aynı zamanada randevu verilecek üst kaynakdır
        }

        public Resource NumaratorAppointmentResource
        {
            get
            {
                if (ProcedureDoctor == null)
                {
                    TTObjectContext roContext = new TTObjectContext(true);
                    BindingList<TTObjectClasses.Appointment.GetMinNumaratorAppointmentResource_Class> minAppResource = Appointment.GetMinNumaratorAppointmentResource(roContext, MasterResource.ObjectID, Common.RecTime().Date, Common.RecTime().Date.AddDays(1));
                    if (minAppResource.Count > 0)
                    {
                        foreach (TTObjectClasses.Appointment.GetMinNumaratorAppointmentResource_Class minNumApp in minAppResource)
                        {
                            Resource resource = (Resource)roContext.GetObject(minNumApp.Resource.Value, typeof(Resource));
                            if (resource is ResUser)
                            {
                                ProcedureDoctor = (ResUser)resource;
                                break;
                            }
                        }
                    }

                    if (ProcedureDoctor == null)
                    {
                        IList<ResUser> userList = (IList<ResUser>)ResUser.GetByUserResourceAndUserType(roContext, UserTypeEnum.Doctor, MasterResource.ObjectID.ToString());
                        foreach (ResUser resUser in userList)
                        {
                            ProcedureDoctor = (ResUser)resUser;
                            break;
                        }
                    }
                }
                return ProcedureDoctor;
            }
            // işlemi yapan doktor aynı zamanda randevu verilecek kişidir
        }

        /// <summary>
        /// Fork işlemleri için kullanlan constructor.
        /// </summary>
        /// <param name="episodeAction"></param>
        /// <param name="masterResource"></param>
        /// <param name="Explanation"></param>
        public HealthCommitteeExamination(EpisodeAction masterAction, HospitalsUnitsGrid hospitalsUnits) : this(masterAction.ObjectContext)
        {
            CurrentStateDefID = HealthCommitteeExamination.States.New;

            SetMandatoryEpisodeActionProperties(masterAction, (ResSection)hospitalsUnits.Unit, true);
            if (masterAction is HealthCommittee)
            {
                HealthCommittee healthCommittee = (HealthCommittee)masterAction;
                Weight = healthCommittee.ClinicWeight;
                Height = healthCommittee.ClinicHeight;
                ProcedureDoctor = hospitalsUnits.Doctor;
            }


            if (ProcedureSpeciality == null)
                throw new Exception(SystemMessage.GetMessageV3(640, new string[] { MasterResource.Name.ToString() }));

            bool chargeHCExaminationPrice = true;
            if (hospitalsUnits.Unit != null)
            {
                if (hospitalsUnits.Unit.NotChargeHCExaminationPrice == true)
                    chargeHCExaminationPrice = false;
            }

            if (chargeHCExaminationPrice)
            {
                string examinationProcedureGuid = ProcedureDefinition.ExaminationProcedureObjectId.ToString();
                if (hospitalsUnits.Unit is ResPoliclinic)
                {
                    if (((ResPoliclinic)hospitalsUnits.Unit).PoliclinicType == PoliclinicTypeEnum.DentalPoliclinic) // Diş Polikliniği ise
                        examinationProcedureGuid = ProcedureDefinition.DentalExaminationProcedureObjectId.ToString();
                }

                HealthCommitteeExaminationProcedure pProcedure = new HealthCommitteeExaminationProcedure(this, examinationProcedureGuid);
                pProcedure.AccountOperation(AccountOperationTimeEnum.PRE);

                bool turnAccTrxToPatientShareAndCancel = false;
                HealthCommittee healthCommittee = null;
                if (masterAction is HealthCommitteeExaminationFromOtherDepartments)
                {
                    HealthCommitteeExaminationFromOtherDepartments hceFromOtherDepartments = (HealthCommitteeExaminationFromOtherDepartments)masterAction;
                    healthCommittee = hceFromOtherDepartments.HCActionToBeLinked;
                }
                else if (masterAction is HealthCommittee)
                    healthCommittee = (HealthCommittee)masterAction;

                if (healthCommittee != null && healthCommittee.WhoPays == WhoPaysEnum.PatientPays)
                    turnAccTrxToPatientShareAndCancel = true;

                foreach (AccountTransaction AccTrx in pProcedure.AccountTransactions)
                {
                    if (hospitalsUnits.Unit != null && !string.IsNullOrEmpty(hospitalsUnits.Unit.Name))
                        AccTrx.Description = AccTrx.Description + " (" + hospitalsUnits.Unit.Name + ")";

                    if (AccTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                    {
                        if (turnAccTrxToPatientShareAndCancel)
                            AccTrx.TurnToPatientShare(false);
                        else if (SubEpisode.IsSGK)
                            AccTrx.CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                    }
                    else if (AccTrx.AccountPayableReceivable.Type == APRTypeEnum.PATIENT)
                    {
                        if (turnAccTrxToPatientShareAndCancel)
                            AccTrx.InvoiceInclusion = false;
                    }
                }

                if (hospitalsUnits.Unit != null && !string.IsNullOrEmpty(hospitalsUnits.Unit.Name))
                    pProcedure.ExtraDescription = "(" + hospitalsUnits.Unit.Name + ")";
            }
        }

        private void CheckMasterActionPrivilege()
        {
            if (MasterAction != null && MasterAction is HealthCommittee)
            {
                HealthCommittee pMaster = MasterAction as HealthCommittee;
                if (!pMaster.IsCancelled)
                {
                    if (!pMaster.CurrentStateDefID.Equals(HealthCommittee.States.CommitteeAcceptance))
                    {
                        throw new Exception(SystemMessage.GetMessage(641));
                    }
                }
            }
        }

        // Uçucu, Yatan ve Normal muayeneleri ayırmak için, DescriptionForWorkList set edilir
        public void SetDescriptionForWorkList()
        {
            bool setDescriptionForWorkList = false;
            //if (this.MasterAction != null && this.MasterAction is HealthCommittee)
            //{
            //    HealthCommittee hc = (HealthCommittee)this.MasterAction;
            //    if(hc != null && hc.HCRequestReason.ReasonForExamination != null)
            //    {
            //        if(hc.HCRequestReason.ReasonForExamination.HealthCommitteeType == HealthCommitteeTypeEnum.FlierCommittee || hc.HCRequestReason.ReasonForExamination.HealthCommitteeType == HealthCommitteeTypeEnum.AdHocFlierCommittee)
            //        {
            //            this.DescriptionForWorkList = "Sağlık Kurulu Muayenesi (Uçucu)";
            //            setDescriptionForWorkList = true;
            //        }
            //    }
            //}
            if (!setDescriptionForWorkList)
            {
                if (Episode != null && (Episode.PatientStatus != PatientStatusEnum.Outpatient))
                {
                    DescriptionForWorkList = TTUtils.CultureService.GetText("M26794", "Sağlık Kurulu Muayenesi (Yatan)");
                    setDescriptionForWorkList = true;
                }
            }
            if (!setDescriptionForWorkList)
                DescriptionForWorkList = TTUtils.CultureService.GetText("M26793", "Sağlık Kurulu Muayenesi (Normal)");
        }




        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HealthCommitteeExamination).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HealthCommitteeExamination.States.New && toState == HealthCommitteeExamination.States.Examination)
                PreTransition_New2Examination();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HealthCommitteeExamination).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HealthCommitteeExamination.States.Examination && toState == HealthCommitteeExamination.States.Cancelled)
                PostTransition_Examination2Cancelled();
            else if (fromState == HealthCommitteeExamination.States.Examination && toState == HealthCommitteeExamination.States.Completed)
                PostTransition_Examination2Completed();
            else if (fromState == HealthCommitteeExamination.States.Completed && toState == HealthCommitteeExamination.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == HealthCommitteeExamination.States.New && toState == HealthCommitteeExamination.States.Examination)
                PostTransition_New2Examination();
            else if (fromState == HealthCommitteeExamination.States.New && toState == HealthCommitteeExamination.States.PatientNoShown)
                PostTransition_New2PatientNoShown();
            else if (fromState == HealthCommitteeExamination.States.InsertedIntoQueue && toState == HealthCommitteeExamination.States.Examination)
                PostTransition_InsertedIntoQueue2Examination();
            else if (fromState == HealthCommitteeExamination.States.InsertedIntoQueue && toState == HealthCommitteeExamination.States.PatientNoShown)
                PostTransition_InsertedIntoQueue2PatientNoShown();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HealthCommitteeExamination).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HealthCommitteeExamination.States.Examination && toState == HealthCommitteeExamination.States.Completed)
                UndoTransition_Examination2Completed(transDef);
        }

    }
}