//$794814D5
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using System.ComponentModel;
using Core.Services;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using Core.Security;

namespace Core.Controllers
{
    public partial class MedulaTreatmentReportServiceController
    {
        [HttpPost]
        public MedulaTedaviRaporlariViewModel MedulaTreatmentReportEmpty(ActiveIDsModel activeIDsModel)
        {
            var formDefID = Guid.Parse("122e4177-adec-4e2d-af68-7cfaef9780b1");
            var objectDefID = Guid.Parse("6042e3e7-271a-4c63-b3d1-877c5a37e92c");
            var viewModel = new MedulaTedaviRaporlariViewModel();
            viewModel.ActiveIDsModel = activeIDsModel;
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MedulaTreatmentReport = new MedulaTreatmentReport(objectContext);

                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MedulaTreatmentReport, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedulaTreatmentReport, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MedulaTreatmentReport);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MedulaTreatmentReport);

                ContextToViewModel(viewModel, objectContext);

                PreScript_MedulaTedaviRaporlari(viewModel, viewModel._MedulaTreatmentReport, objectContext);

                viewModel.ToState = MedulaTreatmentReport.States.New;
                viewModel._MedulaTreatmentReport.CurrentStateDefID = MedulaTreatmentReport.States.New;

                if (viewModel._MedulaTreatmentReport.ProcedureDoctor == null)
                {
                    viewModel._MedulaTreatmentReport.ProcedureDoctor = Common.CurrentResource;
                }

                ContextToViewModel(viewModel, objectContext);

