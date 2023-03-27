
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
    /// Hiperbarik Oksijen Tedavi Emirinin Verildiği Nesnedir
    /// </summary>
    public partial class HyperbaricOxygenTreatmentOrder : BaseHyperbaricOxygenTreatmentOrder, IWorkListEpisodeAction, IOldActions, IReasonOfReject, IAppointmentDef, IAllocateSpeciality, IPlanPlannedAction, ICreateSubEpisode
    {
        public partial class HyperbaricAcceptionReportNQL_Class : TTReportNqlObject
        {
        }

        public partial class HyperResultReportQuery_Class : TTReportNqlObject
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
                case "HYPEROXYGENTREATMENTREQUEST":
                    {
                        HyperbarikOxygenTreatmentRequest value = (HyperbarikOxygenTreatmentRequest)newValue;
                        #region HYPEROXYGENTREATMENTREQUEST_SetParentScript
                        if (value != null)
                        {
                            SetMandatoryEpisodeActionProperties(value, TreatmentDiagnosisUnit, value.FromResource, true);
                            MedulaHastaKabul = value.MedulaHastaKabul;
                        }
                        #endregion HYPEROXYGENTREATMENTREQUEST_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        // Yeni SubEpisode oluşturulmasına karar veren metod
        public override bool IsNewSubEpisodeNeeded()
        {
            if (base.IsNewSubEpisodeNeeded() == false)
                return false;

            if (SubEpisode.IsSGK)
            {
                // HyperbaricOxygenTreatmentRequest in HyperbaricOxygenTreatmentOrder larından sadece 1 tanesi SubEpisode oluşturuyor, diğer HyperbaricOxygenTreatmentOrder lar bu SubEpisode a giriyor
                foreach (HyperbaricOxygenTreatmentOrder hOrder in HyperOxygenTreatmentRequest.HyperbaricOxygenTreatmentOrders)
                {
                    if (hOrder.ObjectID != ObjectID && hOrder.GetSubEpisodeCreatedByMe() != null)
                        return false;
                }

                // 4300 : Sualtı Hekimliği ve Hiperbarik Tıp                
                if (!Episode.IsSGKSubEpisodeProtocolExists(new String[] { "4300" }, new String[] { "G", "Y" }, "7"))
                    return true;

                // Önceden bu metod ile de kontrol yapılıyordu PhysiotherapyOrder.PostUpdate metodunda, şimdilik kapattım ileride gerek olursa açılması lazım (MDZ)
                // Episode.Patient.SuitableToCreateNewDailySubEpisode(SubEpisodeSpeciality);  
            }

            return false;
        }

        // SEP in değiştirilmesi gereken propertyleri varsa bu metodda set edilmeli
        public override void FillLocalSEPProperties(ref SubEpisodeProtocol sep)
        {
            sep.MedulaTedaviTipi = TedaviTipi.GetTedaviTipi("7");

            // Yatan hastalarda bağlı takip olarak son yatış takibi set edilir
            if (Episode.PatientStatus == PatientStatusEnum.Inpatient || Episode.PatientStatus == PatientStatusEnum.PreDischarge)
            {
                InPatientTreatmentClinicApplication iPTCA = Episode.InPatientTreatmentClinicApplications.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled &&
                                                                x.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully).OrderByDescending(x => x.ClinicInpatientDate).FirstOrDefault();

                if (iPTCA != null && iPTCA.GetSubEpisodeCreatedByMe() != null && iPTCA.GetSubEpisodeCreatedByMe().LastActiveSubEpisodeProtocol != null)
                    sep.ParentSEP = iPTCA.GetSubEpisodeCreatedByMe().LastActiveSubEpisodeProtocol;
            }

            //NE hastanın kabulü acilden yapılmış ve HBO planlanmak isteniyorsa bağlı takibi olmamalı ve provizyon tipi adli vaka olmalı
            if (SubEpisode.PatientAdmission.SEP != null && SubEpisode.PatientAdmission.SEP.MedulaProvizyonTipi != null &&
               (SubEpisode.PatientAdmission.SEP.MedulaProvizyonTipi.provizyonTipiKodu.Equals("A") || SubEpisode.PatientAdmission.SEP.MedulaProvizyonTipi.provizyonTipiKodu.Equals("V")))
            {
                if (sep.MedulaTedaviTuru.tedaviTuruKodu.Equals("A"))
                {
                    sep.ParentSEP = null;
                    if (HyperOxygenTreatmentRequest != null && HyperOxygenTreatmentRequest.IsForensic == true)
                        sep.MedulaProvizyonTipi = ProvizyonTipi.GetProvizyonTipi("V");
                    else
                        sep.MedulaProvizyonTipi = ProvizyonTipi.GetProvizyonTipi("N");
                }
            }
        }

        protected override void PreInsert()
        {
            #region PreInsert

            MasterResource = (ResSection)TreatmentDiagnosisUnit;
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

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled

            Cancel();
            #endregion PostTransition_Completed2Cancelled
        }

        protected void PostTransition_Therapy2Aborted()
        {
            // From State : Therapy   To State : Aborted
            #region PostTransition_Therapy2Aborted
            foreach (HyperbarikOxygenTreatmentOrderDetail orderDetail in OrderDetails)
            {
                if (orderDetail.CurrentStateDefID == HyperbarikOxygenTreatmentOrderDetail.States.Execution)
                {
                    orderDetail.CurrentStateDefID = HyperbarikOxygenTreatmentOrderDetail.States.Cancelled;
                }
            }
            #endregion PostTransition_Therapy2Aborted
        }

        protected void PostTransition_Therapy2Cancelled()
        {
            // From State : Therapy   To State : Cancelled
            #region PostTransition_Therapy2Cancelled

            Cancel();
            #endregion PostTransition_Therapy2Cancelled
        }

        protected void PostTransition_Therapy2Completed()
        {
            // From State : Therapy   To State : Completed
            #region PostTransition_Therapy2Completed
            //Buradaki kod  HyperbaricOxygenTreatmentOrderForm nun clientsidepost scriptine tasindi. Terapi asamasindan Tamam asamasina gecerken calismasi sagilandi.

            #endregion PostTransition_Therapy2Completed
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

        protected void UndoTransition_Plan2AutomaticPlan(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Plan   To State : AutomaticPlan
            #region UndoTransition_Plan2AutomaticPlan

            NoBackStateBack();
            #endregion UndoTransition_Plan2AutomaticPlan
        }

        protected void UndoTransition_AutomaticPlan2Therapy(TTObjectStateTransitionDef transitionDef)
        {
            // From State : AutomaticPlan   To State : Therapy
            #region UndoTransition_AutomaticPlan2Therapy

            NoBackStateBack();
            #endregion UndoTransition_AutomaticPlan2Therapy
        }

        #region Methods

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.HyperbaricOxygenTreatmentOrder);
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
                        appointmentCarrier.MasterResourceFilter = " OBJECTID = '" + TreatmentDiagnosisUnit.ObjectID.ToString() + "'";
                    }
                    else
                    {
                        appointmentCarrier.MasterResourceFilter = "";
                    }
                    break;
                }
                return _appointmentList;
            }

            //                    if (this.CurrentStateDefID!= HyperbaricOxygenTreatmentOrder.States.RequestAcception && this.CurrentStateDefID != HyperbaricOxygenTreatmentOrder.States.Appointment)
            //                    {
            //                        List<AppointmentCarrier> appointmentCarrierList=new List<AppointmentCarrier>();
            //                        TTObjectContext context = new TTObjectContext(false);
            //                        AppointmentCarrier carrier = new AppointmentCarrier(context);
            //                        carrier.MasterResource="RESTREATMENTDIAGNOSISUNIT";
            //                        //SubResource değeri değişirse public HyperbarikOxygenTreatmentOrderDetail(HyperbarikOxygenTreatmentOrder Order,Appointment appointment): this( Order.ObjectContext) da da değiştirilmeli
            //                        carrier.SubResource="RESEQUIPMENT";
            //                        carrier.RelationParentName="TREATMENTDIAGNOSISUNIT";
            //                        carrier.AppointmentCount=Convert.ToInt32(this.Amount);
            //                        if( this.TreatmentDiagnosisUnit!=null)
            //                            carrier.MasterResourceFilter = " OBJECTID = '"  + this.TreatmentDiagnosisUnit.ObjectID.ToString() + "'";
            //                        else
            //                            carrier.MasterResourceFilter = "";
            //                        if (Convert.ToInt32(this.Duration)>0)
            //                            carrier.AppointmentDuration = Convert.ToInt32(this.Duration);
            //                        _appointmentList.Add( carrier);
            //                        return _appointmentList;
            //                    }
            //                    else
            //                    {
            //                        lock(_appointmentList)
            //                        {
            //                            ClearAppointmentCarrierDynamicFields(_appointmentList);
            //                            return _appointmentList;
            //                        }
            //                    }
        }

        #region IAppointmentDef Members
        public List<AppointmentCarrier> GetAppointmentCarrierList()
        {
            return AppointmentCarrierList;
        }
        #endregion

        private BindingList<HyperbaricOxygenTreatmentOrder> _mySiblingHyperbaricOrderObjects;
        private BindingList<PlannedAction> _mySiblingPlannedActionObjects;
        public BindingList<PlannedAction> GetMySiblingObjectListForAppointment()
        {
            _mySiblingHyperbaricOrderObjects = new BindingList<HyperbaricOxygenTreatmentOrder>();
            _mySiblingPlannedActionObjects = new BindingList<PlannedAction>();
            _mySiblingHyperbaricOrderObjects = HyperbaricOxygenTreatmentOrder.GetMySiblingObjectsForAppointment(ObjectContext, Episode.ObjectID.ToString(), ObjectID.ToString());
            foreach (HyperbaricOxygenTreatmentOrder hyperbaricOrder in _mySiblingHyperbaricOrderObjects)
            {
                ITTObject itt = (ITTObject)hyperbaricOrder;
                HyperbaricOxygenTreatmentOrder hoto = (HyperbaricOxygenTreatmentOrder)itt.Original;

                if (hoto.CurrentStateDefID == HyperbaricOxygenTreatmentOrder.States.Plan || hyperbaricOrder.CurrentStateDefID == HyperbaricOxygenTreatmentOrder.States.Plan)
                    _mySiblingPlannedActionObjects.Add((PlannedAction)hyperbaricOrder);
            }
            return _mySiblingPlannedActionObjects;
        }
        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true)
            {
                CurrentStateDefID = HyperbaricOxygenTreatmentOrder.States.Plan;
            }
        }

        public override SubactionProcedureFlowable CreateOrderDetail(Appointment appointment)
        {
            return new HyperbarikOxygenTreatmentOrderDetail(this, appointment);
        }

        public override SubactionProcedureFlowable CreateOrderDetail()
        {
            return new HyperbarikOxygenTreatmentOrderDetail(this);
        }

        public override void CreateAppointmentForOrderDetail(SubactionProcedureFlowable orderDetail)
        {
            HyperbarikOxygenTreatmentOrderDetail hypOrderDetail = (HyperbarikOxygenTreatmentOrderDetail)orderDetail;
            Appointment newAppointment = (Appointment)hypOrderDetail.ObjectContext.CreateObject("Appointment");

            DateTime appDate = Convert.ToDateTime(hypOrderDetail.WorkListDate.Value.Date);
            DateTime startDateTime = hypOrderDetail.WorkListDate.Value;
            DateTime endDateTime = hypOrderDetail.WorkListDate.Value.AddMinutes(((HyperbaricOxygenTreatmentOrder)hypOrderDetail.OrderObject).Duration.Value);
            IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(hypOrderDetail.ObjectContext, AppointmentDefinitionEnum.HyperbaricOxygenTreatmentOrder);
            if (appDefList.Count > 0)
            {
                newAppointment.AppointmentDefinition = (AppointmentDefinition)appDefList[0];
            }
            if (newAppointment.AppointmentDefinition.GiveToMaster == true)
                newAppointment.MasterResource = null;
            else
                newAppointment.MasterResource = hypOrderDetail.MasterResource;
            newAppointment.Patient = hypOrderDetail.Episode.Patient;
            newAppointment.StartTime = startDateTime;
            newAppointment.EndTime = endDateTime;
            newAppointment.CurrentStateDefID = Appointment.States.New;
            newAppointment.Schedule = null;
            newAppointment.BreakAppointment = false;
            newAppointment.Notes = TTUtils.CultureService.GetText("M26694", "Planlamasız Oluşturuldu") + " / ";
            newAppointment.Notes += hypOrderDetail.ProcedureObject.Name;
            newAppointment.AppointmentType = null;
            hypOrderDetail.TreatmentEquipment = ((HyperbaricOxygenTreatmentOrder)hypOrderDetail.OrderObject).TreatmentEquipment;
            newAppointment.Resource = hypOrderDetail.TreatmentEquipment;
            newAppointment.AppDate = appDate;
            if (((HyperbaricOxygenTreatmentOrder)hypOrderDetail.OrderObject).AppointmentCarrierList.Count > 0)
                newAppointment.AppointmentCarrier = ((HyperbaricOxygenTreatmentOrder)hypOrderDetail.OrderObject).AppointmentCarrierList[0];
            newAppointment.Action = null;
            newAppointment.SubActionProcedure = (SubActionProcedure)hypOrderDetail;
        }

        public override void SetCurrentStateToTherapy()
        {
            if (CurrentStateDefID == HyperbaricOxygenTreatmentOrder.States.Plan)
            {
                CurrentStateDefID = HyperbaricOxygenTreatmentOrder.States.Therapy;
                Update();
            }
        }
        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList = base.OldActionPropertyList();
            if (propertyList == null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();

            //-------------------------------------
            // propertyList.Add(new OldActionPropertyObject("İstek Tarihi",Common.ReturnObjectAsString(HyperOxygenTreatmentRequest.RequestDate)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M20566", "Protokol No"), Common.ReturnObjectAsString(ProtocolNo)));
            // propertyList.Add(new OldActionPropertyObject("İşlem Tarihi",Common.ReturnObjectAsString(ActionDate)));
            if (HyperOxygenTreatmentRequest.ProcedureDoctor != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M16661", "İstek Yapan Doktor"), Common.ReturnObjectAsString(HyperOxygenTreatmentRequest.ProcedureDoctor.Name)));
            if (TreatmentDiagnosisUnit != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M22778", "Tanı Tedavi Ünitesi"), Common.ReturnObjectAsString(TreatmentDiagnosisUnit.Name)));
            //            if(ProcedureObject != null)
            //                propertyList.Add(new OldActionPropertyObject("Hiperbarik Oksijen Tedavi İşlemi",Common.ReturnObjectAsString(ProcedureObject.Name)));
            //            propertyList.Add(new OldActionPropertyObject("Süre/dk",Common.ReturnObjectAsString(Duration)));
            //            propertyList.Add(new OldActionPropertyObject("Tedavi Derinliği (m)",Common.ReturnObjectAsString(TreatmentDepth)));
            //            propertyList.Add(new OldActionPropertyObject("Seans Sayısı",Common.ReturnObjectAsString(Amount)));
            //            propertyList.Add(new OldActionPropertyObject("Hasta Takip Formu",Common.ReturnObjectAsString(PatientFollowUpForm)));
            //            propertyList.Add(new OldActionPropertyObject("İstek Notu",Common.ReturnObjectAsString(HyperOxygenTreatmentRequest.Note)));
            //            propertyList.Add(new OldActionPropertyObject("Basınç Odası Operatörüne Talimatlar",Common.ReturnObjectAsString(TreatmentProperties)));
            if (ProcedureDoctor != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M26228", "İşlemi Yapacak Basınç Operatörü"), Common.ReturnObjectAsString(ProcedureDoctor.Name)));
            //---------------------------------------
            return propertyList;
        }

        public override void CompleteMySubActionProcedures()
        {
            // HyperbaricOxygenTreatmentOrder in sonuncusu tamamlaninca   HyperbaricOxygenTreatmentOrder da tamamlandigi icin CompleteMySubActionProcedures methodu override edildi. 
        }





        //        protected override List<List<List<OldActionPropertyObject>>> OldActionChildRelationList()
        //        {
        //            List<List<List<OldActionPropertyObject>>> gridList;
        //            if(base.OldActionChildRelationList()==null)
        //                gridList=new List<List<List<OldActionPropertyObject>>>();
        //            else
        //                gridList=base.OldActionChildRelationList();
        //
        //            List<List<OldActionPropertyObject>> gridProceduresRowList = new List<List<OldActionPropertyObject>>();
        //
        //            foreach(HyperbarikOxygenTreatmentOrderDetail orderDetail in OrderDetails)
        //            {
        //                List<OldActionPropertyObject> gridProceduresRowColumnList=new List<OldActionPropertyObject>();
        //                gridProceduresRowColumnList.Add(new OldActionPropertyObject("İşlemin Planlandığı Tarih",Common.ReturnObjectAsString(orderDetail.WorkListDate)));
        //                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Uygulama Tarihi",Common.ReturnObjectAsString(orderDetail.ActionDate)));
        //                if(orderDetail.TreatmentEquipment != null)
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("Tedavi Cihazı",Common.ReturnObjectAsString(orderDetail.TreatmentEquipment.Name)));
        //                else
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("Tedavi Cihazı",Common.ReturnObjectAsString("")));
        //
        //                if(orderDetail.ProcedureDoctor != null)
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("İşlemi Yapan Operatör",Common.ReturnObjectAsString(orderDetail.ProcedureDoctor.Name)));
        //                else
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("İşlemi Yapan Operatör",Common.ReturnObjectAsString("")));
        //
        //                if(orderDetail.ProcedureSpeciality != null)
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("İşlemin Yapıldığı Uzmanlık Dalı",Common.ReturnObjectAsString(orderDetail.ProcedureSpeciality.Name)));
        //                else
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("İşlemin Yapıldığı Uzmanlık Dalı",Common.ReturnObjectAsString("")));
        //
        //                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Operatör Notu",Common.ReturnObjectAsString(orderDetail.Note)));
        //                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Durumu",Common.ReturnObjectAsString(orderDetail.CurrentStateDef.DisplayText)));
        //                gridProceduresRowList.Add(gridProceduresRowColumnList);
        //            }
        //            gridList.Add(gridProceduresRowList);
        //            return gridList;
        //        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HyperbaricOxygenTreatmentOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HyperbaricOxygenTreatmentOrder.States.Aborted && toState == HyperbaricOxygenTreatmentOrder.States.Cancelled)
                PostTransition_Aborted2Cancelled();
            else if (fromState == HyperbaricOxygenTreatmentOrder.States.Completed && toState == HyperbaricOxygenTreatmentOrder.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == HyperbaricOxygenTreatmentOrder.States.Therapy && toState == HyperbaricOxygenTreatmentOrder.States.Aborted)
                PostTransition_Therapy2Aborted();
            else if (fromState == HyperbaricOxygenTreatmentOrder.States.Therapy && toState == HyperbaricOxygenTreatmentOrder.States.Cancelled)
                PostTransition_Therapy2Cancelled();
            else if (fromState == HyperbaricOxygenTreatmentOrder.States.Therapy && toState == HyperbaricOxygenTreatmentOrder.States.Completed)
                PostTransition_Therapy2Completed();
            else if (fromState == HyperbaricOxygenTreatmentOrder.States.Plan && toState == HyperbaricOxygenTreatmentOrder.States.Cancelled)
                PostTransition_Plan2Cancelled();

            //if (toState == States.Therapy)
            //    this.SubEpisode.ArrangeMeOrCreateNewSubEpisode(this, false);  // SubEpisode ve SubEpisodeProtocol oluşturup meduladan takip alan metod
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HyperbaricOxygenTreatmentOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HyperbaricOxygenTreatmentOrder.States.Plan && toState == HyperbaricOxygenTreatmentOrder.States.Therapy)
                UndoTransition_Plan2Therapy(transDef);
            else if (fromState == HyperbaricOxygenTreatmentOrder.States.Plan && toState == HyperbaricOxygenTreatmentOrder.States.AutomaticPlan)
                UndoTransition_Plan2AutomaticPlan(transDef);
            else if (fromState == HyperbaricOxygenTreatmentOrder.States.AutomaticPlan && toState == HyperbaricOxygenTreatmentOrder.States.Therapy)
                UndoTransition_AutomaticPlan2Therapy(transDef);
        }

    }
}