//$5158C418
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Infrastructure.Helpers;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using Infrastructure.Models;

namespace Core.Controllers
{
    public partial class MedicalStuffReportServiceController
    {
        partial void PreScript_MedicalStuffReportForm(MedicalStuffReportFormViewModel viewModel, MedicalStuffReport medicalStuffReport, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();

            if (selectedEpisodeActionObjectID.HasValue && viewModel._MedicalStuffReport.MasterAction == null)
            {
                EpisodeAction episodeAction = medicalStuffReport.ObjectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                viewModel._MedicalStuffReport.MasterAction = episodeAction;
                viewModel._MedicalStuffReport.MasterResource = episodeAction.MasterResource;
                viewModel._MedicalStuffReport.FromResource = episodeAction.MasterResource;
                viewModel._MedicalStuffReport.Episode = episodeAction.Episode;
                var P = viewModel._MedicalStuffReport.Episode.Patient;
                viewModel._MedicalStuffReport.ProcedureDoctor = episodeAction.ProcedureDoctor;
                viewModel._MedicalStuffReport.SubEpisode = episodeAction.SubEpisode;
                viewModel._MedicalStuffReport.ActionDate = System.DateTime.Now;

            }

            if (viewModel._MedicalStuffReport.MasterAction is InPatientPhysicianApplication)
            {
                if (((InPatientPhysicianApplication)viewModel._MedicalStuffReport.MasterAction).SubEpisode.InpatientAdmission != null)
                {
                    //viewModel._MedulaTreatmentReport.StartDate = ((InPatientPhysicianApplication)episodeAction).SubEpisode.InpatientAdmission.HospitalInPatientDate;
                    viewModel.minReportDate = ((DateTime)((InPatientPhysicianApplication)viewModel._MedicalStuffReport.MasterAction).SubEpisode.InpatientAdmission.HospitalInPatientDate).ToString("MM.dd.yyyy");
                }
            }
            else
            {
                viewModel.minReportDate = Common.RecTime().ToString("MM.dd.yyyy");
            }

            viewModel.maxReportDate = Common.RecTime().ToString("MM.dd.yyyy");



            //tanı kontrolü
            medicalStuffReport.CheckForDiagnosis();

            FillReportList(objectContext, viewModel);

            if (viewModel._MedicalStuffReport.StartDate == null)
                viewModel._MedicalStuffReport.StartDate = DateTime.Now;
            if (viewModel._MedicalStuffReport.EndDate == null)
                viewModel._MedicalStuffReport.EndDate = DateTime.Now.AddYears(1);
            if (Common.CurrentUser.IsSuperUser != true)
            {
                viewModel.IsSuperUser = false;
                if (Common.CurrentResource.UserType == UserTypeEnum.Doctor || Common.CurrentResource.UserType == UserTypeEnum.Dentist)
                {
                    if (viewModel._MedicalStuffReport.ProcedureDoctor == null)
                    {
                        viewModel._MedicalStuffReport.ProcedureDoctor = Common.CurrentResource;
                    }
                }
            }
            else
                viewModel.IsSuperUser = true;

            if (medicalStuffReport.CurrentStateDefID == null)
                medicalStuffReport.CurrentStateDefID = MedicalStuffReport.States.New;

            if (medicalStuffReport.CurrentStateDefID == MedicalStuffReport.States.SecondDoctorApproval)
            {
                viewModel.isStateSecondDoctorApproval = true;
                viewModel.isStateHeadDoctorApproval = false;
                viewModel.isStateThirdDoctorApproval = false;
            }
            else if (medicalStuffReport.CurrentStateDefID == MedicalStuffReport.States.ThirdDoctorApproval)
            {
                viewModel.isStateThirdDoctorApproval = true;
                viewModel.isStateHeadDoctorApproval = false;
                viewModel.isStateSecondDoctorApproval = false;
            }
            else if (medicalStuffReport.CurrentStateDefID == MedicalStuffReport.States.HeadDoctorApproval)
            {
                viewModel.isStateHeadDoctorApproval = true;
                viewModel.isStateThirdDoctorApproval = false;
                viewModel.isStateSecondDoctorApproval = false;
            }
            else
            {
                viewModel.isStateHeadDoctorApproval = false;
                viewModel.isStateThirdDoctorApproval = false;
                viewModel.isStateSecondDoctorApproval = false;
            }

            if (medicalStuffReport.CurrentStateDefID == MedicalStuffReport.States.Complete)
            {
                viewModel.isPrescriptionWriteable = true;
            }
            else
            {
                viewModel.isPrescriptionWriteable = false;
            }

            if(viewModel._MedicalStuffReport.CommitteeReport == true)
            {
                viewModel.secondDoctor = viewModel._MedicalStuffReport.SecondDoctor.UniqueNo;
                viewModel.thirdDoctor = viewModel._MedicalStuffReport.ThirdDoctor.UniqueNo;
            }
            var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, viewModel._MedicalStuffReport.ObjectDef.ID, "MedicalStuffReportTemplate").ToList();
            viewModel.userTemplateList = new List<UserTemplateModel>();
            foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList.Where(t => t.TAObjectID.ToString() != viewModel._MedicalStuffReport.ObjectID.ToString()))
            {
                UserTemplateModel templateModel = new UserTemplateModel();
                templateModel.ObjectID = item.ObjectID;
                templateModel.TAObjectID = item.TAObjectID;
                templateModel.TAObjectDefID = item.TAObjectDefID;
                templateModel.Description = item.Description;
                viewModel.userTemplateList.Add(templateModel);
            }
            ContextToViewModel(viewModel, objectContext);
            //viewModel.MedicalStuffGridGridList = viewModel.MedicalStuffGridGridList;

        }
        partial void PostScript_MedicalStuffReportForm(MedicalStuffReportFormViewModel viewModel, MedicalStuffReport medicalStuffReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            List<MedicalStuff> medicalStuffList;
            MedicalStuffReport tempObject = objectContext.GetObject<MedicalStuffReport>(medicalStuffReport.ObjectID);
            if (tempObject != null)
            {
                medicalStuffList = tempObject.MedicalStuff.ToList();
                foreach (MedicalStuff stuff in medicalStuffList)
                {
                    var check = viewModel.MedicalStuffGridGridList.Where(t => t.ObjectID == stuff.ObjectID).FirstOrDefault();
                    if (check == null)
                    {
                        stuff.MedicalStuffReport = null;
                    }
                }
            }
            ReportDiagnosisServiceController diagnosis = new ReportDiagnosisServiceController();
            diagnosis.SaveDiagnosis(viewModel.reportDiagnosisFormViewModel, medicalStuffReport);

            if (medicalStuffReport.CurrentStateDefID == null)
                medicalStuffReport.CurrentStateDefID = MedicalStuffReport.States.New;

            if (medicalStuffReport.ProcedureByUser == null)//rapru ilk oluşturan kişi
            {
                medicalStuffReport.ProcedureByUser = Common.CurrentResource;
            }

            /*  BindingList<MedicalStuffDefinition> medicalStuffDefinitionList = MedicalStuffDefinition.GetMedicalStuffDefByCode(objectContext, viewModel._MedicalStuffReport.StuffCode);
              medicalStuffReport.MedicalStuffDef = medicalStuffDefinitionList[0];*/

            //objectContext.Save();

            /*if (medicalStuffReport.CurrentStateDefID == MedicalStuffReport.States.New)
                medicalStuffReport.CurrentStateDefID = MedicalStuffReport.States.ReportComplete;

            if (viewModel.ToState == MedicalStuffReport.States.ReportComplete)
                medicalStuffReport.CurrentStateDefID = MedicalStuffReport.States.ReportComplete;

            if (viewModel.ToState == MedicalStuffReport.States.Complete)
            {
                medicalStuffReport.CurrentStateDefID = MedicalStuffReport.States.Complete;
        
            }  */

        }

        void FillReportList(TTObjectContext objectContext, MedicalStuffReportFormViewModel viewModel)
        {
            var patientReportList = MedicalStuffReport.GetReportListByPatient(viewModel._MedicalStuffReport.SubEpisode.Episode.Patient.ObjectID).ToList();
            foreach (var item in patientReportList)
            {
                if (viewModel.MedicalStuffReportList == null)
                    viewModel.MedicalStuffReportList = new List<PatientMedicalStuffReportClass>();
                PatientMedicalStuffReportClass patientMedicalStuffReport = new PatientMedicalStuffReportClass();
                patientMedicalStuffReport.ObjectID = item.ObjectID;
                patientMedicalStuffReport.RaporTakipno = item.RaporTakipNo;
                patientMedicalStuffReport.ReportNo = item.ReportNo;
                patientMedicalStuffReport.StartDate = item.StartDate;
                patientMedicalStuffReport.EndDate = item.EndDate;
                patientMedicalStuffReport.Proceduredoctor = item.Proceduredoctor;
                patientMedicalStuffReport.Seconddoctor = item.Seconddoctor;
                patientMedicalStuffReport.Thirddoctor = item.Thirddoctor;
                patientMedicalStuffReport.IsSendedMedula = item.IsSendedMedula;
                viewModel.MedicalStuffReportList.Add(patientMedicalStuffReport);
            }
        }


        [HttpPost]
        public bool Cancel(MedicalStuffReport medicalStuffReport)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {

                    var medicalStuffReportImported = (MedicalStuffReport)objectContext.AddObject(medicalStuffReport);
                    medicalStuffReportImported.CurrentStateDefID = MedicalStuffReport.States.Cancel;

                    if (medicalStuffReportImported.RaporTakipNo != null && medicalStuffReportImported.RaporTakipNo != "")
                    {
                        throw new TTUtils.TTException("Medulada rapor kaydı bulunan raporlar iptal edilemez.Raporu önce Meduladan siliniz.");
                    }



                    objectContext.Save();

                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public BindingList<MedicalStuffReport.GetMedicalStuffReportListByID_Class> GetEReportList(MedicalStuffReportFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    return MedicalStuffReport.GetMedicalStuffReportListByID(viewModel._MedicalStuffReport.SubEpisode.ObjectID);

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public string PrepareSignedDeleteReportContent(PrepareSignedDeleteReportContent_Input input)
        {
            string output = string.Empty;

            var signDeleteContent = MedicalStuffReport.GetERaporSignedDeleteRequestERaporTakipNo(input.eRaporTakipNo);
            output = signDeleteContent;
            return output;
        }

        [HttpPost]
        public bool SendSignedDeleteReportContent(SendSignedDeleteReportContent_Input input)
        {
            var signedData = Convert.FromBase64String(input.singContent);
            bool output = SendSignedDeleteERaporWithERaporTakipNo(signedData);
            return output;
        }

        public bool SendSignedDeleteERaporWithERaporTakipNo(byte[] signedContent)
        {
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            bool error = false;

            TibbiMalzemeERaporIslemleri.imzaliERaporSilIstekDVO eReportSignedDeleteRequest = new TibbiMalzemeERaporIslemleri.imzaliERaporSilIstekDVO();
            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            eReportSignedDeleteRequest.tesisKodu = Convert.ToString(saglikTesisKodu);
            eReportSignedDeleteRequest.doktorTcKimlikNo = currentUser.UniqueNo;
            eReportSignedDeleteRequest.surumNumarasi = "1";
            eReportSignedDeleteRequest.imzaliErapor = signedContent;
            eReportSignedDeleteRequest.surumNumarasi = "1";

            TibbiMalzemeERaporIslemleri.imzaliERaporSilCevapDVO resOnay = TibbiMalzemeERaporIslemleri.WebMethods.imzaliERaporSilSync(Sites.SiteLocalHost, currentUser.UniqueNo, currentUser.ErecetePassword, eReportSignedDeleteRequest);
            if (resOnay != null)
            {
                if (resOnay.sonucKodu.Equals("0000"))
                    error = true;
            }

            return error;
        }

        [HttpPost]
        public string PrepareSignedSearchReportContentUrl(PrepareSignedSearchReportContent_Input input)
        {
            string output = string.Empty;

            var signSearchContent = MedicalStuffReport.GetERaporSignedSearchRequestERaporTakipNo(input.eRaporTakipNo);
            output = signSearchContent;
            return output;
        }

        [HttpPost]
        public bool SendSignedSearchReportContent(SendSignedSearchReportContent_Input input)
        {
            var signedData = Convert.FromBase64String(input.singContent);
            bool output = SendSignedSearchERaporWithERaporTakipNo(input.MedicalStuffReportFormViewModel, signedData);
            return output;
        }

        public bool SendSignedSearchERaporWithERaporTakipNo(MedicalStuffReportFormViewModel viewModel, byte[] signedContent)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                bool error = false;
                var medicalStuffReport = (MedicalStuffReport)objectContext.GetObject<MedicalStuffReport>(viewModel._MedicalStuffReport.ObjectID);

                TibbiMalzemeERaporIslemleri.imzaliERaporSorguIstekDVO eReportSignedSearchRequest = new TibbiMalzemeERaporIslemleri.imzaliERaporSorguIstekDVO();
                long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                eReportSignedSearchRequest.tesisKodu = Convert.ToString(saglikTesisKodu);
                eReportSignedSearchRequest.doktorTcKimlikNo = currentUser.UniqueNo;
                eReportSignedSearchRequest.surumNumarasi = "1";
                eReportSignedSearchRequest.imzaliEraporSorgula = signedContent;

                TibbiMalzemeERaporIslemleri.imzaliERaporSorguCevapDVO resSorgu = TibbiMalzemeERaporIslemleri.WebMethods.imzaliERaporSorguSync(Sites.SiteLocalHost, currentUser.UniqueNo, currentUser.ErecetePassword, eReportSignedSearchRequest);
                if (resSorgu != null)
                {
                    if (resSorgu.sonucKodu.Equals("0000"))
                    {
                        if (resSorgu.raporListesi != null && resSorgu.raporListesi.Length != 0)
                        {

                        }
                        error = true;
                    }
                }

                return error;
            }
        }

        [HttpPost]
        public string PrepareSignedReportContent(PrepareSignedReportContent_Input input)
        {
            string output = string.Empty;

            Guid? selectedEpisodeActionObjectID = Request.Headers.GetSelectedEpisodeActionID();

            var signSearchContent = MedicalStuffReport.GetERaporSignedRequestERaporTakipNo(input.eRaporObjectID, selectedEpisodeActionObjectID);
            output = signSearchContent;
            return output;
        }

        [HttpPost]
        public bool SendSignedReportContent(SendSignedReportContent_Input input)
        {
            var signedData = Convert.FromBase64String(input.singContent);
            bool output = SendSignedERapor(input.MedicalStuffReportFormViewModel, signedData);
            return output;
        }

        public bool SendSignedERapor(MedicalStuffReportFormViewModel viewModel, byte[] signedContent)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                bool error = false;
                var medicalStuffReport = (MedicalStuffReport)objectContext.GetObject<MedicalStuffReport>(viewModel._MedicalStuffReport.ObjectID);

                TibbiMalzemeERaporIslemleri.imzaliERaporGirisIstekDVO eReportSignedRequest = new TibbiMalzemeERaporIslemleri.imzaliERaporGirisIstekDVO();
                long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                eReportSignedRequest.tesisKodu = Convert.ToString(saglikTesisKodu);
                eReportSignedRequest.doktorTcKimlikNo = currentUser.UniqueNo;
                eReportSignedRequest.surumNumarasi = "1";
                eReportSignedRequest.imzaliErapor = signedContent;


                var b = TTUtils.SerializationHelper.XmlSerializeObject(eReportSignedRequest);

                TibbiMalzemeERaporIslemleri.imzaliERaporGirisCevapDVO resSorgu = TibbiMalzemeERaporIslemleri.WebMethods.imzaliERaporGirisSync(Sites.SiteLocalHost, currentUser.UniqueNo, currentUser.ErecetePassword, eReportSignedRequest);
                if (resSorgu != null)
                {
                    var a = TTUtils.SerializationHelper.XmlSerializeObject(resSorgu);
                    if (resSorgu.sonucKodu.Equals("0000"))
                    {
                        if (resSorgu.eRaporDVO != null)
                        {
                            medicalStuffReport.RaporTakipNo = resSorgu.eRaporDVO.raporTakipNo.ToString();
                            medicalStuffReport.RaporGelenXML = TTUtils.SerializationHelper.XmlSerializeObject(resSorgu);
                            medicalStuffReport.RaporGidenXML = TTUtils.SerializationHelper.XmlSerializeObject(eReportSignedRequest);
                            medicalStuffReport.IsSendedMedula = true;

                            ReportDiagnosisServiceController reportDiagnosisService = new ReportDiagnosisServiceController();
                            reportDiagnosisService.SaveDiagnosis(viewModel.reportDiagnosisFormViewModel, medicalStuffReport);

                            objectContext.Update();
                            if (medicalStuffReport.CommitteeReport != null && medicalStuffReport.CommitteeReport == true)
                            {
                                medicalStuffReport.CurrentStateDefID = MedicalStuffReport.States.SecondDoctorApproval;
                            }
                            else
                            {
                                medicalStuffReport.CurrentStateDefID = MedicalStuffReport.States.HeadDoctorApproval;
                            }
                            objectContext.Update();
                        }
                        error = true;
                    }
                }

                return error;
            }
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Medula_Raporlari_Takip_No_ile_Kaydet)]
        public MedulaResult eRaporGiris(MedicalStuffReportFormViewModel viewModel)
        {
            MedulaResult model = new MedulaResult();
            try
            {
                ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                using (var objectContext = new TTObjectContext(false))
                {

                    var medicalStuffReport = (MedicalStuffReport)objectContext.GetObject<MedicalStuffReport>(viewModel._MedicalStuffReport.ObjectID);

                    TibbiMalzemeERaporIslemleri.eRaporGirisIstekDVO raporGirisDVO = new TibbiMalzemeERaporIslemleri.eRaporGirisIstekDVO();
                    TibbiMalzemeERaporIslemleri.eRaporGirisDVO _raporDVO = new TibbiMalzemeERaporIslemleri.eRaporGirisDVO();
                    ResUser tabip = medicalStuffReport.ProcedureDoctor;


                    SubEpisode se = medicalStuffReport.SubEpisode;
                    SubEpisodeProtocol sep = se.LastActiveSubEpisodeProtocolByCloneType;

                    if (sep != null && (sep.MedulaTakipNo == null || sep.MedulaTakipNo == ""))
                    {
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25844", "Hastanın medula provizyon numarası bulunmamaktadır.Hastaya provizyon alınız."));
                    }

                    Episode e = medicalStuffReport.Episode;
                    long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                    raporGirisDVO.tesisKodu = Convert.ToInt32(saglikTesisKodu); //Convert.ToInt32(11068891);

                    raporGirisDVO.doktorTcKimlikNo = tabip.UniqueNo;

                    _raporDVO.tcKimlikNo = Convert.ToInt64(e.Patient.UniqueRefNo);

                    if (medicalStuffReport.Description != null)
                        _raporDVO.aciklama = TTReportTool.TTReport.HTMLtoText(medicalStuffReport.Description.ToString());

                    TibbiMalzemeERaporIslemleri.doktorDVO _doktorBilgisiDVO = new TibbiMalzemeERaporIslemleri.doktorDVO();
                    List<TibbiMalzemeERaporIslemleri.doktorDVO> _doktorBilgisiDVOList = new List<TibbiMalzemeERaporIslemleri.doktorDVO>();
                    _doktorBilgisiDVO.adi = tabip.Person != null ? tabip.Person.Name : "";
                    _doktorBilgisiDVO.bransAdi = tabip.GetSpeciality() != null ? tabip.GetSpeciality().Name : "";
                    _doktorBilgisiDVO.bransKodu = tabip.GetSpeciality() != null ? tabip.GetSpeciality().Code : "";
                    _doktorBilgisiDVO.soyadi = tabip.Person != null ? tabip.Person.Surname : "";
                    _doktorBilgisiDVO.tcKimlikNo = tabip.Person.UniqueRefNo.ToString();
                    _doktorBilgisiDVOList.Add(_doktorBilgisiDVO);

                    TibbiMalzemeERaporIslemleri.doktorDVO _doktorBilgisiDVO2 = new TibbiMalzemeERaporIslemleri.doktorDVO();
                    ResUser tabip2 = medicalStuffReport.SecondDoctor;
                    if (tabip2 != null)
                    {
                        _doktorBilgisiDVO2.adi = tabip2.Person != null ? tabip2.Person.Name : "";
                        _doktorBilgisiDVO2.bransAdi = tabip2.GetSpeciality() != null ? tabip2.GetSpeciality().Name : "";
                        _doktorBilgisiDVO2.bransKodu = tabip2.GetSpeciality() != null ? tabip2.GetSpeciality().Code : "";
                        _doktorBilgisiDVO2.soyadi = tabip2.Person != null ? tabip2.Person.Surname : "";
                        _doktorBilgisiDVO2.tcKimlikNo = tabip2.Person.UniqueRefNo.ToString();
                        _doktorBilgisiDVOList.Add(_doktorBilgisiDVO2);
                    }

                    TibbiMalzemeERaporIslemleri.doktorDVO _doktorBilgisiDVO3 = new TibbiMalzemeERaporIslemleri.doktorDVO();
                    ResUser tabip3 = medicalStuffReport.ThirdDoctor;
                    if (tabip3 != null)
                    {
                        _doktorBilgisiDVO3.adi = tabip3.Person != null ? tabip3.Person.Name : "";
                        _doktorBilgisiDVO3.bransAdi = tabip3.GetSpeciality() != null ? tabip3.GetSpeciality().Name : "";
                        _doktorBilgisiDVO3.bransKodu = tabip3.GetSpeciality() != null ? tabip3.GetSpeciality().Code : "";
                        _doktorBilgisiDVO3.soyadi = tabip3.Person != null ? tabip3.Person.Surname : "";
                        _doktorBilgisiDVO3.tcKimlikNo = tabip3.Person.UniqueRefNo.ToString();
                        _doktorBilgisiDVOList.Add(_doktorBilgisiDVO3);
                    }
                    _raporDVO.doktorListesi = _doktorBilgisiDVOList.ToArray();


                    List<TibbiMalzemeERaporIslemleri.eMalzemeGirisDVO> _malzemeBilgisiDVOList = new List<TibbiMalzemeERaporIslemleri.eMalzemeGirisDVO>();
                    if (medicalStuffReport.MedicalStuff != null)
                    {
                        foreach (MedicalStuff item in medicalStuffReport.MedicalStuff)
                        {
                            TibbiMalzemeERaporIslemleri.eMalzemeGirisDVO _malzemeBilgisiDVO = new TibbiMalzemeERaporIslemleri.eMalzemeGirisDVO();
                            _malzemeBilgisiDVO.adet = item.StuffAmount.Value;
                            _malzemeBilgisiDVO.degistirmeRaporu = "H";
                            _malzemeBilgisiDVO.kullanimPeriyodu = item.PeriodUnit;
                            if (item.PeriodUnitType == PeriodUnitTypeEnum.DayPeriod)
                            {
                                _malzemeBilgisiDVO.kullanimPeriyodBirim = 1;
                            }
                            else if (item.PeriodUnitType == PeriodUnitTypeEnum.WeekPeriod)
                            {
                                _malzemeBilgisiDVO.kullanimPeriyodBirim = 2;
                            }
                            else if (item.PeriodUnitType == PeriodUnitTypeEnum.MonthPeriod)
                            {
                                _malzemeBilgisiDVO.kullanimPeriyodBirim = 3;
                            }
                            else if (item.PeriodUnitType == PeriodUnitTypeEnum.YearPeriod)
                            {
                                _malzemeBilgisiDVO.kullanimPeriyodBirim = 4;
                            }
                            else
                            {
                                _malzemeBilgisiDVO.kullanimPeriyodBirim = 0;
                            }
                            _malzemeBilgisiDVO.kullanimYeri = item.MedicalStuffPlaceOfUsage.Code;
                            _malzemeBilgisiDVO.sutKodu = item.MedicalStuffDef.Code.ToString();
                            if (item.MedicalStuffUsageType != null)
                                _malzemeBilgisiDVO.kullanimSekli = item.MedicalStuffUsageType.Code;
                            _malzemeBilgisiDVOList.Add(_malzemeBilgisiDVO);
                        }
                    }
                    _raporDVO.malzemeListesi = _malzemeBilgisiDVOList.ToArray();

                    List<TibbiMalzemeERaporIslemleri.eTaniDVO> taniBilgisiDVOList = new List<TibbiMalzemeERaporIslemleri.eTaniDVO>();
                    List<string> taniList = new List<string>();
                    if (viewModel.reportDiagnosisFormViewModel != null)
                    {
                        foreach (ReportDiagnosisGridListViewModel item in viewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList)
                        {
                            taniList.Add(item.DiagnoseCode);
                        }

                        taniList = Common.DiagnosesForMedula(taniList);
                        foreach (string taniItem in taniList)
                        {
                            TibbiMalzemeERaporIslemleri.eTaniDVO taniBilgisiDVO = new TibbiMalzemeERaporIslemleri.eTaniDVO();
                            taniBilgisiDVO.taniKodu = taniItem;
                            taniBilgisiDVOList.Add(taniBilgisiDVO);
                        }

                        _raporDVO.taniListesi = taniBilgisiDVOList.ToArray();
                    }

                    _raporDVO.raporTarihi = ((DateTime)medicalStuffReport.StartDate).ToString("dd.MM.yyyy");
                    _raporDVO.raporBitisTarihi = ((DateTime)medicalStuffReport.EndDate).ToString("dd.MM.yyyy");
                    if (medicalStuffReport.CommitteeReport != null && medicalStuffReport.CommitteeReport == true)
                    {
                        _raporDVO.raporDuzenlemeTuruKodu = 1;
                    }
                    else
                    {
                        _raporDVO.raporDuzenlemeTuruKodu = 2;
                    }
                    long value = Convert.ToInt64((TTSequence.GetNextSequenceValueFromDatabase(TTDefinitionManagement.TTObjectDefManager.Instance.DataTypes["MedicalStuffSequence"], null, null)));
                    _raporDVO.raporNo = (medicalStuffReport.ReportNo != null) ? medicalStuffReport.ReportNo.ToString() : value.ToString();
                    _raporDVO.raporOnayDurumu = "";
                    // _raporDVO.raporTakipNo = "";
                    _raporDVO.protokolNo = se.ProtocolNo.ToString();
                    _raporDVO.tesisKodu = Convert.ToInt32(saglikTesisKodu);
                    _raporDVO.takipNo = sep.MedulaTakipNo;
                    raporGirisDVO.eRaporDVO = _raporDVO;

                    string username = "";
                    string password = "";
                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((viewModel.medulaUsername != null && viewModel.medulaUsername != "") || (viewModel.medulaPassword != null && viewModel.medulaPassword != ""))
                        {
                            username = viewModel.medulaUsername;
                            password = viewModel.medulaPassword;
                        }
                        else
                        {
                            throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(medicalStuffReport.ProcedureDoctor.ErecetePassword))
                        {
                            throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");

                        }
                        username = medicalStuffReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                        if (!string.IsNullOrEmpty(medicalStuffReport.ProcedureDoctor.ErecetePassword))
                            password = medicalStuffReport.ProcedureDoctor.ErecetePassword;
                    }

                    TibbiMalzemeERaporIslemleri.eRaporGirisCevapDVO response = TibbiMalzemeERaporIslemleri.WebMethods.eRaporGirisSync(TTObjectClasses.Sites.SiteLocalHost, username, password, raporGirisDVO);

                    if (response != null)
                    {
                        if (response.sonucKodu == "0000")
                        {
                            medicalStuffReport.RaporTakipNo = response.eRaporDVO.raporTakipNo.ToString();
                            medicalStuffReport.RaporGelenXML = TTUtils.SerializationHelper.XmlSerializeObject(response);
                            medicalStuffReport.RaporGidenXML = TTUtils.SerializationHelper.XmlSerializeObject(raporGirisDVO);
                            medicalStuffReport.IsSendedMedula = true;

                            ReportDiagnosisServiceController a = new ReportDiagnosisServiceController();
                            a.SaveDiagnosis(viewModel.reportDiagnosisFormViewModel, medicalStuffReport);

                            if (medicalStuffReport.CommitteeReport != null && medicalStuffReport.CommitteeReport == true)
                            {
                                medicalStuffReport.CurrentStateDefID = MedicalStuffReport.States.SecondDoctorApproval;
                            }
                            else
                            {
                                medicalStuffReport.CurrentStateDefID = MedicalStuffReport.States.HeadDoctorApproval;
                            }
                        }
                        model.SonucKodu = response.sonucKodu;
                        model.SonucMesaji = response.sonucMesaji;
                        if (response.eRaporDVO != null)
                            model.TakipNo = response.eRaporDVO.raporTakipNo;
                    }

                    viewModel._MedicalStuffReport = medicalStuffReport;

                    objectContext.Save();

                    return model;
                }
            }
            catch (Exception e)
            {
                if (e != null)
                    TTUtils.InfoMessageService.Instance.ShowMessage(e.ToString());
                return null;
            }
        }

        [HttpGet]
        public MedicalStuffReport GetMedicalStuffReportObject(string reportNo)
        {
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var medicalStuffReport = MedicalStuffReport.GetObjectByRaporTakipno(objectContext, reportNo);
                    if (medicalStuffReport != null)
                    {
                        return ((MedicalStuffReport)medicalStuffReport[0]);
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                if (e != null)
                    TTUtils.InfoMessageService.Instance.ShowMessage(e.ToString());
                return null;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Medula_Raporlari_Sil)]
        public MedulaResult eRaporSil(MedicalStuffReportFormViewModel viewModel)
        {
            MedulaResult model = new MedulaResult();

            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var medicalStuffReport = (MedicalStuffReport)objectContext.GetObject<MedicalStuffReport>(viewModel._MedicalStuffReport.ObjectID);


                    if (String.IsNullOrEmpty(medicalStuffReport.RaporTakipNo))
                    {
                        throw new TTUtils.TTException("Medula rapor takip numarası bulunamaıştır.");
                    }

                    TibbiMalzemeERaporIslemleri.eRaporSorguIstekDVO eRaporSilDVO = new TibbiMalzemeERaporIslemleri.eRaporSorguIstekDVO();
                    ResUser tabip = medicalStuffReport.ProcedureDoctor;
                    ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;

                    long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                    eRaporSilDVO.tesisKodu = saglikTesisKodu.ToString();
                    eRaporSilDVO.raporTakipNo = medicalStuffReport.RaporTakipNo;
                    eRaporSilDVO.doktorTcKimlikNo = medicalStuffReport.ProcedureDoctor.UniqueNo;
                    string username = "";
                    string password = "";

                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((viewModel.medulaUsername != null && viewModel.medulaUsername != "") || (viewModel.medulaPassword != null && viewModel.medulaPassword != ""))
                        {
                            eRaporSilDVO.doktorTcKimlikNo = viewModel.medulaUsername;   //currentUser.UniqueNo;
                            username = viewModel.medulaUsername;
                            password = viewModel.medulaPassword;
                        }
                        else
                        {
                            throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                        }
                    }
                    else
                    {
                        eRaporSilDVO.doktorTcKimlikNo = medicalStuffReport.ProcedureDoctor.UniqueNo;
                        username = medicalStuffReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                        if (!string.IsNullOrEmpty(medicalStuffReport.ProcedureDoctor.ErecetePassword))
                            password = medicalStuffReport.ProcedureDoctor.ErecetePassword;
                    }
                    TibbiMalzemeERaporIslemleri.eRaporCevapDVO response = TibbiMalzemeERaporIslemleri.WebMethods.eRaporSilSync(TTObjectClasses.Sites.SiteLocalHost, username, password, eRaporSilDVO);

                    if (response != null)
                    {
                        if (response.sonucKodu == "0000")
                        {
                            medicalStuffReport.RaporGelenXML = TTUtils.SerializationHelper.XmlSerializeObject(response);
                            medicalStuffReport.RaporGidenXML = TTUtils.SerializationHelper.XmlSerializeObject(eRaporSilDVO);
                            medicalStuffReport.CurrentStateDefID = MedicalStuffReport.States.New;
                            medicalStuffReport.IsSecondDoctorApproved = false;
                            medicalStuffReport.IsThirdDoctorApproved = false;
                            medicalStuffReport.RaporTakipNo = null;
                        }
                        model.SonucKodu = response.sonucKodu;
                        model.SonucMesaji = response.sonucMesaji;
                    }
                    viewModel._MedicalStuffReport = medicalStuffReport;

                    objectContext.Save();

                    return model;
                }
            }
            catch (Exception e)
            {
                if (e != null)
                    TTUtils.InfoMessageService.Instance.ShowMessage(e.ToString());
                return null;
            }
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Medula_Raporlari_Takip_No_ile_Kaydet)]
        public MedulaResult eRaporSorgu(MedicalStuffReportFormViewModel viewModel)
        {
            MedulaResult model = new MedulaResult();
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var medicalStuffReport = (MedicalStuffReport)objectContext.GetObject<MedicalStuffReport>(viewModel._MedicalStuffReport.ObjectID);

                    TibbiMalzemeERaporIslemleri.eRaporSorguIstekDVO eRaporSorguDVO = new TibbiMalzemeERaporIslemleri.eRaporSorguIstekDVO();
                    ResUser tabip = medicalStuffReport.ProcedureDoctor;
                    long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                    eRaporSorguDVO.tesisKodu = Convert.ToString(saglikTesisKodu);
                    ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;

                    eRaporSorguDVO.doktorTcKimlikNo = currentUser.UniqueNo;

                    if (String.IsNullOrEmpty(medicalStuffReport.RaporTakipNo))
                    {
                        throw new TTUtils.TTException("Medulada rapor takip numarası bulunamaıştır.");
                    }

                    eRaporSorguDVO.raporTakipNo = medicalStuffReport.RaporTakipNo;

                    TibbiMalzemeERaporIslemleri.eRaporSorguCevapDVO response = TibbiMalzemeERaporIslemleri.WebMethods.eRaporSorgulaSync(TTObjectClasses.Sites.SiteLocalHost, currentUser.UniqueNo, currentUser.ErecetePassword, eRaporSorguDVO);

                    if (response != null)
                    {
                        if (response.sonucKodu.Equals(0000))
                        {
                            medicalStuffReport.RaporGelenXML = TTUtils.SerializationHelper.XmlSerializeObject(response);
                            medicalStuffReport.RaporGidenXML = TTUtils.SerializationHelper.XmlSerializeObject(eRaporSorguDVO);
                            medicalStuffReport.IsSendedMedula = true;

                            ReportDiagnosisServiceController a = new ReportDiagnosisServiceController();
                            a.SaveDiagnosis(viewModel.reportDiagnosisFormViewModel, medicalStuffReport);

                        }
                        model.SonucKodu = response.sonucKodu;
                        model.SonucMesaji = response.sonucMesaji;


                    }
                    viewModel._MedicalStuffReport = medicalStuffReport;

                    objectContext.Save();

                    return model;
                }
            }
            catch (Exception e)
            {
                if (e != null)
                    TTUtils.InfoMessageService.Instance.ShowMessage(e.ToString());
                return null;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Medula_Raporlari_Takip_No_ile_Kaydet)]
        public MedulaResult eRaporListeSorgu(MedicalStuffReportFormViewModel viewModel)
        {
            MedulaResult model = new MedulaResult();
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var medicalStuffReport = (MedicalStuffReport)objectContext.GetObject<MedicalStuffReport>(viewModel._MedicalStuffReport.ObjectID);

                    TibbiMalzemeERaporIslemleri.eRaporListeSorguIstekDVO eRaporListeSorguIstekDVO = new TibbiMalzemeERaporIslemleri.eRaporListeSorguIstekDVO();
                    ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;

                    ResUser tabip = medicalStuffReport.ProcedureDoctor;
                    long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                    eRaporListeSorguIstekDVO.tesisKodu = Convert.ToString(saglikTesisKodu);
                    eRaporListeSorguIstekDVO.doktorTcKimlikNo = currentUser.UniqueNo;
                    EpisodeAction episodeAction = medicalStuffReport.ObjectContext.GetObject<EpisodeAction>(viewModel._MedicalStuffReport.ObjectID);
                    Episode e = episodeAction.Episode;
                    eRaporListeSorguIstekDVO.hastaTcKimlikNo = e.Patient.UniqueRefNo.ToString();

                    TibbiMalzemeERaporIslemleri.eRaporSorguCevapDVO response = TibbiMalzemeERaporIslemleri.WebMethods.eRaporListeSorgulaSync(TTObjectClasses.Sites.SiteLocalHost, currentUser.UniqueNo, currentUser.ErecetePassword, eRaporListeSorguIstekDVO);

                    if (response != null)
                    {
                        if (response.sonucKodu.Equals(0000))
                        {
                            medicalStuffReport.RaporGelenXML = TTUtils.SerializationHelper.XmlSerializeObject(response);
                            medicalStuffReport.RaporGidenXML = TTUtils.SerializationHelper.XmlSerializeObject(eRaporListeSorguIstekDVO);
                            medicalStuffReport.IsSendedMedula = true;


                            ReportDiagnosisServiceController a = new ReportDiagnosisServiceController();
                            a.SaveDiagnosis(viewModel.reportDiagnosisFormViewModel, medicalStuffReport);

                            model.eRaporDVO = response.raporCevap.ToList();
                        }
                        model.SonucKodu = response.sonucKodu;
                        model.SonucMesaji = response.sonucMesaji;

                    }
                    viewModel._MedicalStuffReport = medicalStuffReport;

                    objectContext.Save();

                    return model;
                }
            }
            catch (Exception e)
            {
                if (e != null)
                    TTUtils.InfoMessageService.Instance.ShowMessage(e.ToString());
                return null;
            }
        }

        [HttpPost]

        public string getUniqueRefnoOfApproveUser(MedicalStuffReport report)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                MedicalStuffReport reportObj = objectContext.GetObject<MedicalStuffReport>(report.ObjectID);
                if (reportObj.CurrentStateDefID == MedicalStuffReport.States.SecondDoctorApproval)
                {
                    return reportObj.SecondDoctor.UniqueNo;
                }
                else if (reportObj.CurrentStateDefID == MedicalStuffReport.States.ThirdDoctorApproval)
                {
                    return reportObj.ThirdDoctor.UniqueNo;
                }
                else
                {
                    return reportObj.ProcedureDoctor.UniqueNo;
                }
            }
        }

        [HttpPost]
        public TibbiMalzemeERaporIslemleri.eRaporOnayCevapDVO Onay(MedicalStuffReportApproveModel approveModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    ResUser currentUser = Common.CurrentResource;
                    var medicalStuffReportObj = (MedicalStuffReport)objectContext.AddObject(approveModel.medicalStuffReport);
                    string password = "";
                    string uniqueRefNo = "";
                    if (medicalStuffReportObj.RaporTakipNo != null && medicalStuffReportObj.RaporTakipNo != "")
                    {
                        TibbiMalzemeERaporIslemleri.eRaporOnayIstekDVO eRaporOnayIstekDVO = new TibbiMalzemeERaporIslemleri.eRaporOnayIstekDVO();
                        eRaporOnayIstekDVO.tesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                        eRaporOnayIstekDVO.raporTakipNo = medicalStuffReportObj.RaporTakipNo;
                        eRaporOnayIstekDVO.onayKod = 2;


                        var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                        if (MedulaPasswordCheck == "TRUE")
                        {

                            if ((approveModel.medulaUsername != null && approveModel.medulaUsername != "") || (approveModel.medulaPassword != null && approveModel.medulaPassword != ""))
                            {
                                eRaporOnayIstekDVO.doktorTcKimlikNo = approveModel.medulaUsername;
                                uniqueRefNo = approveModel.medulaUsername;
                                password = approveModel.medulaPassword;
                            }
                            else
                            {
                                throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                            }
                        }
                        else
                        {
                            if (approveModel.isSecondDoctorApprove)
                            {
                                uniqueRefNo = medicalStuffReportObj.SecondDoctor.Person.UniqueRefNo.Value.ToString();
                                if (!string.IsNullOrEmpty(medicalStuffReportObj.SecondDoctor.ErecetePassword))
                                    password = medicalStuffReportObj.SecondDoctor.ErecetePassword;
                                else
                                    throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");
                                eRaporOnayIstekDVO.doktorTcKimlikNo = uniqueRefNo;
                            }

                            //if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval)
                            if (approveModel.isThirdDoctorApprove)
                            {

                                uniqueRefNo = medicalStuffReportObj.ThirdDoctor.Person.UniqueRefNo.Value.ToString();
                                eRaporOnayIstekDVO.doktorTcKimlikNo = uniqueRefNo;
                                if (!string.IsNullOrEmpty(medicalStuffReportObj.ThirdDoctor.ErecetePassword))
                                    password = medicalStuffReportObj.ThirdDoctor.ErecetePassword;
                                else
                                    throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");                                
                            }
                           

                        }
                        TibbiMalzemeERaporIslemleri.eRaporOnayCevapDVO response = TibbiMalzemeERaporIslemleri.WebMethods.doktorERaporOnayVeIptalSync(Sites.SiteLocalHost, uniqueRefNo, password, eRaporOnayIstekDVO);
                        if (response != null && response.sonucKodu != null && response.sonucKodu == "0000" || response.sonucKodu == "RAP_0052")
                        {
                            if (medicalStuffReportObj.CommitteeReport == true)
                            {
                                if (uniqueRefNo == medicalStuffReportObj.SecondDoctor.UniqueNo)
                                {
                                    medicalStuffReportObj.IsSecondDoctorApproved = true;
                                }
                                else if (uniqueRefNo == medicalStuffReportObj.ThirdDoctor.UniqueNo)
                                {
                                    medicalStuffReportObj.IsThirdDoctorApproved = true;
                                }
                            }

                            if (medicalStuffReportObj.CurrentStateDefID == MedicalStuffReport.States.SecondDoctorApproval)
                            {
                                medicalStuffReportObj.CurrentStateDefID = MedicalStuffReport.States.ThirdDoctorApproval;
                            }
                            else if (medicalStuffReportObj.CurrentStateDefID == MedicalStuffReport.States.ThirdDoctorApproval)
                            {
                                medicalStuffReportObj.CurrentStateDefID = MedicalStuffReport.States.HeadDoctorApproval;
                            }

                            objectContext.Save();
                            return response;
                        }
                        else
                        {
                            return response;
                        }

                    }

                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public TibbiMalzemeERaporIslemleri.eRaporOnayCevapDVO BashekimOnay(MedicalStuffReportApproveModel approveModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var medicalStuffReportObj = (MedicalStuffReport)objectContext.AddObject(approveModel.medicalStuffReport);
                    string password = "";
                    string uniqueRefNo = "";
                    if (medicalStuffReportObj.RaporTakipNo != null && medicalStuffReportObj.RaporTakipNo != "")
                    {
                        TibbiMalzemeERaporIslemleri.eRaporOnayIstekDVO eraporBashekimOnayIstekDVO = new TibbiMalzemeERaporIslemleri.eRaporOnayIstekDVO();
                        eraporBashekimOnayIstekDVO.tesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                        eraporBashekimOnayIstekDVO.raporTakipNo = medicalStuffReportObj.RaporTakipNo;
                        eraporBashekimOnayIstekDVO.onayKod = 2;
                        if (medicalStuffReportObj.CurrentStateDefID == MedicalStuffReport.States.HeadDoctorApproval)
                        {


                            var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                            if (MedulaPasswordCheck == "TRUE")
                            {
                                if ((approveModel.medulaUsername != null && approveModel.medulaUsername != "") || (approveModel.medulaPassword != null && approveModel.medulaPassword != ""))
                                {
                                    eraporBashekimOnayIstekDVO.doktorTcKimlikNo = approveModel.medulaUsername;
                                    uniqueRefNo = approveModel.medulaUsername;
                                    password = approveModel.medulaPassword;
                                }
                                else
                                {
                                    throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                                }
                            }
                            else
                            {
                                string basHekimObjectID = TTObjectClasses.SystemParameter.GetParameterValue("KURUMSALYONETICI_OBJECTID", "XXXXXX");
                                BindingList<ResUser.GetUserByID_Class> basTabipList = ResUser.GetUserByID(basHekimObjectID);
                                if (basTabipList == null || basTabipList.Count == 0)
                                {
                                    throw new Exception(TTUtils.CultureService.GetText("M25242", "Baş Tabip Boş Olamaz !!!"));
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(basTabipList[0].ErecetePassword))
                                        password = basTabipList[0].ErecetePassword;
                                    else
                                        throw new Exception("EReçete Şifresi Boş Olamaz");
                                    if (basTabipList[0].Tcno != null)
                                    {
                                        eraporBashekimOnayIstekDVO.doktorTcKimlikNo = basTabipList[0].Tcno.ToString();
                                        uniqueRefNo = basTabipList[0].Tcno.ToString();
                                    }
                                    else
                                        throw new Exception(TTUtils.CultureService.GetText("M25249", "Başhekim TC Kimlik Numarası Boş Olamaz"));
                                }
                            }
                            TibbiMalzemeERaporIslemleri.eRaporOnayCevapDVO response = TibbiMalzemeERaporIslemleri.WebMethods.bashekimERaporOnayVeIptalSync(Sites.SiteLocalHost, uniqueRefNo, password, eraporBashekimOnayIstekDVO);
                            if (response != null && response.sonucKodu != null && response.sonucKodu == "0000")
                            {
                                medicalStuffReportObj.CurrentStateDefID = MedicalStuffReport.States.Complete;
                                objectContext.Save();
                                return response;

                            }
                            else
                            {
                                return response;

                            }

                        }

                        return null;
                    }

                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public MedicalStuffReportFormViewModel MedicalStuffReportFormTemplate(MedicalStuffReportFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (viewModel.selectedUserTemplate != null)
                {
                    MedicalStuffReport templateMedicalStuffReport = objectContext.GetObject<MedicalStuffReport>((Guid)viewModel.selectedUserTemplate.TAObjectID);
                    MedicalStuffReport reportObject = (MedicalStuffReport)objectContext.AddObject(viewModel._MedicalStuffReport);
                    var doctor1 = reportObject.ProcedureDoctor;
                    var doctor2 = reportObject.SecondDoctor;
                    var doctor3 = reportObject.ThirdDoctor;
                    reportObject.Duration = templateMedicalStuffReport.Duration;
                    reportObject.DurationType = templateMedicalStuffReport.DurationType;
                    reportObject.Description = templateMedicalStuffReport.Description;
                    reportObject.ReportDecision = templateMedicalStuffReport.ReportDecision;
                    reportObject.MedicalStuff.Clear();
                    reportObject.ReportDiagnosis.Clear();
                    foreach (MedicalStuff oldMedicalStuff in templateMedicalStuffReport.MedicalStuff)
                    {
                        MedicalStuff newMedicalStuff = new MedicalStuff(objectContext);
                        newMedicalStuff.MedicalStuffReport = viewModel._MedicalStuffReport;
                        newMedicalStuff.MedicalStuffDef = oldMedicalStuff.MedicalStuffDef;

                        newMedicalStuff.MedicalStuffGroup = oldMedicalStuff.MedicalStuffGroup;
                        newMedicalStuff.MedicalStuffPlaceOfUsage = oldMedicalStuff.MedicalStuffPlaceOfUsage;
                        newMedicalStuff.MedicalStuffUsageType = oldMedicalStuff.MedicalStuffUsageType;
                        newMedicalStuff.StuffAmount = oldMedicalStuff.StuffAmount;
                        newMedicalStuff.OdyometryTestId = oldMedicalStuff.OdyometryTestId;
                        newMedicalStuff.StuffDescription = oldMedicalStuff.StuffDescription;

                        newMedicalStuff.PeriodUnit = oldMedicalStuff.PeriodUnit;
                        newMedicalStuff.PeriodUnitType = (PeriodUnitTypeEnum)oldMedicalStuff.PeriodUnitType;
                        reportObject.MedicalStuff.Add(newMedicalStuff);
                    }


                    viewModel._MedicalStuffReport = reportObject;
                    viewModel.ListDefDisplayExpressions = new Dictionary<string, object>();
                    ContextToViewModel(viewModel, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public List<UserTemplateModel> SaveMedicalStuffReportUserTemplate(UserTemplateModel userTemplate)
        {
            List<UserTemplateModel> userTemplatesList = new List<UserTemplateModel>();

            using (var objectContext = new TTObjectContext(false))
            {
                if (userTemplate.ObjectID != null)
                {
                    UserTemplate oldUserTemplate = objectContext.GetObject<UserTemplate>((Guid)userTemplate.ObjectID);
                    oldUserTemplate.FiliterData = "DELETED-MedicalStuffReportTemplate";
                }
                else
                {
                    UserTemplate newUserTemplate = new UserTemplate(objectContext);
                    newUserTemplate.TAObjectDefID = userTemplate.TAObjectDefID;
                    newUserTemplate.TAObjectID = userTemplate.TAObjectID;
                    newUserTemplate.FiliterData = "MedicalStuffReportTemplate";
                    newUserTemplate.ResUser = Common.CurrentResource;
                    newUserTemplate.Description = userTemplate.Description;
                }

                objectContext.Save();
                var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, (Guid)userTemplate.TAObjectDefID, "MedicalStuffReportTemplate").ToList();
                foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList)
                {
                    UserTemplateModel templateModel = new UserTemplateModel();
                    templateModel.ObjectID = item.ObjectID;
                    templateModel.TAObjectID = item.TAObjectID;
                    templateModel.TAObjectDefID = item.TAObjectDefID;
                    templateModel.Description = item.Description;
                    userTemplatesList.Add(templateModel);
                }
            }
            return userTemplatesList;
        }

        [HttpPost]
        public TibbiMalzemeERaporIslemleri.eRaporCevapDVO RaporMalzemeEkle(AddTibbiMalzemeClass input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                
                var AddedMedicalStuff = (MedicalStuff)objectContext.AddObject(input.medicalStuff);
                var medicalStuffReport = AddedMedicalStuff.MedicalStuffReport;
                objectContext.FullPartialllyLoadedObjects();
                TibbiMalzemeERaporIslemleri.eRaporMalzemeEkleIstekDVO eRaporMalzemeEkleIstekDVO = new TibbiMalzemeERaporIslemleri.eRaporMalzemeEkleIstekDVO();

                eRaporMalzemeEkleIstekDVO.raporTakipNo = medicalStuffReport.RaporTakipNo;
                eRaporMalzemeEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(input.medulaUsername);

                long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                eRaporMalzemeEkleIstekDVO.tesisKodu = (int)saglikTesisKodu;
                List<TibbiMalzemeERaporIslemleri.eMalzemeGirisDVO> malzemeList = new List<TibbiMalzemeERaporIslemleri.eMalzemeGirisDVO>();

                TibbiMalzemeERaporIslemleri.eMalzemeGirisDVO _malzemeBilgisiDVO = new TibbiMalzemeERaporIslemleri.eMalzemeGirisDVO();
                _malzemeBilgisiDVO.adet = AddedMedicalStuff.StuffAmount.Value;
                _malzemeBilgisiDVO.degistirmeRaporu = "H";
                _malzemeBilgisiDVO.kullanimPeriyodu = AddedMedicalStuff.PeriodUnit;
                if (AddedMedicalStuff.PeriodUnitType == PeriodUnitTypeEnum.DayPeriod)
                {
                    _malzemeBilgisiDVO.kullanimPeriyodBirim = 1;
                }
                else if (AddedMedicalStuff.PeriodUnitType == PeriodUnitTypeEnum.WeekPeriod)
                {
                    _malzemeBilgisiDVO.kullanimPeriyodBirim = 2;
                }
                else if (AddedMedicalStuff.PeriodUnitType == PeriodUnitTypeEnum.MonthPeriod)
                {
                    _malzemeBilgisiDVO.kullanimPeriyodBirim = 3;
                }
                else if (AddedMedicalStuff.PeriodUnitType == PeriodUnitTypeEnum.YearPeriod)
                {
                    _malzemeBilgisiDVO.kullanimPeriyodBirim = 4;
                }
                else
                {
                    _malzemeBilgisiDVO.kullanimPeriyodBirim = 0;
                }
                _malzemeBilgisiDVO.kullanimYeri = AddedMedicalStuff.MedicalStuffPlaceOfUsage.Code;
                _malzemeBilgisiDVO.sutKodu = AddedMedicalStuff.MedicalStuffDef.Code.ToString();
                if (AddedMedicalStuff.MedicalStuffUsageType != null)
                    _malzemeBilgisiDVO.kullanimSekli = AddedMedicalStuff.MedicalStuffUsageType.Code;                
                malzemeList.Add(_malzemeBilgisiDVO);
                eRaporMalzemeEkleIstekDVO.malzemeListesi = malzemeList.ToArray();
                string uniqueRefNo = "", password = "";
                var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                if (MedulaPasswordCheck == "TRUE")
                {
                    if ((input.medulaUsername != null && input.medulaUsername != "") || (input.medulaPassword != null && input.medulaPassword != ""))
                    {
                        eRaporMalzemeEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(input.medulaUsername);
                        uniqueRefNo = input.medulaUsername;
                        password = input.medulaPassword;
                    }
                    else
                    {
                        throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(medicalStuffReport.ProcedureDoctor.ErecetePassword))
                    {
                        throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");

                    }                    
                    uniqueRefNo = medicalStuffReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    eRaporMalzemeEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(uniqueRefNo);
                    if (!string.IsNullOrEmpty(medicalStuffReport.ProcedureDoctor.ErecetePassword))
                        password = medicalStuffReport.ProcedureDoctor.ErecetePassword;
                }

                TibbiMalzemeERaporIslemleri.eRaporCevapDVO response = TibbiMalzemeERaporIslemleri.WebMethods.eRaporMalzemeEkleSync(Sites.SiteLocalHost, uniqueRefNo, password, eRaporMalzemeEkleIstekDVO);

                if(response != null && response.sonucKodu == "0000")
                {
                    objectContext.Save();
                }
            return response;

            }
        }

        [HttpPost]
        public TibbiMalzemeERaporIslemleri.eRaporCevapDVO RaporTaniEkle(AddDiagnosisClass input)
        {
            using (var objectContext = new TTObjectContext(false))
            {

                var diagnosisDefinition = (DiagnosisDefinition)objectContext.AddObject(input.Diagnose);
                var medicalStuffReport = (MedicalStuffReport)objectContext.AddObject(input.ReportObject); 
                objectContext.FullPartialllyLoadedObjects();
                TibbiMalzemeERaporIslemleri.eRaporTaniEkleIstekDVO eRaporTaniEkleIstekDVO = new TibbiMalzemeERaporIslemleri.eRaporTaniEkleIstekDVO();

                eRaporTaniEkleIstekDVO.raporTakipNo = medicalStuffReport.RaporTakipNo;
                eRaporTaniEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(input.medulaUsername);

                long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                eRaporTaniEkleIstekDVO.tesisKodu = (int)saglikTesisKodu;

                var taniListesi = new List<TibbiMalzemeERaporIslemleri.eTaniDVO>();

                TibbiMalzemeERaporIslemleri.eTaniDVO eTaniDVO = new TibbiMalzemeERaporIslemleri.eTaniDVO();
                eTaniDVO.taniKodu = diagnosisDefinition.Code;
                eTaniDVO.taniAdi = diagnosisDefinition.Name;

                taniListesi.Add(eTaniDVO);
                eRaporTaniEkleIstekDVO.taniListesi = taniListesi.ToArray();

                string uniqueRefNo = "", password = "";
                var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                if (MedulaPasswordCheck == "TRUE")
                {
                    if ((input.medulaUsername != null && input.medulaUsername != "") || (input.medulaPassword != null && input.medulaPassword != ""))
                    {
                        eRaporTaniEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(input.medulaUsername);
                        uniqueRefNo = input.medulaUsername;
                        password = input.medulaPassword;
                    }
                    else
                    {
                        throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(medicalStuffReport.ProcedureDoctor.ErecetePassword))
                    {
                        throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");

                    }
                    uniqueRefNo = medicalStuffReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    eRaporTaniEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(uniqueRefNo);
                    if (!string.IsNullOrEmpty(medicalStuffReport.ProcedureDoctor.ErecetePassword))
                        password = medicalStuffReport.ProcedureDoctor.ErecetePassword;
                }

                TibbiMalzemeERaporIslemleri.eRaporCevapDVO response = TibbiMalzemeERaporIslemleri.WebMethods.eRaporTaniEkleSync(Sites.SiteLocalHost, uniqueRefNo, password, eRaporTaniEkleIstekDVO);

                if (response != null && response.sonucKodu == "0000")
                {
                    ReportDiagnosis reportDiagnosis = new ReportDiagnosis(objectContext);
                    reportDiagnosis.Diagnose = diagnosisDefinition;
                    reportDiagnosis.DiagnoseDate = Common.RecTime();
                    reportDiagnosis.EpisodeAction = medicalStuffReport;
                    objectContext.Save();
                }
                return response;

            }
        }

        public TibbiMalzemeERaporIslemleri.eRaporCevapDVO RaporAciklamaGuncelle(ChangeReportDescriptionClass input)
        {
            using (var objectContext = new TTObjectContext(false))
            {                
                var medicalStuffReport = (MedicalStuffReport)objectContext.AddObject(input.medicalStuffReport);
                objectContext.FullPartialllyLoadedObjects();
                TibbiMalzemeERaporIslemleri.eRaporAciklamaGuncelleIstekDVO eRaporAciklamaGuncelleIstek = new TibbiMalzemeERaporIslemleri.eRaporAciklamaGuncelleIstekDVO();

                eRaporAciklamaGuncelleIstek.raporTakipNo = medicalStuffReport.RaporTakipNo;
                eRaporAciklamaGuncelleIstek.doktorTcKimlikNo = Convert.ToInt64(input.medulaUsername);

                long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                eRaporAciklamaGuncelleIstek.tesisKodu = (int)saglikTesisKodu;

                eRaporAciklamaGuncelleIstek.aciklama = medicalStuffReport.Description.ToString();
                string uniqueRefNo = "", password = "";
                var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                if (MedulaPasswordCheck == "TRUE")
                {
                    if ((input.medulaUsername != null && input.medulaUsername != "") || (input.medulaPassword != null && input.medulaPassword != ""))
                    {
                        eRaporAciklamaGuncelleIstek.doktorTcKimlikNo = Convert.ToInt64(input.medulaUsername);
                        uniqueRefNo = input.medulaUsername;
                        password = input.medulaPassword;
                    }
                    else
                    {
                        throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(medicalStuffReport.ProcedureDoctor.ErecetePassword))
                    {
                        throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");

                    }
                    uniqueRefNo = medicalStuffReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    eRaporAciklamaGuncelleIstek.doktorTcKimlikNo = Convert.ToInt64(uniqueRefNo);
                    if (!string.IsNullOrEmpty(medicalStuffReport.ProcedureDoctor.ErecetePassword))
                        password = medicalStuffReport.ProcedureDoctor.ErecetePassword;
                }

                TibbiMalzemeERaporIslemleri.eRaporCevapDVO response = TibbiMalzemeERaporIslemleri.WebMethods.eRaporAciklamaGuncelleSync(Sites.SiteLocalHost, uniqueRefNo, password, eRaporAciklamaGuncelleIstek);

                if (response != null && response.sonucKodu == "0000")
                {                    
                    objectContext.Save();
                }
                return response;

            }
        }


        public class MedulaResult
        {
            private bool _succes;
            private string _basvuruNo;
            private string _takipNo;
            private string _sonucMesaji;
            private string _sonucKodu;
            private string _bagliTakipNo;
            private Guid _SEPObjectID;
            private List<TibbiMalzemeERaporIslemleri.eRaporDVO> _eRaporDVO;

            public Guid SEPObjectID
            {
                get
                {
                    return this._SEPObjectID;
                }
                set
                {
                    this._SEPObjectID = value;
                }
            }

            public bool Succes
            {
                get
                {
                    return this._succes;
                }
                set
                {
                    this._succes = value;
                }
            }
            public string BasvuruNo
            {
                get
                {
                    return this._basvuruNo;
                }
                set
                {
                    this._basvuruNo = value;
                }
            }
            public string TakipNo
            {
                get
                {
                    return this._takipNo;
                }
                set
                {
                    this._takipNo = value;
                }
            }
            public string SonucMesaji
            {
                get
                {
                    return this._sonucMesaji;
                }
                set
                {
                    this._sonucMesaji = value;
                }
            }
            public string SonucKodu
            {
                get
                {
                    return this._sonucKodu;
                }
                set
                {
                    this._sonucKodu = value;
                }
            }
            public string BagliTakipNo
            {
                get
                {
                    return this._bagliTakipNo;
                }
                set
                {
                    this._bagliTakipNo = value;
                }
            }
            public List<TibbiMalzemeERaporIslemleri.eRaporDVO> eRaporDVO
            {
                get
                {
                    return _eRaporDVO;
                }

                set
                {
                    _eRaporDVO = value;
                }
            }
            public MedulaResult()
            {
                this.SonucKodu = "";
                this.SonucMesaji = "";
                this.Succes = false;
                this.TakipNo = "";
                this.BasvuruNo = "";
                this.eRaporDVO = new List<TibbiMalzemeERaporIslemleri.eRaporDVO>();
            }
        }
    }
}