                objectContext.FullPartialllyLoadedObjects();
            }

            return viewModel;
        }

        [HttpPost]
        public MedulaTedaviRaporlariViewModel MedulaTreatmentReportPre(FormLoadInput input)
        {
            var formDefID = Guid.Parse("122e4177-adec-4e2d-af68-7cfaef9780b1");
            var objectDefID = Guid.Parse("6042e3e7-271a-4c63-b3d1-877c5a37e92c");
            var viewModel = new MedulaTedaviRaporlariViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (input.Id.HasValue && input.Id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._MedulaTreatmentReport = objectContext.GetObject(input.Id.Value, objectDefID) as MedulaTreatmentReport;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MedulaTreatmentReport, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedulaTreatmentReport, formDefID);
                    objectContext.LoadFormObjects(formDefID, input.Id.Value, objectDefID);
                    PreScript_MedulaTedaviRaporlari(viewModel, viewModel._MedulaTreatmentReport, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }


        partial void PreScript_MedulaTedaviRaporlari(MedulaTedaviRaporlariViewModel viewModel, MedulaTreatmentReport medulaTreatmentReport, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            EpisodeAction episodeAction = medulaTreatmentReport.ObjectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
            viewModel.TaniGridList.Clear();
            foreach (DiagnosisGrid diagnosis in episodeAction.SubEpisode.Diagnosis)
            {
                TaniGridListModel tani = new TaniGridListModel();
                tani.Tani = diagnosis.DiagnoseCode + " - " + (diagnosis.Diagnose != null ? diagnosis.Diagnose.Name : null);
                tani.TaniKodu = diagnosis.Diagnose != null ? diagnosis.Diagnose.Code : null;
                tani.FTRTaniGrup = (diagnosis.Diagnose != null && diagnosis.Diagnose.FtrDiagnoseGroup != null) ? Common.GetDisplayTextOfEnumValue("FTRDiagnosisGroupEnum", Convert.ToInt32(diagnosis.Diagnose.FtrDiagnoseGroup.Value)) : null;
                viewModel.TaniGridList.Add(tani);
            }

            if (selectedEpisodeActionObjectID.HasValue && viewModel._MedulaTreatmentReport.MasterAction == null)
            {
                // EpisodeAction episodeAction = medulaTreatmentReport.ObjectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                viewModel._MedulaTreatmentReport.MasterAction = episodeAction;
                viewModel._MedulaTreatmentReport.MasterResource = episodeAction.MasterResource;
                viewModel._MedulaTreatmentReport.FromResource = episodeAction.MasterResource;
                viewModel._MedulaTreatmentReport.Episode = episodeAction.Episode;
                var P = viewModel._MedulaTreatmentReport.Episode.Patient; //Contexe patient ı yüklemediği için yazıldı silmeyin   
                viewModel._MedulaTreatmentReport.ProcedureDoctor = episodeAction.ProcedureDoctor;
                viewModel._MedulaTreatmentReport.SubEpisode = episodeAction.SubEpisode;
                viewModel._MedulaTreatmentReport.ActionDate = System.DateTime.Now;
                /*if (episodeAction is InPatientPhysicianApplication)
                {
                    if (((InPatientPhysicianApplication)episodeAction).SubEpisode.InpatientAdmission != null)
                    {
                        //viewModel._MedulaTreatmentReport.StartDate = ((InPatientPhysicianApplication)episodeAction).SubEpisode.InpatientAdmission.HospitalInPatientDate;
                        viewModel.minReportDate = ((DateTime)((InPatientPhysicianApplication)episodeAction).SubEpisode.InpatientAdmission.HospitalInPatientDate).ToString("MM.dd.yyyy");
                    }
                }*/
                //if (episodeAction is PatientExamination)
                //    viewModel._MedulaTreatmentReport.ExaminationDate = ((PatientExamination)episodeAction).ProcessDate;
                //else
                //    viewModel._MedulaTreatmentReport.ExaminationDate = episodeAction.ActionDate;


                if (episodeAction.SubEpisode.SGKSEP != null)
                    viewModel.patientExisting = true;
                viewModel.Patient = episodeAction.Episode.Patient;
                // viewModel.Tabip = episodeAction.ProcedureDoctor;


                if (((ITTObject)medulaTreatmentReport).IsNew && episodeAction.SubEpisode.SGKSEP != null)
                    viewModel.HistoryPatientAdmission = SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport("WHERE CURRENTSTATEDEFID <> STATES.CANCELLED AND THIS.OBJECTID ='" + episodeAction.SubEpisode.SGKSEP.ObjectID.ToString() + "'").ToList();
            }
            else
            {
                if (((ITTObject)medulaTreatmentReport).IsNew == false)
                {
                    if (medulaTreatmentReport.SEPObjectID != null)
                    {
                        SubEpisodeProtocol subEpisodeProtocol = medulaTreatmentReport.ObjectContext.GetObject<SubEpisodeProtocol>(medulaTreatmentReport.SEPObjectID.Value);
                        HastaAktifTakipleriListModel takip = new HastaAktifTakipleriListModel();
                        takip.TakipNo = subEpisodeProtocol.MedulaTakipNo;
                        takip.BagliTakipNo = subEpisodeProtocol.ParentSEP != null ? subEpisodeProtocol.ParentSEP.MedulaTakipNo : null;
                        takip.Brans = subEpisodeProtocol.Brans.Name;
                        takip.BransKodu = subEpisodeProtocol.Brans.Code;
                        takip.HProtocolNo = subEpisodeProtocol.SubEpisode.Episode.HospitalProtocolNo.ToString();
                        takip.ProvizyonTarihi = (DateTime)subEpisodeProtocol.SubEpisode.PatientAdmission.ActionDate;
                        takip.TedaviTuru = subEpisodeProtocol.MedulaTedaviTuru.tedaviTuruAdi;
                        takip.VakaAcilisTarihi = (DateTime)subEpisodeProtocol.SubEpisode.Episode.OpeningDate;
                        takip.SubEpisode = subEpisodeProtocol.ObjectID;
                        takip.EAObjectId = subEpisodeProtocol.SubEpisode.StarterEpisodeAction.ObjectID;
                        viewModel.HastaAktifTakipleriList.Add(takip);
                        viewModel.SelectedTakip = takip;

                        HastaAktifTumTakipleriListModel takip2 = new HastaAktifTumTakipleriListModel();
                        takip2.TakipNo = subEpisodeProtocol.MedulaTakipNo;
                        takip2.BagliTakipNo = subEpisodeProtocol.ParentSEP != null ? subEpisodeProtocol.ParentSEP.MedulaTakipNo : null;
                        takip2.Brans = subEpisodeProtocol.Brans.Name;
                        takip2.BransKodu = subEpisodeProtocol.Brans.Code;
                        takip2.HProtocolNo = subEpisodeProtocol.SubEpisode.Episode.HospitalProtocolNo.ToString();
                        takip2.ProvizyonTarihi = (DateTime)subEpisodeProtocol.SubEpisode.PatientAdmission.ActionDate;
                        takip2.TedaviTuru = subEpisodeProtocol.MedulaTedaviTuru.tedaviTuruAdi;
                        takip2.VakaAcilisTarihi = (DateTime)subEpisodeProtocol.SubEpisode.Episode.OpeningDate;
                        takip2.SubEpisode = subEpisodeProtocol.ObjectID;
                        takip2.EAObjectId = subEpisodeProtocol.SubEpisode.StarterEpisodeAction.ObjectID;
                        viewModel.HastaAktifTumTakipleriList.Add(takip2);

                        viewModel.patientExisting = true;
                        //viewModel.Patient = medulaTreatmentReport.Episode.Patient;
                    }
                    else
                        viewModel.patientExisting = false;
                }
                if (medulaTreatmentReport.Episode != null)
                {
                    //viewModel.patientExisting = true;
                    viewModel.Patient = medulaTreatmentReport.Episode.Patient;
                }
                //else
                //viewModel.patientExisting = false;

            }

            //tanı kontrolü
            medulaTreatmentReport.CheckForDiagnosis();
            //if (medulaTreatmentReport.Episode != null && ((ITTObject)medulaTreatmentReport).IsNew == false && medulaTreatmentReport.SubEpisode != null && medulaTreatmentReport.SubEpisode.IsInvoicedSEPExists)
            //    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25840", "Hastanın faturası kesilmiştir, Rapor yazamazsınız!"));

            if (viewModel.patientExisting)
                viewModel.IsPatientSGK = true;
            else
                viewModel.IsPatientSGK = false;
            if (((ITTObject)medulaTreatmentReport).IsNew)
                viewModel.IsNew = true;
            else
                viewModel.IsNew = false;
            if (viewModel._MedulaTreatmentReport.StartDate == null)
                viewModel._MedulaTreatmentReport.StartDate = DateTime.Now;
            if (viewModel._MedulaTreatmentReport.EndDate == null)
                viewModel._MedulaTreatmentReport.EndDate = DateTime.Now.AddYears(1);
            if (viewModel._MedulaTreatmentReport.Duration == null)
                viewModel._MedulaTreatmentReport.Duration = 1;
            if (viewModel._MedulaTreatmentReport.DurationType == null)
                viewModel._MedulaTreatmentReport.DurationType = PeriodUnitTypeEnum.YearPeriod;

            if (viewModel._MedulaTreatmentReport.MasterAction is InPatientPhysicianApplication)
            {
                if (((InPatientPhysicianApplication)viewModel._MedulaTreatmentReport.MasterAction).SubEpisode.InpatientAdmission != null)
                {
                    //viewModel._MedulaTreatmentReport.StartDate = ((InPatientPhysicianApplication)episodeAction).SubEpisode.InpatientAdmission.HospitalInPatientDate;
                    viewModel.minReportDate = ((DateTime)((InPatientPhysicianApplication)viewModel._MedulaTreatmentReport.MasterAction).SubEpisode.InpatientAdmission.HospitalInPatientDate).ToString("MM.dd.yyyy");
                }
            }
            else
            {
                viewModel.minReportDate = Common.RecTime().ToString("MM.dd.yyyy");
            }
            
            viewModel.maxReportDate = Common.RecTime().ToString("MM.dd.yyyy");


            if (viewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTR || viewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTRTRAFIKKAZASI)
            {
                if (viewModel._MedulaTreatmentReport.FTRReport != null && viewModel._MedulaTreatmentReport.FTRReport.FTRReportDetailGrid.Count > 0)
                {
                    viewModel.FizyoterapiIslemleriList = new List<FizyoterapiIslemleriListModel>();
                    foreach (FTRReportDetailGrid fTRReportDetail in viewModel._MedulaTreatmentReport.FTRReport.FTRReportDetailGrid)
                    {
                        FizyoterapiIslemleriListModel fizyoterapiIslemi = new FizyoterapiIslemleriListModel();
                        fizyoterapiIslemi.ObjectID = fTRReportDetail.ObjectID;
                        if (fTRReportDetail.TedaviRaporiIslemKodlari != null)
                            fizyoterapiIslemi.FizyoterapiIslemi = fTRReportDetail.TedaviRaporiIslemKodlari.ObjectID;
                        if (fTRReportDetail.FTRVucutBolgesi != null)
                            fizyoterapiIslemi.VucutBolgesi = fTRReportDetail.FTRVucutBolgesi.ObjectID;
                        fizyoterapiIslemi.SeansSayisi = fTRReportDetail.NumberOfSessions != null ? Convert.ToInt32(fTRReportDetail.NumberOfSessions) : 0;
                        if (fTRReportDetail.TedaviTuru != null)
                            fizyoterapiIslemi.TedaviTuru = fTRReportDetail.TedaviTuru.ObjectID;

                        viewModel.FizyoterapiIslemleriList.Add(fizyoterapiIslemi);
                    }
                }
            }
            else if (viewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.ESWT)
            {
                if (viewModel._MedulaTreatmentReport.ESWTReport != null && viewModel._MedulaTreatmentReport.ESWTReport.ESWTReportDetailGrid.Count > 0)
                {
                    viewModel.ESWTIslemleriList = new List<ESWTIslemleriListModel>();
                    foreach (ESWTReportDetailGrid eSWTReportDetail in viewModel._MedulaTreatmentReport.ESWTReport.ESWTReportDetailGrid)
                    {
                        ESWTIslemleriListModel eswtIslemi = new ESWTIslemleriListModel();
                        eswtIslemi.ObjectID = eSWTReportDetail.ObjectID;
                        if (eSWTReportDetail.TedaviRaporiIslemKodlari != null)
                            eswtIslemi.FizyoterapiIslemiESWT = eSWTReportDetail.TedaviRaporiIslemKodlari.ObjectID;
                        if (eSWTReportDetail.FTRVucutBolgesi != null)
                            eswtIslemi.VucutBolgesiESWT = eSWTReportDetail.FTRVucutBolgesi.ObjectID;
                        eswtIslemi.SeansSayisiESWT = eSWTReportDetail.NumberOfSessions != null ? Convert.ToInt32(eSWTReportDetail.NumberOfSessions) : 0;

                        viewModel.ESWTIslemleriList.Add(eswtIslemi);
                    }
                }
            }
            else if (viewModel._MedulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.ESWL)
            {
                if (viewModel._MedulaTreatmentReport.ESWLReport != null && viewModel._MedulaTreatmentReport.ESWLReport.ESWLReportDetailGrid.Count > 0)
                {
                    viewModel.ESWTIslemleriList = new List<ESWTIslemleriListModel>();
                    foreach (ESWLReportDetailGrid eSWLReportDetail in viewModel._MedulaTreatmentReport.ESWLReport.ESWLReportDetailGrid)
                    {
                        TasBilgisiIslemleriListModel eswlIslemi = new TasBilgisiIslemleriListModel();
                        eswlIslemi.ObjectID = eSWLReportDetail.ObjectID;
                        if (eSWLReportDetail.TasLokalizasyon != null)
                            eswlIslemi.Lokalizasyon = eSWLReportDetail.TasLokalizasyon.ObjectID;
                        eswlIslemi.LokalizasyonKodu = eSWLReportDetail.TasLokalizasyon.tasLokalizasyonKodu != null ? Convert.ToInt32(eSWLReportDetail.TasLokalizasyon.tasLokalizasyonKodu) : 0;
                        eswlIslemi.TasBoyutu = eSWLReportDetail.StoneSize != null ? Convert.ToInt32(eSWLReportDetail.StoneSize) : 0;

                        viewModel.TasBilgisiIslemleriList.Add(eswlIslemi);
                    }
                }
            }

            if (viewModel._MedulaTreatmentReport.SEP != null && viewModel._MedulaTreatmentReport.SEP.MedulaTedaviTipi != null)
                viewModel.TedaviTipi = viewModel._MedulaTreatmentReport.SEP.MedulaTedaviTipi.tedaviTipiKodu;


            if (viewModel._MedulaTreatmentReport.SEP != null && viewModel._MedulaTreatmentReport.SEP.MedulaTedaviTuru != null)
                viewModel.TedaviTuru = viewModel._MedulaTreatmentReport.SEP.MedulaTedaviTuru.ObjectID.ToString();
            viewModel.willSendToMedula = false;
            ContextToViewModel(viewModel, objectContext);

        }

        partial void PostScript_MedulaTedaviRaporlari(MedulaTedaviRaporlariViewModel viewModel, MedulaTreatmentReport medulaTreatmentReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {

            if (medulaTreatmentReport.ProcedureDoctor != null && medulaTreatmentReport.CommitteeReport == true)
            {
                if (medulaTreatmentReport.ProcedureDoctor.ObjectID == medulaTreatmentReport.SecondDoctor.ObjectID)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M30211", "1.Doktor ve 2.Doktor aynı kişiler olamaz."));
                if (medulaTreatmentReport.ProcedureDoctor.ObjectID == medulaTreatmentReport.ThirdDoctor.ObjectID)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M30212", "1.Doktor ve 3.Doktor aynı kişiler olamaz."));
                if (medulaTreatmentReport.ThirdDoctor.ObjectID == medulaTreatmentReport.SecondDoctor.ObjectID)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M30213", "2.Doktor ve3.Doktor aynı kişiler olamaz."));
            }

            if (medulaTreatmentReport.ProcedureByUser == null)//rapru ilk oluşturan kişi
            {
                medulaTreatmentReport.ProcedureByUser = Common.CurrentResource;
            }

            medulaTreatmentReport.PatientObjectID = viewModel.Patient.ObjectID;
            medulaTreatmentReport.RaporGonderimTarihi = System.DateTime.Now;

            bool complete = false;

            if (viewModel.SelectedTakip != null)
                medulaTreatmentReport.SEPObjectID = viewModel.SelectedTakip.SubEpisode;
            else
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                EpisodeAction episodeAction = medulaTreatmentReport.ObjectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                if (episodeAction.SubEpisode != null)
                {
                    if (episodeAction.SubEpisode.SGKSEP != null)
                    {
                        if (!String.IsNullOrEmpty(episodeAction.SubEpisode.SGKSEP.MedulaTakipNo))
                        {
                            SubEpisodeProtocol subEpisodeProtocol = medulaTreatmentReport.ObjectContext.GetObject<SubEpisodeProtocol>(episodeAction.SubEpisode.SGKSEP.ObjectID);
                            HastaAktifTakipleriListModel takip = new HastaAktifTakipleriListModel();
                            takip.TakipNo = subEpisodeProtocol.MedulaTakipNo;
                            takip.BagliTakipNo = subEpisodeProtocol.ParentSEP != null ? subEpisodeProtocol.ParentSEP.MedulaTakipNo : null;
                            takip.Brans = subEpisodeProtocol.Brans.Name;
                            takip.BransKodu = subEpisodeProtocol.Brans.Code;
                            takip.HProtocolNo = subEpisodeProtocol.SubEpisode.Episode.HospitalProtocolNo.ToString();
                            takip.ProvizyonTarihi = (DateTime)subEpisodeProtocol.SubEpisode.PatientAdmission.ActionDate;
                            takip.TedaviTuru = subEpisodeProtocol.MedulaTedaviTuru.tedaviTuruAdi;
                            takip.VakaAcilisTarihi = (DateTime)subEpisodeProtocol.SubEpisode.Episode.OpeningDate;
                            takip.SubEpisode = subEpisodeProtocol.ObjectID;
                            takip.EAObjectId = subEpisodeProtocol.SubEpisode.StarterEpisodeAction.ObjectID;
                            viewModel.HastaAktifTakipleriList.Add(takip);
                            viewModel.SelectedTakip = takip;
                        }
                    }
                }
            }

            if (medulaTreatmentReport.SEPObjectID != null)
            {
                SubEpisodeProtocol subEpisodeProtocol = medulaTreatmentReport.ObjectContext.GetObject<SubEpisodeProtocol>(medulaTreatmentReport.SEPObjectID.Value);

                if (medulaTreatmentReport.MasterAction == null)
                {
                    // SubEpisodeProtocol subEpisodeProtocol = medulaTreatmentReport.ObjectContext.GetObject<SubEpisodeProtocol>(medulaTreatmentReport.SubEpisodeObjectId.Value);
                    medulaTreatmentReport.MasterAction = subEpisodeProtocol.SubEpisode.StarterEpisodeAction;
                    medulaTreatmentReport.MasterResource = subEpisodeProtocol.SubEpisode.StarterEpisodeAction.MasterResource;
                    medulaTreatmentReport.FromResource = subEpisodeProtocol.SubEpisode.StarterEpisodeAction.MasterResource;
                    medulaTreatmentReport.Episode = subEpisodeProtocol.Episode;
                    medulaTreatmentReport.SubEpisode = subEpisodeProtocol.SubEpisode;
                    medulaTreatmentReport.ActionDate = Common.RecTime();
                    viewModel.reportDiagnosisFormViewModel.episode = subEpisodeProtocol.Episode.ObjectID;
                }

                //Tedavi Tipi 'FİZİKSEL TEDAVİ VE REHABİLİTASYON' olan hastalara sadece FTR, FTR Trafik Kazası,ESWT ya da HBT raporu yazılabilir.
                if (subEpisodeProtocol != null && subEpisodeProtocol.MedulaTedaviTipi != null && subEpisodeProtocol.MedulaTedaviTipi.tedaviTipiKodu == "2" &&
                    !(medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTR || medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTRTRAFIKKAZASI || medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.ESWT || medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.HBT))
                {
                    throw new Exception("Tedavi Tipi 'FİZİKSEL TEDAVİ VE REHABİLİTASYON' olan hastalara sadece FTR, FTR Trafik Kazası,ESWT ya da HBT raporu yazılabilir.");
                }

            }
            if (viewModel.SelectedTakip != null)
            {
                complete = true;
                medulaTreatmentReport.IsSendedMedula = true;
            }
            ReportDiagnosisServiceController a = new ReportDiagnosisServiceController();
            a.SaveDiagnosis(viewModel.reportDiagnosisFormViewModel, medulaTreatmentReport);

            if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTR || medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTRTRAFIKKAZASI)
            {
                if (medulaTreatmentReport.FTRReport != null)
                {
                    if (((ITTObject)medulaTreatmentReport).IsNew == false && medulaTreatmentReport.FTRReport.FTRReportDetailGrid != null && medulaTreatmentReport.FTRReport.FTRReportDetailGrid.Count > 0)
                    {
                        List<FTRReportDetailGrid> tempFTRReportList = medulaTreatmentReport.FTRReport.FTRReportDetailGrid.ToList();

                        foreach (FTRReportDetailGrid item in tempFTRReportList)
                        {
                            FizyoterapiIslemleriListModel result = viewModel.FizyoterapiIslemleriList.Where(t => t.ObjectID == item.ObjectID).FirstOrDefault();
                            if (result == null)
                            {
                                FTRReportDetailGrid tempFTRReportDetail = medulaTreatmentReport.ObjectContext.GetObject<FTRReportDetailGrid>(item.ObjectID);
                                ((ITTObject)tempFTRReportDetail).Delete();
                            }
                        }
                    }
                }

                if (viewModel.FizyoterapiIslemleriList != null && viewModel.FizyoterapiIslemleriList.Count > 0)
                {
                    if (viewModel.FTRReports != null && viewModel.FTRReports.Length > 0)
                    {
                        if (medulaTreatmentReport.FTRReport == null)
                            medulaTreatmentReport.FTRReport = viewModel.FTRReports[0];
                        foreach (FizyoterapiIslemleriListModel fizyoterapiIslemi in viewModel.FizyoterapiIslemleriList)
                        {
                            bool var = false;
                            TedaviRaporiIslemKodlari tedaviRaporiIslemKodu = objectContext.GetObject(fizyoterapiIslemi.FizyoterapiIslemi, typeof(TedaviRaporiIslemKodlari)) as TedaviRaporiIslemKodlari;
                            TedaviTuru tedaviTuru = objectContext.GetObject(fizyoterapiIslemi.TedaviTuru, typeof(TedaviTuru)) as TedaviTuru;
                            FTRVucutBolgesi fTRVucutBolgesi = objectContext.GetObject(fizyoterapiIslemi.VucutBolgesi, typeof(FTRVucutBolgesi)) as FTRVucutBolgesi;
                            foreach (FTRReportDetailGrid item in medulaTreatmentReport.FTRReport.FTRReportDetailGrid)
                            {
                                if (fizyoterapiIslemi.ObjectID == item.ObjectID)
                                {
                                    item.TedaviRaporiIslemKodlari = tedaviRaporiIslemKodu;
                                    item.TedaviTuru = tedaviTuru;
                                    item.FTRVucutBolgesi = fTRVucutBolgesi;
                                    item.NumberOfSessions = fizyoterapiIslemi.SeansSayisi;
                                    var = true;
                                    break;
                                }
                            }

                            if (!var)
                            {
                                FTRReportDetailGrid fTRReportDetailGrid = new FTRReportDetailGrid(medulaTreatmentReport.ObjectContext);
                                fTRReportDetailGrid.TedaviRaporiIslemKodlari = tedaviRaporiIslemKodu; ;
                                fTRReportDetailGrid.TedaviTuru = tedaviTuru;
                                fTRReportDetailGrid.FTRVucutBolgesi = fTRVucutBolgesi;
                                fTRReportDetailGrid.NumberOfSessions = fizyoterapiIslemi.SeansSayisi;
                                medulaTreatmentReport.FTRReport.FTRReportDetailGrid.Add(fTRReportDetailGrid);
                            }
                        }
                        if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTRTRAFIKKAZASI)
                        {
                            medulaTreatmentReport.FTRReport.IsTrafficAccident = true;
                        }
                    }
                }
            }
            else if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.ESWT)
            {
                if (medulaTreatmentReport.ESWTReport != null)
                {
                    if (((ITTObject)medulaTreatmentReport).IsNew == false && medulaTreatmentReport.ESWTReport.ESWTReportDetailGrid != null && medulaTreatmentReport.ESWTReport.ESWTReportDetailGrid.Count > 0)
                    {
                        List<ESWTReportDetailGrid> tempESWTReportList = medulaTreatmentReport.ESWTReport.ESWTReportDetailGrid.ToList();

                        foreach (ESWTReportDetailGrid item in tempESWTReportList)
                        {
                            ESWTIslemleriListModel result = viewModel.ESWTIslemleriList.Where(t => t.ObjectID == item.ObjectID).FirstOrDefault();
                            if (result == null)
                            {
                                ESWTReportDetailGrid tempESWTReportDetail = medulaTreatmentReport.ObjectContext.GetObject<ESWTReportDetailGrid>(item.ObjectID);
                                ((ITTObject)tempESWTReportDetail).Delete();
                            }
                        }
                    }
                }
                if (viewModel.ESWTIslemleriList != null && viewModel.ESWTIslemleriList.Count > 0)
                {
                    if (viewModel.ESWTReports != null && viewModel.ESWTReports.Length > 0)
                    {
                        if (medulaTreatmentReport.ESWTReport == null)
                            medulaTreatmentReport.ESWTReport = viewModel.ESWTReports[0];
                        foreach (ESWTIslemleriListModel eSWTIslemleri in viewModel.ESWTIslemleriList)
                        {
                            bool var = false;
                            TedaviRaporiIslemKodlari tedaviRaporiIslemKodu = objectContext.GetObject(eSWTIslemleri.FizyoterapiIslemiESWT, typeof(TedaviRaporiIslemKodlari)) as TedaviRaporiIslemKodlari;
                            FTRVucutBolgesi fTRVucutBolgesi = objectContext.GetObject(eSWTIslemleri.VucutBolgesiESWT, typeof(FTRVucutBolgesi)) as FTRVucutBolgesi;
                            foreach (ESWTReportDetailGrid item in medulaTreatmentReport.ESWTReport.ESWTReportDetailGrid)
                            {
                                if (eSWTIslemleri.ObjectID == item.ObjectID)
                                {
                                    item.TedaviRaporiIslemKodlari = tedaviRaporiIslemKodu;
                                    item.FTRVucutBolgesi = fTRVucutBolgesi;
                                    item.NumberOfSessions = eSWTIslemleri.SeansSayisiESWT;
                                    var = true;
                                    break;
                                }
                            }

                            if (!var)
                            {
                                ESWTReportDetailGrid eSWTReportDetailGrid = new ESWTReportDetailGrid(medulaTreatmentReport.ObjectContext);
                                eSWTReportDetailGrid.TedaviRaporiIslemKodlari = tedaviRaporiIslemKodu;
                                eSWTReportDetailGrid.FTRVucutBolgesi = fTRVucutBolgesi;
                                eSWTReportDetailGrid.NumberOfSessions = eSWTIslemleri.SeansSayisiESWT;
                                medulaTreatmentReport.ESWTReport.ESWTReportDetailGrid.Add(eSWTReportDetailGrid);
                            }
                        }
                    }
                }
            }
            else if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.ESWL)
            {
                if (medulaTreatmentReport.ESWLReport != null)
                {
                    if (((ITTObject)medulaTreatmentReport).IsNew == false && medulaTreatmentReport.ESWLReport.ESWLReportDetailGrid != null && medulaTreatmentReport.ESWLReport.ESWLReportDetailGrid.Count > 0)
                    {
                        List<ESWLReportDetailGrid> tempESWLReportList = medulaTreatmentReport.ESWLReport.ESWLReportDetailGrid.ToList();

                        foreach (ESWLReportDetailGrid item in tempESWLReportList)
                        {
                            TasBilgisiIslemleriListModel result = viewModel.TasBilgisiIslemleriList.Where(t => t.ObjectID == item.ObjectID).FirstOrDefault();
                            if (result == null)
                            {
                                ESWLReportDetailGrid tempESWLReportDetail = medulaTreatmentReport.ObjectContext.GetObject<ESWLReportDetailGrid>(item.ObjectID);
                                ((ITTObject)tempESWLReportDetail).Delete();
                            }
                        }
                    }
                }
                if (viewModel.TasBilgisiIslemleriList != null && viewModel.TasBilgisiIslemleriList.Count > 0)
                {
                    if (viewModel.ESWLReports != null && viewModel.ESWLReports.Length > 0)
                    {
                        if (medulaTreatmentReport.ESWLReport == null)
                            medulaTreatmentReport.ESWLReport = viewModel.ESWLReports[0];
                        foreach (TasBilgisiIslemleriListModel tasBilgisiIslemleri in viewModel.TasBilgisiIslemleriList)
                        {
                            bool var = false;
                            TasLokalizasyon tasLokalizasyon = objectContext.GetObject(tasBilgisiIslemleri.Lokalizasyon, typeof(TasLokalizasyon)) as TasLokalizasyon;
                            foreach (ESWLReportDetailGrid item in medulaTreatmentReport.ESWLReport.ESWLReportDetailGrid)
                            {
                                if (tasBilgisiIslemleri.ObjectID == item.ObjectID)
                                {
                                    item.TasLokalizasyon = tasLokalizasyon;
                                    item.StoneSize = tasBilgisiIslemleri.TasBoyutu;
                                    var = true;
                                    break;
                                }
                            }

                            if (!var)
                            {
                                ESWLReportDetailGrid eSWLReportDetailGrid = new ESWLReportDetailGrid(medulaTreatmentReport.ObjectContext);
                                eSWLReportDetailGrid.TasLokalizasyon = tasLokalizasyon;
                                eSWLReportDetailGrid.StoneSize = tasBilgisiIslemleri.TasBoyutu;
                                medulaTreatmentReport.ESWLReport.ESWLReportDetailGrid.Add(eSWLReportDetailGrid);
                            }
                        }
                    }
                }
            }
            else if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.HBT)
            {
                if (medulaTreatmentReport.HBTReport == null)
                    medulaTreatmentReport.HBTReport = viewModel.HBTReports[0];
            }
            else if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.TUPBEBEK)
            {
                if (medulaTreatmentReport.TubeBabyReport == null)
                    medulaTreatmentReport.TubeBabyReport = viewModel.TubeBabyReports[0];
            }
            else if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.DIYALIZ)
            {
                if (medulaTreatmentReport.DialysisReport == null)
                    medulaTreatmentReport.DialysisReport = viewModel.DialysisReports[0];
            }
            else if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.EVHEMODIYALIZI)
            {
                if (medulaTreatmentReport.HomeHemodialysisReport == null)
                    medulaTreatmentReport.HomeHemodialysisReport = viewModel.HomeHemodialysisReports[0];
            }

            if (medulaTreatmentReport.ReportNo == null || medulaTreatmentReport.ReportNo == "0")
            {
                long value = 0;

                if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTR || medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.ESWT || medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTRTRAFIKKAZASI)
                    value = TTSequence.GetNextSequenceValueFromDatabase(TTDefinitionManagement.TTObjectDefManager.Instance.DataTypes["FTRRaporSequence"], null, null);
                if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.ESWL)
                    value = TTSequence.GetNextSequenceValueFromDatabase(TTDefinitionManagement.TTObjectDefManager.Instance.DataTypes["TasKirmaRaporSequence"], null, null);
                if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.DIYALIZ || medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.EVHEMODIYALIZI)
                    value = TTSequence.GetNextSequenceValueFromDatabase(TTDefinitionManagement.TTObjectDefManager.Instance.DataTypes["DiyalizRaporSequence"], null, null);
                if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.TUPBEBEK)
                    value = TTSequence.GetNextSequenceValueFromDatabase(TTDefinitionManagement.TTObjectDefManager.Instance.DataTypes["TupBebekRaporSequence"], null, null);
                if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.HBT)
                    value = TTSequence.GetNextSequenceValueFromDatabase(TTDefinitionManagement.TTObjectDefManager.Instance.DataTypes["HOTRaporSequence"], null, null);
                medulaTreatmentReport.ReportNo = value.ToString();
            }

            objectContext.Update();


            if (complete && viewModel.willSendToMedula == true)
            {
                RaporIslemleri.raporCevapDVO response = this.TakipNoileRaporBilgisiKaydet(viewModel, medulaTreatmentReport, objectContext);
                string cevap = null;
                if (response != null)
                {
                    if (response.sonucKodu.Equals(0))
                        cevap += "Takip No: " + response.raporTakipNo.ToString();
                    cevap += "Açıklama : ";
                    cevap += response.sonucKodu + " " + response.sonucAciklamasi;
                    TTUtils.InfoMessageService.Instance.ShowMessage(cevap);
                }
            }
            else
            {
                medulaTreatmentReport.CurrentStateDefID = MedulaTreatmentReport.States.Saved;
                viewModel._MedulaTreatmentReport = medulaTreatmentReport;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Medula_Raporlari_Hasta_Kabulleri_Getir)]
        public List<SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport_Class> FillPatientAdmissionHistory(Patient patient)
        {
            List<Guid> patientObjectIDs = new List<Guid>();
            patientObjectIDs.Add(patient.ObjectID);
            string filterExpression = Common.CreateFilterExpressionOfGuidList(null, "THIS:PATIENTADMISSION:EPISODE:PATIENT", patientObjectIDs);
            List<SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport_Class> admissions; ;
            admissions = SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport("WHERE CURRENTSTATEDEFID <> STATES.CANCELLED AND " + filterExpression).ToList();
            return admissions;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Medula_Raporlari_Takip_No_ile_Kaydet)]
        public RaporIslemleri.raporCevapDVO TakipNoileRaporBilgisiKaydet(MedulaTedaviRaporlariViewModel viewModel, MedulaTreatmentReport medulaTreatmentReport, TTObjectContext objectContext)
        {
            try
            {
                //var medulaTreatmentReportImported = (MedulaTreatmentReport)objectContext.AddObject(viewModel._MedulaTreatmentReport);
                RaporIslemleri.raporGirisDVO raporGirisDVO = new RaporIslemleri.raporGirisDVO();
                RaporIslemleri.tedaviRaporDVO tedaviRaporDVO = new RaporIslemleri.tedaviRaporDVO();
                RaporIslemleri.raporDVO _raporDVO = new RaporIslemleri.raporDVO();
                //  string tedaviTuru = string.Empty;
                raporGirisDVO.isgoremezlikRapor = null;
                //TODO : MEDULA20140501
                raporGirisDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                raporGirisDVO.ilacRapor = null;
                if (medulaTreatmentReport.Description != null)
                    _raporDVO.aciklama = medulaTreatmentReport.Description.ToString();
                if (medulaTreatmentReport.StartDate != null)
                    _raporDVO.baslangicTarihi = ((DateTime)medulaTreatmentReport.StartDate).ToString("dd.MM.yyyy"); //viewModel.RaporBaslangicTarihi.ToString("dd.MM.yyyy");
                if (medulaTreatmentReport.EndDate != null)
                    _raporDVO.bitisTarihi = ((DateTime)medulaTreatmentReport.EndDate).ToString("dd.MM.yyyy");
                _raporDVO.durum = "";
                if (medulaTreatmentReport.FTRReport == null || medulaTreatmentReport.FTRReport.SpacialCase == null)
                    _raporDVO.ozelDurum = 0;
                else
                {
                    //14.02.2018 tarihinde güncellenen medula kullanım kılavuzuna göre daha öncesinde "2" olarak gönderilen özel durum "3" olarak değiştirilmiştir.                  
                    if (Convert.ToInt32(medulaTreatmentReport.FTRReport.SpacialCase.Value) == 2)
                        _raporDVO.ozelDurum = 3;
                    else
                        _raporDVO.ozelDurum = Convert.ToInt32(medulaTreatmentReport.FTRReport.SpacialCase.Value);

                }

                if ((medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.HBT && medulaTreatmentReport.CommitteeReport == true) || medulaTreatmentReport.CommitteeReport == true)
                    _raporDVO.duzenlemeTuru = "1";
                else
                    _raporDVO.duzenlemeTuru = "2";
                _raporDVO.klinikTani = "";
                _raporDVO.turu = "1";
                List<RaporIslemleri.taniBilgisiDVO> taniBilgisiDVOList = new List<RaporIslemleri.taniBilgisiDVO>();
                // TTObjectContext context = new TTObjectContext(true);
                List<string> taniList = new List<string>();
                if (viewModel.reportDiagnosisFormViewModel != null)
                {
                    if (viewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList.Count == 0)
                    {
                        Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                        EpisodeAction episodeAction = medulaTreatmentReport.ObjectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);

                        foreach (DiagnosisGrid diagnosis in episodeAction.SubEpisode.Diagnosis)
                        {

                            TaniGridListModel tani = new TaniGridListModel();
                            tani.TaniKodu = diagnosis.Diagnose != null ? diagnosis.Diagnose.Code : null;
                            taniList.Add(tani.TaniKodu);
                        }
                        /* ReportDiagnosisServiceController a = new ReportDiagnosisServiceController();
                         a.SaveDiagnosis(viewModel.reportDiagnosisFormViewModel, medulaTreatmentReport);*/
                    }
                    else
                    {
                        foreach (ReportDiagnosisGridListViewModel item in viewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList)
                        {
                            taniList.Add(item.DiagnoseCode);
                        }
                    }


                    taniList = Common.DiagnosesForMedula(taniList);
                    foreach (string taniItem in taniList)
                    {
                        RaporIslemleri.taniBilgisiDVO taniBilgisiDVO = new RaporIslemleri.taniBilgisiDVO();
                        taniBilgisiDVO.taniKodu = taniItem;
                        taniBilgisiDVOList.Add(taniBilgisiDVO);
                    }

                    _raporDVO.tanilar = taniBilgisiDVOList.ToArray();
                }
                if (viewModel.SelectedTakip != null)
                {
                    _raporDVO.protokolNo = viewModel.SelectedTakip.HProtocolNo;
                    _raporDVO.protokolTarihi = viewModel.SelectedTakip.ProvizyonTarihi != null ? viewModel.SelectedTakip.ProvizyonTarihi.ToString("dd.MM.yyyy") : null;
                    _raporDVO.takipNo = viewModel.SelectedTakip.TakipNo;
                    // tedaviTuru = selectedRow.Cells[7].Value.ToString();
                }

                List<RaporIslemleri.doktorBilgisiDVO> _doktorBilgisiDVOList = new List<RaporIslemleri.doktorBilgisiDVO>();
                RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO = new RaporIslemleri.doktorBilgisiDVO();
                ResUser tabip = medulaTreatmentReport.ProcedureDoctor;//(ResUser)objectContext.GetObject((Guid)viewModel._MedulaTreatmentReport.ProcedureDoctor.ObjectID, typeof (ResUser));
                _doktorBilgisiDVO.drAdi = tabip.Person != null ? tabip.Person.Name : "";
                _doktorBilgisiDVO.drBransKodu = tabip.GetSpeciality() != null ? tabip.GetSpeciality().Code : "";
                _doktorBilgisiDVO.drSoyadi = tabip.Person != null ? tabip.Person.Surname : "";
                _doktorBilgisiDVO.drTescilNo = tabip.DiplomaRegisterNo;
                if (tabip.UserType != null && tabip.UserType == UserTypeEnum.Dentist)
                    _doktorBilgisiDVO.tipi = "2";
                else
                    _doktorBilgisiDVO.tipi = "1";
                _doktorBilgisiDVOList.Add(_doktorBilgisiDVO);
                if ((medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.HBT && medulaTreatmentReport.CommitteeReport == true) || medulaTreatmentReport.CommitteeReport == true)
                {
                    RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO2 = new RaporIslemleri.doktorBilgisiDVO();
                    ResUser tabip2 = medulaTreatmentReport.SecondDoctor;// (ResUser)objectContext.GetObject((Guid)viewModel._MedulaTreatmentReport.SecondDoctor.ObjectID, typeof(ResUser));
                    _doktorBilgisiDVO2.drAdi = tabip2.Person != null ? tabip2.Name : "";
                    _doktorBilgisiDVO2.drBransKodu = tabip2.GetSpeciality() != null ? tabip2.GetSpeciality().Code : "";
                    _doktorBilgisiDVO2.drSoyadi = tabip2.Person != null ? tabip2.Person.Surname : "";
                    _doktorBilgisiDVO2.drTescilNo = tabip2.DiplomaRegisterNo;
                    if (tabip2.UserType != null && tabip2.UserType == UserTypeEnum.Dentist)
                        _doktorBilgisiDVO2.tipi = "2";
                    else
                        _doktorBilgisiDVO2.tipi = "1";
                    _doktorBilgisiDVOList.Add(_doktorBilgisiDVO2);
                    RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO3 = new RaporIslemleri.doktorBilgisiDVO();
                    ResUser tabip3 = medulaTreatmentReport.ThirdDoctor;//(ResUser)objectContext.GetObject((Guid)viewModel._MedulaTreatmentReport.ThirdDoctor.ObjectID, typeof(ResUser));
                    _doktorBilgisiDVO3.drAdi = tabip3.Person != null ? tabip3.Person.Name : "";
                    _doktorBilgisiDVO3.drBransKodu = tabip3.GetSpeciality() != null ? tabip3.GetSpeciality().Code : "";
                    _doktorBilgisiDVO3.drSoyadi = tabip3.Person != null ? tabip3.Person.Surname : "";
                    _doktorBilgisiDVO3.drTescilNo = tabip3.DiplomaRegisterNo;
                    if (tabip3.UserType != null && tabip3.UserType == UserTypeEnum.Dentist)
                        _doktorBilgisiDVO3.tipi = "2";
                    else
                        _doktorBilgisiDVO3.tipi = "1";
                    _doktorBilgisiDVOList.Add(_doktorBilgisiDVO3);
                }

                _raporDVO.doktorlar = _doktorBilgisiDVOList.ToArray();
                _raporDVO.hakSahibi = null;

                RaporIslemleri.raporBilgisiDVO raporBilgisiDVO = new RaporIslemleri.raporBilgisiDVO();
                raporBilgisiDVO.aVakaTKaza = 3;

                raporBilgisiDVO.no = medulaTreatmentReport.ReportNo.ToString();
                raporBilgisiDVO.raporSiraNo = 0;
                raporBilgisiDVO.raporTakipNo = "";
                raporBilgisiDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                raporBilgisiDVO.tarih = medulaTreatmentReport.StartDate != null ? ((DateTime)medulaTreatmentReport.StartDate).ToString("dd.MM.yyyy") : null;
                _raporDVO.raporBilgisi = raporBilgisiDVO;
                tedaviRaporDVO.raporDVO = _raporDVO;
                List<RaporIslemleri.tedaviIslemBilgisiDVO> tedaviIslemBilgisiDVO = new List<RaporIslemleri.tedaviIslemBilgisiDVO>();
                RaporIslemleri.tedaviIslemBilgisiDVO tedaviIslemBilgisi = new RaporIslemleri.tedaviIslemBilgisiDVO();
                if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTR || medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTRTRAFIKKAZASI)
                {
                    if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.FTR)
                        tedaviRaporDVO.tedaviRaporTuru = 5;
                    else
                        tedaviRaporDVO.tedaviRaporTuru = 7;
                    foreach (FTRReportDetailGrid item in medulaTreatmentReport.FTRReport.FTRReportDetailGrid)
                    {
                        RaporIslemleri.ftrRaporBilgisiDVO fTRRaporBilgisiDVO = new RaporIslemleri.ftrRaporBilgisiDVO();
                        //TedaviRaporiIslemKodlari tedaviRaporiIslemKodlari = (TedaviRaporiIslemKodlari)objectContext.GetObject((Guid)item.TedaviRaporiIslemKodlari, typeof (TedaviRaporiIslemKodlari));
                        fTRRaporBilgisiDVO.butKodu = item.TedaviRaporiIslemKodlari != null ? item.TedaviRaporiIslemKodlari.TedaviRaporuIslemKodu : null;// tedaviRaporiIslemKodlari.TedaviRaporuIslemKodu;
                        fTRRaporBilgisiDVO.seansSayi = Convert.ToInt32(item.NumberOfSessions);
                        //FTRVucutBolgesi fTRVucutBolgesi = (FTRVucutBolgesi)objectContext.GetObject((Guid)item.FTRVucutBolgesi, typeof (FTRVucutBolgesi));
                        fTRRaporBilgisiDVO.ftrVucutBolgesiKodu = (item.FTRVucutBolgesi != null && item.FTRVucutBolgesi.ftrVucutBolgesiKodu != null) ? Convert.ToInt32(item.FTRVucutBolgesi.ftrVucutBolgesiKodu) : 0;//Convert.ToInt32(fTRVucutBolgesi.ftrVucutBolgesiKodu);
                        //  TimeSpan sp = Convert.ToDateTime(RaporBitisTarihi.NullableValue).Subtract(Convert.ToDateTime(RaporBaslangicTarihi.NullableValue));
                        int upperLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("TEDAVIRAPORUYILGUNSAYISI", "366"));
                        int totalDays = Convert.ToInt32((((DateTime)medulaTreatmentReport.EndDate) - ((DateTime)medulaTreatmentReport.StartDate)).TotalDays) + 1;
                        fTRRaporBilgisiDVO.seansGun = totalDays> upperLimit ? upperLimit : totalDays;
                        // TedaviTuru tedaviTuru = (TedaviTuru)objectContext.GetObject((Guid)item.TedaviTuru, typeof (TedaviTuru));
                        fTRRaporBilgisiDVO.tedaviTuru = item.TedaviTuru != null ? item.TedaviTuru.tedaviTuruKodu : null; // tedaviTuru.tedaviTuruKodu;
                        fTRRaporBilgisiDVO.robotikRehabilitasyon = ".";
                        tedaviIslemBilgisi.ftrRaporBilgisi = fTRRaporBilgisiDVO;
                        tedaviIslemBilgisiDVO.Add(tedaviIslemBilgisi);
                    }
                }

                if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.ESWT)
                {
                    tedaviRaporDVO.tedaviRaporTuru = 3;
                    foreach (ESWTReportDetailGrid item in medulaTreatmentReport.ESWTReport.ESWTReportDetailGrid)
                    {
                        RaporIslemleri.eswtRaporBilgisiDVO eSWTRaporBilgisiDVO = new RaporIslemleri.eswtRaporBilgisiDVO();
                        //TedaviRaporiIslemKodlari tedaviRaporiIslemKodlari = (TedaviRaporiIslemKodlari)objectContext.GetObject((Guid)item.TedaviRaporiIslemKodlari, typeof (TedaviRaporiIslemKodlari));
                        eSWTRaporBilgisiDVO.butKodu = item.TedaviRaporiIslemKodlari != null ? item.TedaviRaporiIslemKodlari.TedaviRaporuIslemKodu : null;
                        eSWTRaporBilgisiDVO.seansSayi = item.NumberOfSessions != null ? Convert.ToInt32(item.NumberOfSessions) : 0;
                        //  FTRVucutBolgesi eSWTVucutBolgesi = (FTRVucutBolgesi)objectContext.GetObject((Guid)item.VucutBolgesiESWT, typeof (FTRVucutBolgesi));
                        eSWTRaporBilgisiDVO.eswtVucutBolgesiKodu = (item.FTRVucutBolgesi != null && item.FTRVucutBolgesi.ftrVucutBolgesiKodu != null) ? Convert.ToInt32(item.FTRVucutBolgesi.ftrVucutBolgesiKodu) : 0;//Convert.ToInt32(eSWTVucutBolgesi.ftrVucutBolgesiKodu);
                        int upperLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("TEDAVIRAPORUYILGUNSAYISI", "366"));

                        int totalDays = Convert.ToInt32((((DateTime)medulaTreatmentReport.EndDate) - ((DateTime)medulaTreatmentReport.StartDate)).TotalDays) + 1;
                        eSWTRaporBilgisiDVO.seansGun = totalDays > upperLimit ? upperLimit : totalDays;
                       
                        //eSWTRaporBilgisiDVO.seansGun = Convert.ToInt32((((DateTime)medulaTreatmentReport.EndDate) - ((DateTime)medulaTreatmentReport.StartDate)).TotalDays) ;
                        tedaviIslemBilgisi.eswtRaporBilgisi = eSWTRaporBilgisiDVO;
                        tedaviIslemBilgisiDVO.Add(tedaviIslemBilgisi);
                    }
                }

                if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.ESWL)
                {
                    tedaviRaporDVO.tedaviRaporTuru = 6;
                    List<RaporIslemleri.eswlTasBilgisiDVO> eSWLTasBilgisiDVOList = new List<RaporIslemleri.eswlTasBilgisiDVO>();
                    RaporIslemleri.eswlRaporBilgisiDVO eSWLRaporBilgisiDVO = new RaporIslemleri.eswlRaporBilgisiDVO();
                    eSWLRaporBilgisiDVO.butKodu = medulaTreatmentReport.ESWLReport.TedaviRaporiIslemKodlari != null ? medulaTreatmentReport.ESWLReport.TedaviRaporiIslemKodlari.TedaviRaporuIslemKodu : null;
                    eSWLRaporBilgisiDVO.eswlRaporuSeansSayisi = medulaTreatmentReport.ESWLReport.NumberOfSessions != null ? Convert.ToInt32(medulaTreatmentReport.ESWLReport.NumberOfSessions) : 0;
                    eSWLRaporBilgisiDVO.eswlRaporuTasSayisi = medulaTreatmentReport.ESWLReport.NumberOfStone != null ? Convert.ToInt32(medulaTreatmentReport.ESWLReport.NumberOfStone) : 0;
                    eSWLRaporBilgisiDVO.bobrekBilgisi = (medulaTreatmentReport.ESWLReport.Bobrek != null && medulaTreatmentReport.ESWLReport.Bobrek.bobrekKodu != null) ? Convert.ToInt32(medulaTreatmentReport.ESWLReport.Bobrek.bobrekKodu) : 0;
                    foreach (ESWLReportDetailGrid tasBilgisi in medulaTreatmentReport.ESWLReport.ESWLReportDetailGrid)
                    {
                        RaporIslemleri.eswlTasBilgisiDVO eSWLTasBilgisiDVO = new RaporIslemleri.eswlTasBilgisiDVO();
                        eSWLTasBilgisiDVO.tasBoyutu = tasBilgisi.StoneSize != null ? tasBilgisi.StoneSize.ToString() : null;
                        eSWLTasBilgisiDVO.tasLokalizasyonKodu = (tasBilgisi.TasLokalizasyon != null && tasBilgisi.TasLokalizasyon.tasLokalizasyonKodu != null) ? Convert.ToInt32(tasBilgisi.TasLokalizasyon.tasLokalizasyonKodu.Value.ToString()) : 0;
                        eSWLTasBilgisiDVOList.Add(eSWLTasBilgisiDVO);
                    }

                    eSWLRaporBilgisiDVO.eswlRaporuTasBilgileri = eSWLTasBilgisiDVOList.ToArray();
                    tedaviIslemBilgisi.eswlRaporBilgisi = eSWLRaporBilgisiDVO;
                    tedaviIslemBilgisiDVO.Add(tedaviIslemBilgisi);
                }

                if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.DIYALIZ)
                {
                    if (medulaTreatmentReport.DialysisReport != null)
                    {
                        tedaviRaporDVO.tedaviRaporTuru = 1;
                        RaporIslemleri.diyalizRaporBilgisiDVO diyalizRaporBilgisiDVO = new RaporIslemleri.diyalizRaporBilgisiDVO();
                        diyalizRaporBilgisiDVO.refakatVarMi = medulaTreatmentReport.DialysisReport.IsCompanion == true ? "E" : "H";
                        diyalizRaporBilgisiDVO.butKodu = medulaTreatmentReport.DialysisReport.TedaviRaporiIslemKodlari != null ? medulaTreatmentReport.DialysisReport.TedaviRaporiIslemKodlari.TedaviRaporuIslemKodu : null;
                        diyalizRaporBilgisiDVO.seansSayi = medulaTreatmentReport.DialysisReport.NumberOfSessions != null ? Convert.ToInt32(medulaTreatmentReport.DialysisReport.NumberOfSessions) : 0;
                        diyalizRaporBilgisiDVO.seansGun = medulaTreatmentReport.DialysisReport.NumberOfSessions != null ? Convert.ToInt32(medulaTreatmentReport.DialysisReport.NumberOfSessions) : 0;
                        tedaviIslemBilgisi.diyalizRaporBilgisi = diyalizRaporBilgisiDVO;
                        tedaviIslemBilgisiDVO.Add(tedaviIslemBilgisi);
                    }
                }

                if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.EVHEMODIYALIZI)
                {
                    if (medulaTreatmentReport.HomeHemodialysisReport != null)
                    {
                        tedaviRaporDVO.tedaviRaporTuru = 8;
                        RaporIslemleri.evHemodiyaliziRaporBilgisiDVO evHemodiyaliziRaporBilgisiDVO = new RaporIslemleri.evHemodiyaliziRaporBilgisiDVO();
                        evHemodiyaliziRaporBilgisiDVO.butKodu = medulaTreatmentReport.HomeHemodialysisReport.TedaviRaporiIslemKodlari != null ? medulaTreatmentReport.HomeHemodialysisReport.TedaviRaporiIslemKodlari.TedaviRaporuIslemKodu : null;
                        evHemodiyaliziRaporBilgisiDVO.seansSayi = medulaTreatmentReport.HomeHemodialysisReport.NumberOfSessions != null ? Convert.ToInt32(medulaTreatmentReport.HomeHemodialysisReport.NumberOfSessions) : 0;
                        evHemodiyaliziRaporBilgisiDVO.seansGun = medulaTreatmentReport.HomeHemodialysisReport.NumberOfSessions != null ? Convert.ToInt32(medulaTreatmentReport.HomeHemodialysisReport.NumberOfSessions) : 0;
                        tedaviIslemBilgisi.evHemodiyaliziRaporBilgisi = evHemodiyaliziRaporBilgisiDVO;
                        tedaviIslemBilgisiDVO.Add(tedaviIslemBilgisi);
                    }
                }

                if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.HBT)
                {
                    if (medulaTreatmentReport.HBTReport != null)
                    {
                        tedaviRaporDVO.tedaviRaporTuru = 2;
                        RaporIslemleri.hotRaporBilgisiDVO hOTRaporBilgisiDVO = new RaporIslemleri.hotRaporBilgisiDVO();
                        int upperLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("TEDAVIRAPORUYILGUNSAYISI", "366"));

                        int totalDays = Convert.ToInt32((((DateTime)medulaTreatmentReport.EndDate) - ((DateTime)medulaTreatmentReport.StartDate)).TotalDays) + 1;
                        hOTRaporBilgisiDVO.seansGun = totalDays > upperLimit ? upperLimit : totalDays;
                        //hOTRaporBilgisiDVO.seansGun = Convert.ToInt32((((DateTime)medulaTreatmentReport.EndDate) - ((DateTime)medulaTreatmentReport.StartDate)).TotalDays) ;

                        hOTRaporBilgisiDVO.seansSayi = medulaTreatmentReport.HBTReport.NumberOfSessions != null ? Convert.ToInt32(medulaTreatmentReport.HBTReport.NumberOfSessions) : 0;
                        hOTRaporBilgisiDVO.tedaviSuresi = medulaTreatmentReport.HBTReport.TreatmenDuration != null ? Convert.ToInt32(medulaTreatmentReport.HBTReport.TreatmenDuration) : 0;
                        tedaviIslemBilgisi.hotRaporBilgisi = hOTRaporBilgisiDVO;
                        tedaviIslemBilgisiDVO.Add(tedaviIslemBilgisi);
                    }
                }

                if (medulaTreatmentReport.TedaviRaporTuru == TedaviRaporTuruEnum.TUPBEBEK)
                {
                    if (medulaTreatmentReport.TubeBabyReport != null)
                    {
                        tedaviRaporDVO.tedaviRaporTuru = 4;
                        RaporIslemleri.tupBebekRaporBilgisiDVO tupBebekRaporBilgisiDVO = new RaporIslemleri.tupBebekRaporBilgisiDVO();
                        tupBebekRaporBilgisiDVO.butKodu = medulaTreatmentReport.TubeBabyReport.TedaviRaporiIslemKodlari != null ? medulaTreatmentReport.TubeBabyReport.TedaviRaporiIslemKodlari.TedaviRaporuIslemKodu : null;
                        tupBebekRaporBilgisiDVO.tupBebekRaporTuru = medulaTreatmentReport.TubeBabyReport.TubeBabyReportType != null ? Convert.ToInt32(medulaTreatmentReport.TubeBabyReport.TubeBabyReportType) + 1 : 0;
                        tedaviIslemBilgisi.tupBebekRaporBilgisi = tupBebekRaporBilgisiDVO;
                        tedaviIslemBilgisiDVO.Add(tedaviIslemBilgisi);
                    }
                }

                tedaviRaporDVO.islemler = tedaviIslemBilgisiDVO.ToArray();
                raporGirisDVO.tedaviRapor = tedaviRaporDVO;
                RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.takipNoileRaporBilgisiKaydetSync(Sites.SiteLocalHost, raporGirisDVO);
                if (response != null)
                {
                    var b = TTUtils.SerializationHelper.XmlSerializeObject(raporGirisDVO);
                    var ab = TTUtils.SerializationHelper.XmlSerializeObject(response);

                    //medulaTreatmentReport.PatientObjectID = viewModel.Patient.ObjectID;
                    //medulaTreatmentReport.RaporGonderimTarihi = System.DateTime.Now;
                    medulaTreatmentReport.RaporTakipNo = response.raporTakipNo.ToString();
                    medulaTreatmentReport.SonucKodu = response.sonucKodu.ToString();
                    medulaTreatmentReport.SonucAciklamasi = response.sonucAciklamasi;
                    //medulaTreatmentReport.TedaviRaporTuru = viewModel.RaporTuru;
                    //medulaTreatmentReport.SubEpisodeObjectId = viewModel.SelectedTakip.SubEpisode;
                    medulaTreatmentReport.RaporGelenXML = TTUtils.SerializationHelper.XmlSerializeObject(response);
                    medulaTreatmentReport.RaporGidenXML = TTUtils.SerializationHelper.XmlSerializeObject(raporGirisDVO);
                    medulaTreatmentReport.IsSendedMedula = true;

                    ReportDiagnosisServiceController a = new ReportDiagnosisServiceController();
                    a.SaveDiagnosis(viewModel.reportDiagnosisFormViewModel, medulaTreatmentReport);
                    medulaTreatmentReport.CurrentStateDefID = MedulaTreatmentReport.States.New;
                    if (response.sonucKodu.Equals(0))
                    {
                        objectContext.Update();
                        medulaTreatmentReport.CurrentStateDefID = MedulaTreatmentReport.States.SendMedula;
                        objectContext.Update();
                        medulaTreatmentReport.CurrentStateDefID = MedulaTreatmentReport.States.Completed;
                        objectContext.Update();
                    }
                    //if (viewModel.ToState == MedulaTreatmentReport.States.Completed)
                    //{
                    //    medulaTreatmentReportImported.CurrentStateDefID = MedulaTreatmentReport.States.Completed;
                    //    objectContext.Save();
                    //}
                    // InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi, MessageIconEnum.InformationMessage);
                    ////return;
                    //}
                    //else
                    //{
                    //    //InfoBox.Show("Rapor Servisinden Gelen Uyarı Mesajı : " + response.sonucAciklamasi + "  Rapor Takip Numarası Alınamamıştır.  !!!");
                    //    //return;
                    //}
                }
                viewModel._MedulaTreatmentReport = medulaTreatmentReport;
                return response;
            }
            catch (Exception e)
            {
                if (e != null)
                    TTUtils.InfoMessageService.Instance.ShowMessage(e.ToString());
                return null;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Medula_Raporlari_TC_ile_Rapor_Bul)]
        public RaporIslemleri.raporCevapTCKimlikNodanDVO raporBilgisiBulTCKimlikNodan(RaporIslemleri.raporOkuTCKimlikNodanDVO raporOkuTCKimlikNodanDVO)
        {
            if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("TEDAVIRAPORUSORGU", "TRUE")) == true)
            {
                if (!String.IsNullOrEmpty(raporOkuTCKimlikNodanDVO.tckimlikNo))
                {
                    var context = new TTObjectContext(false);
                    BindingList<Patient> patientSearchList = Patient.GetPatientObjectsByInjection(context, "WHERE (UNIQUEREFNO = " + raporOkuTCKimlikNodanDVO.tckimlikNo.ToString() + " )");
                    if (patientSearchList.Count > 0 && !String.IsNullOrEmpty(patientSearchList[0].YUPASSNO.ToString()))
                        raporOkuTCKimlikNodanDVO.tckimlikNo = patientSearchList[0].YUPASSNO.ToString();
                }
            }
            raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, raporOkuTCKimlikNodanDVO);
            //  string a= TTUtils.SerializationHelper.XmlSerializeObject(raporOkuTCKimlikNodanDVO);
            return response;
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Medula_Raporlari_Takip_No_ile_Kaydet)]
        public bool Undo(MedulaTreatmentReport medulaTreatmentReport)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var medulaTreatmentReportImported = (MedulaTreatmentReport)objectContext.AddObject(medulaTreatmentReport);

                    if (medulaTreatmentReportImported.CurrentStateDefID != MedulaTreatmentReport.States.Cancelled)
                        medulaTreatmentReportImported.CurrentStateDefID = MedulaTreatmentReport.States.New;

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
        [AtlasRequiredRoles(TTRoleNames.Medula_Raporlari_Sil)]
        public bool Cancel(MedulaTreatmentReport medulaTreatmentReport)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var medulaTreatmentReportImported = (MedulaTreatmentReport)objectContext.AddObject(medulaTreatmentReport);
                    medulaTreatmentReportImported.CurrentStateDefID = MedulaTreatmentReport.States.Cancelled;

                    //rapor üzerinden girilen tanının silinmesi tanı ve rapor tanısı bağlantısı kopduğu için bu işleme gerek yok
                    //EpisodeAction episodeAction = medulaTreatmentReportImported.ObjectContext.GetObject<EpisodeAction>(medulaTreatmentReportImported.ObjectID);

                    //EpisodeActionWithDiagnosis reportEpisodeAction = null;
                    //if (((ITTObject)episodeAction).IsNew == false)
                    //{
                    //    reportEpisodeAction = episodeAction.ObjectContext.GetObject<EpisodeActionWithDiagnosis>(episodeAction.ObjectID);//sadece rapor üzerinden kaydedilen tanı
                    //    List<DiagnosisGrid> tempDiagnosisList = reportEpisodeAction.Diagnosis.ToList();
                    //    if (tempDiagnosisList != null)
                    //    {
                    //        foreach (DiagnosisGrid item in tempDiagnosisList)
                    //        {
                    //            BindingList<ReportDiagnosis> reportDiagnosisList = ReportDiagnosis.GetReportDiagnosisByDiagnosisGridAndEA(episodeAction.ObjectContext, episodeAction.ObjectID.ToString(), item.ObjectID.ToString());
                    //            if (reportDiagnosisList != null)
                    //            {
                    //                foreach (ReportDiagnosis reportDiagnosis in reportDiagnosisList)
                    //                {
                    //                    DiagnosisGrid tempDiagnosis = null;
                    //                    if (reportDiagnosis.DiagnosisGrid.EpisodeAction == episodeAction)
                    //                    {
                    //                        tempDiagnosis = reportDiagnosis.DiagnosisGrid;
                    //                    }

                    //                    ((ITTObject)reportDiagnosis).Delete();
                    //                    if (tempDiagnosis != null)
                    //                        ((ITTObject)tempDiagnosis).Delete();
                    //                }
                    //            }
                    //        }
                    //    }
                    //}


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
        [AtlasRequiredRoles(TTRoleNames.Medula_Raporlari_Rapor_Bul)]
        public RaporIslemleri.raporCevapDVO raporBilgisiBul(RaporIslemleri.raporSorguDVO raporSorguDVO)
        {
            RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiBulSync(Sites.SiteLocalHost, raporSorguDVO);
            return response;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Medula_Raporlari_Sil)]
        public RaporIslemleri.raporCevapDVO raporBilgisiSil(string no, string siraNo, string tarih, string objectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {

                RaporIslemleri.raporSorguDVO raporSorguDVO = new RaporIslemleri.raporSorguDVO();
                raporSorguDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                RaporIslemleri.raporOkuDVO _raporOkuDVO = new RaporIslemleri.raporOkuDVO();
                _raporOkuDVO.no = (no == "undefined") ? "" : no;
                _raporOkuDVO.raporSiraNo = siraNo;
                _raporOkuDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                _raporOkuDVO.tarih = tarih;
                _raporOkuDVO.turu = "1";
                raporSorguDVO.raporBilgisi = _raporOkuDVO;
                RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiSilSync(Sites.SiteLocalHost, raporSorguDVO);
                var gelen = TTUtils.SerializationHelper.XmlSerializeObject(response);
                var giden = TTUtils.SerializationHelper.XmlSerializeObject(raporSorguDVO);
                if (response.sonucKodu.Equals(0))
                {
                    Guid objectIDGuid = new Guid(objectID);
                    MedulaTreatmentReport medulaTreatmentReport = objectContext.GetObject<MedulaTreatmentReport>(objectIDGuid);
                    medulaTreatmentReport.RaporTakipNo = null;
                    objectContext.Save();
                }
                return response;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Medula_Raporlari_Takip_No_ile_Rapor_Bul)]
        public RaporIslemleri.raporCevapDVO raporBilgisiBulRaporTakipNodan(RaporIslemleri.raporOkuRaporTakipNodanDVO raporOkuRaporTakipNodanDVO)
        {
            RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiBulRaporTakipNodanSync(Sites.SiteLocalHost, raporOkuRaporTakipNodanDVO);
            return response;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Medula_Raporlari_ListDef_Getirme, TTRoleNames.Saglik_Kurulu_Yeni_RUW, TTRoleNames.Saglik_Kurulu_Rapor_RUW, TTRoleNames.Saglik_Kurulu_Tamamlandi_R)]
        public LookupItem[] GetListDefValues(string listDefName, string listFilterExpression, string linkFilterExpression)
        {
            LookupService service = new LookupService();
            var result = service.ListDefList(listDefName, listFilterExpression, linkFilterExpression);
            return result.ToArray();
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Medula_Raporlari_Doz_Araligi_Getir)]
        public LookupItem[] GetDozAraligi(string listDefName, string listFilterExpression, string linkFilterExpression)
        {
            LookupService service = new LookupService();
            var result = service.ListDefList(listDefName, listFilterExpression, linkFilterExpression);
            return result.ToArray();
        }
    }
}

