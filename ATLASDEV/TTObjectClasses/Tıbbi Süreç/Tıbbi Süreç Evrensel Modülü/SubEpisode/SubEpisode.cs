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
    public partial class SubEpisode : TTObject
    {
        public partial class GetNotDiagnosisExistsByPatientGroup_Class : TTReportNqlObject
        {
        }

        public partial class GetSubEpisodeAccountTransaction_RQ_Class : TTReportNqlObject
        {
        }

        public partial class GetMaxProtocolNo_Class : TTReportNqlObject
        {
        }

        public partial class GetByDateAndPatientGroupAndDepartment_Class : TTReportNqlObject
        {
        }

        public partial class GetSubEpisodeExceptCancelled_Class : TTReportNqlObject
        {
        }

        public partial class VEM_HASTA_BASVURU_Class : TTReportNqlObject
        {
        }

        /// <summary>
        /// Alt vakanın tanısı olup olmadığını döndürür
        /// </summary>
        public bool? HasDiagnosis
        {
            get
            {
                try
                {
                    #region HasDiagnosis_GetScript                    
                    BindingList<DiagnosisGrid> list = DiagnosisGrid.GetDiagnosisBySubEpisode_OQ(ObjectContext, ObjectID.ToString());
                    if (list.Count > 0)
                        return true;
                    return false;
                    #endregion HasDiagnosis_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "HasDiagnosis") + " : " + ex.Message, ex);
                }
            }
        }


        protected List<DiagnosisGrid> _Diagnosis = null;
        public List<DiagnosisGrid> Diagnosis
        {
            get
            {
                if (_Diagnosis == null)
                    _Diagnosis = new List<DiagnosisGrid>();
                foreach (var diagnosisSubEpisode in DiagnosisSubEpisodes)
                {
                    if (!(_Diagnosis.Any(dr => dr.DiagnoseCode == diagnosisSubEpisode.DiagnosisGrid.DiagnoseCode)))
                        _Diagnosis.Add(diagnosisSubEpisode.DiagnosisGrid);
                }
                return _Diagnosis;
            }
        }

        public string GetDiagnosisAsStringForWorkList()
        {
            var diagnosisString = string.Empty;
            if (SystemParameter.GetParameterValue("GETDIAGNOSISFORWORKLIST", "FALSE") == "TRUE")
                diagnosisString = GetDiagnosisAsString();
            return diagnosisString;
        }

        public string GetDiagnosisAsString()
        {
            var diagnosisString = string.Empty;
            BindingList<DiagnosisGrid.getDiagnosisJustBySubepisode_Class> diagnosisList = DiagnosisGrid.getDiagnosisJustBySubepisode(ObjectID.ToString());
            foreach (var diagnosisSubEpisode in diagnosisList)
            {
                diagnosisString += (String.IsNullOrEmpty(diagnosisString) ? "" : ",") + diagnosisSubEpisode.Icd10_kodu + "-" + diagnosisSubEpisode.Idc10_deger;
            }
            return diagnosisString;
        }

        //public BindingList<DiagnosisGrid> Diagnosis
        //{
        //    get
        //    {
        //        BindingList<DiagnosisGrid> list = DiagnosisGrid.GetDiagnosisBySubEpisode_OQ(this.ObjectContext, this.ObjectID.ToString());
        //        return list;
        //    }
        //}

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
            if (SubEpisodeProtocols == null || (SubEpisodeProtocols != null && SubEpisodeProtocols.Count == 0))
                throw new TTException("Alt Vakanın en az bir tane takibi olmalıdır.");

            if (Sent101Package == true && PatientAdmission.IsOldAction != true)
                new SendToENabiz(ObjectContext, this, ObjectID, ObjectDef.Name, "101", Common.RecTime());

            for (int i = 0; i < SubActionProcedures.Count; i++)
            {
                if (SubActionProcedures[i].SendToENabiz(true))
                    new SendToENabiz(ObjectContext, this, SubActionProcedures[i].ObjectID, SubActionProcedures[i].ObjectDef.Name, "102", Common.RecTime());
            }
            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            if (SubEpisodeProtocols == null || (SubEpisodeProtocols != null && SubEpisodeProtocols.Count == 0))
                throw new TTException("Alt Vakanın en az bir tane takibi olmalıdır.");

            if (Sent101Package == true)
            {
                if ((!IsCancelled && (HasMemberChanged("ResSection") || HasMemberChanged("PatientStatus"))) || (StarterEpisodeAction != null && !StarterEpisodeAction.IsCancelled && StarterEpisodeAction.HasMemberChanged("ProcedureDoctor")) || (!PatientAdmission.IsCancelled && PatientAdmission.HasMemberChanged("SKRSVakaTuru")))
                    new SendToENabiz(ObjectContext, this, ObjectID, ObjectDef.Name, "101", Common.RecTime());
            }
            #endregion PostUpdate
        }

        #region Methods
        public SubEpisode(TTObjectContext objectContext, SubEpisode oldSubEpisode) : this(objectContext)
        {
            OldSubEpisode = oldSubEpisode;
        }

        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew)
            {
                if (OpeningDate == null)
                    OpeningDate = Common.RecTime();
                CurrentStateDefID = SubEpisode.States.Opened;
                //TODO: (NE) NebulaClient Da Save edilirken de OnConstruct a girdiği için burayı null yapacak client da doldurulsa bile 
                //o yüzden kapatıldı. Sıkıntı olursa değerlendirilecek
                // this.ClosingDate = null;
            }
        }

        public ISubEpisodeStarter Starter
        {
            get
            {
                if (StarterEpisodeAction != null)
                    return (ISubEpisodeStarter)StarterEpisodeAction;
                else if (StarterSubActionProcedure != null)
                    return (ISubEpisodeStarter)StarterSubActionProcedure;
                return null;
            }

            set
            {
                if (value is EpisodeAction)
                    StarterEpisodeAction = (EpisodeAction)value;
                else if (value is SubActionProcedure)
                    StarterSubActionProcedure = (SubActionProcedure)value;
            }
        }

        public SubEpisode ArrangeMeOrCreateNewSubEpisode(ICreateSubEpisode SubEpisodeCreaterObject, bool closeOtherSubEpisodes, bool getNewMedulaProvision)
        {
            bool isDailyOperation = false;
            Boolean createSubEpisode = true;
            SubEpisode newSubEpisode = null;
            ISubEpisodeStarter starter = SubEpisodeCreaterObject.GetSubEpisodeStarter();
            // hasta kabul düzeltmede CreateSubEpisode false gelir yeni subepisode açılmaz

            if (starter != null && starter.GetCurrentStateDef().Status == StateStatusEnum.Cancelled) // Cancel Objelerde Property Set edilebildiğinde silisin
                createSubEpisode = false;
            else if (starter != null && starter.GetSubEpisode() != null && starter.GetSubEpisode().CurrentStateDefID != SubEpisode.States.Cancelled && starter.GetSubEpisode().Starter != null && starter.GetSubEpisode().Starter.GetObjectID() == starter.GetObjectID())
                createSubEpisode = false; // işlem geri alındı ve ilerletiliyorsa ve daha önce SubEpisodeu atandıysa tekrar atanmaması için
            else
                createSubEpisode = SubEpisodeCreaterObject.IsNewSubEpisodeNeeded();
            if (createSubEpisode)
            {
                // Set edilme sıraları önemli
                SubEpisode subEpisode = null;
                if (SubEpisodeCreaterObject.GetSubEpisodeCreatedByMe() == null) // PatientAdmissionda bu dolu gelir diğerlerinde boş
                {
                    subEpisode = new SubEpisode(ObjectContext, this); // OldSubEpisode olarak kendini yollar
                    if (starter != null)
                        subEpisode.OpeningDate = starter.SubEpisodeOpeningDate();
                    else
                        subEpisode.OpeningDate = SubEpisodeCreaterObject.SubEpisodeOpeningDate();

                    newSubEpisode = subEpisode;
                    newSubEpisode.OldSubEpisode = this;
                }
                else
                    subEpisode = SubEpisodeCreaterObject.GetSubEpisodeCreatedByMe(); // Created SubEpisode'un dolu olma durumu yanlızca Hasta kabulde Episode Create edilirken mümkün o durmdada OlsSubEpisode olmamalı
                if (closeOtherSubEpisodes == true) // Aynı episodedaki diğer SubEpisodları kapatır.
                {
                    foreach (SubEpisode subOldEpisode in SubEpisodeCreaterObject.GetEpisode().SubEpisodes)
                    {
                        if (subEpisode.ObjectID != subOldEpisode.ObjectID) // Hasta Kabulde Yaratılmış ve SubEpisodeCreatedByMe olarak gelen Episode Kapatılmasın diye
                        {
                            if (subOldEpisode.CurrentStateDefID == SubEpisode.States.Opened)
                            {
                                if (subOldEpisode.StarterEpisodeAction != null)
                                    subOldEpisode.Close(subOldEpisode.StarterEpisodeAction.SubEpisodeClosingDate());
                                else
                                    subOldEpisode.Close(Common.RecTime());
                            }
                        }
                    }
                }

                subEpisode.Episode = SubEpisodeCreaterObject.GetEpisode();
                subEpisode.PatientStatus = SubEpisodeCreaterObject.GetSubEpisodePatientStatus();
                subEpisode.ResSection = SubEpisodeCreaterObject.GetSubEpisodeResSection();
                subEpisode.Speciality = SubEpisodeCreaterObject.GetSubEpisodeSpeciality();
                subEpisode.Starter = starter;
                subEpisode.Sent101Package = SubEpisodeCreaterObject.Sent101Package();
                subEpisode.GetAndSetNextProtocolNo();
                if (SubEpisodeCreaterObject is InPatientTreatmentClinicApplication)
                {
                    subEpisode.InpatientStatus = InpatientStatusEnum.Inpatient;
                    subEpisode.InpatientAdmission = (InpatientAdmission)((InPatientTreatmentClinicApplication)SubEpisodeCreaterObject).BaseInpatientAdmission;
                    if (((InPatientTreatmentClinicApplication)SubEpisodeCreaterObject).IsDailyOperation.HasValue && ((InPatientTreatmentClinicApplication)SubEpisodeCreaterObject).IsDailyOperation == true)
                    {
                        isDailyOperation = true;
                    }
                }

                if (subEpisode.PatientAdmission == null)
                    subEpisode.PatientAdmission = subEpisode.Episode.PatientAdmissions.Where(x => x.CurrentStateDefID != PatientAdmission.States.Cancelled).OrderByDescending(x => x.ActionDate).FirstOrDefault();

                if (subEpisode.PatientStatus == SubEpisodeStatusEnum.Daily)
                {
                    subEpisode.PatientAdmission.AdmissionStatus = AdmissionStatusEnum.Gunubirlik;
                }

                // Yeni SubEpisode oluşturulmuşsa SubEpisodeProtocol oluşturulur
                if (newSubEpisode != null)
                {
                    SubEpisodeProtocol newSEP = null;
                    SubEpisodeProtocol lastSEP = LastSubEpisodeProtocol;
                    if (lastSEP == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27245", "Yeni takibin bağlanacağı bir takip bulunamadı. Kontrol ediniz."));

                    //<tanıları yeniSubepisodea taşımaca. Kontrol Muaynesinde Kopyalanmasını isterlerse bu kod newSubEpisode != null kodunun dışına taşınmalı ama o durumda birden fazla çalıştırılırsa diye extra bir kontrol olmalı  subEpisode.DiagnosisSubEpisodes.Count == 0 sa  oluştursun gibi
                    SubEpisode subEpisodeToCopy = null;
                    if (isDailyOperation)
                    {
                        subEpisodeToCopy = newSubEpisode.OldSubEpisode;
                    }

                    else
                    {
                        if (SubEpisodeCreaterObject.GetDiagnosisCopyEnum() == DiagnosisCopyEnum.CopyFromLastSubEpisode)
                        {
                            subEpisodeToCopy = newSubEpisode.OldSubEpisode;
                        }
                        else if (SubEpisodeCreaterObject.GetDiagnosisCopyEnum() == DiagnosisCopyEnum.CopyFromLastSubEpisodeWithSameSpeciality)
                        {
                            subEpisodeToCopy = newSubEpisode.Episode.SubEpisodes.OrderByDescending(dr => dr.OpeningDate).FirstOrDefault(dr => (dr.Speciality == subEpisode.Speciality || dr.ResSection.Brans == subEpisode.Speciality) && dr.ObjectID != subEpisode.ObjectID);
                            if (subEpisodeToCopy == null)
                            {
                                // var firstsubEpisode = newSubEpisode.Episode.SubEpisodes.OrderBy(dr => dr.OpeningDate).FirstOrDefault();
                                if (newSubEpisode.OldSubEpisode != null && newSubEpisode.OldSubEpisode.StarterEpisodeAction is EmergencyIntervention)
                                    subEpisodeToCopy = newSubEpisode.OldSubEpisode;
                            }
                        }
                    }
                    if (subEpisodeToCopy != null)
                    {
                        foreach (var diagnosisSubEpisode in subEpisodeToCopy.DiagnosisSubEpisodes)
                        {
                            DiagnosisSubEpisode newDiagnosisSubEpisode = diagnosisSubEpisode.Clone() as DiagnosisSubEpisode;
                            newDiagnosisSubEpisode.SubEpisode = subEpisode;
                        }
                    }
                    // tanıları yeniSubepisodea taşımaca>


                    //SubEpisodeProtocol.SEPProperty SEPProperty = new SubEpisodeProtocol.SEPProperty();
                    //SEPProperty.parentSEP = lastSEP;
                    //SEPProperty.subEpisode = newSubEpisode;
                    //SEPProperty.tedaviTuru = Episode.GetMedulaTedaviTuruByPatientStatus(newSEP.SubEpisode.PatientStatus);
                    //SEPProperty.brans = newSEP.SubEpisode.Speciality;

                    newSEP = lastSEP.CloneForNewSEP(SEPCloneTypeEnum.NewSubEpisode);
                    newSEP.ParentSEP = lastSEP;
                    newSEP.SubEpisode = newSubEpisode;
                    newSEP.Brans = newSEP.SubEpisode.Speciality;
                    newSEP.MedulaTedaviTuru = Episode.GetMedulaTedaviTuruByPatientStatus(newSEP.SubEpisode.PatientStatus);

                    if (subEpisode.ResSection != null && subEpisode.ResSection.TedaviTipi != null)  // ResSection da tanımlı Tedavi Tipi varsa SEP e set edilir
                        newSEP.MedulaTedaviTipi = subEpisode.ResSection.TedaviTipi;

                    if (subEpisode.ResSection != null && subEpisode.ResSection.TakipTipi != null) // ResSection da tanımlı Takip Tipi varsa SEP e set edilir
                        newSEP.MedulaTakipTipi = subEpisode.ResSection.TakipTipi;
                    else
                        newSEP.MedulaTakipTipi = TakipTipi.GetTakipTipi("N");

                    SubEpisodeCreaterObject.FillLocalSEPProperties(ref newSEP);

                    if (getNewMedulaProvision)
                    {
                        if (newSEP.Brans == null)
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27242", "Yeni oluşturulan takibin branşı boş olmamalıdır."));
                        if (newSEP.MedulaTedaviTuru.tedaviTuruKodu.Equals("Y") && newSEP.ParentSEP == null)
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27244", "Yeni oluşturulan yatan takip herhangi bir takibe bağlanamadı."));
                        if (newSEP.ParentSEP == newSEP)
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27243", "Yeni oluşturulan takip kendisine bağlanamaz."));
                        if (newSEP.ParentSEP.IsInvoiced)
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25664", "Faturalandırılmış durumdaki takibe bağlı takip alınamaz!"));

                        if (newSEP.IsSGK)
                        {
                            try
                            {
                                newSEP.GetProvisionFromMedula();
                            }
                            catch (Exception ex)
                            {
                                if (SystemParameter.GetParameterValue("IGNOREMEDULAERRORFORNEWSUBEPISODE", "FALSE").ToUpper() == "TRUE")
                                    InfoMessageService.Instance.ShowMessage(ex.Message);
                                else
                                    throw ex;
                            }
                        }
                    }
                    //this.Episode.MainSpeciality = subEpisode.Speciality;// artık Yeni SubEpisode MainSpeciality değerini değiştirmiyor
                }

                foreach (EpisodeAction ea in SubEpisodeCreaterObject.GetLinkedEpisodeActionsForSubEpisode()) // Başlatan işlem tarafından başlayan tüm işlemleri için (PatientAdmisin yada episode action olabilir Örn: Yatan hasta sub episode oluştururuken doktor işlemleri , hemşire hemşire işlemleri ginbi kendi başlattığı işlerin) de sub episodu set edilir
                {
                    if (ea.CurrentStateDef.Status != StateStatusEnum.Cancelled) // Cancel Objelerde Property Set edilebildiğinde silisin
                        ea.SubEpisode = subEpisode;
                }

                if (starter != null) // Başlatan işlemin ve SubActionlarının SubEpisode'unu set eder
                    starter.SetSubEpisode(subEpisode);
            }

            return newSubEpisode;
        }

        public string GetAndSetNextProtocolNo()
        {
            return GetAndSetNextProtocolNo(Episode);
        }

        public string GetAndSetNextProtocolNo(Episode episode)
        {
            if (ProtocolNo == null)
            {
                if (episode == null)
                    return TTUtils.CultureService.GetText("M25904", "Hatalı Protokol");
                string protokolNo = episode.ID.ToString();
                int maxint = episode.SubEpisodes.Count;
                if (maxint > 1) // ilk subepisode için  direk episodeId yi alır. Sonrası episodeId-1 episodeId-2 diye artar 
                    protokolNo = protokolNo + "-" + (maxint - 1).ToString();
                ProtocolNo = protokolNo;
            }

            return ProtocolNo;
        }

        public void Close(DateTime? closingDate)
        {
            CurrentStateDefID = SubEpisode.States.Closed;
            ClosingDate = closingDate;
        }

        //Asagıdakı  method EpısodeActıonForm clasına clıentmethod olarak tasındı.
        public void CancelSubEpisodeProtocols(SubEpisodeProtocol newSEP = null, bool userInteraction = false)
        {
            foreach (SubEpisodeProtocol sep in SubEpisodeProtocols.Where(x => x != newSEP && x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled))
            {
                sep.Cancel(newSEP, userInteraction);
            }
        }

        public SubEpisode PrepareSubEpisodeForRemoteMethod(bool withNewObjectID)
        {
            if (withNewObjectID)
            {
                SubEpisode sendingSubEpisode = (SubEpisode)Clone();
                sendingSubEpisode.Episode = null;
                sendingSubEpisode.OldSubEpisode = null;
                sendingSubEpisode.ResSection = null;
                sendingSubEpisode.Starter = null;
                return sendingSubEpisode;
            }
            else
                return this;
        }

        public string GetPatientStatusForENabiz()
        {

            var DailyAdmission = SubEpisodeProtocols.Where(t => t.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && t.MedulaTedaviTuru.tedaviTuruKodu == "G").Any();
            if (DailyAdmission == true)
                return "1";
            else
                return "0";

        }

        public SubEpisodeProtocol OpenSubEpisodeProtocol
        {
            get
            {
                return SubEpisodeProtocols.Where(x => x.CurrentStateDefID == SubEpisodeProtocol.States.Open && x.CloneType != SEPCloneTypeEnum.PatientInvoice).OrderByDescending(x => x.CreationDate).FirstOrDefault();
            }
        }

        public SubEpisodeProtocol FirstSubEpisodeProtocol
        {
            get
            {
                return SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled).OrderBy(x => x.CreationDate).FirstOrDefault();
            }
        }

        public SubEpisodeProtocol LastActiveSubEpisodeProtocol
        {
            get
            {
                return SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled).OrderByDescending(x => x.CreationDate).FirstOrDefault();
            }
        }
        public SubEpisodeProtocol LastActiveSubEpisodeProtocolByCloneType
        {
            get
            {
                return SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && x.CloneType != SEPCloneTypeEnum.PatientInvoice).OrderByDescending(x => x.CreationDate).FirstOrDefault();
            }
        }

        public SubEpisodeProtocol LastSubEpisodeProtocol
        {
            get
            {
                SubEpisodeProtocol sep = LastActiveSubEpisodeProtocol;
                if (sep == null)
                    sep = SubEpisodeProtocols.OrderByDescending(x => x.CreationDate).FirstOrDefault();
                return sep;
            }
        }
        public SubEpisodeProtocol SGKSEPWithProvisionNo
        {
            get
            {
                return SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && x.IsSGK == true && !String.IsNullOrEmpty(x.MedulaTakipNo)).OrderByDescending(x => x.CreationDate).FirstOrDefault();
            }
        }


        public SubEpisodeProtocol SGKSEP
        {
            get
            {
                return SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && x.IsSGK == true).OrderByDescending(x => x.CreationDate).FirstOrDefault();
            }
        }

        public List<SubEpisodeProtocol> SGKSEPs
        {
            get
            {
                return SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && x.IsSGK == true).ToList();
            }
        }

        public static SubEpisodeProtocol GetOpenSubEpisodeProtocol(SubEpisode subEpisode)
        {
            return subEpisode.OpenSubEpisodeProtocol;
        }

        // Episode.IsMedulaEpisode() yerine kullanılması ve artık "SGK lı mı?" kontrolünün Episode dan değil SubEpisode dan yapılması için bu metod yazıldı. (MDZ)
        public bool IsSGK
        {
            get
            {
                //if (SystemParameter.GetParameterValue("MEDULA", "TRUE").ToUpper() == "FALSE")
                //    return false;

                if (PatientAdmission != null)
                    return PatientAdmission.IsSGKPatientAdmission;

                return LastSubEpisodeProtocol.IsSGK;
            }
        }

        public static bool IsSGKSubEpisode(SubEpisode subEpisode)
        {
            return subEpisode.IsSGK;
        }

        //public bool IsInvoicedSEPExists
        //{
        //    get
        //    {
        //        if (SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && x.CloneType != SEPCloneTypeEnum.PatientInvoice && x.IsInvoiced).Any())
        //            return true;

        //        return false;
        //    }
        //}

        public bool IsInvoicedCompletely
        {
            get
            {
                // Tüm SEP ler İptal durumundaysa false döndürülür
                if (SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled).Any() == false)
                    return false;

                // İptal durumunda olmayan, hasta faturası için klonlanmamış ve faturalanmamış durumda SEP i varsa false döndürülür
                if (SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && x.CloneType != SEPCloneTypeEnum.PatientInvoice && !x.IsInvoiced).Any())
                    return false;

                return true;
            }
        }

        public bool HasPaidPayerTypeSEPExists
        {
            get
            {
                if (SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && x.Payer.Type.PayerType == PayerTypeEnum.Paid).Count() > 0)
                    return true;

                return false;
            }
        }

        //public SubEpisodeProtocol AddSubEpisodeProtocol(SubEpisodeProtocol parentSEP, bool checkPaid, bool closeOldSEP, bool useOldSubEpisodeInfo)
        //{
        //    PayerDefinition payer = null;
        //    ProtocolDefinition protocol = null;
        //    SubEpisode subEpisode = this;
        //    if (useOldSubEpisodeInfo && OldSubEpisode != null)
        //        subEpisode = OldSubEpisode;
        //    if (subEpisode.LastSubEpisodeProtocol != null)
        //    {
        //        payer = subEpisode.LastSubEpisodeProtocol.Payer;
        //        protocol = subEpisode.LastSubEpisodeProtocol.Protocol;
        //    }
        //    return AddSubEpisodeProtocol(parentSEP, payer, protocol, checkPaid, closeOldSEP);
        //}
        public SubEpisodeProtocol AddSubEpisodeProtocol(SubEpisodeProtocol.SEPProperty SEPProperty = null)
        {
            SubEpisodeProtocol newSEP = new SubEpisodeProtocol(ObjectContext);
            newSEP.CreationDate = SEPProperty != null ? (SEPProperty.takipTarihi == null ? Common.RecTime() : SEPProperty.takipTarihi) : Common.RecTime();
            newSEP.MedulaProvizyonTarihi = SEPProperty != null ? (SEPProperty.takipTarihi == null ? Common.RecTime() : SEPProperty.takipTarihi) : Common.RecTime();
            newSEP.CurrentStateDefID = SubEpisodeProtocol.States.Open;
            newSEP.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProvisionNoNotExists;
            newSEP.Payer = SEPProperty != null ? SEPProperty.payer : null;
            newSEP.Protocol = SEPProperty != null ? SEPProperty.protocol : null;
            newSEP.Brans = SEPProperty != null ? SEPProperty.brans : null;
            newSEP.CheckPaid = SEPProperty != null ? SEPProperty.checkPaid : true;
            newSEP.MedulaTedaviTuru = (SEPProperty != null && SEPProperty.tedaviTuru != null) ? SEPProperty.tedaviTuru : TedaviTuru.GetTedaviTuru("A");
            newSEP.MedulaTedaviTipi = (SEPProperty != null && SEPProperty.tedaviTipi != null) ? SEPProperty.tedaviTipi : TedaviTipi.GetTedaviTipi("0");
            newSEP.MedulaTakipTipi = (SEPProperty != null && SEPProperty.takipTipi != null) ? SEPProperty.takipTipi : TakipTipi.GetTakipTipi("N");
            newSEP.MedulaProvizyonTipi = (SEPProperty != null && SEPProperty.provizyonTipi != null) ? SEPProperty.provizyonTipi : ProvizyonTipi.GetProvizyonTipi("N");
            if (SEPProperty != null)
            {
                newSEP.MedulaBasvuruNo = SEPProperty.medulaBasvuruNo;
                newSEP.MedulaTakipNo = SEPProperty.medulaTakipNo;
            }
            newSEP.SubEpisode = this;
            if (newSEP.SEPMaster == null)
                newSEP.SetSEPMaster();
            if (SEPProperty != null && SEPProperty.cancelOldSEP)
                CancelSubEpisodeProtocols(newSEP);
            return newSEP;
        }

        public static string MyAddress(SubEpisode subEpisode)
        {
            if (Common.IsPropertyExist(subEpisode.PatientAdmission, "HomeAddress"))
            {
                string property = Convert.ToString(Common.PropertyValue(subEpisode.PatientAdmission, "HomeAddress"));
                if (property != null)
                {
                    return property;
                }
            }

            return null;
        }

        public static string MyDocumentNumber(SubEpisode subEpisode)
        {
            if (Common.IsPropertyExist(subEpisode.PatientAdmission, "DocumentNumber"))
            {
                string property = Convert.ToString(Common.PropertyValue(subEpisode.PatientAdmission, "DocumentNumber"));
                if (property != null)
                {
                    return property;
                }
            }

            if (subEpisode.Episode.DocumentNumber != null)
                return subEpisode.Episode.DocumentNumber;
            return null;
        }

        [TTStorageManager.Attributes.TTRequiredRoles()]
        public static DateTime? MyDocumentDate(SubEpisode subEpisode)
        {
            if (Common.IsPropertyExist(subEpisode.PatientAdmission, "DocumentDate"))
            {
                DateTime? property = Common.PropertyValue(subEpisode.PatientAdmission, "DocumentDate") as DateTime?;
                if (property != null)
                {
                    return property;
                }
            }

            if (subEpisode.Episode.DocumentDate != null)
                return subEpisode.Episode.DocumentDate;
            return null;
        }

        public bool IsOpenedInTenDays()
        {
            if (Episode.PatientStatus == PatientStatusEnum.Outpatient)
            {
                if (PatientAdmission.IsSGKPatientAdmission && PatientAdmission.IsIgnoredTenDaysRule(PatientAdmission.AdmissionType) == false)
                {
                    int limit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("SGKSPECIALITYCONTROLDAYLIMIT", "10"));
                    DateTime dateLimit = Convert.ToDateTime(Common.RecTime()).AddDays(-1 * (limit)).Date;
                    if (OpeningDate.Value.Date <= dateLimit)
                        return false;
                }
            }

            return true;
        }

        public void CreateMyInPatientRtfBySpeciality(EpisodeAction episodeAction)
        {
            if (InPatientRtfBySpecialities.Count == 0)
            {
                if (Speciality != null)
                {
                    var rTFDefinitionsBySpecialityList = RTFDefinitionsBySpeciality.GetBySpeciality(ObjectContext, Speciality.ObjectID);
                    foreach (var rTFDefinitionsBySpeciality in rTFDefinitionsBySpecialityList)
                    {
                        InPatientRtfBySpeciality inPatientRtfBySpeciality = new InPatientRtfBySpeciality(ObjectContext);
                        inPatientRtfBySpeciality.SubEpisode = this;
                        inPatientRtfBySpeciality.EpisodeAction = episodeAction;
                        inPatientRtfBySpeciality.Title = rTFDefinitionsBySpeciality.Title;
                        inPatientRtfBySpeciality.RTFDefinitionsBySpeciality = rTFDefinitionsBySpeciality;
                    }
                }
            }
        }

        public InPatientTreatmentClinicApplication GetStarterInPatientTreatmentClinicApplication()
        {
            if (StarterEpisodeAction is InPatientTreatmentClinicApplication)
                return (InPatientTreatmentClinicApplication)StarterEpisodeAction;
            return null;
        }

        public Guid AddNewPayer(Guid payer, Guid protocol)
        {
            SubEpisodeProtocol lastSEP = LastSubEpisodeProtocol;
            PayerDefinition payerObj = ObjectContext.GetObject(payer, typeof(PayerDefinition)) as PayerDefinition;
            ProtocolDefinition protocolObj = ObjectContext.GetObject(protocol, typeof(ProtocolDefinition)) as ProtocolDefinition;
            SubEpisodeProtocol.SEPProperty SEPProperty = new SubEpisodeProtocol.SEPProperty();
            SEPProperty.payer = payerObj;
            SEPProperty.protocol = protocolObj;
            SEPProperty.cancelOldSEP = false;
            SubEpisodeProtocol cloneSEP = lastSEP.CloneForNewSEP(SEPCloneTypeEnum.InvoiceScreenAddPayer, SEPProperty);
            return cloneSEP.ObjectID;
        }

        public ResUser GetSubEpisodeProcedureDoctor()
        {
            if (StarterEpisodeAction != null)
            {
                if (StarterEpisodeAction.ProcedureDoctor != null)
                    return StarterEpisodeAction.ProcedureDoctor;
            }
            if (StarterSubActionProcedure != null)
            {
                if (StarterSubActionProcedure.EpisodeAction != null && StarterSubActionProcedure.EpisodeAction.ProcedureDoctor != null)
                    return StarterSubActionProcedure.EpisodeAction.ProcedureDoctor;
            }
            return null;
        }

        public bool IsPreDiagnosisExists()
        {
            foreach (var diagnosisSubEpisode in DiagnosisSubEpisodes)
            {
                if (diagnosisSubEpisode.DiagnosisGrid.DiagnosisType == DiagnosisTypeEnum.Primer)
                    return true;
            }
            return false;
        }
        public bool IsSecDiagnosisExists()
        {
            foreach (var diagnosisSubEpisode in DiagnosisSubEpisodes)
            {
                if (diagnosisSubEpisode.DiagnosisGrid.DiagnosisType == DiagnosisTypeEnum.Seconder)
                    return true;
            }
            return false;
        }
        public bool IsDiagnosisExists()
        {
            foreach (var diagnosisSubEpisode in DiagnosisSubEpisodes)
            {
                return true;
            }
            return false;
        }

        public void Cancel()
        {
            if (PatientAdmission.IsOldAction != true)
                new SendToENabiz(ObjectContext, this, ObjectID, ObjectDef.Name, "301", Common.RecTime());
        }


        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SubEpisode).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;


            if (fromState == SubEpisode.States.Opened && toState == SubEpisode.States.Cancelled)
                PostTransition_Opened2Cancelled();
            else if (fromState == SubEpisode.States.Closed && toState == SubEpisode.States.Cancelled)
                PostTransition_Closed2Cancelled();

        }

        public void PostTransition_Opened2Cancelled()
        {
            Cancel();
        }

        public void PostTransition_Closed2Cancelled()
        {
            Cancel();
        }


        public bool HasAirborneContactIsolation
        {
            get
            {
                if (InpatientAdmission != null)
                    if (InpatientAdmission.CurrentStateDefID == InpatientAdmission.States.ClinicProcedure)
                        if (InpatientAdmission.HasAirborneContactIsolation.HasValue && InpatientAdmission.HasAirborneContactIsolation.Value == true)
                            return true;
                return false;
            }
        }

        public bool HasContactIsolation
        {
            get
            {
                if (InpatientAdmission != null)
                    if (InpatientAdmission.CurrentStateDefID == InpatientAdmission.States.ClinicProcedure)
                        if (InpatientAdmission.HasContactIsolation.HasValue && InpatientAdmission.HasContactIsolation.Value == true)
                            return true;
                return false;
            }
        }

        public bool HasDropletIsolation
        {
            get
            {
                if (InpatientAdmission != null)
                    if (InpatientAdmission.CurrentStateDefID == InpatientAdmission.States.ClinicProcedure)
                        if (InpatientAdmission.HasDropletIsolation.HasValue && InpatientAdmission.HasDropletIsolation.Value == true)
                            return true;
                return false;
            }
        }

        public bool HasTightContactIsolation
        {
            get
            {
                if (InpatientAdmission != null)
                    if (InpatientAdmission.CurrentStateDefID == InpatientAdmission.States.ClinicProcedure)
                        if (InpatientAdmission.HasTightContactIsolation.HasValue && InpatientAdmission.HasTightContactIsolation.Value == true)
                            return true;
                return false;
            }
        }

        public bool HasFallingRisk
        {
            get
            {
                if (InpatientAdmission != null)
                    if (InpatientAdmission.CurrentStateDefID == InpatientAdmission.States.ClinicProcedure)
                        if (InpatientAdmission.HasFallingRisk.HasValue && InpatientAdmission.HasFallingRisk.Value == true)
                            return true;
                return false;
            }
        }

        public string isolationInformation()
        {
            string isolationInfo = String.Empty;
            if (InpatientAdmission != null)
            {
                if (InpatientAdmission.CurrentStateDefID == InpatientAdmission.States.ClinicProcedure)
                {
                    if (InpatientAdmission.HasAirborneContactIsolation.HasValue && InpatientAdmission.HasAirborneContactIsolation.Value == true)
                        isolationInfo += "Hastanın solunum izolasyonu mevcuttur." + "\r\n";
                    if (InpatientAdmission.HasContactIsolation.HasValue && InpatientAdmission.HasContactIsolation.Value == true)
                        isolationInfo += "Hastanın temas izolasyonu mevcuttur." + "\r\n";
                    if (InpatientAdmission.HasDropletIsolation.HasValue && InpatientAdmission.HasDropletIsolation.Value == true)
                        isolationInfo += "Hastanın damlacık izolasyonu mevcuttur." + "\r\n";
                    if (InpatientAdmission.HasTightContactIsolation.HasValue && InpatientAdmission.HasTightContactIsolation.Value == true)
                        isolationInfo += "Hastanın sıkı temas izolasyonu mevcuttur." + "\r\n";
                }
            }
            return isolationInfo;
        }
        #endregion Methods

        public static SubEpisode.InpatientInfo getInpatientInfoByProtocolNo(string SubEpisodeProtocolNo)
        {

            TTObjectContext context = new TTObjectContext(true);
            var treatmentClinicList = InPatientTreatmentClinicApplication.GetLastActiveInPatientTreatClinicAppBySEProtocolNo(context, SubEpisodeProtocolNo);
            foreach (var lastTreatmentClinic in treatmentClinicList)
            {
                if (lastTreatmentClinic.BaseInpatientAdmission != null)
                {
                    SubEpisode.InpatientInfo inpatientInfo = new SubEpisode.InpatientInfo();
                    if (lastTreatmentClinic.BaseInpatientAdmission.PhysicalStateClinic != null)
                        inpatientInfo.PhysicalStateClinic = lastTreatmentClinic.BaseInpatientAdmission.PhysicalStateClinic.Name;
                    if (lastTreatmentClinic.BaseInpatientAdmission.RoomGroup != null)
                        inpatientInfo.RoomGroup = lastTreatmentClinic.BaseInpatientAdmission.RoomGroup.Name;
                    if (lastTreatmentClinic.BaseInpatientAdmission.Room != null)
                        inpatientInfo.Room = lastTreatmentClinic.BaseInpatientAdmission.Room.Name;
                    if (lastTreatmentClinic.BaseInpatientAdmission.Bed != null)
                        inpatientInfo.Bed = lastTreatmentClinic.BaseInpatientAdmission.Bed.Name;
                    if (lastTreatmentClinic.ProcedureDoctor != null)
                        inpatientInfo.ProcedureDoctor = lastTreatmentClinic.ProcedureDoctor.Name;
                    return inpatientInfo;
                }

            }

            return null;

        }

        public class InpatientInfo
        {
            public string PhysicalStateClinic;
            public string Bed;
            public string Room;
            public string RoomGroup;
            public string ProcedureDoctor;

        }

    }
}