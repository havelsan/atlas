//$85D1EF9A
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
using System.Text;
using Infrastructure.Models;

namespace Core.Controllers
{
    public partial class ParticipatnFreeDrugReportServiceController
    {
         public class TeshisImzalanacakXml
        {
            //Type 1 teshis type 2 ilave deger
            public byte Type { get; set; }
            public string imzalanacakXml { get; set; }
        }

        public List<int> diabetTeshis07_02_1_Array = new List<int> { 246, 247, 50, 51, 52, 53, 54,55,56, 244, 271 };
        partial void PreScript_ParticipationFreeDrugReportNewForm(ParticipationFreeDrugReportNewFormViewModel viewModel, ParticipatnFreeDrugReport participatnFreeDrugReport, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionObjectID.HasValue && viewModel._ParticipatnFreeDrugReport.MasterAction == null)
            {
                EpisodeAction episodeAction = participatnFreeDrugReport.ObjectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                viewModel._ParticipatnFreeDrugReport.MasterAction = episodeAction;
                viewModel._ParticipatnFreeDrugReport.MasterResource = episodeAction.MasterResource;
                viewModel._ParticipatnFreeDrugReport.FromResource = episodeAction.MasterResource;
                viewModel._ParticipatnFreeDrugReport.Episode = episodeAction.Episode;
                var P = viewModel._ParticipatnFreeDrugReport.Episode.Patient; //Contexe patient ı yüklemediği için yazıldı silmeyin
                viewModel._ParticipatnFreeDrugReport.ProcedureDoctor = episodeAction.ProcedureDoctor;
                viewModel._ParticipatnFreeDrugReport.SubEpisode = episodeAction.SubEpisode;
                viewModel._ParticipatnFreeDrugReport.ActionDate = System.DateTime.Now;
                /*if (episodeAction is InPatientPhysicianApplication)
                {
                    if (((InPatientPhysicianApplication)episodeAction).SubEpisode.InpatientAdmission != null)
                    {
                        viewModel._ParticipatnFreeDrugReport.ReportStartDate = ((InPatientPhysicianApplication)episodeAction).SubEpisode.InpatientAdmission.HospitalInPatientDate;
                    }
                }*/
                if (episodeAction is PatientExamination)
                    viewModel._ParticipatnFreeDrugReport.ExaminationDate = ((PatientExamination)episodeAction).ProcessDate;
                else
                {
                    foreach (EpisodeAction ea in episodeAction.Episode.EpisodeActions)
                    {
                        if (ea is PatientExamination && ea.IsCancelled == false)
                        {
                            PatientExamination patientExamination = (PatientExamination)ea;
                            viewModel._ParticipatnFreeDrugReport.ExaminationDate = patientExamination.ProcessDate != null ? patientExamination.ProcessDate : null;
                        }
                    }
                    if (viewModel._ParticipatnFreeDrugReport.ExaminationDate == null)
                        viewModel._ParticipatnFreeDrugReport.ExaminationDate = episodeAction.ActionDate;
                }

                // Kullanılmayan bir data dolduruyor
                //if (viewModel._ParticipatnFreeDrugReport.Diagnosis.Count == 0)
                //{
                //    viewModel.TaniTeshisList = new List<TaniTeshisListModel>();
                //    foreach (DiagnosisGrid diagnosis in episodeAction.Episode.Diagnosis)
                //    {
                //        if (diagnosis.TaniTeshisİliskisi != null && diagnosis.TaniTeshisİliskisi.Count > 0)
                //        {
                //            foreach (TaniTeshisİliskisi item in diagnosis.TaniTeshisİliskisi)
                //            {
                //                TaniTeshisListModel taniTeshis = new TaniTeshisListModel();
                //                taniTeshis.Tani = diagnosis.Diagnose.ObjectID;
                //                taniTeshis.Teshis = item.Teshis != null ? item.Teshis.ObjectID : Guid.Empty;
                //                viewModel.TaniTeshisList.Add(taniTeshis);
                //            }
                //        }
                //        else
                //        {
                //            TaniTeshisListModel taniTeshis = new TaniTeshisListModel();
                //            taniTeshis.Tani = diagnosis.Diagnose.ObjectID;
                //            taniTeshis.Teshis = Guid.Empty;
                //            viewModel.TaniTeshisList.Add(taniTeshis);
                //        }
                //    }
                //}



            }