namespace Core.Models
{
    public partial class MedulaTedaviRaporlariViewModel
    {
        public ReportDiagnosisFormViewModel reportDiagnosisFormViewModel = new ReportDiagnosisFormViewModel();

        public bool willSendToMedula
        {
            get;
            set;
        }

        public Patient Patient
        {
            get;
            set;
        }
        public bool IsNew
        {
            get;
            set;
        }

        public bool IsPatientSGK
        {
            get;
            set;
        }

        public List<SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport_Class> HistoryPatientAdmission
        {
            get;
            set;
        }

        public List<FizyoterapiIslemleriListModel> FizyoterapiIslemleriList
        {
            get;
            set;
        }

        public List<ESWTIslemleriListModel> ESWTIslemleriList
        {
            get;
            set;
        }

        public List<TasBilgisiIslemleriListModel> TasBilgisiIslemleriList
        {
            get;
            set;
        }

        public List<HastaAktifTakipleriListModel> HastaAktifTakipleriList
        {
            get;
            set;
        }

        public List<HastaAktifTumTakipleriListModel> HastaAktifTumTakipleriList
        {
            get;
            set;
        }

        public List<GridFtrRaporlariListModel> GridFtrRaporlariList
        {
            get;
            set;
        }

        public List<GridEswlRaporlariListModel> GridEswlRaporlariList
        {
            get;
            set;
        }

