//$C16425EE
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using ReportClasses.Controllers;
using Newtonsoft.Json;
using ReportClasses.ReportUtils;

namespace Core.Controllers
{
    public partial class ForensicMedicalReportServiceController
    {
        partial void PreScript_ForensicMedicalReportForm(ForensicMedicalReportFormViewModel viewModel, ForensicMedicalReport forensicMedicalReport, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            //selectedEpisodeActionObjectID = new Guid("cc740d53-0fd9-4718-b22a-6cddd96b1091");
            if (selectedEpisodeActionObjectID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                viewModel._ForensicMedicalReport.FromResource = episodeAction.MasterResource;
                viewModel._ForensicMedicalReport.MasterAction = episodeAction;
                viewModel._ForensicMedicalReport.Episode = episodeAction.Episode;
                if (episodeAction is PatientExamination)
                {
                    if (((PatientExamination)episodeAction).ProcessDate.HasValue)
                        viewModel._ForensicMedicalReport.ExaminationDate = Convert.ToDateTime(((PatientExamination)episodeAction).ProcessDate);
                    else
                        viewModel._ForensicMedicalReport.ExaminationDate = DateTime.Now;
                }


            }

            ContextToViewModel(viewModel, objectContext);
        }

        partial void AfterContextSaveScript_ForensicMedicalReportForm(ForensicMedicalReportFormViewModel viewModel, ForensicMedicalReport forensicMedicalReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            // Adli Vaka Raporu için UploadedDocument oluþturulur
            if (forensicMedicalReport.CurrentStateDefID == ForensicMedicalReport.States.Completed)
            {
                try
                {
                    // ApiCaller.IISBaseUrl null kalýyor bazen, null olunca da rapor oluþturulamýyor. Bu yüzden boþsa burada set edildi.
                    if (ApiCaller.IISBaseUrl == null)
                    {
                        if (HttpContext != null && HttpContext.Request != null)
                        {
                            ApiCaller.IISBaseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}";
                        }
                    }

                    ReportClasses.Controllers.DynamicReporting.ReportParameters parameters = new ReportClasses.Controllers.DynamicReporting.ReportParameters();
                    parameters.ReportParams = JsonConvert.SerializeObject(new AtlasDataSource.Controllers.AdliVakaReportParameters() { ObjectID = forensicMedicalReport.ObjectID });
                    parameters.Code = "ADLIVAKA";
                    parameters.ReportClassName = "AdliVakaFormu";
                    parameters.Token = HttpContext.Request.Headers["Authorization"];
                    parameters.Token = parameters.Token.Replace("Bearer ", "");

                    UploadedDocument doc = new UploadedDocument(objectContext);
                    doc.File = ReportResolver.GetReportOutput("ADLIVAKA", parameters);
                    doc.UploadDate = DateTime.Now;
                    doc.Uploader = Common.CurrentResource;
                    doc.BaseAction = forensicMedicalReport;
                    doc.SubEpisode = forensicMedicalReport.SubEpisode;
                    doc.Episode = forensicMedicalReport.Episode;
                    doc.Explanation = "Adli Vaka Raporu";
                    doc.FileName = "Adli Vaka Raporu.pdf";
                    doc.DosyaTuru = objectContext.QueryObjects<DosyaTuru>("DOSYATURUKODU = 60").FirstOrDefault();

                    objectContext.Save();
                }
                catch (Exception ex)
                {
                    throw new TTException("Adli Vaka Raporu döküman olarak kaydedilirken hata alýndý. Detay : " + ex.Message);
                }
            }
        }

        [HttpGet]
        public ForensicMedicalReport CheckForensicMedicalReport(Guid EpisodeActionId)
        {
            using (var objectContext = new TTObjectContext(false))
            {

                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(EpisodeActionId);
                Episode episode = objectContext.GetObject(episodeAction.Episode.ObjectID, typeof(Episode)) as Episode;


                if (episode.ForensicMedicalReports.Count > 0)
                {
                    foreach (ForensicMedicalReport fReport in episode.ForensicMedicalReports)
                    {
                        if (fReport.CurrentStateDefID != ForensicMedicalReport.States.Cancelled)
                        {
                            ForensicMedicalReport forensicReport = objectContext.GetObject<ForensicMedicalReport>(fReport.ObjectID);
                            objectContext.FullPartialllyLoadedObjects();
                            return forensicReport;
                        }
                    }

                    //return ((ForensicMedicalReport)episodeAction.Episode.ForensicMedicalReports.FirstOrDefault()) as ForensicMedicalReport;
                }

                ForensicMedicalReport report = new ForensicMedicalReport(objectContext, episodeAction);
                return report;
            }

        }

    }
}

namespace Core.Models
{
    public partial class ForensicMedicalReportFormViewModel : BaseViewModel
    {
    }
}