            var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, viewModel._ParticipatnFreeDrugReport.ObjectDef.ID, "DrugReportTemplate").ToList();
            viewModel.userTemplateList = new List<UserTemplateModel>();
            foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList.Where(t => t.TAObjectID.ToString() != viewModel._ParticipatnFreeDrugReport.ObjectID.ToString()))
            {
                UserTemplateModel templateModel = new UserTemplateModel();
                templateModel.ObjectID = item.ObjectID;
                templateModel.TAObjectID = item.TAObjectID;
                templateModel.TAObjectDefID = item.TAObjectDefID;
                templateModel.Description = item.Description;
                viewModel.userTemplateList.Add(templateModel);
            }
            //viewModel.userTemplateList = 
            //Hasta SGK lı mı?
            viewModel.IsPatientSGK = viewModel._ParticipatnFreeDrugReport.SubEpisode != null ? viewModel._ParticipatnFreeDrugReport.SubEpisode.IsSGK : false;
            //TODO : Burcu Test edebilmek için konuldu.
            viewModel.closeMedula = TTObjectClasses.SystemParameter.GetParameterValue("CLOSEMEDULAFORPARTICIPATNFREEDRGREPORT", "FALSE") == "TRUE" ? true : false;

            //tanı kontrolü
            participatnFreeDrugReport.CheckForDiagnosis();

            foreach (FrequencyEnum frequency in Enum.GetValues(typeof(FrequencyEnum)))
            {
                DozAraligiListModel dozAraligi = new DozAraligiListModel();
                dozAraligi.DozAraligiText = Common.GetEnumValueDefOfEnumValue(frequency).DisplayText;
                dozAraligi.DozAraligiID = (int)frequency;
                viewModel.DozAraligiList.Add(dozAraligi);
            }

            if (viewModel._ParticipatnFreeDrugReport.ReportStartDate == null)
                viewModel._ParticipatnFreeDrugReport.ReportStartDate = DateTime.Now;

            if (Common.CurrentUser.IsSuperUser != true)
            {
                viewModel.IsSuperUser = false;
                if (Common.CurrentResource.UserType == UserTypeEnum.Doctor || Common.CurrentResource.UserType == UserTypeEnum.Dentist)
                {
                    if (viewModel._ParticipatnFreeDrugReport.ProcedureDoctor == null)
                    {
                        viewModel._ParticipatnFreeDrugReport.ProcedureDoctor = Common.CurrentResource;
                    }
                }
            }
            else
                viewModel.IsSuperUser = true;
            if (viewModel._ParticipatnFreeDrugReport.CommitteeReport == true)
            {
                //if (viewModel._ParticipatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval)
                //{
                //    if (viewModel._ParticipatnFreeDrugReport.SecondDoctor != null)
                //    {
                //        if (viewModel.IsSuperUser == false && viewModel._ParticipatnFreeDrugReport.SecondDoctor.ObjectID.ToString() != Common.CurrentResource.ObjectID.ToString())
                //        {
                //            viewModel.SecondDoctorApprove = true;
                //        }
                //    }
                //}
                viewModel.secondDoctor = viewModel._ParticipatnFreeDrugReport.SecondDoctor.UniqueNo;
                viewModel.thirdDoctor = viewModel._ParticipatnFreeDrugReport.ThirdDoctor.UniqueNo;
                if (viewModel._ParticipatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.ThirdDoctorApproval)
                {
                    if (viewModel._ParticipatnFreeDrugReport.ThirdDoctor != null)
                    {
                        if (viewModel.IsSuperUser == false && viewModel._ParticipatnFreeDrugReport.ThirdDoctor.ObjectID.ToString() != Common.CurrentResource.ObjectID.ToString())
                        {
                            //viewModel.ThirdDoctorApprove = true;
                            viewModel.SecondDoctorApprove = true;
                        }
                    }
                }

                if (viewModel._ParticipatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.Approval)
                {
                    if (viewModel._ParticipatnFreeDrugReport.ThirdDoctor != null)
                    {
                        if (viewModel.IsSuperUser == false && viewModel._ParticipatnFreeDrugReport.ThirdDoctor.ObjectID.ToString() != Common.CurrentResource.ObjectID.ToString())
                        {
                            viewModel.ThirdDoctorApprove = true;
                        }
                    }
                }
            }

            if (viewModel._ParticipatnFreeDrugReport.ExaminationDate == null)
                viewModel._ParticipatnFreeDrugReport.ExaminationDate = DateTime.Now;
            if (viewModel.TeshistStartDate == null || viewModel.TeshistStartDate != null)
                viewModel.TeshistStartDate = DateTime.Now;
            if (viewModel.TeshisEndDate == null || viewModel.TeshisEndDate != null)
                viewModel.TeshisEndDate = DateTime.Now;
            if (viewModel._ParticipatnFreeDrugReport.ParticipationFreeDrugs.Count > 0)
            {
                viewModel.EtkinMaddeList = new List<EtkinMaddeListModel>();
                foreach (ParticipationFreeDrgGrid participationFreeDrgGrid in viewModel._ParticipatnFreeDrugReport.ParticipationFreeDrugs)
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
                    viewModel.EtkinMaddeList.Add(etkinMadde);
                    if (participationFreeDrgGrid.MedulaDose != null && participationFreeDrgGrid.MedulaDoseInteger == null)
                        participationFreeDrgGrid.MedulaDoseInteger = participationFreeDrgGrid.MedulaDose.ToString();

                    EtkenMaddeTeshisListModel etkenMaddeTeshis = new EtkenMaddeTeshisListModel();
                    etkenMaddeTeshis.etkenMaddeObjectId = participationFreeDrgGrid.EtkinMadde.ObjectID;
                    etkenMaddeTeshis.TeshisList = new List<TeshisListModel>();
                    List<TeshisListModel> teshisTaniList = new List<TeshisListModel>();
                    teshisTaniList.AddRange(GetTeshisTani(etkenMaddeTeshis));
                    foreach (TeshisListModel item in teshisTaniList)
                    {
                        TeshisListModel result = viewModel.TeshisList.Where(t => t.teshis.ObjectID == item.teshis.ObjectID).FirstOrDefault();
                        if (result == null)
                        {
                            viewModel.TeshisList.Add(item);
                        }
                        else
                        {
                            result.relatedEtkenMaddeList.Add(item.relatedEtkenMaddeList[0]);
                            result.relatedEtkenMaddeNames += ", " + item.relatedEtkenMaddeList[0].etkinMaddeAdi;
                        }
                    }
                }

                foreach (ReportDiagnosis reportDiagnosis in viewModel._ParticipatnFreeDrugReport.ReportDiagnosis)
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
            }
            if (viewModel._ParticipatnFreeDrugReport.MasterAction is InPatientPhysicianApplication)
            {
                if (((InPatientPhysicianApplication)viewModel._ParticipatnFreeDrugReport.MasterAction).SubEpisode.InpatientAdmission != null)
                {
                    //viewModel._MedulaTreatmentReport.StartDate = ((InPatientPhysicianApplication)episodeAction).SubEpisode.InpatientAdmission.HospitalInPatientDate;
                    viewModel.minReportDate = ((DateTime)((InPatientPhysicianApplication)viewModel._ParticipatnFreeDrugReport.MasterAction).SubEpisode.InpatientAdmission.HospitalInPatientDate).ToString("MM.dd.yyyy");
                }
            }
            else
            {
                viewModel.minReportDate = Common.RecTime().ToString("MM.dd.yyyy");
            }

            viewModel.maxReportDate = Common.RecTime().ToString("MM.dd.yyyy");


            viewModel.maxReportDate = Common.RecTime().ToString("MM.dd.yyyy");



            viewModel.EtkinMaddeListFilter = "BITISTARIHI > TO_DATE('" + Common.RecTime().ToShortDateString() + "','dd.mm.yyyy') AND BASLANGICTARIHI < TO_DATE('" + Common.RecTime().ToShortDateString() + "','dd.mm.yyyy')";
            if (viewModel._ParticipatnFreeDrugReport.MedulaReportResults != null && viewModel._ParticipatnFreeDrugReport.MedulaReportResults.Count > 0)
                viewModel.SelectededulaReportResult = viewModel._ParticipatnFreeDrugReport.MedulaReportResults[0];
            var se = viewModel._ParticipatnFreeDrugReport.SubEpisode;
            var sep = se.FirstSubEpisodeProtocol;
            if (sep == null)
                viewModel.SubEpisodeProtocol = se.AddSubEpisodeProtocol();


            if (viewModel._ParticipatnFreeDrugReport.IsSendedMedula == null)
                viewModel._ParticipatnFreeDrugReport.IsSendedMedula = false;
            if (viewModel._ParticipatnFreeDrugReport.CurrentStateDefID == null)
                viewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.States.New;

            if (((ITTObject)participatnFreeDrugReport).IsNew == true)
            {
                viewModel.ReadOnly = false;
            }

            viewModel.hasAuthorityForUndo = Common.CurrentUser.HasRole(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Geri_Alma);

            LocalQueryToView(viewModel, objectContext);
        }

        partial void PostScript_ParticipationFreeDrugReportNewForm(ParticipationFreeDrugReportNewFormViewModel viewModel, ParticipatnFreeDrugReport participatnFreeDrugReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            objectContext.AddToRawObjectList(viewModel.SubEpisodeProtocol);
            objectContext.ProcessRawObjects();

            if (participatnFreeDrugReport.ProcedureByUser == null)//rapru ilk oluşturan kişi
            {
                participatnFreeDrugReport.ProcedureByUser = Common.CurrentResource;
            }

            if (transDef != null && transDef.ToStateDefID == ParticipatnFreeDrugReport.States.Cancelled)
            {
                if (participatnFreeDrugReport.MedulaReportResults != null && participatnFreeDrugReport.MedulaReportResults.Count > 0)
                {
                    foreach (MedulaReportResult item in participatnFreeDrugReport.MedulaReportResults)
                    {
                        if (item.ReportChasingNo != null)
                        {
                            throw new Exception(TTUtils.CultureService.GetText("M25845", "Hastanın meduladan silinmemiş raporu mevcut. Raporu silmeden İptal edemezsiniz !"));
                        }
                    }
                }
            }
            if ((participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.New && transDef == null)
                || (participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.Report && transDef == null)
                || (participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.Completed && transDef == null)
                || (participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval && transDef == null)
                || (participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.Approval && transDef == null)
                || (transDef != null && (transDef.ToStateDefID == ParticipatnFreeDrugReport.States.Report || transDef.ToStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval)))
            {
                if (participatnFreeDrugReport.ExamptionProtocolNo.Value == null)
                    participatnFreeDrugReport.ExamptionProtocolNo.GetNextValue();

                EpisodeActionWithDiagnosis reportEpisodeAction = null;
                if (((ITTObject)participatnFreeDrugReport).IsNew == false)
                {
                    reportEpisodeAction = objectContext.GetObject<EpisodeActionWithDiagnosis>(participatnFreeDrugReport.ObjectID);
                    //sadece rapor üzerinden kaydedilen tanı
                    //List<DiagnosisGrid> tempDiagnosisList = reportEpisodeAction.Diagnosis.ToList();
                    //foreach (DiagnosisGrid item in tempDiagnosisList)
                    //{
                    //    AddedDiagnosisListModel result = viewModel.SelectedTeshisTaniList.Where(t => t.Tani.ObjectID == item.Diagnose.ObjectID).FirstOrDefault();
                    //    if (result == null)
                    //    {
                    //        BindingList<ReportDiagnosis> reportDiagnosisList = ReportDiagnosis.GetReportDiagnosisByDiagnosisGridAndEA(objectContext, participatnFreeDrugReport.ObjectID.ToString(), item.ObjectID.ToString());
                    //        foreach (ReportDiagnosis reportDiagnosis in reportDiagnosisList)
                    //        {
                    //            ((ITTObject)reportDiagnosis).Delete();
                    //        }
                    //        if (item.EpisodeAction == participatnFreeDrugReport)
                    //        {
                    //            List<TaniTeshisİliskisi> tempTaniTeshisİliskisiList = item.TaniTeshisİliskisi.ToList();
                    //            foreach (TaniTeshisİliskisi taniTeshisİliskisi in tempTaniTeshisİliskisiList)
                    //            {
                    //                TaniTeshisİliskisi tempTaniTeshisİliskisi = item.TaniTeshisİliskisi.Where(t => t.DiagnosisGrid.ObjectID == taniTeshisİliskisi.DiagnosisGrid.ObjectID && t.Teshis.ObjectID == taniTeshisİliskisi.Teshis.ObjectID).First();
                    //                ((ITTObject)tempTaniTeshisİliskisi).Delete();
                    //            }
                    //            DiagnosisGrid tempDiagnosis = reportEpisodeAction.Diagnosis.Where(t => t.Diagnose == item.Diagnose).First();

                    //            ((ITTObject)tempDiagnosis).Delete();
                    //        }
                    //    }
                    //}
                    if (participatnFreeDrugReport.ReportDiagnosis != null && participatnFreeDrugReport.ReportDiagnosis.Count > 0)
                    {
                        foreach (ReportDiagnosis reportDiagnosisItem in reportEpisodeAction.ReportDiagnosis.ToList())
                        {
                            AddedDiagnosisListModel result = null;

                            if (reportDiagnosisItem != null && reportDiagnosisItem.Diagnose != null)
                                result = viewModel.SelectedTeshisTaniList.Where(t => t.Tani.ObjectID == reportDiagnosisItem.Diagnose.ObjectID).FirstOrDefault();

                            if (result == null)
                            {

                                if (reportDiagnosisItem.EpisodeAction.ObjectID == participatnFreeDrugReport.ObjectID)// gerekli mi
                                {
                                    List<TaniTeshisİliskisi> tempTaniTeshisİliskisiList = reportDiagnosisItem.TaniTeshisİliskisi.ToList();
                                    foreach (TaniTeshisİliskisi taniTeshisİliskisi in tempTaniTeshisİliskisiList)
                                    {
                                        TaniTeshisİliskisi tempTaniTeshisİliskisi = reportDiagnosisItem.TaniTeshisİliskisi.Where(t => t.ReportDiagnosis.ObjectID == taniTeshisİliskisi.ReportDiagnosis.ObjectID && t.Teshis.ObjectID == taniTeshisİliskisi.Teshis.ObjectID).First();
                                        ((ITTObject)tempTaniTeshisİliskisi).Delete();
                                    }
                                    ReportDiagnosis tempReportDiagnosis = reportEpisodeAction.ReportDiagnosis.Where(t => t.ObjectID == reportDiagnosisItem.ObjectID).First();

                                    ((ITTObject)tempReportDiagnosis).Delete();
                                }
                            }
                            else
                            {
                                List<TaniTeshisİliskisi> tempTaniTeshisİliskisiList = reportDiagnosisItem.TaniTeshisİliskisi.ToList();
                                foreach (TaniTeshisİliskisi taniTeshisİliskisi in tempTaniTeshisİliskisiList)
                                {
                                    if (taniTeshisİliskisi.Teshis != null)
                                        result = viewModel.SelectedTeshisTaniList.Where(t => t.teshisObjectID == taniTeshisİliskisi.Teshis.ObjectID && t.Tani.ObjectID == taniTeshisİliskisi.ReportDiagnosis.Diagnose.ObjectID).FirstOrDefault();
                                    if (result == null)
                                    {
                                        TaniTeshisİliskisi tempTaniTeshisİliskisi = reportDiagnosisItem.TaniTeshisİliskisi.Where(t => t.ReportDiagnosis.ObjectID == taniTeshisİliskisi.ReportDiagnosis.ObjectID && t.Teshis.ObjectID == taniTeshisİliskisi.Teshis.ObjectID).First();
                                        ((ITTObject)tempTaniTeshisİliskisi).Delete();
                                    }
                                }
                            }
                        }
                    }
                }

                // Seçieln tanı teşhisler daha önce kaydedildi ise bişey yapma ilkkez kaydediliyor ise ekle
                if (viewModel.SelectedTeshisTaniList != null)
                {

                    foreach (AddedDiagnosisListModel taniTeshis in viewModel.SelectedTeshisTaniList)
                    {

                        // Benim ReportDiagnosislerimin altındaki tanı teşhislerin içinde tanısı ve teşhisi benim tanı teşhisimle aynı olan varsa hiçbirşey yapma 
                        // Benim ReportDiagnosislerimin altındaki tanı teşhislerin içinde tanısı ve teşhisi benim tanı teşhisimle aynı olan yoksa ;

                        // BU tanıda bir ReportDiagnosis varmı bak Yoksa yeni ReportDiagnosis ve TanıTeşhis ilişkisi ekle 
                        // BU tanıda bir ReportDiagnosis varmı bak varasa  yeni  TanıTeşhis ilişkisi ekle ve bulduğun raportDiagnosise ekle 
                        bool reportEpisodeActionCheck = false;
                        if (reportEpisodeAction == null)
                        {
                            reportEpisodeActionCheck = true;
                        }
                        else
                        {
                            var mevcutReportDiagnosis = reportEpisodeAction.ReportDiagnosis.FirstOrDefault(dr => dr.Diagnose.ObjectID == taniTeshis.Tani.ObjectID);
                            if (mevcutReportDiagnosis != null) //Clinetdan gelen TanıTeşhis tanısı için mevcut  RaporDiagnosis Varsa 
                            {

                                var mevcutTaniTeshis = mevcutReportDiagnosis.TaniTeshisİliskisi.FirstOrDefault(dr => dr.Teshis.ObjectID == taniTeshis.teshisObjectID);
                                if (mevcutTaniTeshis == null)//Clinetdan gelen TanıTeşhis teşhisi  için mevcut  TanıTeşhis Varsa
                                {

                                    Teshis teshis = objectContext.GetObject<Teshis>((Guid)taniTeshis.teshisObjectID);
                                    TaniTeshisİliskisi taniTeshisİliskisi = new TaniTeshisİliskisi(objectContext);
                                    taniTeshisİliskisi.Teshis = teshis;
                                    taniTeshisİliskisi.ReportDiagnosis = mevcutReportDiagnosis;

                                }

                            }
                            else //Clinetdan gelen TanıTeşhis tanısı için mevcut  RaporDiagnosis Yoksa 
                            {

                                reportEpisodeActionCheck = true;

                            }
                        }
                        if (reportEpisodeActionCheck == true)
                        {
                            ReportDiagnosis reportDiagnosis = new ReportDiagnosis(participatnFreeDrugReport.ObjectContext);
                            reportDiagnosis.Diagnose = taniTeshis.Tani;
                            reportDiagnosis.DiagnoseDate = Common.RecTime();
                            reportDiagnosis.EpisodeAction = participatnFreeDrugReport;

                            Teshis teshis = objectContext.GetObject<Teshis>((Guid)taniTeshis.teshisObjectID);
                            TaniTeshisİliskisi taniTeshisİliskisi = new TaniTeshisİliskisi(objectContext);
                            taniTeshisİliskisi.Teshis = teshis;
                            taniTeshisİliskisi.ReportDiagnosis = reportDiagnosis;
                            participatnFreeDrugReport.ReportDiagnosis.Add(reportDiagnosis);

                        }







                        // Benim ReportDiagnosislerimin içindedönüp  İlgili Tanı ile  bu teşhis arasında mevcut relation varsa hiçbir şey yapma yoksa yeni Teşhis Tanıİlşkisi ekle 


                    }
                }

                // DiagnosisGridle bağlantısı koparıldığı için bu kod artık geçersiz 
                //if (viewModel.SelectedTeshisTaniList != null && viewModel.SelectedTeshisTaniList.Count > 0)
                //{
                //    foreach (AddedDiagnosisListModel taniTeshis in viewModel.SelectedTeshisTaniList)
                //    {
                //        Teshis teshis = objectContext.GetObject<Teshis>((Guid)taniTeshis.teshisObjectID);
                //        BindingList<DiagnosisGrid.GetDiagnosisByEpisodeAndDiagnose_Class> episodeDiagnosis = DiagnosisGrid.GetDiagnosisByEpisodeAndDiagnose(participatnFreeDrugReport.Episode.ObjectID.ToString(), taniTeshis.Tani.ObjectID.ToString());
                //        if (episodeDiagnosis.Count > 0)
                //        {
                //            if (episodeDiagnosis.Count > 1)
                //            {
                //                DiagnosisGrid relatedDiagnosis = null;

                //                foreach (DiagnosisGrid.GetDiagnosisByEpisodeAndDiagnose_Class diagnose in episodeDiagnosis)
                //                {
                //                    DiagnosisGrid diagnosisGrid = objectContext.GetObject<DiagnosisGrid>((Guid)diagnose.ObjectID);
                //                    if (diagnosisGrid.DiagnosisType == DiagnosisTypeEnum.Seconder)
                //                    {
                //                        relatedDiagnosis = diagnosisGrid;
                //                        break;
                //                    }
                //                }
                //                if (relatedDiagnosis == null)
                //                {
                //                    DiagnosisGrid diagnosisGrid = objectContext.GetObject<DiagnosisGrid>((Guid)episodeDiagnosis[0].ObjectID);
                //                    relatedDiagnosis = diagnosisGrid;
                //                }
                //                bool add = true;
                //                foreach (ReportDiagnosis item in relatedDiagnosis.ReportDiagnosis)
                //                {
                //                    if (item.EpisodeAction == participatnFreeDrugReport)
                //                    {
                //                        bool addTeshis = true;
                //                        foreach (TaniTeshisİliskisi taniTeshisIliski in relatedDiagnosis.TaniTeshisİliskisi)
                //                        {
                //                            if (taniTeshisIliski.Teshis != null && taniTeshisIliski.Teshis.ObjectID == taniTeshis.teshisObjectID)
                //                                addTeshis = false;
                //                        }
                //                        if (addTeshis)
                //                        {
                //                            TaniTeshisİliskisi taniTeshisİliskisi = new TaniTeshisİliskisi(objectContext);
                //                            taniTeshisİliskisi.Teshis = teshis;
                //                            taniTeshisİliskisi.DiagnosisGrid = relatedDiagnosis;
                //                        }
                //                        add = false;
                //                        break;
                //                    }
                //                }
                //                if (add)
                //                {
                //                    ReportDiagnosis reportDiagnosis = new ReportDiagnosis(objectContext);
                //                    reportDiagnosis.DiagnosisGrid = relatedDiagnosis;
                //                    TaniTeshisİliskisi taniTeshisİliskisi = new TaniTeshisİliskisi(objectContext);
                //                    taniTeshisİliskisi.Teshis = teshis;
                //                    taniTeshisİliskisi.DiagnosisGrid = relatedDiagnosis;
                //                    reportDiagnosis.EpisodeAction = participatnFreeDrugReport;
                //                }
                //            }
                //            else
                //            {
                //                DiagnosisGrid diagnosisGrid = objectContext.GetObject<DiagnosisGrid>((Guid)episodeDiagnosis[0].ObjectID);
                //                bool add = true;
                //                foreach (ReportDiagnosis item in diagnosisGrid.ReportDiagnosis)
                //                {
                //                    if (item.EpisodeAction.ObjectID == participatnFreeDrugReport.ObjectID)
                //                    {
                //                        bool addTeshis = true;
                //                        foreach (TaniTeshisİliskisi taniTeshisIliski in diagnosisGrid.TaniTeshisİliskisi)
                //                        {
                //                            if (taniTeshisIliski.Teshis != null && taniTeshisIliski.Teshis.ObjectID == taniTeshis.teshisObjectID)
                //                                addTeshis = false;
                //                        }
                //                        if (addTeshis)
                //                        {
                //                            TaniTeshisİliskisi taniTeshisİliskisi = new TaniTeshisİliskisi(objectContext);
                //                            taniTeshisİliskisi.Teshis = teshis;
                //                            taniTeshisİliskisi.DiagnosisGrid = diagnosisGrid;
                //                        }
                //                        add = false;
                //                        break;
                //                    }
                //                }
                //                if (add)
                //                {
                //                    ReportDiagnosis reportDiagnosis = new ReportDiagnosis(objectContext);
                //                    reportDiagnosis.DiagnosisGrid = diagnosisGrid;
                //                    TaniTeshisİliskisi taniTeshisİliskisi = new TaniTeshisİliskisi(objectContext);
                //                    taniTeshisİliskisi.Teshis = teshis;
                //                    taniTeshisİliskisi.DiagnosisGrid = diagnosisGrid;
                //                    reportDiagnosis.EpisodeAction = participatnFreeDrugReport;
                //                }
                //            }
                //        }
                //        else
                //        {
                //            DiagnosisGrid diagnosis = new DiagnosisGrid(participatnFreeDrugReport, taniTeshis.Tani, false, DiagnosisTypeEnum.Primer, participatnFreeDrugReport.ProcedureDoctor, null, null);

                //            TaniTeshisİliskisi taniTeshisİliskisi = new TaniTeshisİliskisi(objectContext);
                //            taniTeshisİliskisi.Teshis = teshis;
                //            taniTeshisİliskisi.DiagnosisGrid = diagnosis;
                //            ReportDiagnosis reportDiagnosis = new ReportDiagnosis(participatnFreeDrugReport.ObjectContext);
                //            reportDiagnosis.DiagnosisGrid = diagnosis;
                //            reportDiagnosis.EpisodeAction = participatnFreeDrugReport;
                //            participatnFreeDrugReport.Diagnosis.Add(diagnosis);
                //        }
                //    }
                //}

                if (viewModel.EtkinMaddeList == null || viewModel.EtkinMaddeList.Count == 0)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25936", "Hiçbir etkin madde seçmeden devam edemezsiniz!"));
                bool checkPatientApprovalFormNo = false;
                string etkinMaddeAdi = String.Empty;
                if (viewModel.EtkinMaddeList != null && viewModel.EtkinMaddeList.Count > 0)
                {
                    foreach (EtkinMaddeListModel taniTeshis in viewModel.EtkinMaddeList)
                    {
                        if (taniTeshis.EtkinMadde == null && taniTeshis.EtkinMaddeMudalaHarici == null)
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25936", "Hiçbir etkin madde seçmeden devam edemezsiniz!"));
                        bool var = false;
                        EtkinMadde etkinMaddeDef = objectContext.GetObject(taniTeshis.EtkinMadde, typeof(EtkinMadde)) as EtkinMadde;
                        CheckParticipationFreeDrugDoseContent(taniTeshis.Doz2.ToString());
                        if (etkinMaddeDef != null && etkinMaddeDef.hastaGvnlikveIzlemFrmGerek.HasValue && etkinMaddeDef.hastaGvnlikveIzlemFrmGerek.Value == true)
                        {
                            checkPatientApprovalFormNo = true;
                            etkinMaddeAdi = etkinMaddeDef.etkinMaddeAdi;
                        }

                        foreach (ParticipationFreeDrgGrid item in participatnFreeDrugReport.ParticipationFreeDrugs)
                        {
                            if (taniTeshis.ParticipatientFreeDrugObjectID == item.ObjectID)
                            {
                                item.DrugName = taniTeshis.EtkinMaddeMudalaHarici;
                                item.Frequency = taniTeshis.DozAraligi;
                                item.Dose = taniTeshis.Doz.ToString();
                                item.UsageDoseUnitType = taniTeshis.DozBirimi;
                                item.Day = taniTeshis.Periyod;
                                item.PeriodUnitType = taniTeshis.PeriyodBirimi;
                                item.MedulaDoseInteger = taniTeshis.Doz.ToString();
                                item.MedulaUsageDose2 = taniTeshis.Doz2;
                                var = true;
                                break;
                            }
                            //else
                            //{
                            //    if (item.EtkinMadde.etkinMaddeKodu == etkinMaddeDef.etkinMaddeKodu)
                            //    {
                            //        var = true;
                            //        break;
                            //    }
                            //}
                        }

                        if (!var)
                        {
                            ParticipationFreeDrgGrid participationFreeDrgGrid = new ParticipationFreeDrgGrid(participatnFreeDrugReport.ObjectContext);
                            //Teshis teshis = objectContext.GetObject(taniTeshis.Teshis, typeof(Teshis)) as Teshis;
                            participationFreeDrgGrid.EtkinMadde = etkinMaddeDef;
                            participationFreeDrgGrid.DrugName = taniTeshis.EtkinMaddeMudalaHarici;
                            participationFreeDrgGrid.Frequency = taniTeshis.DozAraligi;
                            participationFreeDrgGrid.Dose = taniTeshis.Doz.ToString();
                            participationFreeDrgGrid.MedulaUsageDose2 = taniTeshis.Doz2;
                            participationFreeDrgGrid.UsageDoseUnitType = taniTeshis.DozBirimi;
                            participationFreeDrgGrid.Day = taniTeshis.Periyod;
                            participationFreeDrgGrid.PeriodUnitType = taniTeshis.PeriyodBirimi;
                            participationFreeDrgGrid.MedulaDoseInteger = taniTeshis.Doz.ToString();
                            participatnFreeDrugReport.ParticipationFreeDrugs.Add(participationFreeDrgGrid);
                        }
                    }

                    if (String.IsNullOrEmpty(participatnFreeDrugReport.PatientApprovalFormNo) && checkPatientApprovalFormNo)
                        throw new Exception("'" + etkinMaddeAdi + "' etkin maddesi Hasta Güvenlik ve İzlem Formu gerektirir. 'Hasta Onay Form No' alanını giriniz. ");
                }
                List<ParticipationFreeDrgGrid> tempDrugList = participatnFreeDrugReport.ParticipationFreeDrugs.ToList();

                foreach (ParticipationFreeDrgGrid drug in tempDrugList)
                {
                    if (viewModel.EtkinMaddeList != null && viewModel.EtkinMaddeList.Count > 0)
                    {
                        EtkinMaddeListModel result = viewModel.EtkinMaddeList.Where(t => t.EtkinMadde == drug.EtkinMadde.ObjectID).FirstOrDefault();
                        if (result == null)
                        {

                            ParticipationFreeDrgGrid tempDrug = participatnFreeDrugReport.ParticipationFreeDrugs.Where(t => t.ObjectID == drug.ObjectID).First();
                            ((ITTObject)tempDrug).Delete();
                            // ((ITTObject)drug).Delete();
                        }
                    }
                    else
                    {
                        ParticipationFreeDrgGrid tempDrug = participatnFreeDrugReport.ParticipationFreeDrugs.Where(t => t.ObjectID == drug.ObjectID).First();
                        ((ITTObject)tempDrug).Delete();
                    }
                }
            }

            if (transDef != null)
            {
                if ((transDef.FromStateDefID == ParticipatnFreeDrugReport.States.Approval && transDef.ToStateDefID == ParticipatnFreeDrugReport.States.New)
                    || (transDef.FromStateDefID == ParticipatnFreeDrugReport.States.Approval && transDef.ToStateDefID == ParticipatnFreeDrugReport.States.Report))
                {
                    if (participatnFreeDrugReport.HeadDoctorApproval == 1)
                    {
                        if (participatnFreeDrugReport.MedulaReportResults.Count > 0)
                        {
                            if (participatnFreeDrugReport.MedulaReportResults[0] != null && participatnFreeDrugReport.MedulaReportResults[0].ReportChasingNo != null)
                            {
                                IlacRaporuServis.eraporSilIstekDVO eraporSilIstekDVO = new IlacRaporuServis.eraporSilIstekDVO();
                                eraporSilIstekDVO.doktorTcKimlikNo = participatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                                eraporSilIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                                eraporSilIstekDVO.raporTakipNo = participatnFreeDrugReport.MedulaReportResults[0].ReportChasingNo;
                                participatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                                if (string.IsNullOrEmpty(participatnFreeDrugReport.ProcedureDoctor.ErecetePassword))
                                {
                                    //TTVisual.TTForm medulaPasswordForm = new TTFormClasses.MedulaPasswordForm();
                                    //TTFormClasses.ParticipationFreeDrugReportNewForm participationFreeDrugReportNewForm = new TTFormClasses.ParticipationFreeDrugReportNewForm();
                                    //medulaPasswordForm.ShowEdit(participationFreeDrugReportNewForm.FindForm(), participatnFreeDrugReport, true);
                                    if (string.IsNullOrEmpty(participatnFreeDrugReport.ProcedureDoctor.ErecetePassword) && string.IsNullOrEmpty(participatnFreeDrugReport.MedulaPassword))
                                    {
                                        throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");
                                    }
                                }

                                string password = "";
                                if (!string.IsNullOrEmpty(participatnFreeDrugReport.ProcedureDoctor.ErecetePassword))
                                    password = participatnFreeDrugReport.ProcedureDoctor.ErecetePassword;
                                else if (!string.IsNullOrEmpty(participatnFreeDrugReport.MedulaPassword))
                                    password = participatnFreeDrugReport.MedulaPassword;
                                IlacRaporuServis.eraporSilCevapDVO response = IlacRaporuServis.WebMethods.eraporSil(Sites.SiteLocalHost, participatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString(), password, eraporSilIstekDVO);
                                if (response != null)
                                {
                                    if (response.sonucKodu != null)
                                    {
                                        if (response.sonucKodu == "0000")
                                        {
                                            TTObjectContext context = participatnFreeDrugReport.ObjectContext;
                                            MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(participatnFreeDrugReport.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
                                            //   MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                                            medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Completed;
                                            medulaReportResult.ResultCode = response.sonucKodu;
                                            medulaReportResult.ResultExplanation = TTUtils.CultureService.GetText("M26743", "Rapor Bilgisi Silinmiştir");
                                            medulaReportResult.ReportRowNumber = null;
                                            medulaReportResult.ReportNumber = "";
                                            medulaReportResult.ReportChasingNo = "";
                                            participatnFreeDrugReport.HeadDoctorApproval = 0;
                                            participatnFreeDrugReport.SecondDoctorApproval = 0;
                                            participatnFreeDrugReport.ThirdDoctorApproval = 0;
                                        }
                                        else
                                        {
                                            if (!string.IsNullOrEmpty(response.sonucMesaji))
                                            {
                                                TTObjectContext context = participatnFreeDrugReport.ObjectContext;
                                                MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(participatnFreeDrugReport.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
                                                // MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                                                medulaReportResult.ResultCode = response.sonucKodu;
                                                medulaReportResult.ResultExplanation = response.sonucMesaji;
                                                //InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                                            }

                                            throw new TTUtils.TTException("Rapor Silinemedi!!! Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                                        }
                                    }
                                    else
                                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26748", "Rapor silinirken bir hata oluştu !!!"));
                                }
                            }
                        }
                    }
                }
            }
            /*else
            {
                if(!viewModel.IsPatientSGK && participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.New)
                {
                    objectContext.Save();
                    participatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.States.Report;
                    objectContext.Save();
                   // participatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.States.Completed; 
                }
            }*/
        }

        [HttpPost]
        public ParticipationFreeDrugReportNewFormViewModel ParticipatnFreeDrugReportFormEmpty(ActiveIDsModel activeIDsModel)
        {
            var formDefID = Guid.Parse("03427eac-3998-45e7-a2be-3b0f444b93a4");
            var objectDefID = Guid.Parse("c3d26685-4b86-4454-9884-1ae2c8bc932f");
            var viewModel = new ParticipationFreeDrugReportNewFormViewModel();
            viewModel.ActiveIDsModel = activeIDsModel;

            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ParticipatnFreeDrugReport = new ParticipatnFreeDrugReport(objectContext);
                var entryStateID = Guid.Parse("04200b26-1590-4f3d-abed-dda38b822304");
                viewModel._ParticipatnFreeDrugReport.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ParticipatnFreeDrugReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ParticipatnFreeDrugReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ParticipatnFreeDrugReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ParticipatnFreeDrugReport);

                ContextToViewModel(viewModel, objectContext);

                PreScript_ParticipationFreeDrugReportNewForm(viewModel, viewModel._ParticipatnFreeDrugReport, objectContext);

                viewModel.ToState = ParticipatnFreeDrugReport.States.New;
                viewModel._ParticipatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.States.New;

                if (viewModel._ParticipatnFreeDrugReport.ProcedureDoctor == null)
                {
                    viewModel._ParticipatnFreeDrugReport.ProcedureDoctor = Common.CurrentResource;
                }
                ContextToViewModel(viewModel, objectContext);

                objectContext.FullPartialllyLoadedObjects();
            }

            return viewModel;
        }

        [HttpGet]
        public ParticipationFreeDrugReportNewFormViewModel ParticipatnFreeDrugReportFormPre(Guid? id)
        {
            var formDefID = Guid.Parse("03427eac-3998-45e7-a2be-3b0f444b93a4");
            var objectDefID = Guid.Parse("c3d26685-4b86-4454-9884-1ae2c8bc932f");
            var viewModel = new ParticipationFreeDrugReportNewFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ParticipatnFreeDrugReport = objectContext.GetObject(id.Value, objectDefID) as ParticipatnFreeDrugReport;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ParticipatnFreeDrugReport, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ParticipatnFreeDrugReport, formDefID);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    PreScript_ParticipationFreeDrugReportNewForm(viewModel, viewModel._ParticipatnFreeDrugReport, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public List<UserTemplateModel> SaveParticipatnFreeDrugReportUserTemplate(UserTemplateModel userTemplate)
        {
            List<UserTemplateModel> userTemplatesList = new List<UserTemplateModel>();

            using (var objectContext = new TTObjectContext(false))
            {
                if (userTemplate.ObjectID != null)
                {
                    UserTemplate oldUserTemplate = objectContext.GetObject<UserTemplate>((Guid)userTemplate.ObjectID);
                    oldUserTemplate.FiliterData = "DELETED-DrugReportTemplate";
                }
                else
                {
                    UserTemplate newUserTemplate = new UserTemplate(objectContext);
                    newUserTemplate.TAObjectDefID = userTemplate.TAObjectDefID;
                    newUserTemplate.TAObjectID = userTemplate.TAObjectID;
                    newUserTemplate.FiliterData = "DrugReportTemplate";
                    newUserTemplate.ResUser = Common.CurrentResource;
                    newUserTemplate.Description = userTemplate.Description;
                }

                objectContext.Save();
                var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, (Guid)userTemplate.TAObjectDefID, "DrugReportTemplate").ToList();
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
        public ParticipationFreeDrugReportNewFormViewModel ParticipatnFreeDrugReportFormTemplate(ParticipationFreeDrugReportNewFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (viewModel.selectedUserTemplate != null)
                {
                    ParticipatnFreeDrugReport templateParticipationFreeDrugReport = objectContext.GetObject<ParticipatnFreeDrugReport>((Guid)viewModel.selectedUserTemplate.TAObjectID);
                    ParticipatnFreeDrugReport reportObject = (ParticipatnFreeDrugReport) objectContext.AddObject(viewModel._ParticipatnFreeDrugReport);
                    var doctor1 = reportObject.ProcedureDoctor;
                    var doctor2 = reportObject.SecondDoctor;
                    var doctor3 = reportObject.ThirdDoctor;
                    reportObject.ReportDuration = templateParticipationFreeDrugReport.ReportDuration;
                    reportObject.ReportDurationType = templateParticipationFreeDrugReport.ReportDurationType;
                    reportObject.Description = templateParticipationFreeDrugReport.Description;
                    reportObject.ParticipationFreeDrugs.Clear();
                    reportObject.ReportDiagnosis.Clear();
                    foreach (ParticipationFreeDrgGrid oldParticipationFreeDrg in templateParticipationFreeDrugReport.ParticipationFreeDrugs)
                    {
                        ParticipationFreeDrgGrid newParticipationFreeDrgGrid = new ParticipationFreeDrgGrid(objectContext);
                        newParticipationFreeDrgGrid.ParticipatnFreeDrugReport = viewModel._ParticipatnFreeDrugReport;
                        newParticipationFreeDrgGrid.EtkinMadde = oldParticipationFreeDrg.EtkinMadde;

                        newParticipationFreeDrgGrid.DrugName = oldParticipationFreeDrg.DrugName;
                        newParticipationFreeDrgGrid.Frequency = (FrequencyEnum)oldParticipationFreeDrg.Frequency;
                        newParticipationFreeDrgGrid.MedulaDoseInteger = oldParticipationFreeDrg.MedulaDoseInteger;
                        newParticipationFreeDrgGrid.MedulaUsageDose2 = oldParticipationFreeDrg.MedulaUsageDose2;
                        newParticipationFreeDrgGrid.UsageDoseUnitType = (UsageDoseUnitTypeEnum)oldParticipationFreeDrg.UsageDoseUnitType;
                        newParticipationFreeDrgGrid.Day = oldParticipationFreeDrg.Day;
                        newParticipationFreeDrgGrid.PeriodUnitType = (PeriodUnitTypeEnum)oldParticipationFreeDrg.PeriodUnitType;
                        reportObject.ParticipationFreeDrugs.Add(newParticipationFreeDrgGrid);
                    }

                    foreach (ReportDiagnosis oldReportDiagnosis in templateParticipationFreeDrugReport.ReportDiagnosis)
                    {

                        ReportDiagnosis newReportDiagnosis = new ReportDiagnosis(objectContext);
                        newReportDiagnosis.Diagnose = oldReportDiagnosis.Diagnose;
                        newReportDiagnosis.DiagnoseDate = oldReportDiagnosis.DiagnoseDate;
                        newReportDiagnosis.DiagnosisGrid = oldReportDiagnosis.DiagnosisGrid;
                        newReportDiagnosis.EpisodeAction = viewModel._ParticipatnFreeDrugReport;

                        foreach (TaniTeshisİliskisi oldtaniTeshisIliskisi in oldReportDiagnosis.TaniTeshisİliskisi)
                        {
                            TaniTeshisİliskisi newTaniTeshisIliskisi = new TaniTeshisİliskisi(objectContext);
                            newTaniTeshisIliskisi.DiagnosisGrid = oldtaniTeshisIliskisi.DiagnosisGrid;
                            newTaniTeshisIliskisi.Teshis = oldtaniTeshisIliskisi.Teshis;
                            newTaniTeshisIliskisi.ReportDiagnosis = newReportDiagnosis;
                            newReportDiagnosis.TaniTeshisİliskisi.Add(newTaniTeshisIliskisi);
                        }

                    }
                    if (reportObject.ParticipationFreeDrugs.Count > 0)
                    {
                        viewModel.EtkinMaddeList = new List<EtkinMaddeListModel>();
                        viewModel.TeshisList = new List<TeshisListModel>();
                        viewModel.SelectedTeshisTaniList = new List<AddedDiagnosisListModel>();
                        foreach (ParticipationFreeDrgGrid participationFreeDrgGrid in reportObject.ParticipationFreeDrugs)
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
                            viewModel.EtkinMaddeList.Add(etkinMadde);
                            if (participationFreeDrgGrid.MedulaDose != null && participationFreeDrgGrid.MedulaDoseInteger == null)
                                participationFreeDrgGrid.MedulaDoseInteger = participationFreeDrgGrid.MedulaDose.ToString();

                            EtkenMaddeTeshisListModel etkenMaddeTeshis = new EtkenMaddeTeshisListModel();
                            etkenMaddeTeshis.etkenMaddeObjectId = participationFreeDrgGrid.EtkinMadde.ObjectID;
                            etkenMaddeTeshis.TeshisList = new List<TeshisListModel>();
                            List<TeshisListModel> teshisTaniList = new List<TeshisListModel>();
                            teshisTaniList.AddRange(GetTeshisTani(etkenMaddeTeshis));
                            foreach (TeshisListModel item in teshisTaniList)
                            {
                                TeshisListModel result = viewModel.TeshisList.Where(t => t.teshis.ObjectID == item.teshis.ObjectID).FirstOrDefault();
                                if (result == null)
                                {
                                    viewModel.TeshisList.Add(item);
                                }
                                else
                                {
                                    result.relatedEtkenMaddeList.Add(item.relatedEtkenMaddeList[0]);
                                    result.relatedEtkenMaddeNames += ", " + item.relatedEtkenMaddeList[0].etkinMaddeAdi;
                                }
                            }
                        }

                        foreach (ReportDiagnosis reportDiagnosis in reportObject.ReportDiagnosis)
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
                        viewModel._ParticipatnFreeDrugReport = reportObject;

                    }
                    viewModel.ListDefDisplayExpressions = new Dictionary<string, object>();
                    ContextToViewModel(viewModel, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }                
            }

            return viewModel;
        }

        void LocalQueryToView(ParticipationFreeDrugReportNewFormViewModel viewModel, TTObjectContext objectContext)
        {
            ContextToViewModel(viewModel, objectContext);
            viewModel.SubEpisodeProtocol = objectContext.LocalQuery<SubEpisodeProtocol>().FirstOrDefault();
        }

        [HttpPost]
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
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Kaydet)]
        public IlacRaporuServis.eraporGirisCevapDVO EraporGirisKaydet(ParticipationFreeDrugReportNewFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(viewModel._ParticipatnFreeDrugReport);
                bool checkPatientApprovalFormNo = false;
                string etkinMaddeAdi = String.Empty;
                CheckParticipationFreeDrugs(participatnFreeDrugReportImported);
                if (string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.DiplomaRegisterNo))
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25528", "Doktorun diploma tescil no bilgisini tanımlayınız!"));
                //if (!Common.CurrentUser.IsSuperUser && participatnFreeDrugReportImported.ProcedureDoctor.ObjectID != Common.CurrentUser.UserObject.ObjectID)
                //    throw new TTUtils.TTException("Raporun sorumlu doktoru değilsiniz!");
                Guid savePointGuid = objectContext.BeginSavePoint();
                ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)objectContext.GetObject(participatnFreeDrugReportImported.ObjectID, typeof(ParticipatnFreeDrugReport));
                if (participatnFreeDrugReportImported.ReportNo == null)
                    _participationFreeDrugReport.ReportNo.GetNextValue();
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
                            if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                                password = participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword;
                            else if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                                password = participatnFreeDrugReportImported.MedulaPassword;
                        }


                        IlacRaporuServis.eraporGirisCevapDVO response = IlacRaporuServis.WebMethods.eraporGiris(Sites.SiteLocalHost, username, password, eraporGirisIstekDVO);
                        if (response != null)
                        {
                            var a = TTUtils.SerializationHelper.XmlSerializeObject(response);
                            var b = TTUtils.SerializationHelper.XmlSerializeObject(eraporGirisIstekDVO);

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
                    else
                    {
                        objectContext.RollbackSavePoint(savePointGuid);
                        throw new TTUtils.TTException("Hasta Ait Aktif Provizyon Bilgisi Olmadığından Dolayı Raporu Medulaya Kayıt Edemezsiniz!!! ");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public IlacRaporuServis.imzaliEraporGirisCevapDVO SendSignedReportContent(SendSignedReport_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                var signedData = Convert.FromBase64String(input.signContent);
                Guid savePointGuid = objectContext.BeginSavePoint();

                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.GetObject<ParticipatnFreeDrugReport>(input.viewModel._ParticipatnFreeDrugReport.ObjectID);

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
                    if ((input.viewModel.medulaUsername != null && input.viewModel.medulaUsername != "") || (input.viewModel.medulaPassword != null && input.viewModel.medulaPassword != ""))
                    {
                        username = input.viewModel.medulaUsername;
                        password = input.viewModel.medulaPassword;
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


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string PrepareSignedReportContent(ParticipationFreeDrugReportNewFormViewModel viewModel)
        {
            string output = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(viewModel._ParticipatnFreeDrugReport);
                bool checkPatientApprovalFormNo = false;
                Guid savePointGuid = objectContext.BeginSavePoint();
                string etkinMaddeAdi = String.Empty;
                CheckParticipationFreeDrugs(participatnFreeDrugReportImported);
                if (string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.DiplomaRegisterNo))
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25528", "Doktorun diploma tescil no bilgisini tanımlayınız!"));
                //if (!Common.CurrentUser.IsSuperUser && participatnFreeDrugReportImported.ProcedureDoctor.ObjectID != Common.CurrentUser.UserObject.ObjectID)
                //    throw new TTUtils.TTException("Raporun sorumlu doktoru değilsiniz!");
                ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)objectContext.GetObject(participatnFreeDrugReportImported.ObjectID, typeof(ParticipatnFreeDrugReport));
                if (participatnFreeDrugReportImported.ReportNo == null)
                    _participationFreeDrugReport.ReportNo.GetNextValue();
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

                        foreach (AddedDiagnosisListModel selectedDiagnose in viewModel.SelectedTeshisTaniList)
                        {
                            _eraporTaniList.Add(selectedDiagnose.taniKodu);
                        }

                        IEnumerable<Guid> teshisObjectIDFilter = viewModel.SelectedTeshisTaniList.Select(x => x.teshisObjectID).Distinct();
                        string filterTeshis = Common.CreateFilterExpressionOfGuidList("", "OBJECTID", teshisObjectIDFilter.ToList());
                        var selectedTeshisList = objectContext.QueryObjects<Teshis>(filterTeshis);

                        #region İlave Değer Ekleme
                        List<IlacRaporuServis.eraporIlaveDegerDVO> eraporIlaveDegerDVOs = ilaveDegerOlustur(viewModel.SelectedTeshisTaniList, viewModel.ReportReasonList, participatnFreeDrugReportImported, objectContext);

                        if (eraporIlaveDegerDVOs.Count > 0)
                            _eraporDVO.eraporIlaveDegerListesi = eraporIlaveDegerDVOs.ToArray();

                        #endregion İlave Değer Ekleme

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
                            Teshis teshis = selectedTeshisList.FirstOrDefault(x => x.ObjectID == item.teshisObjectID); //(Teshis)objectContext.GetObject(item.teshisObjectID, typeof(Teshis));
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
                        imzalanacakXml = imzalanacakXml.Replace("eraporIlaveDegerListesi", "eraporIlaveDegerBilgisi");
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

          public List<IlacRaporuServis.eraporIlaveDegerDVO> ilaveDegerOlustur(List<AddedDiagnosisListModel> addedDiagnosisListModel, List<int> ReportReasonList, ParticipatnFreeDrugReport participatnFreeDrugReportImported, TTObjectContext objectContext)
        {
            IEnumerable<Guid> teshisObjectIDFilter = addedDiagnosisListModel.Select(x => x.teshisObjectID).Distinct();
            string filterTeshis = Common.CreateFilterExpressionOfGuidList("", "OBJECTID", teshisObjectIDFilter.ToList());
            var selectedTeshisList = objectContext.QueryObjects<Teshis>(filterTeshis);

            List<IlacRaporuServis.eraporIlaveDegerDVO> eraporIlaveDegerDVOs = new List<IlacRaporuServis.eraporIlaveDegerDVO>();

            if (selectedTeshisList.Any(x => diabetTeshis07_02_1_Array.Contains(x.teshisKodu.Value)))
            {
                IlacRaporuServis.eraporIlaveDegerDVO ilaveDegerKilo = new IlacRaporuServis.eraporIlaveDegerDVO();
                var patientKg = participatnFreeDrugReportImported.Kilo;
                ilaveDegerKilo.turu = 2;
                ilaveDegerKilo.degeri = patientKg.HasValue ? patientKg.Value.ToString() : string.Empty;
                ilaveDegerKilo.aciklama = "Kilo";
                eraporIlaveDegerDVOs.Add(ilaveDegerKilo);

                IlacRaporuServis.eraporIlaveDegerDVO ilaveDegerHemogLobinA1c = new IlacRaporuServis.eraporIlaveDegerDVO();
                ilaveDegerHemogLobinA1c.turu = 3;
                ilaveDegerHemogLobinA1c.degeri = participatnFreeDrugReportImported.HemoglobinA1c.HasValue ? participatnFreeDrugReportImported.HemoglobinA1c.Value.ToString().Replace(',','.') : string.Empty;
                ilaveDegerHemogLobinA1c.aciklama = "HemoglobinA1c";
                eraporIlaveDegerDVOs.Add(ilaveDegerHemogLobinA1c);

                IlacRaporuServis.eraporIlaveDegerDVO ilaveDegerAclikKanSekeri = new IlacRaporuServis.eraporIlaveDegerDVO();
                ilaveDegerAclikKanSekeri.turu = 4;
                ilaveDegerAclikKanSekeri.degeri = participatnFreeDrugReportImported.AclikKanSekeri.HasValue ? participatnFreeDrugReportImported.AclikKanSekeri.Value.ToString() : string.Empty;
                ilaveDegerAclikKanSekeri.aciklama = "Aclik Kan Sekeri";
                eraporIlaveDegerDVOs.Add(ilaveDegerAclikKanSekeri);
            }

            if (selectedTeshisList.Any(x => x.teshisKodu == 206) || selectedTeshisList.Any(x => x.teshisKodu == 226))
            {
                IlacRaporuServis.eraporIlaveDegerDVO raporDuzenlemeNedeni = null;

                foreach (var item in ReportReasonList)
                {
                    raporDuzenlemeNedeni = new IlacRaporuServis.eraporIlaveDegerDVO();
                    raporDuzenlemeNedeni.turu = 1;
                    raporDuzenlemeNedeni.degeri = item.ToString();
                    eraporIlaveDegerDVOs.Add(raporDuzenlemeNedeni);
                }
            }
            return eraporIlaveDegerDVOs;
        }

        [HttpPost]
        public string PrepareSignedReportApproveContent(SendSignedReportApproveModel approveModel)
        {
            string output = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(approveModel.participatnFreeDrugReport);
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
        public string getUniqueRefnoOfApproveUser(ParticipatnFreeDrugReport report)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                ParticipatnFreeDrugReport reportObj = objectContext.GetObject<ParticipatnFreeDrugReport>(report.ObjectID);

                return reportObj.ProcedureDoctor.UniqueNo;

            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Sil)]
        public IlacRaporuServis.imzaliEraporOnayCevapDVO SendSignedReportApproveContent(SendSignedReportApproveModel approveModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(approveModel.participatnFreeDrugReport);
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
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Onay)]
        public IlacRaporuServis.eraporOnayCevapDVO Onay(DrugReportApproveModel approveModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(approveModel.participatnFreeDrugReport);
                    MedulaReportResult currentMedulaReportResult = participatnFreeDrugReportImported.MedulaReportResults[0];
                    if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                    {
                        IlacRaporuServis.eraporOnayIstekDVO eraporOnayIstekDVO = new IlacRaporuServis.eraporOnayIstekDVO();
                        eraporOnayIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                        eraporOnayIstekDVO.raporTakipNo = currentMedulaReportResult.ReportChasingNo;
                        string password = "";
                        string uniqueRefNo = "";
                        //if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.Completed)
                        if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.Completed
                            || participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval)
                        {
                            uniqueRefNo = participatnFreeDrugReportImported.SecondDoctor.Person.UniqueRefNo.Value.ToString();
                            eraporOnayIstekDVO.doktorTcKimlikNo = uniqueRefNo;
                            if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.SecondDoctor.ErecetePassword))
                                password = participatnFreeDrugReportImported.SecondDoctor.ErecetePassword;
                            else
                                throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");
                        }

                        //if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval)
                        if (participatnFreeDrugReportImported.CurrentStateDefID == ParticipatnFreeDrugReport.States.ThirdDoctorApproval)
                        {
                            uniqueRefNo = participatnFreeDrugReportImported.ThirdDoctor.Person.UniqueRefNo.Value.ToString();
                            eraporOnayIstekDVO.doktorTcKimlikNo = uniqueRefNo;
                            if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ThirdDoctor.ErecetePassword))
                                password = participatnFreeDrugReportImported.ThirdDoctor.ErecetePassword;
                            else
                                throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");
                        }

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
                        IlacRaporuServis.eraporOnayCevapDVO response = IlacRaporuServis.WebMethods.eraporOnay(Sites.SiteLocalHost, uniqueRefNo, password, eraporOnayIstekDVO);
                        if (response != null && response.sonucKodu != null && (response.sonucKodu == "0000" || response.sonucKodu == "RAP_0052"))
                        {
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

                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Onay)]
        public string PrepareSignedReportHeadDoctorApproveContent(SendSignedReportApproveModel approveModel)
        {
            string output = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(approveModel.participatnFreeDrugReport);
                MedulaReportResult currentMedulaReportResult = participatnFreeDrugReportImported.MedulaReportResults[0];
                if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                {
                    IlacRaporuServis.eraporBashekimOnayIstekDVO eraporBashekimOnayIstekDVO = new IlacRaporuServis.eraporBashekimOnayIstekDVO();
                    eraporBashekimOnayIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    eraporBashekimOnayIstekDVO.raporTakipNo = currentMedulaReportResult.ReportChasingNo;
                    string uniqueRefNo = "";
                    string password = "";

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

                    string imzalanacakXml = Common.SerializeObjectToXml(eraporBashekimOnayIstekDVO);
                    imzalanacakXml = imzalanacakXml.Replace("eraporBashekimOnayIstekDVO", "imzaliEraporBashekimOnayBilgisi");

                    return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
                }

            }
            return output;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Sil)]
        public IlacRaporuServis.imzaliEraporBashekimOnayCevapDVO SendSignedReportHeadDoctorApproveContent(SendSignedReportApproveModel approveModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(approveModel.participatnFreeDrugReport);
                MedulaReportResult currentMedulaReportResult = participatnFreeDrugReportImported.MedulaReportResults[0];
                var signedData = Convert.FromBase64String(approveModel.signContent);
                string username = "";
                string password = "";
                string uniqueRefNo = "";
                if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                {
                    IlacRaporuServis.imzaliEraporBashekimOnayIstekDVO eraporBashekimOnayIstekDVO = new IlacRaporuServis.imzaliEraporBashekimOnayIstekDVO();
                    eraporBashekimOnayIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    eraporBashekimOnayIstekDVO.imzaliEraporBashekimOnay = signedData;

                    eraporBashekimOnayIstekDVO.surumNumarasi = 1;


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
                    IlacRaporuServis.imzaliEraporBashekimOnayCevapDVO response = IlacRaporuServis.WebMethods.imzaliEraporBashekimOnaySync(Sites.SiteLocalHost, uniqueRefNo, password, eraporBashekimOnayIstekDVO);
                    if (response != null && response.sonucKodu != null && response.sonucKodu == "0000")
                    {
                        participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.HeadDoctorApprove;
                        participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.ReportCompleted;
                        participatnFreeDrugReportImported.HeadDoctorApproval = 1;
                        objectContext.Save();
                    }
                    else if (response != null && response.sonucKodu != null && response.sonucKodu == "RAP_0047")
                    {
                        participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.HeadDoctorApprove;
                        participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.ReportCompleted;
                        participatnFreeDrugReportImported.HeadDoctorApproval = 1;
                        objectContext.Save();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(response.sonucMesaji) || !string.IsNullOrEmpty(response.uyariMesaji))
                        {
                            participatnFreeDrugReportImported.HeadDoctorApproval = 0;
                            objectContext.Save();
                        }
                    }

                    return response;
                }
            }
            return null;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Onay)]
        public IlacRaporuServis.eraporBashekimOnayCevapDVO BashekimOnay(DrugReportApproveModel approveModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(approveModel.participatnFreeDrugReport);
                    MedulaReportResult currentMedulaReportResult = participatnFreeDrugReportImported.MedulaReportResults[0];
                    if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                    {
                        IlacRaporuServis.eraporBashekimOnayIstekDVO eraporBashekimOnayIstekDVO = new IlacRaporuServis.eraporBashekimOnayIstekDVO();
                        eraporBashekimOnayIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                        eraporBashekimOnayIstekDVO.raporTakipNo = currentMedulaReportResult.ReportChasingNo;
                        string uniqueRefNo = "";
                        string password = "";
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
                        IlacRaporuServis.eraporBashekimOnayCevapDVO response = IlacRaporuServis.WebMethods.eraporBashekimOnay(Sites.SiteLocalHost, uniqueRefNo, password, eraporBashekimOnayIstekDVO);
                        if (response != null && response.sonucKodu != null && response.sonucKodu == "0000")
                        {
                            participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.HeadDoctorApprove;
                            participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.ReportCompleted;
                            participatnFreeDrugReportImported.HeadDoctorApproval = 1;
                            objectContext.Save();
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(response.sonucMesaji) || !string.IsNullOrEmpty(response.uyariMesaji))
                            {
                                participatnFreeDrugReportImported.HeadDoctorApproval = 0;
                                objectContext.Save();
                            }
                        }

                        return response;
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
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Sil)]
        public string PrepareDeleteReportContent(ParticipationFreeDrugReportNewFormViewModel viewModel)
        {
            string output = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(viewModel._ParticipatnFreeDrugReport);
                MedulaReportResult currentMedulaReportResult = viewModel.SelectededulaReportResult;
                if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                {
                    IlacRaporuServis.eraporSilIstekDVO eraporSilIstekDVO = new IlacRaporuServis.eraporSilIstekDVO();
                    eraporSilIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    eraporSilIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    eraporSilIstekDVO.raporTakipNo = currentMedulaReportResult.ReportChasingNo;

                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((viewModel.medulaUsername != null && viewModel.medulaUsername != "") || (viewModel.medulaPassword != null && viewModel.medulaPassword != ""))
                        {
                            eraporSilIstekDVO.doktorTcKimlikNo = viewModel.medulaUsername;
                        }
                        else
                        {
                            throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                        }
                    }
                    else
                    {
                        eraporSilIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    }

                    string imzalanacakXml = Common.SerializeObjectToXml(eraporSilIstekDVO);
                    imzalanacakXml = imzalanacakXml.Replace("eraporSilIstekDVO", "imzaliEraporSilBilgisi");

                    return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
                }
            }
            return output;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Sil)]
        public IlacRaporuServis.imzaliEraporSilCevapDVO SendSignedReportDeleteContent(SendSignedReportDelete_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(input.viewModel._ParticipatnFreeDrugReport);
                var signedData = Convert.FromBase64String(input.signContent);

                MedulaReportResult currentMedulaReportResult = input.viewModel.SelectededulaReportResult;
                if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                {
                    IlacRaporuServis.imzaliEraporSilIstekDVO eraporSilIstekDVO = new IlacRaporuServis.imzaliEraporSilIstekDVO();
                    eraporSilIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    eraporSilIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    eraporSilIstekDVO.imzaliEraporSil = signedData;
                    eraporSilIstekDVO.surumNumarasi = 1;


                    string username = "";
                    string password = "";

                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((input.viewModel.medulaUsername != null && input.viewModel.medulaUsername != "") || (input.viewModel.medulaPassword != null && input.viewModel.medulaPassword != ""))
                        {
                            eraporSilIstekDVO.doktorTcKimlikNo = input.viewModel.medulaUsername;
                            username = input.viewModel.medulaUsername;
                            password = input.viewModel.medulaPassword;
                        }
                        else
                        {
                            throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                        }
                    }
                    else
                    {
                        username = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                        eraporSilIstekDVO.doktorTcKimlikNo = username;
                        if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                            password = participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword;
                        else if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                            password = input.viewModel._ParticipatnFreeDrugReport.MedulaPassword;
                    }
                    IlacRaporuServis.imzaliEraporSilCevapDVO response = IlacRaporuServis.WebMethods.imzaliEraporSilSync(Sites.SiteLocalHost, username, password, eraporSilIstekDVO);
                    if (response != null && response.sonucKodu != null && response.sonucKodu == "0000")
                    {

                        participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                        /*if (participatnFreeDrugReportImported.CommitteeReport.HasValue && participatnFreeDrugReportImported.CommitteeReport.Value == true)
                            participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.SecondDoctorApproval;
                        else
                            participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.Approval;*/
                        //participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.Completed;

                        MedulaReportResult medulaReportResult = (MedulaReportResult)objectContext.GetObject(participatnFreeDrugReportImported.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
                        //   MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                        medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Completed;
                        medulaReportResult.ResultCode = response.sonucKodu;
                        medulaReportResult.ResultExplanation = TTUtils.CultureService.GetText("M26743", "Rapor Bilgisi Silinmiştir");
                        medulaReportResult.ReportRowNumber = null;
                        medulaReportResult.ReportNumber = "";
                        medulaReportResult.ReportChasingNo = "";
                        participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.Report;
                        input.viewModel._ParticipatnFreeDrugReport = participatnFreeDrugReportImported;
                        participatnFreeDrugReportImported.IsSendedMedula = false;
                        participatnFreeDrugReportImported.IsSecondDoctorApproved = false;
                        participatnFreeDrugReportImported.IsThirdDoctorApproved = false;
                        objectContext.Save();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(response.sonucMesaji))
                        {
                            MedulaReportResult medulaReportResult = (MedulaReportResult)objectContext.GetObject(participatnFreeDrugReportImported.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
                            // MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                            medulaReportResult.ResultCode = response.sonucKodu;
                            medulaReportResult.ResultExplanation = response.sonucMesaji;
                            objectContext.Save();

                            if (response.sonucKodu == "RAP_0021")
                            {
                                participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.Report;
                                input.viewModel.ReadOnly = true;
                                input.viewModel._ParticipatnFreeDrugReport = participatnFreeDrugReportImported;
                                participatnFreeDrugReportImported.IsSendedMedula = false;
                                participatnFreeDrugReportImported.IsSecondDoctorApproved = false;
                                participatnFreeDrugReportImported.IsThirdDoctorApproved = false;
                                objectContext.Save();
                            }

                            input.viewModel.ReadOnly = false;
                        }
                    }

                    return response;
                }
            }
            return null;
        }



        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Sil)]
        public IlacRaporuServis.eraporSilCevapDVO Sil(ParticipationFreeDrugReportNewFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(viewModel._ParticipatnFreeDrugReport);
                    MedulaReportResult currentMedulaReportResult = viewModel.SelectededulaReportResult;
                    if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                    {
                        IlacRaporuServis.eraporSilIstekDVO eraporSilIstekDVO = new IlacRaporuServis.eraporSilIstekDVO();
                        eraporSilIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                        eraporSilIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                        eraporSilIstekDVO.raporTakipNo = currentMedulaReportResult.ReportChasingNo;



                        string username = "";
                        string password = "";

                        var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                        if (MedulaPasswordCheck == "TRUE")
                        {
                            if ((viewModel.medulaUsername != null && viewModel.medulaUsername != "") || (viewModel.medulaPassword != null && viewModel.medulaPassword != ""))
                            {
                                eraporSilIstekDVO.doktorTcKimlikNo = viewModel.medulaUsername;
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
                            username = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                            eraporSilIstekDVO.doktorTcKimlikNo = username;
                            if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                                password = participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword;
                            else if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                                password = viewModel._ParticipatnFreeDrugReport.MedulaPassword;
                        }
                        IlacRaporuServis.eraporSilCevapDVO response = IlacRaporuServis.WebMethods.eraporSil(Sites.SiteLocalHost, username, password, eraporSilIstekDVO);
                        if (response != null && response.sonucKodu != null && response.sonucKodu == "0000")
                        {

                            participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                            if (participatnFreeDrugReportImported.CommitteeReport.HasValue && participatnFreeDrugReportImported.CommitteeReport.Value == true)
                                participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.SecondDoctorApproval;
                            else
                                participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.Approval;
                            //participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.Completed;

                            MedulaReportResult medulaReportResult = (MedulaReportResult)objectContext.GetObject(participatnFreeDrugReportImported.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
                            //   MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                            medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Completed;
                            medulaReportResult.ResultCode = response.sonucKodu;
                            medulaReportResult.ResultExplanation = TTUtils.CultureService.GetText("M26743", "Rapor Bilgisi Silinmiştir");
                            medulaReportResult.ReportRowNumber = null;
                            medulaReportResult.ReportNumber = "";
                            medulaReportResult.ReportChasingNo = "";
                            participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.Report;
                            viewModel._ParticipatnFreeDrugReport = participatnFreeDrugReportImported;
                            participatnFreeDrugReportImported.IsSendedMedula = false;

                            objectContext.Save();
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(response.sonucMesaji))
                            {
                                MedulaReportResult medulaReportResult = (MedulaReportResult)objectContext.GetObject(participatnFreeDrugReportImported.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
                                // MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                                medulaReportResult.ResultCode = response.sonucKodu;
                                medulaReportResult.ResultExplanation = response.sonucMesaji;
                                objectContext.Save();

                                if (response.sonucKodu == "RAP_0021")
                                {
                                    participatnFreeDrugReportImported.CurrentStateDefID = ParticipatnFreeDrugReport.States.Report;
                                    viewModel.ReadOnly = true;
                                    viewModel._ParticipatnFreeDrugReport = participatnFreeDrugReportImported;
                                    participatnFreeDrugReportImported.IsSendedMedula = false;

                                    objectContext.Save();
                                }

                                viewModel.ReadOnly = false;
                            }
                        }

                        return response;
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
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Kaydet)]
        public void Cancel(ParticipatnFreeDrugReport participatnFreeDrugReport)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                participatnFreeDrugReport = objectContext.GetObject(participatnFreeDrugReport.ObjectID, "ParticipatnFreeDrugReport", false) as ParticipatnFreeDrugReport;
                if (participatnFreeDrugReport != null)
                {
                    if (participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.Cancelled)
                    {
                        throw new Exception("İptal edilmiş raporlar tekrar iptal edilemez.");
                    }
                    else if (participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.Report || participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.New)
                    {
                        participatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.States.Cancelled;

                        objectContext.Save();
                    }
                    else
                        throw new Exception("Medulaya gönderilmiş raporlar iptal edilemez.Önce raporu 'Geri' alınız.");
                }
                else
                    throw new Exception("Kaydedilmemiş raporlar iptal edilemez.");
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Kaydet)]
        public void Undo(ParticipationFreeDrugReportNewFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                ParticipatnFreeDrugReport participatnFreeDrugReport = viewModel._ParticipatnFreeDrugReport;

                participatnFreeDrugReport = objectContext.GetObject(participatnFreeDrugReport.ObjectID, "ParticipatnFreeDrugReport", false) as ParticipatnFreeDrugReport;
                if (participatnFreeDrugReport != null)
                {
                    if (participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.ReportCompleted)
                    {
                        participatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.States.Approval;
                    }
                    else if (participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.Approval)
                    {
                        if (participatnFreeDrugReport.CommitteeReport == true)
                            participatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.States.ThirdDoctorApproval;
                    }
                    else if (participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.ThirdDoctorApproval)
                        participatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.States.SecondDoctorApproval;

                    //participatnFreeDrugReport.CurrentStateDefID = ParticipatnFreeDrugReport.States.Completed;
                    //else if (participatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.Completed)//meduladan silinmeli                 
                    objectContext.Save();
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Aciklama_Ekle)]
        public string PrepareSignedReportDescriptionContent(ParticipationFreeDrugReportNewFormViewModel viewModel)
        {
            string output = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(viewModel._ParticipatnFreeDrugReport);
                MedulaReportResult currentMedulaReportResult = viewModel.SelectededulaReportResult;
                if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                {
                    viewModel.AciklamaEkleIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    viewModel.AciklamaEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    //participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                    string password = "";
                    string username = "";

                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((viewModel.medulaUsername != null && viewModel.medulaUsername != "") || (viewModel.medulaPassword != null && viewModel.medulaPassword != ""))
                        {
                            username = viewModel.medulaUsername;
                            viewModel.AciklamaEkleIstekDVO.doktorTcKimlikNo = username;
                        }
                        else
                        {
                            throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                        }
                    }
                    else
                    {
                        username = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                        viewModel.AciklamaEkleIstekDVO.doktorTcKimlikNo = username;
                        if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                            password = participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword;
                        //else if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                        //    password = viewModel._ParticipatnFreeDrugReport.MedulaPassword;                 
                        else
                            throw new Exception("EReçete Şifresi Boş Olamaz");
                    }

                    string imzalanacakXml = Common.SerializeObjectToXml(viewModel.AciklamaEkleIstekDVO);
                    imzalanacakXml = imzalanacakXml.Replace("eraporAciklamaEkleIstekDVO", "imzaliEraporAciklamaBilgisi");
                    imzalanacakXml = imzalanacakXml.Replace("eraporAciklamaDVO", "eraporAciklamaBilgisi");


                    return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
                }
            }
            return output;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Aciklama_Ekle)]
        public ParticipationFreeDrugReportNewFormViewModel SendSignedReportDescriptionContent(SendSignedReportAddDescription_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(input.viewModel._ParticipatnFreeDrugReport);
                var signedData = Convert.FromBase64String(input.signContent);

                MedulaReportResult currentMedulaReportResult = input.viewModel.SelectededulaReportResult;
                if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                {
                    IlacRaporuServis.imzaliEraporAciklamaEkleIstekDVO eraporAciklamaEkleIstekDVO = new IlacRaporuServis.imzaliEraporAciklamaEkleIstekDVO();
                    eraporAciklamaEkleIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    eraporAciklamaEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    eraporAciklamaEkleIstekDVO.imzaliEraporAciklama = signedData;
                    eraporAciklamaEkleIstekDVO.surumNumarasi = 1;


                    string username = "";
                    string password = "";

                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((input.viewModel.medulaUsername != null && input.viewModel.medulaUsername != "") || (input.viewModel.medulaPassword != null && input.viewModel.medulaPassword != ""))
                        {
                            eraporAciklamaEkleIstekDVO.doktorTcKimlikNo = input.viewModel.medulaUsername;
                            username = input.viewModel.medulaUsername;
                            password = input.viewModel.medulaPassword;
                        }
                        else
                        {
                            throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                        }
                    }
                    else
                    {
                        username = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                        eraporAciklamaEkleIstekDVO.doktorTcKimlikNo = username;
                        if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                            password = participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword;
                        else if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                            password = input.viewModel._ParticipatnFreeDrugReport.MedulaPassword;
                    }
                    IlacRaporuServis.imzaliEraporAciklamaEkleCevapDVO response = IlacRaporuServis.WebMethods.imzaliEraporAciklamaEkleSync(Sites.SiteLocalHost, username, password, eraporAciklamaEkleIstekDVO);
                    if (response != null && response.sonucKodu != null && response.sonucKodu == "0000")
                    {
                        input.viewModel.sonucKodu = response.sonucKodu;
                        input.viewModel.sonucMesaji = response.sonucMesaji;
                        input.viewModel.uyariMesaji = response.uyariMesaji;
                        //TTObjectContext _context = viewModel._ParticipatnFreeDrugReport.ObjectContext;
                        ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)objectContext.GetObject(participatnFreeDrugReportImported.ObjectID, typeof(ParticipatnFreeDrugReport));
                        string aciklama = string.Empty;
                        aciklama = TTReportTool.TTReport.HTMLtoText(input.viewModel.AciklamaEkleIstekDVO.eraporAciklamaDVO.aciklama.ToString());
                        //aciklama += response.sonucMesaji + " " + response.uyariMesaji + " " + TTUtils.CultureService.GetText("M26175", "İşlem Başarılı.");
                        _participationFreeDrugReport.Description += TTReportTool.TTReport.HTMLtoText(aciklama);
                        objectContext.Save();
                        participatnFreeDrugReportImported.Description += TTReportTool.TTReport.HTMLtoText(aciklama);
                    }

                    return input.viewModel;

                }
            }
            return null;
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Aciklama_Ekle)]
        public ParticipationFreeDrugReportNewFormViewModel AciklamaEkle(ParticipationFreeDrugReportNewFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(viewModel._ParticipatnFreeDrugReport);
                    MedulaReportResult currentMedulaReportResult = viewModel.SelectededulaReportResult;
                    if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                    {
                        viewModel.AciklamaEkleIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                        viewModel.AciklamaEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                        participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                        string password = "";
                        string username = "";

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
                            username = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                            if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                                password = participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword;
                            //else if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                            //    password = viewModel._ParticipatnFreeDrugReport.MedulaPassword;                 
                            else
                                throw new Exception("EReçete Şifresi Boş Olamaz");
                        }
                        IlacRaporuServis.eraporAciklamaEkleCevapDVO response = IlacRaporuServis.WebMethods.eraporAciklamaEkle(Sites.SiteLocalHost, username, password, viewModel.AciklamaEkleIstekDVO);

                        if (response != null && response.sonucKodu != null && response.sonucKodu == "0000")
                        {
                            viewModel.sonucKodu = response.sonucKodu;
                            viewModel.sonucMesaji = response.sonucMesaji;
                            viewModel.uyariMesaji = response.uyariMesaji;
                            //TTObjectContext _context = viewModel._ParticipatnFreeDrugReport.ObjectContext;
                            ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)objectContext.GetObject(participatnFreeDrugReportImported.ObjectID, typeof(ParticipatnFreeDrugReport));
                            string aciklama = string.Empty;
                            aciklama = TTReportTool.TTReport.HTMLtoText(viewModel.AciklamaEkleIstekDVO.eraporAciklamaDVO.aciklama.ToString());
                            aciklama += response.sonucMesaji + " " + response.uyariMesaji + " " + TTUtils.CultureService.GetText("M26175", "İşlem Başarılı.");
                            _participationFreeDrugReport.Description += TTReportTool.TTReport.HTMLtoText(aciklama);
                            objectContext.Save();
                            participatnFreeDrugReportImported.Description += TTReportTool.TTReport.HTMLtoText(aciklama);
                        }

                        return viewModel;
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
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Tani_Ekle)]
        public string PrepareSignedReportDiagnosisContent(ParticipationFreeDrugReportNewFormViewModel viewModel)
        {
            string output = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(viewModel._ParticipatnFreeDrugReport);
                MedulaReportResult currentMedulaReportResult = viewModel.SelectededulaReportResult;
                if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                {
                    viewModel.TaniEkleIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.ToString();
                    viewModel.TaniEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                    string password = "";
                    string username = "";

                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((viewModel.medulaUsername != null && viewModel.medulaUsername != "") || (viewModel.medulaPassword != null && viewModel.medulaPassword != ""))
                        {
                            username = viewModel.medulaUsername;
                            viewModel.TaniEkleIstekDVO.doktorTcKimlikNo = username;
                        }
                        else
                        {
                            throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                        }
                    }
                    else
                    {
                        username = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                        viewModel.TaniEkleIstekDVO.doktorTcKimlikNo = username;
                        if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                            password = participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword;
                        //else if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                        //    password = viewModel._ParticipatnFreeDrugReport.MedulaPassword;                 
                        else
                            throw new Exception("EReçete Şifresi Boş Olamaz");
                    }
                    string imzalanacakXml = Common.SerializeObjectToXml(viewModel.TaniEkleIstekDVO);
                    imzalanacakXml = imzalanacakXml.Replace("eraporTaniEkleIstekDVO", "imzaliEraporTaniBilgisi");
                    imzalanacakXml = imzalanacakXml.Replace("eraporTaniDVO", "eraporTaniBilgisi");


                    return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
                }
            }
            return output;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Tani_Ekle)]
        public ParticipationFreeDrugReportNewFormViewModel SendSignedReportDiagnosisContent(SendSignedReportAddDiagnosis_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(input.viewModel._ParticipatnFreeDrugReport);
                var signedData = Convert.FromBase64String(input.signContent);

                MedulaReportResult currentMedulaReportResult = input.viewModel.SelectededulaReportResult;
                if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                {
                    IlacRaporuServis.imzaliEraporTaniEkleIstekDVO eraporTaniEkleIstekDVO = new IlacRaporuServis.imzaliEraporTaniEkleIstekDVO();
                    eraporTaniEkleIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    eraporTaniEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    eraporTaniEkleIstekDVO.imzaliEraporTani = signedData;
                    eraporTaniEkleIstekDVO.surumNumarasi = 1;


                    string username = "";
                    string password = "";

                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((input.viewModel.medulaUsername != null && input.viewModel.medulaUsername != "") || (input.viewModel.medulaPassword != null && input.viewModel.medulaPassword != ""))
                        {
                            eraporTaniEkleIstekDVO.doktorTcKimlikNo = input.viewModel.medulaUsername;
                            username = input.viewModel.medulaUsername;
                            password = input.viewModel.medulaPassword;
                        }
                        else
                        {
                            throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                        }
                    }
                    else
                    {
                        username = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                        eraporTaniEkleIstekDVO.doktorTcKimlikNo = username;
                        if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                            password = participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword;
                        else if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                            password = input.viewModel._ParticipatnFreeDrugReport.MedulaPassword;
                    }
                    IlacRaporuServis.imzaliEraporTaniEkleCevapDVO response = IlacRaporuServis.WebMethods.imzaliEraporTaniEkleSync(Sites.SiteLocalHost, username, password, eraporTaniEkleIstekDVO);
                    if (response != null && response.sonucKodu != null && response.sonucKodu == "0000")
                    {
                        input.viewModel.sonucKodu = response.sonucKodu;
                        input.viewModel.sonucMesaji = response.sonucMesaji;
                        input.viewModel.uyariMesaji = response.uyariMesaji;
                        //TTObjectContext _context = viewModel._ParticipatnFreeDrugReport.ObjectContext;
                        ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)objectContext.GetObject(participatnFreeDrugReportImported.ObjectID, typeof(ParticipatnFreeDrugReport));
                        //DiagnosisGrid newdg = new DiagnosisGrid(_participationFreeDrugReport, DiagnosisDefinition.GetDiagnosisDefinitionByCode(objectContext, viewModel.TaniEkleIstekDVO.eraporTaniDVO.taniKodu, "")[0], false, DiagnosisTypeEnum.Primer, participatnFreeDrugReportImported.ProcedureDoctor, null, null);

                        ////Birçok yerde tekrarlanıyordu yukarıdaki hale getirildi
                        ////DiagnosisGrid newdg = new DiagnosisGrid(_participationFreeDrugReport.ObjectContext);
                        ////newdg.EpisodeAction = _participationFreeDrugReport;
                        ////newdg.AddToHistory = false;
                        ////newdg.Diagnose = DiagnosisDefinition.GetDiagnosisDefinitionByCode(objectContext, viewModel.TaniEkleIstekDVO.eraporTaniDVO.taniKodu, "")[0];
                        ////newdg.DiagnosisType = DiagnosisTypeEnum.Primer;
                        ////newdg.IsMainDiagnose = false;
                        ////newdg.ResponsibleUser = participatnFreeDrugReportImported.ProcedureDoctor; //(ResUser)lstDoctorAddedToEpisodeDiagnosis.SelectedObject;
                        ////newdg.DiagnoseDate = System.DateTime.Now;
                        ////newdg.Episode = participatnFreeDrugReportImported.Episode;
                        ////var diagnosisSubEpisode = new DiagnosisSubEpisode(_participationFreeDrugReport.ObjectContext);
                        ////diagnosisSubEpisode.SubEpisode = _participationFreeDrugReport.SubEpisode;
                        ////diagnosisSubEpisode.DiagnosisGrid = newdg;




                        var mevcutReportDiagnosis = _participationFreeDrugReport.ReportDiagnosis.FirstOrDefault(dr => dr.Diagnose.Code == input.viewModel.TaniEkleIstekDVO.eraporTaniDVO.taniKodu);
                        if (mevcutReportDiagnosis != null) //Clinetdan gelen TanıTeşhis tanısı için mevcut  RaporDiagnosis Varsa 
                        {

                            var mevcutTaniTeshis = mevcutReportDiagnosis.TaniTeshisİliskisi.FirstOrDefault(dr => dr.Teshis.teshisKodu.ToString() == input.viewModel.TaniEkleIstekDVO.raporTeshisKodu);
                            if (mevcutTaniTeshis == null)//Clinetdan gelen TanıTeşhis teşhisi  için mevcut  TanıTeşhis Varsa
                            {

                                Teshis teshis = Teshis.GetTesihisByCode(objectContext, input.viewModel.TaniEkleIstekDVO.raporTeshisKodu, "")[0];
                                TaniTeshisİliskisi taniTeshisİliskisi = new TaniTeshisİliskisi(objectContext);
                                taniTeshisİliskisi.Teshis = teshis;
                                taniTeshisİliskisi.ReportDiagnosis = mevcutReportDiagnosis;
                            }

                        }
                        else //Clinetdan gelen TanıTeşhis tanısı için mevcut  RaporDiagnosis Yoksa 
                        {

                            var diagnosisDefList = DiagnosisDefinition.GetDiagnosisDefinitionByCode(objectContext, input.viewModel.TaniEkleIstekDVO.eraporTaniDVO.taniKodu);

                            if (diagnosisDefList.Count > 0)
                            {
                                ReportDiagnosis reportDiagnosis = new ReportDiagnosis(objectContext);
                                reportDiagnosis.Diagnose = diagnosisDefList[0];
                                reportDiagnosis.DiagnoseDate = Common.RecTime();
                                reportDiagnosis.EpisodeAction = _participationFreeDrugReport;


                                Teshis teshis = Teshis.GetTesihisByCode(objectContext, input.viewModel.TaniEkleIstekDVO.raporTeshisKodu, "")[0];
                                TaniTeshisİliskisi taniTeshisİliskisi = new TaniTeshisİliskisi(objectContext);
                                taniTeshisİliskisi.Teshis = teshis;
                                taniTeshisİliskisi.ReportDiagnosis = reportDiagnosis;
                            }



                        }
                        // newdg.Teshis = Teshis.GetTesihisByCode(objectContext, viewModel.TaniEkleIstekDVO.raporTeshisKodu, "")[0];
                        //participatnFreeDrugReportImported.Diagnosis.Add(newdg);
                        objectContext.Save();
                    }

                    return input.viewModel;

                }
            }
            return null;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Tani_Ekle)]
        public ParticipationFreeDrugReportNewFormViewModel TaniEkle(ParticipationFreeDrugReportNewFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(viewModel._ParticipatnFreeDrugReport);
                    MedulaReportResult currentMedulaReportResult = viewModel.SelectededulaReportResult;
                    if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                    {
                        viewModel.TaniEkleIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.ToString();
                        viewModel.TaniEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                        participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                        string password = "";
                        string username = "";

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
                            username = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                            if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                                password = participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword;
                            //else if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                            //    password = viewModel._ParticipatnFreeDrugReport.MedulaPassword;                 
                            else
                                throw new Exception("EReçete Şifresi Boş Olamaz");
                        }
                        IlacRaporuServis.eraporTaniEkleCevapDVO response = IlacRaporuServis.WebMethods.eraporTaniEkle(Sites.SiteLocalHost, username, password, viewModel.TaniEkleIstekDVO);

                        if (response != null && response.sonucKodu != null && response.sonucKodu == "0000")
                        {
                            viewModel.sonucKodu = response.sonucKodu;
                            viewModel.sonucMesaji = response.sonucMesaji;
                            viewModel.uyariMesaji = response.uyariMesaji;
                            //TTObjectContext _context = viewModel._ParticipatnFreeDrugReport.ObjectContext;
                            ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)objectContext.GetObject(participatnFreeDrugReportImported.ObjectID, typeof(ParticipatnFreeDrugReport));
                            //DiagnosisGrid newdg = new DiagnosisGrid(_participationFreeDrugReport, DiagnosisDefinition.GetDiagnosisDefinitionByCode(objectContext, viewModel.TaniEkleIstekDVO.eraporTaniDVO.taniKodu, "")[0], false, DiagnosisTypeEnum.Primer, participatnFreeDrugReportImported.ProcedureDoctor, null, null);

                            ////Birçok yerde tekrarlanıyordu yukarıdaki hale getirildi
                            ////DiagnosisGrid newdg = new DiagnosisGrid(_participationFreeDrugReport.ObjectContext);
                            ////newdg.EpisodeAction = _participationFreeDrugReport;
                            ////newdg.AddToHistory = false;
                            ////newdg.Diagnose = DiagnosisDefinition.GetDiagnosisDefinitionByCode(objectContext, viewModel.TaniEkleIstekDVO.eraporTaniDVO.taniKodu, "")[0];
                            ////newdg.DiagnosisType = DiagnosisTypeEnum.Primer;
                            ////newdg.IsMainDiagnose = false;
                            ////newdg.ResponsibleUser = participatnFreeDrugReportImported.ProcedureDoctor; //(ResUser)lstDoctorAddedToEpisodeDiagnosis.SelectedObject;
                            ////newdg.DiagnoseDate = System.DateTime.Now;
                            ////newdg.Episode = participatnFreeDrugReportImported.Episode;
                            ////var diagnosisSubEpisode = new DiagnosisSubEpisode(_participationFreeDrugReport.ObjectContext);
                            ////diagnosisSubEpisode.SubEpisode = _participationFreeDrugReport.SubEpisode;
                            ////diagnosisSubEpisode.DiagnosisGrid = newdg;




                            var mevcutReportDiagnosis = _participationFreeDrugReport.ReportDiagnosis.FirstOrDefault(dr => dr.Diagnose.Code == viewModel.TaniEkleIstekDVO.eraporTaniDVO.taniKodu);
                            if (mevcutReportDiagnosis != null) //Clinetdan gelen TanıTeşhis tanısı için mevcut  RaporDiagnosis Varsa 
                            {

                                var mevcutTaniTeshis = mevcutReportDiagnosis.TaniTeshisİliskisi.FirstOrDefault(dr => dr.Teshis.teshisKodu.ToString() == viewModel.TaniEkleIstekDVO.raporTeshisKodu);
                                if (mevcutTaniTeshis == null)//Clinetdan gelen TanıTeşhis teşhisi  için mevcut  TanıTeşhis Varsa
                                {

                                    Teshis teshis = Teshis.GetTesihisByCode(objectContext, viewModel.TaniEkleIstekDVO.raporTeshisKodu, "")[0];
                                    TaniTeshisİliskisi taniTeshisİliskisi = new TaniTeshisİliskisi(objectContext);
                                    taniTeshisİliskisi.Teshis = teshis;
                                    taniTeshisİliskisi.ReportDiagnosis = mevcutReportDiagnosis;

                                }

                            }
                            else //Clinetdan gelen TanıTeşhis tanısı için mevcut  RaporDiagnosis Yoksa 
                            {

                                var diagnosisDefList = DiagnosisDefinition.GetDiagnosisDefinitionByCode(objectContext, viewModel.TaniEkleIstekDVO.eraporTaniDVO.taniKodu);

                                if (diagnosisDefList.Count > 0)
                                {
                                    ReportDiagnosis reportDiagnosis = new ReportDiagnosis(objectContext);
                                    reportDiagnosis.Diagnose = diagnosisDefList[0];
                                    reportDiagnosis.DiagnoseDate = Common.RecTime();
                                    reportDiagnosis.EpisodeAction = _participationFreeDrugReport;


                                    Teshis teshis = Teshis.GetTesihisByCode(objectContext, viewModel.TaniEkleIstekDVO.raporTeshisKodu, "")[0];
                                    TaniTeshisİliskisi taniTeshisİliskisi = new TaniTeshisİliskisi(objectContext);
                                    taniTeshisİliskisi.Teshis = teshis;
                                    taniTeshisİliskisi.ReportDiagnosis = mevcutReportDiagnosis;
                                }



                            }
                            // newdg.Teshis = Teshis.GetTesihisByCode(objectContext, viewModel.TaniEkleIstekDVO.raporTeshisKodu, "")[0];
                            //participatnFreeDrugReportImported.Diagnosis.Add(newdg);
                            objectContext.Save();
                        }

                        return viewModel;
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
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Teshis_Ekle)]
        public List<TeshisImzalanacakXml> PrepareSignedReportTeshisContent(ParticipationFreeDrugReportNewFormViewModel viewModel)
        {
             List<TeshisImzalanacakXml> xmlList = new List<TeshisImzalanacakXml>();
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(viewModel._ParticipatnFreeDrugReport);
                MedulaReportResult currentMedulaReportResult = viewModel.SelectededulaReportResult;
                if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                {
                    viewModel.TeshisEkleIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.ToString();
                    viewModel.TeshisEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    //viewModel.TeshisEkleIstekDVO.eraporTeshisDVO.baslangicTarihi = Convert.ToDateTime(viewModel.TeshistStartDate).ToString("dd.MM.yyyy");
                    //viewModel.TeshisEkleIstekDVO.eraporTeshisDVO.baslangicTarihi = Convert.ToDateTime(viewModel.TeshisEndDate).ToString("dd.MM.yyyy");
                    List<IlacRaporuServis.taniDVO> taniDVOList = new List<IlacRaporuServis.taniDVO>();
                    foreach (AddedDiagnosisListModel item in viewModel.AddedDiagnosisList)
                    {
                        IlacRaporuServis.taniDVO taniDVO = new IlacRaporuServis.taniDVO();
                        taniDVO.kodu = item.Tani.Code;
                        taniDVO.adi = item.Tani.Name;
                        taniDVOList.Add(taniDVO);
                    }

                    List<IlacRaporuServis.eraporIlaveDegerDVO> eraporIlaveDegerDVOs = ilaveDegerOlustur(viewModel.SelectedTeshisTaniList, viewModel.ReportReasonList, participatnFreeDrugReportImported, objectContext);

                    viewModel.TeshisEkleIstekDVO.eraporTeshisDVO.taniListesi = taniDVOList.ToArray();
                    //participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                    string password = "";
                    string username = "";

                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((viewModel.medulaUsername != null && viewModel.medulaUsername != "") || (viewModel.medulaPassword != null && viewModel.medulaPassword != ""))
                        {
                            username = viewModel.medulaUsername;
                            password = viewModel.medulaPassword;
                            viewModel.TeshisEkleIstekDVO.doktorTcKimlikNo = username;
                        }
                        else
                        {
                            throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                        }
                    }
                    else
                    {
                        username = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                        viewModel.TeshisEkleIstekDVO.doktorTcKimlikNo = username;
                        if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                            password = participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword;
                        //else if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                        //    password = viewModel._ParticipatnFreeDrugReport.MedulaPassword;                 
                        else
                            throw new Exception("EReçete Şifresi Boş Olamaz");
                    }
                    string imzalanacakXml = Common.SerializeObjectToXml(viewModel.TeshisEkleIstekDVO);
                    string imzalanacakTeshisXml = string.Empty;
                    if (eraporIlaveDegerDVOs.Count > 0)
                    {
                        TeshisImzalanacakXml ilaveDeger = new TeshisImzalanacakXml();
                        imzalanacakTeshisXml = Common.SerializeObjectToXml(eraporIlaveDegerDVOs);
                        imzalanacakTeshisXml = imzalanacakTeshisXml.Replace("eraporIlaveDegerDVO", "imzaliEraporIlaveDegerBilgisi");
                        imzalanacakTeshisXml = imzalanacakTeshisXml.Replace("eraporIlaveDegerListesi", "eraporIlaveDegerBilgisi");
                        ilaveDeger.imzalanacakXml = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakTeshisXml));
                        ilaveDeger.Type = 2;
                        xmlList.Add(ilaveDeger);
                    }
                     TeshisImzalanacakXml teshis = new TeshisImzalanacakXml();

                    imzalanacakXml = imzalanacakXml.Replace("eraporTeshisEkleIstekDVO", "imzaliEraporTeshisBilgisi");
                    imzalanacakXml = imzalanacakXml.Replace("eraporTeshisEkleIstekDVO", "imzaliEraporTeshisBilgisi");
                    imzalanacakXml = imzalanacakXml.Replace("taniListesi", "taniBilgisi");
                    imzalanacakXml = imzalanacakXml.Replace("eraporTeshisDVO", "eraporTeshisBilgisi");
                    teshis.imzalanacakXml = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
                    teshis.Type = 1;
                    xmlList.Add(teshis);

                }
                return xmlList;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Teshis_Ekle)]
        public ParticipationFreeDrugReportNewFormViewModel SendSignedReportTeshisContent(SendSignedReportAddTeshis_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(input.viewModel._ParticipatnFreeDrugReport);

                IlacRaporuServis.imzaliEraporTeshisEkleIstekDVO eraporTeshisEkleIstekDVO = null;
                IlacRaporuServis.imzaliEraporIlaveDegerEkleIstekDVO imzaliIlaveDeger = null;
                MedulaReportResult currentMedulaReportResult = input.viewModel.SelectededulaReportResult;
                if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                {
                    foreach (var item in input.signContentList)
                    {
                        if (item.Type == 1)
                        {
                            eraporTeshisEkleIstekDVO = new IlacRaporuServis.imzaliEraporTeshisEkleIstekDVO();
                            eraporTeshisEkleIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                            eraporTeshisEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                            eraporTeshisEkleIstekDVO.imzaliEraporTeshis = Convert.FromBase64String(item.imzalanacakXml);;
                            eraporTeshisEkleIstekDVO.surumNumarasi = 1;
                        }
                        else if (item.Type == 2)
                        {
                            imzaliIlaveDeger = new IlacRaporuServis.imzaliEraporIlaveDegerEkleIstekDVO();
                            imzaliIlaveDeger.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                            imzaliIlaveDeger.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                            imzaliIlaveDeger.surumNumarasi = 1;
                            imzaliIlaveDeger.imzaliEraporIlaveDeger = Convert.FromBase64String(item.imzalanacakXml);
                        }

                    }
                    string username = "";
                    string password = "";

                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((input.viewModel.medulaUsername != null && input.viewModel.medulaUsername != "") || (input.viewModel.medulaPassword != null && input.viewModel.medulaPassword != ""))
                        {
                            eraporTeshisEkleIstekDVO.doktorTcKimlikNo = input.viewModel.medulaUsername;
                            username = input.viewModel.medulaUsername;
                            password = input.viewModel.medulaPassword;
                        }
                        else
                        {
                            throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                        }
                    }
                    else
                    {
                        username = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                        eraporTeshisEkleIstekDVO.doktorTcKimlikNo = username;
                        if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                            password = participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword;
                        else if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                            password = input.viewModel._ParticipatnFreeDrugReport.MedulaPassword;
                    }
                    IlacRaporuServis.imzaliEraporTeshisEkleCevapDVO response = IlacRaporuServis.WebMethods.imzaliEraporTeshisEkleSync(Sites.SiteLocalHost, username, password, eraporTeshisEkleIstekDVO);
                    if (response != null && response.sonucKodu != null && response.sonucKodu == "0000")
                    {
                        input.viewModel.sonucKodu = response.sonucKodu + Environment.NewLine;
                        input.viewModel.sonucMesaji = response.sonucMesaji + Environment.NewLine;
                        input.viewModel.uyariMesaji = response.uyariMesaji + Environment.NewLine;
                        //TTObjectContext _context = viewModel._ParticipatnFreeDrugReport.ObjectContext;
                        ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)objectContext.GetObject(participatnFreeDrugReportImported.ObjectID, typeof(ParticipatnFreeDrugReport));
                        foreach (AddedDiagnosisListModel item in input.viewModel.AddedDiagnosisList)
                        {


                            var mevcutReportDiagnosis = _participationFreeDrugReport.ReportDiagnosis.FirstOrDefault(dr => dr.Diagnose.Code == item.Tani.Code);
                            if (mevcutReportDiagnosis != null) //Clinetdan gelen TanıTeşhis tanısı için mevcut  RaporDiagnosis Varsa 
                            {

                                var mevcutTaniTeshis = mevcutReportDiagnosis.TaniTeshisİliskisi.FirstOrDefault(dr => dr.Teshis.teshisKodu.ToString() == input.viewModel.TeshisEkleIstekDVO.eraporTeshisDVO.raporTeshisKodu);
                                if (mevcutTaniTeshis == null)//Clinetdan gelen TanıTeşhis teşhisi  için mevcut  TanıTeşhis Varsa
                                {

                                    Teshis teshis = Teshis.GetTesihisByCode(objectContext, input.viewModel.TaniEkleIstekDVO.raporTeshisKodu, "")[0];
                                    TaniTeshisİliskisi taniTeshisİliskisi = new TaniTeshisİliskisi(objectContext);
                                    taniTeshisİliskisi.Teshis = teshis;
                                    taniTeshisİliskisi.ReportDiagnosis = mevcutReportDiagnosis;

                                }

                            }
                            else //Clinetdan gelen TanıTeşhis tanısı için mevcut  RaporDiagnosis Yoksa 
                            {

                                var diagnosisDefList = DiagnosisDefinition.GetDiagnosisDefinitionByCode(objectContext, item.Tani.Code);

                                if (diagnosisDefList.Count > 0)
                                {
                                    ReportDiagnosis reportDiagnosis = new ReportDiagnosis(objectContext);
                                    reportDiagnosis.Diagnose = diagnosisDefList[0];
                                    reportDiagnosis.DiagnoseDate = Common.RecTime();
                                    reportDiagnosis.EpisodeAction = _participationFreeDrugReport;


                                    Teshis teshis = Teshis.GetTesihisByCode(objectContext, input.viewModel.TeshisEkleIstekDVO.eraporTeshisDVO.raporTeshisKodu, "")[0];
                                    TaniTeshisİliskisi taniTeshisİliskisi = new TaniTeshisİliskisi(objectContext);
                                    taniTeshisİliskisi.Teshis = teshis;
                                    taniTeshisİliskisi.ReportDiagnosis = mevcutReportDiagnosis;
                                }



                            }
                        }
                        IlacRaporuServis.imzaliEraporIlaveDegerEkleCevapDVO responseIlaveDeger = IlacRaporuServis.WebMethods.imzaliEraporIlaveDegerEkleSync(Sites.SiteLocalHost, participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString(), password, imzaliIlaveDeger);
                        if (responseIlaveDeger != null)
                        {
                        input.viewModel.sonucKodu += responseIlaveDeger.sonucKodu;
                        input.viewModel.sonucMesaji += responseIlaveDeger.sonucMesaji;
                        input.viewModel.uyariMesaji += responseIlaveDeger.uyariMesaji;
                        }

                        objectContext.Save();
                    }

                    return input.viewModel;

                }
            }
            return null;
        }



        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Teshis_Ekle)]
        public ParticipationFreeDrugReportNewFormViewModel TeshisEkle(ParticipationFreeDrugReportNewFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(viewModel._ParticipatnFreeDrugReport);
                    MedulaReportResult currentMedulaReportResult = viewModel.SelectededulaReportResult;
                    if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                    {
                        viewModel.TeshisEkleIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.ToString();
                        viewModel.TeshisEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                        //viewModel.TeshisEkleIstekDVO.eraporTeshisDVO.baslangicTarihi = Convert.ToDateTime(viewModel.TeshistStartDate).ToString("dd.MM.yyyy");
                        //viewModel.TeshisEkleIstekDVO.eraporTeshisDVO.baslangicTarihi = Convert.ToDateTime(viewModel.TeshisEndDate).ToString("dd.MM.yyyy");
                        List<IlacRaporuServis.taniDVO> taniDVOList = new List<IlacRaporuServis.taniDVO>();
                        foreach (AddedDiagnosisListModel item in viewModel.AddedDiagnosisList)
                        {
                            IlacRaporuServis.taniDVO taniDVO = new IlacRaporuServis.taniDVO();
                            taniDVO.kodu = item.Tani.Code;
                            taniDVO.adi = item.Tani.Name;
                            taniDVOList.Add(taniDVO);
                        }

                        viewModel.TeshisEkleIstekDVO.eraporTeshisDVO.taniListesi = taniDVOList.ToArray();
                        participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                        string password = "";
                        string username = "";

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
                            username = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                            if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                                password = participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword;
                            //else if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                            //    password = viewModel._ParticipatnFreeDrugReport.MedulaPassword;                 
                            else
                                throw new Exception("EReçete Şifresi Boş Olamaz");
                        }
                        IlacRaporuServis.eraporTeshisEkleCevapDVO response = IlacRaporuServis.WebMethods.eraporTeshisEkle(Sites.SiteLocalHost, username, password, viewModel.TeshisEkleIstekDVO);

                        if (response != null && response.sonucKodu != null && response.sonucKodu == "0000")
                        {
                            viewModel.sonucKodu = response.sonucKodu;
                            viewModel.sonucMesaji = response.sonucMesaji;
                            viewModel.uyariMesaji = response.uyariMesaji;
                            //TTObjectContext _context = viewModel._ParticipatnFreeDrugReport.ObjectContext;
                            ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)objectContext.GetObject(participatnFreeDrugReportImported.ObjectID, typeof(ParticipatnFreeDrugReport));
                            foreach (AddedDiagnosisListModel item in viewModel.AddedDiagnosisList)
                            {

                                var mevcutReportDiagnosis = _participationFreeDrugReport.ReportDiagnosis.FirstOrDefault(dr => dr.Diagnose.Code == viewModel.TaniEkleIstekDVO.eraporTaniDVO.taniKodu);
                                if (mevcutReportDiagnosis != null) //Clinetdan gelen TanıTeşhis tanısı için mevcut  RaporDiagnosis Varsa 
                                {

                                    var mevcutTaniTeshis = mevcutReportDiagnosis.TaniTeshisİliskisi.FirstOrDefault(dr => dr.Teshis.teshisKodu.ToString() == viewModel.TaniEkleIstekDVO.raporTeshisKodu);
                                    if (mevcutTaniTeshis == null)//Clinetdan gelen TanıTeşhis teşhisi  için mevcut  TanıTeşhis Varsa
                                    {

                                        Teshis teshis = Teshis.GetTesihisByCode(objectContext, viewModel.TaniEkleIstekDVO.raporTeshisKodu, "")[0];
                                        TaniTeshisİliskisi taniTeshisİliskisi = new TaniTeshisİliskisi(objectContext);
                                        taniTeshisİliskisi.Teshis = teshis;
                                        taniTeshisİliskisi.ReportDiagnosis = mevcutReportDiagnosis;

                                    }

                                }
                                else //Clinetdan gelen TanıTeşhis tanısı için mevcut  RaporDiagnosis Yoksa 
                                {

                                    var diagnosisDefList = DiagnosisDefinition.GetDiagnosisDefinitionByCode(objectContext, viewModel.TaniEkleIstekDVO.eraporTaniDVO.taniKodu);

                                    if (diagnosisDefList.Count > 0)
                                    {
                                        ReportDiagnosis reportDiagnosis = new ReportDiagnosis(objectContext);
                                        reportDiagnosis.Diagnose = diagnosisDefList[0];
                                        reportDiagnosis.DiagnoseDate = Common.RecTime();
                                        reportDiagnosis.EpisodeAction = _participationFreeDrugReport;


                                        Teshis teshis = Teshis.GetTesihisByCode(objectContext, viewModel.TaniEkleIstekDVO.raporTeshisKodu, "")[0];
                                        TaniTeshisİliskisi taniTeshisİliskisi = new TaniTeshisİliskisi(objectContext);
                                        taniTeshisİliskisi.Teshis = teshis;
                                        taniTeshisİliskisi.ReportDiagnosis = mevcutReportDiagnosis;
                                    }



                                }
                            }

                            objectContext.Save();
                        }

                        return viewModel;
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
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Etkin_Madde_Ekle)]
        public string PrepareSignedReportEtkinMaddeContent(ParticipationFreeDrugReportNewFormViewModel viewModel)
        {
            string output = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(viewModel._ParticipatnFreeDrugReport);
                MedulaReportResult currentMedulaReportResult = viewModel.SelectededulaReportResult;
                if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                {
                    viewModel.EtkinMaddeEkleIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.ToString();
                    viewModel.EtkinMaddeEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                   // viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDoz1 = DrugOrder.GetDetailCount((FrequencyEnum)Enum.Parse(typeof(FrequencyEnum), viewModel.cmbEklenecekDozAraligi.ToString())).ToString();
                    string password = "";
                    string username = "";

                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((viewModel.medulaUsername != null && viewModel.medulaUsername != "") || (viewModel.medulaPassword != null && viewModel.medulaPassword != ""))
                        {

                            username = viewModel.medulaUsername;
                            password = viewModel.medulaPassword;
                            viewModel.EtkinMaddeEkleIstekDVO.doktorTcKimlikNo = username;
                        }
                        else
                        {
                            throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                        }
                    }
                    else
                    {
                        username = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                        viewModel.EtkinMaddeEkleIstekDVO.doktorTcKimlikNo = username;
                        if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                            password = participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword;
                        //else if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                        //    password = viewModel._ParticipatnFreeDrugReport.MedulaPassword;                 
                        else
                            throw new Exception("EReçete Şifresi Boş Olamaz");
                    }
                    string imzalanacakXml = Common.SerializeObjectToXml(viewModel.EtkinMaddeEkleIstekDVO);
                    imzalanacakXml = imzalanacakXml.Replace("eraporEtkinMaddeEkleIstekDVO", "imzaliEraporEtkinMaddeBilgisi");
                    imzalanacakXml = imzalanacakXml.Replace("eraporEtkinMaddeDVO", "eraporEtkinMaddeBilgisi");
                    imzalanacakXml = imzalanacakXml.Replace("etkinMaddeDVO", "etkinMaddeBilgisi");


                    return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
                }
            }
            return output;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Teshis_Ekle)]
        public ParticipationFreeDrugReportNewFormViewModel SendSignedReportEtkinMaddeContent(SendSignedReportAddEtkinMadde_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(input.viewModel._ParticipatnFreeDrugReport);
                var signedData = Convert.FromBase64String(input.signContent);

                MedulaReportResult currentMedulaReportResult = input.viewModel.SelectededulaReportResult;
                if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                {
                    IlacRaporuServis.imzaliEraporEtkinMaddeEkleIstekDVO eraporEtkinMaddeEkleIstekDVO = new IlacRaporuServis.imzaliEraporEtkinMaddeEkleIstekDVO();
                    eraporEtkinMaddeEkleIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    eraporEtkinMaddeEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    eraporEtkinMaddeEkleIstekDVO.imzaliEraporEtkinMadde = signedData;
                    eraporEtkinMaddeEkleIstekDVO.surumNumarasi = 1;


                    string username = "";
                    string password = "";

                    var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                    if (MedulaPasswordCheck == "TRUE")
                    {
                        if ((input.viewModel.medulaUsername != null && input.viewModel.medulaUsername != "") || (input.viewModel.medulaPassword != null && input.viewModel.medulaPassword != ""))
                        {
                            eraporEtkinMaddeEkleIstekDVO.doktorTcKimlikNo = input.viewModel.medulaUsername;
                            username = input.viewModel.medulaUsername;
                            password = input.viewModel.medulaPassword;
                        }
                        else
                        {
                            throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                        }
                    }
                    else
                    {
                        username = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                        eraporEtkinMaddeEkleIstekDVO.doktorTcKimlikNo = username;
                        if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                            password = participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword;
                        else if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                            password = input.viewModel._ParticipatnFreeDrugReport.MedulaPassword;
                    }
                    IlacRaporuServis.imzaliEraporEtkinMaddeEkleCevapDVO response = IlacRaporuServis.WebMethods.imzaliEraporEtkinMaddeEkleSync(Sites.SiteLocalHost, username, password, eraporEtkinMaddeEkleIstekDVO);

                    if (response != null && response.sonucKodu != null && response.sonucKodu == "0000")
                    {
                        input.viewModel.sonucKodu = response.sonucKodu;
                        input.viewModel.sonucMesaji = response.sonucMesaji;
                        input.viewModel.uyariMesaji = response.uyariMesaji;
                        //TTObjectContext _context = viewModel._ParticipatnFreeDrugReport.ObjectContext;
                        ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)objectContext.GetObject(participatnFreeDrugReportImported.ObjectID, typeof(ParticipatnFreeDrugReport));
                        ParticipationFreeDrgGrid newdg = new ParticipationFreeDrgGrid(_participationFreeDrugReport.ObjectContext);
                        newdg.EtkinMadde = EtkinMadde.GetEtkinMaddeByCode(objectContext, input.viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.etkinMaddeKodu, "")[0];
                        newdg.Frequency = (input.viewModel.cmbEklenecekDozAraligi).ToString() == "0" ? FrequencyEnum.Q1H : (input.viewModel.cmbEklenecekDozAraligi).ToString() == "1" ? FrequencyEnum.Q3H : (input.viewModel.cmbEklenecekDozAraligi).ToString() == "2" ? FrequencyEnum.Q6H : (input.viewModel.cmbEklenecekDozAraligi).ToString() == "3" ? FrequencyEnum.Q8H : (input.viewModel.cmbEklenecekDozAraligi).ToString() == "4" ? FrequencyEnum.Q12H : (input.viewModel.cmbEklenecekDozAraligi).ToString() == "5" ? FrequencyEnum.Q24H : (input.viewModel.cmbEklenecekDozAraligi).ToString() == "6" ? FrequencyEnum.Q2H : FrequencyEnum.Q4H;
                        newdg.PeriodUnitType = input.viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozPeriyotBirimi == "3" ? PeriodUnitTypeEnum.DayPeriod : input.viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozPeriyotBirimi == "4" ? PeriodUnitTypeEnum.WeekPeriod : input.viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozPeriyotBirimi == "5" ? PeriodUnitTypeEnum.MonthPeriod : PeriodUnitTypeEnum.YearPeriod;
                        newdg.ParticipatnFreeDrugReport = _participationFreeDrugReport;
                        newdg.MedulaDoseInteger = input.viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDoz1;
                        newdg.MedulaUsageDose2 = Convert.ToDouble(input.viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDoz2);
                        newdg.UsageDoseUnitType = input.viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozBirimi == "1" ? UsageDoseUnitTypeEnum.Adet : input.viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozBirimi == "2" ? UsageDoseUnitTypeEnum.Mililitre : input.viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozBirimi == "3" ? UsageDoseUnitTypeEnum.Miligram : input.viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozBirimi == "4" ? UsageDoseUnitTypeEnum.Gram : input.viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozBirimi == "5" ? UsageDoseUnitTypeEnum.Damla : input.viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozBirimi == "6" ? UsageDoseUnitTypeEnum.Unite : input.viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozBirimi == "7" ? UsageDoseUnitTypeEnum.Kutu : input.viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozBirimi == "8" ? UsageDoseUnitTypeEnum.Mikrogram : UsageDoseUnitTypeEnum.Mikrolitre;
                        newdg.Day = Convert.ToInt32(input.viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozPeriyot);
                        objectContext.Save();
                        participatnFreeDrugReportImported.ParticipationFreeDrugs.Add(newdg);
                    }

                    return input.viewModel;

                }
            }
            return null;
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Katilim_Payindan_Muaf_Ilac_Raporu_Etkin_Madde_Ekle)]
        public ParticipationFreeDrugReportNewFormViewModel EtkinMaddeEkle(ParticipationFreeDrugReportNewFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var participatnFreeDrugReportImported = (ParticipatnFreeDrugReport)objectContext.AddObject(viewModel._ParticipatnFreeDrugReport);
                    MedulaReportResult currentMedulaReportResult = viewModel.SelectededulaReportResult;
                    if (currentMedulaReportResult != null && currentMedulaReportResult.ReportChasingNo != null)
                    {
                        viewModel.EtkinMaddeEkleIstekDVO.doktorTcKimlikNo = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.ToString();
                        viewModel.EtkinMaddeEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                        viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDoz1 = DrugOrder.GetDetailCount((FrequencyEnum)Enum.Parse(typeof(FrequencyEnum), viewModel.cmbEklenecekDozAraligi.ToString())).ToString();
                        participatnFreeDrugReportImported.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                        string password = "";
                        string username = "";

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
                            username = participatnFreeDrugReportImported.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                            if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword))
                                password = participatnFreeDrugReportImported.ProcedureDoctor.ErecetePassword;
                            //else if (!string.IsNullOrEmpty(participatnFreeDrugReportImported.MedulaPassword))
                            //    password = viewModel._ParticipatnFreeDrugReport.MedulaPassword;                 
                            else
                                throw new Exception("EReçete Şifresi Boş Olamaz");
                        }
                        IlacRaporuServis.eraporEtkinMaddeEkleCevapDVO response = IlacRaporuServis.WebMethods.eraporEtkinMaddeEkle(Sites.SiteLocalHost, username, password, viewModel.EtkinMaddeEkleIstekDVO);
                        viewModel.sonucKodu = response.sonucKodu;
                        viewModel.sonucMesaji = response.sonucMesaji;
                        viewModel.uyariMesaji = response.uyariMesaji;
                        if (response != null && response.sonucKodu != null && response.sonucKodu == "0000")
                        {
                            //TTObjectContext _context = viewModel._ParticipatnFreeDrugReport.ObjectContext;
                            ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)objectContext.GetObject(participatnFreeDrugReportImported.ObjectID, typeof(ParticipatnFreeDrugReport));
                            ParticipationFreeDrgGrid newdg = new ParticipationFreeDrgGrid(_participationFreeDrugReport.ObjectContext);
                            newdg.EtkinMadde = EtkinMadde.GetEtkinMaddeByCode(objectContext, viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.etkinMaddeKodu, "")[0];
                            newdg.Frequency = (viewModel.cmbEklenecekDozAraligi).ToString() == "0" ? FrequencyEnum.Q1H : (viewModel.cmbEklenecekDozAraligi).ToString() == "1" ? FrequencyEnum.Q3H : (viewModel.cmbEklenecekDozAraligi).ToString() == "2" ? FrequencyEnum.Q6H : (viewModel.cmbEklenecekDozAraligi).ToString() == "3" ? FrequencyEnum.Q8H : (viewModel.cmbEklenecekDozAraligi).ToString() == "4" ? FrequencyEnum.Q12H : (viewModel.cmbEklenecekDozAraligi).ToString() == "5" ? FrequencyEnum.Q24H : (viewModel.cmbEklenecekDozAraligi).ToString() == "6" ? FrequencyEnum.Q2H : FrequencyEnum.Q4H;
                            newdg.PeriodUnitType = viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozPeriyotBirimi == "3" ? PeriodUnitTypeEnum.DayPeriod : viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozPeriyotBirimi == "4" ? PeriodUnitTypeEnum.WeekPeriod : viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozPeriyotBirimi == "5" ? PeriodUnitTypeEnum.MonthPeriod : PeriodUnitTypeEnum.YearPeriod;
                            newdg.ParticipatnFreeDrugReport = _participationFreeDrugReport;
                            newdg.MedulaDoseInteger = viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDoz2;
                            newdg.UsageDoseUnitType = viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozBirimi == "1" ? UsageDoseUnitTypeEnum.Adet : viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozBirimi == "2" ? UsageDoseUnitTypeEnum.Mililitre : viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozBirimi == "3" ? UsageDoseUnitTypeEnum.Miligram : viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozBirimi == "4" ? UsageDoseUnitTypeEnum.Gram : viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozBirimi == "5" ? UsageDoseUnitTypeEnum.Damla : viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozBirimi == "6" ? UsageDoseUnitTypeEnum.Unite : viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozBirimi == "7" ? UsageDoseUnitTypeEnum.Kutu : viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozBirimi == "8" ? UsageDoseUnitTypeEnum.Mikrogram : UsageDoseUnitTypeEnum.Mikrolitre;
                            newdg.Day = Convert.ToInt32(viewModel.EtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO.kullanimDozPeriyot);
                            newdg.ParticipatnFreeDrugReport = _participationFreeDrugReport;
                            objectContext.Save();
                            participatnFreeDrugReportImported.ParticipationFreeDrugs.Add(newdg);
                        }

                        return viewModel;
                    }

                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
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

        private void CheckParticipationFreeDrugs(ParticipatnFreeDrugReport participatnFreeDrugReportImported)
        {
            foreach (ParticipationFreeDrgGrid pd in participatnFreeDrugReportImported.ParticipationFreeDrugs)
            {
                if (pd.EtkinMadde == null && pd.DrugName == null)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25936", "Hiçbir etkin madde seçmeden devam edemezsiniz!"));
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
    }
}