        public List<GridDiyalizRaporlariListModel> GridDiyalizRaporlariList
        {
            get;
            set;
        }

        public List<GridEvdiyalizRaporlariListModel> GridEvdiyalizRaporlariList
        {
            get;
            set;
        }

        public List<GridTupBebekRaporlariListModel> GridTupBebekRaporlariList
        {
            get;
            set;
        }

        public List<GridHOTRaporlariListModel> GridHOTRaporlariList
        {
            get;
            set;
        }

        public List<TaniGridListModel> TaniGridList
        {
            get;
            set;
        }

        public HastaAktifTakipleriListModel SelectedTakip
        {
            get;
            set;
        }

        public List<FTRVucutBolgesiListModel> fTRVucutBolgesiList
        {
            get;
            set;
        }

        public DiyalizSeansGunEnum cmbDiyalizSeansGun
        {
            get;
            set;
        }

        public DiyalizSeansGunEnum cmbEvHemodiyalizSeansGun
        {
            get;
            set;
        }

        public MedulaRaporOzelDurumEnum? OzelDurum
        {
            get;
            set;
        }

        public bool chkOzelDurum
        {
            get;
            set;
        }

        public bool chkRefakatVarYok
        {
            get;
            set;
        }

        public TedaviRaporTuruEnum RaporTuru
        {
            get;
            set;
        }

