
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
using TTStorageManager.Attributes;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Tanı Gridi
    /// </summary>
    public partial class DiagnosisGrid : TTObject, ISUTInstance
    {

        public DiagnosisGrid(PackageTemplateICDDetailDefinition packTempICDDef) : this(packTempICDDef.ObjectContext)
        {

            Diagnose = packTempICDDef.Diagnose;
            DiagnosisDefinition = packTempICDDef.DiagnosisDefinition;
            DiagnosisType = packTempICDDef.DiagnosisType;
            FreeDiagnosis = packTempICDDef.FreeDiagnosis;
            IsMainDiagnose = packTempICDDef.IsMainDiagnose;
            taniKodu = packTempICDDef.TaniKodu;
        }

        public DiagnosisGrid(EpisodeActionWithDiagnosis episodeAction,
            DiagnosisDefinition diagnosisDefinition,
             bool isMainDiagnose,
            DiagnosisTypeEnum diagnosisTypeEnum,
           ResUser responsibleDoctor,
           ResUser responsibleUser,
           DateTime? diagnoseDate

          )
            : this(episodeAction.ObjectContext)
        {
            EpisodeAction = episodeAction;
            EntryActionType = episodeAction.ActionType;
            AddToHistory = false;
            Diagnose = diagnosisDefinition;
            DiagnosisType = diagnosisTypeEnum;
            IsMainDiagnose = isMainDiagnose;
            ResponsibleUser = responsibleUser == null ? Common.CurrentResource : responsibleUser; //(ResUser)lstDoctorAddedToEpisodeDiagnosis.SelectedObject;
            ResponsibleDoctor = responsibleDoctor;
            DiagnoseDate = diagnoseDate == null ? Common.RecTime() : diagnoseDate;
            Speciality = episodeAction.ProcedureSpeciality;
            Episode = episodeAction.Episode;
            var diagnosisSubEpisode = new DiagnosisSubEpisode(episodeAction.ObjectContext);
            diagnosisSubEpisode.SubEpisode = episodeAction.SubEpisode;
            diagnosisSubEpisode.DiagnosisGrid = this;
        }



        public partial class GetDiagnosisByParent_Class : TTReportNqlObject
        {
        }

        public partial class GetDiagnosisByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetSecDiagnosisByEpisodeAction_Class : TTReportNqlObject
        {
        }

        public partial class GetSecDiagnosisBySubactionProcedure_Class : TTReportNqlObject
        {
        }

        public partial class GetPreDiagnosisByEpisodeAction_Class : TTReportNqlObject
        {
        }

        public partial class GetPreDiagnosisBySubactionProcedure_Class : TTReportNqlObject
        {
        }

        public partial class GetDiagnosisBySubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetInfectiousDiagnosisByDate_Class : TTReportNqlObject
        {
        }

        public partial class GetTop10DiagnosisDefinitionOfUser_Class : TTReportNqlObject
        {
        }

        public partial class GetSeconderDiagnosisByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetDiagnoseByDate_Class : TTReportNqlObject
        {
        }

        public partial class GetMainDiagnosisByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetMedulaDiagnosisBySubEpisodeAndStatus_Class : TTReportNqlObject
        {
        }

        public partial class GetLast10DiagnosisOfPatient_Class : TTReportNqlObject
        {
        }

        public partial class GetLast10DiagnosisOfUser_Class : TTReportNqlObject
        {
        }

        public partial class GetDiagnosisForMedulaByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetDiagnosisByDateInterval_Class : TTReportNqlObject
        {
        }

        public partial class GetDiagnosisForMedulaBySubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetDiagnoseAndPatientByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class VEM_BASVURU_TANI_Class : TTReportNqlObject
        {
        }

        public string DiagnoseCode
        {
            get
            {
                try
                {
                    #region DiagnoseCode_GetScript                    
                    if (Diagnose != null)
                    {
                        if (!string.IsNullOrEmpty(Diagnose.Code))
                        {
                            // 5 karakterden uzun tanı kodlarını bazen kabul etmiyor Hiperbarik te falan, bü yüzden ilk 5 karakteri alındı )
                            if (Diagnose.Code.Length > 5)
                                return Diagnose.Code.Substring(0, 5);
                            else
                                return Diagnose.Code;
                        }
                    }
                    return null;
                    #endregion DiagnoseCode_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "DiagnoseCode") + " : " + ex.Message, ex);
                }
            }
        }

        //public override void OnContextDispose()
        //{
        //    if (_isReportDiagnose.HasValue == false)
        //    {
        //        _isReportDiagnose = ReportDiagnosis != null && ReportDiagnosis.Where(t => t.EpisodeAction.IsCancelled==false).ToList().Count > 0;
        //    }
        //    base.OnContextDispose();
        //}

        //private bool? _isReportDiagnose;
        //[TTSerializeProperty]
        //public bool IsReportDiagnose
        //{
        //    get
        //    {
        //        if (_isReportDiagnose.HasValue)
        //            return _isReportDiagnose.Value;

        //        try
        //        {
        //            #region IsReportDiagnose_GetScript      
        //            if (this.ObjectContext == null)
        //                return false;

        //            if (ReportDiagnosis != null && ReportDiagnosis.Count > 0)
        //            {
        //                return true;
        //            }
        //            else
        //                return false;
        //            #endregion IsReportDiagnose_GetScript
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "IsReportDiagnose") + " : " + ex.Message, ex);
        //        }
        //    }
        //    set { _isReportDiagnose = value; }
        //}
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "SUBACTIONPROCEDURE":
                    {
                        SubactionProcedureWithDiagnosis value = (SubactionProcedureWithDiagnosis)newValue;
                        #region SUBACTIONPROCEDURE_SetParentScript
                        //if (value != null)
                        //{
                        //    this.Episode = value.Episode;
                        //    this.EntryActionType = value.EpisodeAction.ActionType;
                        //    this.Speciality = value.ProcedureSpeciality;
                        //}
                        #endregion SUBACTIONPROCEDURE_SetParentScript
                    }
                    break;
                case "EPISODEACTION":
                    {
                        EpisodeActionWithDiagnosis value = (EpisodeActionWithDiagnosis)newValue;
                        #region EPISODEACTION_SetParentScript
                        //if (value != null)
                        //{
                        //    this.Episode = value.Episode;
                        //    this.EntryActionType = value.ActionType;
                        //    this.Speciality = value.ProcedureSpeciality;

                        //}
                        #endregion EPISODEACTION_SetParentScript
                    }
                    break;

            }
        }




        public void UpdateSEPDiagnosis()
        {
            if (SEPDiagnoses.Count == 0)
                return;

            TTObjectContext objContext = new TTObjectContext(true);
            DiagnosisGrid originalDiagnosisGrid = (DiagnosisGrid)objContext.GetObject(ObjectID, TTObjectDefManager.Instance.ObjectDefs[typeof(DiagnosisGrid).Name], false);
            if (originalDiagnosisGrid != null)
            {
                foreach (SEPDiagnosis sepDiagnosis in SEPDiagnoses)
                {
                    if (Diagnose.ObjectID != originalDiagnosisGrid.Diagnose.ObjectID)
                        sepDiagnosis.Diagnose = Diagnose;

                    if (DiagnosisType != originalDiagnosisGrid.DiagnosisType)
                        sepDiagnosis.DiagnosisType = DiagnosisType;

                    if (IsMainDiagnose != originalDiagnosisGrid.IsMainDiagnose)
                        sepDiagnosis.IsMainDiagnose = IsMainDiagnose;

                    if ((OzelDurum == null && originalDiagnosisGrid.OzelDurum != null) ||
                        (OzelDurum != null && originalDiagnosisGrid.OzelDurum == null) ||
                        (OzelDurum != null && originalDiagnosisGrid.OzelDurum != null && OzelDurum.ObjectID != originalDiagnosisGrid.OzelDurum.ObjectID))
                        sepDiagnosis.OzelDurum = OzelDurum;
                }
            }
        }



        protected override void PreInsert()
        {
            #region PreInsert
            CheckAndSetDefaultProperties();
            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert
            setMondatoryProperties();
            FireInfectiousIllnesesInformation();
            AddToImportantMedicalInformationDiagnosis();
            ControlandAddPandemicInfo();
            SendSmsForDiagnosis();
            //AddEpisodeProtocolByDiagnoseCode();

            //            if ( this.Episode.Patient.ehr.Count >0)
            //            {
            //                if (this.Episode.Patient.ehr[0].ehrEpisodes.Count > 0 )
            //                {
            //                    ehrDiagnosis _ehrDiagnosis = new ehrDiagnosis(ObjectContext);
            //                    _ehrDiagnosis.Diagnose = this.Diagnose;
            //                    _ehrDiagnosis.DiagnoseDate = this.DiagnoseDate;
            //                    _ehrDiagnosis.DiagnoseType = this.DiagnosisType ;
            //                    _ehrDiagnosis.IsMainDiagnose = this.IsMainDiagnose ;
            //                    _ehrDiagnosis.DiagnosisGrid.Add(this);
            //                    //this.Episode.Patient.ehr[0].ehrEpisodes[0].ehrDiagnosis.Add(_ehrDiagnosis) ;
            //                    this.Episode.ehrEpisode.ehrDiagnosis.Add(_ehrDiagnosis) ;
            //                }
            //            }

            // DiagnosisSubEpisode clasının Post İnsretüne Taşındı
            //if (this.EpisodeAction != null && this.EpisodeAction.SubEpisode != null && this.EpisodeAction.SendToENabiz())
            //    new SendToENabiz(this.ObjectContext, this.EpisodeAction.SubEpisode, this.EpisodeAction.SubEpisode.ObjectID, this.EpisodeAction.SubEpisode.ObjectDef.Name, "103", Common.RecTime());
            //else if (this.SubactionProcedure != null && this.SubactionProcedure.SubEpisode != null && this.SubactionProcedure.SendToENabiz(true))
            //    new SendToENabiz(this.ObjectContext, this.SubactionProcedure.SubEpisode, this.SubactionProcedure.SubEpisode.ObjectID, this.SubactionProcedure.SubEpisode.ObjectDef.Name, "103", Common.RecTime());


            setEpisodesMainDiagnosis();
            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();
            UpdateSEPDiagnosis();
            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate


            if (((ITTObject)this).IsNew != true)
            {
                if (((DiagnosisGrid)((ITTObject)this).Original).Diagnose != (Diagnose))
                {
                    FireInfectiousIllnesesInformation();
                }
            }

            ChangeImportantMedicalInformationDiagnosis();
            //AddEpisodeProtocolByDiagnoseCode();

            //YAPILACAK//Mesaj verme sistemi tamamlandığında kontrol edilip açılabilir.
            //            if (((DiagnosisGrid)((ITTObject)this).Original).Diagnose.DeclerationMust==true)
            //            {
            //                Message Box.Show("Bildirimi zorunlu olan" + ((DiagnosisGrid)((ITTObject)this).Original).Diagnose.Name + "  Tanısını değiştirdiniz.Devam ettiğiniz takdirde bu tanıya ait Bulaşıcı/Bildirimi Zorunlu Hastalık Bilgileri işlemini iptal etmeniz gerekebilir. ");
            //            }


            // DiagnosisSubEpisode clasının Post  İnsretüne Taşındı
            //if (this.EpisodeAction != null && this.EpisodeAction.SubEpisode != null && this.EpisodeAction.SendToENabiz())
            //    new SendToENabiz(this.ObjectContext, this.EpisodeAction.SubEpisode, this.EpisodeAction.SubEpisode.ObjectID, this.EpisodeAction.SubEpisode.ObjectDef.Name, "103", Common.RecTime());
            //else if (this.SubactionProcedure != null && this.SubactionProcedure.SubEpisode != null && this.SubactionProcedure.SendToENabiz(true))
            //    new SendToENabiz(this.ObjectContext, this.SubactionProcedure.SubEpisode, this.SubactionProcedure.SubEpisode.ObjectID, this.SubactionProcedure.SubEpisode.ObjectDef.Name, "103", Common.RecTime());


            setEpisodesMainDiagnosis();
            #endregion PostUpdate
        }
        protected override void PreDelete()
        {
            #region PostDelete

            int _count = DiagnosisSubEpisodes.Count;
            while (_count > 0)
            {
                ((ITTObject)DiagnosisSubEpisodes[_count - 1]).Delete();
                _count--;
            }

            base.PreDelete();

            #endregion PostDelete
        }

        #region Methods
        //public virtual void SetDiagnosisType()
        //{
        //    //this.DiagnosisType = DiagnosisTypeEnum.Primer;
        //}

        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true)
            {
                CheckAndSetDefaultProperties();
            }
        }

        protected void setEpisodesMainDiagnosis()
        {
            Episode episode = Episode == null ? EpisodeAction.Episode : Episode;
            if (IsMainDiagnose == true)
            {
                episode.MainDiagnose = this;
            }
            else
            {
                if (episode.MainDiagnose == this)
                    episode.MainDiagnose = null;
            }
        }

        protected void setMondatoryProperties()
        {
            if (EpisodeAction != null)
            {
                Episode = EpisodeAction.Episode;
                EntryActionType = EpisodeAction.ActionType;
                Speciality = EpisodeAction.ProcedureSpeciality;
            }
            else if (SubactionProcedure != null)
            {
                Episode = SubactionProcedure.Episode;
                EntryActionType = SubactionProcedure.EpisodeAction.ActionType;
                Speciality = SubactionProcedure.ProcedureSpeciality;
            }

        }

        /// <summary>
        /// EpisodeActiona bağlı Diagnosis'ler için EpisodeActionın Episodeunu döndürür
        /// </summary>
        /// <returns></returns>
        protected virtual Episode MyEpisode()
        {
            if (EpisodeAction == null)
                return Episode;
            else
                return EpisodeAction.Episode;
        }

        protected virtual ResSection MyFromResource()
        {
            if (EpisodeAction == null)
                return (ResSection)Common.GetCurrentHospital(_objectContext);
            else
                return EpisodeAction.MasterResource;
        }

        /// <summary>
        /// EpisodeActiona bağlı Diagnosis'ler için  girşin yapıldığı EpisodeActionı döndürür
        /// </summary>
        /// <returns></returns>
        protected virtual EpisodeAction MyEntryEpisodeAction()
        {
            return EpisodeAction;
        }


        /// <summary>
        /// Tanı Tanım ekranında Bildirimi Zorunlu olarak işaretlenmiş bir tanı seçildiğinde otomatik olarak
        /// Bulaşıcı/Bildirimi Zorunlu Hastalık Bilgileri işlemi başlatılır.
        /// </summary>
        protected void FireInfectiousIllnesesInformation()
        {
            if (MyEntryEpisodeAction() != null) //Dışarıya gönderilen işlemlerde episode tanıları gönderilirken Bulaşıcı ve Bildirimi Zorunlu Hastalıkların fire etmemesi için.
            {
                if (Diagnose != null)
                {
                    if (Diagnose.DeclerationMust == true)
                    {
                        bool found;
                        found = false;
                        foreach (InfectiousIllnesesInformation infectiousIllnesesInformation in MyEntryEpisodeAction().Episode.InfectiousIllnesesInformations)
                        {
                            if (infectiousIllnesesInformation.InfectiousIllnesesDiagnosis == Diagnose && infectiousIllnesesInformation.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                            {
                                found = true;
                            }
                        }
                        if (found == false)
                        {
                            //Mehmet Beye Göster
                            //InfectiousIllnesesInformation infectiousIllnesesInformation = new InfectiousIllnesesInformation(this.ObjectContext, this.EpisodeAction.MasterResource);
                            InfectiousIllnesesInformation infectiousIllnesesInformation = (InfectiousIllnesesInformation)ObjectContext.CreateObject("INFECTIOUSILLNESESINFORMATION");
                            //infectiousIllnesesInformation.MasterResource = this.MyEntryEpisodeAction().MasterResource;
                            infectiousIllnesesInformation.StarterEpisodeAction = MyEntryEpisodeAction();
                            infectiousIllnesesInformation.StarterSubactionProcedure = SubactionProcedure;
                            infectiousIllnesesInformation.ActionDate = Common.RecTime();
                            infectiousIllnesesInformation.InfectiousIllnesesDiagnosis = Diagnose;

                            if (ResponsibleDoctor != null)
                                infectiousIllnesesInformation.ProcedureDoctor = ResponsibleDoctor;

                            if (DiagnosisType == DiagnosisTypeEnum.Primer)
                                infectiousIllnesesInformation.SKRSVakaTipi = SKRSVakaTipi.GetByDiagnosisStatusEnum((int)DiagnosisStatusEnum.Possible);

                            if (DiagnosisType == DiagnosisTypeEnum.Seconder)
                                infectiousIllnesesInformation.SKRSVakaTipi = SKRSVakaTipi.GetByDiagnosisStatusEnum((int)DiagnosisStatusEnum.Certain);

                            if (SubactionProcedure != null && SubactionProcedure.MasterResource != null)
                                infectiousIllnesesInformation.FromResource = SubactionProcedure.MasterResource;
                            else
                                infectiousIllnesesInformation.FromResource = MyEntryEpisodeAction().MasterResource;

                            infectiousIllnesesInformation.Episode = MyEpisode();
                            infectiousIllnesesInformation.CurrentStateDefID = InfectiousIllnesesInformation.States.New;

                            //YAPILACAKLAR//Master Resource'ü constracterda set edilmeli aşağıdaki kod düzeltilmeli//YAPILDI..yilmaz
                            //infectiousIllnesesInformation.MasterResource=this.MyEntryEpisodeAction().MasterResource;
                        }
                    }
                }
            }
        }
        protected void CheckAndSetDefaultProperties()
        {
            if (DiagnoseDate == null)
                DiagnoseDate = Common.RecTime();
            if (ResponsibleUser == null)
                ResponsibleUser = Common.CurrentResource;
            if (EpisodeAction != null)
            {
                if (Episode == null)
                    Episode = EpisodeAction.Episode;
                if (ResponsibleDoctor == null)
                    ResponsibleDoctor = EpisodeAction.ProcedureDoctor;
                if (EntryActionType == null)
                    EntryActionType = EpisodeAction.ActionType;
                if (Speciality == null)
                    Speciality = EpisodeAction.ProcedureSpeciality;
            }
            else if (SubactionProcedure != null)
            {
                if (Episode == null)
                    Episode = SubactionProcedure.Episode;
                if (ResponsibleDoctor == null)
                    ResponsibleDoctor = SubactionProcedure.ProcedureDoctor;
                if (EntryActionType == null)
                    EntryActionType = SubactionProcedure.EpisodeAction.ActionType;
                if (Speciality == null)
                    Speciality = SubactionProcedure.ProcedureSpeciality;
            }
        }

        protected void AddToImportantMedicalInformationDiagnosis()
        {

            if (AddToHistory == true)
            {
                if (MyEpisode() != null)//null geldiğinde ne yapılacak? this.Episode olduğu halde neden Episode'a ihtiyaç duyulmuş?
                {
                    if (MyEpisode().Patient.ImportantMedicalInformation != null)
                    {
                        MyEpisode().Patient.ImportantMedicalInformation.DiagnosisHistory.Add(this);
                    }
                    else
                    {
                        ImportantMedicalInformation importantMedicalInformation = new ImportantMedicalInformation((Episode)MyEpisode(), MyFromResource(), ObjectContext);
                        importantMedicalInformation.DiagnosisHistory.Add(this);
                    }

                }
            }
        }

        protected void ControlandAddPandemicInfo()
        {

            if (MyEpisode() != null && Diagnose.Code == "U07.3")
            {
                if (MyEpisode().Patient.MedicalInformation != null)
                {
                    MyEpisode().Patient.MedicalInformation.Pandemic = true;
                }
                else
                {
                    MyEpisode().Patient.MedicalInformation = new MedicalInformation(this.ObjectContext);
                    MyEpisode().Patient.MedicalInformation.Pandemic = true;
                }

            }

        }
        protected void RemoveFromImportantMedicalInformationDiagnosis()
        {
            if (MyEpisode().Patient.ImportantMedicalInformation != null)
            {
                if (MyEpisode().Patient.ImportantMedicalInformation.DiagnosisHistory.Contains(this))
                {
                    MyEpisode().Patient.ImportantMedicalInformation.DiagnosisHistory.Remove(this);
                }

            }
        }

        protected void ChangeImportantMedicalInformationDiagnosis()
        {
            if (((DiagnosisGrid)((ITTObject)this).Original).AddToHistory == true)
            {
                if (AddToHistory == false)
                {
                    RemoveFromImportantMedicalInformationDiagnosis();
                }
            }
            else //(((DiagnosisGrid)((ITTObject)this).Original).AddToHistory==false)
            {
                if (AddToHistory == true)
                {
                    AddToImportantMedicalInformationDiagnosis();
                }
            }
        }

        public IEpisodeAction EpisodeActionObject
        {
            get
            {
                if (EpisodeAction != null)
                    return (IEpisodeAction)EpisodeAction;
                if (SubactionProcedure != null)
                    return (IEpisodeAction)SubactionProcedure;
                return null;
            }
            set
            {
                if (value is EpisodeAction)
                    EpisodeAction = (EpisodeActionWithDiagnosis)value;
                if (value is SubactionProcedureFlowable)
                    SubactionProcedure = (SubactionProcedureWithDiagnosis)value;
            }
        }

        public ISUTEpisodeAction GetSUTEpisodeAction()
        {
            return EpisodeAction;
        }

        public ISUTRulableObject GetSUTRulableObject()
        {
            return Diagnose;
        }

        public DateTime? GetRuleDate()
        {
            return DiagnoseDate;
        }

        public double? GetRuleAmount()
        {
            return null;
        }

        public long? GetDoctorSpecialityCode()
        {
            return null;
        }

        public DiagnosisGrid PrepareDiagnosisGridForRemoteMethod(bool withNewObjectID)
        {
            // Çağırılan yerde yeni Save Point Konulup sonra savepointe dönülmeli
            if (withNewObjectID)
            {
                DiagnosisGrid sendingDiagnosisGrid = (DiagnosisGrid)Clone();
                //Diğer tarafda bilinmeyen nesne içeren tüm relationlar temizleniyor...
                sendingDiagnosisGrid.ExaminationInfoByBrans = null;

                sendingDiagnosisGrid.Episode = null;
                sendingDiagnosisGrid.EpisodeAction = null;
                sendingDiagnosisGrid.ImportantMedicalInformation = null;
                sendingDiagnosisGrid.ResponsibleUser = null;
                sendingDiagnosisGrid.SubactionProcedure = null;
                TTSequence.allowSetSequenceValue = true;
                //sendingDiagnosisGrid.MedulaServiceProviderRefNo.SetSequenceValue(0);
                return sendingDiagnosisGrid;
            }
            else
            {
                return this;
            }

        }

        /*
        public void AddEpisodeProtocolByDiagnoseCode()
        {
            if (this.Diagnose != null)
            {
                if (this.Diagnose.Code != null)
                {
                    if (this.Diagnose.Code.Substring(0, 1) == "C") // C ile başlayan tanı kodlarında
                    {
                        Episode episode;
                        if (this.EpisodeAction != null)
                            episode = this.EpisodeAction.Episode;
                        else if (this.SubactionProcedure != null)
                            episode = this.SubactionProcedure.Episode;
                        else
                            episode = null;

                        // Açık durumda vakabaşı anlaşması varsa kapatılıp, Kamu Kurum Anlaşması eklenecek
                        if (episode != null)
                            this.EpisodeProtocol = episode.AddDefaultPublicProtocolIfHasBulletin(true);
                    }
                }
            }
        }
        */

        //TODO: KLINIK KARAR VERME
        // Tani Giris componenti tasarlanirken asagidaki methodlar kullanilarak, girilen herbir tani satiri icin klinik karar verme detay bilgisi get edilecek (GetMyDiagnosisClinicDecisionDetail)
        // herbir klinik detay objesi icin EmergencyIntervention objesi varsa ona  child olarak EmergencyInterventionClinicalDecisions objeleri eklenecek. (CreateEmergencyClinicalDecision)
        public void CreateEmergencyClinicalDecision(List<EmergencyClinicDecisionQuideDetailDefinition> clinicalDecisionDetailList)
        {
            if (EpisodeAction is PatientExamination)
            {
                PatientExamination pExam = (PatientExamination)EpisodeAction;

                if (pExam.EmergencyIntervention != null)
                {
                    foreach (EmergencyClinicDecisionQuideDetailDefinition clinicalDecision in clinicalDecisionDetailList)
                    {
                        EmergencyInterventionClinicalDecision EMClncDecision = new EmergencyInterventionClinicalDecision(ObjectContext);
                        EMClncDecision.EMClinicDecisionQuideDetDef = clinicalDecision;
                        pExam.EmergencyIntervention.EmergencyInterventionClinicalDecisions.Add(EMClncDecision);
                    }
                }
            }
        }

        public List<EmergencyClinicDecisionQuideDetailDefinition> GetMyDiagnosisClinicDecisionDetail()
        {

            List<EmergencyClinicDecisionQuideDetailDefinition> clinicDecisionDetailList = new List<EmergencyClinicDecisionQuideDetailDefinition>();
            if (Diagnose.EMClinicDecisionQuideDef != null)
            {
                foreach (EmergencyClinicDecisionQuideDetailDefinition decisionDetail in Diagnose.EMClinicDecisionQuideDef.EMClinicDecisionQuideDetails)
                {
                    if (clinicDecisionDetailList.Contains(decisionDetail) == false)
                        clinicDecisionDetailList.Add(decisionDetail);
                }
            }
            return clinicDecisionDetailList;
        }

        protected void SendSmsForDiagnosis() //Sms gönderilecek tanı girildiyse hastaya sms gönderir
        {

            if (Diagnose.SendSms == true)
            {
                UserMessage userMessage = new UserMessage();

                Patient patient = MyEpisode().Patient;
                string hospitalName = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                string messageText = "";
                messageText = DiagnoseDate != null ? Convert.ToDateTime(DiagnoseDate).ToString("dd.MM.yyyy HH:mm") + " tarihinde " : "";
                messageText += hospitalName + "'de yapılan muayeneniz sonucunda Doktor " + ResponsibleDoctor.Name + " tarafından " + Diagnose.Code + "-" + Diagnose.Name + " tanısı girilmiştir. ";
                messageText += Diagnose.SMSText;
                List<Patient> patients = new List<Patient> { patient };
                userMessage.SendSMSPatient(patients, messageText, SMSTypeEnum.DiagnosisSMSForPatient);

            }


        }

        #endregion Methods

    }
}