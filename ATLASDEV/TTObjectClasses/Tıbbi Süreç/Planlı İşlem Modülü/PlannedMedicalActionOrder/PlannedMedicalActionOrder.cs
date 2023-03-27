
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
    /// Planlı Tıbbi İşlem Emri
    /// </summary>
    public partial class PlannedMedicalActionOrder : PlannedAction, IAllocateSpeciality, IOldActions, IPlanPlannedAction, IReasonOfReject, IWorkListEpisodeAction
    {
        public partial class GetPlannedMedicalActionOrders_Class : TTReportNqlObject
        {
        }

        public partial class PlannedMedicalActionAcceptionReportNQL_Class : TTReportNqlObject
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
                case "PLANNEDMEDICALACTIONREQUEST":
                    {
                        PlannedMedicalActionRequest value = (PlannedMedicalActionRequest)newValue;
                        #region PLANNEDMEDICALACTIONREQUEST_SetParentScript
                        if (value != null)
                        {
                            MedulaHastaKabul = value.MedulaHastaKabul;
                            SetMandatoryEpisodeActionProperties(value, TreatmentUnit, value.FromResource, true);
                        }
                        #endregion PLANNEDMEDICALACTIONREQUEST_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PreInsert()
        {
            #region PreInsert
            MasterResource = (ResSection)TreatmentUnit;
            base.PreInsert();

            #endregion PreInsert
        }

        protected void PostTransition_Aborted2Cancelled()
        {
            // From State : Aborted   To State : Cancelled
            #region PostTransition_Aborted2Cancelled

            Cancel();
            #endregion PostTransition_Aborted2Cancelled
        }

        protected void PostTransition_ApprovalForAbort2Aborted()
        {
            // From State : ApprovalForAbort   To State : Aborted
            #region PostTransition_ApprovalForAbort2Aborted

            foreach (PlannedMedicalActionOrderDetail orderDetail in OrderDetails)
            {
                if (orderDetail.CurrentStateDefID == PlannedMedicalActionOrderDetail.States.Execution)
                {
                    orderDetail.CurrentStateDefID = PlannedMedicalActionOrderDetail.States.Cancelled;
                }
            }
            #endregion PostTransition_ApprovalForAbort2Aborted
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled

            Cancel();
            #endregion PostTransition_Completed2Cancelled
        }

        protected void PostTransition_Plan2Cancelled()
        {
            // From State : Plan   To State : Cancelled
            #region PostTransition_Plan2Cancelled

            Cancel();
            #endregion PostTransition_Plan2Cancelled
        }

        protected void UndoTransition_Plan2Therapy(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Plan   To State : Therapy
            #region UndoTransition_Plan2Therapy

            NoBackStateBack();
            #endregion UndoTransition_Plan2Therapy
        }

        protected void UndoTransition_RequestAcception2Therapy(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Therapy
            #region UndoTransition_RequestAcception2Therapy

            NoBackStateBack();
            #endregion UndoTransition_RequestAcception2Therapy
        }

        protected void PostTransition_Therapy2Cancelled()
        {
            // From State : Therapy   To State : Cancelled
            #region PostTransition_Therapy2Cancelled

            Cancel();
            #endregion PostTransition_Therapy2Cancelled
        }

        #region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true)
            {
                CurrentStateDefID = PlannedMedicalActionOrder.States.RequestAcception;
            }
        }


        //
        //
        //        public override List<int> AllowedMedulaTedaviTipi()
        //        {
        //            List<int> typeList=new List<int>();
        //            typeList.Add(2);//Fiziksel Tedavi ve Rehabilitasyon
        //            return typeList;
        //        }

        public override void CreateAppointmentForOrderDetail(SubactionProcedureFlowable orderDetail)
        {
            PlannedMedicalActionOrderDetail pmaOrderDetail = (PlannedMedicalActionOrderDetail)orderDetail;
            Appointment newAppointment = (Appointment)pmaOrderDetail.ObjectContext.CreateObject("Appointment");

            DateTime appDate = Convert.ToDateTime(pmaOrderDetail.WorkListDate.Value.Date);
            DateTime startDateTime = pmaOrderDetail.WorkListDate.Value;
            DateTime endDateTime = pmaOrderDetail.WorkListDate.Value.AddMinutes(((PlannedMedicalActionOrder)pmaOrderDetail.OrderObject).Duration.Value);
            IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(pmaOrderDetail.ObjectContext, AppointmentDefinitionEnum.PlannedMedicalActionOrder);
            if (appDefList.Count > 0)
            {
                newAppointment.AppointmentDefinition = (AppointmentDefinition)appDefList[0];
            }
            if (newAppointment.AppointmentDefinition.GiveToMaster == true)
                newAppointment.MasterResource = null;
            else
                newAppointment.MasterResource = pmaOrderDetail.MasterResource;
            newAppointment.Patient = pmaOrderDetail.Episode.Patient;
            newAppointment.StartTime = startDateTime;
            newAppointment.EndTime = endDateTime;
            newAppointment.CurrentStateDefID = Appointment.States.New;
            newAppointment.Schedule = null;
            newAppointment.BreakAppointment = false;
            newAppointment.Notes = TTUtils.CultureService.GetText("M26694", "Planlamasız Oluşturuldu") + " / ";
            newAppointment.Notes += pmaOrderDetail.ProcedureObject.Name;
            newAppointment.AppointmentType = null;
            newAppointment.Resource = pmaOrderDetail.MasterResource;
            newAppointment.AppDate = appDate;
            if (((PlannedMedicalActionOrder)pmaOrderDetail.OrderObject).AppointmentCarrierList.Count > 0)
                newAppointment.AppointmentCarrier = ((PlannedMedicalActionOrder)pmaOrderDetail.OrderObject).AppointmentCarrierList[0];
            newAppointment.Action = null;
            newAppointment.SubActionProcedure = (SubActionProcedure)pmaOrderDetail;
        }

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.PlannedMedicalActionOrder);
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
                    _appointmentList.Add(carrier);
                }
                //her public appcarrier listesinin başında çağırılmalı.
                ClearAppointmentCarrierDynamicFields(_appointmentList);
                foreach (AppointmentCarrier appointmentCarrier in _appointmentList)
                {
                    appointmentCarrier.AppointmentCount = Convert.ToInt32(Amount);
                    if (Convert.ToInt32(Duration) > 0)
                        appointmentCarrier.AppointmentDuration = Convert.ToInt32(Duration);
                    if (TreatmentUnit != null)
                    {
                        string masterResFilter = " OBJECTID IN ('" + TreatmentUnit.ObjectID.ToString() + "'";
                        if (GetMySiblingObjectListForAppointment() != null)
                        {
                            foreach (PlannedAction spa in GetMySiblingObjectListForAppointment())
                            {
                                masterResFilter += ",'" + ((PlannedMedicalActionOrder)spa).TreatmentUnit.ObjectID.ToString() + "'";
                            }
                        }
                        masterResFilter += ")";

                        appointmentCarrier.MasterResourceFilter = masterResFilter;//" OBJECTID = '"  + this.TreatmentDiagnosisUnit.ObjectID.ToString() + "'";
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

        private BindingList<PlannedMedicalActionOrder> _mySiblingPlannedMedicalActionOrderObjects;
        private BindingList<PlannedAction> _mySiblingPlannedActionObjects;
        public BindingList<PlannedAction> GetMySiblingObjectListForAppointment()
        {
            _mySiblingPlannedMedicalActionOrderObjects = new BindingList<PlannedMedicalActionOrder>();
            _mySiblingPlannedActionObjects = new BindingList<PlannedAction>();
            _mySiblingPlannedMedicalActionOrderObjects = PlannedMedicalActionOrder.GetMySiblingObjectsForAppointment(ObjectContext, Episode.ObjectID.ToString(), ObjectID.ToString());
            foreach (PlannedMedicalActionOrder plannedMedicalActionOrder in _mySiblingPlannedMedicalActionOrderObjects)
            {
                ITTObject itt = (ITTObject)plannedMedicalActionOrder;
                PlannedMedicalActionOrder por = (PlannedMedicalActionOrder)itt.Original;

                if (por.CurrentStateDefID == PlannedMedicalActionOrder.States.Plan || plannedMedicalActionOrder.CurrentStateDefID == PlannedMedicalActionOrder.States.Plan)
                    _mySiblingPlannedActionObjects.Add((PlannedAction)plannedMedicalActionOrder);
            }
            return _mySiblingPlannedActionObjects;
        }



        public override SubactionProcedureFlowable CreateOrderDetail(Appointment appointment)
        {
            return new PlannedMedicalActionOrderDetail(this, appointment);
        }

        public override SubactionProcedureFlowable CreateOrderDetail()
        {
            return new PlannedMedicalActionOrderDetail(this);
        }

        public override void SetCurrentStateToTherapy()
        {
            if (CurrentStateDefID == PlannedMedicalActionOrder.States.Plan)
            {
                CurrentStateDefID = PlannedMedicalActionOrder.States.Therapy;
                Update();
            }
        }

        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList = base.OldActionPropertyList();
            if (propertyList == null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();
            //------------------------------------
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M20566", "Protokol No"), Common.ReturnObjectAsString(ProtocolNo)));
            if (PlannedMedicalActionRequest.ProcedureDoctor != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M16661", "İstek Yapan Doktor"), Common.ReturnObjectAsString(PlannedMedicalActionRequest.ProcedureDoctor.Name)));
            if (TreatmentUnit != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M23046", "Tedavi Ünitesi"), Common.ReturnObjectAsString(TreatmentUnit.Name)));
            if (ProcedureDoctor != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M26231", "İşlemi Yapacak Kullanıcı"), Common.ReturnObjectAsString(ProcedureDoctor.Name)));
            //---------------------------------------
            return propertyList;
        }

        public override void CompleteMySubActionProcedures()
        {
            // PlannedMedicalActionOrderDetail in sonuncusu tamamlaninca   PlannedMedicalActionOrder da tamamlandigi icin CompleteMySubActionProcedures methodu override edildi. 
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PlannedMedicalActionOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PlannedMedicalActionOrder.States.Aborted && toState == PlannedMedicalActionOrder.States.Cancelled)
                PostTransition_Aborted2Cancelled();
            else if (fromState == PlannedMedicalActionOrder.States.ApprovalForAbort && toState == PlannedMedicalActionOrder.States.Aborted)
                PostTransition_ApprovalForAbort2Aborted();
            else if (fromState == PlannedMedicalActionOrder.States.Completed && toState == PlannedMedicalActionOrder.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == PlannedMedicalActionOrder.States.Plan && toState == PlannedMedicalActionOrder.States.Cancelled)
                PostTransition_Plan2Cancelled();
            else if (fromState == PlannedMedicalActionOrder.States.Therapy && toState == PlannedMedicalActionOrder.States.Cancelled)
                PostTransition_Therapy2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PlannedMedicalActionOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PlannedMedicalActionOrder.States.Plan && toState == PlannedMedicalActionOrder.States.Therapy)
                UndoTransition_Plan2Therapy(transDef);
            else if (fromState == PlannedMedicalActionOrder.States.RequestAcception && toState == PlannedMedicalActionOrder.States.Therapy)
                UndoTransition_RequestAcception2Therapy(transDef);
        }

    }
}