namespace Core.Models
{
    public partial class ParticipationFreeDrugReportNewFormViewModel
    {
        public bool IsSuperUser
        {
            get;
            set;
        }
        public bool IsPatientSGK
        {
            get;
            set;
        }

        public bool closeMedula
        {
            get;
            set;
        }
        public DateTime TeshistStartDate
        {
            get;
            set;
        }

        public DateTime TeshisEndDate
        {
            get;
            set;
        }

        public bool SecondDoctorApprove
        {
            get;
            set;
        }

        public bool ThirdDoctorApprove
        {
            get;
            set;
        }

        public string TeshisFilter
        {
            get;
            set;
        }

        public string EtkinMaddeListFilter
        {
            get;
            set;
        }
        public Guid ToState
        {
            get;
            set;
        }
        public MedulaReportResult SelectededulaReportResult
        {
            get;
            set;
        }

        public IlacRaporuServis.eraporAciklamaEkleIstekDVO AciklamaEkleIstekDVO
        {
            get;
            set;
        }

        public IlacRaporuServis.eraporTaniEkleIstekDVO TaniEkleIstekDVO
        {
            get;
            set;
        }

        public IlacRaporuServis.eraporTeshisEkleIstekDVO TeshisEkleIstekDVO
        {
            get;
            set;
        }