        public MedulaRaporTuruEnum RBReportType
        {
            get;
            set;
        }

        public MedulaRaporTuruEnum ReportType
        {
            get;
            set;
        }

        public TupBebekRaporTuruEnum cmbTupBebekTuru
        {
            get;
            set;
        }

        public int kur
        {
            get;
            set;
        }

        //public Bobrek lstBobrekBilgisi
        //{
        //    get;
        //    set;
        //}

        public TedaviRaporiIslemKodlari lstDiyalizRaporKodu
        {
            get;
            set;
        }

        //public TedaviRaporiIslemKodlari lstEswlRaporKodu
        //{
        //    get;
        //    set;
        //}

        public TedaviRaporiIslemKodlari lstEvHemodiyalizRaporKodu
        {
            get;
            set;
        }

        public ResUser Tabip
        {
            get;
            set;
        }

        public ResUser Tabip2
        {
            get;
            set;
        }

        public ResUser Tabip3
        {
            get;
            set;
        }

        public TedaviRaporiIslemKodlari lstTupBebekRaporKodu
        {
            get;
            set;
        }

        public DateTime RaporBaslangicTarihi
        {
            get;
            set;
        }

        //public DateTime RaporBitisTarihi
        //{
        //    get;
        //    set;
        //}

        public bool FtrHeyetRaporu
        {
            get;
            set;
        }

