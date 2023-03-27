//$0F677B36
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using System.Collections.Generic;
using Core.Security;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class GlassesReportServiceController
    {
        partial void PreScript_GlassesReportForm(GlassesReportFormViewModel viewModel, GlassesReport glassesReport, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionObjectID.HasValue)
            {
                using (var objectContextLocal = new TTObjectContext(false))
                {
                    if (selectedEpisodeActionObjectID != Guid.Empty)
                    {
                        EpisodeAction episodeAction = objectContextLocal.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                        if (viewModel._GlassesReport.Episode == null)
                        {
                            viewModel._GlassesReport.Episode = episodeAction.Episode;
                            viewModel._GlassesReport.MasterAction = episodeAction;
                            viewModel._GlassesReport.ProcedureDoctor = episodeAction.ProcedureDoctor;
                            viewModel._GlassesReport.SubEpisode = episodeAction.SubEpisode;
                        }
                    }


                }

                viewModel.Episodes = glassesReport.ObjectContext.LocalQuery<Episode>().ToArray();
                viewModel.ResUsers = glassesReport.ObjectContext.LocalQuery<ResUser>().ToArray();
            }

            if (viewModel._GlassesReport.CurrentStateDefID == GlassesReport.States.New)
            {
                viewModel._GlassesReport.ReportDate = DateTime.Now;

            }
            List<TTObjectStateTransitionDef> removedOutgoingTransitions = new List<TTObjectStateTransitionDef>();
            foreach (var trans in viewModel.OutgoingTransitions)
            {
                if (glassesReport.CurrentStateDefID == GlassesReport.States.New)
                {
                    if (trans.ToStateDefID == GlassesReport.States.Completed)
                        removedOutgoingTransitions.Add(trans);
                }
                else if (glassesReport.CurrentStateDefID == GlassesReport.States.Completed)
                {
                    if (trans.ToStateDefID == GlassesReport.States.New)
                        removedOutgoingTransitions.Add(trans);
                    if (trans.ToStateDefID == GlassesReport.States.Cancelled)
                        removedOutgoingTransitions.Add(trans);
                }

            }
            foreach (var removedtrans in removedOutgoingTransitions)
            {
                viewModel.OutgoingTransitions.Remove(removedtrans);
            }
        }
        partial void AfterContextSaveScript_GlassesReportForm(GlassesReportFormViewModel viewModel, GlassesReport glassesReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {


            List<TTObjectStateTransitionDef> removedOutgoingTransitions = new List<TTObjectStateTransitionDef>();
            if (viewModel.OutgoingTransitions != null)
            {
                foreach (var trans in viewModel.OutgoingTransitions)
                {
                    if (glassesReport.CurrentStateDefID == GlassesReport.States.New)
                    {
                        if (trans.ToStateDefID == GlassesReport.States.Completed)
                            removedOutgoingTransitions.Add(trans);
                    }
                    else if (glassesReport.CurrentStateDefID == GlassesReport.States.Completed)
                    {
                        if (trans.ToStateDefID == GlassesReport.States.New)
                            removedOutgoingTransitions.Add(trans);
                        if (trans.ToStateDefID == GlassesReport.States.Cancelled)
                            removedOutgoingTransitions.Add(trans);
                    }
                }
                foreach (var removedtrans in removedOutgoingTransitions)
                {
                    viewModel.OutgoingTransitions.Remove(removedtrans);
                }
            }

        }
        partial void PostScript_GlassesReportForm(GlassesReportFormViewModel viewModel, GlassesReport glassesReport, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            string uniqueRefNo = "", password = "";
            if (viewModel.stateToComplete == true || viewModel.stateToNew == true)
            {
                var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                if (MedulaPasswordCheck == "TRUE")
                {
                    if ((viewModel.medulaUsername != null && viewModel.medulaUsername != "") || (viewModel.medulaPassword != null && viewModel.medulaPassword != ""))
                    {
                        uniqueRefNo = viewModel.medulaUsername;
                        password = viewModel.medulaPassword;
                    }
                    else
                    {
                        throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(glassesReport.ProcedureDoctor.ErecetePassword))
                    {
                        throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");

                    }
                    uniqueRefNo = glassesReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    if (!string.IsNullOrEmpty(glassesReport.ProcedureDoctor.ErecetePassword))
                        password = glassesReport.ProcedureDoctor.ErecetePassword;
                }
            }

            if (viewModel.stateToComplete == true)
            {
                GlassesReport.ReceteKaydet(glassesReport, glassesReport.VitrumFar, glassesReport.VitrumNear, glassesReport.VitrumCloseReading, uniqueRefNo, password);
                //GlassesReport.GecmisReceteleriListele(glassesReport);
                if (glassesReport.SonucKodu != "0")
                {
                    objectContext.Save();
                    //throw new TTException(glassesReport.SonucKodu + "  " + glassesReport.SonucAciklamasi);
                }
                else
                {
                    objectContext.Save();
                    new SendToENabiz(objectContext, glassesReport.SubEpisode, glassesReport.ObjectID, glassesReport.ObjectDef.Name, "226", Common.RecTime());
                    glassesReport.CurrentStateDefID = GlassesReport.States.Completed;
                }
            }
            if (viewModel.stateToNew == true)
            {
                GlassesReport.ReceteSil(glassesReport, uniqueRefNo, password);
                if (glassesReport.SonucKodu != "0")
                {
                    objectContext.Save();
                    //throw new TTException(glassesReport.SonucKodu + "  " + glassesReport.SonucAciklamasi);
                }
                else
                {
                    objectContext.Save();
                    glassesReport.CurrentStateDefID = GlassesReport.States.New;
                    glassesReport.SonucAciklamasi = "";
                    glassesReport.SonucKodu = "";
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public OptikReceteIslemleri.receteTesisDVO[] GetOldMedulaGlassesReports(Guid MasterAction, string medulaUsername, string medulaPassword)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                EpisodeAction episodeActionObj = (EpisodeAction)objectContext.GetObject(MasterAction, "EpisodeAction");
                string uniqueRefNo = "", password = "";
                var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                if (MedulaPasswordCheck == "TRUE")
                {
                    if ((medulaUsername != null && medulaUsername != "") || (medulaPassword != null && medulaPassword != ""))
                    {
                        uniqueRefNo = medulaUsername;
                        password = medulaPassword;
                    }
                    else
                    {
                        throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(episodeActionObj.ProcedureDoctor.ErecetePassword))
                    {
                        throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");

                    }
                    uniqueRefNo = episodeActionObj.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    if (!string.IsNullOrEmpty(episodeActionObj.ProcedureDoctor.ErecetePassword))
                        password = episodeActionObj.ProcedureDoctor.ErecetePassword;
                }
                return GlassesReport.GecmisReceteleriListele(episodeActionObj, uniqueRefNo, password);
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string RemoveOldGlassesReport(string oldGlassesReportNo, Guid _GlassesReport, string medulaUsername, string medulaPassword)
        {
            using (var tempObjectContext = new TTObjectContext(false))
            {
                GlassesReport glassesReportObj = (GlassesReport)tempObjectContext.GetObject(_GlassesReport, "GlassesReport");
                GlassesReport glassesReport = new GlassesReport(tempObjectContext);
                glassesReport.EReceteNo = oldGlassesReportNo;
                glassesReport.ProcedureDoctor = glassesReportObj.ProcedureDoctor;
                string uniqueRefNo = "", password = "";
                var MedulaPasswordCheck = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASIFREGIRISEKRANIAKTIF", "FALSE");

                if (MedulaPasswordCheck == "TRUE")
                {
                    if ((medulaUsername != null && medulaUsername != "") || (medulaPassword != null && medulaPassword != ""))
                    {
                        uniqueRefNo = medulaUsername;
                        password = medulaPassword;
                    }
                    else
                    {
                        throw new TTUtils.TTException("Kullanıcı adı veya şifre boş olamaz!");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(glassesReport.ProcedureDoctor.ErecetePassword))
                    {
                        throw new TTUtils.TTException("E-Reçete Şifreniz Boş Olamaz");

                    }
                    uniqueRefNo = glassesReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                    if (!string.IsNullOrEmpty(glassesReport.ProcedureDoctor.ErecetePassword))
                        password = glassesReport.ProcedureDoctor.ErecetePassword;
                }

                GlassesReport.ReceteSil(glassesReport, uniqueRefNo, password);
                return glassesReport.SonucKodu + " " + glassesReport.SonucAciklamasi;
            }
        }

    }


}

namespace Core.Models
{
    public partial class GlassesReportFormViewModel
    {
        public bool cbxVitrumNearVal;
        public bool cbxVitrumFarVal;
        public bool cbxVitrumCloseReadingVal;
        public bool stateToComplete;
        public bool stateToNew;
        public string medulaUsername { get; set; }
        public string medulaPassword { get; set; }
    }

    public partial class OldGlassesReport
    {
        public Guid ObjectId { get; set; }
        public DateTime ActionDate { get; set; }
        public string GlassesReportNo { get; set; }
        public string currentState { get; set; }

    }



}