        public IlacRaporuServis.eraporEtkinMaddeEkleIstekDVO EtkinMaddeEkleIstekDVO
        {
            get;
            set;
        }

        public List<DozAraligiListModel> DozAraligiList
        {
            get;
            set;
        }

        public List<TaniTeshisListModel> TaniTeshisList
        {
            get;
            set;
        }

        public List<EtkinMaddeListModel> EtkinMaddeList
        {
            get;
            set;
        }

        public List<AddedDiagnosisListModel> AddedDiagnosisList
        {
            get;
            set;
        }
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

        public EtkenMaddeTeshisListModel EtkenMaddeTeshisList
        {
            get;
            set;
        }

        public FrequencyEnum cmbEklenecekDozAraligi
        {
            get;
            set;
        }

        public string sonucKodu
        {
            get;
            set;
        }

        public string sonucMesaji
        {
            get;
            set;
        }

        public string uyariMesaji
        {
            get;
            set;
        }
        public TTObjectClasses.SubEpisodeProtocol SubEpisodeProtocol
        {
            get;
            set;
        }
        public string medulaUsername { get; set; }
        public string medulaPassword { get; set; }
        public ParticipationFreeDrugReportNewFormViewModel()
        {
            this.DozAraligiList = new List<DozAraligiListModel>();
            this.TaniTeshisList = new List<TaniTeshisListModel>();
            this.EtkinMaddeList = new List<EtkinMaddeListModel>();
            this.AddedDiagnosisList = new List<AddedDiagnosisListModel>();
            this.TeshisList = new List<TeshisListModel>();
            this.SelectedTeshisTaniList = new List<AddedDiagnosisListModel>();
        }
        public string maxReportDate { get; set; }
        public string minReportDate { get; set; }
        public string secondDoctor { get; set; }
        public string thirdDoctor { get; set; }
        public List<UserTemplateModel> userTemplateList { get; set; }
        public UserTemplateModel selectedUserTemplate { get; set; }
        public bool hasAuthorityForUndo { get; set; }     
        public List<int> ReportReasonList { get; set; }
   
    }