        public int txtDiyalizSeansSayisi
        {
            get;
            set;
        }

        //public int txtEswlSeansSayisi
        //{
        //    get;
        //    set;
        //}

        public string maxReportDate { get; set; }
        public string minReportDate { get; set; }

        public int txtEvHemodiyalizSeansSayisi
        {
            get;
            set;
        }

        public int txtEvHemodiyalizTedaviSuresi
        {
            get;
            set;
        }

        public int txtHOTSeansSayisi
        {
            get;
            set;
        }

        public int txtHOTTedaviSuresi
        {
            get;
            set;
        }

        public string txtRaporTakipNo
        {
            get;
            set;
        }

        public string txtRaporAciklama
        {
            get;
            set;
        }

        public int RBReportChasing
        {
            get;
            set;
        }

        public int RBReportRow
        {
            get;
            set;
        }

        public int ReportChasing
        {
            get;
            set;
        }

        public int ReportRow
        {
            get;
            set;
        }

        public Object txtResult
        {
            get;
            set;
        }

        public Guid ToState
        {
            get;
            set;
        }

        public DateTime ReportDate
        {
            get;
            set;
        }

        public int txtRaporSuresi
        {
            get;
            set;
        }

        public PeriodUnitTypeEnum cmbRaporSureTuru
        {
            get;
            set;
        }

