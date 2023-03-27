//$DA10073D
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.Text;
using static Core.Controllers.MedicalStuffReportServiceController;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class ReportApproveFormServiceController : BaseEpisodeActionWorkListServiceController
    {

        [HttpPost]
        public List<ReportApproveListItem> getDoctorApproveReports(ReportApproveListSearchCriteria searchCriteria)
        {

            ResUser currentUser = Common.CurrentResource;
            DateTime WorkListStartDate = Common.RecTime();
            DateTime WorkListEndDate = Common.RecTime();
            if (searchCriteria.startDate.HasValue)
                WorkListStartDate = Convert.ToDateTime(searchCriteria.startDate.Value.ToShortDateString() + " " + "00:00:00");

            if (searchCriteria.endDate.HasValue)
                WorkListEndDate = Convert.ToDateTime(searchCriteria.endDate.Value.ToShortDateString() + " " + "23:59:59");

            string whereCriteria_For_ParticipatnFreeDrugReport = " AND this.REQUESTDATE BETWEEN " + GetDateAsString(WorkListStartDate) + " AND " + GetDateAsString(WorkListEndDate);
            string whereCriteria_For_MedicalStuffReport = " AND this.REQUESTDATE BETWEEN " + GetDateAsString(WorkListStartDate) + " AND " + GetDateAsString(WorkListEndDate);
            if (!Common.CurrentUser.IsSuperUser)
            {
                whereCriteria_For_MedicalStuffReport += "AND (this.PROCEDUREDOCTOR = '" + currentUser.ObjectID.ToString() + "' OR this.seconddoctor = '" + currentUser.ObjectID.ToString() + "' OR this.thirdDoctor = '" + currentUser.ObjectID.ToString() + "')";
                whereCriteria_For_ParticipatnFreeDrugReport += " AND (this.PROCEDUREDOCTOR='" + currentUser.ObjectID.ToString() + "' OR this.seconddoctor='" + currentUser.ObjectID.ToString() + "' OR this.thirdDoctor='" + currentUser.ObjectID.ToString() + "') ";
            }

            whereCriteria_For_ParticipatnFreeDrugReport += " AND this.CURRENTSTATEDEFID IN(States.Report, States.SecondDoctorApproval, States.ThirdDoctorApproval, States.Approval)";
            whereCriteria_For_MedicalStuffReport += " AND this.CURRENTSTATEDEFID IN(States.New, States.SecondDoctorApproval, States.ThirdDoctorApproval, States.HeadDoctorApproval)";
            var doctorApproveList = new List<ReportApproveListItem>();

            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                var reportList = ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportForWL(objectContext, whereCriteria_For_ParticipatnFreeDrugReport);
                foreach (var reportFWL in reportList)
                {
                    ParticipatnFreeDrugReport participatnFreeDrugReport = (ParticipatnFreeDrugReport)objectContext.GetObject((Guid)reportFWL.ObjectID, "ParticipatnFreeDrugReport");
                    // GENEL 

                    ReportApproveListItem workListItem = new ReportApproveListItem();
                    //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları
                    var episode = participatnFreeDrugReport.Episode;
                    workListItem.ObjectDefID = reportFWL.ObjectDefID.ToString();
                    workListItem.ObjectDefName = reportFWL.ObjectDefName;
                    workListItem.ObjectID = (Guid)reportFWL.ObjectID;
                    workListItem.ItemType = "İlaç Raporu";
                    // Ikon set etmece
                    string PriorityStatus = reportFWL.Prioritystatus;
                    this.editedSetWorkListIkonProperties(PriorityStatus, episode.Patient, workListItem);
                    //
                    if (reportFWL.Date != null)
                        workListItem.Date = Convert.ToDateTime(reportFWL.Date);
                    workListItem.PatientNameSurname = reportFWL.Patientnamesurname.ToString();
                    workListItem.KabulNo = reportFWL.Kabulno == null ? "" : reportFWL.Kabulno.ToString();
                    workListItem.UniqueRefno = reportFWL.UniqueRefNo == null ? "" : reportFWL.UniqueRefNo.ToString();
                    workListItem.ResourceName = reportFWL.Masterresource == null ? "" : reportFWL.Masterresource.ToString(); ;
                    workListItem.DoctorName = reportFWL.Doctorname == null ? "" : reportFWL.Doctorname.ToString();
                    workListItem.procedureDoctorUniqueRefNo = participatnFreeDrugReport.ProcedureDoctor.UniqueNo;

                    if (reportFWL.BirthDate != null)
                    {
                        workListItem.BirthDate = reportFWL.BirthDate.Value; // Doğum Tarihi
                        var FullAge = Common.CalculateAge(workListItem.BirthDate);
                        workListItem.Age = FullAge.Years + " Yıl " + FullAge.Months + " Ay ";
                    }

                    if (participatnFreeDrugReport.SecondDoctor != null)
                    {
                        workListItem.secondDoctorApprovalStatus = participatnFreeDrugReport.IsSecondDoctorApproved != null ? ((bool)participatnFreeDrugReport.IsSecondDoctorApproved) : false;
                        workListItem.secondDoctorName = participatnFreeDrugReport.SecondDoctor.Name;
                        workListItem.secondDoctorUniqueRefNo = participatnFreeDrugReport.SecondDoctor.UniqueNo;
                        if (workListItem.secondDoctorApprovalStatus == false)
                            workListItem.disapprovedUsers = workListItem.secondDoctorName;
                    }
                    if (participatnFreeDrugReport.ThirdDoctor != null)
                    {
                        workListItem.thirdDoctorApprovalStatus = participatnFreeDrugReport.IsThirdDoctorApproved != null ? ((bool)participatnFreeDrugReport.IsThirdDoctorApproved) : false;
                        workListItem.thirdDoctorName = participatnFreeDrugReport.ThirdDoctor.Name;
                        workListItem.thirdDoctorUniqueRefNo = participatnFreeDrugReport.ThirdDoctor.UniqueNo;
                        if (workListItem.secondDoctorApprovalStatus == false)
                        {
                            if (String.IsNullOrEmpty(workListItem.disapprovedUsers) != true)
                                workListItem.disapprovedUsers += ", ";
                            workListItem.disapprovedUsers += workListItem.thirdDoctorName;
                        }
                    }
                    if (participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.Report)
                    {
                        workListItem.currentStateText = "Medulaya Gönderim Bekleniyor";
                        workListItem.currentStateID = 1;
                    }
                    else if (participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval || participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.ThirdDoctorApproval)
                    {
                        workListItem.currentStateText = "Hekim Onayında";
                        workListItem.currentStateID = 2;
                    }
                    else if (participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.Approval)
                    {
                        workListItem.currentStateText = "Başhekim Onayında";
                        workListItem.currentStateID = 3;
                    }

                    doctorApproveList.Add(workListItem);
                    // GENEL                         
                    //

                }

                var stuffReportList = MedicalStuffReport.GetMedicalStuffReportForWL(objectContext, whereCriteria_For_MedicalStuffReport);
                foreach (var reportFWL in stuffReportList)
                {
                    MedicalStuffReport medicalStuffReport = (MedicalStuffReport)objectContext.GetObject((Guid)reportFWL.ObjectID, "MedicalStuffReport");
                    // GENEL 

                    ReportApproveListItem workListItem = new ReportApproveListItem();
                    //ZORUNLU ALANLAR  BaseEpisodeActionWorkListItem alanları
                    var episode = medicalStuffReport.Episode;
                    workListItem.ObjectDefID = reportFWL.ObjectDefID.ToString();
                    workListItem.ObjectDefName = reportFWL.ObjectDefName;
                    workListItem.ObjectID = (Guid)reportFWL.ObjectID;
                    workListItem.ItemType = "Tıbbi Malzeme Raporu";
                    // Ikon set etmece
                    string PriorityStatus = reportFWL.Prioritystatus;
                    this.editedSetWorkListIkonProperties(PriorityStatus, episode.Patient, workListItem);
                    //
                    if (reportFWL.Date != null)
                        workListItem.Date = Convert.ToDateTime(reportFWL.Date);
                    workListItem.PatientNameSurname = reportFWL.Patientnamesurname.ToString();
                    workListItem.KabulNo = reportFWL.Kabulno == null ? "" : reportFWL.Kabulno.ToString();
                    workListItem.UniqueRefno = reportFWL.UniqueRefNo == null ? "" : reportFWL.UniqueRefNo.ToString();
                    workListItem.ResourceName = reportFWL.Masterresource == null ? "" : reportFWL.Masterresource.ToString(); ;
                    workListItem.DoctorName = reportFWL.Doctorname == null ? "" : reportFWL.Doctorname.ToString();
                    workListItem.procedureDoctorUniqueRefNo = medicalStuffReport.ProcedureDoctor.UniqueNo;
                    if (reportFWL.BirthDate != null)
                    {
                        workListItem.BirthDate = reportFWL.BirthDate.Value; // Doğum Tarihi
                        var FullAge = Common.CalculateAge(workListItem.BirthDate);
                        workListItem.Age = FullAge.Years + " Yıl " + FullAge.Months + " Ay ";
                    }

                    if (medicalStuffReport.SecondDoctor != null)
                    {
                        workListItem.secondDoctorApprovalStatus = medicalStuffReport.IsSecondDoctorApproved != null ? ((bool)medicalStuffReport.IsSecondDoctorApproved) : false;
                        workListItem.secondDoctorName = medicalStuffReport.SecondDoctor.Name;
                        workListItem.secondDoctorUniqueRefNo = medicalStuffReport.SecondDoctor.UniqueNo;
                        if (workListItem.secondDoctorApprovalStatus == false)
                            workListItem.disapprovedUsers = workListItem.secondDoctorName;
                    }
                    if (medicalStuffReport.ThirdDoctor != null)
                    {
                        workListItem.thirdDoctorApprovalStatus = medicalStuffReport.IsThirdDoctorApproved != null ? ((bool)medicalStuffReport.IsThirdDoctorApproved) : false;
                        workListItem.thirdDoctorName = medicalStuffReport.ThirdDoctor.Name;
                        workListItem.thirdDoctorUniqueRefNo = medicalStuffReport.ThirdDoctor.UniqueNo;
                        if (workListItem.secondDoctorApprovalStatus == false)
                        {
                            if (String.IsNullOrEmpty(workListItem.disapprovedUsers) != true)
                                workListItem.disapprovedUsers += ", ";
                            workListItem.disapprovedUsers += workListItem.thirdDoctorName;
                        }
                    }

                    if (medicalStuffReport.CurrentStateDefID == MedicalStuffReport.States.SecondDoctorApproval || medicalStuffReport.CurrentStateDefID == MedicalStuffReport.States.New)
                    {                        
                        if (medicalStuffReport.CurrentStateDefID == MedicalStuffReport.States.New)
                        {
                            workListItem.currentStateText = "Medulaya Gönderim Bekleniyor";
                            workListItem.currentStateID = 1;
                        }
                        else
                        {
                            workListItem.currentStateText = "Hekim Onayında";
                            workListItem.currentStateID = 2;
                        }
                    }
                    else if (medicalStuffReport.CurrentStateDefID == MedicalStuffReport.States.ThirdDoctorApproval)
                    {                      
                        workListItem.currentStateText = "Hekim Onayında";
                        workListItem.currentStateID = 2;
                    }
                    else if (medicalStuffReport.CurrentStateDefID == MedicalStuffReport.States.HeadDoctorApproval)
                    {
                        workListItem.currentStateText = "Başhekim Onayında";
                        workListItem.currentStateID = 3;
                    }                    

                    doctorApproveList.Add(workListItem);

                }
                return doctorApproveList;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string PrepareSignedReportContent(SendReportApproveModel sendModel)
        {
            string output = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = objectContext.GetObject<ParticipatnFreeDrugReport>(sendModel.reportObjectID);
                bool checkPatientApprovalFormNo = false;
                Guid savePointGuid = objectContext.BeginSavePoint();
                string etkinMaddeAdi = String.Empty;
                CheckParticipationFreeDrugs(participatnFreeDrugReportImported);
                if (string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.DiplomaRegisterNo))
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25528", "Doktorun diploma tescil no bilgisini tanımlayınız!"));
                //if (!Common.CurrentUser.IsSuperUser && participatnFreeDrugReportImported.ProcedureDoctor.ObjectID != Common.CurrentUser.UserObject.ObjectID)
                //    throw new TTUtils.TTException("Raporun sorumlu doktoru değilsiniz!");                
                objectContext.Update();
                try
                {
                    if (participatnFreeDrugReportImported.SubEpisode.SGKSEP != null)
                    {
                        if (participatnFreeDrugReportImported.Episode.Patient.UniqueRefNo == null)
                        {
                            objectContext.RollbackSavePoint(savePointGuid);
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25794", "Hasta Kimlik Numarası Boş Olamaz"));
                        }

                        if (participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo == null)
                        {
                            objectContext.RollbackSavePoint(savePointGuid);
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25523", "Doktor Kimlik Numarası Boş Olamaz"));
                        }

                        if (SpecialityDefinition.GetSpecialityByResUser(participatnFreeDrugReportImported.ProcedureDoctor) == null)
                        {
                            objectContext.RollbackSavePoint(savePointGuid);
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25521", "Doktor Branş Kodu Boş Olamaz"));
                        }

                        if (String.IsNullOrEmpty(participatnFreeDrugReportImported.SubEpisode.SGKSEP.MedulaTakipNo))
                        {
                            objectContext.RollbackSavePoint(savePointGuid);
                            throw new TTUtils.TTException("Provizyon numarası bulunmayan hastalara rapor yazılamaz.Önce Takip Alınız.");
                        }

                        IlacRaporuServis.eraporGirisIstekDVO eraporGirisIstekDVO = new IlacRaporuServis.eraporGirisIstekDVO();
                        eraporGirisIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                        eraporGirisIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                        IlacRaporuServis.eraporDVO _eraporDVO = new IlacRaporuServis.eraporDVO();
                        _eraporDVO.aciklama = string.Empty;
                        if (participatnFreeDrugReportImported.Episode.Patient.YUPASSNO != null && participatnFreeDrugReportImported.Episode.Patient.YUPASSNO.Value != 0)
                        {
                            _eraporDVO.hastaTcKimlikNo = participatnFreeDrugReportImported.Episode.Patient.YUPASSNO.Value.ToString(); //Zorunlu
                        }
                        else
                            _eraporDVO.hastaTcKimlikNo = participatnFreeDrugReportImported.Episode.Patient.UniqueRefNo.Value.ToString(); //Zorunlu
                        _eraporDVO.klinikTani = string.Empty;
                        _eraporDVO.protokolNo = participatnFreeDrugReportImported.Episode.HospitalProtocolNo.ToString(); //Zorunlu
                        _eraporDVO.raporNo = participatnFreeDrugReportImported.ReportNo.Value.ToString(); //Zorunlu
                        _eraporDVO.raporOnayDurumu = string.Empty;
                        _eraporDVO.raporTakipNo = string.Empty;
                        _eraporDVO.raporTarihi = participatnFreeDrugReportImported.ReportStartDate != null ? participatnFreeDrugReportImported.ReportStartDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");

                        //if (participatnFreeDrugReportImported.ExaminationDate.HasValue)
                        //    _eraporDVO.raporTarihi = participatnFreeDrugReportImported.ExaminationDate.Value.ToString("dd.MM.yyyy"); //Zorunlu
                        //else
                        //    _eraporDVO.raporTarihi = DateTime.Now.ToString("dd.MM.yyyy");
                        _eraporDVO.takipNo = participatnFreeDrugReportImported.SubEpisode.SGKSEP != null ? participatnFreeDrugReportImported.SubEpisode.SGKSEP.MedulaTakipNo : ""; //Zorunlu
                        _eraporDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                        if (participatnFreeDrugReportImported.CommitteeReport == true)
                        {
                            _eraporDVO.raporDuzenlemeTuru = "1";
                        }
                        else
                            _eraporDVO.raporDuzenlemeTuru = "2";
                        IlacRaporuServis.kisiDVO _kisiDVO = new IlacRaporuServis.kisiDVO();

                        if (participatnFreeDrugReportImported.Episode.Patient.YUPASSNO != null && participatnFreeDrugReportImported.Episode.Patient.YUPASSNO.Value != 0)
                        {
                            _kisiDVO.tcKimlikNo = participatnFreeDrugReportImported.Episode.Patient.YUPASSNO.Value; //Zorunlu
                        }
                        else
                            _kisiDVO.tcKimlikNo = participatnFreeDrugReportImported.Episode.Patient.UniqueRefNo.Value; //Zorunlu
                        _kisiDVO.adi = participatnFreeDrugReportImported.Episode.Patient.Name;
                        _kisiDVO.soyadi = participatnFreeDrugReportImported.Episode.Patient.Surname;
                        if (participatnFreeDrugReportImported.Episode.Patient.Sex != null)
                        {
                            //todo bg
                            if (participatnFreeDrugReportImported.Episode.Patient.Sex.KODU == "2")
                                _kisiDVO.cinsiyeti = "K";
                            if (participatnFreeDrugReportImported.Episode.Patient.Sex.KODU == "1")
                                _kisiDVO.cinsiyeti = "E";
                        }

                        _kisiDVO.dogumTarihi = participatnFreeDrugReportImported.Episode.Patient.BirthDate.ToString();
                        _eraporDVO.kisiDVO = _kisiDVO;
                        List<string> _eraporTaniList = new List<string>();
                        List<IlacRaporuServis.eraporTaniDVO> _eraporTaniDVOList = new List<IlacRaporuServis.eraporTaniDVO>();

                        var viewModel = new SentItemContainerForDrugReport();
                        viewModel = FillContainerModel(participatnFreeDrugReportImported);

                        foreach (ReportDiagnosis reportDiagnosis in participatnFreeDrugReportImported.ReportDiagnosis)
                        {
                            if (reportDiagnosis.TaniTeshisİliskisi != null)
                            {
                                foreach (TaniTeshisİliskisi taniTeshis in reportDiagnosis.TaniTeshisİliskisi)
                                {
                                    TeshisListModel result = viewModel.TeshisList.Where(t => t.teshis.ObjectID == taniTeshis.Teshis.ObjectID).FirstOrDefault();
                                    if (result != null)
                                    {
                                        AddedDiagnosisListModel addedDiagnosis = result.AddedDiagnosisList.Where(t => t.Tani.ObjectID == reportDiagnosis.Diagnose.ObjectID).FirstOrDefault();
                                        if (addedDiagnosis != null)
                                            viewModel.SelectedTeshisTaniList.Add(addedDiagnosis);
                                    }
                                }
                            }
                        }

                        foreach (AddedDiagnosisListModel selectedDiagnose in viewModel.SelectedTeshisTaniList)
                        {
                            _eraporTaniList.Add(selectedDiagnose.taniKodu);
                        }

                        _eraporTaniList = Common.DiagnosesForMedula(_eraporTaniList);


                        foreach (string _eraporTani in _eraporTaniList)
                        {
                            IlacRaporuServis.eraporTaniDVO _eraporTaniDVO = new IlacRaporuServis.eraporTaniDVO();
                            // _eraporTaniDVO.taniAdi = selectedDiagnose.taniAdi;
                            _eraporTaniDVO.taniKodu = _eraporTani;
                            _eraporTaniDVOList.Add(_eraporTaniDVO);
                        }

                        //foreach (DiagnosisGrid item in participatnFreeDrugReportImported.Episode.Diagnosis)
                        //{
                        //    _eraporTaniList.Add(item.DiagnoseCode);
                        //}

                        //_eraporTaniList = Common.DiagnosesForMedula(_eraporTaniList);
                        //foreach (string _eraporTani in _eraporTaniList)
                        //{
                        //    IlacRaporuServis.eraporTaniDVO _eraporTaniDVO = new IlacRaporuServis.eraporTaniDVO();
                        //    _eraporTaniDVO.taniKodu = _eraporTani;
                        //    //_eraporTaniDVO.taniAdi = item.Diagnose;
                        //    _eraporTaniDVOList.Add(_eraporTaniDVO);
                        //}

                        _eraporDVO.eraporTaniListesi = _eraporTaniDVOList.ToArray();
                        List<TaniTeshisPair> _taniTeshisPairList = new List<TaniTeshisPair>();
                        foreach (AddedDiagnosisListModel item in viewModel.SelectedTeshisTaniList)
                        {
                            List<TaniListesi> _taniList = new List<TaniListesi>();
                            DiagnosisDefinition d = item.Tani;// (DiagnosisDefinition)objectContext.GetObject(item.Tani, typeof(DiagnosisDefinition));
                            Teshis teshis = (Teshis)objectContext.GetObject(item.teshisObjectID, typeof(Teshis));
                            bool _teshisVar = false;
                            bool _taniVar = false;
                            if (_taniTeshisPairList != null && _taniTeshisPairList.Count > 0)
                            {
                                TaniTeshisPair _teshis = new TaniTeshisPair();
                                foreach (TaniTeshisPair teshisVar in _taniTeshisPairList)
                                {
                                    if (item.teshisObjectID == null)
                                    {
                                        objectContext.RollbackSavePoint(savePointGuid);
                                        throw new TTUtils.TTException(d.Code + " Tanı Koduna Ait Teshis Bilgisi Seçilmemiştir");
                                    }

                                    if (teshisVar.Teshis.teshisKodu == teshis.teshisKodu.Value)
                                    {
                                        _teshisVar = true;
                                        _teshis = teshisVar;
                                    }
                                }

                                if (_teshisVar)
                                {
                                    // TaniTeshisPair _taniTeshisPair = new TaniTeshisPair();
                                    foreach (TaniListesi taniVar in _taniList)
                                    {
                                        if (taniVar.Kodu == d.Code)
                                        {
                                            _taniVar = true;
                                        }
                                    }

                                    if (!_taniVar)
                                    {
                                        _taniList.Clear();
                                        TaniListesi tani = new TaniListesi();
                                        tani.Kodu = d.Code;
                                        _taniList.Add(tani);

                                        _teshis.Tanilar.Add(tani);
                                        //_taniTeshisPair.Tanilar = _taniList;
                                        //_taniTeshisPair.Teshis = teshis;
                                        //_taniTeshisPairList.Add(_taniTeshisPair);
                                    }
                                }
                                else
                                {
                                    TaniTeshisPair _taniTeshisPair = new TaniTeshisPair();
                                    _taniTeshisPair.Teshis = teshis;
                                    //if (item.teshisObjectID == null)
                                    //{
                                    //    objectContext.RollbackSavePoint(savePointGuid);
                                    //    throw new TTUtils.TTException(d.Code + " Tanı Koduna ait Teshis Bilgisi Sistemde Tanımlı Değildir");
                                    //    //break;
                                    //}

                                    foreach (TaniListesi taniVar in _taniList)
                                    {
                                        if (taniVar.Kodu == d.Code)
                                        {
                                            _taniVar = true;
                                        }
                                    }

                                    if (!_taniVar)
                                    {
                                        _taniList.Clear();
                                        TaniListesi tani = new TaniListesi();
                                        tani.Kodu = d.Code;
                                        _taniList.Add(tani);
                                        _taniTeshisPair.Tanilar = _taniList;
                                    }

                                    _taniTeshisPairList.Add(_taniTeshisPair);
                                }
                            }
                            else
                            {
                                TaniTeshisPair _taniTeshisPair = new TaniTeshisPair();
                                _taniTeshisPair.Teshis = teshis;
                                //if (item.Teshis == null)
                                //{
                                //    objectContext.RollbackSavePoint(savePointGuid);
                                //    throw new TTUtils.TTException(d.Code + " Tanı Koduna ait Teshis Bilgisi Sistemde Tanımlı Değildir");
                                //    //break;
                                //}

                                _taniList.Clear();
                                TaniListesi tani = new TaniListesi();
                                tani.Kodu = d.Code;
                                _taniList.Add(tani);
                                _taniTeshisPair.Tanilar = _taniList;
                                _taniTeshisPairList.Add(_taniTeshisPair);
                            }
                        }

                        List<IlacRaporuServis.eraporTeshisDVO> _eraporTeshisDVOList = new List<IlacRaporuServis.eraporTeshisDVO>();
                        List<IlacRaporuServis.taniDVO> _taniDVOList = new List<IlacRaporuServis.taniDVO>();
                        foreach (TaniTeshisPair item in _taniTeshisPairList)
                        {
                            IlacRaporuServis.eraporTeshisDVO _eraporTeshisDVO = new IlacRaporuServis.eraporTeshisDVO();
                            _eraporTeshisDVO.baslangicTarihi = participatnFreeDrugReportImported.ReportStartDate != null ? participatnFreeDrugReportImported.ReportStartDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                            _eraporTeshisDVO.bitisTarihi = participatnFreeDrugReportImported.ReportEndDate != null ? participatnFreeDrugReportImported.ReportEndDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                            if (item.Teshis != null)
                                _eraporTeshisDVO.raporTeshisKodu = item.Teshis.teshisKodu != null ? item.Teshis.teshisKodu.ToString() : "";
                            else
                                _eraporTeshisDVO.raporTeshisKodu = "";
                            List<string> taniList = new List<string>();
                            foreach (TaniListesi taniItem in item.Tanilar)
                            {
                                taniList.Add(taniItem.Kodu);
                            }

                            taniList = Common.DiagnosesForMedula(taniList);
                            _taniDVOList.Clear();
                            foreach (string taniItem in taniList)
                            {
                                // _taniDVOList.Clear();
                                IlacRaporuServis.taniDVO _taniDVO = new IlacRaporuServis.taniDVO();
                                _taniDVO.kodu = taniItem;
                                _taniDVOList.Add(_taniDVO);
                            }

                            _eraporTeshisDVO.taniListesi = _taniDVOList.ToArray();
                            _eraporTeshisDVOList.Add(_eraporTeshisDVO);
                        }

                        if (_eraporTeshisDVOList != null && _eraporTeshisDVOList.Count > 0)
                            _eraporDVO.eraporTeshisListesi = _eraporTeshisDVOList.ToArray();
                        List<IlacRaporuServis.eraporDoktorDVO> _eraporDoktorDVOList = new List<IlacRaporuServis.eraporDoktorDVO>();
                        IlacRaporuServis.eraporDoktorDVO _eraporDoktorDVO = new IlacRaporuServis.eraporDoktorDVO();
                        _eraporDoktorDVO.tcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString(); //Zorunlu
                        _eraporDoktorDVO.sertifikaKodu = "0"; //Zorunlu
                        _eraporDoktorDVO.bransKodu = SpecialityDefinition.GetSpecialityByResUser(participatnFreeDrugReportImported.ProcedureDoctor) != null ? SpecialityDefinition.GetSpecialityByResUser(participatnFreeDrugReportImported.ProcedureDoctor).Code : "0"; //Zorunlu
                        _eraporDoktorDVO.adi = participatnFreeDrugReportImported.ProcedureDoctor.Person.Name;
                        _eraporDoktorDVO.soyadi = participatnFreeDrugReportImported.ProcedureDoctor.Person.Surname;
                        _eraporDoktorDVOList.Add(_eraporDoktorDVO);
                        if (participatnFreeDrugReportImported.CommitteeReport == true)
                        {
                            if (participatnFreeDrugReportImported.SecondDoctor == null)
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25929", "Heyet Raporlarında 2.Tabibi Seçmelisiniz!"));
                            if (participatnFreeDrugReportImported.ThirdDoctor == null)
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25930", "Heyet Raporlarında 3.Tabibi Seçmelisiniz!"));
                            if (participatnFreeDrugReportImported.SecondDoctor.Person.UniqueRefNo == null)
                            {
                                objectContext.RollbackSavePoint(savePointGuid);
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25081", "2.Doktor Kimlik Numarası Boş Olamaz"));
                            }

                            if (participatnFreeDrugReportImported.ThirdDoctor.Person.UniqueRefNo == null)
                            {
                                objectContext.RollbackSavePoint(savePointGuid);
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25086", "3.Doktor Kimlik Numarası Boş Olamaz"));
                            }

                            IlacRaporuServis.eraporDoktorDVO _eraporDoktorDVO2 = new IlacRaporuServis.eraporDoktorDVO();
                            _eraporDoktorDVO2.tcKimlikNo = participatnFreeDrugReportImported.SecondDoctor.Person.UniqueRefNo.Value.ToString(); //Zorunlu
                            _eraporDoktorDVO2.sertifikaKodu = "0"; //Zorunlu
                            _eraporDoktorDVO2.bransKodu = SpecialityDefinition.GetSpecialityByResUser(participatnFreeDrugReportImported.SecondDoctor) != null ? SpecialityDefinition.GetSpecialityByResUser(participatnFreeDrugReportImported.SecondDoctor).Code : "0"; //Zorunlu
                            _eraporDoktorDVO2.adi = participatnFreeDrugReportImported.SecondDoctor.Person.Name;
                            _eraporDoktorDVO2.soyadi = participatnFreeDrugReportImported.SecondDoctor.Person.Surname;
                            _eraporDoktorDVOList.Add(_eraporDoktorDVO2);
                            IlacRaporuServis.eraporDoktorDVO _eraporDoktorDVO3 = new IlacRaporuServis.eraporDoktorDVO();
                            _eraporDoktorDVO3.tcKimlikNo = participatnFreeDrugReportImported.ThirdDoctor.Person.UniqueRefNo.Value.ToString(); //Zorunlu
                            _eraporDoktorDVO3.sertifikaKodu = "0"; //Zorunlu
                            _eraporDoktorDVO3.bransKodu = SpecialityDefinition.GetSpecialityByResUser(participatnFreeDrugReportImported.ThirdDoctor) != null ? SpecialityDefinition.GetSpecialityByResUser(participatnFreeDrugReportImported.ThirdDoctor).Code : "0"; //Zorunlu
                            _eraporDoktorDVO3.adi = participatnFreeDrugReportImported.ThirdDoctor.Person.Name;
                            _eraporDoktorDVO3.soyadi = participatnFreeDrugReportImported.ThirdDoctor.Person.Surname;
                            _eraporDoktorDVOList.Add(_eraporDoktorDVO3);
                        }

                        _eraporDVO.eraporDoktorListesi = _eraporDoktorDVOList.ToArray();
                        List<IlacRaporuServis.eraporAciklamaDVO> _eraporAciklamaDVOList = new List<IlacRaporuServis.eraporAciklamaDVO>();
                        IlacRaporuServis.eraporAciklamaDVO _eraporAciklamaDVO2 = new IlacRaporuServis.eraporAciklamaDVO();
                        string raporAciklama = string.Empty;
                        raporAciklama = participatnFreeDrugReportImported.Description != null ? TTReportTool.TTReport.HTMLtoText(participatnFreeDrugReportImported.Description.ToString()) : "";
                        raporAciklama += participatnFreeDrugReportImported.TestsAndSigns != null ? (" " + TTReportTool.TTReport.HTMLtoText(participatnFreeDrugReportImported.TestsAndSigns.ToString())) : "";
                        _eraporAciklamaDVO2.aciklama = raporAciklama;
                        _eraporAciklamaDVOList.Add(_eraporAciklamaDVO2);
                        if (_eraporAciklamaDVOList != null && _eraporAciklamaDVOList.Count > 0)
                            _eraporDVO.eraporAciklamaListesi = _eraporAciklamaDVOList.ToArray();
                        List<IlacRaporuServis.eraporEtkinMaddeDVO> _eraporEtkinMaddeDVOList = new List<IlacRaporuServis.eraporEtkinMaddeDVO>();
                        foreach (EtkinMaddeListModel etkinMadde in viewModel.EtkinMaddeList)
                        {
                            EtkinMadde _etkinMadde = (EtkinMadde)objectContext.GetObject(etkinMadde.EtkinMadde, typeof(EtkinMadde));
                            if (_etkinMadde != null)
                            {
                                CheckParticipationFreeDrugDoseContent(etkinMadde.Doz2.ToString());
                                if (_etkinMadde.hastaGvnlikveIzlemFrmGerek.HasValue && _etkinMadde.hastaGvnlikveIzlemFrmGerek.Value == true)
                                {
                                    checkPatientApprovalFormNo = true;
                                    etkinMaddeAdi = _etkinMadde.etkinMaddeAdi;
                                }

                                IlacRaporuServis.eraporEtkinMaddeDVO _eraporEtkinMaddeDVO = new IlacRaporuServis.eraporEtkinMaddeDVO();
                                IlacRaporuServis.etkinMaddeDVO _etkinMaddeDVO = new IlacRaporuServis.etkinMaddeDVO();
                                _eraporEtkinMaddeDVO.etkinMaddeKodu = _etkinMadde.etkinMaddeKodu;
                                _eraporEtkinMaddeDVO.kullanimDoz1 = etkinMadde.Doz.ToString();
                                _eraporEtkinMaddeDVO.kullanimDoz2 = etkinMadde.Doz2.ToString().Replace(',', '.');
                                _eraporEtkinMaddeDVO.kullanimDozBirimi = ((int)etkinMadde.DozBirimi).ToString();
                                _eraporEtkinMaddeDVO.kullanimDozPeriyot = etkinMadde.Periyod.ToString();
                                _eraporEtkinMaddeDVO.kullanimDozPeriyotBirimi = ((int)etkinMadde.PeriyodBirimi).ToString();
                                _etkinMaddeDVO.kodu = _etkinMadde.etkinMaddeKodu;
                                _etkinMaddeDVO.adi = _etkinMadde.etkinMaddeAdi;
                                _etkinMaddeDVO.icerikMiktari = _etkinMadde.icerikMiktari;
                                _etkinMaddeDVO.formu = _etkinMadde.form != null ? _etkinMadde.form : "";
                                _eraporEtkinMaddeDVO.etkinMaddeDVO = _etkinMaddeDVO;
                                _eraporEtkinMaddeDVOList.Add(_eraporEtkinMaddeDVO);
                            }
                        }

                        if (String.IsNullOrEmpty(participatnFreeDrugReportImported.PatientApprovalFormNo) && checkPatientApprovalFormNo)
                            throw new Exception("'" + etkinMaddeAdi + "' etkin maddesi Hasta Güvenlik ve İzlem Formu gerektirir. 'Hasta Onay Form No' alanını giriniz. ");
                        if (_eraporEtkinMaddeDVOList != null && _eraporEtkinMaddeDVOList.Count > 0)
                            _eraporDVO.eraporEtkinMaddeListesi = _eraporEtkinMaddeDVOList.ToArray();
                        eraporGirisIstekDVO.eraporDVO = _eraporDVO;
                        participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;

                        string imzalanacakXml = Common.SerializeObjectToXml(_eraporDVO);
                        imzalanacakXml = imzalanacakXml.Replace("eraporDVO", "eraporBilgisi");
                        imzalanacakXml = imzalanacakXml.Replace("kisiDVO", "eraporKisiBilgisi");
                        imzalanacakXml = imzalanacakXml.Replace("eraporTaniListesi", "taniBilgisi");
                        imzalanacakXml = imzalanacakXml.Replace("eraporTeshisListesi", "eraporTeshisBilgisi");
                        imzalanacakXml = imzalanacakXml.Replace("eraporDoktorListesi", "eraporDoktorBilgisi");
                        imzalanacakXml = imzalanacakXml.Replace("eraporAciklamaListesi", "eraporAciklamaBilgisi");
                        imzalanacakXml = imzalanacakXml.Replace("eraporEtkinMaddeListesi", "eraporEtkinMaddeBilgisi");
                        imzalanacakXml = imzalanacakXml.Replace("etkinMaddeDVO", "etkinMaddeBilgisi");
                        imzalanacakXml = imzalanacakXml.Replace("taniListesi", "taniBilgisi");
                        return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }


            return output;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public IlacRaporuServis.imzaliEraporGirisCevapDVO SendSignedReportContent(SendReportApproveModel input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                var signedData = Convert.FromBase64String(input.signContent);
                Guid savePointGuid = objectContext.BeginSavePoint();

                var participatnFreeDrugReportImported = objectContext.GetObject<ParticipatnFreeDrugReport>(input.reportObjectID);

                IlacRaporuServis.imzaliEraporGirisIstekDVO eReportSignedRequest = new IlacRaporuServis.imzaliEraporGirisIstekDVO();
                long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                eReportSignedRequest.tesisKodu = Convert.ToString(saglikTesisKodu);
                eReportSignedRequest.doktorTcKimlikNo = currentUser.UniqueNo;
                eReportSignedRequest.surumNumarasi = "1";
                eReportSignedRequest.imzaliErapor = signedData;

                //var b = TTUtils.SerializationHelper.XmlSerializeObject(eReportSignedRequest);

                //IlacRaporuServis.imzaliEraporGirisCevapDVO resSorgu = IlacRaporuServis.WebMethods.imzaliEraporGirisSync(Sites.SiteLocalHost, currentUser.UniqueNo, currentUser.ErecetePassword, eReportSignedRequest);
                string username = "";
                string password = "";



                var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                if (MedulaPasswordCheck == "TRUE")
                {
                    if ((input.medulaUsername != null && input.medulaUsername != "") || (input.medulaPassword != null && input.medulaPassword != ""))
                    {
                        username = input.medulaUsername;
                        password = input.medulaPassword;
                        eReportSignedRequest.doktorTcKimlikNo = currentUser.UniqueNo;
                    }
                    else
                    {
                        throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                    {
                        /*TODO Burası sonra düzenlenecek
                        TTVisual.TTForm medulaPasswordForm = new TTFormClasses.MedulaPasswordForm();
                        medulaPasswordForm.ShowEdit(this.FindForm(), participatnFreeDrugReportImported, true);
                        */
                        if (string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword) && string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                        {
                            objectContext.RollbackSavePoint(savePointGuid);
                            throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");
                        }
                    }
                    username = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    eReportSignedRequest.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                        password = participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword;
                    else if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                        password = participatnFreeDrugReportImported.MedulaPassword;
                }
                IlacRaporuServis.imzaliEraporGirisCevapDVO response = IlacRaporuServis.WebMethods.imzaliEraporGirisSync(Sites.SiteLocalHost, username, password, eReportSignedRequest);
                if (response != null)
                {
                    var a = TTUtils.SerializationHelper.XmlSerializeObject(response);
                    var b = eReportSignedRequest;

                    if (response.sonucKodu == "0000")
                    {
                        if (participatnFreeDrugReportImported.MedulaReportResults != null)
                        {
                            if (participatnFreeDrugReportImported.MedulaReportResults.Count > 0)
                            {
                                MedulaReportResult medulaReportResult = (MedulaReportResult)objectContext.GetObject(participatnFreeDrugReportImported.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
                                medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Completed;
                                medulaReportResult.ReportNumber = participatnFreeDrugReportImported.ReportNo.ToString();
                                medulaReportResult.ReportRowNumber = 0; // response.eraporDVO != null ? Convert.ToInt32(response.eraporDVO) : 0;
                                medulaReportResult.ReportChasingNo = response.eraporDVO != null ? response.eraporDVO.raporTakipNo.ToString() : "";
                                if (response.eraporDVO != null)
                                    medulaReportResult.SendReportDate = Convert.ToDateTime(response.eraporDVO.raporTarihi);
                                medulaReportResult.ResultExplanation = TTUtils.CultureService.GetText("M26171", "İşlem başarı ile tamamlandı.");
                                medulaReportResult.ResultCode = response.sonucKodu;
                                objectContext.Update();
                                if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.New
                                    || participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.Report)
                                {
                                    if (participatnFreeDrugReportImported.CommitteeReport.HasValue && participatnFreeDrugReportImported.CommitteeReport.Value == true)
                                        participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.SecondDoctorApproval;
                                    else
                                        participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.Approval;
                                }

                                //participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.Completed;
                                participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;


                                medulaReportResult.ParticipatnFreeDrugReport = participatnFreeDrugReportImported;
                                participatnFreeDrugReportImported.IsSendedMedula = true;
                                objectContext.Save();
                            }
                            else
                            {
                                MedulaReportResult medulaReportResult = new MedulaReportResult(objectContext);
                                medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
                                medulaReportResult.ReportNumber = participatnFreeDrugReportImported.ReportNo.ToString();
                                medulaReportResult.ReportRowNumber = 0; //response.eraporDVO != null ? Convert.ToInt32(response.eraporDVO.raporNo) : 0;
                                medulaReportResult.ReportChasingNo = response.eraporDVO != null ? response.eraporDVO.raporTakipNo.ToString() : "";
                                if (response.eraporDVO != null)
                                    medulaReportResult.SendReportDate = Convert.ToDateTime(response.eraporDVO.raporTarihi);
                                medulaReportResult.ResultExplanation = TTUtils.CultureService.GetText("M26171", "İşlem başarı ile tamamlandı.");
                                medulaReportResult.ResultCode = response.sonucKodu;
                                objectContext.Update();
                                if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.New
                                    || participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.Report)
                                {
                                    if (participatnFreeDrugReportImported.CommitteeReport.HasValue && participatnFreeDrugReportImported.CommitteeReport.Value == true)
                                        participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.SecondDoctorApproval;
                                    else
                                        participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.Approval;
                                }
                                //objectContext.Save();

                                //participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.Completed;
                                participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;

                                medulaReportResult.ParticipatnFreeDrugReport = participatnFreeDrugReportImported;
                                participatnFreeDrugReportImported.IsSendedMedula = true;
                                objectContext.Save();
                            }
                        }
                        else
                        {
                            MedulaReportResult medulaReportResult = new MedulaReportResult(objectContext);
                            medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Completed;
                            medulaReportResult.ReportNumber = participatnFreeDrugReportImported.ReportNo.ToString();
                            medulaReportResult.ReportRowNumber = 0; // response.eraporDVO != null ? Convert.ToInt32(response.eraporDVO.raporNo) : 0;
                            medulaReportResult.ReportChasingNo = response.eraporDVO != null ? response.eraporDVO.raporTakipNo.ToString() : "";
                            if (response.eraporDVO != null)
                                medulaReportResult.SendReportDate = Convert.ToDateTime(response.eraporDVO.raporTarihi);
                            medulaReportResult.ResultExplanation = TTUtils.CultureService.GetText("M26171", "İşlem başarı ile tamamlandı.");
                            medulaReportResult.ResultCode = response.sonucKodu;
                            objectContext.Update();
                            if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.New
                                || participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.Report)
                            {
                                if (participatnFreeDrugReportImported.CommitteeReport.HasValue && participatnFreeDrugReportImported.CommitteeReport.Value == true)
                                    participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.SecondDoctorApproval;
                                else
                                    participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.Approval;
                            }
                            //objectContext.Save();

                            //participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.Completed;
                            participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;

                            medulaReportResult.ParticipatnFreeDrugReport = participatnFreeDrugReportImported;
                            participatnFreeDrugReportImported.IsSendedMedula = true;
                            objectContext.Save();
                        }
                    }
                    else
                    {
                        if (participatnFreeDrugReportImported.MedulaReportResults != null)
                        {
                            if (participatnFreeDrugReportImported.MedulaReportResults.Count > 0)
                            {
                                MedulaReportResult medulaReportResult = (MedulaReportResult)objectContext.GetObject(participatnFreeDrugReportImported.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
                                if (medulaReportResult.ReportChasingNo != null)
                                    throw new TTUtils.TTException(response.sonucMesaji);
                                medulaReportResult.ResultCode = response.sonucKodu.ToString();
                                medulaReportResult.ResultExplanation = response.sonucMesaji;
                                medulaReportResult.ResultCode = response.sonucKodu;
                                medulaReportResult.ParticipatnFreeDrugReport = participatnFreeDrugReportImported;
                                participatnFreeDrugReportImported.IsSendedMedula = false;
                                objectContext.Save();
                            }
                            else
                            {
                                MedulaReportResult medulaReportResult = new MedulaReportResult(objectContext);
                                medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
                                medulaReportResult.ResultCode = response.sonucKodu.ToString();
                                medulaReportResult.ResultExplanation = response.sonucMesaji;
                                medulaReportResult.ReportNumber = "0";
                                medulaReportResult.ParticipatnFreeDrugReport = participatnFreeDrugReportImported;
                                //medulaReportResult.SendReportDate = DateTime.Now;
                                participatnFreeDrugReportImported.IsSendedMedula = false;
                                objectContext.Save();
                            }
                        }
                        else
                        {
                            MedulaReportResult medulaReportResult = new MedulaReportResult(objectContext);
                            medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
                            medulaReportResult.ResultCode = response.sonucKodu.ToString();
                            medulaReportResult.ResultExplanation = response.sonucMesaji;
                            medulaReportResult.ReportNumber = "0";
                            medulaReportResult.ParticipatnFreeDrugReport = participatnFreeDrugReportImported;
                            //medulaReportResult.SendReportDate = DateTime.Now;
                            participatnFreeDrugReportImported.IsSendedMedula = false;
                            objectContext.Save();
                        }
                    }
                }

                return response;
            }
        }

        public SentItemContainerForDrugReport FillContainerModel(ParticipatnFreeDrugReport participatnFreeDrugReport)
        {
            SentItemContainerForDrugReport sentItemContainerForDrugReport = new SentItemContainerForDrugReport();

            sentItemContainerForDrugReport.EtkinMaddeList = new List<EtkinMaddeListModel>();
            foreach (ParticipationFreeDrgGrid participationFreeDrgGrid in participatnFreeDrugReport.ParticipationFreeDrugs)
            {
                EtkinMaddeListModel etkinMadde = new EtkinMaddeListModel();
                etkinMadde.ParticipatientFreeDrugObjectID = participationFreeDrgGrid.ObjectID;
                etkinMadde.EtkinMadde = participationFreeDrgGrid.EtkinMadde.ObjectID;
                etkinMadde.EtkinMaddeName = participationFreeDrgGrid.EtkinMadde.etkinMaddeKodu + " : " + participationFreeDrgGrid.EtkinMadde.etkinMaddeAdi;
                etkinMadde.EtkinMaddeMudalaHarici = participationFreeDrgGrid.DrugName;
                etkinMadde.DozAraligi = (FrequencyEnum)participationFreeDrgGrid.Frequency;
                etkinMadde.Doz = Convert.ToDouble(participationFreeDrgGrid.MedulaDoseInteger);
                etkinMadde.Doz2 = Convert.ToDouble(participationFreeDrgGrid.MedulaUsageDose2);
                etkinMadde.DozBirimi = (UsageDoseUnitTypeEnum)participationFreeDrgGrid.UsageDoseUnitType;
                etkinMadde.Periyod = Convert.ToInt32(participationFreeDrgGrid.Day);
                etkinMadde.PeriyodBirimi = (PeriodUnitTypeEnum)participationFreeDrgGrid.PeriodUnitType;
                sentItemContainerForDrugReport.EtkinMaddeList.Add(etkinMadde);
                if (participationFreeDrgGrid.MedulaDose != null && participationFreeDrgGrid.MedulaDoseInteger == null)
                    participationFreeDrgGrid.MedulaDoseInteger = participationFreeDrgGrid.MedulaDose.ToString();

                EtkenMaddeTeshisListModel etkenMaddeTeshis = new EtkenMaddeTeshisListModel();
                etkenMaddeTeshis.etkenMaddeObjectId = participationFreeDrgGrid.EtkinMadde.ObjectID;
                etkenMaddeTeshis.TeshisList = new List<TeshisListModel>();
                sentItemContainerForDrugReport.TeshisList = new List<TeshisListModel>();
                sentItemContainerForDrugReport.SelectedTeshisTaniList = new List<AddedDiagnosisListModel>();
                List<TeshisListModel> teshisTaniList = new List<TeshisListModel>();
                teshisTaniList.AddRange(GetTeshisTani(etkenMaddeTeshis));
                foreach (TeshisListModel item in teshisTaniList)
                {
                    TeshisListModel result = sentItemContainerForDrugReport.TeshisList.Where(t => t.teshis.ObjectID == item.teshis.ObjectID).FirstOrDefault();
                    if (result == null)
                    {
                        sentItemContainerForDrugReport.TeshisList.Add(item);
                    }
                    else
                    {
                        result.relatedEtkenMaddeList.Add(item.relatedEtkenMaddeList[0]);
                        result.relatedEtkenMaddeNames += ", " + item.relatedEtkenMaddeList[0].etkinMaddeAdi;
                    }
                }
            }

            return sentItemContainerForDrugReport;
        }
        private void CheckParticipationFreeDrugs(ParticipatnFreeDrugReport participatnFreeDrugReportImported)
        {
            foreach (ParticipationFreeDrgGrid pd in participatnFreeDrugReportImported.ParticipationFreeDrugs)
            {
                if (pd.EtkinMadde == null && pd.DrugName == null)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25936", "Hiçbir etkin madde seçmeden devam edemezsiniz!"));
            }
        }

        public TeshisListModel[] GetTeshisTani(EtkenMaddeTeshisListModel etkenMaddeTeshisList)
        {
            string anaTaniGoster = TTObjectClasses.SystemParameter.GetParameterValue("ANATANIGOSTER", "FALSE");

            List<TeshisListModel> teshisList = new List<TeshisListModel>();
            using (var objectContext = new TTObjectContext(false))
            {
                EtkinMadde etkinMsdde = (EtkinMadde)objectContext.GetObject(etkenMaddeTeshisList.etkenMaddeObjectId, typeof(EtkinMadde));
                foreach (TeshisEtkinMaddeGrid etkinMadde in etkinMsdde.TeshisEtkinMaddeGrid)
                {
                    TeshisListModel teshis = new TeshisListModel();
                    teshis.teshis = etkinMadde.Teshis;
                    teshis.teshisAdi = etkinMadde.Teshis.teshisAdi;
                    teshis.teshisKodu = etkinMadde.Teshis.teshisKodu.ToString();
                    List<AddedDiagnosisListModel> diagnosisList = new List<AddedDiagnosisListModel>();
                    foreach (DiagnosisDefTeshis diagnose in etkinMadde.Teshis.DiagnosisDefTeshis)
                    {
                        AddedDiagnosisListModel diagnosis = new AddedDiagnosisListModel();
                        diagnosis.Tani = diagnose.DiagnosisDefinition;
                        diagnosis.teshisObjectID = etkinMadde.Teshis.ObjectID;
                        diagnosis.taniAdi = diagnose.DiagnosisDefinition.Name;
                        diagnosis.taniKodu = diagnose.DiagnosisDefinition.Code;
                        if (anaTaniGoster == "FALSE")
                        {
                            if (diagnose.DiagnosisDefinition.IsLeaf.HasValue && diagnose.DiagnosisDefinition.IsLeaf == true)
                            {
                                diagnosisList.Add(diagnosis);
                            }
                        }
                        else
                        {
                            diagnosisList.Add(diagnosis);
                        }
                    }
                    teshis.AddedDiagnosisList = diagnosisList;
                    teshis.relatedEtkenMaddeList.Add(etkinMsdde);
                    teshis.relatedEtkenMaddeNames += etkinMsdde.etkinMaddeAdi;
                    teshisList.Add(teshis);

                    //etkenMaddeTeshisList.TeshisList.Add(teshis);
                }
                return teshisList.ToArray();
            }
        }

        private void CheckParticipationFreeDrugDoseContent(string dose)
        {
            char[] characters = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',' };
            if (!string.IsNullOrEmpty(dose))
            {
                foreach (Char doseCh in dose)
                {
                    bool ctrl = false;
                    foreach (Char ch in characters)
                    {
                        if (doseCh.Equals(ch))
                            ctrl = true;
                    }

                    if (ctrl == false)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25535", "Doz değerine sayısal karakterler ve . haricinde giriş yapılamaz!"));
                }
            }

            if (dose.Length > 5)
            {
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25534", "Doz değerine 5 karakterden fazla giriş yapılamaz!"));
            }
        }

        private class TaniTeshisPair
        {
            private Teshis teshis;
            public Teshis Teshis
            {
                get
                {
                    return teshis;
                }

                set
                {
                    teshis = value;
                }
            }

            private List<TaniListesi> tanilar;
            public List<TaniListesi> Tanilar
            {
                get
                {
                    return tanilar;
                }

                set
                {
                    tanilar = value;
                }
            }
        }

        private class TaniListesi
        {
            private string kodu;
            public string Kodu
            {
                get
                {
                    return kodu;
                }

                set
                {
                    kodu = value;
                }
            }
        }

        [HttpPost]
        public string PrepareSignedReportApproveContent(SendReportApproveModel approveModel)
        {
            string output = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = objectContext.GetObject<ParticipatnFreeDrugReport>(approveModel.reportObjectID);
                MedulaReportResult currentMedulaReportResult = participatnFreeDrugReportImported.MedulaReportResults[0];
                if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                {
                    IlacRaporuServis.eraporOnayIstekDVO eraporOnayIstekDVO = new IlacRaporuServis.eraporOnayIstekDVO();
                    eraporOnayIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    eraporOnayIstekDVO.raporTakipNo = currentMedulaReportResult.ReportChasingNo;
                    string password = "";
                    string uniqueRefNo = "";
                    //if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.Completed)

                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((approveModel.medulaUsername != null && approveModel.medulaUsername != "") || (approveModel.medulaPassword != null && approveModel.medulaPassword != ""))
                        {
                            eraporOnayIstekDVO.doktorTcKimlikNo = approveModel.medulaUsername;
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
                            uniqueRefNo = participatnFreeDrugReportImported.SecondDoctor.Person.UniqueRefNo.Value.ToString();
                            eraporOnayIstekDVO.doktorTcKimlikNo = uniqueRefNo;
                        }

                        //if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval)
                        if (approveModel.isThirdDoctorApprove)
                        {
                            uniqueRefNo = participatnFreeDrugReportImported.ThirdDoctor.Person.UniqueRefNo.Value.ToString();
                            eraporOnayIstekDVO.doktorTcKimlikNo = uniqueRefNo;
                        }

                    }
                    string imzalanacakXml = Common.SerializeObjectToXml(eraporOnayIstekDVO);
                    imzalanacakXml = imzalanacakXml.Replace("eraporOnayIstekDVO", "imzaliEraporOnayBilgisi");

                    return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
                }

            }
            return output;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public IlacRaporuServis.imzaliEraporOnayCevapDVO SendSignedReportApproveContent(SendReportApproveModel approveModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = objectContext.GetObject<ParticipatnFreeDrugReport>(approveModel.reportObjectID);
                MedulaReportResult currentMedulaReportResult = participatnFreeDrugReportImported.MedulaReportResults[0];
                var signedData = Convert.FromBase64String(approveModel.signContent);
                string username = "";
                string password = "";
                string uniqueRefNo = "";
                if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                {
                    IlacRaporuServis.imzaliEraporOnayIstekDVO eraporOnayIstekDVO = new IlacRaporuServis.imzaliEraporOnayIstekDVO();
                    eraporOnayIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    eraporOnayIstekDVO.imzaliEraporOnay = signedData;
                    eraporOnayIstekDVO.surumNumarasi = 1;



                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((approveModel.medulaUsername != null && approveModel.medulaUsername != "") || (approveModel.medulaPassword != null && approveModel.medulaPassword != ""))
                        {
                            eraporOnayIstekDVO.doktorTcKimlikNo = approveModel.medulaUsername;
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
                            uniqueRefNo = participatnFreeDrugReportImported.SecondDoctor.Person.UniqueRefNo.Value.ToString();
                            eraporOnayIstekDVO.doktorTcKimlikNo = uniqueRefNo;
                            if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.SecondDoctor.ErecetePassword))
                                password = participatnFreeDrugReportImported.SecondDoctor.ErecetePassword;
                            else
                                throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");
                        }
                        else if (approveModel.isThirdDoctorApprove)
                        {
                            uniqueRefNo = participatnFreeDrugReportImported.ThirdDoctor.Person.UniqueRefNo.Value.ToString();
                            eraporOnayIstekDVO.doktorTcKimlikNo = uniqueRefNo;
                            if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ThirdDoctor.ErecetePassword))
                                password = participatnFreeDrugReportImported.ThirdDoctor.ErecetePassword;
                            else
                                throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");
                        }

                    }


                    IlacRaporuServis.imzaliEraporOnayCevapDVO response = IlacRaporuServis.WebMethods.imzaliEraporOnaySync(Sites.SiteLocalHost, uniqueRefNo, password, eraporOnayIstekDVO);
                    if (response != null && response.sonucKodu != null && (response.sonucKodu == "0000" || response.sonucKodu == "RAP_0052"))
                    {
                        if (participatnFreeDrugReportImported.CommitteeReport == true)
                        {
                            if (uniqueRefNo == participatnFreeDrugReportImported.SecondDoctor.UniqueNo)
                            {
                                participatnFreeDrugReportImported.IsSecondDoctorApproved = true;
                            }
                            else if (uniqueRefNo == participatnFreeDrugReportImported.ThirdDoctor.UniqueNo)
                            {
                                participatnFreeDrugReportImported.IsThirdDoctorApproved = true;
                            }
                        }
                        //if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.Completed)
                        if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.Completed ||
                            participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval)
                        {
                            participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.SecondDoktorApprove;
                            //participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.SecondDoctorApproval;
                            participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.ThirdDoctorApproval;
                            participatnFreeDrugReportImported.SecondDoctorApproval = 1;
                        }
                        //else if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval)
                        else if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.ThirdDoctorApproval)
                        {
                            participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.ThirdDoktorApprove;
                            //participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.ThirdDoctorApproval;
                            participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.Approval;
                            participatnFreeDrugReportImported.ThirdDoctorApproval = 1;
                        }

                        // viewModel._ParticipatnFreeDrugReport = participatnFreeDrugReportImported;
                        objectContext.Save();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(response.sonucMesaji) || !string.IsNullOrEmpty(response.uyariMesaji))
                        {
                            //if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.Completed)
                            if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.Completed ||
                                participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval)
                                participatnFreeDrugReportImported.SecondDoctorApproval = 0;
                            //else if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval)
                            else if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.ThirdDoctorApproval)
                                participatnFreeDrugReportImported.ThirdDoctorApproval = 0;
                            objectContext.Save();
                            if (response.sonucMesaji == "The request failed with HTTP status 401: Unauthorized." || response.uyariMesaji == "The request failed with HTTP status 401: Unauthorized.")
                            {
                                //if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.Completed)
                                if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.Completed ||
                                    participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval)
                                    throw new Exception(participatnFreeDrugReportImported.SecondDoctor.Person.FullName + "TC ve E-Reçete Şifresi Uyuşmazlığı");
                                //else if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval)
                                else if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.ThirdDoctorApproval)
                                    throw new Exception(participatnFreeDrugReportImported.ThirdDoctor.Person.FullName + "TC ve E-Reçete Şifresi Uyuşmazlığı");
                            }
                        }
                    }

                    return response;
                }
            }
            return null;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public MedulaResult eRaporGiris(SendReportApproveModel inputModel)
        {
            MedulaResult model = new MedulaResult();
            try
            {
                ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                using (var objectContext = new TTObjectContext(false))
                {

                    var medicalStuffReport = objectContext.GetObject<MedicalStuffReport>(inputModel.reportObjectID);

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
                    if (medicalStuffReport.ReportDiagnosis != null)
                    {
                        foreach (ReportDiagnosis item in medicalStuffReport.ReportDiagnosis)
                        {
                            taniList.Add(item.Diagnose.Code);
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
                        if ((inputModel.medulaUsername != null && inputModel.medulaUsername != "") || (inputModel.medulaPassword != null && inputModel.medulaPassword != ""))
                        {
                            username = inputModel.medulaUsername;
                            password = inputModel.medulaPassword;
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
                    medicalStuffReport.RaporGidenXML = TTUtils.SerializationHelper.XmlSerializeObject(raporGirisDVO);

                    TibbiMalzemeERaporIslemleri.eRaporGirisCevapDVO response = TibbiMalzemeERaporIslemleri.WebMethods.eRaporGirisSync(TTObjectClasses.Sites.SiteLocalHost, username, password, raporGirisDVO);

                    if (response != null)
                    {
                        if (response.sonucKodu == "0000")
                        {
                            medicalStuffReport.RaporTakipNo = response.eRaporDVO.raporTakipNo.ToString();
                            medicalStuffReport.RaporGelenXML = TTUtils.SerializationHelper.XmlSerializeObject(response);
                            medicalStuffReport.RaporGidenXML = TTUtils.SerializationHelper.XmlSerializeObject(raporGirisDVO);
                            medicalStuffReport.IsSendedMedula = true;

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
        public bool getMyDisapprovedReportExistance()
        {
            ResUser currentUser = Common.CurrentResource;
            if (Common.CurrentUser.HasRole(TTRoleNames.Tabip) || Common.CurrentUser.IsSuperUser)
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    DateTime WorkListStartDate = Common.RecTime();
                    DateTime WorkListEndDate = Common.RecTime();
                    int dateInterval = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("RAPOREKRANIGUNARALIGI", "30"));
                    WorkListStartDate = WorkListEndDate.AddDays(-dateInterval);
                    string whereCriteria_For_ParticipatnFreeDrugReport = " AND this.REQUESTDATE BETWEEN " + GetDateAsString(WorkListStartDate) + " AND " + GetDateAsString(WorkListEndDate);
                    string whereCriteria_For_MedicalStuffReport = " AND this.REQUESTDATE BETWEEN " + GetDateAsString(WorkListStartDate) + " AND " + GetDateAsString(WorkListEndDate);
                    if (!Common.CurrentUser.IsSuperUser)
                    {
                        whereCriteria_For_MedicalStuffReport += "AND (this.PROCEDUREDOCTOR = '" + currentUser.ObjectID.ToString() + "' OR this.seconddoctor = '" + currentUser.ObjectID.ToString() + "' OR this.thirdDoctor = '" + currentUser.ObjectID.ToString() + "')";
                        whereCriteria_For_ParticipatnFreeDrugReport += " AND (this.PROCEDUREDOCTOR='" + currentUser.ObjectID.ToString() + "' OR this.seconddoctor='" + currentUser.ObjectID.ToString() + "' OR this.thirdDoctor='" + currentUser.ObjectID.ToString() + "') ";
                    }
                    var reportList = ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportForWL(objectContext, whereCriteria_For_ParticipatnFreeDrugReport);
                    if (reportList.Count > 0)
                        return true;
                    var stuffReportList = MedicalStuffReport.GetMedicalStuffReportForWL(objectContext, whereCriteria_For_MedicalStuffReport);
                    if (stuffReportList.Count > 0)
                        return true;
                    else
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public TibbiMalzemeERaporIslemleri.eRaporOnayCevapDVO Onay(SendReportApproveModel approveModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var medicalStuffReportObj = objectContext.GetObject<MedicalStuffReport>(approveModel.reportObjectID);
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
                            if (medicalStuffReportObj.CurrentStateDefID == MedicalStuffReport.States.SecondDoctorApproval)
                            {
                                /*if(currentUser.ObjectID != medicalStuffReportObj.SecondDoctor.ObjectID)
                                {
                                    throw new TTUtils.TTException("Diğer Hekim Yerine Onay Yapamazsınız.");
                                }*/
                                uniqueRefNo = medicalStuffReportObj.SecondDoctor.Person.UniqueRefNo.Value.ToString();
                                eRaporOnayIstekDVO.doktorTcKimlikNo = uniqueRefNo;
                                if (!string.IsNullOrEmpty(medicalStuffReportObj.SecondDoctor.ErecetePassword))
                                    password = medicalStuffReportObj.SecondDoctor.ErecetePassword;
                                else
                                    throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");
                            }

                            if (medicalStuffReportObj.CurrentStateDefID == MedicalStuffReport.States.ThirdDoctorApproval)
                            {
                                /*if (currentUser.ObjectID != medicalStuffReportObj.SecondDoctor.ObjectID)
                                {
                                    throw new TTUtils.TTException("Diğer Hekim Yerine Onay Yapamazsınız.");
                                }*/
                                uniqueRefNo = medicalStuffReportObj.ThirdDoctor.Person.UniqueRefNo.Value.ToString();
                                eRaporOnayIstekDVO.doktorTcKimlikNo = uniqueRefNo;
                                if (!string.IsNullOrEmpty(medicalStuffReportObj.ThirdDoctor.ErecetePassword))
                                    password = medicalStuffReportObj.ThirdDoctor.ErecetePassword;
                                else
                                    throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");
                            }

                        }
                        TibbiMalzemeERaporIslemleri.eRaporOnayCevapDVO response = TibbiMalzemeERaporIslemleri.WebMethods.doktorERaporOnayVeIptalSync(Sites.SiteLocalHost, uniqueRefNo, password, eRaporOnayIstekDVO);

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
                        if (response != null && response.sonucKodu != null && response.sonucKodu == "0000")
                        {
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
        public UserPropertiesModel GetActiveUserProperties()
        {
            UserPropertiesModel returnModel = new UserPropertiesModel();
            bool showAllButtons = false;
            var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("RAPORONAYEKRANITUMBUTONLARIGOSTER", "FALSE");
            if (MedulaPasswordCheck == "TRUE")
                showAllButtons = true;
            returnModel.UniqueRefNo = Common.CurrentResource.UniqueNo;
            returnModel.hasRoleToSeeAllButtons = Common.CurrentUser.IsSuperUser || showAllButtons;

            return returnModel;
        }

        [HttpGet]

        public string getUniqueRefnoOfApproveUser(Guid reportID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                MedicalStuffReport reportObj = objectContext.GetObject<MedicalStuffReport>(reportID);
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
    }


}

namespace Core.Models
{
    public class ReportApproveListSearchCriteria
    {
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }

    public class ReportApproveListItem : ExaminationWorkListItem
    {
        public string ItemType { get; set; }
        public string currentStateText { get; set; }
        public int currentStateID { get; set; }     //1 : Medulaya Gönderim Bekliyor, 2: Hekim Onayında, 3: Başhekim Onayında
        public string procedureDoctorUniqueRefNo { get; set; }
        public string secondDoctorName { get; set; }
        public string secondDoctorUniqueRefNo { get; set; }
        public bool secondDoctorApprovalStatus { get; set; }
        public string thirdDoctorName { get; set; }
        public string thirdDoctorUniqueRefNo { get; set; }
        public bool thirdDoctorApprovalStatus { get; set; }
        public string disapprovedUsers { get; set; }
    }

    public class SendReportApproveModel
    {
        public string signContent
        {
            get;
            set;
        }
        public Guid reportObjectID { get; set; }
        public string medulaUsername { get; set; }
        public string medulaPassword { get; set; }
        public bool isSecondDoctorApprove = false;
        public bool isThirdDoctorApprove = false;
    }

    public class SentItemContainerForDrugReport
    {
        public List<TeshisListModel> TeshisList
        {
            get;
            set;
        }

        public List<AddedDiagnosisListModel> SelectedTeshisTaniList
        {
            get;
            set;
        }

        public List<EtkinMaddeListModel> EtkinMaddeList
        {
            get;
            set;
        }

    }

    public class UserPropertiesModel
    {
        public string UniqueRefNo { get; set; }
        public bool hasRoleToSeeAllButtons { get; set; }
    }


}