    public class EtkenMaddeTeshisListModel
    {
        public Guid etkenMaddeObjectId
        {
            get;
            set;
        }
        public List<TeshisListModel> TeshisList
        {
            get;
            set;
        }
    }

    public class TeshisListModel
    {
        public Teshis teshis
        {
            get;
            set;
        }
        public string teshisKodu
        {
            get;
            set;
        }
        public string teshisAdi
        {
            get;
            set;
        }
        public List<AddedDiagnosisListModel> AddedDiagnosisList
        {
            get;
            set;
        }
        public List<AddedDiagnosisListModel> SelectedDiagnosisList
        {
            get;
            set;
        }

        public List<string> SelectedDiagnosisListKeys
        {
            get;
            set;
        }

        public List<EtkinMadde> relatedEtkenMaddeList = new List<EtkinMadde>();
        public string relatedEtkenMaddeNames { get; set; }
        public string selectedDiagnoses { get; set; }

    }
    public class DozAraligiListModel
    {
        public int DozAraligiID
        {
            get;
            set;
        }

        public string DozAraligiText
        {
            get;
            set;
        }
    }

    public class TaniTeshisListModel
    {
        public Guid Tani
        {
            get;
            set;
        }

        public Guid Teshis
        {
            get;
            set;
        }
    }