namespace Core.Models
{
    public class ReportSignContent
    {
        public Guid ReportObjectID
        {
            get;
            set;
        }

        public string SignContent
        {
            get;
            set;
        }
        public int OrderNo
        {
            get;
            set;
        }
    }

    public class MedicalStuffReportApproveModel
    {
        public MedicalStuffReport medicalStuffReport { get; set; }
        public string medulaUsername { get; set; }
        public string medulaPassword { get; set; }
        public bool isSecondDoctorApprove = false;
        public bool isThirdDoctorApprove = false;
    }
    public class PrepareSignedDeleteReportContent_Input
    {
        public string eRaporTakipNo
        {
            get;
            set;
        }

    }
    public class PrepareSignedDiagnosisReportContent_Input
    {
        public string eRaporTakipNo
        {
            get;
            set;
        }
        public Guid diagnosisObjID
        {
            get;
            set;
        }

    }

    public class SendSignedDeleteReportContent_Input
    {
        public string singContent
        {
            get;
            set;
        }

    }
    public class SendSignedDiagnosisReportContent_Input
    {
        public string singContent
        {
            get;
            set;
        }

    }

    public class SignedReportOutput
    {
        public List<ReportSignContent> ReportSignContentList
        {
            get;
            set;
        }
    }
    public class PrepareSignedSearchReportContent_Input
    {
        public string eRaporTakipNo
        {
            get;
            set;
        }

    }
    public class SendSignedSearchReportContent_Input
    {
        public string singContent
        {
            get;
            set;
        }
        public MedicalStuffReportFormViewModel MedicalStuffReportFormViewModel { get; set; }
    }
    public class PrepareSignedReportContent_Input
    {
        public Guid eRaporObjectID
        {
            get;
            set;
        }

    }
    public class SendSignedReportContent_Input
    {
        public string singContent
        {
            get;
            set;
        }
        public MedicalStuffReportFormViewModel MedicalStuffReportFormViewModel { get; set; }
    }
    public partial class MedicalStuffReportFormViewModel : BaseViewModel
    {
        public bool IsSuperUser
        {
            get;
            set;
        }

