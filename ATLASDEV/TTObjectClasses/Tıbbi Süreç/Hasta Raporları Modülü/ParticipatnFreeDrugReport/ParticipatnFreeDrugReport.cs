
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
using Newtonsoft.Json;

namespace TTObjectClasses
{
    /// <summary>
    /// Hasta Katılım Payından Muaf İlaç Raporu
    /// </summary>
    public partial class ParticipatnFreeDrugReport : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public partial class GetParticipatnFreeDrugReportRNQL_Class : TTReportNqlObject
        {
        }

        private BindingList<ResUser> _basHekimList;

        private BindingList<ResUser> basHekimList
        {
            get
            {
                if (_basHekimList != null && _basHekimList.Count > 0)
                    return _basHekimList;
                _basHekimList = new BindingList<ResUser>();
                Guid bashekimRoleID = Common.BashekimRoleID;
                BindingList<ResUser> basTabipList = ResUser.GetResUsersByRoleID(ObjectContext, bashekimRoleID);

                if (basTabipList != null && basTabipList.Count > 0)
                    foreach (ResUser ru in basTabipList)
                        _basHekimList.Add(ru);

                Guid nobetciBashekimRoleID = Common.NobetciBashekimRoleID;
                BindingList<ResUser> nobetciBasTabipList = ResUser.GetResUsersByRoleID(ObjectContext, nobetciBashekimRoleID);
                if (nobetciBasTabipList != null && nobetciBasTabipList.Count > 0)
                    foreach (ResUser ru in nobetciBasTabipList)
                        _basHekimList.Add(ru);
                return _basHekimList;
            }
        }
        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();

            if (TransDef != null && TransDef.ToStateDefID == ParticipatnFreeDrugReport.States.Cancelled)
            {
                if (_MedulaReportResults != null)
                {
                    foreach (MedulaReportResult result in _MedulaReportResults)
                    {
                        if (result != null && result.ReportChasingNo != null)
                            throw new Exception("Medula gönderimi yapılmış raporu iptal edemezsiniz!");
                    }
                }

            }

            if (CurrentStateDefID == ParticipatnFreeDrugReport.States.Completed || CurrentStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval || CurrentStateDefID == ParticipatnFreeDrugReport.States.Approval)
            {
                if (SubEpisode != null && SendToENabiz())
                    new SendToENabiz(ObjectContext, SubEpisode, SubEpisode.ObjectID, SubEpisode.ObjectDef.Name, "103", Common.RecTime());
            }

            

            if (SecondDoctor != null)
                SecondDoctor.SetAsPatientAuthorizedResource(Episode);
            if (ThirdDoctor != null)
                ThirdDoctor.SetAsPatientAuthorizedResource(Episode);
            ProcedureDoctor.SetAsPatientAuthorizedResource(Episode);

            bool currentResourceIsHeadDoctor = (ResUser.HasRole(TTObjectClasses.Common.CurrentResource, Common.BashekimRoleID) || ResUser.HasRole(TTObjectClasses.Common.CurrentResource, Common.NobetciBashekimRoleID));

            foreach (ResUser resUser in basHekimList)
            {
                resUser.SetAsPatientAuthorizedResource(Episode);
            }
            //string basHekimObjectID = TTObjectClasses.SystemParameter.GetParameterValue("KURUMSALYONETICI_OBJECTID", "XXXXXX");
            //BindingList<ResUser> basTabipList = ResUser.GetResUserByObjectID(this.ObjectContext, basHekimObjectID);
            //if (basTabipList != null && basTabipList.Count > 0)
            //    basTabipList[0].SetAsPatientAuthorizedResource(this.Episode);

            if (TTObjectClasses.Common.CurrentResource != null)
            { //CurrentResource 1.,2.,3. tabip veya başhekim değilse hata versin.
                if (!((SecondDoctor == null || (SecondDoctor != null && TTObjectClasses.Common.CurrentResource.ObjectID.Equals(SecondDoctor.ObjectID))) ||
                    (ThirdDoctor == null || (ThirdDoctor != null && TTObjectClasses.Common.CurrentResource.ObjectID.Equals(ThirdDoctor.ObjectID))) ||
                    (ProcedureDoctor == null || (ProcedureDoctor != null && TTObjectClasses.Common.CurrentResource.ObjectID.Equals(ProcedureDoctor.ObjectID))) ||
                    (currentResourceIsHeadDoctor) ||
                    Common.CurrentUser.IsSuperUser))
                {
                    throw new Exception("Bu işlemi kaydetmek için yetkiniz bulunmamaktadır.");
                }
            }