    public class EtkinMaddeListModel
    {
        public Guid ParticipatientFreeDrugObjectID
        {
            get;
            set;
        }
        public Guid EtkinMadde
        {
            get;
            set;
        }
        public string EtkinMaddeName
        {
            get;
            set;
        }

        public string EtkinMaddeMudalaHarici
        {
            get;
            set;
        }

        public FrequencyEnum DozAraligi
        {
            get;
            set;
        }

        public double Doz
        {
            get;
            set;
        }

        public UsageDoseUnitTypeEnum DozBirimi
        {
            get;
            set;
        }

        public int Periyod
        {
            get;
            set;
        }

        public PeriodUnitTypeEnum PeriyodBirimi
        {
            get;
            set;
        }

        public double Doz2
        {
            get;
            set;
        }
    }

    public class AddedDiagnosisListModel
    {
        public DiagnosisDefinition Tani
        {
            get;
            set;
        }
        public string taniKodu
        {
            get;
            set;
        }
        public Guid teshisObjectID
        {
            get;
            set;
        }
        public string taniAdi
        {
            get;
            set;
        }
        public bool selected
        {
            get;
            set;
        }

    }

    public class DrugReportApproveModel
    {
        public ParticipatnFreeDrugReport participatnFreeDrugReport { get; set; }
        public string medulaUsername { get; set; }
        public string medulaPassword { get; set; }
    }

