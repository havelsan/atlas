
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

    public class PatientEpisodePaymentDetail
    {
        public Currency ServiceTotal { get; set; }
        public Currency ReceiptTotal { get; set; }
        public Currency AdvanceBackTotal { get; set; }
        public Currency ReceiptBackTotal { get; set; }
        public Currency? AdvanceTotal { get; set; }
        public Currency RemainingDebt { get; set; }
        public Currency BondTotal { get; set; }
        public Currency RemainingBondTotal { get; set; }
    }

    public class CharacteristicModel
    {
        public string Weight { get; set; }
        public string Height { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? PregnancyDate { get; set; }
        public string Gender { get; set; }
        public bool? SmokingHabit { get; set; }
        public bool? DrugHabit { get; set; }
        public bool? IsPregnant { get; set; }
    }
    /// <summary>
    /// Hastanın bir gelişine ait işlemlerin tutulduğu Vaka
    /// </summary>
    public partial class Episode : TTObject, ISUTEpisode, IOldActions
    {
        public partial class OLAP_GetInpatientDate_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetEpisodeInformation_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetEpisodeDiagnosis_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetLastDiagnosis_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetDailyInPatient_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetEmergencyAdmission_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetEpisodeResourceByStatus_Class : TTReportNqlObject
        {
        }

        public partial class GetDischargedPatientCount_Class : TTReportNqlObject
        {
        }

        public partial class GetInpatientAdmissionCount_Class : TTReportNqlObject
        {
        }

        public partial class GetByPatientAndDayLimitNQL_Class : TTReportNqlObject
        {
        }

        public partial class GeyByDateAndDepartment_Class : TTReportNqlObject
        {
        }

        public partial class GetNotDiagnosisExistsByDateInterval_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledEmergencyAdmission_Class : TTReportNqlObject
        {
        }

        public partial class GetEpisodeInformation_RQ_Class : TTReportNqlObject
        {
        }

        public partial class GetEpisodesToSendEHRs_Class : TTReportNqlObject
        {
        }

        public partial class GetDiagnosisByPatientExamination_Class : TTReportNqlObject
        {
        }

        public partial class GetVeteransOfEpisodesByDate_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientNotHaveMedulaProvisionByInvoiceState_Class : TTReportNqlObject
        {
        }

        public CharacteristicModel GetPatientCharacteristics()
        {
            CharacteristicModel returnModel = new CharacteristicModel();
            if (Patient.BirthDate != null)
            {
                returnModel.BirthDate = Patient.BirthDate.Value;
            }

            returnModel.DrugHabit = null;
            if (Patient.MedicalInformation != null)
            {
                if (Patient.MedicalInformation.MedicalInfoHabits != null)
                {
                    if (Patient.MedicalInformation.MedicalInfoHabits.Cigarette != null)
                    {
                        returnModel.SmokingHabit = (bool)Patient.MedicalInformation.MedicalInfoHabits.Cigarette;
                    }
                    else
                    {
                        returnModel.SmokingHabit = null;
                    }
                }
            }
            returnModel.Weight = Patient.Weight != null ? Patient.Weight.ToString() : null;
            returnModel.Height = Patient.Heigth != null ? Patient.Heigth.ToString() : null;
            if (Patient.MedicalInformation != null)
            {
                if (Patient.MedicalInformation.Pregnancy != null)
                {
                    returnModel.IsPregnant = (bool)Patient.MedicalInformation.Pregnancy;
                }
                else
                {
                    returnModel.IsPregnant = null;
                }
            }
            returnModel.PregnancyDate = null;
            returnModel.Gender = Patient.Sex.ADI == "ERKEK" ? "male" : "female";
            return returnModel;
        }


        /// <summary>
        /// Vakada Hastanın Kabul edildiği Birimleri Döndürür
        /// </summary>
        public string AdmissionSpecOrRes
        {
            get
            {
                try
                {
                    #region AdmissionSpecOrRes_GetScript                    
                    string admissionSpecOrRes = "";

                    if (MainSpeciality != null)
                        admissionSpecOrRes += MainSpeciality.Name;
                    else if (AdmissionResource != null)
                        admissionSpecOrRes += AdmissionResource;
                    return admissionSpecOrRes;
                    #endregion AdmissionSpecOrRes_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "AdmissionSpecOrRes") + " : " + ex.Message, ex);
                }
            }
        }


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "PATIENTSTATUS":
                    {
                        PatientStatusEnum? value = (PatientStatusEnum?)(int?)newValue;
                        #region PATIENTSTATUS_SetScript
                        if (value.HasValue == true)
                        {
                            if (value == PatientStatusEnum.Inpatient)
                                Patient.InpatientEpisode = this;
                            else if (value == PatientStatusEnum.Discharge)
                                Patient.InpatientEpisode = null;

                            //if (this.PatientStatus == PatientStatusEnum.Inpatient && value == PatientStatusEnum.Outpatient)
                            // InfoBox.Alert("Yatan hasta, ayaktan hastaya çevirilecektir");
                        }
                        #endregion PATIENTSTATUS_SetScript
                    }
                    break;
                case "MAINDIAGNOSE":
                    {
                        DiagnosisGrid value = (DiagnosisGrid)newValue;
                        #region MAINDIAGNOSE_SetParentScript
                        // ana tanı her zaman tek olur o yüzden daha önecki ana tanının IsMainDiagnose özelliği kaldırılıyor
                        if (value != null && MainDiagnose != null)
                            MainDiagnose.IsMainDiagnose = false;
                        #endregion MAINDIAGNOSE_SetParentScript
                    }
                    break;

            }
        }

        public bool PatientHasDebt()
        {
            PatientEpisodePaymentDetail ppd = CalculatePatientDebt(this, null, null);
            if (ppd.RemainingDebt > 0)
                return true;

            return false;
        }

        public static PatientEpisodePaymentDetail CalculatePatientDebt(Episode episode, object serviceTotal, object advanceTotal)
        {
            PatientEpisodePaymentDetail pepd = new PatientEpisodePaymentDetail();

            if (advanceTotal != null)
                pepd.AdvanceTotal = Convert.ToDouble(advanceTotal);
            else
                pepd.AdvanceTotal = 0;

            var episodeActionList = episode.ObjectContext.QueryObjects<EpisodeAction>("EPISODE = '" + episode.ObjectID + "' AND OBJECTDEFNAME IN ('RECEIPT','ADVANCE','ADVANCEBACK','RECEIPTBACK','BOND')").ToList();
            foreach (EpisodeAction episodeAction in episodeActionList)
            {
                Receipt receiptAct = episodeAction as Receipt;
                if (receiptAct != null)
                {
                    if (receiptAct.CurrentStateDefID == Receipt.States.Paid)
                        pepd.ReceiptTotal += receiptAct.TotalPayment.Value;
                }

                AdvanceBack advBackAct = episodeAction as AdvanceBack;
                if (advBackAct != null)
                {
                    if (advBackAct.CurrentStateDefID == AdvanceBack.States.Paid)
                        pepd.AdvanceBackTotal += advBackAct.AdvanceBackDocument.TotalPrice.Value;
                }

                ReceiptBack ReceiptBackAct = episodeAction as ReceiptBack;
                if (ReceiptBackAct != null)
                {
                    if (ReceiptBackAct.CurrentStateDefID == ReceiptBack.States.ReturnBack)
                        pepd.ReceiptBackTotal += ReceiptBackAct.ReceiptBackDocument.TotalPrice.Value;
                }

                Bond bondAct = episodeAction as Bond;
                if (bondAct != null)
                {
                    if (bondAct.CurrentStateDefID != Bond.States.Cancelled)
                    {
                        if (bondAct.CurrentStateDefID == Bond.States.Restructured)
                            pepd.BondTotal += bondAct.BondDetails.Where(x => x.CurrentStateDefID == BondDetail.States.Paid).Sum(x => (decimal)x.Price);
                        else
                        {
                            pepd.BondTotal += bondAct.TotalPrice.Value;
                            pepd.RemainingBondTotal += bondAct.BondDetails.Where(x => x.CurrentStateDefID == BondDetail.States.New).Sum(x => (decimal)x.Price);
                        }
                    }
                }

                if (advanceTotal == null)
                {
                    Advance advanceAct = episodeAction as Advance;
                    if (advanceAct != null)
                    {

                        //advanceTotal = 0;
                        //foreach (EpisodeAction episodeAction in episode.EpisodeActions.OfType<Advance>())
                        //{
                        //if (advanceAct != null)
                        //{
                        if (advanceAct.CurrentStateDefID == Advance.States.Paid)
                            pepd.AdvanceTotal = CurrencyType.ConvertFrom(pepd.AdvanceTotal) + advanceAct.AdvanceDocument.TotalPrice.Value;
                        //}
                        //}
                        //pepd.AdvanceTotal = Convert.ToDouble(advanceTotal);
                    }
                }
            }

            //if (advanceTotal == null)
            //{
            //    advanceTotal = 0;
            //    foreach (EpisodeAction episodeAction in episode.EpisodeActions.OfType<Advance>())
            //    {
            //        Advance advanceAct = episodeAction as Advance;
            //        //if (advanceAct != null)
            //        //{
            //        if (advanceAct.AdvanceDocument.CurrentStateDefID == AdvanceDocument.States.Paid)
            //            advanceTotal = CurrencyType.ConvertFrom(advanceTotal) + advanceAct.AdvanceDocument.TotalPrice.Value;
            //        //}
            //    }
            //    pepd.AdvanceTotal = Convert.ToDouble(advanceTotal);
            //}
            //else
            //    pepd.AdvanceTotal = Convert.ToDouble(advanceTotal);

            if (serviceTotal == null)
            {
                serviceTotal = 0;
                List<InvoiceBlockingDefinition> blockingStateDefList = new List<InvoiceBlockingDefinition>();
                List<Guid> blockingSateDefObjectIDList = new List<Guid>();
                bool cashOfficeBlockingActive = SystemParameter.GetParameterValue("CASHOFFICEBLOCKINGACTIVE", "FALSE") == "TRUE" ? true : false;

                //List<AccountTransaction> transactionsList = AccountTransaction.GetIncludedTrxsExceptCancelledByEpisode(episode.ObjectContext, episode.Patient.MyAPR().ObjectID, episode.ObjectID).ToList();

                if (cashOfficeBlockingActive)
                {
                    if (blockingSateDefObjectIDList.Count == 0)
                    {
                        blockingStateDefList = episode.ObjectContext.QueryObjects<InvoiceBlockingDefinition>("ISACTIVE = 1 AND CASHOFFICEBLOCK = 1").ToList();
                        blockingSateDefObjectIDList.AddRange(blockingStateDefList.Select(x => x.StateDefId.Value));
                    }
                }
                else
                {
                    if (blockingSateDefObjectIDList.Count == 0)
                        blockingSateDefObjectIDList.Add(Guid.Empty);
                }

                // Vezne engeli olan state tanımları listeye alınır 
                //if (transactionsList.Any(x => x.InvoiceInclusion == true && x.CurrentStateDefID == AccountTransaction.States.New && x.SubActionProcedure != null))
                //    blockingStateDefList = episode.ObjectContext.QueryObjects<InvoiceBlockingDefinition>("ISACTIVE = 1 AND CASHOFFICEBLOCK = 1").ToList();

                var newTrxsServiceTotal = AccountTransaction.GetIncludedTrxsTotalPriceByEpisode(episode.Patient.MyAPR().ObjectID, episode.ObjectID, blockingSateDefObjectIDList).ToList();

                if (newTrxsServiceTotal.Count > 0)
                    serviceTotal = CurrencyType.ConvertFrom(serviceTotal) + CurrencyType.ConvertFrom(newTrxsServiceTotal.Sum(x => Convert.ToDouble(x.Price)));

                //foreach (AccountTransaction accTrx in transactionsList)
                //{
                //    if (accTrx.CurrentStateDefID == AccountTransaction.States.New) // Yeni durumundaki hizmet/malzemeler için
                //    {
                //        if (accTrx.SubActionProcedure != null) // Hizmetler için Vezne Engeli kontrol edilir
                //        {
                //            if (accTrx.SubActionProcedure.IsCashOfficeBlock(blockingStateDefList, cashOfficeBlockingActive) == false)
                //                serviceTotal = CurrencyType.ConvertFrom(serviceTotal) + CurrencyType.ConvertFrom(accTrx.UnitPrice * accTrx.Amount);
                //        }
                //        else if (accTrx.SubActionMaterial != null)
                //            serviceTotal = CurrencyType.ConvertFrom(serviceTotal) + CurrencyType.ConvertFrom(accTrx.UnitPrice * accTrx.Amount);
                //    }
                //    else // Makbuzu kesilmiş hizmetler için
                //        serviceTotal = CurrencyType.ConvertFrom(serviceTotal) + CurrencyType.ConvertFrom(accTrx.UnitPrice * accTrx.Amount);
                //}
                pepd.ServiceTotal = Convert.ToDouble(serviceTotal);
            }
            else
                pepd.ServiceTotal = CurrencyType.ConvertFrom(serviceTotal).Value;

            pepd.RemainingDebt = Math.Round((decimal)(pepd.AdvanceBackTotal + pepd.ReceiptBackTotal + pepd.ServiceTotal) - (decimal)(pepd.AdvanceTotal + pepd.ReceiptTotal + pepd.BondTotal), 2);
            return pepd;
        }
        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();

            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert



            base.PostInsert();
            // Sevk ile başlatılmış bir Episode ise..
            //RunReturnToDispatchToOtherHospital(); // XXXXXXler arası sevk işlemi kendi return mesajını kendi gönderecek şekilde ayarlandığı için kaldırıldı.

            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();

            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate





            base.PostUpdate();
            if (Patient.UniqueRefNo != null)
            {
                foreach (DiagnosisGrid diagnosis in Diagnosis)
                {
                    if (diagnosis.Diagnose != null)
                    {
                        if (diagnosis.Diagnose.DeclerationMust == true && ObjectID != null)
                        {
                            string ipAddr = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112IP", null);
                            TTUtils.TTWebServiceUri uri = new TTUtils.TTWebServiceUri(ipAddr);
                            string userName112 = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME", null);
                            string password112 = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD", null);
                            string ICD10Kodu = diagnosis.Diagnose.Code;
                            if (!string.IsNullOrEmpty(userName112) && !string.IsNullOrEmpty(password112))
                            {
                                Acil112Servis.HastaBilgileri hastaBilgileri = new Acil112Servis.HastaBilgileri();
                                hastaBilgileri.AdiSoyadi = Patient.FullName;
                                if (Patient.Sex.ADI == "KADIN")
                                {
                                    hastaBilgileri.Cinsiyet = "K";
                                }
                                else
                                {
                                    hastaBilgileri.Cinsiyet = "E";
                                }
                                hastaBilgileri.HastaGirisZamani = Convert.ToDateTime(OpeningDate).ToString("yyyy-MM-dd HH:mm:ss");
                                //hastaBilgileri.Il = this.Patient.HomeCity.Name;
                                //hastaBilgileri.Ilce = this.Patient.HomeTown.Name;
                                hastaBilgileri.TCKimlikNo = Patient.UniqueRefNo.ToString();// !=null ? this.Patient.UniqueRefNo.ToString() :this.Patient.ForeignUniqueRefNo.ToString();// diagnoseAndPatientByEpisode.Tcno.ToString();
                                hastaBilgileri.Yas = Convert.ToInt32(Patient.Age);

                                if (PatientStatus == PatientStatusEnum.Inpatient)
                                {
                                    hastaBilgileri.YatarakTedavi = true;
                                }
                                else
                                    hastaBilgileri.YatarakTedavi = false;


                                //  TTObjectClasses.HastaKabulIslemleri.provizyonGirisDVO provizyonGirisDVO = null;
                                TTObjectClasses.XXXXXX112Services.EUYSTaniGonderParam inputParam = new TTObjectClasses.XXXXXX112Services.EUYSTaniGonderParam();
                                TTObjectClasses.Acil112Servis.WebMethods.EUYSTaniGonderASync(Sites.SiteLocalHost, inputParam, uri, userName112, password112, hastaBilgileri, ICD10Kodu);
                            }
                        }
                    }
                }
            }


            #endregion PostUpdate
        }

        protected void PostTransition_Open2Closed()
        {
            // From State : Open   To State : Closed
            #region PostTransition_Open2Closed

            //this.SendEhrEpisodeToMerkezSagKom();
            #endregion PostTransition_Open2Closed
        }

        protected void PostTransition_Open2ClosedToNew()
        {
            // From State : Open   To State : ClosedToNew
            #region PostTransition_Open2ClosedToNew
            //this.SendEhrEpisodeToMerkezSagKom();
            #endregion PostTransition_Open2ClosedToNew
        }

        protected void PostTransition_ClosedToNew2Closed()
        {
            // From State : ClosedToNew   To State : Closed
            #region PostTransition_ClosedToNew2Closed
            //this.SendEhrEpisodeToMerkezSagKom();
            #endregion PostTransition_ClosedToNew2Closed
        }

        #region Methods
        // Diş PreDiagnosislerini de alır
        private List<DiagnosisGrid> _AllPreDiagnosis = null;
        public List<DiagnosisGrid> AllPreDiagnosis
        {
            get
            {
                _AllPreDiagnosis = new List<DiagnosisGrid>();
                foreach (DiagnosisGrid dg in Diagnosis)
                {
                    if (dg.DiagnosisType == DiagnosisTypeEnum.Primer)
                        _AllPreDiagnosis.Add(dg);
                }
                return _AllPreDiagnosis;
            }
        }

        // Diş SecDiagnosislerini de alır
        private List<DiagnosisGrid> _AllSecDiagnosis = null;
        public List<DiagnosisGrid> AllSecDiagnosis
        {
            get
            {
                _AllSecDiagnosis = new List<DiagnosisGrid>();
                foreach (DiagnosisGrid dg in Diagnosis)
                {
                    if (dg.DiagnosisType == DiagnosisTypeEnum.Seconder)
                        _AllSecDiagnosis.Add(dg);
                }
                return _AllSecDiagnosis;
            }
        }


        protected System.Collections.Generic.IList<DiagnosisGrid> _PreDiagnosis = null;
        public System.Collections.Generic.IList<DiagnosisGrid> PreDiagnosis
        {
            get
            {
                if (_PreDiagnosis == null)
                    _PreDiagnosis = Diagnosis.Where(r => r.DiagnosisType.Value == DiagnosisTypeEnum.Primer).ToList();
                return _PreDiagnosis;
            }
        }
        protected System.Collections.Generic.IList<DiagnosisGrid> _SecDiagnosis = null;
        public System.Collections.Generic.IList<DiagnosisGrid> SecDiagnosis
        {
            get
            {
                if (_SecDiagnosis == null)
                    _SecDiagnosis = Diagnosis.Where(r => r.DiagnosisType.Value == DiagnosisTypeEnum.Seconder).ToList();
                return _SecDiagnosis;
            }
        }

        public List<AccountTransaction> GetTransactionsForReceipt()
        {
            bool cashOfficeBlockingActive = SystemParameter.GetParameterValue("CASHOFFICEBLOCKINGACTIVE", "FALSE") == "TRUE" ? true : false;
            List<InvoiceBlockingDefinition> blockingStateDefList = ObjectContext.QueryObjects<InvoiceBlockingDefinition>("ISACTIVE = 1 AND CASHOFFICEBLOCK = 1").ToList();

            List<AccountTransaction> trxList = AccountTransaction.GetTransactionsForReceiptByEpisode(ObjectContext, AccountTransaction.States.New, ObjectID, Patient.MyAPR().ObjectID).ToList<AccountTransaction>();
            List<AccountTransaction> returnTrxList = new List<AccountTransaction>();

            foreach (AccountTransaction accTrx in trxList)
            {   // Malzemeler direkt eklenir, Hizmetler için Vezne Engeli kontrol edilir
                if (accTrx.SubActionMaterial != null || (accTrx.SubActionProcedure != null && accTrx.SubActionProcedure.IsCashOfficeBlock(blockingStateDefList, cashOfficeBlockingActive) == false))
                    returnTrxList.Add(accTrx);
            }

            return returnTrxList;
        }

        public List<AccountTransaction.GetTransactionsForReceiptByEpisodeRprtQuery_Class> GetTransactionsForReceiptV2()
        {
            bool cashOfficeBlockingActive = SystemParameter.GetParameterValue("CASHOFFICEBLOCKINGACTIVE", "FALSE") == "TRUE" ? true : false;
            List<InvoiceBlockingDefinition> blockingStateDefList = ObjectContext.QueryObjects<InvoiceBlockingDefinition>("ISACTIVE = 1 AND CASHOFFICEBLOCK = 1").ToList();
            List<Guid> blockingSateDefObjectIDList = new List<Guid>();

            if (cashOfficeBlockingActive)
            {
                if (blockingSateDefObjectIDList.Count == 0)
                    blockingSateDefObjectIDList.AddRange(blockingStateDefList.Select(x => x.StateDefId.Value));
            }
            else
            {
                if (blockingSateDefObjectIDList.Count == 0)
                    blockingSateDefObjectIDList.Add(Guid.Empty);
            }

            List<AccountTransaction.GetTransactionsForReceiptByEpisodeRprtQuery_Class> trxList = AccountTransaction.GetTransactionsForReceiptByEpisodeRprtQuery(Patient.MyAPR().ObjectID, blockingStateDefList.Select(x => x.StateDefId.Value).ToList(), AccountTransaction.States.New, ObjectID).ToList();

            return trxList;
        }


        public static IList GetTransactionsForReceipt(Episode episode)
        {
            IList trxList = null;

            if (episode != null)
                trxList = episode.GetTransactionsForReceipt();

            return trxList;
        }

        /// <summary>
        /// Episode' un State' ini Closed yapar.
        /// </summary>
        public void CloseEpisode()
        {
            //UsedBy kaldırılacak
            //Allocationlar kaldırılacak
            ClosingDate = Common.RecTime().Date;
            CurrentStateDefID = Episode.States.Closed;
            foreach (PatientAuthorizedResource patientAuthResource in PatientAuthorizedResources)
            {
                patientAuthResource.Patient = null;
            }
        }

        /// <summary>
        /// Episode' un State' ini ClosedToNew yapar.
        /// </summary>
        public void CloseEpisodeToNew()
        {
            ClosingDate = Common.RecTime().Date;
            CurrentStateDefID = Episode.States.ClosedToNew;
            foreach (PatientAuthorizedResource patientAuthResource in PatientAuthorizedResources)
            {
                patientAuthResource.Patient = null;
            }
        }

        /// <summary>
        /// Episode' un State' ini Openyapar.
        /// </summary>
        ///
        public void OpenEpisode()
        {
            ClosingDate = null;
            CurrentStateDefID = Episode.States.Open;
            foreach (PatientAuthorizedResource patientAuthResource in PatientAuthorizedResources)
            {
                patientAuthResource.Patient = Patient;
            }
        }

        /// <summary>
        /// Episode un stateini Kapalı veya Açıkdevam ise Açık yapar.
        /// </summary>
        public void UndoCloseEpisode()
        {
            if (CurrentStateDefID == Episode.States.Closed || CurrentStateDefID == Episode.States.ClosedToNew)
                OpenEpisode();
        }

        /// <summary>
        /// forOnlyNewAction parametresi true ise Episode' un currentStateDefID' si sadece Open olduğunda true döndürür. ForOnlyNewAction false ise closeToNew ve Open olduğunda True döndürür.
        /// </summary>
        /// <param name="ForOnlyNewAction"></param>
        /// <returns></returns>
        public bool IsOpen(bool forOnlyNewAction)
        {
            if (forOnlyNewAction == true)
            {
                if (CurrentStateDefID == Episode.States.Open)
                    return true;
                return false;
            }
            else
            {
                if (CurrentStateDefID != Episode.States.Closed)
                    return true;
                return false;
            }
        }
        /// <summary>
        /// Vakaya açılmış tahsis varmı gösterir.
        /// </summary>
        /// <param name="resSection"></param>
        /// <returns></returns>
        public bool HasAllocation(ResSection resSection)
        {
            foreach (ResourceSpecialityGrid rSpeciality in resSection.ResourceSpecialities)
            {
                if (Allocation.GetByStateEpisodeAndSpeciality(ObjectContext, Convert.ToString(Allocation.States.Allocated), ObjectID.ToString(), rSpeciality.Speciality.ObjectID.ToString()).Count > 0)
                {
                    return true;
                }
            }
            return false;
        }




        //Sınıf - rütbe bilgisini getirir. raporlarda kullanılmak üzere yazılmıştır.
        private string classRankInfoForReport = "";
        public string ClassRankInfoForReport
        {
            get
            {
                //                PatientAdmission patientAdmission = this.PatientAdmission;
                //                string patientGroup = ((TTDataDictionary.ITTEnumValueDef)TTObjectDefManager.Instance.DataTypes["PatientGroupEnum"].EnumValueDefs[patientAdmission.PatientGroup.Value.ToString()]).DisplayText;
                //                switch (patientAdmission.PatientGroup.Value)
                //                {
                //                        //"Kurmay Subay" yok.
                //                    case PatientGroupEnum.Officer: //Subay
                //                    case PatientGroupEnum.NoncommissionedOfficer://Astsubay
                //                    case PatientGroupEnum.PrivateNonCom://Er/Erbaş
                //                    case PatientGroupEnum.ExpertNonCom://Uzman Erbaş
                //                    case PatientGroupEnum.ExpertGendarme: //Uzman Jandarma
                //                    case PatientGroupEnum.RetiredOfficer://Emekli Subay
                //                    case PatientGroupEnum.RetiredNoncommissionedOfficer://Emekli Astsubay
                //                    case PatientGroupEnum.RetiredExpertNonCom://Emekli Uzman Erbaş
                //                    case PatientGroupEnum.RetiredExpertGendarme: //Emekli Uzman Jandarma
                //                    case PatientGroupEnum.RetiredGeneral: //Emekli General
                //                        //classRankInfoForReport = this.MyMilitaryClass().Name + " " + this.MyRank().Name;
                //                        classRankInfoForReport = (this.MilitaryClass == null ? (this.Patient.MilitaryClass == null ? "" : this.Patient.MilitaryClass.Name) : this.MilitaryClass.Name);
                //                        classRankInfoForReport += " " + (this.Rank == null ? (this.Patient.Rank == null ? "" : this.Patient.Rank.Name) : this.Rank.Name);
                //                        break;
                //                    case PatientGroupEnum.MilitaryCivilOfficial: //XXXXXX Sivil Memur
                //                    case PatientGroupEnum.ExpertNonComCandidate: //Uzman Erbaş Adayı
                //                    case PatientGroupEnum.ConsignmentPrivate: //Sevk Eri
                //                    case PatientGroupEnum.MilitaryCivilOfficialCandidate: //XXXXXX Sivil Memur Adayı
                //                    case PatientGroupEnum.MilitaryWorker: //XXXXXX İşçi
                //                    case PatientGroupEnum.MilitaryWorkerCandidate: //XXXXXX İşçi Adayı
                //                        //classRankInfoForReport = this.MyMilitaryClass().Name + " " + patientAdmission.PatientGroup.Value;
                //                        classRankInfoForReport = (this.MilitaryClass == null ? (this.Patient.MilitaryClass == null ? "" : this.Patient.MilitaryClass.Name) : this.MilitaryClass.Name) + " " + patientGroup;
                //                        break;
                //                        //"XXXXXX Hemşire", "XXXXXX Hemşire Emeklisi" hasta grupları yok.
                //                    case PatientGroupEnum.RetiredMilitaryCivilOfficial: //XXXXXX Sivil Memur Emeklisi
                //                    case PatientGroupEnum.ConsignmentReserveOfficerCandidate: //Sevke Tabi Yedek Subay Adayı
                //                    case PatientGroupEnum.CadetCandidate: //XXXXXX Öğrenci Adayı
                //                    case PatientGroupEnum.RollCallPrivate: //Yoklama Eri
                //                        //case PatientGroupEnum.MilitaryNurseCandidate: //XXXXXX Hemşire Adayı
                //                        classRankInfoForReport = patientGroup;
                //                        break;
                //                    case PatientGroupEnum.OfficerFamily: //Subay Ailesi
                //                    case PatientGroupEnum.NoncommissionedOfficerFamily: //Astsubay Ailesi
                //                    case PatientGroupEnum.ExpertNonComFamily: //Uzman Erbaş Ailesi
                //                    case PatientGroupEnum.ExpertGendarmeFamily: //Uzman Jandarma Ailesi
                //                    case PatientGroupEnum.GeneralAdmiralFamily: //Genaral/Amiral Ailesi
                //                        //classRankInfoForReport = patientAdmission.PatientGroup.Value + " " + this.MyMilitaryClass().Name + " ";
                //                        //classRankInfoForReport += this.MyRank().Name + " " + this.HeadOfFamilyName + " " + this.Relationship.Relationship;
                //                        classRankInfoForReport = patientGroup + " ";
                //                        classRankInfoForReport += (this.MilitaryClass == null ? (this.Patient.MilitaryClass == null ? "" : this.Patient.MilitaryClass.Name) : this.MilitaryClass.Name) + " ";
                //                        classRankInfoForReport += (this.Rank == null ? (this.Patient.Rank == null ? "" : this.Patient.Rank.Name) : this.Rank.Name) + " ";
                //                        classRankInfoForReport += this.HeadOfFamilyName + " " ;
                //                        classRankInfoForReport += (this.Relationship == null ? "": this.Relationship.Relationship);
                //                        break;
                //                    case PatientGroupEnum.Cadet: //XXXXXX Öğrenci
                //                        //classRankInfoForReport = this.MyMilitaryClass().Name + " " + this.MyRank().Name + " " + patientAdmission.PatientGroup.Value;
                //                        classRankInfoForReport = (this.MilitaryClass == null ? (this.Patient.MilitaryClass == null ? "" : this.Patient.MilitaryClass.Name) : this.MilitaryClass.Name);
                //                        classRankInfoForReport += " " + (this.Rank == null ? (this.Patient.Rank == null ? "" : this.Patient.Rank.Name) : this.Rank.Name);
                //                        classRankInfoForReport += " " + patientGroup;
                //                        break;
                //                        //"XXXXXX Hemşire Emeklisi Ailesi", "XXXXXX Hemşire Ailesi" yok.
                //                    case PatientGroupEnum.RetiredOfficerFamily: //Emekli Subay Ailesi
                //                    case PatientGroupEnum.RetiredNoncommissionedOfficerFamily: //Emekli Astsubay Ailesi
                //                    case PatientGroupEnum.RetiredExpertNonComFamily: //Emekli Uzman Erbaş Ailesi
                //                    case PatientGroupEnum.RetiredMilitaryCivilOfficialFamily: //Emekli XXXXXX Sivil Memur Ailesi
                //                    case PatientGroupEnum.MilitaryCivilOfficialFamily: //XXXXXX Sivil Memur Ailesi
                //                    case PatientGroupEnum.CivilianConsignment: //Sivil Sevkli
                //                    case PatientGroupEnum.PaidCivilian: //Sivil Ücretli
                //                    case PatientGroupEnum.PatientWithGreenCard: //Yeşil Kartlı Hasta
                //                    case PatientGroupEnum.RetiredCivilian: //Sivil Emekli
                //                    case PatientGroupEnum.UnpaidCivilian: //Sivil Ücretsiz
                //                    case PatientGroupEnum.RetiredExpertGendarmeFamily: //Emekli Uzman Jandarma Ailesi
                //                    case PatientGroupEnum.MartyrFamily: // Şehit Ailesi
                //                    case PatientGroupEnum.RetiredGeneralFamily: //Emekli General Ailesi
                //                        classRankInfoForReport = patientGroup + " " + this.HeadOfFamilyName;
                //                        if (Relationship != null)
                //                            classRankInfoForReport += " " + this.Relationship.Relationship;
                //                        break;
                //                    case PatientGroupEnum.GeneralAdmiral: //General/Amiral
                //                        //classRankInfoForReport = this.MyRank().Name;
                //                        classRankInfoForReport = (this.Rank == null ? (this.Patient.Rank == null ? "" : this.Patient.Rank.Name) : this.Rank.Name);
                //                        break;
                //                    case PatientGroupEnum.Emergency: //Acil Hasta
                //                        classRankInfoForReport = " ";
                //                        break;
                //                        //Terhisli Uzman Erbaş ,Terhisli Uzman Erbaş Ailesi,Terhisli Erbaş,Terhisli Er ,Terhisli Yedek Subay
                //                        //Tutuklu,Geçici Köy Korucusu,Sivil Ücretsiz,Misafir XXXXXX Öğrenci,Misafir Subay,Misafir Subay Ailesi
                //                    default:
                //                        //classRankInfoForReport = this.MyMilitaryClass().Name + " " + this.MyRank().Name + " " + patientAdmission.PatientGroup.Value;
                //                        classRankInfoForReport = (this.MilitaryClass == null ? (this.Patient.MilitaryClass == null ? "" : this.Patient.MilitaryClass.Name) : this.MilitaryClass.Name);
                //                        classRankInfoForReport += " " + (this.Rank == null ? (this.Patient.Rank == null ? "" : this.Patient.Rank.Name) : this.Rank.Name);
                //                        classRankInfoForReport += " " + patientGroup;
                //                        break;
                //                }
                return classRankInfoForReport;
            }
        }

        public bool Paid()
        {
            if (ObjectContext.QueryObjects<PatientOldDebt>("OLDUNIQUEREFNO = '" + Patient.UniqueRefNo + "' AND (ISREMOVED = 0 OR ISREMOVED IS NULL)").Count(x => x.OldDebtReceiptDocument == null) > 0)
                return false;

            foreach (EpisodeAction ea in EpisodeActions)
            {
                if (ea.IsCancelled == false && ea.Paid() == false)
                    return false;
            }
            return true;
        }

        protected override void OnConstruct()
        {
            base.OnConstruct();

        }



        //Karantina işlemleri için
        public struct GivenOrTakenValuableMaterialStruct
        {
            public double amount;
            public QuarantineMaterialDefinition Material;
            public QuarantineProcessTypeEnum QuarantineProcess;
        }

        public ArrayList GivenOrTakenValuableMaterials()
        {
            ArrayList valuableMaterialArray = new ArrayList();
            ArrayList givenOrTakenValuableMaterialArrayList = new ArrayList();

            foreach (InpatientAdmissionValuableMaterial inpatientAdmissionValuableMaterial in ValuableMaterials)
            {
                if (inpatientAdmissionValuableMaterial.Material != null)
                {
                    if (valuableMaterialArray.Contains(inpatientAdmissionValuableMaterial.Material) == false)
                    {
                        valuableMaterialArray.Add(inpatientAdmissionValuableMaterial.Material);
                    }
                }
            }

            int count = valuableMaterialArray.Count;
            double materialCount = 0;
            for (int k = 0; k < count; k++)
            {
                materialCount = 0;
                foreach (InpatientAdmissionValuableMaterial inpatientAdmissionValuableMaterial in ValuableMaterials)
                {
                    if (inpatientAdmissionValuableMaterial.Material == (TTObjectClasses.QuarantineMaterialDefinition)valuableMaterialArray[k])
                    {
                        if (inpatientAdmissionValuableMaterial.QuarantineProcessType == QuarantineProcessTypeEnum.TakedFromPatient)
                        {
                            materialCount = materialCount + Convert.ToDouble(inpatientAdmissionValuableMaterial.Amount);
                        }
                        else if (inpatientAdmissionValuableMaterial.QuarantineProcessType == QuarantineProcessTypeEnum.GivedToPatient)
                        {
                            materialCount = materialCount - Convert.ToDouble(inpatientAdmissionValuableMaterial.Amount);
                        }
                    }
                }
                if (materialCount != 0)
                {
                    GivenOrTakenValuableMaterialStruct gotvm = new GivenOrTakenValuableMaterialStruct();
                    gotvm.Material = (QuarantineMaterialDefinition)valuableMaterialArray[k];
                    gotvm.amount = Math.Abs(materialCount);
                    if (materialCount < 0)
                    {
                        gotvm.QuarantineProcess = QuarantineProcessTypeEnum.GivedToPatient;
                    }
                    else if (materialCount > 0)
                    {
                        gotvm.QuarantineProcess = QuarantineProcessTypeEnum.TakedFromPatient;
                    }
                    givenOrTakenValuableMaterialArrayList.Add(gotvm);
                }
            }
            return givenOrTakenValuableMaterialArrayList;
        }

        public struct GivenOrTakenMoneyStruct
        {
            public double amount;
            public MonetaryUnitDefinition MonetaryUnit;
            public QuarantineProcessTypeEnum QuarantineProcess;
        }



        public static string GivenValuableMaterialsMsg(Episode episode)
        {
            ArrayList givenOrTakenValuableMaterials = episode.GivenOrTakenValuableMaterials();
            ArrayList givenOrTakenMoney = episode.GivenOrTakenMoney();
            string givenMsg = "";

            if (givenOrTakenValuableMaterials.Count != 0 || givenOrTakenMoney.Count != 0)
            {
                foreach (GivenOrTakenValuableMaterialStruct gotvm in givenOrTakenValuableMaterials)
                {
                    if (gotvm.QuarantineProcess == QuarantineProcessTypeEnum.TakedFromPatient)
                    {
                        givenMsg = givenMsg + gotvm.amount + " adet " + gotvm.Material.Material + "\r\n";
                    }

                }

                foreach (GivenOrTakenMoneyStruct gotm in givenOrTakenMoney)
                {
                    if (gotm.QuarantineProcess == QuarantineProcessTypeEnum.TakedFromPatient)
                    {
                        givenMsg = givenMsg + gotm.amount + gotm.MonetaryUnit.MonetaryUnit + "\r\n";
                    }
                }
            }
            return givenMsg;
        }

        public static string TakenValuableMaterialsMsg(Episode episode)
        {
            ArrayList givenOrTakenValuableMaterials = episode.GivenOrTakenValuableMaterials();
            ArrayList givenOrTakenMoney = episode.GivenOrTakenMoney();
            string takenMsg = "";

            if (givenOrTakenValuableMaterials.Count != 0 || givenOrTakenMoney.Count != 0)
            {
                foreach (GivenOrTakenValuableMaterialStruct gotvm in givenOrTakenValuableMaterials)
                {
                    if (gotvm.QuarantineProcess != QuarantineProcessTypeEnum.TakedFromPatient)
                    {
                        takenMsg = takenMsg + gotvm.amount + " adet " + gotvm.Material.Material + "\r\n";
                    }

                }

                foreach (GivenOrTakenMoneyStruct gotm in givenOrTakenMoney)
                {
                    if (gotm.QuarantineProcess != QuarantineProcessTypeEnum.TakedFromPatient)
                    {
                        takenMsg = takenMsg + gotm.amount + gotm.MonetaryUnit.MonetaryUnit + "\r\n";
                    }
                }
            }
            return takenMsg;
        }

        public ArrayList GivenOrTakenMoney()
        {

            ArrayList moneyArray = new ArrayList();
            ArrayList givenOrTakenMoneyArrayList = new ArrayList();

            foreach (InpatientAdmissionMoney inpatientAdmissionMoney in Money)
            {
                if (inpatientAdmissionMoney.MonetaryUnit != null)
                {
                    if (moneyArray.Contains(inpatientAdmissionMoney.MonetaryUnit) == false)
                    {
                        moneyArray.Add(inpatientAdmissionMoney.MonetaryUnit);
                    }
                }
            }

            int count = moneyArray.Count;
            double moneyCount = 0;
            for (int k = 0; k < count; k++)
            {
                moneyCount = 0;
                foreach (InpatientAdmissionMoney inpatientAdmissionMoney in Money)
                {
                    if (inpatientAdmissionMoney.MonetaryUnit == (TTObjectClasses.MonetaryUnitDefinition)moneyArray[k])
                    {
                        if (inpatientAdmissionMoney.QuarantineProcessType == QuarantineProcessTypeEnum.TakedFromPatient)
                        {
                            moneyCount = moneyCount + Convert.ToDouble(inpatientAdmissionMoney.Amount);
                        }
                        else if (inpatientAdmissionMoney.QuarantineProcessType == QuarantineProcessTypeEnum.GivedToPatient)
                        {
                            moneyCount = moneyCount - Convert.ToDouble(inpatientAdmissionMoney.Amount);
                        }
                    }
                }
                if (moneyCount != 0)
                {
                    GivenOrTakenMoneyStruct gotm = new GivenOrTakenMoneyStruct();
                    gotm.MonetaryUnit = (MonetaryUnitDefinition)moneyArray[k];
                    gotm.amount = Math.Abs(moneyCount);
                    if (moneyCount < 0)
                    {
                        gotm.QuarantineProcess = QuarantineProcessTypeEnum.GivedToPatient;
                    }
                    else if (moneyCount > 0)
                    {
                        gotm.QuarantineProcess = QuarantineProcessTypeEnum.TakedFromPatient;
                    }
                    givenOrTakenMoneyArrayList.Add(gotm);
                }
            }
            return givenOrTakenMoneyArrayList;
        }


        //Karantina işlemleri için

        public string OldActionReportHtml()
        {
            string report = "";
            report = report + "<html><table border=1 width='100%'>";
            report = report + "<tr>" + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M27172", "Vaka Açılış Tarihi"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(OpeningDate), null);
            report = report + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M27173", "Vaka Durumu"), null) + Common.FormatAsOldActionValue(CurrentStateDef.Description, null);
            report = report + "<tr>" + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M25819", "XXXXXX Protokol No"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(HospitalProtocolNo), " colspan=3");
            report = report + "<tr>" + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M27174", "Vaka Uzmanlık Dalı"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(AdmissionSpecOrRes.ToString()), " colspan=3");
            report = report + "<tr>" + Common.FormatAsOldActionTitle(TTUtils.CultureService.GetText("M20117", "Özgeçmiş"), null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(PatientHistory), " colspan=3");
            report = report + "</table></html>";

            return report;
        }

        public Guid ChangeAllSEPsPayerAndProtocol(Guid newPayer, Guid newProtocol, SubEpisodeProtocol sep)
        {
            PayerDefinition payer = ObjectContext.GetObject(newPayer, typeof(PayerDefinition)) as PayerDefinition;
            ProtocolDefinition protocol = ObjectContext.GetObject(newProtocol, typeof(ProtocolDefinition)) as ProtocolDefinition;

            List<SubEpisodeProtocol> sepList = AllSubEpisodeProtocolsWithSamePayer(sep.Payer.ObjectID, true);
            List<SubEpisodeProtocol> sepListCloned = new List<SubEpisodeProtocol>();
            bool isBkkProvisionTypeExists = false;
            foreach (SubEpisodeProtocol sepInner in sepList)
            {
                if (sepInner.CurrentStateDefID == SubEpisodeProtocol.States.Open && (sepInner.Payer.ObjectID != newPayer || sepInner.Protocol.ObjectID != newProtocol))
                {
                    if (sepInner.IsSGKAndActiveWithMedulaTakipNo && !payer.IsSGK)
                        throw new TTException("Takip alınmayan bir kuruma kurum değişikliği yaparken takip numarası var ise silinmesi gerekli.");
                }
                if (sepInner.MedulaIstisnaiHal != null && sepInner.MedulaIstisnaiHal.Kodu.Equals("9"))
                    isBkkProvisionTypeExists = true;
            }

            #region Vakabaşı Hizmeti Silme
            if (sep != null)
            {
                if (sep.Payer.IsSGK && !payer.IsSGK) // Bu durumda vakabaşı hizmetleri iptal edilir.
                {
                    CancelBulletinSubactionProcedure();
                }
            }
            #endregion

            #region Muayene Katılım Payı Hizmeti Silme
            if (payer.GetPatientParticipation != true && isBkkProvisionTypeExists == false) // Yeni kurum katılım payı alınmayan bir kurum ise katılım payı hizmeti iptal edilir.
                CancelPatientParticipationProcedure();
            #endregion

            foreach (SubEpisodeProtocol sepInner in sepList)
            {
                if (sepInner.CurrentStateDefID == SubEpisodeProtocol.States.Open && (sepInner.Payer.ObjectID != newPayer || sepInner.Protocol.ObjectID != newProtocol))
                {
                    SubEpisodeProtocol.SEPProperty SEPProperty = new SubEpisodeProtocol.SEPProperty();
                    SEPProperty.payer = payer;
                    SEPProperty.protocol = protocol;
                    SEPProperty.creationDate = sepInner.CreationDate.Value;
                    SEPProperty.cancelOldSEP = true;
                    SubEpisodeProtocol cloneSEP = sepInner.CloneForNewSEP(SEPCloneTypeEnum.InvoiceScreenChangePayer, SEPProperty);

                    InvoiceLog.AddInfo(TTUtils.CultureService.GetText("M26358", "Kurum Değiştirildi. Eski kurum:") + sepInner.Payer.Name + " Yeni kurum: " + cloneSEP.Payer.Name, sepInner.ObjectID, InvoiceOperationTypeEnum.ChangePayer, InvoiceLogObjectTypeEnum.SubEpisodeProtocol, ObjectContext);
                    sepListCloned.Add(cloneSEP);

                    if (sepInner.SubEpisode.PatientAdmission.Payer == null || (sepInner.SubEpisode.PatientAdmission.Payer != null && sepInner.SubEpisode.PatientAdmission.Payer.ObjectID != payer.ObjectID))
                        sepInner.SubEpisode.PatientAdmission.Payer = payer;
                    if (sepInner.SubEpisode.PatientAdmission.Protocol == null || (sepInner.SubEpisode.PatientAdmission.Protocol != null && sepInner.SubEpisode.PatientAdmission.Protocol.ObjectID != protocol.ObjectID))
                        sepInner.SubEpisode.PatientAdmission.Protocol = protocol;

                    if (sepInner.SubEpisode.Episode.Payer == null || (sepInner.SubEpisode.Episode.Payer != null && sepInner.SubEpisode.Episode.Payer.ObjectID != payer.ObjectID))
                        sepInner.SubEpisode.Episode.Payer = payer;

                    InvoiceLog.AddInfo(TTUtils.CultureService.GetText("M26358", "Kurum Değiştirildi. Eski kurum:") + sepInner.Payer.Name + " Yeni kurum: " + cloneSEP.Payer.Name, cloneSEP.ObjectID, InvoiceOperationTypeEnum.ChangePayer, InvoiceLogObjectTypeEnum.SubEpisodeProtocol, ObjectContext);
                }
            }

            #region Vakabaşı Hizmet Ekleme
            if (sepList.Count > 0)
            {
                if (!sepList[0].Payer.IsSGK && payer.IsSGK) // Bu durumda vakabaşı hizmeti oluşturulur.
                {
                    foreach (PatientAdmission item in PatientAdmissions)
                    {
                        PatientAdmission.ControlBulletinProtocol(item);
                    }
                }
            }
            #endregion

            #region Muayene Katılım Payı Hizmeti Ekleme
            if (payer.GetPatientParticipation == true) // Yeni kurum katılım payı alnan bir kurum ise katılım payı hizmeti oluşturulur.
                AddPatientParticipationProcedure();
            #endregion

            foreach (SubEpisodeProtocol sepInner in sepListCloned)
            {
                if (sepInner.ParentSEP != null)
                    sepInner.ParentSEP = sepListCloned.Where(x => x.ClonedFrom.ObjectID == sepInner.ParentSEP.ObjectID).FirstOrDefault();
            }

            if (sepListCloned.Count == 0)
                throw new TTException(TTUtils.CultureService.GetText("M26359", "Kurum değiştirilemedi. Açık durumda takip olmayabilir veya aynı kurum ve anlaşma seçilmiş olabilir."));

            Guid returnValue = Guid.Empty;

            if (sepListCloned.Count > 0)
                returnValue = sepListCloned.First().ObjectID;

            return returnValue;
        }

        /*
        public BulletinProcedureDefinition getBulletinProcedure()
        {
            foreach (PatientExamination pe in this.PatientExaminations)
            {
                if (pe.CurrentStateDefID != PatientExamination.States.Cancelled)
                {
                    if (pe.MasterResource is ResPoliclinic)
                    {
                        return ((ResPoliclinic)pe.MasterResource).BulletinProcedure;
                    }
                }
            }

            return null;
        }
        */

        public static bool HasMainDiagnose(Episode episode)
        {
            foreach (DiagnosisGrid diagnosisGrid in episode.AllSecDiagnosis)
            {
                if (diagnosisGrid.IsMainDiagnose == true)
                    return true;
            }
            return false;
        }

        public ResWard GetInPatientClinic()
        {
            foreach (InpatientAdmission inpadmission in InpatientAdmissions)
            {
                if (inpadmission.IsCancelled == false)
                {
                    return inpadmission.PhysicalStateClinic;
                }
            }
            return null;
        }

        public ResClinic GetInPatientTreatmentClinic()
        {
            ResClinic clinic = null;
            foreach (InpatientAdmission inpadmission in InpatientAdmissions)
            {
                if (inpadmission.IsCancelled == false)
                {
                    DateTime? LastclinicTreatment = Convert.ToDateTime("01/01/1000 00:00");
                    foreach (InPatientTreatmentClinicApplication ipTCliniCApp in inpadmission.InPatientTreatmentClinicApplications)
                    {
                        if (ipTCliniCApp.RequestDate != null && ipTCliniCApp.RequestDate > LastclinicTreatment)
                        {
                            LastclinicTreatment = ipTCliniCApp.RequestDate;
                            if (ipTCliniCApp.MasterResource is ResClinic)
                                clinic = (ResClinic)ipTCliniCApp.MasterResource;
                        }
                    }
                    break;
                }
            }
            return clinic;
        }

        public ResPoliclinic GetExaminationPoliclinic()
        {
            foreach (PatientExamination pe in PatientExaminations)
            {
                if (pe.IsCancelled == false && pe.MasterResource is ResPoliclinic)
                    return pe.MasterResource as ResPoliclinic;
            }

            return null;
        }

        public ISUTMaterialTotalAmount SUTMaterialTotalAmount(ISUTEpisodeAction episodeAction, Guid materialID)
        {
            ISUTMaterialTotalAmount materialTotalAmount = episodeAction.NewSUTMaterialTotalAmount(materialID);

            //            IList subactionMaterialsList = Episode.GetEHREpisodeSubactionMaterialsTotalAmount(this.ObjectID, materialID);
            //            foreach (Episode.GetEHREpisodeSubactionMaterialsTotalAmount_Class o in subactionMaterialsList)
            //                materialTotalAmount.TotalAmount += Convert.ToDouble(o.Totalamount);

            return materialTotalAmount;
        }

        public ISUTProcedureTotalAmount SUTProcedureTotalAmount(ISUTEpisodeAction episodeAction, Guid procedureID)
        {
            ISUTProcedureTotalAmount procedureTotalAmount = episodeAction.NewSUTProcedureTotalAmount(procedureID);

            //            IList subactionProceduresTotalAmountList = Episode.GetEHREpisodeSubactionProceduresTotalAmount(this.ObjectID, procedureID);
            //            foreach (Episode.GetEHREpisodeSubactionProceduresTotalAmount_Class o in subactionProceduresTotalAmountList)
            //                procedureTotalAmount.TotalAmount += Convert.ToInt64(o.Totalamount);
            //
            //            subactionProceduresTotalAmountList = Episode.GetEHREpisodeSubactProcedureFlowablesTotalAmount(this.ObjectID, procedureID);
            //            foreach (Episode.GetEHREpisodeSubactProcedureFlowablesTotalAmount_Class o in subactionProceduresTotalAmountList)
            //                procedureTotalAmount.TotalAmount += Convert.ToInt64(o.Totalamount);

            return procedureTotalAmount;
        }

        public List<ISUTInstance> SUTSubactionProcedures(Guid procedureID)
        {
            List<ISUTInstance> retValue = new List<ISUTInstance>();
            //            IList subactionProcedures = Episode.GetEHREpisodeSubactionProcedures(procedureID, this.ObjectID, string.Empty);
            //            if (subactionProcedures.Count > 0)
            //            {
            //                TTObjectContext objectContext = new TTObjectContext(false);
            //                foreach (Episode.GetEHREpisodeSubactionProcedures_Class o in subactionProcedures)
            //                {
            //                    SUTInstance sutInstance = new SUTInstance(objectContext);
            //                    sutInstance.RuleDate = o.ActionDate;
            //                    sutInstance.RuleAmount = o.Amount;
            //                    sutInstance.SUTRulableObject = (ProcedureDefinition)objectContext.GetObject((Guid)o.Procedureobjectid, typeof(ProcedureDefinition));
            //                    retValue.Add(sutInstance);
            //                }
            //            }
            return retValue;
        }

        public List<ISUTInstance> SUTDiagnosisGrid()
        {
            List<ISUTInstance> retValue = new List<ISUTInstance>();
            //            IList episodeDiagnosis = Episode.GetEHREpisodeDiagnosis(this.ObjectID, string.Empty);
            //            if (episodeDiagnosis.Count > 0)
            //            {
            //                TTObjectContext objectContext = new TTObjectContext(false);
            //                foreach (Episode.GetEHREpisodeDiagnosis_Class o in episodeDiagnosis)
            //                {
            //                    SUTInstance sutInstance = new SUTInstance(objectContext);
            //                    sutInstance.RuleDate = o.DiagnoseDate;
            //                    sutInstance.SUTRulableObject = (DiagnosisDefinition)objectContext.GetObject((Guid)o.Diagnosisobjectid, typeof(DiagnosisDefinition));
            //                    retValue.Add(sutInstance);
            //                }
            //            }
            return retValue;
        }


        public ISUTPatient SUTPatient
        {
            get
            {
                return (ISUTPatient)Patient;
            }
        }

        //Episode
        /// <summary>
        /// Diğer XXXXXXlerden Yaratılan Episodelar Yatatan Sitea Yaratılma Sonucunu döner.
        /// </summary>
        public void RunReturnToDispatchToOtherHospital()
        {
            //            if (this.sourceDispatchObjID != null) //XXXXXXler Arsı Sevkden yaratıldı ise
            //            {
            //                if (this.CreaterSite != null)
            //                {
            //                    TTObjectContext objectContext = new TTObjectContext(false);
            //                    try
            //                    {
            //
            //                        TTMessage message = DispatchToOtherHospital.RemoteMethods.ReturnDispatchToOtherHospital(this.CreaterSite.ObjectID, this);
            //                        objectContext.Save();
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        throw ex;
            //                    }
            //                    finally
            //                    {
            //                        objectContext.Dispose();
            //                    }
            //                }
            //            }
        }

        /*
        public EpisodeProtocol GetMyEpisodeProtocolForRemoteMethod()
        {
            EpisodeProtocol episodeProtocol = this.MyEpisodeProtocol();
            if(episodeProtocol != null)
                return  episodeProtocol.PrepareEpisodeProtocolForRemoteMethod(true);
            else
                throw new Exception(SystemMessage.GetMessage(997));
        }
         */

        ///// <summary>
        ///// Diğer Sitedan Gelen Vaka Local Siteda Oluşturulur.
        ///// </summary>
        ///// <param name="objectContext"></param>
        ///// <param name="createrSite"></param>
        ///// <param name="sourcePatient"></param>
        ///// <param name="sourcePatientAdmission"></param>
        ///// <param name="episodeDiagnosis"></param>
        ///// <param name="admissionTypeEnum"></param>
        ///// <returns></returns>
        //public Episode PrepareEpisodeInRemoteMethod(TTObjectContext objectContext, Sites createrSite, Patient sourcePatient, PatientAdmission sourcePatientAdmission, List<DiagnosisGrid> episodeDiagnosis, AdmissionTypeEnum admissionTypeEnum/*, EpisodeProtocol sourceEpisodeProtocol*/)
        //{
        //    Episode sourceEpisode = this;
        //    //Patient target tan get edilir.
        //    Patient.AddOrUpdatePatientWithLocalID(objectContext, sourcePatient);

        //    objectContext.AddObject(sourcePatientAdmission);
        //    objectContext.AddObject(sourceEpisode);
        //    //objectContext.AddObject(sourceEpisodeProtocol);

        //    PatientAdmission targetPatientAdmission = (PatientAdmission)objectContext.GetObject(sourcePatientAdmission.ObjectID, sourcePatientAdmission.ObjectDef);
        //    Episode targetEpisode = (Episode)objectContext.GetObject(sourceEpisode.ObjectID, sourceEpisode.ObjectDef);

        //    //Episode property leri set ediliyor.
        //    targetEpisode.PatientAdmission = targetPatientAdmission;
        //    targetEpisode.OpeningDate = Common.RecTime();
        //    targetEpisode.HospitalProtocolNo.GetNextValue(Common.RecTime().Year);
        //    targetEpisode.ID.GetNextValue();
        //    targetEpisode.CreaterSite = createrSite;
        //    targetEpisode.Patient = targetPatientAdmission.Patient;

        //    //Episode Set edilirken IsParentRelationReadonly ve IsPropertyReadonly
        //    //kodlarının false dönmesini Böylece Episode'dan gelen Propogation(CopyToların) ReadOnly'ye takılmadan set edilmesini sağlar
        //    targetPatientAdmission.IsSettingEpisode = true;
        //    targetPatientAdmission.Episode = (Episode)targetEpisode;
        //    targetPatientAdmission.IsSettingEpisode = false;

        //    /*
        //    if (sourceEpisodeProtocol != null)
        //    {
        //        EpisodeProtocol targetEpisodeProtocol = (EpisodeProtocol)objectContext.GetObject(sourceEpisodeProtocol.ObjectID, sourceEpisodeProtocol.ObjectDef);
        //        targetEpisodeProtocol.Episode = (Episode)targetEpisode;
        //        targetEpisodeProtocol.ID.GetNextValue();
        //    }
        //    */

        //    foreach (DiagnosisGrid diagnose in episodeDiagnosis)
        //    {
        //        objectContext.AddObject(diagnose);
        //        DiagnosisGrid targetDiagnose = (DiagnosisGrid)objectContext.GetObject(diagnose.ObjectID, diagnose.ObjectDef);
        //        //targetDiagnose.MedulaServiceProviderRefNo.GetNextValue();
        //        targetDiagnose.Episode = targetEpisode;
        //        targetDiagnose.EpisodeAction = null;
        //    }

        //    IList list = ReasonForAdmission.GetByReasonAdmissionType(objectContext, admissionTypeEnum);
        //    if (list.Count < 1)
        //    {
        //        string[] hataParamList = new string[] { admissionTypeEnum.ToString() };
        //        String message = SystemMessage.GetMessageV3(138, hataParamList);
        //        throw new TTUtils.TTException(message);
        //        //throw new Exception("Gönderilen XXXXXXde " + AdmissionTypeEnum.ToString() + " kabul sebebi tanımı yapılmamıştır .Lütfen Bilgi İşleme Bildiriniz.Tanım yapıldığında tekrar deneyiniz.");
        //    }
        //    else
        //    {
        //        targetPatientAdmission.AdmissionType = (AdmissionTypeEnum)list[0];

        //    }
        //    return targetEpisode;
        //}

        ///// <summary>
        ///// Vaka Diğer Sitelara Gönderilmeye Hazır Hale Getirilir
        ///// </summary>
        ///// <param name="withNewObjectID"></param>
        ///// <returns></returns>
        //public Episode PrepareEpisodeForRemoteMethod(bool withNewObjectID)
        //{
        //    // Çağırılan yerde savePoit konulup daha sonra o pointe dönülmeli
        //    if (withNewObjectID)
        //    {
        //        Episode sendingEpisode = (Episode)this.Clone();
        //        sendingEpisode.PatientAdmission = null;
        //        sendingEpisode.PatientStatus = PatientStatusEnum.Outpatient;
        //        sendingEpisode.DischargeDate = null;
        //        sendingEpisode.EstimatedDischargeDate = null;
        //        sendingEpisode.QuarantineCupboardNo = null;
        //        sendingEpisode.QuarantineDischargeDate = null;
        //        sendingEpisode.QuarantineInPatientDate = null;
        //        sendingEpisode.CurrentStateDefID = Episode.States.Open;
        //        sendingEpisode.AdmissionResource = null;
        //        sendingEpisode.ClosedByMorgue = false;
        //        sendingEpisode.ClosingDate = null;
        //        sendingEpisode.CreaterSite = null;
        //        sendingEpisode.DischargeDate = null;

        //        sendingEpisode.IntensiveCareBed = null;
        //        sendingEpisode.IntensiveCareRoom = null;
        //        sendingEpisode.IntensiveCareRoomGroup = null;
        //        sendingEpisode.MainDiagnose = null;
        //        sendingEpisode.TreatmentClinic = null;
        //        sendingEpisode.Bed = null;
        //        sendingEpisode.Room = null;
        //        sendingEpisode.RoomGroup = null;
        //        TTSequence.allowSetSequenceValue = true;
        //        sendingEpisode.ID.SetSequenceValue(0);
        //        TTSequence.allowSetSequenceValue = true;
        //        sendingEpisode.HospitalProtocolNo.SetSequenceValue(0);
        //        return sendingEpisode;
        //    }
        //    else
        //    {
        //        return this;
        //    }

        //}

        public void CancelBulletinProcedure()
        {
            List<Guid> stateList = new List<Guid>();
            stateList.Add(AccountTransaction.States.New);
            stateList.Add(AccountTransaction.States.ToBeNew);
            stateList.Add(AccountTransaction.States.MedulaDontSend);
            stateList.Add(AccountTransaction.States.MedulaEntryUnsuccessful);

            foreach (SubEpisodeProtocol sep in AllSubEpisodeProtocols())
            {
                IList accTrxList = AccountTransaction.GetBulletinProcedureTrxsBySEP(ObjectContext, sep.ObjectID, stateList);
                foreach (AccountTransaction at in accTrxList)
                    at.SubActionProcedure.CancelMyAccountTransactions();
            }
        }

        public void CancelBulletinSubactionProcedure()
        {
            List<Guid> stateList = new List<Guid>();
            stateList.Add(AccountTransaction.States.New);
            stateList.Add(AccountTransaction.States.ToBeNew);
            stateList.Add(AccountTransaction.States.MedulaDontSend);
            stateList.Add(AccountTransaction.States.MedulaEntryUnsuccessful);

            foreach (SubEpisodeProtocol sep in AllSubEpisodeProtocols())
            {
                IList accTrxList = AccountTransaction.GetBulletinProcedureTrxsBySEP(ObjectContext, sep.ObjectID, stateList);
                foreach (AccountTransaction at in accTrxList)
                    ((ITTObject)at.SubActionProcedure).Cancel();

            }
        }

        public bool IsInvoicedBulletinProcedureExists()
        {
            List<Guid> stateList = new List<Guid>();
            stateList.Add(AccountTransaction.States.Invoiced);
            stateList.Add(AccountTransaction.States.Ready);
            stateList.Add(AccountTransaction.States.Send);
            stateList.Add(AccountTransaction.States.Paid);

            foreach (SubEpisodeProtocol sep in AllSubEpisodeProtocols())
            {
                IList accTrxList = AccountTransaction.GetBulletinProcedureTrxsBySEP(ObjectContext, sep.ObjectID, stateList);
                if (accTrxList.Count > 0)
                    return true;
            }

            return false;
        }

        public bool IsUnpaidPackageSPExists()
        {
            List<Guid> stateList = new List<Guid>();
            stateList.Add(AccountTransaction.States.New);

            BindingList<AccountTransaction> accTrxList = AccountTransaction.GetPackageTransactionsByEpisode(ObjectContext, ObjectID, Patient.MyAPR().ObjectID, stateList);
            foreach (AccountTransaction accTrx in accTrxList)
            {
                if (accTrx.UnitPrice > 0 &&
                    accTrx.SubEpisodeProtocol.Brans.Code != "4400" && accTrx.SubEpisodeProtocol.Brans.Code != "1596" && // Acil branşları için ödeme kontrolü yapılmaz
                    accTrx.SubActionProcedure.IsCashOfficeBlock() == false)
                    return true;
            }

            return false;
        }

        //public bool IsMedulaEpisode()
        //{
        //    return IsMedulaEpisode(this);
        //}
        //public static bool IsMedulaEpisode(Episode episode)
        //{
        //    return IsMedulaEpisode(episode, null);
        //}

        //private static bool IsMedulaEpisode(Episode episode, PatientAdmission patientAdmission)
        //{
        //    if (SystemParameter.GetParameterValue("MEDULA", "TRUE").ToUpper() == "FALSE")
        //        return false;

        //    PatientAdmission myPatientAdmission = null;
        //    if (patientAdmission != null)
        //        myPatientAdmission = patientAdmission;
        //    else
        //        myPatientAdmission = episode.LastSubEpisode.PatientAdmission;

        //    if (myPatientAdmission != null && myPatientAdmission.IsSGKPatientAdmission)
        //        return true;

        //    foreach (SubEpisodeProtocol sep in episode.AllSubEpisodeProtocols)
        //    {
        //        if (sep.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && sep.IsSGK)
        //            return true;
        //    }

        //    //if (myPatientAdmission.IsSGKPatientAdmission)  // Hasta Grubu SGK'lı ise
        //    //{
        //    //                if(myPatientAdmission != null && myPatientAdmission.ReasonForAdmission != null && myPatientAdmission.ReasonForAdmission.IgnoreMedula != true)
        //    //                {
        //    //                    if(myPatientAdmission is PA_CivilianConsignment) // Sivil Sevkli ise kurumunun tür bilgisi de kontrol edilmeli
        //    //                    {
        //    //                        if(patientAdmission == null)  // Hasta kabul ve hasta kabul düzeltmeden çağrılmamışsa...
        //    //                        {
        //    //                            EpisodeProtocol ep = MyLastEpisodeProtocol();
        //    //                            if(ep != null)
        //    //                            {
        //    //                                if(ep.Payer.Type != null)
        //    //                                {
        //    //                                    if(ep.Payer.Type.IsSGK == true)  // Son anlaşmanın kurumu SGK türünde ise
        //    //                                        return true;
        //    //                                }
        //    //                                else
        //    //                                    throw new TTUtils.TTException(ep.Payer.Name + " kurumunun türü bilinmediği için vakanın SGK'lı olup olmadığı bilinemiyor!");
        //    //                            }
        //    //                        }
        //    //                        else
        //    //                        {
        //    //                            if(myPatientAdmission.Payer != null)
        //    //                            {
        //    //                                if(myPatientAdmission.Payer.Type != null)
        //    //                                {
        //    //                                    if(myPatientAdmission.Payer.Type.IsSGK == true)  // Hasta kabuldeki kurum SGK türünde ise
        //    //                                        return true;
        //    //                                }
        //    //                                else
        //    //                                    throw new TTUtils.TTException(myPatientAdmission.Payer.Name + " kurumunun türü bilinmediği için vakanın SGK'lı olup olmadığı bilinemiyor!");
        //    //                            }
        //    //                            else
        //    //                                return false;
        //    //                        }
        //    //                    }
        //    //                    else  // Sivil Sevkli dışındakilerde direkt true dönmeli
        //    //return true;
        //    //}
        //    //}
        //    return false;
        //}

        /* kpayi --- public bool IsMedulaPatientParticipationExists()
        {
            foreach (PatientExamination pe in this.PatientExaminations)
            {
                if (pe.MuayeneGiris != null)
                {
                    if(pe.MuayeneGiris.CurrentStateDefID != MuayeneGiris.States.Cancelled)
                        return true;
                }
            }

            foreach(DentalExamination de in this.DentalExaminations)
            {
                if (de.MuayeneGiris != null)
                {
                    if(de.MuayeneGiris.CurrentStateDefID != MuayeneGiris.States.Cancelled)
                        return true;
                }
            }

            foreach(EmergencyIntervention emergencyInt in this.EmergencyInterventions)
            {
                if (emergencyInt.MuayeneGiris != null)
                {
                    if(emergencyInt.MuayeneGiris.CurrentStateDefID != MuayeneGiris.States.Cancelled)
                        return true;
                }
            }

            return false;
        }

        public void CancelMedulaPatientParticipation()
        {
            foreach (PatientExamination pe in this.PatientExaminations)
            {
                if (pe.MuayeneGiris != null)
                {
                    if(pe.MuayeneGiris.CurrentStateDefID != MuayeneGiris.States.Cancelled)
                        pe.MuayeneGiris.CurrentStateDefID = MuayeneGiris.States.Cancelled;
                }
            }

            foreach(DentalExamination de in this.DentalExaminations)
            {
                if (de.MuayeneGiris != null)
                {
                    if(de.MuayeneGiris.CurrentStateDefID != MuayeneGiris.States.Cancelled)
                        de.MuayeneGiris.CurrentStateDefID = MuayeneGiris.States.Cancelled;
                }
            }
        }

        public void AddOrCancelMedulaPatientParticipation()
        {
            // Yeni eklenen anlaşmaya göre yeniden muayene katılım payı oluşturulur veya oluşturulmaz
            bool muayeneKatılımPayıEkle = false;
            bool hasParticipation = true;
            bool katılımPayınıIptalEt = true; // buradan katılım payı eklenemiyorsa, önceden oluşmuş katılım payı da silinmeli
            RelationshipDefinition relationshipDefinition = null;

            // Acil hastalar (Hasta Grubu veya kabul sebebi acil olanlar) ve Portör Muayenesi için Muayene Katılım Payı oluşturulmayacak
            if (this.PatientGroup != PatientGroupEnum.Emergency && this.ReasonForAdmission.Type != AdmissionTypeEnum.Emergency && this.ReasonForAdmission.Type != AdmissionTypeEnum.PortorExamination && this.Patient.IsNewBorn != true)
            {
                // Tutuklu ve Adli Vakalarda da katılım payı alınmamalı
                if (this.ReasonForAdmission.Type != AdmissionTypeEnum.Arrested && this.ReasonForAdmission.Type != AdmissionTypeEnum.JudicialObservation && this.ReasonForAdmission.Type != AdmissionTypeEnum.JudicialObservationFileInvestigation && this.PatientAdmission.Arrested != true)
                {
                    if (this.PatientAdmission.ParticipationType != null)
                    {
                        foreach (PatientExamParticipDetail pgrid in this.PatientAdmission.ParticipationType.Relationships)
                        {
                            if (this.PatientAdmission.HaveRelationshipProperty()) // yakınlık derecesi varsa set edilir
                                relationshipDefinition = this.Relationship;

                            if(relationshipDefinition == null)
                            {
                                // Yakınlık derecesi hasta kabul forumunda yoksa Default yakınlık derecesini 'Kendisi' olarak atanır
                                Guid defaultRelationshipGuid = new Guid("{434014dc-596b-4c08-9e5e-76de439893dc}");
                                relationshipDefinition = (RelationshipDefinition)this._objectContext.GetObject(defaultRelationshipGuid, "RELATIONSHIPDEFINITION");
                            }

                            if (relationshipDefinition == pgrid.Relationship)
                            {
                                if(this.PatientAdmission.ParticipationType.OnlyForDefinedUnits == true)
                                {
                                    ResSection masterRes = null;
                                    foreach (PatientExamination pe in this.PatientExaminations)
                                    {
                                        if (pe.CurrentStateDefID != PatientExamination.States.Cancelled && pe.CurrentStateDefID != PatientExamination.States.PatientNoShown)
                                        {
                                            if(pe.MasterResource != null)
                                            {
                                                masterRes = pe.MasterResource;
                                                break;
                                            }
                                        }
                                    }

                                    if(masterRes == null)
                                    {
                                        foreach(DentalExamination de in this.DentalExaminations)
                                        {
                                            if (de.CurrentStateDefID != DentalExamination.States.Cancelled && de.CurrentStateDefID != DentalExamination.States.PatientNoShown)
                                            {
                                                if(de.MasterResource != null)
                                                {
                                                    masterRes = de.MasterResource;
                                                    break;
                                                }
                                            }
                                        }
                                    }

                                    foreach(PatientExamParticipUnit unit in this.PatientAdmission.ParticipationType.Units)
                                    {
                                        if(unit.ResSection != null && masterRes != null)
                                        {
                                            if(unit.ResSection.ObjectID == masterRes.ObjectID)
                                            {
                                                hasParticipation = false;
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                    hasParticipation = false;
                                break;
                            }
                        }
                    }

                    PatientGroupDefinition pg = Common.PatientGroupDefinitionByEnum(this.ObjectContext, this.PatientGroup.Value);
                    if (pg.GetPatientParticipation == true)
                    {
                        if(this.MyEpisodeProtocol() == null || this.MyEpisodeProtocol().Payer.GetPatientParticipation == true)
                        {
                            muayeneKatılımPayıEkle = TTObjectClasses.SystemParameter.IsPatientExaminationParticipationControl;

                            if (muayeneKatılımPayıEkle && hasParticipation)
                            {
                                PatientExamination pEx = null;
                                foreach (PatientExamination pe in this.PatientExaminations)
                                {
                                    if (pe.CurrentStateDefID != PatientExamination.States.Cancelled && pe.CurrentStateDefID != PatientExamination.States.PatientNoShown)
                                    {
                                        pEx = pe;
                                        break;
                                    }
                                }

                                DentalExamination dEx = null;
                                foreach(DentalExamination de in this.DentalExaminations)
                                {
                                    if (de.CurrentStateDefID != DentalExamination.States.Cancelled && de.CurrentStateDefID != DentalExamination.States.PatientNoShown)
                                    {
                                        dEx = de;
                                        break;
                                    }
                                }

                                // Epizotta Muayene veya Diş Muayenesi işlemi varsa, Muayene Katılım Payı oluşturulacak
                                if (pEx != null)
                                {
                                    pEx.AddMedulaPatientParticipation();
                                    katılımPayınıIptalEt = false;
                                }
                                else if (dEx != null)
                                {
                                    dEx.AddMedulaPatientParticipation();
                                    katılımPayınıIptalEt = false;
                                }
                            }
                        }
                    }
                }
            }
            if(katılımPayınıIptalEt)
                this.CancelMedulaPatientParticipation();
        }

        public void CancelPatientParticipationProcedure()
        {
            // Muayene  Katılım Payını iptal eder
            Guid muayeneKatılımPayıGuid;
            try
            {
                muayeneKatılımPayıGuid = ProcedureDefinition.ExaminationParticipationProcedureObjectId;
            }
            catch
            {
                throw new TTUtils.TTException(SystemMessage.GetMessage(230));
            }

            // Muayene  Katılım Payı iptal edilir
            foreach (EpisodeProtocol ep in this.EpisodeProtocols)
            {
                IList myPAccountTransactions = ep.GetSubActionProcedureTransactions();
                foreach (AccountTransaction at in myPAccountTransactions)
                {
                    if(at.SubActionProcedure != null)
                    {
                        if (at.SubActionProcedure.ProcedureObject.ObjectID == muayeneKatılımPayıGuid)
                        {
                            ((ITTObject)at.SubActionProcedure).Cancel();
                            break;
                        }
                    }
                }
            }
        }

        public void AddPatientParticipationProcedure()
        {
            // Yeni eklenen anlaşmaya göre yeniden muayene katılım payı oluşturulur veya oluşturulmaz
            bool muayeneKatılımPayıEkle = false;
            bool hasParticipation = true;
            RelationshipDefinition relationshipDefinition = null;
            Guid muayeneKatılımPayıGuid;

            try
            {
                muayeneKatılımPayıGuid = ProcedureDefinition.ExaminationParticipationProcedureObjectId;
            }
            catch
            {
                throw new TTUtils.TTException(SystemMessage.GetMessage(230));
            }

            // Acil hastalar (Hasta Grubu veya kabul sebebi acil olanlar) ve Portör Muayenesi için Muayene Katılım Payı oluşturulmayacak
            if (this.PatientGroup != PatientGroupEnum.Emergency && this.ReasonForAdmission.Type != AdmissionTypeEnum.Emergency && this.ReasonForAdmission.Type != AdmissionTypeEnum.PortorExamination && this.Patient.IsNewBorn != true)
            {
                // Tutuklu ve Adli Vakalarda da katılım payı alınmamalı
                if (this.ReasonForAdmission.Type != AdmissionTypeEnum.Arrested && this.ReasonForAdmission.Type != AdmissionTypeEnum.JudicialObservation && this.ReasonForAdmission.Type != AdmissionTypeEnum.JudicialObservationFileInvestigation && this.PatientAdmission.Arrested != true)
                {
                    if (this.PatientAdmission.ParticipationType != null)
                    {
                        foreach (PatientExamParticipDetail pgrid in this.PatientAdmission.ParticipationType.Relationships)
                        {
                            if (this.PatientAdmission.HaveRelationshipProperty()) // yakınlık derecesi varsa set edilir
                                relationshipDefinition = this.Relationship;

                            if(relationshipDefinition == null)
                            {
                                // Yakınlık derecesi hasta kabul forumunda yoksa Default yakınlık derecesini 'Kendisi' olarak atanır
                                Guid defaultRelationshipGuid = new Guid("{434014dc-596b-4c08-9e5e-76de439893dc}");
                                relationshipDefinition = (RelationshipDefinition)this._objectContext.GetObject(defaultRelationshipGuid, "RELATIONSHIPDEFINITION");
                            }

                            if (relationshipDefinition == pgrid.Relationship)
                            {
                                if(this.PatientAdmission.ParticipationType.OnlyForDefinedUnits == true)
                                {
                                    ResSection masterRes = null;
                                    foreach (PatientExamination pe in this.PatientExaminations)
                                    {
                                        if (pe.CurrentStateDefID != PatientExamination.States.Cancelled)
                                        {
                                            if(pe.MasterResource != null)
                                            {
                                                masterRes = pe.MasterResource;
                                                break;
                                            }
                                        }
                                    }

                                    if(masterRes == null)
                                    {
                                        foreach(DentalExamination de in this.DentalExaminations)
                                        {
                                            if (de.CurrentStateDefID != DentalExamination.States.Cancelled)
                                            {
                                                if(de.MasterResource != null)
                                                {
                                                    masterRes = de.MasterResource;
                                                    break;
                                                }
                                            }
                                        }
                                    }

                                    foreach(PatientExamParticipUnit unit in this.PatientAdmission.ParticipationType.Units)
                                    {
                                        if(unit.ResSection != null && masterRes != null)
                                        {
                                            if(unit.ResSection.ObjectID == masterRes.ObjectID)
                                            {
                                                hasParticipation = false;
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                    hasParticipation = false;
                                break;
                            }
                        }
                    }

                    PatientGroupDefinition pg = Common.PatientGroupDefinitionByEnum(this.ObjectContext, this.PatientGroup.Value);
                    if (pg.GetPatientParticipation == true)
                    {
                        muayeneKatılımPayıEkle = TTObjectClasses.SystemParameter.IsPatientExaminationParticipationControl;
                        if (muayeneKatılımPayıEkle && hasParticipation)
                        {
                            if(MyEpisodeProtocol() == null)
                                throw new TTUtils.TTException("Bu vakaya ait açık anlaşma bulunmamaktadır!");

                            if(MyEpisodeProtocol().Payer.GetPatientParticipation == true)
                            {
                                // Ödendi durumunda Muayene Katılım Payı varsa tekrar oluşturmamalı
                                bool odenmisMuayeneKatılımPayıMevcut = false;
                                AccountPayableReceivable myAPR = this.Patient.MyAPR();

                                foreach (EpisodeProtocol ep in this.EpisodeProtocols)
                                {
                                    IList myAccountTransactions = ep.GetTransactionsExceptCancelledByEpisodeProtocol(myAPR);
                                    foreach (AccountTransaction at in myAccountTransactions)
                                    {
                                        if (at.SubActionProcedure != null)
                                        {
                                            if (at.SubActionProcedure.ProcedureObject.ObjectID == muayeneKatılımPayıGuid && at.CurrentStateDefID == AccountTransaction.States.Paid)
                                            {
                                                odenmisMuayeneKatılımPayıMevcut = true;
                                                break;
                                            }
                                        }
                                    }
                                }

                                if (!odenmisMuayeneKatılımPayıMevcut)
                                {
                                    PatientExamination pEx = null;
                                    foreach (PatientExamination pe in this.PatientExaminations)
                                    {
                                        if (pe.CurrentStateDefID != PatientExamination.States.Cancelled)
                                        {
                                            pEx = pe;
                                            break;
                                        }
                                    }

                                    DentalExamination dEx = null;
                                    foreach(DentalExamination de in this.DentalExaminations)
                                    {
                                        if (de.CurrentStateDefID != DentalExamination.States.Cancelled)
                                        {
                                            dEx = de;
                                            break;
                                        }
                                    }

                                    // Epizotta Muayene veya Diş Muayenesi işlemi varsa, Muayene Katılım Payı oluşturulacak
                                    if (pEx != null || dEx != null)
                                    {
                                        PatientExaminationProcedure patientShareProcedure = null;
                                        patientShareProcedure = new PatientExaminationProcedure(this.ObjectContext);
                                        patientShareProcedure.ProcedureObject = (ProcedureDefinition)this.ObjectContext.GetObject(muayeneKatılımPayıGuid, "PROCEDUREDEFINITION");
                                        patientShareProcedure.CurrentStateDefID = PatientExaminationProcedure.States.Completed;

                                        if (pEx != null)
                                            pEx.SubactionProcedures.Add(patientShareProcedure);
                                        else
                                            dEx.SubactionProcedures.Add(patientShareProcedure);

                                        patientShareProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
         */
        public List<AccountTransaction> GetPatientParticipationProcedure()
        {
            List<AccountTransaction> accTrxList = new List<AccountTransaction>();

            Guid muayeneKatılımPayıGuid = ProcedureDefinition.ExaminationParticipationProcedureObjectId;
            IList transactionsList = AccountTransaction.GetByProcedureAndEpisode(ObjectContext, muayeneKatılımPayıGuid, ObjectID);
            foreach (AccountTransaction at in transactionsList)
            {
                if (!at.IsCancelled)
                    accTrxList.Add(at);
            }

            return accTrxList;
        }

        public void CancelPatientParticipationProcedure()
        {
            List<AccountTransaction> participationTrxList = GetPatientParticipationProcedure();
            if (participationTrxList.Count > 0) // Yeni kurum katılım payı alnmayan bir kurum ise katılım payı hizmeti iptal edilir.
            {
                foreach (AccountTransaction accTrx in participationTrxList)
                {
                    ((ITTObject)accTrx.SubActionProcedure).Cancel();
                }
            }
        }

        public SubActionProcedure AddPatientParticipationProcedure()
        {
            Guid muayeneKatılımPayıGuid = ProcedureDefinition.ExaminationParticipationProcedureObjectId;

            if (TTObjectClasses.SystemParameter.IsPatientExaminationParticipationControl)
            {
                List<AccountTransaction> participationTrxList = GetPatientParticipationProcedure();
                if (participationTrxList.Count == 0) // Katılım payı hizmeti yoksa oluşturulur
                {
                    foreach (PatientExamination pe in PatientExaminations)
                    {
                        if (pe.IsOldAction != true &&
                            pe.CurrentStateDefID != PatientExamination.States.Cancelled &&
                            pe.SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.Normal &&
                            pe.SubEpisode?.OpenSubEpisodeProtocol?.Payer?.GetPatientParticipation == true)
                        {
                            PatientExaminationProcedure examProc = new PatientExaminationProcedure(pe, muayeneKatılımPayıGuid.ToString());
                            examProc.AccountOperation(AccountOperationTimeEnum.PREPOST);
                            return examProc;
                        }
                    }

                    foreach (DentalExamination de in DentalExaminations)
                    {
                        if (de.IsOldAction != true &&
                            de.CurrentStateDefID != DentalExamination.States.Cancelled &&
                            de.SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.DisKabulu &&
                            de.SubEpisode?.OpenSubEpisodeProtocol?.Payer?.GetPatientParticipation == true)
                        {
                            DentalExaminationProcedure examProc = new DentalExaminationProcedure(de, muayeneKatılımPayıGuid.ToString());
                            examProc.AccountOperation(AccountOperationTimeEnum.PREPOST);
                            return examProc;
                        }
                    }
                }
            }

            return null;
        }

        /*
        public EpisodeProtocol AddDefaultPublicProtocolIfHasBulletin(bool closeOldEpisodeProtocols)
        {
            EpisodeProtocol newEP = null;

            Guid bulletinProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("DEFAULTBULLETINPROTOCOL", "af9fc8c0-3e55-434d-91e1-d758362fcba7"));

            EpisodeProtocol bulletinEP = null;
            foreach (EpisodeProtocol ep in this.EpisodeProtocols)
            {
                if (ep.Protocol.ObjectID.Equals(bulletinProtocolGuid) && ep.CurrentStateDefID == EpisodeProtocol.States.OPEN)
                {
                    bulletinEP = ep;

                    if(closeOldEpisodeProtocols) // Vakabaşı anlaşması kapatılacaksa içindeki Vakabaşı hizmeti de iptal edilir
                    {
                        IList myPAccountTransactions = ep.GetSubActionProcedureTransactions();
                        foreach (AccountTransaction at in myPAccountTransactions)
                        {
                            if (at.SubActionProcedure.ProcedureObject is BulletinProcedureDefinition)
                            {
                                at.SubActionProcedure.CancelMyAccountTransactions();
                                break;
                            }
                        }
                    }
                }
            }

            if(bulletinEP != null)
            {
                ProtocolDefinition myProtocol = null;
                Guid defaultProtocolGuid;
                //TODO daha sonra çalışma durumundan çekilebilir BB
                //                if (this.PatientAdmission is PA_MilitaryRetired || this.PatientAdmission is PA_MilitaryRetiredFamily || this.PatientAdmission is PA_RetiredCivilian)
                //                    defaultProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SGKRETIREDPROTOCOL", "b819e53b-07cd-43fb-937b-dd5a9b909da8"));
                //                else
                defaultProtocolGuid = new Guid(this.GetProperDefaultPublicProtocolObjectID());

                myProtocol = (ProtocolDefinition)this.ObjectContext.GetObject(defaultProtocolGuid,"ProtocolDefinition");

                // Vakabaşı anlaşması closeOldEpisodeProtocols parametresine göre kapatılır veya kapatılmaz
                newEP = this.AddEpisodeProtocol(bulletinEP.Payer, myProtocol, true, closeOldEpisodeProtocols);
            }

            return newEP;
        }


        public EpisodeProtocol AddDefaultPublicProtocolIfHasSameDayProtocol(bool closeOldEpisodeProtocols)
        {
            EpisodeProtocol newEP = null;

            Guid sameDayProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("DEFAULTSGKOUTPATIENTSAMEDAYPROTOCOL", "6514e4ec-5798-4a46-9ce3-5f6a92beaaf3"));

            EpisodeProtocol sameDayEP = null;
            foreach (EpisodeProtocol ep in this.EpisodeProtocols)
            {
                if (ep.Protocol.ObjectID.Equals(sameDayProtocolGuid) && ep.CurrentStateDefID == EpisodeProtocol.States.OPEN)
                {
                    sameDayEP = ep;
                    break;
                }
            }

            if(sameDayEP != null)
            {
                ProtocolDefinition myProtocol = null;
                Guid defaultProtocolGuid;
                //TODO daha sonra çalışma durumundan çekilebilir BB
                //                if (this.PatientAdmission is PA_MilitaryRetired || this.PatientAdmission is PA_MilitaryRetiredFamily || this.PatientAdmission is PA_RetiredCivilian)
                //                    defaultProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SGKRETIREDPROTOCOL", "b819e53b-07cd-43fb-937b-dd5a9b909da8"));
                //                else
                defaultProtocolGuid = new Guid(this.GetProperDefaultPublicProtocolObjectID());

                myProtocol = (ProtocolDefinition)this.ObjectContext.GetObject(defaultProtocolGuid,"ProtocolDefinition");

                // SGK Aynı Gün anlaşması closeOldEpisodeProtocols parametresine göre kapatılır veya kapatılmaz
                newEP = this.AddEpisodeProtocol(sameDayEP.Payer, myProtocol, true, closeOldEpisodeProtocols);
            }

            return newEP;
        }

        public EpisodeProtocol AddDefaultPublicProtocolIfHasGreenAreaProtocol(bool closeOldEpisodeProtocols)
        {
            EpisodeProtocol newEP = null;

            Guid greenAreaProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("DEFAULTGREENAREAEXAMINATIONPROTOCOL", "e8c0d3b7-5a56-45c8-98bd-d5ad04320f0c"));

            EpisodeProtocol greenAreaEP = null;
            foreach (EpisodeProtocol ep in this.EpisodeProtocols)
            {
                if (ep.Protocol.ObjectID.Equals(greenAreaProtocolGuid) && ep.CurrentStateDefID == EpisodeProtocol.States.OPEN)
                {
                    greenAreaEP = ep;
                    // Yeşilalan anlaşması kapatılmalı çünkü son eklenen anlaşma bu, kapatılmazsa aktif anlaşma olarak kalmaya devam eder
                    ep.CurrentStateDefID = EpisodeProtocol.States.CLOSED;
                    break;
                }
            }

            if(greenAreaEP != null)
            {
                ProtocolDefinition myProtocol = null;
                Guid defaultProtocolGuid;
                //TODO daha sonra çalışma durumundan çekilebilir BB
                //                if (this.PatientAdmission is PA_MilitaryRetired || this.PatientAdmission is PA_MilitaryRetiredFamily || this.PatientAdmission is PA_RetiredCivilian)
                //                    defaultProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SGKRETIREDPROTOCOL", "b819e53b-07cd-43fb-937b-dd5a9b909da8"));
                //                else
                defaultProtocolGuid = new Guid(this.GetProperDefaultPublicProtocolObjectID());

                myProtocol = (ProtocolDefinition)this.ObjectContext.GetObject(defaultProtocolGuid,"ProtocolDefinition");

                // Yeşil Alan anlaşması yukarıda kapatılıyor ama içindeki hizmet/malzemeler closeOldEpisodeProtocols parametresine
                // göre bu anlaşmanın içine aktarılır veya aktarılmaz
                newEP = this.AddEpisodeProtocol(greenAreaEP.Payer, myProtocol, true, closeOldEpisodeProtocols);
            }

            return newEP;


        // Yatış iptal edildiği zaman, yatırırken oluşturulan Kamu Kurum Anlaşmasını kapatır ve içindekileri VakaBaşına aktarır

        public void CloseDefaultPublicProtocolIfHasBulletin(SubEpisodeProtocol defaultSEP)
        {
            if (defaultSEP == null)
                return;

            SubEpisodeProtocol bulletinSEP = null;
            Guid bulletinProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("DEFAULTBULLETINPROTOCOL", "af9fc8c0-3e55-434d-91e1-d758362fcba7"));

            foreach (SubEpisode se in this.SubEpisodes)
            {
                foreach (SubEpisodeProtocol sep in se.SubEpisodeProtocols)
                {
                    if (sep.Protocol.ObjectID.Equals(bulletinProtocolGuid) && sep.CurrentStateDefID == SubEpisodeProtocol.States.Open)
                    {
                        bulletinSEP = sep;
                        break;
                    }
                }
            }

            if (bulletinSEP != null)
            {
                SubActionProcedure tempSubActP = null;
                SubActionMaterial tempSubActM = null;

                IList myPAccountTransactions = defaultSEP.GetSubActionProcedureTrxs();
                foreach (AccountTransaction at in myPAccountTransactions)
                {
                    if (tempSubActP != at.SubActionProcedure)
                        at.SubActionProcedure.ChangeMyProtocol(bulletinSEP);

                    tempSubActP = at.SubActionProcedure;
                }

                IList myMAccountTransactions = defaultSEP.GetSubActionMaterialTrxs();
                foreach (AccountTransaction at in myMAccountTransactions)
                {
                    if (tempSubActM != at.SubActionMaterial)
                        at.SubActionMaterial.ChangeMyProtocol(bulletinSEP);

                    tempSubActM = at.SubActionMaterial;
                }
            }

            defaultSEP.CurrentStateDefID = SubEpisodeProtocol.States.Closed;
        }

        // Yatış iptal edildiği zaman, yatırırken oluşturulan Kamu Kurum Anlaşmasını kapatır ve içindekileri SGK Aynı Gün Anlaşmasına aktarır
        public void CloseDefaultPublicProtocolIfHasSameDayProtocol(SubEpisodeProtocol defaultSEP)
        {
            if (defaultSEP == null)
                return;

            SubEpisodeProtocol sameDaySEP = null;
            Guid sameDayProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("DEFAULTSGKOUTPATIENTSAMEDAYPROTOCOL", "6514e4ec-5798-4a46-9ce3-5f6a92beaaf3"));

            foreach (SubEpisode se in this.SubEpisodes)
            {
                foreach (SubEpisodeProtocol sep in se.SubEpisodeProtocols)
                {
                    if (sep.Protocol.ObjectID.Equals(sameDayProtocolGuid) && sep.CurrentStateDefID == SubEpisodeProtocol.States.Open)
                    {
                        sameDaySEP = sep;
                        break;
                    }
                }
            }

            if (sameDaySEP != null)
            {
                SubActionProcedure tempSubActP = null;
                SubActionMaterial tempSubActM = null;

                IList myPAccountTransactions = defaultSEP.GetSubActionProcedureTrxs();
                foreach (AccountTransaction at in myPAccountTransactions)
                {
                    if (tempSubActP != at.SubActionProcedure)
                        at.SubActionProcedure.ChangeMyProtocol(sameDaySEP);

                    tempSubActP = at.SubActionProcedure;
                }

                IList myMAccountTransactions = defaultSEP.GetSubActionMaterialTrxs();
                foreach (AccountTransaction at in myMAccountTransactions)
                {
                    if (tempSubActM != at.SubActionMaterial)
                        at.SubActionMaterial.ChangeMyProtocol(sameDaySEP);

                    tempSubActM = at.SubActionMaterial;
                }
            }

            defaultSEP.CurrentStateDefID = SubEpisodeProtocol.States.Closed;
        }
        */

        public List<TTObjectClasses.SubEpisode> GetMyOpenedSubEpisodes()
        {

            List<TTObjectClasses.SubEpisode> subEpisodeList = new List<TTObjectClasses.SubEpisode>();
            foreach (TTObjectClasses.SubEpisode subEpisode in SubEpisodes)
            {
                if (subEpisode.CurrentStateDefID == SubEpisode.States.Opened)// Yanlızca Açık SubEpisodelar
                {
                    subEpisodeList.Add(subEpisode);
                }
            }

            return subEpisodeList;
        }

        public PatientGroupDefinition GetMyPatientGroupDefinition()
        {
            return null;// Common.PatientGroupDefinitionByEnum(this.ObjectContext, this.PatientGroup.Value);
        }

        public string GetProperDefaultPublicProtocolObjectID()
        {


            return TTObjectClasses.SystemParameter.GetParameterValue("SGKPROTOCOL", "15b57761-eea5-4f12-b66a-349d0c187c8e");
        }

        public bool HasAnyEpisodeHealthCommitteeOrHCExamination()
        {
            foreach (HealthCommittee hCommittee in HealthCommittees)
            {
                if (hCommittee.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                    return true;
            }

            BindingList<HealthCommitteeExamination> HCEList = HealthCommitteeExamination.GetHCEByEpisode(ObjectContext, ObjectID);
            foreach (HealthCommitteeExamination hCommitteeExamination in HCEList)
            {
                if (hCommitteeExamination.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                    return true;
            }

            BindingList<HealthCommitteeExaminationFromOtherHospitals> HCEOtherList = HealthCommitteeExaminationFromOtherHospitals.GetHCEFromOtherHospByEpisode(ObjectContext, ObjectID);
            foreach (HealthCommitteeExaminationFromOtherHospitals hCommitteeExaminationOther in HCEOtherList)
            {
                if (hCommitteeExaminationOther.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                    return true;
            }

            return false;
        }

        public HealthCommittee GetNotCollectedInvoicableHealthCommittee()
        {
            // XXXXXX Çalışan ve Aileleri için
            //TODO Atlas için kapatıldı BB
            /*if(this.PatientAdmission is PA_Officer || this.PatientAdmission is PA_GeneralAdmiral || this.PatientAdmission is PA_NoncommissionedOfficer || this.PatientAdmission is PA_OfficerFamily || this.PatientAdmission is PA_NoncommissionedOfficerFamily || this.PatientAdmission is PA_MilitaryCivilOfficialFamily || this.PatientAdmission is PA_ExpertNonComFamily || this.PatientAdmission is PA_GeneralAdmiralFamily || this.PatientAdmission is PA_ExpertGendarmeFamily || this.PatientAdmission is PA_MilitaryWorker || this.PatientAdmission is PA_MilitaryCivilOfficial || this.PatientAdmission is PA_ExpertNonCom || this.PatientAdmission is PA_ExpertGendarme || this.PatientAdmission is PA_Cadet)
            {
                foreach(HealthCommittee hCommittee in this.HealthCommittees)
                {
                    if(hCommittee.CurrentStateDefID != HealthCommittee.States.Cancelled && hCommittee.CurrentStateDefID != HealthCommittee.States.Rejected)
                    {
                        if(hCommittee.ReasonForExamination != null)
                        {
                            if(hCommittee.ReasonForExamination.NotCollectedInvoicable == true)
                                return hCommittee;
                        }
                    }
                }
            }*/
            return null;
        }

        // SubEpisode içindeki SubEpisodePatientStatus değeri Medula Tedavi Türü alanına çevriliyor
        public static TedaviTuru GetMedulaTedaviTuruByPatientStatus(SubEpisodeStatusEnum? patientStatus)
        {
            TedaviTuru tedaviTuru = null;
            if (patientStatus.HasValue)
            {
                if (patientStatus == SubEpisodeStatusEnum.Inpatient)
                    tedaviTuru = TedaviTuru.GetTedaviTuru("Y");
                else if (patientStatus == SubEpisodeStatusEnum.Outpatient)
                    tedaviTuru = TedaviTuru.GetTedaviTuru("A");
                else if (patientStatus == SubEpisodeStatusEnum.Daily)
                    tedaviTuru = TedaviTuru.GetTedaviTuru("G");
            }
            return tedaviTuru;
        }

        // Episode'un ilk SGK SubEpisodeProtocol ü bulunur
        public SubEpisodeProtocol GetFirstSGKSEP(bool hasMedulaTakipNo = true)
        {
            return AllSGKSubEpisodeProtocols().Where(x => !hasMedulaTakipNo || (hasMedulaTakipNo && !string.IsNullOrEmpty(x.MedulaTakipNo))).OrderBy(x => x.CreationDate).FirstOrDefault();
        }


        // Episode'un ilk SubEpisodeProtocol ü bulunur
        public SubEpisodeProtocol GetFirstSEP()
        {
            return AllSubEpisodeProtocols().OrderBy(x => x.CreationDate).FirstOrDefault();
        }

        public InPatientTreatmentClinicApplication GetFirstInpatientTreatmentClinicApp()
        {
            return InPatientTreatmentClinicApplications.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled && x.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully).OrderBy(x => x.ClinicInpatientDate).FirstOrDefault();
        }

        // Takip numaralarına göre Episode daki en son SubEpisodeProtocol ü döndürür
        public SubEpisodeProtocol GetLastSGKSEP()
        {
            List<SubEpisodeProtocol> SGKSEPsWithMedulaTakipNo = AllSGKSubEpisodeProtocols().Where(x => x.IsSGKAndActiveWithMedulaTakipNo).OrderBy(x => x.CreationDate).ToList();

            SubEpisodeProtocol retValue = SGKSEPsWithMedulaTakipNo.Where(x => x.ParentSEP == null).FirstOrDefault();

            // TODO Mustafa : Aşağıdaki kısım Sevkli Kabulü için SEP e eklenmesi gereken MedulaESevkNo propertysinden sonra açılmalı
            // Sevki kabullerde ilk SEP başka XXXXXXdeki takibe bağlı alınacak ama ParentSEP i null kalacak. 
            // Bu durumda bağlı alınan takip numarasını MedulaESevkNo gibi bir alanda tutmak lazım gibi.
            //if (retValue == null)
            //{
            //    foreach (SubEpisode se in SubEpisodes)
            //    {
            //        if (!string.IsNullOrEmpty(se.PatientAdmission.MedulaESevkNo))
            //        {
            //            retValue = SGKSEPsWithMedulaTakipNo.Where(x => x.MedulaESevkNo == se.PatientAdmission.MedulaESevkNo).FirstOrDefault();
            //            break;
            //        }
            //    }
            //}

            if (retValue == null)
                retValue = GetFirstSGKSEP();

            // ParentSEP lerden takiplerden 
            if (retValue != null)
            {
                for (int i = 0; i < SGKSEPsWithMedulaTakipNo.Count; i++)
                {
                    SubEpisodeProtocol sep = SGKSEPsWithMedulaTakipNo[i];
                    if (sep != retValue && sep.ParentSEP == retValue)
                    {
                        retValue = sep;
                        i = 0;
                    }
                }
            }

            return retValue;
        }

        public static List<string> GetMyMedulaDiagnosisDefinitionICDCodes(Episode episode)
        {
            List<string> retList = new List<string>();
            DiagnosisDefinition diagnosisDefinition = null;

            foreach (DiagnosisGrid diagnosisGrid in episode.Diagnosis)
            {
                diagnosisDefinition = diagnosisGrid.Diagnose;
                if (retList.Contains(diagnosisDefinition.Code) == false)
                    retList.Add(diagnosisDefinition.Code);
            }

            return retList;
        }

        public List<DiagnosisDefinition> GetMyMedulaDiagnosisDefinitions()
        {
            List<DiagnosisDefinition> retList = new List<DiagnosisDefinition>();
            foreach (DiagnosisGrid diagnosisGrid in Diagnosis)
            {
                if (retList.Contains(diagnosisGrid.Diagnose) == false)
                    retList.Add(diagnosisGrid.Diagnose);
            }

            return retList;
        }

        // Medula geçişinden sonra gerekli bazı state düzenlemelerini yapan metod
        // Şimdilik sadece 520030 Normal Poliklinik Muayenesi için çalışıyor, ileride eklemeler olabilir
        /*
        public void AdjustAccountTransactionsState()
        {
            // Sunucuya Gönderilmeyecek durumunda muayene hizmeti varsa, durumu Yeni yapılır
            Guid muayeneGuid = ProcedureDefinition.ExaminationProcedureObjectId;
            foreach (PatientExamination pExam in this.PatientExaminations)
            {
                if (pExam.CurrentStateDefID != PatientExamination.States.Cancelled)
                {
                    foreach (PatientExaminationProcedure pExamProc in pExam.PatientExaminationProcedures)
                    {
                        if (pExamProc.ProcedureObject.ObjectID.Equals(muayeneGuid))
                        {
                            foreach (AccountTransaction examAccTrx in pExamProc.AccountTransactions)
                            {
                                if (examAccTrx.CurrentStateDefID == AccountTransaction.States.MedulaDontSend)
                                    examAccTrx.CurrentStateDefID = AccountTransaction.States.New;
                            }
                        }
                    }
                }
            }
        }
        */

        public static bool HasAnyEpisodePhysiotherapyOrderWithoutRobotikRehabilitasyon(Episode episode)
        {
            foreach (PhysiotherapyRequest pRequest in episode.PhysiotherapyRequests)
            {
                if (pRequest.PhysiotherapyOrders != null && pRequest.CurrentStateDefID != PhysiotherapyRequest.States.Cancelled)
                {
                    foreach (PhysiotherapyOrder pOrder in pRequest.PhysiotherapyOrders)
                    {
                        //Robotik Rehabilitasyon
                        if (pOrder.ProcedureObject != null && pOrder.ProcedureObject.ID.Value != null && pOrder.ProcedureObject.ID.Value != 11084)
                            return true;
                    }
                }
                else
                    return false;
            }
            return false;
        }

        public static bool HasAnyEpisodeRobotikRehabilitasyon(Episode episode)
        {
            foreach (PhysiotherapyRequest pRequest in episode.PhysiotherapyRequests)
            {
                if (pRequest.PhysiotherapyOrders != null)
                {
                    foreach (PhysiotherapyOrder pOrder in pRequest.PhysiotherapyOrders)
                    {
                        //Robotik Rehabilitasyon
                        if (pOrder.ProcedureObject != null && pOrder.ProcedureObject.ID.Value != null && pOrder.ProcedureObject.ID.Value == 11084)
                            return true;
                    }
                }
            }
            return false;
        }

        public bool HasAnyCompanionApplicationWithSameDateInterval(DateTime startDate, DateTime endDate)
        {
            foreach (CompanionApplication compApp in CompanionApplications)
            {
                if (compApp.RequestDate != null && compApp.EndDate != null)
                {
                    if (compApp.RequestDate.Value.Date < endDate && compApp.EndDate.Value.Date >= endDate)
                        return true;
                    if (compApp.RequestDate.Value.Date <= startDate && compApp.EndDate.Value.Date > startDate)
                        return true;
                }
            }
            return false;
        }

        public CompanionApplication GetActiveCompanionApplication()
        {
            foreach (CompanionApplication compApp in CompanionApplications)
            {
                if ((compApp.RequestDate == null || compApp.RequestDate.Value.Date <= Common.RecTime().Date) && (compApp.EndDate == null || compApp.EndDate.Value.Date >= Common.RecTime().Date))
                    return compApp;
            }
            return null;
        }

        public DateTime? GetLatestClinicDischargeDate()
        {
            DateTime? maxClinicDischargeDate = null;
            foreach (InpatientAdmission inpatientAdmission in InpatientAdmissions)
            {
                foreach (InPatientTreatmentClinicApplication inPtntTrtmntClncApp in inpatientAdmission.InPatientTreatmentClinicApplications)
                {
                    if (inPtntTrtmntClncApp.ClinicDischargeDate.HasValue)
                    {
                        if (!maxClinicDischargeDate.HasValue)
                            maxClinicDischargeDate = inPtntTrtmntClncApp.ClinicDischargeDate.Value;
                        else if (inPtntTrtmntClncApp.ClinicDischargeDate.Value > maxClinicDischargeDate.Value)
                            maxClinicDischargeDate = inPtntTrtmntClncApp.ClinicDischargeDate.Value;
                    }
                }
            }

            return maxClinicDischargeDate;
        }

        public InpatientAdmission GetLastInpatientAdmission()
        {
            foreach (InpatientAdmission inpatientAdmission in InpatientAdmissions.OrderByDescending(dr => dr.HospitalInPatientDate))
            {
                if (inpatientAdmission.IsCancelled != true)
                    return inpatientAdmission;
            }
            return null;
        }

        public InpatientAdmission GetActiveInpatientAdmission()
        {
            foreach (InpatientAdmission inpatientAdmission in InpatientAdmissions.Where(dr => dr.IsCancelled != true && dr.CurrentStateDefID == InpatientAdmission.States.ClinicProcedure).OrderByDescending(dr => dr.HospitalInPatientDate))
            {
                return inpatientAdmission;
            }
            return null;
        }

        public string Triaj
        {
            get
            {
                foreach (EmergencyIntervention ei in EmergencyInterventions)
                {
                    if (ei.CurrentStateDefID != EmergencyIntervention.States.Cancelled && ei.Triage != null)
                    {
                        if (ei.Triage.KODU.Equals("1")) // Yeşil
                            return "Y";
                        else if (ei.Triage.KODU.Equals("2")) // Sarı
                            return "S";
                        else if (ei.Triage.KODU.Equals("3")) // Kırmızı
                            return "K";
                    }
                }
                //foreach (DentalExamination de in DentalExaminations)
                //{
                //    if (de.CurrentStateDefID != DentalExamination.States.Cancelled && de.TriajCode != null)
                //    {
                //        if (de.TriajCode == TriajCode.Red)
                //            return "K";
                //        else if (de.TriajCode == TriajCode.Yellow)
                //            return "S";
                //        else if (de.TriajCode == TriajCode.Green)
                //            return "Y";
                //    }
                //}
                return string.Empty;
            }
        }



        public ResUser GetPatientExaminationDoctor()
        {
            ResUser doctor = null;
            foreach (PatientExamination pa in PatientExaminations)
            {
                if (pa.ProcedureDoctor != null)
                {
                    if (pa.CurrentStateDefID != PatientExamination.States.Cancelled)
                        return pa.ProcedureDoctor;
                    else
                        doctor = pa.ProcedureDoctor;
                }
            }
            return doctor;
        }

        public void CancelPatientShareAccTrxs()
        {
            foreach (SubEpisode se in SubEpisodes)
            {
                foreach (SubEpisodeProtocol sep in se.SubEpisodeProtocols)
                {
                    sep.CancelPatientShareAccTrxs();
                }
            }
        }

        public List<SubEpisodeProtocol> AllSubEpisodeProtocols(bool onlyActive = true)
        {
            List<SubEpisodeProtocol> SEPList = new List<SubEpisodeProtocol>();
            foreach (SubEpisode se in SubEpisodes)
            {
                foreach (SubEpisodeProtocol sep in se.SubEpisodeProtocols)
                {
                    if (!onlyActive || (onlyActive && sep.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled))
                        SEPList.Add(sep);
                }
            }
            return SEPList;
        }

        public List<SubEpisodeProtocol> AllSubEpisodeProtocolsWithSamePayer(Guid payerObjectID, bool onlyActive = true)
        {
            List<SubEpisodeProtocol> SEPList = new List<SubEpisodeProtocol>();
            foreach (SubEpisode se in SubEpisodes)
            {
                foreach (SubEpisodeProtocol sep in se.SubEpisodeProtocols)
                {
                    if (sep.Payer.ObjectID == payerObjectID && (!onlyActive || (onlyActive && sep.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled)))
                        SEPList.Add(sep);
                }
            }
            return SEPList;
        }

        public List<SubEpisodeProtocol> AllSGKSubEpisodeProtocols(bool onlyActive = true)
        {
            List<SubEpisodeProtocol> SEPList = new List<SubEpisodeProtocol>();
            foreach (SubEpisodeProtocol sep in AllSubEpisodeProtocols(onlyActive))
            {
                if (sep.IsSGKAll)
                    SEPList.Add(sep);
            }
            return SEPList;

        }

        // Daha önce bağlı yatan diyaliz, hot, ftr takibi alınmış ise bir daha alma ve SubEpisode oluşturma
        public bool IsSGKSubEpisodeProtocolExists(String[] bransKodu, String[] tedaviTuru, String tedaviTipi)
        {
            foreach (SubEpisodeProtocol sep in AllSGKSubEpisodeProtocols())
            {
                if (!string.IsNullOrEmpty(sep.MedulaTakipNo))
                {
                    if (bransKodu.Contains(sep.Brans.Code) && tedaviTuru.Contains(sep.MedulaTedaviTuru.tedaviTuruKodu) && tedaviTipi.Equals(sep.MedulaTedaviTipi.tedaviTipiKodu))
                        return true;
                }
            }

            return false;
        }

        public SubEpisode LastSubEpisode
        {
            get
            {
                SubEpisode lastSubEpisode = SubEpisodes.Where(x => x.IsCancelled == false).OrderByDescending(x => x.OpeningDate).FirstOrDefault();
                return lastSubEpisode;
            }
        }

        //public bool IsInvoicedSEPExists
        //{
        //    get
        //    {
        //        if (SubEpisodes.Where(x => x.IsInvoicedSEPExists).Any())
        //            return true;

        //        return false;
        //    }
        //}

        public bool IsInvoicedCompletely
        {
            get
            {
                if (SubEpisodes.Where(x => !x.IsInvoicedCompletely).Any())
                    return false;

                return true;
            }
        }

        #endregion Methods

        public static Episode.InpatientInfoByEpisode getInpatientInfoByEpisode(Guid episode)
        {

            TTObjectContext context = new TTObjectContext(true);
            var treatmentClinicList = InPatientTreatmentClinicApplication.GetLastActiveInPatientTreatmentClinicApp(context, episode);
            foreach (var lastTreatmentClinic in treatmentClinicList)
            {
                if (lastTreatmentClinic.BaseInpatientAdmission != null)
                {
                    Episode.InpatientInfoByEpisode inpatientInfo = new Episode.InpatientInfoByEpisode();
                    if (lastTreatmentClinic.BaseInpatientAdmission.PhysicalStateClinic != null)
                        inpatientInfo.PhysicalStateClinic = lastTreatmentClinic.BaseInpatientAdmission.PhysicalStateClinic.Name;
                    if (lastTreatmentClinic.BaseInpatientAdmission.RoomGroup != null)
                        inpatientInfo.RoomGroup = lastTreatmentClinic.BaseInpatientAdmission.RoomGroup.Name;
                    if (lastTreatmentClinic.BaseInpatientAdmission.Room != null)
                        inpatientInfo.Room = lastTreatmentClinic.BaseInpatientAdmission.Room.Name;
                    if (lastTreatmentClinic.BaseInpatientAdmission.Bed != null)
                        inpatientInfo.Bed = lastTreatmentClinic.BaseInpatientAdmission.Bed.Name;
                    if (lastTreatmentClinic.BaseInpatientAdmission.ProcedureDoctor != null)
                        inpatientInfo.ProcedureDoctor = lastTreatmentClinic.BaseInpatientAdmission.ProcedureDoctor.Name;
                    return inpatientInfo;
                }

            }

            return null;

        }
        public class InpatientInfoByEpisode
        {
            public string PhysicalStateClinic;
            public string Bed;
            public string Room;
            public string RoomGroup;
            public string ProcedureDoctor;

        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Episode).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Episode.States.Open && toState == Episode.States.Closed)
                PostTransition_Open2Closed();
            else if (fromState == Episode.States.Open && toState == Episode.States.ClosedToNew)
                PostTransition_Open2ClosedToNew();
            else if (fromState == Episode.States.ClosedToNew && toState == Episode.States.Closed)
                PostTransition_ClosedToNew2Closed();
        }

        public PatientMedulaHastaKabul.ChildPatientMedulaHastaKabulCollection GetEpisodeMedulaHastaKabulleri()
        {
            return EpisodeMedulaHastaKabulleri;
        }

    }
}