        public Guid ToState
        {
            get;
            set;
        }
        public ReportDiagnosisFormViewModel reportDiagnosisFormViewModel = new ReportDiagnosisFormViewModel();

        public List<PatientMedicalStuffReportClass> MedicalStuffReportList
        {
            get;
            set;
        }

        public bool isStateSecondDoctorApproval { get; set; }
        public bool isStateThirdDoctorApproval { get; set; }
        public bool isStateHeadDoctorApproval { get; set; }
        public bool isPrescriptionWriteable { get; set; }
        public string medulaUsername { get; set; }
        public string medulaPassword { get; set; }
        public string maxReportDate { get; set; }
        public string minReportDate { get; set; }

        public List<UserTemplateModel> userTemplateList { get; set; }
        public UserTemplateModel selectedUserTemplate { get; set; }
        public string secondDoctor { get; set; }
        public string thirdDoctor { get; set; }
    }
    public class MedicalStuffGridListViewModel
    {
        public TTObjectClasses.MedicalStuffDefinition MedicalStuff
        {
            get;
            set;
        }
        public string MedicalStuffName
        {
            get;
            set;
        }
        public string MedicalStuffCode
        {
            get;
            set;
        }
    }

    public class PatientMedicalStuffReportClass
    {
        public Guid? ObjectID { get; set; }
        public string RaporTakipno { get; set; }
        public long? ReportNo { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Proceduredoctor { get; set; }
        public string Seconddoctor { get; set; }
        public string Thirddoctor { get; set; }
        public bool? IsSendedMedula { get; set; }
    }

    public class AddTibbiMalzemeClass
    {
        public MedicalStuff medicalStuff { get; set; }
        public string medulaUsername { get; set; }
        public string medulaPassword { get; set; }
    }

    public class AddDiagnosisClass
    {
        public DiagnosisDefinition Diagnose { get; set; }
        public MedicalStuffReport ReportObject { get; set; }
        public string medulaUsername { get; set; }
        public string medulaPassword { get; set; }
    }

    public class ChangeReportDescriptionClass
    {
        public MedicalStuffReport medicalStuffReport { get; set; }
        public string medulaUsername { get; set; }
        public string medulaPassword { get; set; }
    }
}
