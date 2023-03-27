
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
    /// Hasta Kontrol Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public partial class FollowUpExamination : PhysicianApplication, IReasonOfReject, IAppointmentDef, IAllocateSpeciality, ICheckTreatmentMaterialIsEmpty, IOAExamination, IWorkListEpisodeAction, ITreatmentMaterialCollection
    {
        public partial class OLAP_GetFollowUpExamination_Class : TTReportNqlObject
        {
        }

        public partial class GetFollowUpExaminationNQL_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledFollowUpExamination_Class : TTReportNqlObject
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

        protected override void PreUpdate()
        {
            #region PreUpdate

            base.PreUpdate();

            foreach (SingleNursingOrder nursingOrder in SingleNursingOrders)
            {
                if (nursingOrder.CurrentStateDefID == SingleNursingOrder.States.New)
                {
                    nursingOrder.FromResource = FromResource;
                    nursingOrder.MasterResource = MasterResource;
                    nursingOrder.Episode = Episode;
                    nursingOrder.Frequency = TTObjectClasses.FrequencyEnum.Q24H;
                    nursingOrder.AmountForPeriod = 1;
                    nursingOrder.RecurrenceDayAmount = 1;
                }
            }
            #endregion PreUpdate
        }

        protected void PostTransition_Examination2Cancelled()
        {
            // From State : Examination   To State : Cancelled
            #region PostTransition_Examination2Cancelled

            Cancel();
            #endregion PostTransition_Examination2Cancelled
        }

        protected void PostTransition_Examination2NursingorderDetails()
        {
            // From State : Examination   To State : NursingorderDetails
            #region PostTransition_Examination2NursingorderDetails

            CreateNursingOrderDetailsAndCompleteOrder();
            #endregion PostTransition_Examination2NursingorderDetails
        }

        protected void PreTransition_Examination2Completed()
        {
            // From State : Examination   To State : Completed
            #region PreTransition_Examination2Completed


            foreach (SingleNursingOrder nursingOrder in SingleNursingOrders)
            {
                if (nursingOrder.CurrentStateDefID == SingleNursingOrder.States.New)
                    throw new Exception(SystemMessage.GetMessage(666));
            }

            #endregion PreTransition_Examination2Completed
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled

            Cancel();
            #endregion PostTransition_Completed2Cancelled
        }

        protected void PostTransition_Approval2NursingorderDetails()
        {
            // From State : Approval   To State : NursingorderDetails
            #region PostTransition_Approval2NursingorderDetails

            CreateNursingOrderDetailsAndCompleteOrder();
            #endregion PostTransition_Approval2NursingorderDetails
        }

        protected void PostTransition_Approval2Cancelled()
        {
            // From State : Approval   To State : Cancelled
            #region PostTransition_Approval2Cancelled

            Cancel();
            #endregion PostTransition_Approval2Cancelled
        }

        protected void PreTransition_New2Examination()
        {
            // From State : New   To State : Examination
            #region PreTransition_New2Examination

            AddFollowUpExaminationProcedure();
            if (OlapDate == null)
                OlapDate = DateTime.Now;

            #endregion PreTransition_New2Examination
        }

        protected void PreTransition_Appointment2Examination()
        {
            // From State : Appointment   To State : Examination
            #region PreTransition_Appointment2Examination

            AddFollowUpExaminationProcedure();
            if (OlapDate == null)
                OlapDate = DateTime.Now;

            #endregion PreTransition_Appointment2Examination
        }

        #region Methods

        #region ICheckTreatmentMaterialIsEmpty Members
        public bool? GetIsTreatmentMaterialEmpty()
        {
            return IsTreatmentMaterialEmpty;
        }
        public void SetIsTreatmentMaterialEmpty(bool? value)
        {
            IsTreatmentMaterialEmpty = value;
        }

        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection GetTreatmentMaterials()
        {
            return TreatmentMaterials;
        }
        #endregion
        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.FollowUpExamination);
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
                    carrier.MasterResource = "ResSection";
                    carrier.SubResource = "ResUser";
                    carrier.RelationParentName = "";
                    carrier.UserTypes.Add(UserTypeEnum.Doctor);
                    carrier.UserTypes.Add(UserTypeEnum.Nurse);

                    _appointmentList.Add(carrier);
                }
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
                return ActionTypeEnum.FollowUpExamination;
            }
        }




        protected override void BeforeSetSubEpisode(SubEpisode subEpisode)
        {
            base.BeforeSetSubEpisode(subEpisode);

            bool patientExaminationFound = false;
            foreach (PatientExamination patientExamination in subEpisode.Episode.PatientExaminations)
            {
                if ((patientExamination.MasterResource == MasterResource && patientExamination.CurrentStateDefID == PatientExamination.States.Completed) || MasterAction is AdmissionAppointment)
                {
                    //                    if(!Common.CurrentUser.IsSuperUser)
                    //                    {
                    //                        if(patientExamination.ProcedureDoctor != null && Common.CurrentResource.ObjectID != patientExamination.ProcedureDoctor.ObjectID)
                    //                            throw new Exception ( "Kontrol Muayenesi ancak Hastanın Muayenesini gerçekleştiren '" + patientExamination.ProcedureDoctor + " tarafından  başlatılabilir."  );
                    //                    }

                    PatientGroupDefinition patientGroupDef = subEpisode.Episode.GetMyPatientGroupDefinition();
                    double limit = (double)(patientGroupDef.EpisodeClosingDayLimit == null ? 0 : patientGroupDef.EpisodeClosingDayLimit);
                    //if(limit == 0 || limit == null)
                    if (limit == 0)
                        limit = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("CLOSEEPISODELASTUPDATEDAYLIMIT", "10"));
                    double templimit = (double)(-1 * limit);
                    DateTime LimitLastUpdateDate = Convert.ToDateTime(Common.RecTime()).AddDays(templimit).Date;

                    if ((limit > 0) && patientExamination.RequestDate.Value.Date < LimitLastUpdateDate)
                    {
                        throw new Exception(SystemMessage.GetMessage(667));
                    }
                    patientExaminationFound = true;
                }
            }
            if (patientExaminationFound == false)
            {
                //TODO BG
                //throw new Exception(SystemMessage.GetMessage(668));
            }
            subEpisode.Episode.OpenEpisode();
        }

        private void CreateNursingOrderDetailsAndCompleteOrder()
        {
            foreach (SingleNursingOrder examinationNursingOrder in _SingleNursingOrders)
            {
                if (examinationNursingOrder.CurrentStateDefID == SingleNursingOrder.States.New)
                {
                    examinationNursingOrder.CreateOrderDetails();
                    examinationNursingOrder.CurrentStateDefID = SingleNursingOrder.States.Planned;
                }
            }
        }

        public override void CompleteMyNewAppoinments()
        {
            if (TransDef != null)
            {
                foreach (Appointment app in EpisodeAction.GetMyNewAppointments(ObjectID))
                {
                    if (TransDef.ToStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || TransDef.ToStateDef.Status == StateStatusEnum.Cancelled || TransDef.ToStateDefID == FollowUpExamination.States.New)
                    {
                        app.CurrentStateDefID = Appointment.States.Cancelled;
                    }
                    else if (TransDef.ToStateDef.Status == StateStatusEnum.Uncompleted || TransDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {

                        app.CurrentStateDefID = Appointment.States.Completed;
                    }
                }
            }
        }
        public override void Cancel()
        {
            base.Cancel();
            foreach (SingleNursingOrder singleNursingOrder in SingleNursingOrders)
            {
                singleNursingOrder.Cancel();
            }
        }

        /*public void CompleteMyExaminationProcedures()
        {
            foreach(FollowUpExaminationProcedure followUpExaminationProcedure in this.FollowUpExaminationProcedures)
            {
                if(followUpExaminationProcedure.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                    followUpExaminationProcedure.CurrentStateDefID = FollowUpExaminationProcedure.States.Completed;
            }
        }*/

        protected void AddFollowUpExaminationProcedure()
        {
            // Kontrol muayene hizmeti oluşması için kontrol muayene procedürü atar
            bool muayeneEkle = true;
            Guid muayeneGuid = ProcedureDefinition.FollowUpExaminationProcedureObjectId;
            RelationshipDefinition relationshipDefinition = null;

            foreach (FollowUpExaminationProcedure examinationProcedure in FollowUpExaminationProcedures)
            {
                if (examinationProcedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    if (examinationProcedure.ProcedureObject.ObjectID.Equals(muayeneGuid))
                    {
                        muayeneEkle = false;
                        break;
                    }
                }
            }

            FollowUpExaminationProcedure followUpExaminationProcedure = null;

            if (muayeneEkle)
            {
                followUpExaminationProcedure = new FollowUpExaminationProcedure(this, muayeneGuid.ToString());

                if (Episode.OpeningDate != null)
                    followUpExaminationProcedure.PricingDate = SubEpisode.OpeningDate;
            }
        }

        public override BaseAdditionalApplication CreateBaseAdditionalApplication()
        {
            return new FollowUpExaminationAdditionalApplication(ObjectContext);
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(FollowUpExamination).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == FollowUpExamination.States.Examination && toState == FollowUpExamination.States.Completed)
                PreTransition_Examination2Completed();
            else if (fromState == FollowUpExamination.States.New && toState == FollowUpExamination.States.Examination)
                PreTransition_New2Examination();
            else if (fromState == FollowUpExamination.States.Appointment && toState == FollowUpExamination.States.Examination)
                PreTransition_Appointment2Examination();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(FollowUpExamination).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == FollowUpExamination.States.Examination && toState == FollowUpExamination.States.Cancelled)
                PostTransition_Examination2Cancelled();
            else if (fromState == FollowUpExamination.States.Examination && toState == FollowUpExamination.States.NursingorderDetails)
                PostTransition_Examination2NursingorderDetails();
            else if (fromState == FollowUpExamination.States.Completed && toState == FollowUpExamination.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == FollowUpExamination.States.Approval && toState == FollowUpExamination.States.NursingorderDetails)
                PostTransition_Approval2NursingorderDetails();
            else if (fromState == FollowUpExamination.States.Approval && toState == FollowUpExamination.States.Cancelled)
                PostTransition_Approval2Cancelled();
        }

    }
}