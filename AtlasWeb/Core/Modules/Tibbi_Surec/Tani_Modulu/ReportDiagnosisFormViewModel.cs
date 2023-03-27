using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class ReportDiagnosisServiceController
    {

        [HttpGet]
        public ReportDiagnosisGridListViewModel[] PreScriptReportDiagnosisForm(string reportEpisodeAction, string episode, bool isNew)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<ReportDiagnosisGridListViewModel> diagnosisList = new List<ReportDiagnosisGridListViewModel>();
                if (!isNew)
                {
                    EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(new Guid(reportEpisodeAction));

                    if (episodeAction.ReportDiagnosis != null && episodeAction.ReportDiagnosis.Count > 0)
                    {
                        try
                        {
                            foreach (ReportDiagnosis reportDiagnose in episodeAction.ReportDiagnosis)
                            {
                                //if (reportDiagnose.DiagnosisGrid == null)
                                //    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25484", "DiagnosisGrid null geldi"));
                                if (reportDiagnose.Diagnose == null)
                                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25484", "Diagnosis null geldi"));
                                if (!(diagnosisList.Any(dr => dr.DiagnoseCode == reportDiagnose.Diagnose.Code)))
                                {
                                    ReportDiagnosisGridListViewModel diagnosis = new ReportDiagnosisGridListViewModel();
                                    diagnosis.ObjectId = reportDiagnose.ObjectID;
                                    //diagnosis.DiagnosisGrid = reportDiagnose.DiagnosisGrid; TODO
                                    diagnosis.Diagnosis = reportDiagnose.Diagnose;
                                    diagnosis.DiagnoseName = reportDiagnose.Diagnose.Code + ' ' + reportDiagnose.Diagnose.Name;
                                    diagnosis.DiagnoseCode = reportDiagnose.Diagnose.Code;
                                    diagnosisList.Add(diagnosis);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
                else
                {
                    Episode episodeObject = objectContext.GetObject<Episode>(new Guid(episode));
                    if (episodeObject.Diagnosis.Count > 0)
                    {
                        foreach (DiagnosisGrid diagnose in episodeObject.Diagnosis)
                        {
                            var diagnosisGrid = diagnosisList.Where(t => t.DiagnoseCode == diagnose.DiagnoseCode).FirstOrDefault();
                            if (diagnosisGrid == null)
                            {
                                ReportDiagnosisGridListViewModel diagnosis = new ReportDiagnosisGridListViewModel();
                                diagnosis.ObjectId = null;
                                diagnosis.DiagnosisGrid = diagnose;
                                diagnosis.Diagnosis = diagnose.Diagnose;
                                diagnosis.DiagnoseName = diagnose.Diagnose.Code + ' ' + diagnose.Diagnose.Name;
                                diagnosis.DiagnoseCode = diagnose.Diagnose.Code;
                                diagnosisList.Add(diagnosis);
                            }

                        }
                    }
                }
                objectContext.FullPartialllyLoadedObjects();
                return diagnosisList.ToArray();
            }
        }

        public void SaveDiagnosis(ReportDiagnosisFormViewModel viewModel, EpisodeActionWithDiagnosis episodeAction)
        {

            // Rapordan girilenlerin hem DGsini hem RD ini siliyor
            EpisodeActionWithDiagnosis databaseEpisodeAction = null;
            if (((ITTObject)episodeAction).IsNew == false)
            {
                databaseEpisodeAction = episodeAction.ObjectContext.GetObject<EpisodeActionWithDiagnosis>(episodeAction.ObjectID, false);//sadece rapor üzerinden kaydedilen tanı

                //List<DiagnosisGrid> tempDiagnosisList = reportEpisodeAction.Diagnosis.ToList();
                //foreach (DiagnosisGrid item in tempDiagnosisList)
                //{
                //    ReportDiagnosisGridListViewModel result = viewModel.ReportDiagnosisGridList.Where(t => t.Diagnosis.ObjectID == item.Diagnose.ObjectID).FirstOrDefault();
                //    if (result == null)
                //    {
                //        BindingList<ReportDiagnosis> reportDiagnosisList = ReportDiagnosis.GetReportDiagnosisByDiagnosisGridAndEA(episodeAction.ObjectContext, episodeAction.ObjectID.ToString(), item.ObjectID.ToString());
                //        foreach (ReportDiagnosis reportDiagnosis in reportDiagnosisList)
                //        {
                //            DiagnosisGrid tempDiagnosis = null;
                //            if (reportDiagnosis.DiagnosisGrid.EpisodeAction == episodeAction)
                //            {
                //                tempDiagnosis = reportDiagnosis.DiagnosisGrid;

                //            }
                //            ((ITTObject)reportDiagnosis).Delete();
                //            if (tempDiagnosis != null)
                //                ((ITTObject)tempDiagnosis).Delete();
                //        }
                //    }
                //}

                // Muayneden girilen DGler için Yanlızca RD i siliyor
                //if (episodeAction.ReportDiagnosis != null && episodeAction.ReportDiagnosis.Count > 0)
                //{
                //    List<ReportDiagnosis> tempReportDiagnosisList = reportEpisodeAction.ReportDiagnosis.ToList();
                //    foreach (ReportDiagnosis reportItem in tempReportDiagnosisList)
                //    {
                //        if (reportItem.DiagnosisGrid != null)
                //        {
                //            ReportDiagnosisGridListViewModel result = viewModel.ReportDiagnosisGridList.Where(t => t.DiagnosisGrid != null && t.DiagnosisGrid.ObjectID == reportItem.DiagnosisGrid.ObjectID).FirstOrDefault();
                //            if (result == null)
                //            {

                //                if (reportItem.EpisodeAction == episodeAction)
                //                {
                //                    ReportDiagnosis tempDiagnosis = reportEpisodeAction.ReportDiagnosis.Where(t => t.DiagnosisGrid.ObjectID == reportItem.DiagnosisGrid.ObjectID).First();
                //                    ((ITTObject)tempDiagnosis).Delete();
                //                }
                //            }
                //        }
                //    }
                //}

                if (episodeAction.ReportDiagnosis != null && episodeAction.ReportDiagnosis.Count > 0)
                {
                    List<ReportDiagnosis> databaseReportDiagnosisList = databaseEpisodeAction.ReportDiagnosis.ToList();
                    foreach (ReportDiagnosis databaseReportDiagnosis in databaseReportDiagnosisList)
                    {
                        ReportDiagnosisGridListViewModel result = viewModel.ReportDiagnosisGridList.Where(t => t.ObjectId == databaseReportDiagnosis.ObjectID).FirstOrDefault();
                        if (result == null)
                        {
                            //if (databaseReportDiagnosis.EpisodeAction == episodeAction)// Rapordan das muaynedende girilse silinecek
                            //{
                            ReportDiagnosis tempDiagnosis = databaseEpisodeAction.ReportDiagnosis.Where(t => t.ObjectID == databaseReportDiagnosis.ObjectID).First();
                            ((ITTObject)tempDiagnosis).Delete();
                            //}
                        }
                    }
                }
            }

            foreach (ReportDiagnosisGridListViewModel reportDiagnose in viewModel.ReportDiagnosisGridList)
            {
                if (reportDiagnose.ObjectId == null)
                {
                    ReportDiagnosis reportDiagnosis = new ReportDiagnosis(episodeAction.ObjectContext);
                    reportDiagnosis.Diagnose = reportDiagnose.Diagnosis;
                    reportDiagnosis.DiagnoseDate = Common.RecTime();
                    reportDiagnosis.EpisodeAction = episodeAction;

                }



                //BindingList<DiagnosisGrid.GetDiagnosisByEpisodeAndDiagnose_Class> episodeDiagnosis = DiagnosisGrid.GetDiagnosisByEpisodeAndDiagnose(episode.ObjectID.ToString(), reportDiagnose.Diagnosis.ObjectID.ToString());

                //if (episodeDiagnosis.Count > 0)
                //{
                //    if (episodeDiagnosis.Count > 1)
                //    {
                //        DiagnosisGrid relatedDiagnosis = null;

                //        foreach (DiagnosisGrid.GetDiagnosisByEpisodeAndDiagnose_Class diagnose in episodeDiagnosis)
                //        {
                //            DiagnosisGrid diagnosisGrid = episodeAction.ObjectContext.GetObject<DiagnosisGrid>((Guid)diagnose.ObjectID);
                //            if (diagnosisGrid.DiagnosisType == DiagnosisTypeEnum.Seconder)
                //            {
                //                relatedDiagnosis = diagnosisGrid;
                //                return;
                //            }
                //        }
                //        if (relatedDiagnosis == null)
                //        {
                //            DiagnosisGrid diagnosisGrid = episodeAction.ObjectContext.GetObject<DiagnosisGrid>((Guid)episodeDiagnosis[0].ObjectID);
                //            relatedDiagnosis = diagnosisGrid;
                //        }
                //        bool add = true;
                //        foreach (ReportDiagnosis item in relatedDiagnosis.ReportDiagnosis)
                //        {
                //            if (item.EpisodeAction == episodeAction)
                //            {
                //                add = false;
                //                break;
                //            }
                //        }
                //        if (add)
                //        {
                //            ReportDiagnosis reportDiagnosis = new ReportDiagnosis(episodeAction.ObjectContext);
                //            reportDiagnosis.DiagnosisGrid = relatedDiagnosis;
                //            reportDiagnosis.EpisodeAction = episodeAction;
                //        }
                //    }
                //    else
                //    {
                //        DiagnosisGrid diagnosisGrid = episodeAction.ObjectContext.GetObject<DiagnosisGrid>((Guid)episodeDiagnosis[0].ObjectID);
                //        bool add = true;
                //        foreach (ReportDiagnosis item in diagnosisGrid.ReportDiagnosis)
                //        {
                //            if (item.EpisodeAction == episodeAction)
                //            {
                //                add = false;
                //                break;
                //            }
                //        }
                //        if (add)
                //        {
                //            ReportDiagnosis reportDiagnosis = new ReportDiagnosis(episodeAction.ObjectContext);
                //            reportDiagnosis.DiagnosisGrid = diagnosisGrid;
                //            reportDiagnosis.EpisodeAction = episodeAction;
                //        }
                //    }
                //}
                //else
                //{
                //    DiagnosisGrid diagnosisGrid = new DiagnosisGrid(episodeAction, reportDiagnose.Diagnosis, false, DiagnosisTypeEnum.Primer, episodeAction.ProcedureDoctor, null, null);
                //    //Birçok yerde tekrarlanıyordu yukarıdaki hale getirildi
                //    //DiagnosisGrid diagnosisGrid = new DiagnosisGrid(episodeAction.ObjectContext);
                //    //diagnosisGrid.Diagnose = reportDiagnose.Diagnosis;
                //    //diagnosisGrid.EpisodeAction = episodeAction;
                //    //diagnosisGrid.Episode = episodeAction.Episode;
                //    //diagnosisGrid.DiagnosisType = DiagnosisTypeEnum.Primer;
                //    //diagnosisGrid.DiagnoseDate = Common.RecTime();
                //    //diagnosisGrid.ResponsibleDoctor = episodeAction.ProcedureDoctor;
                //    //diagnosisGrid.ResponsibleUser = Common.CurrentResource;
                //    //diagnosisGrid.EntryActionType = episodeAction.ActionType;
                //    //diagnosisGrid.Speciality = episodeAction.ProcedureSpeciality;
                //    //var diagnosisSubEpisode = new DiagnosisSubEpisode(episodeAction.ObjectContext);
                //    //diagnosisSubEpisode.SubEpisode = episodeAction.SubEpisode;
                //    //diagnosisSubEpisode.DiagnosisGrid = diagnosisGrid;

                //    ReportDiagnosis reportDiagnosis = new ReportDiagnosis(episodeAction.ObjectContext);
                //    reportDiagnosis.Diagnose = reportDiagnose.Diagnosis;
                //    reportDiagnosis.DiagnoseDate = Common.RecTime() ;
                //    reportDiagnosis.EpisodeAction = episodeAction;
                //}
            }

        }
    }
}
namespace Core.Models
{


    public class ReportDiagnosisFormViewModel
    {
        public DiagnosisDefinition _selectedDiagnosis
        {
            get;
            set;
        }
        public Guid episode
        {
            get;
            set;
        }
        public Guid reportEpisodeAction
        {
            get;
            set;
        }
        public List<ReportDiagnosisGridListViewModel> ReportDiagnosisGridList
        {
            get;
            set;
        }
        public ReportDiagnosisFormViewModel()
        {
            this.ReportDiagnosisGridList = new List<ReportDiagnosisGridListViewModel>();
        }
    }

    public class ReportDiagnosisGridListViewModel
    {
        public Guid? ObjectId
        {
            get;
            set;
        }
        public TTObjectClasses.DiagnosisDefinition Diagnosis
        {
            get;
            set;
        }
        public TTObjectClasses.DiagnosisGrid DiagnosisGrid
        {
            get;
            set;
        }
        public string DiagnoseName
        {
            get;
            set;
        }
        public string DiagnoseCode
        {
            get;
            set;
        }
    }
}