        public bool patientExisting
        {
            get;
            set;
        }
        public string TedaviTipi { get; set; }
        public string TedaviTuru { get; set; }

        public MedulaTedaviRaporlariViewModel()
        {
            this.RaporBaslangicTarihi = DateTime.Now;
            //this.RaporBitisTarihi = DateTime.Now;
            this.FizyoterapiIslemleriList = new List<FizyoterapiIslemleriListModel>();
            this.ESWTIslemleriList = new List<ESWTIslemleriListModel>();
            this.TasBilgisiIslemleriList = new List<TasBilgisiIslemleriListModel>();
            this.HastaAktifTakipleriList = new List<HastaAktifTakipleriListModel>();
            this.HastaAktifTumTakipleriList = new List<HastaAktifTumTakipleriListModel>();
            this.GridFtrRaporlariList = new List<GridFtrRaporlariListModel>();
            this.GridEswlRaporlariList = new List<GridEswlRaporlariListModel>();
            this.GridDiyalizRaporlariList = new List<GridDiyalizRaporlariListModel>();
            this.GridEvdiyalizRaporlariList = new List<GridEvdiyalizRaporlariListModel>();
            this.GridTupBebekRaporlariList = new List<GridTupBebekRaporlariListModel>();
            this.GridHOTRaporlariList = new List<GridHOTRaporlariListModel>();
            this.TaniGridList = new List<TaniGridListModel>();
            this.HistoryPatientAdmission = new List<SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport_Class>();
            this.fTRVucutBolgesiList = new List<FTRVucutBolgesiListModel>();

        }
    }

