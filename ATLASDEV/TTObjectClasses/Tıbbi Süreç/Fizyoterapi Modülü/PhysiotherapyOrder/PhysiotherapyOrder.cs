
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
    /// Fizyoterapi Emrinin Veridiği Nesnedir
    /// </summary>
    public partial class PhysiotherapyOrder : BasePhysiotherapyOrder, IOldActions, IReasonOfReject, IAllocateSpeciality, IPlanPlannedAction, ICreateSubEpisode
    {
        public partial class GetPhysiotherapyOrders_Class : TTReportNqlObject
        {
        }

        public partial class PhysiotherapyAcceptionReportNQL_Class : TTReportNqlObject
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
                case "PHYSIOTHERAPYREQUEST":
                    {
                        PhysiotherapyRequest value = (PhysiotherapyRequest)newValue;
                        #region PHYSIOTHERAPYREQUEST_SetParentScript
                        if (value != null)
                        {
                            MedulaHastaKabul = value.MedulaHastaKabul;
                            SetMandatoryEpisodeActionProperties(value, TreatmentDiagnosisUnit, value.FromResource, true);
                        }
                        #endregion PHYSIOTHERAPYREQUEST_SetParentScript
                    }
                    break;
                //case "FTRAPPLICATIONAREADEF":
                //    {
                //        FTRVucutBolgesi value = (FTRVucutBolgesi)newValue;
                //        #region FTRAPPLICATIONAREADEF_SetParentScript
                //        if (value == null)
                //            value.ftrVucutBolgesiAdi = "";
                //        else
                //            this.FTRApplicationAreaDef = value;
                //        #endregion FTRAPPLICATIONAREADEF_SetParentScript
                //    }
                //    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        public override SpecialityDefinition GetSubEpisodeSpeciality()
        {
                // Spor hekimliği yada hidroklimatoloji den FTR ye kayıt açılıyorsa branş ı FTR yapma, ilk takip ne ise öyle kalsın. 
                // Bu kontrol ArrangeMeOrCreateNewSubEpisode metodundan buraya taşındı (MDZ)
                if (Episode.MainSpeciality != null && (Episode.MainSpeciality.Code.Equals("4000") || Episode.MainSpeciality.Code.Equals("600")))
                    return Episode.MainSpeciality;

                return base.GetSubEpisodeSpeciality();
        }

        // Yeni SubEpisode oluşturulmasına karar veren metod
        //public override bool IsNewSubEpisodeNeeded()
        //{
        //    if (base.IsNewSubEpisodeNeeded() == false)
        //        return false;

        //    if (SubEpisode.IsSGK)
        //    {
        //        // PhysiotherapyRequest in PhysiotherapyOrder larından sadece 1 tanesi SubEpisode oluşturuyor, diğer PhysiotherapyOrder lar bu SubEpisode a giriyor
        //        foreach (PhysiotherapyOrder po in PhysiotherapyRequest.PhysiotherapyOrders)
        //        {
        //            if (po.ObjectID != ObjectID && po.SubEpisodeCreatedByMe != null)
        //                return false;
        //        }
        //        // 1800 = FTR , 600 = Tıbbi Ekoloji ve Hidroklimatoloji, 4000 = Spor Hekimliği
        //        if (!Episode.IsSGKSubEpisodeProtocolExists(new String[] { "1800", "4000", "600" }, new String[] { "G", "Y" }, "2"))
        //            return true;

        //        // Önceden bu metod ile de kontrol yapılıyordu PhysiotherapyOrder.PostUpdate metodunda, şimdilik kapattım ileride gerek olursa açılması lazım (MDZ)
        //        // Episode.Patient.SuitableToCreateNewDailySubEpisode(SubEpisodeSpeciality);  
        //    }

        //    return false;
        //}

        // SEP in değiştirilmesi gereken propertyleri varsa bu metodda set edilmeli
        //public override void FillLocalSEPProperties(ref SubEpisodeProtocol sep)
        //{
        //    sep.MedulaTedaviTipi = TedaviTipi.GetTedaviTipi("2");

        //    // Yatan hastalarda bağlı takip olarak son yatış takibi set edilir
        //    if (Episode.PatientStatus == PatientStatusEnum.Inpatient || Episode.PatientStatus == PatientStatusEnum.PreDischarge)
        //    {
        //        InPatientTreatmentClinicApplication iPTCA = Episode.InPatientTreatmentClinicApplications.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled &&
        //                                                        x.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully).OrderByDescending(x => x.ClinicInpatientDate).FirstOrDefault();

        //        if (iPTCA != null && iPTCA.SubEpisodeCreatedByMe != null && iPTCA.SubEpisodeCreatedByMe.LastActiveSubEpisodeProtocol != null)
        //            sep.ParentSEP = iPTCA.SubEpisodeCreatedByMe.LastActiveSubEpisodeProtocol;
        //    }
        //}

        protected override void PreInsert()
        {
            #region PreInsert

            MasterResource = (ResSection)TreatmentDiagnosisUnit;
            base.PreInsert();

            #endregion PreInsert
        }


        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();
            if (FinishSession != null && StartSession != null)
            {
                Amount = FinishSession - StartSession + 1;
            }
            else
            {
                Amount = 0;
            }

            #endregion PostInsert
        }

        protected void PostTransition_Aborted2Cancelled()
        {
            // From State : Aborted   To State : Cancelled
            #region PostTransition_Aborted2Cancelled

            Cancel();
            #endregion PostTransition_Aborted2Cancelled
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

            //if (SubEpisode.IsSGK)
            //{
            //    SubEpisode FTRSubEpisode = SubEpisodeCreatedByMe;

            //    // FTR işlemi altvaka oluşturmuşsa o kullanılır
            //    if (FTRSubEpisode == null)
            //    {
            //        foreach (PhysiotherapyOrder pOrder in this.PhysiotherapyRequest.PhysiotherapyOrders)
            //        {
            //            FTRSubEpisode = pOrder.SubEpisodeCreatedByMe;
            //            if (FTRSubEpisode != null)
            //                break;
            //        }
            //    }

            //    // FTR işlemi altvaka oluşturmamışsa, vakadaki FTR branşındaki diğer takiplerden altvakaya ulaşmaya çalışılır
            //    if (FTRSubEpisode == null)
            //    {
            //        foreach (SubEpisodeProtocol sep in this.Episode.AllSGKSubEpisodeProtocols())
            //        {
            //            // 1800 = FTR , 600 = Tıbbi Ekoloji ve Hidroklimatoloji, 4000 = Spor Hekimliği
            //            if (sep.Brans.Code.Equals("1800") || sep.Brans.Code.Equals("600") || sep.Brans.Code.Equals("4000"))
            //            {
            //                if (FTRSubEpisode == null)
            //                    FTRSubEpisode = sep.SubEpisode;
            //                else
            //                {
            //                    // "2 : Fiziksel Tedavi ve Rehabilitasyon" Tedavi Tipinde takip varsa onun altvakası set edilir
            //                    if (sep.MedulaTedaviTipi.tedaviTipiKodu.Equals("2"))
            //                        FTRSubEpisode = sep.SubEpisode;
            //                }
            //            }
            //        }
            //    }

            //    if (FTRSubEpisode != null && this.SubEpisode.ObjectID != FTRSubEpisode.ObjectID)
            //        this.SubEpisode = FTRSubEpisode;

            //    //TODO: AAE
            //    // FTR paketleri ekleneceği için FTR hizmetleri fatura dışı bırakılır. Paket Girildiğinde Kural Çalışınca bunu silebiliriz.
            //    //foreach (SubActionProcedure sp in this.SubactionProcedures)
            //    //{
            //    //    foreach (AccountTransaction accTrx in sp.AccountTransactions)
            //    //    {
            //    //        if (accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER && accTrx.IsAllowedToCancel)
            //    //            accTrx.InvoiceInclusion = false;
            //    //    }
            //    //}

            //    // Daha önce FTR paketleri oluşturulmamışsa, Fizyoterapi Uygulaması sayısı kadar ve aynı tarihler ile oluşturulur
            //    if (this.PhysiotherapyRequest != null && this.PhysiotherapyRequest.PackageProcedure != null && this.PhysiotherapyRequest.FTRPackageProcedures.Count == 0)
            //    {
            //        foreach (SubActionProcedure sp in this.SubactionProcedures)
            //        {
            //            FTRPackageProcedure FTRPackage = new FTRPackageProcedure(this.ObjectContext);
            //            FTRPackage.ActionDate = Common.RecTime();
            //            FTRPackage.Amount = 1;
            //            FTRPackage.CurrentStateDefID = FTRPackageProcedure.States.Completed;
            //            FTRPackage.ProcedureObject = this.PhysiotherapyRequest.PackageProcedure;
            //            FTRPackage.EpisodeAction = this.PhysiotherapyRequest;
            //            FTRPackage.PricingDate = sp.PricingDate;

            //            if (FTRSubEpisode != null)
            //                FTRPackage.SubEpisode = FTRSubEpisode;

            //            FTRPackage.AccountOperation(AccountOperationTimeEnum.PREPOST);
            //        }
            //    }
            //}

            #endregion PostTransition_Therapy2Completed
        }

        protected void PreTransition_RequestAcception2Therapy()
        {
            // From State : RequestAcception   To State : Therapy
            #region PreTransition_RequestAcception2Therapy

            //CheckHasReport();


            #endregion PreTransition_RequestAcception2Therapy
        }

        protected void UndoTransition_RequestAcception2Therapy(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Therapy
            #region UndoTransition_RequestAcception2Therapy

            NoBackStateBack();
            #endregion UndoTransition_RequestAcception2Therapy
        }

        protected void PreTransition_RequestAcception2Plan()
        {
            // From State : RequestAcception   To State : Plan
            #region PreTransition_RequestAcception2Plan

            //CheckHasReport();

            #endregion PreTransition_RequestAcception2Plan
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

        protected void PostTransition_ApprovalForAbort2Aborted()
        {
            // From State : ApprovalForAbort   To State : Aborted
            #region PostTransition_ApprovalForAbort2Aborted


            foreach (PhysiotherapyOrderDetail orderDetail in OrderDetails)
            {
                if (orderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution)
                {
                    orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Cancelled;
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

        #region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true)
            {
                CurrentStateDefID = PhysiotherapyOrder.States.RequestAcception;
            }
        }

        public override List<int> AllowedMedulaTedaviTipi()
        {
            List<int> typeList = new List<int>();
            typeList.Add(2);//Fiziksel Tedavi ve Rehabilitasyon
            return typeList;
        }

        public override void CreateAppointmentForOrderDetail(SubactionProcedureFlowable orderDetail)
        {
            PhysiotherapyOrderDetail phyOrderDetail = (PhysiotherapyOrderDetail)orderDetail;
            Appointment newAppointment = (Appointment)phyOrderDetail.ObjectContext.CreateObject("Appointment");

            DateTime appDate = Convert.ToDateTime(phyOrderDetail.WorkListDate.Value.Date);
            DateTime startDateTime = phyOrderDetail.WorkListDate.Value;
            DateTime endDateTime = phyOrderDetail.WorkListDate.Value.AddMinutes(((PhysiotherapyOrder)phyOrderDetail.OrderObject).Duration.Value);
            IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(phyOrderDetail.ObjectContext, AppointmentDefinitionEnum.PhysiotherapyOrder);
            if (appDefList.Count > 0)
            {
                newAppointment.AppointmentDefinition = (AppointmentDefinition)appDefList[0];
            }
            if (newAppointment.AppointmentDefinition.GiveToMaster == true)
                newAppointment.MasterResource = null;
            else
                newAppointment.MasterResource = phyOrderDetail.MasterResource;
            newAppointment.Patient = phyOrderDetail.Episode.Patient;
            newAppointment.StartTime = startDateTime;
            newAppointment.EndTime = endDateTime;
            newAppointment.CurrentStateDefID = Appointment.States.New;
            newAppointment.Schedule = null;
            newAppointment.BreakAppointment = false;
            newAppointment.Notes = TTUtils.CultureService.GetText("M26694", "Planlamasız Oluşturuldu") + " / ";
            newAppointment.Notes += phyOrderDetail.ProcedureObject.Name;
            newAppointment.AppointmentType = null;
            phyOrderDetail.TreatmentRoom = ((PhysiotherapyOrder)phyOrderDetail.OrderObject).TreatmentRoom;
            newAppointment.Resource = phyOrderDetail.TreatmentRoom;
            newAppointment.AppDate = appDate;
            if (((PhysiotherapyOrder)phyOrderDetail.OrderObject).AppointmentCarrierList.Count > 0)
                newAppointment.AppointmentCarrier = ((PhysiotherapyOrder)phyOrderDetail.OrderObject).AppointmentCarrierList[0];
            newAppointment.Action = null;
            newAppointment.SubActionProcedure = (SubActionProcedure)phyOrderDetail;
        }

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.PhysiotherapyOrder);
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
                    //SubResource değeri değişirse public PhysiotherapyOrderDetail(PhysiotherapyOrder physiotherapyOrder,Appointment appointment): this(physiotherapyOrder.ObjectContext) da da değiştirilmeli
                    carrier.SubResource = "RESTREATMENTDIAGNOSISROOM";
                    carrier.RelationParentName = "TREATMENTDIAGNOSISUNIT";
                    _appointmentList.Add(carrier);
                }

                //her public appcarrier listesinin başında çağırılmalı.
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
                                masterResFilter += ",'" + ((PhysiotherapyOrder)spa).TreatmentDiagnosisUnit.ObjectID.ToString() + "'";
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

        private BindingList<PhysiotherapyOrder> _mySiblingPhysiotherapyOrderObjects;
        private BindingList<PlannedAction> _mySiblingPlannedActionObjects;
        public BindingList<PlannedAction> GetMySiblingObjectListForAppointment()
        {
            _mySiblingPhysiotherapyOrderObjects = new BindingList<PhysiotherapyOrder>();
            _mySiblingPlannedActionObjects = new BindingList<PlannedAction>();

            _mySiblingPhysiotherapyOrderObjects = ObjectContext.QueryObjects<PhysiotherapyOrder>("EPISODE = " + ConnectionManager.GuidToString(Episode.ObjectID) + " AND OBJECTID <> " + ConnectionManager.GuidToString(ObjectID));
            foreach (PhysiotherapyOrder po in ObjectContext.LocalQuery("PHYSIOTHERAPYORDER", "EPISODE = " + ConnectionManager.GuidToString(Episode.ObjectID) + " AND OBJECTID <> " + ConnectionManager.GuidToString(ObjectID)))
                if (_mySiblingPhysiotherapyOrderObjects.Contains(po) == false)
                    _mySiblingPhysiotherapyOrderObjects.Add(po);

            //_mySiblingPhysiotherapyOrderObjects = PhysiotherapyOrder.GetMySiblingObjectsForAppointment(this.ObjectContext, this.Episode.ObjectID.ToString(), this.ObjectID.ToString());
            foreach (PhysiotherapyOrder physiotherapyOrder in _mySiblingPhysiotherapyOrderObjects)
            {
                ITTObject itt = (ITTObject)physiotherapyOrder;
                PhysiotherapyOrder por = (PhysiotherapyOrder)itt.Original;

                //if (por.CurrentStateDefID == PhysiotherapyOrder.States.Plan || physiotherapyOrder.CurrentStateDefID == PhysiotherapyOrder.States.Plan)
                //    _mySiblingPlannedActionObjects.Add((PlannedAction)physiotherapyOrder);
            }
            return _mySiblingPlannedActionObjects;
        }



        public override SubactionProcedureFlowable CreateOrderDetail(Appointment appointment)
        {
            return new PhysiotherapyOrderDetail(this, appointment);
        }

        public override SubactionProcedureFlowable CreateOrderDetail()
        {
            return new PhysiotherapyOrderDetail(this);
        }

        public override void SetCurrentStateToTherapy()
        {
            //if (this.CurrentStateDefID == PhysiotherapyOrder.States.Plan)
            //{
            //    this.CurrentStateDefID = PhysiotherapyOrder.States.Therapy;
            //    this.Update();
            //}
        }

        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList = base.OldActionPropertyList();
            if (propertyList == null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();
            //-------------------------------------
            // propertyList.Add(new OldActionPropertyObject("İstek Tarihi",Common.ReturnObjectAsString(PhysiotherapyRequest.RequestDate)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M20566", "Protokol No"), Common.ReturnObjectAsString(ProtocolNo)));
            //propertyList.Add(new OldActionPropertyObject("İşlem Tarihi",Common.ReturnObjectAsString(ActionDate)));
            if (PhysiotherapyRequest.ProcedureDoctor != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M16661", "İstek Yapan Doktor"), Common.ReturnObjectAsString(PhysiotherapyRequest.ProcedureDoctor.Name)));
            if (TreatmentDiagnosisUnit != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M22778", "Tanı Tedavi Ünitesi"), Common.ReturnObjectAsString(TreatmentDiagnosisUnit.Name)));
            //            if(ProcedureObject != null)
            //                propertyList.Add(new OldActionPropertyObject("Fizyoterapi İşlemi",Common.ReturnObjectAsString(ProcedureObject.Name)));
            //            propertyList.Add(new OldActionPropertyObject("Uygulama Alanı",Common.ReturnObjectAsString(ApplicationArea)));
            //            propertyList.Add(new OldActionPropertyObject("Süre/dk",Common.ReturnObjectAsString(Duration)));
            //            propertyList.Add(new OldActionPropertyObject("Kür",Common.ReturnObjectAsString(Amount)));
            //   propertyList.Add(new OldActionPropertyObject("İstek Notu",Common.ReturnObjectAsString(PhysiotherapyRequest.NoteToPhysiotherapist)));
            //propertyList.Add(new OldActionPropertyObject("Tedavi Özellikleri",Common.ReturnObjectAsString(TreatmentProperties)));
            if (ProcedureDoctor != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M26229", "İşlemi Yapacak Fizyoterapist"), Common.ReturnObjectAsString(ProcedureDoctor.Name)));
            //---------------------------------------
            return propertyList;
        }

        public override void CompleteMySubActionProcedures()
        {
            // PhysiotherapyOrderDetail in sonuncusu tamamlaninca   PhysiotherapyOrder da tamamlandigi icin CompleteMySubActionProcedures methodu override edildi. 
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
        //            foreach(PhysiotherapyOrderDetail orderDetail in OrderDetails)
        //            {
        //                List<OldActionPropertyObject> gridProceduresRowColumnList=new List<OldActionPropertyObject>();
        //                gridProceduresRowColumnList.Add(new OldActionPropertyObject("İşlemin Planlandığı Tarih",Common.ReturnObjectAsString(orderDetail.WorkListDate)));
        //                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Uygulama Tarihi",Common.ReturnObjectAsString(orderDetail.ActionDate)));
        //                if(orderDetail.TreatmentRoom != null)
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("Tedavi Odası",Common.ReturnObjectAsString(orderDetail.TreatmentRoom.Name)));
        //                else
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("Tedavi Odası",Common.ReturnObjectAsString("")));
        //
        //                if(orderDetail.ProcedureDoctor != null)
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("İşlemi Yapan Fizyoterapist",Common.ReturnObjectAsString(orderDetail.ProcedureDoctor.Name)));
        //                else
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("İşlemi Yapan Fizyoterapist",Common.ReturnObjectAsString("")));
        //
        //                if(orderDetail.ProcedureSpeciality != null)
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("İşlemin Yapıldığı Uzmanlık Dalı",Common.ReturnObjectAsString(orderDetail.ProcedureSpeciality.Name)));
        //                else
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("İşlemin Yapıldığı Uzmanlık Dalı",Common.ReturnObjectAsString("")));
        //
        //                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Fizyoterapist Notu",Common.ReturnObjectAsString(orderDetail.Note)));
        //                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Durumu",Common.ReturnObjectAsString(orderDetail.CurrentStateDef.DisplayText)));
        //                gridProceduresRowList.Add(gridProceduresRowColumnList);
        //            }
        //            gridList.Add(gridProceduresRowList);
        //            return gridList;
        //        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PhysiotherapyOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            //if (fromState == States.RequestAcception && toState == States.Therapy)
            //    PreTransition_RequestAcception2Therapy();
            //else if (fromState == States.RequestAcception && toState == States.Plan)
            //    PreTransition_RequestAcception2Plan();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            //if (transDef.ObjectDef.CodeName != typeof(PhysiotherapyOrder).Name)
            //    return;

            //var fromState = transDef.FromStateDefID;
            //var toState = transDef.ToStateDefID;

            //if (fromState == States.Aborted && toState == States.Cancelled)
            //    PostTransition_Aborted2Cancelled();
            //else if (fromState == States.Therapy && toState == States.Cancelled)
            //    PostTransition_Therapy2Cancelled();
            //else if (fromState == States.Therapy && toState == States.Completed)
            //    PostTransition_Therapy2Completed();
            //else if (fromState == States.Plan && toState == States.Cancelled)
            //    PostTransition_Plan2Cancelled();
            //else if (fromState == States.ApprovalForAbort && toState == States.Aborted)
            //    PostTransition_ApprovalForAbort2Aborted();
            //else if (fromState == States.Completed && toState == States.Cancelled)
            //    PostTransition_Completed2Cancelled();

            //if (toState == States.Therapy)
            //    this.SubEpisode.ArrangeMeOrCreateNewSubEpisode(this, false);  // SubEpisode ve SubEpisodeProtocol oluşturup meduladan takip alan metod
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            //if (transDef.ObjectDef.CodeName != typeof(PhysiotherapyOrder).Name)
            //    return;

            //var fromState = transDef.FromStateDefID;
            //var toState = transDef.ToStateDefID;

            //if (fromState == States.RequestAcception && toState == States.Therapy)
            //    UndoTransition_RequestAcception2Therapy(transDef);
            //else if (fromState == States.Plan && toState == States.Therapy)
            //    UndoTransition_Plan2Therapy(transDef);
        }


    }
}