    public class SendSignedReport_Input
    {
        public string signContent
        {
            get;
            set;
        }
        public ParticipationFreeDrugReportNewFormViewModel viewModel { get; set; }
    }

    public class SendSignedReportDelete_Input
    {
        public string signContent
        {
            get;
            set;
        }
        public ParticipationFreeDrugReportNewFormViewModel viewModel { get; set; }
    }

    public class SendSignedReportAddDescription_Input
    {
        public string signContent
        {
            get;
            set;
        }
        public ParticipationFreeDrugReportNewFormViewModel viewModel { get; set; }
    }

    public class SendSignedReportAddDiagnosis_Input
    {
        public string signContent
        {
            get;
            set;
        }
        public ParticipationFreeDrugReportNewFormViewModel viewModel { get; set; }

    }

    public class SendSignedReportAddTeshis_Input
    {
        public List<Controllers.ParticipatnFreeDrugReportServiceController.TeshisImzalanacakXml> signContentList;

        public ParticipationFreeDrugReportNewFormViewModel viewModel { get; set; }
    }

    public class SendSignedReportAddEtkinMadde_Input
    {
        public string signContent
        {
            get;
            set;
        }
        public ParticipationFreeDrugReportNewFormViewModel viewModel { get; set; }
    }

    public class SendSignedReportApproveModel
    {
        public string signContent
        {
            get;
            set;
        }
        public ParticipatnFreeDrugReport participatnFreeDrugReport { get; set; }
        public string medulaUsername { get; set; }
        public string medulaPassword { get; set; }
        public bool isSecondDoctorApprove = false;
        public bool isThirdDoctorApprove = false;
    }
    public class UserTemplateModel
    {
        public Guid? ObjectID { get; set; }
        public string Description { get; set; }            
        public Guid? TAObjectID { get; set; }
        public Guid? TAObjectDefID { get; set; }
    }
}