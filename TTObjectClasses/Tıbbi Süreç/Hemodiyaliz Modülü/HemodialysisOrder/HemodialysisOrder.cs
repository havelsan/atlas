
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
    /// Diyaliz Emrinin Verildiği Nesnedir.
    /// </summary>
    public partial class HemodialysisOrder : PlannedAction, IPlanPlannedAction, IWorkListEpisodeAction
    {
        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true)
            {
                CurrentStateDefID = HemodialysisOrder.States.Request;
            }
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
                case "DIALYSISREQUEST":
                    {
                        HemodialysisRequest value = (HemodialysisRequest)newValue;
                        #region DIALYSISREQUEST_SetParentScript
                        if (value != null)
                        {
                            SetMandatoryEpisodeActionProperties(value, TreatmentDiagnosisUnit, value.FromResource, true);
                            //Medula için gerekli
                            MedulaHastaKabul = value.MedulaHastaKabul;
                        }
                        #endregion DIALYSISREQUEST_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        public override bool IsNewSubEpisodeNeeded()
        {
            if (base.IsNewSubEpisodeNeeded() == false)
                return false;

            if (SubEpisode.IsSGK)
            {
                // HemodialysisRequest in HemodialysisOrder larından sadece 1 tanesi SubEpisode oluşturuyor, diğer HemodialysisOrder lar bu SubEpisode a giriyor
                foreach (HemodialysisOrder dOrder in HemodialysisRequest.HemodialysisOrders)
                {
                    if (dOrder.ObjectID != ObjectID && dOrder.GetSubEpisodeCreatedByMe() != null)
                        return false;
                }
                // 1062 = Nefroloji, 1584 = Çocuk Nefrolojisi
                if (!Episode.IsSGKSubEpisodeProtocolExists(new String[] { "1062", "1584" }, new String[] { "G", "Y" }, "1"))
                    return true;

                // Önceden bu metod ile de kontrol yapılıyordu PhysiotherapyOrder.PostUpdate metodunda, şimdilik kapattım ileride gerek olursa açılması lazım (MDZ)
                // Episode.Patient.SuitableToCreateNewDailySubEpisode(SubEpisodeSpeciality);  
            }

            return false;
        }

        // SEP in değiştirilmesi gereken propertyleri varsa bu metodda set edilmeli
        public override void FillLocalSEPProperties(ref SubEpisodeProtocol sep)
        {
            sep.MedulaTedaviTipi = TedaviTipi.GetTedaviTipi("1");

            // Yatan hastalarda bağlı takip olarak son yatış takibi set edilir
            if (Episode.PatientStatus == PatientStatusEnum.Inpatient)
            {
                InPatientTreatmentClinicApplication iPTCA = Episode.InPatientTreatmentClinicApplications.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled &&
                                                                x.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully).OrderByDescending(x => x.ClinicInpatientDate).FirstOrDefault();

                if (iPTCA != null && iPTCA.GetSubEpisodeCreatedByMe() != null && iPTCA.GetSubEpisodeCreatedByMe().LastActiveSubEpisodeProtocol != null)
                    sep.ParentSEP = iPTCA.GetSubEpisodeCreatedByMe().LastActiveSubEpisodeProtocol;
            }
        }

        protected override void PreInsert()
        {
            #region PreInsert

            MasterResource = (ResSection)TreatmentDiagnosisUnit;// todo merve?????????
            base.PreInsert();

            #endregion PreInsert
        }


        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();
            if (SessionCount != null)
            {
                Amount = SessionCount;// todo merve?????????
            }
            else
            {
                Amount = 0;
            }

            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate(); if (SessionCount != null)
            {
                Amount = SessionCount;
            }

            #endregion PostUpdate
        }

        protected void PostTransition_Request2Plan()
        {
            // From State : Aborted   To State : Cancelled
            #region PostTransition_Request2Plan

            HemodialysisRequest.CurrentStateDefID = HemodialysisRequest.States.Plan;

            #endregion PostTransition_Request2Plan
        }
        protected void PostTransition_Request2Therapy()
        {
            // From State : Aborted   To State : Cancelled
            #region PostTransition_Request2Therapy

            HemodialysisRequest.CurrentStateDefID = HemodialysisRequest.States.Procedure;

            #endregion PostTransition_Request2Thera
        }
        protected void PostTransition_Plan2Therapy()
        {
            // From State : Aborted   To State : Cancelled
            #region PostTransition_Plan2Therapy

            HemodialysisRequest.CurrentStateDefID = HemodialysisRequest.States.Procedure;

            #endregion PostTransition_Plan2Therapy
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HemodialysisOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;


            if (fromState == HemodialysisOrder.States.Request && toState == HemodialysisOrder.States.Plan)
                PostTransition_Request2Plan();
            if (fromState == HemodialysisOrder.States.Request && toState == HemodialysisOrder.States.Therapy)
                PostTransition_Request2Therapy();
            if (fromState == HemodialysisOrder.States.Plan && toState == HemodialysisOrder.States.Therapy)
                PostTransition_Plan2Therapy();
            if (toState == HemodialysisOrder.States.Completed)
            {
                HemodialysisRequest.CurrentStateDefID = HemodialysisRequest.States.Completed;
            }
            if (toState == HemodialysisOrder.States.Cancelled)
            {
                HemodialysisRequest.CurrentStateDefID = HemodialysisRequest.States.Cancelled;
            }


            //if (fromState == HemodialysisOrder.States.Therapy && toState == HemodialysisOrder.States.Cancelled)
            //    PostTransition_Therapy2Cancelled();
            //else if (fromState == HemodialysisOrder.States.Therapy && toState == HemodialysisOrder.States.Completed)
            //    PostTransition_Therapy2Completed();
            //else if (fromState == HemodialysisOrder.States.ApprovalForAbort && toState == HemodialysisOrder.States.Aborted)
            //    PostTransition_ApprovalForAbort2Aborted();
            //else if (fromState == HemodialysisOrder.States.Completed && toState == HemodialysisOrder.States.Cancelled)
            //    PostTransition_Completed2Cancelled();
            //else if (fromState == HemodialysisOrder.States.Aborted && toState == HemodialysisOrder.States.Cancelled)
            //    PostTransition_Aborted2Cancelled();
            //else if (fromState == HemodialysisOrder.States.Plan && toState == HemodialysisOrder.States.Cancelled)
            //    PostTransition_Plan2Cancelled();

            //if (toState == States.Therapy)
            //    this.SubEpisode.ArrangeMeOrCreateNewSubEpisode(this, false);  // SubEpisode ve SubEpisodeProtocol oluşturup meduladan takip alan metod
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HemodialysisOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            //if (fromState == HemodialysisOrder.States.RequestAcception && toState == HemodialysisOrder.States.Therapy)
            //    UndoTransition_RequestAcception2Therapy(transDef);
            //else if (fromState == HemodialysisOrder.States.Plan && toState == HemodialysisOrder.States.Therapy)
            //    UndoTransition_Plan2Therapy(transDef);
        }


        #region Methods

        public override List<int> AllowedMedulaTedaviTipi()
        {
            List<int> typeList = new List<int>();
            typeList.Add(1); //'Diyaliz' Tedavi Türünde
            return typeList;
        }

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.DialysisOrder);
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
                    carrier.MasterResource = "RESTREATMENTDIAGNOSISUNIT";
                    //SubResource değeri değişirse public HemodialysisOrderDetail(HemodialysisOrder HemodialysisOrder,Appointment appointment): this(HemodialysisOrder.ObjectContext) da da değiştirilmeli
                    carrier.SubResource = "RESEQUIPMENT";
                    carrier.RelationParentName = "TREATMENTDIAGNOSISUNIT";
                    _appointmentList.Add(carrier);
                }
                ClearAppointmentCarrierDynamicFields(_appointmentList);
                foreach (AppointmentCarrier appointmentCarrier in _appointmentList)
                {
                    appointmentCarrier.AppointmentCount = Convert.ToInt32(Amount);
                    if (Convert.ToInt32(Duration) > 0)
                        appointmentCarrier.AppointmentDuration = Convert.ToInt32(Duration);
                    if (TreatmentDiagnosisUnit != null)
                    {
                        string masterResFilter = " OBJECTID IN ('" + TreatmentDiagnosisUnit.ObjectID.ToString() + "'";
                        if (GetMySiblingObjectListForAppointment() != null)
                        {
                            foreach (PlannedAction spa in GetMySiblingObjectListForAppointment())
                            {
                                masterResFilter += ",'" + ((HemodialysisOrder)spa).TreatmentDiagnosisUnit.ObjectID.ToString() + "'";
                            }
                        }
                        masterResFilter += ")";

                        appointmentCarrier.MasterResourceFilter = masterResFilter;
                        //appointmentCarrier.MasterResourceFilter = " OBJECTID = '"  + this.TreatmentDiagnosisUnit.ObjectID.ToString() + "'";
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


        private BindingList<HemodialysisOrder> _mySiblingHemodialysisOrderObjects;
        private BindingList<PlannedAction> _mySiblingPlannedActionObjects;
        public BindingList<PlannedAction> GetMySiblingObjectListForAppointment()
        {
            _mySiblingHemodialysisOrderObjects = new BindingList<HemodialysisOrder>();
            _mySiblingPlannedActionObjects = new BindingList<PlannedAction>();
            _mySiblingHemodialysisOrderObjects = HemodialysisOrder.GetMySiblingObjectsForAppointment(ObjectContext, Episode.ObjectID.ToString(), ObjectID.ToString());
            foreach (HemodialysisOrder dialysisOrder in _mySiblingHemodialysisOrderObjects)
            {
                ITTObject itt = (ITTObject)dialysisOrder;
                HemodialysisOrder dor = (HemodialysisOrder)itt.Original;

                if (dor.CurrentStateDefID == HemodialysisOrder.States.Plan || dialysisOrder.CurrentStateDefID == HemodialysisOrder.States.Plan)
                    _mySiblingPlannedActionObjects.Add((PlannedAction)dialysisOrder);
            }
            return _mySiblingPlannedActionObjects;
        }

        public override SubactionProcedureFlowable CreateOrderDetail(Appointment appointment)
        {
            return new HemodialysisOrderDetail(this, appointment);
        }

        public override SubactionProcedureFlowable CreateOrderDetail()
        {
            return new HemodialysisOrderDetail(this);
        }
        public override void CreateAppointmentForOrderDetail(SubactionProcedureFlowable orderDetail)
        {
            HemodialysisOrderDetail diaOrderDetail = (HemodialysisOrderDetail)orderDetail;
            Appointment newAppointment = (Appointment)diaOrderDetail.ObjectContext.CreateObject("Appointment");

            DateTime appDate = Convert.ToDateTime(diaOrderDetail.WorkListDate.Value.Date);
            DateTime startDateTime = diaOrderDetail.WorkListDate.Value;
            DateTime endDateTime = diaOrderDetail.WorkListDate.Value.AddMinutes(((HemodialysisOrder)diaOrderDetail.OrderObject).Duration.Value);
            IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(diaOrderDetail.ObjectContext, AppointmentDefinitionEnum.DialysisOrder);
            if (appDefList.Count > 0)
            {
                newAppointment.AppointmentDefinition = (AppointmentDefinition)appDefList[0];
            }
            //if (newAppointment.AppointmentDefinition.GiveToMaster == true)
            //    newAppointment.MasterResource = null;
            //else
                newAppointment.MasterResource = diaOrderDetail.MasterResource;
            newAppointment.Patient = diaOrderDetail.Episode.Patient;
            newAppointment.StartTime = startDateTime;
            newAppointment.EndTime = endDateTime;
            newAppointment.CurrentStateDefID = Appointment.States.New;
            newAppointment.Schedule = null;
            newAppointment.BreakAppointment = false;
            newAppointment.Notes = TTUtils.CultureService.GetText("M26694", "Planlamasız Oluşturuldu") + " / ";
            newAppointment.Notes += diaOrderDetail.ProcedureObject.Name;
            newAppointment.AppointmentType = null;
            diaOrderDetail.TreatmentEquipment = ((HemodialysisOrder)diaOrderDetail.OrderObject).TreatmentEquipment;
            diaOrderDetail.SessionDate = startDateTime;
            newAppointment.Resource = diaOrderDetail.TreatmentEquipment;
            newAppointment.AppDate = appDate;
            newAppointment.AppointmentDefinition = AppointmentDefinition.GetAppointmentDefinitionByName(ObjectContext, AppointmentDefinitionEnum.DialysisOrder).FirstOrDefault();
            if (((HemodialysisOrder)diaOrderDetail.OrderObject).AppointmentCarrierList.Count > 0)
                newAppointment.AppointmentCarrier = ((HemodialysisOrder)diaOrderDetail.OrderObject).AppointmentCarrierList[0];
            newAppointment.Action = null;
            newAppointment.SubActionProcedure = (SubActionProcedure)diaOrderDetail;
        }

        public override void SetCurrentStateToTherapy()
        {
            if (CurrentStateDefID == HemodialysisOrder.States.Plan)
            {
                CurrentStateDefID = HemodialysisOrder.States.Therapy;
                Update();
            }
        }

        public override Resource GetDefaultAppointmentResource()
        {
            return this.TreatmentEquipment;
        }

        #endregion Methods
    }
}