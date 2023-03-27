
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
    /// Hasta Yatış  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public partial class InpatientAdmission : BaseInpatientAdmission, IOAInPatientAdmission
    {
        public partial class GetInpatientFolderInfo_Class : TTReportNqlObject
        {
        }

        public partial class GetInpatientDischargeInfo_Class : TTReportNqlObject
        {
        }

        public partial class GetInpatientPrisonerDelivery_Class : TTReportNqlObject
        {
        }

        public partial class GetInpatientAdmissionDeclaration_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetLastTreatmentClinic_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetDischargedInpatient_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetFirstTreatmentClinic_Class : TTReportNqlObject
        {
        }

        public partial class GetDischargeNumberForEtiquetteOffice_Class : TTReportNqlObject
        {
        }

        public partial class GetUrgentPatientListByDate_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledDischargedInpatient_Class : TTReportNqlObject
        {
        }

        public partial class GetDischargedPatientListByDischargeNumber_Class : TTReportNqlObject
        {
        }

        public partial class GetDischargedPatientListByDate_Class : TTReportNqlObject
        {
        }

        public partial class GetDischargeNumberForEtiquetteUnit_Class : TTReportNqlObject
        {
        }

        public partial class PlastikCerrahiIstatistik_Class : TTReportNqlObject
        {
        }

        public partial class SelectActiveInpatientAdmissionCollectedInvoiceRQ_Class : TTReportNqlObject
        {
        }

        public partial class GetForeignInpatientsNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetInPatientEtiquette_Class : TTReportNqlObject
        {
        }

        public partial class GetDoctorFaultAmount_Class : TTReportNqlObject
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();

            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate


            base.PreUpdate();
            if (!NotUpdateEpisodeAction)
            {
                if (InPatientTreatmentClinicApplications.FirstOrDefault(dr => dr.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Procedure && dr.IsDailyOperation != true) != null) // Procedure Aşamasında Klinik işlemi varsa 
                    AllocateNewBed(false, false);
            }

            if (TransDef == null)
            {
                if (CurrentStateDefID == InpatientAdmission.States.Request)
                    CurrentStateDefID = InpatientAdmission.States.ClinicProcedure;
            }


            #endregion PreUpdate
        }


        protected override void PostUpdate()
        {
            #region PostUpdate


            base.PostUpdate();


            #endregion PostUpdate
        }

        protected override void PreDelete()
        {
            #region PreDelete
            base.PreDelete();

            #endregion PreDelete
        }

        protected override void PostDelete()
        {
            #region PostDelete
            base.PostDelete();

            #endregion PostDelete
        }



        protected void PreTransition_Request2ClinicProcedure()
        {
            // From State : Request   To State : ClinicProcedure
            #region PreTransition_Request2ClinicProcedure
            if (ReportNo.Value == null)
                ReportNo.GetNextValue(MasterResource.ObjectID.ToString(), Common.RecTime().Year);
            #endregion PreTransition_Request2ClinicProcedure
        }

        protected void PostTransition_Request2ClinicProcedure()
        {
            // From State : Request   To State : ClinicProcedure
            #region PostTransition_Request2ClinicProcedure
            //Tıbbi kayıt no burda atanır
            if (QuarantineProtocolNo.Value == null)
                QuarantineProtocolNo.GetNextValue(Common.RecTime().Year);

            new InPatientTreatmentClinicApplication(this, TreatmentClinic, FromResource);


            #endregion PostTransition_Request2ClinicProcedure
        }

        protected void UndoTransition_Request2ClinicProcedure(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Request   To State : ClinicProcedure
            #region UndoTransition_Request2ClinicProcedure
            NoBackStateBack();
            #endregion UndoTransition_Request2ClinicProcedure
        }

        protected void PostTransition_ClinicProcedure2Cancelled()
        {
            // From State : ClinicProcedure   To State : Cancelled
            #region PostTransition_ClinicProcedure2Cancelled
            Cancel();
            #endregion PostTransition_ClinicProcedure2Cancelled
        }

        protected void UndoTransition_ClinicProcedure2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ClinicProcedure   To State : Cancelled
            #region UndoTransition_ClinicProcedure2Cancelled
            UndoCancel();
            #endregion UndoTransition_ClinicProcedure2Cancelled
        }



        protected void PostTransition_Request2Cancelled()
        {
            // From State : Request   To State : Cancelled
            #region PostTransition_Request2Cancelled
            Cancel();
            #endregion PostTransition_Request2Cancelled
        }

        protected void UndoTransition_Request2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Request   To State : Cancelled
            #region UndoTransition_Request2Cancelled
            UndoCancel();
            #endregion UndoTransition_Request2Cancelled
        }


        protected void PostTransition_ClinicProcedure2Discharged()
        {
            // From State : ClinicProcedure  To State : Discharged
            #region PostTransition_ClinicProcedure2Discharged


            if (DischargeNumber.Value == null)
                DischargeNumber.GetNextValue(Common.RecTime().Year);

            Discharged();
            CheckAndCloseEpisode(true);


            #endregion PostTransition_ClinicProcedure2Discharged
        }

        protected void UndoTransition_ClinicProcedure2Discharged(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ReadyToDischarge   To State : Discharged
            #region UndoTransition_ClinicProcedure2Discharged

            UndoDischarged();
            UndoCloseEpisode();

            #endregion UndoTransition_ClinicProcedure2Discharged
        }







        #region Methods
        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.InpatientAdmission;
            }
        }


        public override void SetMasterResource(Episode episode, bool notSetNull)
        {
            if (MasterResource == null)
            {
                //İlk tanımlanan ResQuarantine tipindeki Kaynağı defulat olark master Resource olarak atar
                IList Quarantines = ResQuarantine.GetActiveQuarantines(ObjectContext);
                if (Quarantines.Count < 1)
                {
                    // throw new Exception(SystemMessage.GetMessage(1174));
                    base.SetMasterResource(episode,notSetNull);

                }
                else
                {
                    MasterResource = (ResSection)Quarantines[0];
                }
            }
        }


        protected override void CheckPatientExclusive(Episode episode)
        {
            foreach (Episode ep in episode.Patient.Episodes)
            {
                foreach (InPatientTreatmentClinicApplication itcapp in ep.InPatientTreatmentClinicApplications)
                {
                    if (itcapp.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Acception || itcapp.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Procedure)
                    {
                        string[] hataParamList = new string[] { itcapp.CurrentStateDef.DisplayText, ((DateTime)itcapp.ActionDate).ToShortDateString(), ObjectDef.ApplicationName.ToString(), ObjectDef.ApplicationName.ToString() };
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(168, hataParamList));

                        //Bu hastada,  {0} adımındaki   {1} tarihli   {2}   işlemi tamamlanmadan ya da iptal edilmeden  yeni bir  {3}  işlemi başlatılamaz.

                    }
                }
            }
        }

            public void Discharged()
        {
            FinancialControlToDischarge();

            var activeInPatientTrtmentClcApp = ActiveInPatientTrtmentClcApp;
            // önceki aşamalarda yatak boşaltıldı.
            //   this.DeallocateLastBed();

            //Close my last inpatient subepisode
            if (activeInPatientTrtmentClcApp.SubEpisode != null)
            {
                if (activeInPatientTrtmentClcApp.SubEpisode.CurrentStateDefID == SubEpisode.States.Opened)
                {
                    activeInPatientTrtmentClcApp.SubEpisode.Close(activeInPatientTrtmentClcApp.SubEpisodeClosingDate());
                }
            }

        }
        public void UndoDischarged()
        {

            HospitalDischargeDate = null;
            var activeInPatientTrtmentClcApp = ActiveInPatientTrtmentClcApp;
            if (activeInPatientTrtmentClcApp.SubEpisode != null)
            {
                if (activeInPatientTrtmentClcApp.SubEpisode.CurrentStateDefID == SubEpisode.States.Closed)
                {
                    //((ITTObject)this.ActiveInPatientTrtmentClcApp.SubEpisode).UndoLastTransition();
                    activeInPatientTrtmentClcApp.SubEpisode.CurrentStateDefID = SubEpisode.States.Opened;
                    activeInPatientTrtmentClcApp.SubEpisode.ClosingDate = null;
                }
            }
        }

        public void EmptyCupboard()
        {
            if (Cupboard != null)
            {
                Cupboard.UsedByAction = null;
            }
        }

        private bool _undoByMasterAction = false;
        public bool UndoByMasterAction
        {
            get
            {
                return _undoByMasterAction;
            }
            set
            {
                _undoByMasterAction = value;
            }
        }

        public void CheckUndo()
        {
            if (!UndoByMasterAction)
            {
                string msg = "Hasta Yatış(Inpatient Admission) başına geri alınamaz ";
                throw new Exception(msg);
            }
        }

        private bool _cancelledByMasterAction = false;
        public bool CancelledByMasterAction
        {
            get
            {
                return _cancelledByMasterAction;
            }
            set
            {
                _cancelledByMasterAction = value;
            }
        }

        public override void Cancel()
        {
            if (CancelledByMasterAction)
            {
                bool changePatientStatus = true;

                foreach (InpatientAdmission ia in Episode.InpatientAdmissions)
                {
                    if (ia.ObjectID != ObjectID && ia.CurrentStateDef.Status != StateStatusEnum.Cancelled && ia.InPatientTreatmentClinicApplications.Count > 0)
                    {
                        changePatientStatus = false;
                    }
                }

                //EmptyCupboard();
                DeallocateLastBed();
                if (changePatientStatus)
                {
                    //this.Episode.QuarantineInPatientDate = null;
                    //this.Episode.QuarantineDischargeDate = null;
                    Episode.PatientStatus = PatientStatusEnum.Outpatient;
                    Episode.Patient.InpatientEpisode = null;
           
                    //this.UndoControlAndAddEpisodeProtocol();
                }
                base.Cancel();
            }
            else
            {

                string msg = TTUtils.CultureService.GetText("M27222", "Yatış İşlemleri tek başına  iptal edilemez.Başlattığı Klinik işlemi iptal edildiğinde otomatik olarak iptal edilir.");
                throw new Exception(msg);
            }
        }

        public override void UndoCancel()
        {
            base.UndoCancel();
            NoBackStateBack();
        }



        public string GetDischargedConclusion()
        {
            return InpatientAdmission.GetDischargedConclusion(this);
        }

        public static string GetDischargedConclusion(InpatientAdmission inpatientAdmission)
        {
            TreatmentDischarge treatmentDischarge = inpatientAdmission.MyTreatmentDischarge;
            if (treatmentDischarge != null)
            {
                if (treatmentDischarge.Conclusion != null)
                    return treatmentDischarge.Conclusion.ToString();
            }
            return "";
        }



        public TreatmentDischarge MyTreatmentDischarge
        {
            get
            {
                foreach (InPatientTreatmentClinicApplication iPTCA in InPatientTreatmentClinicApplications)
                {
                    if (iPTCA.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Discharged)
                    {
                        if (iPTCA.TreatmentDischarge != null)
                        {
                            return iPTCA.TreatmentDischarge;
                        }
                    }
                }
                return null;
            }
        }

        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList = base.OldActionPropertyList();
            if (propertyList == null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();

            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M26268", "Karantina Protokol No"), Common.ReturnObjectAsString(QuarantineProtocolNo)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M24448", "Yatış Tarihi"), Common.ReturnObjectAsString(HospitalInPatientDate)));
            //propertyList.Add(new OldActionPropertyObject("Yatış Sebebi",Common.ReturnObjectAsString(ReasonForInpatientAdmission)));
            if (TreatmentClinic != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M22986", "Tedavi Gördüğü Klinik"), Common.ReturnObjectAsString(TreatmentClinic.Name)));
            if (RoomGroup != null)
            {
                if (RoomGroup.Ward != null)
                    propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M24457", "Yattığı Klinik"), Common.ReturnObjectAsString(RoomGroup.Ward.Name)));
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M27226", "Yattığı Oda grup"), Common.ReturnObjectAsString(RoomGroup.Name)));
            }
            if (Room != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M27225", "Yattığı Oda"), Common.ReturnObjectAsString(Room.Name)));
            if (Bed != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M27227", "Yattığı Yatak"), Common.ReturnObjectAsString(Bed.Name)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M22570", "Taburcu Tarihi"), Common.ReturnObjectAsString(HospitalDischargeDate)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject("Taburcu Numarası ", Common.ReturnObjectAsString(DischargeNumber)));
            return propertyList;
        }


        //        protected override List<List<List<OldActionPropertyObject>>> OldActionChildRelationList()
        //        {
        //            List<List<List<OldActionPropertyObject>>> gridList;
        //            if(base.OldActionChildRelationList()==null)
        //                gridList=new List<List<List<OldActionPropertyObject>>>();
        //            else
        //                gridList=base.OldActionChildRelationList();
        //            // ValueMatials
        //            List<List<OldActionPropertyObject>> gridMaterialRowList=new List<List<OldActionPropertyObject>>();
        //            foreach(InpatientAdmissionValuableMaterial Material in this.Episode.ValuableMaterials)
        //            {
        //                // her bir satyry için kolonlary ta?yyan Liste
        //                List<OldActionPropertyObject> gridMaterialRowColumnList=new List<OldActionPropertyObject>();
        //                gridMaterialRowColumnList.Add(new OldActionPropertyObject("İşlem Tarihi",Common.ReturnObjectAsString(Material.ProcessDate)));
        //                gridMaterialRowColumnList.Add(new OldActionPropertyObject("Karantina işlem Türü",Common.ReturnObjectAsString(Material.QuarantineProcessType)));
        //                gridMaterialRowColumnList.Add(new OldActionPropertyObject("Değerli Eşya",Common.ReturnObjectAsString(Material.Material.Material)));
        //                gridMaterialRowColumnList.Add(new OldActionPropertyObject("Miktar",Common.ReturnObjectAsString(Material.Amount)));
        //                gridMaterialRowList.Add(gridMaterialRowColumnList);
        //            }
        //            gridList.Add(gridMaterialRowList);
        //
        //            // Money
        //            List<List<OldActionPropertyObject>> gridMoneyRowList=new List<List<OldActionPropertyObject>>();
        //            foreach(InpatientAdmissionMoney Money in this.Episode.Money)
        //            {
        //                // her bir satyry için kolonlary ta?yyan Liste
        //                List<OldActionPropertyObject> gridMoneyRowColumnList=new List<OldActionPropertyObject>();
        //                gridMoneyRowColumnList.Add(new OldActionPropertyObject("İşlem Tarihi",Common.ReturnObjectAsString(Money.ProcessDate)));
        //                gridMoneyRowColumnList.Add(new OldActionPropertyObject("Karantina işlem Türü",Common.ReturnObjectAsString(Money.QuarantineProcessType)));
        //                gridMoneyRowColumnList.Add(new OldActionPropertyObject("Para Birimi",Common.ReturnObjectAsString(Money.MonetaryUnit.MonetaryUnit)));
        //                gridMoneyRowColumnList.Add(new OldActionPropertyObject("Miktar",Common.ReturnObjectAsString(Money.Amount)));
        //                gridMoneyRowColumnList.Add(new OldActionPropertyObject("Makbuz No",Common.ReturnObjectAsString(Money.ReceiptNo)));
        //                gridMoneyRowList.Add(gridMoneyRowColumnList);
        //            }
        //            gridList.Add(gridMoneyRowList);
        //
        //
        //            return gridList;
        //        }

        public InpatientAdmission(TTObjectContext objectContext, EpisodeAction episodeAction)
            : this(objectContext)
        {
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = InpatientAdmission.States.Request;
            MasterAction = episodeAction;
            Episode = episodeAction.Episode;
        }

        public string GetAccountCode(AccountEntegrationAccountTypeEnum pType)
        {
            IList codeList = null;
            codeList = AccountCodeDefinition.GetByAccountType(ObjectContext, pType);

            if (codeList.Count == 0)
                throw new TTException(SystemMessage.GetMessageV3(496, new string[] { pType.ToString() }));
            else if (codeList.Count > 1)
                throw new TTException(SystemMessage.GetMessageV3(496, new string[] { pType.ToString() }));
            else
            {
                foreach (AccountCodeDefinition codeDef in codeList)
                {
                    string code = codeDef.AccountCode.ToString().Trim();
                    return code;
                    /*
                    if (code.IndexOf(".0000") == -1)
                        throw new TTException("Muhasebe Hesap Kodunda XXXXXX kodu ile değiştirilecek kısım (0000) bulunamadı! (" + pType.ToString() + ")");
                    else
                    {
                        if (SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") == "")
                            throw new TTException("XXXXXX muhasebe kodu sistem parametresi bulunamadı!");
                        else
                        {
                            code = code.Substring(0, code.IndexOf(".")+1) + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + code.Substring(code.IndexOf(".")+5, code.Length - (code.IndexOf(".")+5));
                            return code;
                        }
                    }
                     */
                }
            }
            return null;
        }

        /*
        public void ControlAndAddEpisodeProtocol()
        {
            Guid bulletinProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("DEFAULTBULLETINPROTOCOL", "af9fc8c0-3e55-434d-91e1-d758362fcba7"));
            Guid sameDayProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("DEFAULTSGKOUTPATIENTSAMEDAYPROTOCOL", "6514e4ec-5798-4a46-9ce3-5f6a92beaaf3"));
            Guid greenAreaProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("DEFAULTGREENAREAEXAMINATIONPROTOCOL", "e8c0d3b7-5a56-45c8-98bd-d5ad04320f0c"));

            foreach (EpisodeProtocol ep in this.Episode.EpisodeProtocols)
            {
                if (ep.CurrentStateDefID == EpisodeProtocol.States.OPEN)
                {
                    if (ep.Protocol.ObjectID.Equals(bulletinProtocolGuid))
                    {
                        this.EpisodeProtocol = this.Episode.AddDefaultPublicProtocolIfHasBulletin(false);
                        break;
                    }
                    else if (ep.Protocol.ObjectID.Equals(sameDayProtocolGuid))
                    {
                        this.EpisodeProtocol = this.Episode.AddDefaultPublicProtocolIfHasSameDayProtocol(false);
                        break;
                    }
                    else if (ep.Protocol.ObjectID.Equals(greenAreaProtocolGuid))
                    {
                        this.EpisodeProtocol = this.Episode.AddDefaultPublicProtocolIfHasGreenAreaProtocol(false);
                        break;
                    }
                }
            }
        }
        */

        /*
        public void UndoControlAndAddEpisodeProtocol()
        {
            Guid bulletinProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("DEFAULTBULLETINPROTOCOL", "af9fc8c0-3e55-434d-91e1-d758362fcba7"));
            Guid sameDayProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("DEFAULTSGKOUTPATIENTSAMEDAYPROTOCOL", "6514e4ec-5798-4a46-9ce3-5f6a92beaaf3"));

            foreach (SubEpisode se in Episode.SubEpisodes)
            {
                foreach (SubEpisodeProtocol sep in se.SubEpisodeProtocols)
                {
                    if (sep.IsActive == true)
                    {
                        if (sep.Protocol.ObjectID.Equals(bulletinProtocolGuid))
                        {
                            this.Episode.CloseDefaultPublicProtocolIfHasBulletin(this.EpisodeProtocol);
                            break;
                        }
                        else if (sep.Protocol.ObjectID.Equals(sameDayProtocolGuid))
                        {
                            this.Episode.CloseDefaultPublicProtocolIfHasSameDayProtocol(this.EpisodeProtocol);
                            break;
                        }
                    }
                }
            }
        }
        */

        //bedDay - bedProcedureCount;
        public static int GetExcessOfRealBedDayToBedProcedure(InpatientAdmission inpatientAdmission)
        {
            DateTime inpatientDate = DateTime.Now;
            DateTime dischargeDate = Convert.ToDateTime("01/01/1900 00:00:00");
            bool control = true;

            foreach (InPatientTreatmentClinicApplication inPatientTreatClinicApp in inpatientAdmission.InPatientTreatmentClinicApplications)
            {
                if (inPatientTreatClinicApp.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                {
                    if (inPatientTreatClinicApp.ClinicInpatientDate != null && inPatientTreatClinicApp.ClinicDischargeDate != null)
                    {
                        if (Common.DateDiffV2(0, Convert.ToDateTime(inPatientTreatClinicApp.ClinicInpatientDate), Convert.ToDateTime(inpatientDate), false) < 0)
                            inpatientDate = (DateTime)inPatientTreatClinicApp.ClinicInpatientDate;

                        if (Common.DateDiffV2(0, Convert.ToDateTime(dischargeDate), Convert.ToDateTime(inPatientTreatClinicApp.ClinicDischargeDate), false) < 0)
                            dischargeDate = (DateTime)inPatientTreatClinicApp.ClinicDischargeDate;
                    }
                    else
                    {
                        control = false;
                        break;
                    }
                }
                else
                {
                    control = false;
                    break;
                }
            }

            if (control)
            {
                int bedDay = Common.DateDiff(Common.DateIntervalEnum.Day, dischargeDate.Date, inpatientDate.Date);
                int bedProcedureCount = 0;

                foreach (BaseBedProcedure bedProcedure in inpatientAdmission.BedProcedures)
                {
                    foreach (AccountTransaction accTrx in bedProcedure.AccountTransactions)
                    {
                        if (accTrx.CurrentStateDefID != AccountTransaction.States.Cancelled)
                            bedProcedureCount += Convert.ToInt16(accTrx.Amount);
                    }
                }
                return bedDay - bedProcedureCount;
                //                if (bedDay != bedProcedureCount)
                //                {
                //                    string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Hastanın yattığı gün sayısı ile oluşan yatak hizmeti sayısı arasında uyumsuzluk vardır!\r\nYattığı Gün Sayısı: " + bedDay.ToString() + "\r\nYatak Hizmeti Sayısı: " + bedProcedureCount.ToString() + "\r\nDevam etmek istiyor musunuz?", 1);
                //                    if (result == "H")
                //                        throw new Exception(SystemMessage.GetMessage(80));
                //                }
            }
            return 0;
        }


        ///*
        // * MEDULA SEVK KAYIT IPTAL METODU
        // * */

        //public bool MedulaESevkKayitIptalSync()
        //{

        //    try
        //    {
        //        SevkIslemleri.sevkIptalCevapDVO sevkIptalCevapDVO = SevkIslemleri.WebMethods.sevkKayitIptalSync(TTObjectClasses.Sites.SiteLocalHost, GetSevkKayitIptalDVO());
        //        if (sevkIptalCevapDVO != null)
        //        {
        //            if (string.IsNullOrEmpty(sevkIptalCevapDVO.sonucKodu) == false)
        //            {
        //                if (sevkIptalCevapDVO.sonucKodu.Equals("0000"))
        //                {
        //                    InfoBox.Alert("Sevk Takip No: " + this.SubEpisode.FirstSubEpisodeProtocol.MedulaTakipNo + " , E-Sevk No: " + this.MedulaESevkNo + " olan sevkin iptal işlemi başarı ile sonuçlandı.", MessageIconEnum.InformationMessage);
        //                    this.MedulaESevkNo = null;
        //                    return true;
        //                }
        //                else
        //                {
        //                    if (string.IsNullOrEmpty(sevkIptalCevapDVO.sonucMesaji) == false)
        //                        throw new Exception("Sonuç Mesajı :" + sevkIptalCevapDVO.sonucMesaji);
        //                    else
        //                        throw new Exception("Sonuç mesajı alanı boş! Sonuç Kodu: " + sevkIptalCevapDVO.sonucKodu);
        //                }
        //            }
        //            else
        //            {
        //                if (string.IsNullOrEmpty(sevkIptalCevapDVO.sonucMesaji) == false)
        //                    throw new Exception(" Sonuç Mesajı :" + sevkIptalCevapDVO.sonucMesaji);
        //                else
        //                    throw new Exception("Sevk bildirimi iptal işleminde hata var.Sonuç Kodu ve sonuç mesajı alanları boş!");

        //            }
        //        }
        //        else
        //            throw new Exception("Medulaya sevk bildirimi iptal işlemi yapılamadı.Cevap dönmedi!");

        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Medula sevk bildirimi iptal işlemi sırasında hata oluştu! " + e.Message);
        //    }
        //}

        ///*
        // * MEDULA SEVK KAYIT IPTAL DVO HAZIRLANMASI
        // * */

        //public SevkIslemleri.sevkKayitIptalDVO GetSevkKayitIptalDVO()
        //{
        //    SevkIslemleri.sevkKayitIptalDVO sevkKayitIptalDVO = new SevkIslemleri.sevkKayitIptalDVO();

        //    if (this.SubEpisode != null && this.SubEpisode.Episode != null && this.SubEpisode.FirstSubEpisodeProtocol != null && this.SubEpisode.FirstSubEpisodeProtocol.MedulaTakipNo != null && this.MedulaESevkNo != null)
        //    {
        //        sevkKayitIptalDVO.sevkTakipNo = this.SubEpisode.FirstSubEpisodeProtocol.MedulaTakipNo;
        //    }
        //    else
        //    {
        //        throw new Exception("Medulaya sevk bildirimi yapılmamış. Öncelikle bildirimi yapmalısınız!");
        //    }

        //    sevkKayitIptalDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

        //    return sevkKayitIptalDVO;
        //}



        ///*
        // * MEDULA MUTAT DIŞI ARAÇ RAPOR SIL METODU
        // * */

        //public bool MutatDisiAracRaporSilSync()
        //{

        //    try
        //    {
        //        SevkIslemleri.mutatDisiIptalCevapDVO mutatDisiIptalCevapDVO = SevkIslemleri.WebMethods.mutatDisiAracRaporSilSync(TTObjectClasses.Sites.SiteLocalHost, GetMutatDisiRaporIptalDVO());
        //        if (mutatDisiIptalCevapDVO != null)
        //        {
        //            if (string.IsNullOrEmpty(mutatDisiIptalCevapDVO.sonucKodu) == false)
        //            {
        //                if (mutatDisiIptalCevapDVO.sonucKodu.Equals("0000"))
        //                {
        //                    InfoBox.Alert("Mutat dışı araç rapor id: " + this.MedulaMutatDisiAracRaporNo + " olan raporun silme işlemi başarı ile sonuçlandı.", MessageIconEnum.InformationMessage);
        //                    this.MedulaMutatDisiAracRaporNo = null;
        //                    return true;
        //                }
        //                else
        //                {
        //                    if (string.IsNullOrEmpty(mutatDisiIptalCevapDVO.sonucMesaji) == false)
        //                        throw new Exception("Sonuç Mesajı :" + mutatDisiIptalCevapDVO.sonucMesaji);
        //                    else
        //                        throw new Exception("Sonuç mesajı alanı boş! Sonuç Kodu: " + mutatDisiIptalCevapDVO.sonucKodu);
        //                }
        //            }
        //            else
        //            {

        //                if (string.IsNullOrEmpty(mutatDisiIptalCevapDVO.sonucMesaji) == false)
        //                    throw new Exception("Sonuç Mesajı :" + mutatDisiIptalCevapDVO.sonucMesaji);
        //                else
        //                    throw new Exception("Sonuç mesajı ve Sonuç Kodu alanları boş!");
        //            }
        //        }
        //        else
        //            throw new Exception("Medulaya mutat dışı araç rapor silme işlemi yapılamadı.Cevap dönmedi!");
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Medulaya mutat dışı araç rapor silme işlemi sırasında hata oluştu! " + e.Message);
        //    }

        //}

        ///*
        // * MEDULA MUTAT DIŞI RAPOR IPTAL DVO HAZIRLANMASI
        // * */
        //public SevkIslemleri.mutatDisiRaporIptalDVO GetMutatDisiRaporIptalDVO()
        //{
        //    SevkIslemleri.mutatDisiRaporIptalDVO mutatDisiRaporIptalDVO = new SevkIslemleri.mutatDisiRaporIptalDVO();
        //    if (this.MedulaMutatDisiAracRaporNo != null && !this.MedulaMutatDisiAracRaporNo.Equals("0"))
        //    {
        //        mutatDisiRaporIptalDVO.raporID = Convert.ToInt32(this.MedulaMutatDisiAracRaporNo);
        //    }
        //    else
        //    {
        //        throw new Exception("Medulaya mutat dışı araç rapor kaydı yapılmamış. Öncelikle kayıt yapmalısınız!");
        //    }

        //    mutatDisiRaporIptalDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

        //    return mutatDisiRaporIptalDVO;
        //}





        public String GetLatestDischargeDate()
        {
            return GetLatestDischargeDate(this);
        }
        public static String GetLatestDischargeDate(InpatientAdmission inpatientAdmission)
        {
            DateTime bufferDate = DateTime.MinValue;

            if (inpatientAdmission.InPatientTreatmentClinicApplications != null)
            {

                foreach (InPatientTreatmentClinicApplication inPtntTrtmntClncApp in inpatientAdmission.InPatientTreatmentClinicApplications)
                {
                    if (inPtntTrtmntClncApp != null && inPtntTrtmntClncApp.ClinicDischargeDate != null && inPtntTrtmntClncApp.ClinicDischargeDate.Value != null)
                    {
                        if (DateTime.Compare(bufferDate, inPtntTrtmntClncApp.ClinicDischargeDate.Value) < 0)
                            bufferDate = inPtntTrtmntClncApp.ClinicDischargeDate.Value;

                    }
                }
            }
            if (bufferDate.Equals(DateTime.MinValue))
                return "";

            return bufferDate.ToString("dd.MM.yyyy");
        }

        /// <summary>
        /// İşleme Bağlı Alt İşlemleri Ve Malzemeleri Ãœcretlendirir
        /// Yatak hizmetinin miktarı AccountOperation dan sonra güncellendiği için Attribute kaldırıldı ve bu metod kullanıldı
        /// </summary>
        //public void AccountingOperation(AccountOperationTimeEnum pPreAccounting)
        //{
        //    foreach (InPatientTreatmentClinicApplication tca in InPatientTreatmentClinicApplications)
        //    {
        //        foreach (SubActionProcedure sp in tca.GetAccountableSubActionProcedures())
        //        {
        //            if (sp.CurrentStateDef.Status != StateStatusEnum.Cancelled)
        //                sp.AccountOperation(pPreAccounting);
        //        }

        //        foreach (SubActionMaterial sm in tca.GetAccountableSubActionMaterials())
        //        {
        //            if (sm.CurrentStateDef.Status != StateStatusEnum.Cancelled)
        //            {
        //                // DrugOrder ve DrugOrderDetail in burada ücretlenmemesi için eklendi
        //                if (!(sm is DrugOrder || sm is DrugOrderDetail))
        //                    sm.AccountOperation(pPreAccounting);
        //            }
        //        }
        //    }
        //}

        public void CancelBedProcedureAccTrxs()
        {
            foreach (BaseBedProcedure bedProcedure in BedProcedures.Where(x => x.CurrentStateDefID != BaseBedProcedure.States.Cancelled))
                bedProcedure.CancelMyAccountTransactions();
        }

        public string FinancialControlToDischarge(bool onlyInformation = false)
        {
            // FinancialControlToDischarge  methodunun çağırıldığı ClientFormPostlara taşındı
            // Yatış gün sayısı ile oluşmuş yatak hizmeti sayısını karşılaştırır, eşit değilse uyarı verir
            //this.ControlBedProcedureCount();
            double chargeTotal = 0;
            double advanceTotal = 0;
            string errorMessage = string.Empty;

            foreach (AccountTransaction accTrx in Episode.GetTransactionsForReceipt())
            {
                if ((accTrx.SubActionProcedure != null || accTrx.SubActionMaterial != null) && accTrx.RemainingPrice > 0)
                {
                    chargeTotal += accTrx.RemainingPrice;
                    AccountTransactions.Add(accTrx);
                }
            }

            foreach (Advance advance in Episode.Advances)
            {
                if (advance.AdvanceDocument.CurrentStateDefID == AdvanceDocument.States.Paid && advance.AdvanceDocument.Used == false && advance.RemainingPrice > 0)
                {
                    advanceTotal += advance.TotalPrice.Value;
                    AdvanceDocuments.Add(advance.AdvanceDocument);
                }
            }

            if (chargeTotal > advanceTotal)
                errorMessage = SystemMessage.GetMessage(1168);
            else if (chargeTotal < advanceTotal)
                errorMessage = SystemMessage.GetMessage(1169);


            if (onlyInformation)
            {
                if (chargeTotal > advanceTotal)
                    TTUtils.InfoMessageService.Instance.ShowMessage(SystemMessage.GetMessage(1168));
                else if (chargeTotal < advanceTotal)
                    TTUtils.InfoMessageService.Instance.ShowMessage(SystemMessage.GetMessage(1169));
            }
            else
            {
                if (chargeTotal > advanceTotal)
                    throw new TTException(SystemMessage.GetMessage(1168));
                else if (chargeTotal < advanceTotal)
                    throw new TTException(SystemMessage.GetMessage(1169));
                else if (chargeTotal > 0 && advanceTotal > 0 && chargeTotal == advanceTotal)
                {
                    // muhasebeye hareket gönderen kısmın başlangıcı
                    /*
                    AccountDocument.ReceiptInfo RI = null;
                    if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
                    {
                        RI = new AccountDocument.ReceiptInfo();

                        RI.ObjectId = this.ObjectID.ToString();
                        RI.receiptDate = ((DateTime)this.ActionDate).Date;
                        RI.Description = "Hasta: " + this.Episode.Patient.ID.ToString() + " " + this.Episode.Patient.FullName.ToString() + " / H.Protokol No: " + this.Episode.HospitalProtocolNo + " / İşlem No: " + this.ID;
                        RI.Type = AccountDocument.ReceiptTypeEnum.HastaYatisFinansalKontrol;
                        RI.CashOfficeName = " ";  // null olunca serialize da hata veriyor, bu yüzden " " gönderiliyor
                        RI.No = " ";              // null olunca serialize da hata veriyor, bu yüzden " " gönderiliyor

                        RI.Lines = new List<AccountDocument.ReceiptLine>();

                        // Paid e alınan accTrx ler için bölüm gelir hesapları çalışmalı
                        double prcTrxTotal = 0;
                        double matTrxTotal = 0;

                        foreach (AccountTransaction accTrx in Episode.GetTransactionsForReceipt())
                        {
                            if (accTrx.PackageDefinition == null)
                            {
                                if (accTrx.SubActionProcedure != null)
                                    prcTrxTotal = prcTrxTotal + ((double)accTrx.Amount * (double)accTrx.UnitPrice);
                                else if (accTrx.SubActionMaterial != null)
                                    matTrxTotal = matTrxTotal + ((double)accTrx.Amount * (double)accTrx.UnitPrice);
                            }
                        }


                        if (matTrxTotal > 0 || prcTrxTotal > 0)
                        {
                            string accountCodeStart = "";
                            string accountCode = "";
                            bool addLine = true;
                            double lineTotal = 0;
                            RevenueSubAccountCodeDefinition revenueCode = null;

                            if (this.Episode.Patient.Foreign == true)
                                accountCodeStart = "601."; // + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + ".";
                            else
                                accountCodeStart = "600."; // + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + ".";

                            if (matTrxTotal > 0)
                            {
                                AccountDocument.ReceiptLine rLine = new AccountDocument.ReceiptLine();
                                rLine.Description = "İlaç ve Tıbbi Sarf Malzemesi Gelirleri";
                                rLine.AccountCode = accountCodeStart + "08";
                                rLine.IsDebt = false;
                                rLine.Price = (double)matTrxTotal;
                                rLine.CurrencyRate = 1;
                                RI.Lines.Add(rLine);
                            }

                            if (prcTrxTotal > 0)
                            {
                                prcTrxTotal = 0;
                                foreach (AccountTransaction accTrx in Episode.GetTransactionsForReceipt())
                                {
                                    if (accTrx.SubActionProcedure != null)
                                    {
                                        if (accTrx.PackageDefinition == null)
                                        {
                                            accountCode = "";
                                            addLine = true;
                                            revenueCode = null;
                                            revenueCode = accTrx.SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode();

                                            if (revenueCode == null)
                                                throw new TTException(SystemMessage.GetMessageV3(127, new string[] { accTrx.SubActionProcedure.ProcedureObject.Code, accTrx.SubActionProcedure.ProcedureObject.Name }));
                                            else
                                            {
                                                if (((double)accTrx.Amount * (double)accTrx.UnitPrice) > 0)
                                                {
                                                    accountCode = accountCodeStart + revenueCode.AccountCode;

                                                    foreach (AccountDocument.ReceiptLine rLine in RI.Lines)
                                                    {
                                                        if (rLine.AccountCode == accountCode)
                                                        {
                                                            rLine.Price = rLine.Price + ((double)accTrx.Amount * (double)accTrx.UnitPrice); // line larda var, fiyata ekle
                                                            addLine = false;
                                                            break;
                                                        }
                                                    }
                                                    if (addLine)  // line larda yok, yeni line ekle
                                                    {
                                                        AccountDocument.ReceiptLine rLine1 = new AccountDocument.ReceiptLine();
                                                        rLine1.Description = revenueCode.Description;
                                                        rLine1.AccountCode = accountCode;
                                                        rLine1.IsDebt = false;
                                                        rLine1.Price = ((double)accTrx.Amount * (double)accTrx.UnitPrice);
                                                        rLine1.CurrencyRate = 1;
                                                        RI.Lines.Add(rLine1);
                                                    }

                                                    prcTrxTotal = prcTrxTotal + ((double)accTrx.Amount * (double)accTrx.UnitPrice);
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                        // fişin toplam tutarı set edilir
                        RI.TotalPrice = (double)prcTrxTotal + (double)matTrxTotal;

                        if (RI.TotalPrice == 0)
                            throw new TTException(SystemMessage.GetMessage(1170));

                        AccountDocument.ReceiptLine rLine2 = new AccountDocument.ReceiptLine();
                        rLine2.Description = "Hasta Tedavi Avans İadesi";
                        rLine2.AccountCode = this.GetAccountCode(AccountEntegrationAccountTypeEnum.AvansHesabi);
                        rLine2.IsDebt = true;
                        rLine2.Price = (double)prcTrxTotal + (double)matTrxTotal;
                        rLine2.CurrencyRate = 1;
                        RI.Lines.Add(rLine2);

                        // muhasebe hareketi kontrol edilir
                        double debtTotal = 0;
                        double creditTotal = 0;
                        int counter = 1;

                        foreach (AccountDocument.ReceiptLine rLine in RI.Lines)
                        {
                            // line lara ObjectId verilir sıradan, primery key i olsun diye.
                            rLine.ObjectId = RI.ObjectId + "-" + counter.ToString();
                            counter++;

                            if (rLine.AccountCode == null)
                                throw new TTException(SystemMessage.GetMessage(1171));
                            else
                            {
                                if (rLine.AccountCode.Trim() == "")
                                    throw new TTException(SystemMessage.GetMessage(1171));
                            }

                            if (rLine.IsDebt == true)
                                debtTotal = debtTotal + (double)Math.Round((rLine.Price * rLine.CurrencyRate), 2);
                            else
                                creditTotal = creditTotal + (double)Math.Round((rLine.Price * rLine.CurrencyRate), 2);
                        }

                        if (Math.Round(debtTotal, 2) != Math.Round(creditTotal, 2))
                            throw new TTException(SystemMessage.GetMessage(1172));
                        else if (Math.Round(RI.TotalPrice, 2) != Math.Round(debtTotal, 2))
                            throw new TTException(SystemMessage.GetMessage(1173));
                        else if (Math.Round(RI.TotalPrice, 2) != Math.Round(creditTotal, 2))
                            throw new TTException(SystemMessage.GetMessage(1173));

                        // muhasebe programına gönderilir
                        IList<AccountDocument.ReceiptInfo> ReceiptList = new List<AccountDocument.ReceiptInfo>();
                        if (RI != null)
                            ReceiptList.Add(RI);

                        if (ReceiptList.Count > 0)
                        {
                            TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "Invoice.Integration", "InvoiceUtils", "CreateReceipt", null, ReceiptList);
                        }
                    } 
                    */
                    // muhasebe kısmının sonu

                    foreach (AccountTransaction accTrx in AccountTransactions)
                    {
                        foreach (AdvanceDocument advanceDoc in AdvanceDocuments)
                        {
                            Advance advance = advanceDoc.EpisodeAccountAction as Advance;
                            Currency advanceRemainingPrice = advance.RemainingPrice;
                            if (advanceRemainingPrice > 0)
                            {
                                Currency accTrxRemainingPrice = accTrx.RemainingPrice;
                                PatientPaymentDetail ppDetail = new PatientPaymentDetail(ObjectContext);
                                if (accTrxRemainingPrice <= advanceRemainingPrice)
                                {
                                    ppDetail.CreatePPDetail(accTrx, advanceDoc, accTrxRemainingPrice, PaymentTypeEnum.Advance);
                                    break;
                                }
                                else
                                    ppDetail.CreatePPDetail(accTrx, advanceDoc, advanceRemainingPrice, PaymentTypeEnum.Advance);
                            }
                        }

                        if (accTrx.RemainingPrice == 0)
                            accTrx.CurrentStateDefID = AccountTransaction.States.Paid;
                    }

                    foreach (AdvanceDocument advanceDoc in AdvanceDocuments)
                        advanceDoc.Used = true;
                }
            }
            return errorMessage;
        }

        /// <summary>
        /// KullaniciDoktor ise islemi Yapan Doktor Olarak Atar
        /// </summary>
        public override void SetProcedureDoctorAsCurrentResource()
        {
            if (CurrentStateDef.Status == StateStatusEnum.Uncompleted)
            {
                if (ProcedureDoctor == null && Common.CurrentResource.TakesPerformanceScore == true)
                {
                    IList userResources = UserResource.GetByUserAndResource(ObjectContext, Common.CurrentResource.ObjectID, FromResource.ObjectID);
                    if (userResources.Count > 0)
                        ProcedureDoctor = Common.CurrentResource;
                }
            }
        }

        //public override void CheckRulesForNewEpisodeAction()
        //{

        //if (this.CurrentStateDefID == InpatientAdmission.States.Request)
        //{
        //    DateTime openingDate = this.Episode.OpeningDate.Value;
        //    DateTime today = Common.RecTime();
        //    System.TimeSpan timeSpan = today.Subtract(openingDate);
        //    int dayDiff = (int)timeSpan.TotalDays;
        //    if (dayDiff > 10)
        //    {
        //        throw new TTUtils.TTException("Epizode açılış tarihinden 10 gün geçmiş vakalara yatış işlemi başlatamazsınız!");
        //    }
        //}


        //// Acil serviste muayeneleri YEŞİL ALAN olarak işaretlenen hastaların kliniklere yatışına Medulada ödeme kapsamında olmadığı için  izin verilmemektedir.
        //if (this.Episode != null)
        //{
        //    foreach (EmergencyIntervention ei in this.Episode.EmergencyInterventions)
        //    {
        //        foreach (InPatientPhysicianApplication ippa in ei.InPatientPhysicianApplications)
        //        {
        //            //if (ippa.IsGreenAreaExamination != null)
        //            {
        //                if (ippa.IsGreenAreaExamination == true)
        //                    throw new Exception("Acil serviste muayeneleri YEŞİL ALAN olan hastaların kliniklere yatışına izin verilmemektedir.");

        //            }
        //        }
        //        foreach (PatientExamination pe in ei.PatientExaminations)
        //        {
        //            if (pe.IsGreenAreaExamination == true)
        //                throw new Exception("Yeşil alan muayenelerinde hasta yatış işlemi başlatılamaz!");

        //        }
        //    }

        //    //Günübirlik Takip üzerinden yatış başlatılamaz


        //    if ( this.SubEpisode.PatientAdmission != null)
        //    {
        //        // Hasta Kabul aynı Gün
        //        if (this.SubEpisode.PatientAdmission.ActionDate != null && Common.RecTime().Date == Convert.ToDateTime(this.SubEpisode.PatientAdmission.ActionDate).Date)
        //        {
        //            // Kabul Sebebi Günübirlik

        //            if (this.SubEpisode.PatientAdmission.AdmissionType != null && this.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Daily) == true)
        //            {
        //                throw new Exception("Hasta Kabul Sebebi 'Günübirlik' olduğundan Yatış başlatılamaz. Kabul Sebebi alanı hasta kabul düzeltmeden 'Normal Muayene' olacak şekilde güncellenerek yatış başlatılabilir.");
        //            }
        //            // Takip Tipi Günübirlik
        //            else if (this.SubEpisode.PatientAdmission.SEP != null && this.SubEpisode.PatientAdmission.SEP.MedulaTakipTipi != null && this.SubEpisode.PatientAdmission.SEP.MedulaTakipTipi.takipTipiKodu != null && this.SubEpisode.PatientAdmission.SEP.MedulaTakipTipi.takipTipiKodu.Equals("T") == true)
        //            {
        //                throw new Exception("Takip Tipi 'Tanı Amaçlı Günübirlik' olduğundan Yatış başlatılamaz. Hasta kabul düzeltme adımından Takip Tipi, 'Normal' olacak şekilde güncellenerek yatış başlatılabilir.");

        //            }
        //        }
        //        //Hasta Kabul Farklı Gün
        //        else
        //        {

        //            // Kabul Sebebi Günübirlik
        //            if (this.SubEpisode.PatientAdmission.AdmissionType != null && this.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Daily) == true)
        //            {
        //                throw new Exception("Hasta Kabul Sebebi 'Günübirlik' olduğundan Yatış başlatılamaz.Kabul Sebebi, 'Normal Muayene' olacak şekilde yeni kabul yapılarak Yatış başlatılabilir.");
        //            }
        //            // Takip Tipi Günübirlik
        //            else if (this.SubEpisode.PatientAdmission.SEP != null && this.SubEpisode.PatientAdmission.SEP.MedulaTakipTipi != null && this.SubEpisode.PatientAdmission.SEP.MedulaTakipTipi.takipTipiKodu != null && this.SubEpisode.PatientAdmission.SEP.MedulaTakipTipi.takipTipiKodu.Equals("T") == true)
        //            {
        //                throw new Exception("Takip Tipi 'Tanı Amaçlı Günübirlik' olduğundan Yatış başlatılamaz.Takip Tipi, 'Normal' olacak şekilde yeni kabul yapılarak Yatış başlatılabilir.");
        //            }


        //        }

        //        // Kabul Sebebi Sağlık Kurulu Muayenesi
        //        if (this.SubEpisode.PatientAdmission.AdmissionType != null && this.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.HealthCommitteeExamination) == true)
        //        {
        //            throw new Exception("Hasta Kabul Sebebi 'Sağlık Kurulu Muayenesi' olan kabullerde Hasta Yatış işlemi başlatılamaz. Yatış işlemi için 'Normal Muayene' kaydı açınız.");
        //        }
        //    }
        //}

        //}


        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InpatientAdmission).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;


            if (fromState == InpatientAdmission.States.Request && toState == InpatientAdmission.States.ClinicProcedure)
                PreTransition_Request2ClinicProcedure();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InpatientAdmission).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;


            if (fromState == InpatientAdmission.States.Request && toState == InpatientAdmission.States.ClinicProcedure)
                PostTransition_Request2ClinicProcedure();
            else if (fromState == InpatientAdmission.States.Request && toState == InpatientAdmission.States.Cancelled)
                PostTransition_Request2Cancelled();
            else if (fromState == InpatientAdmission.States.ClinicProcedure && toState == InpatientAdmission.States.Discharged)
                PostTransition_ClinicProcedure2Discharged();
            else if (fromState == InpatientAdmission.States.ClinicProcedure && toState == InpatientAdmission.States.Cancelled)
                PostTransition_ClinicProcedure2Cancelled();


        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InpatientAdmission).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            CheckUndo();
            if (fromState == InpatientAdmission.States.ClinicProcedure && toState == InpatientAdmission.States.Cancelled)
                UndoTransition_ClinicProcedure2Cancelled(transDef);
            else if (fromState == InpatientAdmission.States.Request && toState == InpatientAdmission.States.ClinicProcedure)
                UndoTransition_Request2ClinicProcedure(transDef);
            else if (fromState == InpatientAdmission.States.Request && toState == InpatientAdmission.States.Cancelled)
                UndoTransition_Request2Cancelled(transDef);
            else if (fromState == InpatientAdmission.States.ClinicProcedure && toState == InpatientAdmission.States.Discharged)
                UndoTransition_ClinicProcedure2Discharged(transDef);
        }

    }
}