    public class FizyoterapiIslemleriListModel
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public Guid FizyoterapiIslemi
        {
            get;
            set;
        }

        public Guid VucutBolgesi
        {
            get;
            set;
        }

        public int SeansSayisi
        {
            get;
            set;
        }

        public Guid TedaviTuru
        {
            get;
            set;
        }


    }

    public class ESWTIslemleriListModel
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public Guid FizyoterapiIslemiESWT
        {
            get;
            set;
        }

        public Guid VucutBolgesiESWT
        {
            get;
            set;
        }

        public int SeansSayisiESWT
        {
            get;
            set;
        }
    }

    public class TasBilgisiIslemleriListModel
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public Guid Lokalizasyon
        {
            get;
            set;
        }

        public int LokalizasyonKodu
        {
            get;
            set;
        }

        public int TasBoyutu
        {
            get;
            set;
        }
    }

    public class HastaAktifTakipleriListModel
    {
        public string TakipNo
        {
            get;
            set;
        }

        public string Brans
        {
            get;
            set;
        }

        public DateTime ProvizyonTarihi
        {
            get;
            set;
        }

        public string BagliTakipNo
        {
            get;
            set;
        }

        public string BransKodu
        {
            get;
            set;
        }

        public string TedaviTuru
        {
            get;
            set;
        }

        public string HProtocolNo
        {
            get;
            set;
        }

        public DateTime VakaAcilisTarihi
        {
            get;
            set;
        }

        public Guid SubEpisode
        {
            get;
            set;
        }

        public Guid EAObjectId
        {
            get;
            set;
        }
    }

    public class HastaAktifTumTakipleriListModel
    {
        public string TakipNo
        {
            get;
            set;
        }

        public string Brans
        {
            get;
            set;
        }

        public DateTime ProvizyonTarihi
        {
            get;
            set;
        }

        public string BagliTakipNo
        {
            get;
            set;
        }

        public string BransKodu
        {
            get;
            set;
        }

        public string TedaviTuru
        {
            get;
            set;
        }

        public string HProtocolNo
        {
            get;
            set;
        }

        public DateTime VakaAcilisTarihi
        {
            get;
            set;
        }

        public Guid SubEpisode
        {
            get;
            set;
        }

        public Guid EAObjectId
        {
            get;
            set;
        }
    }

    public class TaniGridListModel
    {
        public string Tani
        {
            get;
            set;
        }

        public string FTRTaniGrup
        {
            get;
            set;
        }

        public string TaniKodu
        {
            get;
            set;
        }
    }

    public class GridFtrRaporlariListModel
    {
        public int TakipNo
        {
            get;
            set;
        }

        public string RaporNo
        {
            get;
            set;
        }

        public int RaporSiraNo
        {
            get;
            set;
        }

        public string VucutBolgesi
        {
            get;
            set;
        }

        public int Kur
        {
            get;
            set;
        }

        public string RaporBaslangicTarihi
        {
            get;
            set;
        }

        public string VerildigiTesis
        {
            get;
            set;
        }
        public string Detail
        {
            get;
            set;
        }
        public string SonucMesaji
        {
            get;
            set;
        }

        public int SonucKodu
        {
            get;
            set;
        }
    }

    public class GridEswlRaporlariListModel
    {
        public int TakipNo
        {
            get;
            set;
        }

        public string RaporNo
        {
            get;
            set;
        }

        public int RaporSiraNo
        {
            get;
            set;
        }

        public string SonucMesaji
        {
            get;
            set;
        }

        public int SonucKodu
        {
            get;
            set;
        }

        public string RaporBaslangicTarihi
        {
            get;
            set;
        }

        public string VerildigiTesis
        {
            get;
            set;
        }
        public string Detail
        {
            get;
            set;
        }
        //   public int Count { get; set; }
    }

    public class GridDiyalizRaporlariListModel
    {
        public int TakipNo
        {
            get;
            set;
        }

        public string RaporNo
        {
            get;
            set;
        }

        public int RaporSiraNo
        {
            get;
            set;
        }

        public string SonucMesaji
        {
            get;
            set;
        }

        public int SonucKodu
        {
            get;
            set;
        }

        public string RaporBaslangicTarihi
        {
            get;
            set;
        }

        public string VerildigiTesis
        {
            get;
            set;
        }
        public string Detail
        {
            get;
            set;
        }
        //   public int Count { get; set; }
    }

    public class GridEvdiyalizRaporlariListModel
    {
        public int TakipNo
        {
            get;
            set;
        }

        public string RaporNo
        {
            get;
            set;
        }

        public int RaporSiraNo
        {
            get;
            set;
        }

        public string SonucMesaji
        {
            get;
            set;
        }

        public int SonucKodu
        {
            get;
            set;
        }

        public string RaporBaslangicTarihi
        {
            get;
            set;
        }

        public string VerildigiTesis
        {
            get;
            set;
        }
        public string Detail
        {
            get;
            set;
        }
        //   public int Count { get; set; }
    }

    public class GridTupBebekRaporlariListModel
    {
        public int TakipNo
        {
            get;
            set;
        }

        public string RaporNo
        {
            get;
            set;
        }

        public int RaporSiraNo
        {
            get;
            set;
        }

        public string SonucMesaji
        {
            get;
            set;
        }

        public int SonucKodu
        {
            get;
            set;
        }

        public string RaporBaslangicTarihi
        {
            get;
            set;
        }

        public string VerildigiTesis
        {
            get;
            set;
        }
        public string Detail
        {
            get;
            set;
        }
        //   public int Count { get; set; }
    }

    public class GridHOTRaporlariListModel
    {
        public int TakipNo
        {
            get;
            set;
        }

        public string RaporNo
        {
            get;
            set;
        }

        public int RaporSiraNo
        {
            get;
            set;
        }

        public string SonucMesaji
        {
            get;
            set;
        }

        public int SonucKodu
        {
            get;
            set;
        }

        public string RaporBaslangicTarihi
        {
            get;
            set;
        }

        public string VerildigiTesis
        {
            get;
            set;
        }
        public string Detail
        {
            get;
            set;
        }
        //   public int Count { get; set; }
    }

    public class FTRVucutBolgesiListModel
    {
        public string ftrVucutBolgesiKodu
        {
            get;
            set;
        }

        public string ftrVucutBolgesiAdi
        {
            get;
            set;
        }
    }
}