            NotifyDoctors();
            #endregion PostUpdate
        }

        private void NotifyDoctors()
        {
            if (TransDef != null && TransDef.ToStateDefID != ParticipatnFreeDrugReport.States.Cancelled)
            {
                List<string> doctorlist = new List<string>();
                if (TransDef.ToStateDefID == ParticipatnFreeDrugReport.States.Approval)
                {
                   if (basHekimList != null && basHekimList.Count > 0)
                        foreach (ResUser ru in basHekimList)
                            doctorlist.Add(ru.ObjectID.ToString());
                }
                else if (TransDef.ToStateDefID == ParticipatnFreeDrugReport.States.New 
                    || TransDef.ToStateDefID == ParticipatnFreeDrugReport.States.Report)
                {
                    if (ProcedureDoctor != null)
                        doctorlist.Add(ProcedureDoctor.ObjectID.ToString());
                }
                else if(TransDef.ToStateDefID == ParticipatnFreeDrugReport.States.ThirdDoctorApproval 
                    || TransDef.ToStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval )
                {
                    
                    if (ThirdDoctor != null)
                        doctorlist.Add(ThirdDoctor.ObjectID.ToString());
                    if (SecondDoctor != null)
                        doctorlist.Add(SecondDoctor.ObjectID.ToString());
                }

                TTUtils.AtlasNotificationContainer atlasNotification = new TTUtils.AtlasNotificationContainer();
                atlasNotification.users = doctorlist;
                atlasNotification.notificationType = TTUtils.AtlasNotificationType.Info;
                atlasNotification.contentType = TTUtils.AtlasContentType.Action;

                string messageText = "";
                messageText += ProcedureDoctor != null ? ("Sayın Doktor, ") : "";
                messageText += RequestDate != null ? (RequestDate.Value.ToString("dd MMMM yyyy") + " tarihi " + RequestDate.Value.ToString("HH:mm") + " saatinde ") : "";
                messageText += Episode.Patient != null ? ("'" + Episode.Patient.FullName + "' hastası için ") : "";
                messageText += "tarafınıza rapor istemi yapılmıştır.";

                atlasNotification.content = messageText;
                atlasNotification.actionData = this;
                string notificationStr = JsonConvert.SerializeObject(atlasNotification);

                TTUtils.AtlasSignalRHubFactory.Instance.HandleUserNotification(notificationStr);

            }
        }

        protected void PreTransition_New2Approval()
        {
            // From State : New   To State : Approval
            #region PreTransition_New2Approval


            string kontrol = "0";
            if (SubEpisode.IsSGK)
            {
                if (ParticipationFreeDrugs.Count > 0)
                {
                    foreach (ParticipationFreeDrgGrid item in ParticipationFreeDrugs)
                    {
                        if (item.EtkinMadde != null)
                            kontrol = "1";
                    }
                    if (kontrol == "1")
                    {
                        if (MedulaReportResults != null && MedulaReportResults.Count > 0)
                        {
                            int raporKontrol = 0;
                            foreach (MedulaReportResult raporlar in MedulaReportResults)
                            {
                                if (!string.IsNullOrEmpty(raporlar.ReportChasingNo))
                                {
                                    if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULAILACRAPORUGONDERIMTIPI", "0") == "0")
                                    {
                                        if (CommitteeReport == true)
                                        {
                                            if (ThirdDoctorApproval == 1 && SecondDoctorApproval == 1)
                                                raporKontrol = 1;
                                            else
                                            {
                                                if (ThirdDoctorApproval != 1)
                                                    throw new Exception(TTUtils.CultureService.GetText("M25085", "3. Doktor Raporu Onaylamadan Onaya Gönderemezsiniz!!!"));
                                                if (SecondDoctorApproval != 1)
                                                    throw new Exception(TTUtils.CultureService.GetText("M25080", "2. Doktor Raporu Onaylamadan Onaya Gönderemezsiniz!!!"));
                                            }
                                        }
                                        else
                                            raporKontrol = 1;
                                    }
                                    else
                                        raporKontrol = 1;
                                }
                            }
                            if (raporKontrol == 0)
                                throw new Exception("Raporu Medulaya Bildiremediniz!!");
                        }
                        else
                            throw new Exception("Raporu Medulaya Bildiremediniz!!");
                    }
                }
            }

            #endregion PreTransition_New2Approval
        }

        protected void PreTransition_New2SecondDoctorApproval()
        {
            // From State : New   To State : SecondDoctorApproval
            #region PreTransition_New2SecondDoctorApproval


            string kontrol = "0";
            if (SubEpisode.IsSGK)
            {
                if (ParticipationFreeDrugs.Count > 0)
                {
                    foreach (ParticipationFreeDrgGrid item in ParticipationFreeDrugs)
                    {
                        if (item.EtkinMadde != null)
                            kontrol = "1";
                    }
                    if (kontrol == "1")
                    {
                        if (MedulaReportResults != null && MedulaReportResults.Count > 0)
                        {
                            foreach (MedulaReportResult raporlar in MedulaReportResults)
                            {
                                if (string.IsNullOrEmpty(raporlar.ReportChasingNo))
                                    throw new Exception("Raporu Medulaya Bildiremediniz!!");
                            }
                        }
                        else
                            throw new Exception("Raporu Medulaya Bildiremediniz!!");
                    }
                }
            }

            #endregion PreTransition_New2SecondDoctorApproval
        }

        protected void PreTransition_Approval2New()
        {
            // From State : Approval   To State : New
            #region PreTransition_Approval2New

            //Asagidaki kod ParticipationFreeDrugReportNewForm formun clienntside post scriptine tasindi.
            /*if (this.HeadDoctorApproval == 1)
            {
                if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Raporu Medula'da onayladınız. \nİade ettiğinizde Medula onayı iptal edilmeyecektir !!!. \nDevam etmek istediğinize emin misiniz?") == "H")
                    throw new TTUtils.TTException("İşlemden vazgeçildi");
            }
            */

            #endregion PreTransition_Approval2New
        }

        protected void PreTransition_Approval2Report()
        {
            // From State : Approval   To State : Report
            #region PreTransition_Approval2Report

            if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULAILACRAPORUGONDERIMTIPI", "0") == "0")
            {
                int raporKontrol = 0;
                string kontrol = "0";
                if (SubEpisode.IsSGK)
                {
                    if (ParticipationFreeDrugs.Count > 0)
                    {
                        foreach (ParticipationFreeDrgGrid item in ParticipationFreeDrugs)
                        {
                            if (item.EtkinMadde != null)
                                kontrol = "1";
                        }
                        if (kontrol == "1")
                        {
                            foreach (MedulaReportResult raporlar in MedulaReportResults)
                            {
                                if (!string.IsNullOrEmpty(raporlar.ReportChasingNo))
                                {
                                    if (HeadDoctorApproval != 1)
                                        throw new Exception(TTUtils.CultureService.GetText("M25248", "Başhekim Onaylamadan Rapora Gönderemezsiniz!!!"));
                                    else
                                        raporKontrol = 1;
                                }
                                else
                                    raporKontrol = 0;
                            }
                            if (raporKontrol == 0)
                                throw new Exception("Meduladan Rapor Alınmadan Devam Edemezsiniz !!!");
                        }
                    }
                }
            }


            #endregion PreTransition_Approval2Report
        }

        protected void PreTransition_SecondDoctorApproval2ThirdDoctorApproval()
        {
            // From State : SecondDoctorApproval   To State : ThirdDoctorApproval
            #region PreTransition_SecondDoctorApproval2ThirdDoctorApproval


            string kontrol = "0";
            if (SubEpisode.IsSGK)
            {
                if (ParticipationFreeDrugs.Count > 0)
                {
                    foreach (ParticipationFreeDrgGrid item in ParticipationFreeDrugs)
                    {
                        if (item.EtkinMadde == null)
                            kontrol = "1";
                    }
                    if (kontrol != "1")
                    {
                        if (MedulaReportResults != null && MedulaReportResults.Count > 0)
                        {
                            foreach (MedulaReportResult raporlar in MedulaReportResults)
                            {
                                if (string.IsNullOrEmpty(raporlar.ReportChasingNo))
                                    throw new Exception("Raporu Medulaya Bildiremediniz!!");
                                if (SecondDoctorApproval != 1)
                                    throw new Exception(TTUtils.CultureService.GetText("M25079", "2. Doktor Raporu Onaylamadan 3.Doktor Onayına Gönderemezsiniz!!!"));
                            }
                        }
                        else
                            throw new Exception("Raporu Medulaya Bildiremediniz!!");
                    }
                }
            }



            #endregion PreTransition_SecondDoctorApproval2ThirdDoctorApproval
        }

        protected void PreTransition_ThirdDoctorApproval2Approval()
        {
            // From State : ThirdDoctorApproval   To State : Approval
            #region PreTransition_ThirdDoctorApproval2Approval

            string kontrol = "0";
            if (SubEpisode.IsSGK)
            {
                if (ParticipationFreeDrugs.Count > 0)
                {
                    foreach (ParticipationFreeDrgGrid item in ParticipationFreeDrugs)
                    {
                        if (item.EtkinMadde != null)
                            kontrol = "1";
                    }
                    if (kontrol == "1")
                    {
                        if (MedulaReportResults != null && MedulaReportResults.Count > 0)
                        {
                            foreach (MedulaReportResult raporlar in MedulaReportResults)
                            {
                                if (string.IsNullOrEmpty(raporlar.ReportChasingNo))
                                    throw new Exception("Raporu Medulaya Bildiremediniz!!");
                                if (ThirdDoctorApproval != 1)
                                    throw new Exception(TTUtils.CultureService.GetText("M25085", "3. Doktor Raporu Onaylamadan Onaya Gönderemezsiniz!!!"));
                            }
                        }
                        else
                            throw new Exception("Raporu Medulaya Bildiremediniz!!");
                    }
                }
            }

            #endregion PreTransition_ThirdDoctorApproval2Approval
        }

        protected void PostTransition_2Completed()
        {
            CreateHCReportProcedure();
        }

        protected void PostTransition_2ReportCompleted()
        {
            new SendToENabiz(ObjectContext, SubEpisode, SubEpisode.ObjectID, SubEpisode.ObjectDef.Name, "103", Common.RecTime());
        }

        #region Methods

        public ParticipatnFreeDrugReport(TTObjectContext objectContext, EpisodeAction episodeAction)
            : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = ParticipatnFreeDrugReport.States.New;
            Episode = episodeAction.Episode;
        }

        public ParticipatnFreeDrugReport(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable)
            : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = subactionProcedureFlowable.MasterResource;
            FromResource = subactionProcedureFlowable.MasterResource;
            CurrentStateDefID = ParticipatnFreeDrugReport.States.New;
            Episode = subactionProcedureFlowable.Episode;
        }

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.ParticipatnFreeDrugReport;
            }
        }

        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObj = (ITTObject)this;
            if (theObj.IsNew)
            {
                ReportNo.GetNextValue();
            }
        }

        public static IlacRaporuServis.eraporGirisIstekDVO eraporGiris(ParticipatnFreeDrugReport pfr)
        {

            if (pfr.Episode.Patient.UniqueRefNo == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25794", "Hasta Kimlik Numarası Boş Olamaz"));
            }
            if (pfr.ProcedureDoctor.Person.UniqueRefNo == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25523", "Doktor Kimlik Numarası Boş Olamaz"));
            }
            if (pfr.ProcedureDoctor.GetSpeciality() == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25521", "Doktor Branş Kodu Boş Olamaz"));
            }
            IlacRaporuServis.eraporGirisIstekDVO eraporGirisIstekDVO = new IlacRaporuServis.eraporGirisIstekDVO();
            eraporGirisIstekDVO.doktorTcKimlikNo = pfr.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
            eraporGirisIstekDVO.tesisKodu = SystemParameter.GetSaglikTesisKodu().ToString();

            IlacRaporuServis.eraporDVO _eraporDVO = new IlacRaporuServis.eraporDVO();

            _eraporDVO.aciklama = string.Empty;
            _eraporDVO.hastaTcKimlikNo = pfr.Episode.Patient.UniqueRefNo.Value.ToString();//Zorunlu
            _eraporDVO.klinikTani = string.Empty;
            _eraporDVO.protokolNo = pfr.Episode.HospitalProtocolNo.ToString();//Zorunlu
            //1 ? Sağlık Kurulu Raporu
            //2 ? Uzman Hekim Raporu
            _eraporDVO.raporDuzenlemeTuru = "2";//Zorunlu
            _eraporDVO.raporNo = pfr.ReportNo.Value.ToString();//Zorunlu
            _eraporDVO.raporOnayDurumu = string.Empty;
            _eraporDVO.raporTakipNo = string.Empty;
            if (pfr.ExaminationDate.HasValue)
                _eraporDVO.raporTarihi = pfr.ExaminationDate.Value.ToString("dd.MM.yyyy");//Zorunlu
            else
                _eraporDVO.raporTarihi = DateTime.Now.ToString("dd.MM.yyyy");

            _eraporDVO.takipNo = pfr.SubEpisode.SGKSEP != null ? pfr.SubEpisode.SGKSEP.MedulaTakipNo : "";//Zorunlu
            _eraporDVO.tesisKodu = SystemParameter.GetSaglikTesisKodu().ToString();//Zorunlu


            List<IlacRaporuServis.eraporTeshisDVO> _eraporTeshisDVOList = new List<IlacRaporuServis.eraporTeshisDVO>();
            List<IlacRaporuServis.taniDVO> _taniDVOList = new List<IlacRaporuServis.taniDVO>();

            foreach (DiagnosisGrid item in pfr.Episode.Diagnosis)
            {
                //foreach (var _taniCode in item)
                //{
                //    IlacRaporuServis.TaniDVO _taniDVO = new IlacRaporuServis.TaniDVO();
                //    _taniDVO.kodu = item.Diagnose.Code;

                //    _taniDVOList.Add(_taniDVO);
                //    _eraporTeshisDVOList.Add(_eraporTeshisDVO);
                //}

                IlacRaporuServis.eraporTeshisDVO _eraporTeshisDVO = new IlacRaporuServis.eraporTeshisDVO();
                if (item.Diagnose.Teshis != null && item.Diagnose.Teshis.teshisKodu != null)
                    _eraporTeshisDVO.raporTeshisKodu = item.Diagnose.Teshis.teshisKodu.Value.ToString();
                else
                    _eraporTeshisDVO.raporTeshisKodu = "";

                _eraporTeshisDVO.taniListesi = _taniDVOList.ToArray();

            }
            if (_eraporTeshisDVOList != null && _eraporTeshisDVOList.Count > 0)
                _eraporDVO.eraporTeshisListesi = _eraporTeshisDVOList.ToArray();




            List<IlacRaporuServis.eraporTaniDVO> _eraporTaniDVOList = new List<IlacRaporuServis.eraporTaniDVO>();
            foreach (DiagnosisGrid diagnosis in pfr.Episode.Diagnosis)
            {
                IlacRaporuServis.eraporTaniDVO _taniDVO = new IlacRaporuServis.eraporTaniDVO();
                _taniDVO.taniKodu = diagnosis.DiagnoseCode;  //Zorunlu
                _eraporTaniDVOList.Add(_taniDVO);

            }
            if (_eraporTaniDVOList != null && _eraporTaniDVOList.Count > 0)
                _eraporDVO.eraporTaniListesi = _eraporTaniDVOList.ToArray();

            //0      Yok
            //56 Hemodiyaliz
            //109 Aile Hekimliği
            List<IlacRaporuServis.eraporDoktorDVO> _eraporDoktorDVOList = new List<IlacRaporuServis.eraporDoktorDVO>();
            IlacRaporuServis.eraporDoktorDVO _eraporDoktorDVO = new IlacRaporuServis.eraporDoktorDVO();
            _eraporDoktorDVO.tcKimlikNo = pfr.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();  //Zorunlu
            _eraporDoktorDVO.sertifikaKodu = "0";  //Zorunlu
            _eraporDoktorDVO.bransKodu = pfr.ProcedureDoctor.GetSpeciality() != null ? pfr.ProcedureDoctor.GetSpeciality().Code : "0";  //Zorunlu
            _eraporDoktorDVOList.Add(_eraporDoktorDVO);
            _eraporDVO.eraporDoktorListesi = _eraporDoktorDVOList.ToArray();

            List<IlacRaporuServis.eraporAciklamaDVO> _eraporAciklamaDVOList = new List<IlacRaporuServis.eraporAciklamaDVO>();
            IlacRaporuServis.eraporAciklamaDVO _eraporAciklamaDVO = new IlacRaporuServis.eraporAciklamaDVO();
            _eraporAciklamaDVO.aciklama = "";//Zorunlu
            _eraporAciklamaDVO.takipFormuNo = "";
            _eraporAciklamaDVOList.Add(_eraporAciklamaDVO);
            _eraporDVO.eraporAciklamaListesi = _eraporAciklamaDVOList.ToArray();

            List<IlacRaporuServis.eraporEtkinMaddeDVO> _eraporEtkinMaddeDVOList = new List<IlacRaporuServis.eraporEtkinMaddeDVO>();
            foreach (ParticipationFreeDrgGrid item in pfr.ParticipationFreeDrugs)
            {
                IlacRaporuServis.eraporEtkinMaddeDVO _eraporEtkinMaddeDVO = new IlacRaporuServis.eraporEtkinMaddeDVO();
                _eraporEtkinMaddeDVO.etkinMaddeKodu = item.EtkinMadde.etkinMaddeKodu;
                _eraporEtkinMaddeDVO.kullanimDoz1 = DrugOrder.GetDetailCount(item.Frequency.Value).ToString();
                _eraporEtkinMaddeDVO.kullanimDoz2 = ((int)item.MedulaDose.Value).ToString();
                _eraporEtkinMaddeDVO.kullanimDozBirimi = ((int)item.UsageDoseUnitType.Value).ToString();
                _eraporEtkinMaddeDVO.kullanimDozPeriyot = item.Day.Value.ToString();
                _eraporEtkinMaddeDVO.kullanimDozPeriyotBirimi = ((int)item.PeriodUnitType.Value).ToString();
                _eraporEtkinMaddeDVOList.Add(_eraporEtkinMaddeDVO);
            }
            if (_eraporEtkinMaddeDVOList != null && _eraporEtkinMaddeDVOList.Count > 0)
                _eraporDVO.eraporEtkinMaddeListesi = _eraporEtkinMaddeDVOList.ToArray();

            eraporGirisIstekDVO.eraporDVO = _eraporDVO;

            return eraporGirisIstekDVO;

        }

        public static IlacRaporuServis.eraporSilIstekDVO eraporSil(ParticipatnFreeDrugReport pfr)
        {
            if (pfr.ProcedureDoctor.Person.UniqueRefNo == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25523", "Doktor Kimlik Numarası Boş Olamaz"));
            }

            IlacRaporuServis.eraporSilIstekDVO eraporSilIstekDVO = new IlacRaporuServis.eraporSilIstekDVO();

            eraporSilIstekDVO.doktorTcKimlikNo = pfr.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
            eraporSilIstekDVO.tesisKodu = SystemParameter.GetSaglikTesisKodu().ToString();
            eraporSilIstekDVO.raporTakipNo = "";

            return eraporSilIstekDVO;

        }

        public static IlacRaporuServis.eraporSorguIstekDVO eraporSorgula(ParticipatnFreeDrugReport pfr)
        {

            if (pfr.ProcedureDoctor.Person.UniqueRefNo == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25523", "Doktor Kimlik Numarası Boş Olamaz"));
            }

            IlacRaporuServis.eraporSorguIstekDVO eraporSorguIstekDVO = new IlacRaporuServis.eraporSorguIstekDVO();

            eraporSorguIstekDVO.doktorTcKimlikNo = pfr.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
            eraporSorguIstekDVO.tesisKodu = SystemParameter.GetSaglikTesisKodu().ToString();
            eraporSorguIstekDVO.raporTakipNo = "";

            return eraporSorguIstekDVO;

        }

        public static IlacRaporuServis.eraporListeSorguIstekDVO eraporListeSorgula(ParticipatnFreeDrugReport pfr)
        {
            if (pfr.ProcedureDoctor.Person.UniqueRefNo == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25523", "Doktor Kimlik Numarası Boş Olamaz"));
            }
            if (pfr.Episode.Patient.UniqueRefNo == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25794", "Hasta Kimlik Numarası Boş Olamaz"));
            }

            IlacRaporuServis.eraporListeSorguIstekDVO eraporListeSorguIstekDVO = new IlacRaporuServis.eraporListeSorguIstekDVO();

            eraporListeSorguIstekDVO.doktorTcKimlikNo = pfr.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
            eraporListeSorguIstekDVO.tesisKodu = SystemParameter.GetSaglikTesisKodu().ToString();
            eraporListeSorguIstekDVO.hastaTcKimlikNo = pfr.Episode.Patient.UniqueRefNo.Value.ToString();

            return eraporListeSorguIstekDVO;

        }

        public static IlacRaporuServis.eraporOnayIstekDVO eraporOnay(ParticipatnFreeDrugReport pfr)
        {
            if (pfr.ProcedureDoctor.Person.UniqueRefNo == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25523", "Doktor Kimlik Numarası Boş Olamaz"));
            }

            IlacRaporuServis.eraporOnayIstekDVO eraporOnayIstekDVO = new IlacRaporuServis.eraporOnayIstekDVO();

            eraporOnayIstekDVO.doktorTcKimlikNo = pfr.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
            eraporOnayIstekDVO.tesisKodu = SystemParameter.GetSaglikTesisKodu().ToString();
            eraporOnayIstekDVO.raporTakipNo = "";

            return eraporOnayIstekDVO;

        }

        public static IlacRaporuServis.eraporOnayRedIstekDVO eraporOnayRed(ParticipatnFreeDrugReport pfr)
        {
            if (pfr.ProcedureDoctor.Person.UniqueRefNo == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25523", "Doktor Kimlik Numarası Boş Olamaz"));
            }

            IlacRaporuServis.eraporOnayRedIstekDVO eraporOnayRedIstekDVO = new IlacRaporuServis.eraporOnayRedIstekDVO();

            eraporOnayRedIstekDVO.doktorTcKimlikNo = pfr.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
            eraporOnayRedIstekDVO.tesisKodu = SystemParameter.GetSaglikTesisKodu().ToString();
            eraporOnayRedIstekDVO.raporTakipNo = "";

            return eraporOnayRedIstekDVO;

        }

        public static IlacRaporuServis.eraporOnayBekleyenListeSorguIstekDVO eraporOnayBekleyenListeSorgu(ParticipatnFreeDrugReport pfr)
        {
            if (pfr.ProcedureDoctor.Person.UniqueRefNo == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25523", "Doktor Kimlik Numarası Boş Olamaz"));
            }

            IlacRaporuServis.eraporOnayBekleyenListeSorguIstekDVO eraporOnayBekleyenListeSorguIstekDVO = new IlacRaporuServis.eraporOnayBekleyenListeSorguIstekDVO();

            eraporOnayBekleyenListeSorguIstekDVO.doktorTcKimlikNo = pfr.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
            eraporOnayBekleyenListeSorguIstekDVO.tesisKodu = SystemParameter.GetSaglikTesisKodu().ToString();

            return eraporOnayBekleyenListeSorguIstekDVO;

        }

        public static IlacRaporuServis.eraporBashekimOnayIstekDVO eraporBashekimOnay(ParticipatnFreeDrugReport pfr)
        {
            if (pfr.ProcedureDoctor.Person.UniqueRefNo == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25523", "Doktor Kimlik Numarası Boş Olamaz"));
            }

            IlacRaporuServis.eraporBashekimOnayIstekDVO eraporBashekimOnayIstekDVO = new IlacRaporuServis.eraporBashekimOnayIstekDVO();

            eraporBashekimOnayIstekDVO.doktorTcKimlikNo = pfr.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
            eraporBashekimOnayIstekDVO.tesisKodu = SystemParameter.GetSaglikTesisKodu().ToString();
            eraporBashekimOnayIstekDVO.raporTakipNo = "";

            return eraporBashekimOnayIstekDVO;

        }


        public static IlacRaporuServis.eraporBashekimOnayRedIstekDVO eraporBashekimOnayRed(ParticipatnFreeDrugReport pfr)
        {
            if (pfr.ProcedureDoctor.Person.UniqueRefNo == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25523", "Doktor Kimlik Numarası Boş Olamaz"));
            }

            IlacRaporuServis.eraporBashekimOnayRedIstekDVO eraporBashekimOnayRedIstekDVO = new IlacRaporuServis.eraporBashekimOnayRedIstekDVO();

            return eraporBashekimOnayRedIstekDVO;

        }

        public static IlacRaporuServis.eraporBashekimOnayBekleyenListeSorguIstekDVO eraporBashekimOnayBekleyenListeSorgu(ParticipatnFreeDrugReport pfr)
        {
            if (pfr.ProcedureDoctor.Person.UniqueRefNo == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25523", "Doktor Kimlik Numarası Boş Olamaz"));
            }

            IlacRaporuServis.eraporBashekimOnayBekleyenListeSorguIstekDVO eraporBashekimOnayBekleyenListeSorguIstekDVO = new IlacRaporuServis.eraporBashekimOnayBekleyenListeSorguIstekDVO();

            eraporBashekimOnayBekleyenListeSorguIstekDVO.doktorTcKimlikNo = pfr.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
            eraporBashekimOnayBekleyenListeSorguIstekDVO.tesisKodu = SystemParameter.GetSaglikTesisKodu().ToString();

            return eraporBashekimOnayBekleyenListeSorguIstekDVO;

        }


        public static IlacRaporuServis.eraporAciklamaEkleIstekDVO eraporAciklamaEkle(ParticipatnFreeDrugReport pfr)
        {
            if (pfr.ProcedureDoctor.Person.UniqueRefNo == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25523", "Doktor Kimlik Numarası Boş Olamaz"));
            }

            IlacRaporuServis.eraporAciklamaEkleIstekDVO eraporAciklamaEkleIstekDVO = new IlacRaporuServis.eraporAciklamaEkleIstekDVO();

            eraporAciklamaEkleIstekDVO.doktorTcKimlikNo = pfr.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
            eraporAciklamaEkleIstekDVO.tesisKodu = SystemParameter.GetSaglikTesisKodu().ToString();
            eraporAciklamaEkleIstekDVO.raporTakipNo = "";

            IlacRaporuServis.eraporAciklamaDVO _eraporAciklamaDVO = new IlacRaporuServis.eraporAciklamaDVO();
            _eraporAciklamaDVO.aciklama = "";
            _eraporAciklamaDVO.takipFormuNo = "";
            eraporAciklamaEkleIstekDVO.eraporAciklamaDVO = _eraporAciklamaDVO;

            return eraporAciklamaEkleIstekDVO;

        }

        public static IlacRaporuServis.eraporEtkinMaddeEkleIstekDVO eraporEtkinMaddeEkle(ParticipatnFreeDrugReport pfr)
        {
            if (pfr.ProcedureDoctor.Person.UniqueRefNo == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25523", "Doktor Kimlik Numarası Boş Olamaz"));
            }

            IlacRaporuServis.eraporEtkinMaddeEkleIstekDVO eraporEtkinMaddeEkleIstekDVO = new IlacRaporuServis.eraporEtkinMaddeEkleIstekDVO();

            eraporEtkinMaddeEkleIstekDVO.doktorTcKimlikNo = pfr.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
            eraporEtkinMaddeEkleIstekDVO.tesisKodu = SystemParameter.GetSaglikTesisKodu().ToString();
            eraporEtkinMaddeEkleIstekDVO.raporTakipNo = "";

            IlacRaporuServis.eraporEtkinMaddeDVO _eraporEtkinMaddeDVO = new IlacRaporuServis.eraporEtkinMaddeDVO();



            eraporEtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO = _eraporEtkinMaddeDVO;

            return eraporEtkinMaddeEkleIstekDVO;

        }

        public static IlacRaporuServis.eraporTaniEkleIstekDVO eraporTaniEkle(ParticipatnFreeDrugReport pfr)
        {
            if (pfr.ProcedureDoctor.Person.UniqueRefNo == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25523", "Doktor Kimlik Numarası Boş Olamaz"));
            }

            IlacRaporuServis.eraporTaniEkleIstekDVO eraporTaniEkleIstekDVO = new IlacRaporuServis.eraporTaniEkleIstekDVO();

            eraporTaniEkleIstekDVO.doktorTcKimlikNo = pfr.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
            eraporTaniEkleIstekDVO.tesisKodu = SystemParameter.GetSaglikTesisKodu().ToString();
            eraporTaniEkleIstekDVO.raporTakipNo = "";

            eraporTaniEkleIstekDVO.raporTeshisKodu = "";

            return eraporTaniEkleIstekDVO;

        }

        public static IlacRaporuServis.eraporTeshisEkleIstekDVO eraporTeshisEkle(ParticipatnFreeDrugReport pfr)
        {
            IlacRaporuServis.eraporTeshisEkleIstekDVO eraporTeshisEkleIstekDVO = new IlacRaporuServis.eraporTeshisEkleIstekDVO();

            return eraporTeshisEkleIstekDVO;

        }


        // Diabet Takip Formu Kaydet


        /*
         * MEDULA Takip Formu Kaydet Giriş DVO Hazırlanması
         * */



        public String getMedulaCode(VarYokEnum varYokEnum)
        {
            if (varYokEnum == VarYokEnum.B)
                return "B";
            else if (varYokEnum == VarYokEnum.V)
                return "V";
            else if (varYokEnum == VarYokEnum.Y)
                return "Y";
            else
                return "";
        }


        public void medulaPaswordForm()
        {

            // eRecetePassword = inpatientPrescription.ERecetePassword;
        }


        //        // Diabet Takip Formu Sil
        //
        //        public void MedulaDiabetTakipFormuSil(){
        //
        //            try
        //            {
        //                Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString());
        //
        //                TakipFormuIslemleri.takipFormuSilGirisDVO takipFormuSilGirisDVO = new TakipFormuIslemleri.takipFormuSilGirisDVO();
        //                takipFormuSilGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
        //                if(this.DiabetesMellitusPursuit != null && !string.IsNullOrEmpty(this.DiabetesMellitusPursuit.takipFormuNo))
        //                    takipFormuSilGirisDVO.takipFormuNo = this.DiabetesMellitusPursuit.takipFormuNo;
        //                else
        //                    throw new Exception("Diabet Takip Formunun Meduladan silme işleminde Takip Formu Numarası alanı dolu olmalıdır.");
        //
        //                TakipFormuIslemleri.takipFormuSilCevapDVO takipFormuSilCevapDVO = TakipFormuIslemleri.WebMethods.takipFormuSil(siteID,takipFormuSilGirisDVO);
        //                if(takipFormuSilCevapDVO != null)
        //                {
        //                    if(string.IsNullOrEmpty(takipFormuSilCevapDVO.sonucKodu) == false)
        //                    {
        //                        if(takipFormuSilCevapDVO.sonucKodu.Equals("0000"))
        //                            InfoBox.Show("Diabet Takip Formu silme işlemi başarılı şekilde yapıldı.", MessageIconEnum.InformationMessage);
        //                        else
        //                        {
        //                            if(string.IsNullOrEmpty(takipFormuSilCevapDVO.sonucMesaji) == false)
        //                                throw new Exception("Diabet Takip Formunun Meduladan silme işleminde hata var. Sonuç Mesajı :"+ takipFormuSilCevapDVO.sonucMesaji);
        //                            else
        //                                throw new Exception("Diabet Takip Formunun Meduladan silme işleminde hata var.");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if(string.IsNullOrEmpty(takipFormuSilCevapDVO.sonucMesaji) == false)
        //                            throw new Exception("Diabet Takip Formunun Meduladan silinmesi işleminde hata var: "+ takipFormuSilCevapDVO.sonucMesaji);
        //                        else
        //                            throw new Exception("Diabet Takip Formunun Meduladan silinmesi sırasında hata oluştu! Sonuç Kodu ve Sonuç Mesajı alanı boş!");
        //                    }
        //
        //                }
        //                else
        //                    throw new Exception("Diabet Takip Formu Meduladan silinemedi!");
        //
        //            }
        //            catch(Exception e){
        //                 InfoBox.Show(e.Message);
        //            }
        //        }

        // Sağlık Kurulu Rapor hizmetini oluşturur
        public void CreateHCReportProcedure()
        {
            Guid procedureCode = ProcedureDefinition.HCReportProcedureObjectId;

            if (ParticipationFreeDrugReportHCProcedures.Any(x => x.CurrentStateDefID != SubActionProcedure.States.Cancelled && x.ProcedureObject.ObjectID.Equals(procedureCode)))
                return;

            HealthCommitteeProcedure pProcedure = new HealthCommitteeProcedure(this, procedureCode.ToString());
            pProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
            pProcedure.PerformedDate = Common.RecTime();
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ParticipatnFreeDrugReport).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if ((fromState == ParticipatnFreeDrugReport.States.Completed && toState == ParticipatnFreeDrugReport.States.SecondDoctorApproval) || (fromState == ParticipatnFreeDrugReport.States.Report && toState == ParticipatnFreeDrugReport.States.SecondDoctorApproval))
                PreTransition_New2SecondDoctorApproval();
            else if (fromState == ParticipatnFreeDrugReport.States.SecondDoctorApproval && toState == ParticipatnFreeDrugReport.States.ThirdDoctorApproval)
                PreTransition_SecondDoctorApproval2ThirdDoctorApproval();
            else if (fromState == ParticipatnFreeDrugReport.States.ThirdDoctorApproval && toState == ParticipatnFreeDrugReport.States.Approval)
                PreTransition_ThirdDoctorApproval2Approval();

        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ParticipatnFreeDrugReport).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (toState == ParticipatnFreeDrugReport.States.New || toState == ParticipatnFreeDrugReport.States.Report)
                PostTransition_2Completed();
            if (toState == ParticipatnFreeDrugReport.States.ReportCompleted)
                PostTransition_2ReportCompleted();

        }

    }
}