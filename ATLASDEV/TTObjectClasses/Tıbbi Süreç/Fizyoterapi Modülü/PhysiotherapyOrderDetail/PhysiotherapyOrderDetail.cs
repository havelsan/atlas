
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
    /// Fizyoterapi Emrinin  Uygulamasının Gerçekleştirildiği NEsnedir
    /// </summary>
    public partial class PhysiotherapyOrderDetail : BasePhysiotherapyOrderDetail, IBaseAppointmentDef, IReasonOfReject, ITreatmentMaterialCollection
    {
        public partial class GetPhysiotherapyOrderDetails_Class : TTReportNqlObject
        {
        }

        public partial class GetPhysiotherapyOrderDetailsForPatient_Class : TTReportNqlObject
        {
        }

        public partial class GetPhysiotherapyOrderDetailsByOrderObject_Class : TTReportNqlObject
        {
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();

            bool IsAppointmentActive = TTObjectClasses.SystemParameter.GetParameterValue("IsAppointmentActive", "FALSE") == "FALSE" ? false : true;
            if (IsAppointmentActive == true)
            {
                CreateAppointmentForOrderDetail();
            }

            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();

            #endregion PostUpdate
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled

            Cancel();

            PerformedDate = null;
            #endregion PostTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
            #region UndoTransition_Completed2Cancelled

            NoBackStateBack();

            PerformedDate = null;
            #endregion UndoTransition_Completed2Cancelled
        }

        protected void UndoTransition_Execution2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Execution   To State : Completed
            #region UndoTransition_Execution2Completed
            //CancelAccountingOperation();
            #endregion UndoTransition_Execution2Completed
        }

        protected void PreTransition_Execution2Completed()
        {
            // From State : Execution   To State : Completed
            #region PreTransition_Execution2Completed


            //if(this.OrderObject.CurrentStateDefID == PhysiotherapyOrder.States.ApprovalForAbort)
            //   throw new Exception(SystemMessage.GetMessage(1177));
            #endregion PreTransition_Execution2Completed
        }

        protected void PostTransition_Execution2Completed()
        {
            // From State : Execution   To State : Completed
            #region PostTransition_Execution2Completed

            SetPerformedDate();
            CompleteMyNewAppoinments();

            // Aşağıdaki if bloğu bir süre sonra kapatılmalı. Artık ücretlendirme planlama aşamasında yapılıyor. 
            // Planlaması yapılmış ama ücretlenmemişlerin tamamlanırken ücretlenmesi açık bırakıldı şimdilik. (31.05.2018 Mustafa)
            if (IsOldAction != true)
            {
                // AltVaka Oluşturulur
                PhysiotherapyOrder.PhysiotherapyRequest.SubEpisode.ArrangeMeOrCreateNewSubEpisode(PhysiotherapyOrder.PhysiotherapyRequest, false, true);

                if (PlannedDate.Value.Date == PhysiotherapyOrder.PhysiotherapyRequest.SubEpisode.OpeningDate.Value.Date)
                    PlannedDate.Value.AddMinutes(2);

                // Ãœcretlendirmeler yapılır
                AccountingOperation();
            }

            IfLastCompletePhysiotherapyOrder();

            CompleteFTRPackageProcedure();

            #endregion PostTransition_Execution2Completed
        }

        protected void PostTransition_Completed2Execution()
        {
            // From State : Completed   To State : Execution
            #region PostTransition_Completed2Execution

            //CancelAccountingOperation();

            PerformedDate = null;

            UnCompleteFTRPackageProcedure();

            #endregion PostTransition_Completed2Execution
        }

        protected void PostTransition_Execution2Cancelled()
        {
            // From State : Execution   To State : Cancelled
            #region PostTransition_Execution2Cancelled

            Cancel();

            #endregion PostTransition_Execution2Cancelled
        }

        protected void UndoTransition_Execution2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Execution   To State : Cancelled
            #region UndoTransition_Execution2Cancelled

            NoBackStateBack();
            #endregion UndoTransition_Execution2Cancelled
        }

        protected void PostTransition_ApprovalForCancel2Cancelled()
        {
            // From State : ApprovalForCancel   To State : Cancelled
            #region PostTransition_ApprovalForCancel2Cancelled


            Cancel();
            #endregion PostTransition_ApprovalForCancel2Cancelled
        }

        protected void PostTransition_Execution2Aborted()
        {
            CancelAccountingOperation(); // Tekrar ücretlendirme yapılmalı
        }

        protected void PostTransition_Aborted2Execution()
        {
            AccountingOperation(); // Tekrar ücretlendirme yapılmalı
        }

        protected void UndoTransition_ApprovalForCancel2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ApprovalForCancel   To State : Cancelled
            #region UndoTransition_ApprovalForCancel2Cancelled

            NoBackStateBack();
            #endregion UndoTransition_ApprovalForCancel2Cancelled
        }

        #region Methods

        public void CreateAppointmentForOrderDetail()
        {
            Appointment newAppointment;
            var app = Appointment.GetBySubActionProcedureId(ObjectContext, this.ObjectID);
            if (app.Count() > 0)
            {
                newAppointment = app.FirstOrDefault();
            }
            else
            {
                newAppointment = new Appointment(ObjectContext);
            }


            DateTime appDate = Convert.ToDateTime(PlannedDate.Value.Date);
            DateTime startDateTime = PlannedDate.Value;
            DateTime endDateTime = PlannedDate.Value.AddMinutes(((PhysiotherapyOrder)OrderObject).Duration.Value);
            IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(ObjectContext, AppointmentDefinitionEnum.PhysiotherapyOrder);
            if (appDefList.Count > 0)
            {
                newAppointment.AppointmentDefinition = (AppointmentDefinition)appDefList[0];
            }

            newAppointment.MasterResource = ((PhysiotherapyOrder)OrderObject).TreatmentDiagnosisUnit;
            newAppointment.Resource = TreatmentRoom;
            newAppointment.Patient = Episode.Patient;
            newAppointment.EpisodeAction = PhysiotherapyOrder.PhysiotherapyRequest;
            newAppointment.StartTime = startDateTime;
            newAppointment.EndTime = endDateTime;
            newAppointment.CurrentStateDefID = Appointment.States.New;
            newAppointment.Schedule = null;
            newAppointment.BreakAppointment = false;
            newAppointment.Notes = TTUtils.CultureService.GetText("M26694", "Planlamasız Oluşturuldu") + " / ";//????????????
            newAppointment.Notes += ProcedureObject.Name;
            newAppointment.AppointmentType = AppointmentTypeEnum.Intervention;
            newAppointment.AppDate = appDate;
            newAppointment.AppointmentDefinition = AppointmentDefinition.GetAppointmentDefinitionByName(ObjectContext, AppointmentDefinitionEnum.PhysiotherapyOrder).FirstOrDefault();
            if (((PhysiotherapyOrder)OrderObject).AppointmentCarrierList.Count > 0)
                newAppointment.AppointmentCarrier = ((PhysiotherapyOrder)OrderObject).AppointmentCarrierList[0];
            newAppointment.GivenBy = (ResUser)Common.CurrentResource;
            newAppointment.InitialObjectID = ObjectID.ToString();
            newAppointment.Action = null;
            newAppointment.SubActionProcedure = (SubActionProcedure)this;

            //this.ObjectContext.Save();
        }

        #region ITreatmentMaterialCollection Members
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection GetTreatmentMaterials()
        {
            return TreatmentMaterials;
        }
        #endregion
        public override ResUser GetPerformanceDoctor()
        {
            return ProcedureByUser;
        }

        public override bool CheckSubepisodeClosingDate()
        {
            return false;
        }

        public override bool SendToENabiz(bool isNewInserted)
        {
            if (IsOldAction == true)
                return false;
            if (CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed)
                return true;

            return false;

        }
        public PhysiotherapyOrderDetail(PhysiotherapyOrder physiotherapyOrder, Appointment appointment) : this(physiotherapyOrder.ObjectContext)
        {
            TreatmentRoom = (ResTreatmentDiagnosisRoom)appointment.Resource;
        }

        public PhysiotherapyOrderDetail(PhysiotherapyOrder physiotherapyOrder) : this(physiotherapyOrder.ObjectContext)
        {
            TreatmentRoom = physiotherapyOrder.TreatmentRoom;
        }

        public void IfLastCompletePhysiotherapyOrder()
        {
            bool allComplete = true;
            foreach (SubActionProcedure orderDetail in OrderObject.OrderDetails)
            {
                if (orderDetail.CurrentStateDef.Status == StateStatusEnum.Uncompleted && orderDetail.ObjectID != ObjectID)
                {
                    allComplete = false;
                }
            }
            if (allComplete)
            {
                //if (((PhysiotherapyOrder)this.OrderObject).CurrentStateDefID == PhysiotherapyOrder.States.Therapy)
                //    ((PhysiotherapyOrder)this.OrderObject).CurrentStateDefID=PhysiotherapyOrder.States.Completed;
            }
        }



        public override void Cancel()
        {
            base.Cancel();
            CancelMyNewAppoinments();
            CancelAccountingOperation();
            IfLastCompletePhysiotherapyOrder();
        }

        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (accTrx != null)
                return accTrx.SubEpisodeProtocol.Brans.Code;

            return null;
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            if (PhysiotherapyOrder != null && PhysiotherapyOrder.PhysiotherapyRequest != null && PhysiotherapyOrder.PhysiotherapyRequest.ProcedureDoctor != null)
                return PhysiotherapyOrder.PhysiotherapyRequest.ProcedureDoctor.DiplomaRegisterNo;

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}

        // Ãœcretini hasta mı ödeyecek bilgisini döndürür
        public bool IsPaid()
        {
            // todo merve Faturalanmış ön taburcu hastaları taburcu etmek için kod kapatıldı
            //SubEpisodeProtocol sep = SubEpisode.OpenSubEpisodeProtocol;
            //if (sep == null)
            //    throw new TTException(SystemMessage.GetMessage(663));

            //PayerTypeEnum? payerType = sep.Payer.Type.PayerType;
            //if (!payerType.HasValue)
            //    throw new TTException(TTUtils.CultureService.GetText("M27154", "Ãœcretlendirme sırasında hata oluştu. '") + sep.Payer.Name + "' kurumunun tip bilgisine ulaşılamıyor.");

            //if (payerType == PayerTypeEnum.Paid) // Ãœcretli hasta ise true döner
            //    return true;
            // Faturalanmış ön taburcu hastaları taburcu etmek için kod kapatıldı

            if (PhysiotherapyOrder.IsPaidTreatment == true) // IsPaidTreatment işaretli ise true döner
                return true;

            // PhysiotherapyRequest te aynı Paket ve aynı vücut bölgesi olan ve ücretli olarak işaretlenmiş bir PhysiotherapyOrder varsa bu PhysiotherapyOrderDetail de ücretli olmalı şeklinde istendi
            List<PhysiotherapyOrder> OrderList = new List<PhysiotherapyOrder>();
            foreach (PhysiotherapyOrder order in PhysiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrders)
            {
                if (order.PhysiotherapyOrderDetails.Where(x => x.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed).Count() == 0)
                    OrderList.Add(order);
            }

            if (OrderList.Where(x => x.IsPaidTreatment == true && x.PackageProcedure.Code == PhysiotherapyOrder.PackageProcedure.Code && x.FTRApplicationAreaDef == PhysiotherapyOrder.FTRApplicationAreaDef).Count() > 0)
            {
                PhysiotherapyOrder.IsPaidTreatment = true;
                return true;
            }

            return false;
        }

        // PhysiotherapyOrderDetail tamamlanırken uygun FTRPackageProcedure varsa Execution dan Completed adımına alır
        public void CompleteFTRPackageProcedure()
        {
            bool isPaid = IsPaid();
            List<FTRPackageProcedure> FTRPackageProcedureList = PhysiotherapyOrder.PhysiotherapyRequest.FTRPackageProcedures.Where(x => x.ProcedureObject.Code == PhysiotherapyOrder.PackageProcedure.Code &&
                                                                                                                                        x.PricingDate.Value.Date == PlannedDate.Value.Date &&
                                                                                                                                        x.PhysiotherapyOrderDetail.PhysiotherapyOrder.FTRApplicationAreaDef.ObjectID == PhysiotherapyOrder.FTRApplicationAreaDef.ObjectID &&
                                                                                                                                        x.CurrentStateDefID == TTObjectClasses.FTRPackageProcedure.States.Execution &&
                                                                                                                                        x.PhysiotherapyOrderDetail.IsPaid() == isPaid).ToList<FTRPackageProcedure>();

            foreach (FTRPackageProcedure ftrPP in FTRPackageProcedureList)
            {
                ftrPP.CreationDate = PlannedDate;
                ftrPP.PricingDate = PlannedDate;
                ftrPP.PerformedDate = PlannedDate;
                ftrPP.Update();
                ftrPP.CurrentStateDefID = TTObjectClasses.FTRPackageProcedure.States.Completed;
            }
        }

        // PhysiotherapyOrderDetail tamamdan geri alınırken gerekli FTRPackageProcedure leri de Completed dan Execution adımına geri alır (O güne ait başka tamamlanmış PhysiotherapyOrderDetail yoksa)
        public void UnCompleteFTRPackageProcedure()
        {
            bool isPaid = IsPaid();

            bool sameDayOtherCompletedPTODExists = PhysiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrderDetails.Where(x => x.ObjectID != ObjectID &&
                                                                            x.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed &&
                                                                            x.PlannedDate.Value.Date == PlannedDate.Value.Date &&
                                                                            x.PhysiotherapyOrder.FTRApplicationAreaDef.ObjectID == PhysiotherapyOrder.FTRApplicationAreaDef.ObjectID &&
                                                                            x.PhysiotherapyOrder.PackageProcedure != null &&
                                                                            x.PhysiotherapyOrder.PackageProcedure.Code == PhysiotherapyOrder.PackageProcedure.Code &&
                                                                            x.IsPaid() == isPaid).Any();
            // Aynı gün, aynı vücut bölgesi ve aynı paket için tamamlandı durumunda başka PhysiotherapyOrderDetail yoksa FTRPackageProcedure tekrar Execution adımına alınır
            if (sameDayOtherCompletedPTODExists == false)
            {
                List<FTRPackageProcedure> FTRPackageProcedureList = PhysiotherapyOrder.PhysiotherapyRequest.FTRPackageProcedures.Where(x => x.ProcedureObject.Code == PhysiotherapyOrder.PackageProcedure.Code &&
                                                                                                                                            x.PricingDate.Value.Date == PlannedDate.Value.Date &&
                                                                                                                                            x.PhysiotherapyOrderDetail.PhysiotherapyOrder.FTRApplicationAreaDef.ObjectID == PhysiotherapyOrder.FTRApplicationAreaDef.ObjectID &&
                                                                                                                                            x.CurrentStateDefID == TTObjectClasses.FTRPackageProcedure.States.Completed &&
                                                                                                                                            x.PhysiotherapyOrderDetail.IsPaid() == isPaid).ToList<FTRPackageProcedure>();
                foreach (FTRPackageProcedure ftrPP in FTRPackageProcedureList)
                    ftrPP.CurrentStateDefID = TTObjectClasses.FTRPackageProcedure.States.Execution;
            }
        }

        // FTR Uygulamaları için ücretlendirme yapar (Paket Hizmet Oluşturur gerekli ise)
        public void AccountingOperation()
        {
            if (PhysiotherapyOrder == null)
                throw new TTException(TTUtils.CultureService.GetText("M25681", "FTR Emri boş olamaz."));

            if (PhysiotherapyOrder.PackageProcedure == null)
                throw new TTException(TTUtils.CultureService.GetText("M25682", "FTR Emri'nin paket hizmeti boş olamaz."));

            if (PlannedDate == null)
                throw new TTException(TTUtils.CultureService.GetText("M25683", "FTR Uygulaması'nın planlama tarihi boş olamaz."));

            bool isPaid = IsPaid();

            // Aynı gün, aynı kodlu, aynı vücut bölgesinden ve iptal durumunda olmayan paket varsa tekrar paket oluşturulmaz
            FTRPackageProcedure FTRPackage = null;
            if (PhysiotherapyOrder.PhysiotherapyRequest.FTRPackageProcedures.Where(x => x.ProcedureObject.Code == PhysiotherapyOrder.PackageProcedure.Code && x.PricingDate.Value.Date == PlannedDate.Value.Date && x.PhysiotherapyOrderDetail.PhysiotherapyOrder.FTRApplicationAreaDef.ObjectID == PhysiotherapyOrder.FTRApplicationAreaDef.ObjectID && x.IsCancelled == false && x.PhysiotherapyOrderDetail.IsPaid() == isPaid).Count() == 0)
            {
                FTRPackage = new FTRPackageProcedure(ObjectContext);
                FTRPackage.ActionDate = Common.RecTime();
                FTRPackage.Amount = 1;
                FTRPackage.CurrentStateDefID = TTObjectClasses.FTRPackageProcedure.States.Execution;
                FTRPackage.ProcedureObject = PhysiotherapyOrder.PackageProcedure;
                FTRPackage.EpisodeAction = PhysiotherapyOrder.PhysiotherapyRequest;
                FTRPackage.PhysiotherapyOrderDetail = this;
                FTRPackage.RequestedByUser = PhysiotherapyRequest.ProcedureDoctor != null ? PhysiotherapyRequest.ProcedureDoctor : PhysiotherapyRequest.GetSubEpisodeStarter().GetSubEpisode().GetSubEpisodeProcedureDoctor();
                FTRPackage.MedulaReportNo = PhysiotherapyOrder.PhysiotherapyReports != null ? PhysiotherapyOrder.PhysiotherapyReports.ReportNo : null;
                FTRPackage.CreationDate = PlannedDate;
                FTRPackage.PricingDate = PlannedDate;
                FTRPackage.PerformedDate = PlannedDate;
                FTRPackage.AccountOperation(AccountOperationTimeEnum.PREPOST);
            }

            // FTR işlemi ücretlendirilir
            AccountOperation(AccountOperationTimeEnum.PREPOST);

            if (SubEpisode.OpenSubEpisodeProtocol != null)
            {
                PayerTypeEnum? payerType = SubEpisode.OpenSubEpisodeProtocol.Payer.Type.PayerType;

                if (!payerType.HasValue)
                    throw new TTException(TTUtils.CultureService.GetText("M27154", "Ãœcretlendirme sırasında hata oluştu. '") + SubEpisode.OpenSubEpisodeProtocol.Payer.Name + "' kurumunun tip bilgisine ulaşılamıyor.");

                if (payerType == PayerTypeEnum.Paid) // Ãœcretli hasta ise paket olmayan FTR işlemi fatura hariç yapılır ve çıkılır
                {
                    foreach (AccountTransaction accTrx in AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled).ToList())
                        accTrx.InvoiceInclusion = false;

                    return;
                }
            }

            if (isPaid)
            {
                AccountTransaction payerAccTrx = null;
                AccountTransaction patientAccTrx = null;

                // Paket Hizmet için Kurum Payı hasta payına çevrilir veya fiyatı hasta payının üstüne eklenip iptal edilir
                if (FTRPackage != null)
                {
                    FTRPackage.PatientPay = true;
                    payerAccTrx = FTRPackage.AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled && x.AccountPayableReceivable.Type == APRTypeEnum.PAYER).FirstOrDefault();
                    patientAccTrx = FTRPackage.AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled && x.AccountPayableReceivable.Type == APRTypeEnum.PATIENT).FirstOrDefault();

                    if (payerAccTrx != null && patientAccTrx == null) // Sadece Kurum Payı varsa hasta payına çevrilir
                        payerAccTrx.TurnToPatientShare(true, true);
                    else if (payerAccTrx != null && patientAccTrx != null) // Kurum payı ve hasta payı varsa, kurum payı iptal edilip fiyatı hasta payının üstüne eklenir
                    {
                        payerAccTrx.CurrentStateDefID = AccountTransaction.States.Cancelled;
                        patientAccTrx.TurnToPatientShare(true, true);
                    }
                }

                // FTR işlemi için Kurum Payı hasta payına çevrilir veya fiyatı hasta payının üstüne eklenip iptal edilir
                PatientPay = true;
                payerAccTrx = AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled && x.AccountPayableReceivable.Type == APRTypeEnum.PAYER).FirstOrDefault();
                patientAccTrx = AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled && x.AccountPayableReceivable.Type == APRTypeEnum.PATIENT).FirstOrDefault();

                if (payerAccTrx != null && patientAccTrx == null) // Sadece Kurum Payı varsa hasta payına çevrilir
                    payerAccTrx.TurnToPatientShare(false, true);
                else if (payerAccTrx != null && patientAccTrx != null) // Kurum payı ve hasta payı varsa, kurum payı iptal edilip fiyatı hasta payının üstüne eklenir
                {
                    payerAccTrx.CurrentStateDefID = AccountTransaction.States.Cancelled;
                    patientAccTrx.TurnToPatientShare(false, true);
                }
                else if (payerAccTrx == null && patientAccTrx != null)
                    patientAccTrx.InvoiceInclusion = false;
            }
        }

        // FTR Uygulaması iptal edildiğinde ftr hizmetini iptal eden ve paket hizmeti iptal eden veya güncelleyen (PhysiotherapyOrderDetail ı) metod
        // Aynı gün, aynı paket kodlu, aynı vücut bölgesinden tamamlanmış başka bir PhysiotherapyOrderDetail varsa, bu PhysiotherapyOrderDetail in paketini diğerine geçirir
        // Yoksa bu PhysiotherapyOrderDetail in paketi iptal edilir
        public void CancelAccountingOperation()
        {
            List<FTRPackageProcedure> ftrPackageList = FTRPackageProcedure.Where(x => !x.IsCancelled).ToList();
            if (ftrPackageList.Any()) // İptal durumunda olmayan paket hizmeti varsa
            {
                bool isPaid = IsPaid();

                List<PhysiotherapyOrderDetail> sameDayOtherPTODList = PhysiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.ObjectID != ObjectID &&
                                                                              (c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution || c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed) &&
                                                                              c.PlannedDate.Value.Date == PlannedDate.Value.Date && c.PhysiotherapyOrder != null).ToList<PhysiotherapyOrderDetail>();

                PhysiotherapyOrderDetail sameDayOtherPTOD = sameDayOtherPTODList.Where(x => x.PhysiotherapyOrder.FTRApplicationAreaDef.ObjectID == PhysiotherapyOrder.FTRApplicationAreaDef.ObjectID &&
                                                                              x.PhysiotherapyOrder.PackageProcedure != null &&
                                                                              x.PhysiotherapyOrder.PackageProcedure.Code == PhysiotherapyOrder.PackageProcedure.Code &&
                                                                              x.IsPaid() == isPaid).FirstOrDefault();
                foreach (FTRPackageProcedure FTRPackage in ftrPackageList)
                {
                    if (sameDayOtherPTOD != null)  // Aynı gün başka uygun PhysiotherapyOrderDetail varsa paket iptal edilmez sadece PhysiotherapyOrderDetail i güncellenir
                        FTRPackage.PhysiotherapyOrderDetail = sameDayOtherPTOD;
                    else
                        ((ITTObject)FTRPackage).Cancel(); // Aynı gün başka uygun PhysiotherapyOrderDetail yoksa paket iptal edilir
                }
            }

            CancelMyAccountTransactions();
        }

        public static void MedulaProcedureEntry(List<PhysiotherapyOrderDetail> podList)
        {
            if (podList != null && podList.Count > 0)
            {
                List<SubActionProcedure> spList = new List<SubActionProcedure>();

                foreach (PhysiotherapyOrderDetail pod in podList)
                {
                    foreach (FTRPackageProcedure FTRPackage in pod.FTRPackageProcedure) // Sadece paketler medulaya hizmet kayıt yapılıyor
                    {
                        if (!FTRPackage.IsCancelled)
                            spList.Add(FTRPackage);
                    }
                }

                AccountTransaction.MedulaProcedureEntry(spList);
            }
        }

        public static void MedulaProcedureEntryCancel(List<PhysiotherapyOrderDetail> podList)
        {
            if (podList != null && podList.Count > 0)
            {
                List<SubActionProcedure> spList = new List<SubActionProcedure>();

                foreach (PhysiotherapyOrderDetail pod in podList)
                {
                    spList.Add(pod);

                    foreach (FTRPackageProcedure FTRPackage in pod.FTRPackageProcedure)
                    {
                        if (!FTRPackage.IsCancelled)
                        {
                            bool isPaid = pod.IsPaid();

                            bool sameDayOtherPODExists = pod.PhysiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrderDetails.Where(x => x.ObjectID != pod.ObjectID &&
                                                                             x.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed &&
                                                                             x.PlannedDate.Value.Date == pod.PlannedDate.Value.Date &&
                                                                             x.FTRPackageProcedure.Where(p => !p.IsCancelled).Any() == false &&
                                                                             x.PhysiotherapyOrder.PackageProcedure != null &&
                                                                             x.PhysiotherapyOrder.PackageProcedure == pod.PhysiotherapyOrder.PackageProcedure &&
                                                                             x.IsPaid() == isPaid &&
                                                                             podList.Contains(x) == false).Any();

                            // Aynı gün, aynı paket kodlu, tamamlanmış başka bir PhysiotherapyOrderDetail varsa, bu PhysiotherapyOrderDetail in paketi iptal edilmeyip
                            // diğerine geçirileceği için paket hizmetin meduladan hizmet kaydının iptal edilmesine gerek yok
                            if (!sameDayOtherPODExists)
                                spList.Add(FTRPackage);
                        }
                    }
                }

                AccountTransaction.MedulaProcedureEntryCancel(spList);
            }
        }

        public override void AccountOperationAfterUpdate() { }

        public override void SetPerformedDate()// İşlemin yapıldığı tarihi set edecek şekilde override edilmeli
        {
            if (Common.RecTime().Date >= PlannedDate.Value.Date)
            {
                if ((Common.RecTime().Date == PlannedDate.Value.Date) && (Common.RecTime().TimeOfDay < PlannedDate.Value.TimeOfDay))
                {
                    PerformedDate = Common.RecTime();
                }
                else
                {
                    PerformedDate = PlannedDate;
                }
                if (CreationDate > PerformedDate)
                {
                    CreationDate = PerformedDate;//Eğer işlem oluşturulduğu tarihten geçmiş bir tarihte planlanıp tamamlanıyorsa oluşturma tarihi de geçmişe alınıyor.
                }
            }
            else
            {
                throw new Exception(TTUtils.CultureService.GetText("M26077", "İleri Tarihli İşlemleri Bugünden Tamamlayamazsınız!"));
            }

        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PhysiotherapyOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PhysiotherapyOrderDetail.States.Execution && toState == PhysiotherapyOrderDetail.States.Completed)
                PreTransition_Execution2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PhysiotherapyOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PhysiotherapyOrderDetail.States.Completed && toState == PhysiotherapyOrderDetail.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == PhysiotherapyOrderDetail.States.Execution && toState == PhysiotherapyOrderDetail.States.Completed)
                PostTransition_Execution2Completed();
            else if (fromState == PhysiotherapyOrderDetail.States.Completed && toState == PhysiotherapyOrderDetail.States.Execution)
                PostTransition_Completed2Execution();
            else if (fromState == PhysiotherapyOrderDetail.States.Execution && toState == PhysiotherapyOrderDetail.States.Cancelled)
                PostTransition_Execution2Cancelled();
            else if (fromState == PhysiotherapyOrderDetail.States.ApprovalForCancel && toState == PhysiotherapyOrderDetail.States.Cancelled)
                PostTransition_ApprovalForCancel2Cancelled();
            else if (fromState == PhysiotherapyOrderDetail.States.Execution && toState == PhysiotherapyOrderDetail.States.Aborted)
                PostTransition_Execution2Aborted();
            else if (fromState == PhysiotherapyOrderDetail.States.Aborted && toState == PhysiotherapyOrderDetail.States.Execution)
                PostTransition_Aborted2Execution();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PhysiotherapyOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PhysiotherapyOrderDetail.States.Completed && toState == PhysiotherapyOrderDetail.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
            else if (fromState == PhysiotherapyOrderDetail.States.Execution && toState == PhysiotherapyOrderDetail.States.Cancelled)
                UndoTransition_Execution2Cancelled(transDef);
            else if (fromState == PhysiotherapyOrderDetail.States.ApprovalForCancel && toState == PhysiotherapyOrderDetail.States.Cancelled)
                UndoTransition_ApprovalForCancel2Cancelled(transDef);
            else if (fromState == PhysiotherapyOrderDetail.States.Execution && toState == PhysiotherapyOrderDetail.States.Completed)
                UndoTransition_Execution2Completed(transDef);
        }

    }
}