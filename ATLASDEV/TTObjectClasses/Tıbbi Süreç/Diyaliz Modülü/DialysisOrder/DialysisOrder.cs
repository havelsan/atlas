
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
    public partial class DialysisOrder : BaseDialysisOrder, IOldActions, IReasonOfReject, IAllocateSpeciality, IWorkListEpisodeAction, IPlanPlannedAction, ICreateSubEpisode
    {
        public partial class DialysisAcceptionReportNQL_Class : TTReportNqlObject
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
                case "DIALYSISREQUEST":
                    {
                        DialysisRequest value = (DialysisRequest)newValue;
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
                // DialysisRequest in DialysisOrder larından sadece 1 tanesi SubEpisode oluşturuyor, diğer DialysisOrder lar bu SubEpisode a giriyor
                foreach (DialysisOrder dOrder in DialysisRequest.DialysisOrders)
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


            MasterResource = (ResSection)TreatmentDiagnosisUnit;
            base.PreInsert();
            #endregion PreInsert
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

            if (SubEpisode.IsSGK)
            {
                SubEpisode DialysisSubEpisode = GetSubEpisodeCreatedByMe();

                // Diyaliz işlemi altvaka oluşturmuşsa o kullanılır
                if (DialysisSubEpisode == null)
                {
                    foreach (DialysisOrder dOrder in DialysisRequest.DialysisOrders)
                    {
                        DialysisSubEpisode = dOrder.GetSubEpisodeCreatedByMe();
                        if (DialysisSubEpisode != null)
                            break;
                    }
                }

                // Diyaliz işlemi altvaka oluşturmamışsa, vakadaki Diyaliz tipindeki diğer takiplerden altvakaya ulaşmaya çalışılır
                if (DialysisSubEpisode == null)
                {
                    foreach (SubEpisodeProtocol sep in Episode.AllSGKSubEpisodeProtocols())
                    {
                        // 1062 = Nefroloji, 1584 = Çocuk Nefrolojisi
                        if (sep.Brans.Code.Equals("1062") || sep.Brans.Code.Equals("1584"))
                        {
                            if (DialysisSubEpisode == null)
                                DialysisSubEpisode = sep.SubEpisode;
                            else
                            {
                                // Diyaliz Tedavi Tipinde takip varsa onun altvakası set edilir (1 = Diyaliz)
                                if (sep.MedulaTedaviTipi.tedaviTipiKodu.Equals("1"))
                                    DialysisSubEpisode = sep.SubEpisode;
                            }
                        }
                    }
                }

                if (DialysisSubEpisode != null && SubEpisode.ObjectID != DialysisSubEpisode.ObjectID)
                    SubEpisode = DialysisSubEpisode;

                //TODO: AAE Kural ekranı bunu haletmesi lazım.
                // Diyaliz paketleri ekleneceği için diyaliz hizmetleri iptal edilir
                //foreach (SubActionProcedure sp in this.SubactionProcedures)
                //{
                //    foreach (AccountTransaction accTrx in sp.AccountTransactions)
                //    {
                //        if (accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER && accTrx.IsAllowedToCancel)
                //        {
                //            if (accTrx.SubActionProcedure.ProcedureObject.Code != "704290")  // 704290 kodlu hizmetin iptal edilmesi istenmiyor.
                //                accTrx.InvoiceInclusion = false; ;
                //        }
                //    }
                //}

                // Daha önce Diyaliz paketleri oluşturulmamışsa, Diyaliz Uygulaması sayısı kadar ve aynı tarihler ile oluşturulur
                if (DialysisRequest != null && DialysisRequest.PackageProcedure != null && DialysisRequest.DialysisPackageProcedures.Count == 0)
                {
                    foreach (SubActionProcedure sp in SubactionProcedures)
                    {
                        if (sp.ProcedureObject.Code != "704290") // 704290 kodlu hizmetin paketinin oluşturulması istenmiyor.
                        {
                            DialysisPackageProcedure DialysisPackage = new DialysisPackageProcedure(ObjectContext);
                            DialysisPackage.ActionDate = Common.RecTime();
                            DialysisPackage.Amount = 1;
                            DialysisPackage.CurrentStateDefID = DialysisPackageProcedure.States.Completed;
                            DialysisPackage.ProcedureObject = DialysisRequest.PackageProcedure;
                            DialysisPackage.EpisodeAction = DialysisRequest;
                            DialysisPackage.PricingDate = sp.PricingDate;

                            if (DialysisSubEpisode != null)
                                DialysisPackage.SubEpisode = DialysisSubEpisode;

                            DialysisPackage.AccountOperation(AccountOperationTimeEnum.PREPOST);
                        }
                    }
                }
            }

            #endregion PostTransition_Therapy2Completed
        }

        protected void UndoTransition_RequestAcception2Therapy(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Therapy
            #region UndoTransition_RequestAcception2Therapy

            NoBackStateBack();
            #endregion UndoTransition_RequestAcception2Therapy
        }

        protected void PostTransition_ApprovalForAbort2Aborted()
        {
            // From State : ApprovalForAbort   To State : Aborted
            #region PostTransition_ApprovalForAbort2Aborted


            foreach (DialysisOrderDetail orderDetail in OrderDetails)
            {
                if (orderDetail.CurrentStateDefID == DialysisOrderDetail.States.Execution)
                {
                    orderDetail.CurrentStateDefID = DialysisOrderDetail.States.Cancelled;
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

        protected void PostTransition_Aborted2Cancelled()
        {
            // From State : Aborted   To State : Cancelled
            #region PostTransition_Aborted2Cancelled

            Cancel();
            #endregion PostTransition_Aborted2Cancelled
        }

        protected void UndoTransition_Plan2Therapy(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Plan   To State : Therapy
            #region UndoTransition_Plan2Therapy

            NoBackStateBack();
            #endregion UndoTransition_Plan2Therapy
        }

        protected void PostTransition_Plan2Cancelled()
        {
            // From State : Plan   To State : Cancelled
            #region PostTransition_Plan2Cancelled

            Cancel();
            #endregion PostTransition_Plan2Cancelled
        }

        #region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true)
            {
                CurrentStateDefID = DialysisOrder.States.RequestAcception;
            }
        }

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
                    //SubResource değeri değişirse public DialysisOrderDetail(DialysisOrder DialysisOrder,Appointment appointment): this(DialysisOrder.ObjectContext) da da değiştirilmeli
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
                                masterResFilter += ",'" + ((DialysisOrder)spa).TreatmentDiagnosisUnit.ObjectID.ToString() + "'";
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

        private BindingList<DialysisOrder> _mySiblingDialysisOrderObjects;
        private BindingList<PlannedAction> _mySiblingPlannedActionObjects;
        public BindingList<PlannedAction> GetMySiblingObjectListForAppointment()
        {
            _mySiblingDialysisOrderObjects = new BindingList<DialysisOrder>();
            _mySiblingPlannedActionObjects = new BindingList<PlannedAction>();
            _mySiblingDialysisOrderObjects = DialysisOrder.GetMySiblingObjectsForAppointment(ObjectContext, Episode.ObjectID.ToString(), ObjectID.ToString());
            foreach (DialysisOrder dialysisOrder in _mySiblingDialysisOrderObjects)
            {
                ITTObject itt = (ITTObject)dialysisOrder;
                DialysisOrder dor = (DialysisOrder)itt.Original;

                if (dor.CurrentStateDefID == DialysisOrder.States.Plan || dialysisOrder.CurrentStateDefID == DialysisOrder.States.Plan)
                    _mySiblingPlannedActionObjects.Add((PlannedAction)dialysisOrder);
            }
            return _mySiblingPlannedActionObjects;
        }

        public override SubactionProcedureFlowable CreateOrderDetail(Appointment appointment)
        {
            return new DialysisOrderDetail(this, appointment);
        }

        public override SubactionProcedureFlowable CreateOrderDetail()
        {
            return new DialysisOrderDetail(this);
        }

        public override void CreateAppointmentForOrderDetail(SubactionProcedureFlowable orderDetail)
        {
            DialysisOrderDetail diaOrderDetail = (DialysisOrderDetail)orderDetail;
            Appointment newAppointment = (Appointment)diaOrderDetail.ObjectContext.CreateObject("Appointment");

            DateTime appDate = Convert.ToDateTime(diaOrderDetail.WorkListDate.Value.Date);
            DateTime startDateTime = diaOrderDetail.WorkListDate.Value;
            DateTime endDateTime = diaOrderDetail.WorkListDate.Value.AddMinutes(((DialysisOrder)diaOrderDetail.OrderObject).Duration.Value);
            IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(diaOrderDetail.ObjectContext, AppointmentDefinitionEnum.DialysisOrder);
            if (appDefList.Count > 0)
            {
                newAppointment.AppointmentDefinition = (AppointmentDefinition)appDefList[0];
            }
            if (newAppointment.AppointmentDefinition.GiveToMaster == true)
                newAppointment.MasterResource = null;
            else
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
            diaOrderDetail.TreatmentEquipment = ((DialysisOrder)diaOrderDetail.OrderObject).TreatmentEquipment;
            newAppointment.Resource = diaOrderDetail.TreatmentEquipment;
            newAppointment.AppDate = appDate;
            if (((DialysisOrder)diaOrderDetail.OrderObject).AppointmentCarrierList.Count > 0)
                newAppointment.AppointmentCarrier = ((DialysisOrder)diaOrderDetail.OrderObject).AppointmentCarrierList[0];
            newAppointment.Action = null;
            newAppointment.SubActionProcedure = (SubActionProcedure)diaOrderDetail;
        }

        public override void SetCurrentStateToTherapy()
        {
            if (CurrentStateDefID == DialysisOrder.States.Plan)
            {
                CurrentStateDefID = DialysisOrder.States.Therapy;
                Update();
            }
        }

        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList = base.OldActionPropertyList();
            //-------------------------------------
            if (propertyList == null)
            {
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();
            }
            //propertyList.Add(new OldActionPropertyObject("İstek Tarihi",Common.ReturnObjectAsString(DialysisRequest.RequestDate)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M20566", "Protokol No"), Common.ReturnObjectAsString(ProtocolNo)));
            //propertyList.Add(new OldActionPropertyObject("İşlem Tarihi",Common.ReturnObjectAsString(ActionDate)));
            if (DialysisRequest.ProcedureDoctor != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M16661", "İstek Yapan Doktor"), Common.ReturnObjectAsString(DialysisRequest.ProcedureDoctor.Name)));
            if (TreatmentDiagnosisUnit != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M22778", "Tanı Tedavi Ünitesi"), Common.ReturnObjectAsString(TreatmentDiagnosisUnit.Name)));
            //            if(ProcedureObject != null)
            //                propertyList.Add(new OldActionPropertyObject("Diyaliz Uygulaması",Common.ReturnObjectAsString(ProcedureObject.Name)));
            //propertyList.Add(new OldActionPropertyObject("Süre/dk",Common.ReturnObjectAsString(Duration)));
            // propertyList.Add(new OldActionPropertyObject("Kür",Common.ReturnObjectAsString(Amount)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25923", "Hemşireye Emirler"), Common.ReturnObjectAsString(OrderNote)));
            if (ProcedureDoctor != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M26230", "İşlemi Yapacak Hemşire"), Common.ReturnObjectAsString(ProcedureDoctor.Name)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25522", "Doktor Diyaliz Takip Formu"), Common.ReturnObjectAsString(DoctorFollowUpForm)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25919", "Hemşire Diyaliz Takip Formu"), Common.ReturnObjectAsString(NurseFollowUpForm)));
            //---------------------------------------
            return propertyList;
        }

        public override void CompleteMySubActionProcedures()
        {
            // DialysisOrderDetail in sonuncusu tamamlaninca   DialysisOrder da tamamlandigi icin CompleteMySubActionProcedures methodu override edildi. 
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
        //            foreach(DialysisOrderDetail orderDetail in OrderDetails)
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
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("İşlemi Yapan Hemşire",Common.ReturnObjectAsString(orderDetail.ProcedureDoctor.Name)));
        //                else
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("İşlemi Yapan Hemşire",Common.ReturnObjectAsString("")));
        //
        //                if(orderDetail.ProcedureSpeciality != null)
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("İşlemin Yapıldığı Uzmanlık Dalı",Common.ReturnObjectAsString(orderDetail.ProcedureSpeciality.Name)));
        //                else
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("İşlemin Yapıldığı Uzmanlık Dalı",Common.ReturnObjectAsString("")));
        //
        //                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Hemşire Notu",Common.ReturnObjectAsString(orderDetail.Note)));
        //                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Durumu",Common.ReturnObjectAsString(orderDetail.CurrentStateDef.DisplayText)));
        //                gridProceduresRowList.Add(gridProceduresRowColumnList);
        //            }
        //            gridList.Add(gridProceduresRowList);
        //            return gridList;
        //        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DialysisOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DialysisOrder.States.Therapy && toState == DialysisOrder.States.Cancelled)
                PostTransition_Therapy2Cancelled();
            else if (fromState == DialysisOrder.States.Therapy && toState == DialysisOrder.States.Completed)
                PostTransition_Therapy2Completed();
            else if (fromState == DialysisOrder.States.ApprovalForAbort && toState == DialysisOrder.States.Aborted)
                PostTransition_ApprovalForAbort2Aborted();
            else if (fromState == DialysisOrder.States.Completed && toState == DialysisOrder.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == DialysisOrder.States.Aborted && toState == DialysisOrder.States.Cancelled)
                PostTransition_Aborted2Cancelled();
            else if (fromState == DialysisOrder.States.Plan && toState == DialysisOrder.States.Cancelled)
                PostTransition_Plan2Cancelled();

            //if (toState == States.Therapy)
            //    this.SubEpisode.ArrangeMeOrCreateNewSubEpisode(this, false);  // SubEpisode ve SubEpisodeProtocol oluşturup meduladan takip alan metod
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DialysisOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DialysisOrder.States.RequestAcception && toState == DialysisOrder.States.Therapy)
                UndoTransition_RequestAcception2Therapy(transDef);
            else if (fromState == DialysisOrder.States.Plan && toState == DialysisOrder.States.Therapy)
                UndoTransition_Plan2Therapy(transDef);
        }

    }
}