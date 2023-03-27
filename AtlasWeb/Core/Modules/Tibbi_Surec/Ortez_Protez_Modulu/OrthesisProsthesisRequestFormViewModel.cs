//$A8F585FE
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using TTStorageManager.Security;
using Core.Security;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class OrthesisProsthesisRequestServiceController
    {
        partial void PreScript_OrthesisProsthesisRequestForm(OrthesisProsthesisRequestFormViewModel viewModel, OrthesisProsthesisRequest orthesisProsthesisRequest, TTObjectContext objectContext)
        {
            if (((ITTObject)orthesisProsthesisRequest).IsNew)
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    viewModel._OrthesisProsthesisRequest.MasterAction = episodeAction;
                    viewModel._OrthesisProsthesisRequest.SetMyPropertiesByMasterAction(episodeAction);
                    viewModel._OrthesisProsthesisRequest.ProcedureSpeciality = episodeAction.ProcedureSpeciality;
                    viewModel.RequesterUnit = episodeAction.MasterResource.Name;
                    viewModel.RequesterUserName = TTUser.CurrentUser.FullName;
                    orthesisProsthesisRequest.RequesterUsr = TTUser.CurrentUser.UserID;

                    //eğer açık bir ortezprotez subepisode u varsa onu al
                    foreach (var item in episodeAction.Episode.SubEpisodes)
                    {
                        if (item.CurrentStateDefID != SubEpisode.States.Cancelled && item.StarterEpisodeAction is OrthesisProsthesisRequest)
                        {
                            if (item.OpenSubEpisodeProtocol != null)
                                orthesisProsthesisRequest.SubEpisode = item;
                        }
                    }

                    if (orthesisProsthesisRequest.Episode.Diagnosis.Count == 0)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25312", "Bu işlem herhangi bir tanısı olmayan episotlarda başlatılamaz."));

                    if (!(episodeAction is InPatientPhysicianApplication || episodeAction is NursingApplication || episodeAction is InPatientTreatmentClinicApplication || (episodeAction is PatientExamination /*&& episodeAction.CurrentStateDefID != PatientExamination.States.Examination*/)))
                        throw new Exception(episodeAction.ObjectDef.ApplicationName + " işleminden Ortez/Protez işlemi başlatılamaz");
                    if (episodeAction.SubEpisode.IsInvoicedCompletely)
                        throw new Exception("Bu gelişin faturası kesildiği için Ortez/Protez işlemi başlatılamaz");
                    if((episodeAction is InPatientPhysicianApplication || episodeAction is NursingApplication || episodeAction is InPatientTreatmentClinicApplication) 
                        && (episodeAction.SubEpisode.InpatientStatus == InpatientStatusEnum.Discharged || episodeAction.SubEpisode.InpatientStatus == InpatientStatusEnum.Predischarged || episodeAction.SubEpisode.InpatientStatus == InpatientStatusEnum.TransferToOtherClinic))
                        throw new Exception("Taburcu/Öntaburcu ve transfer olan hastalar için için Ortez/Protez işlemi başlatılamaz");
                }
            }
            else
            {
                viewModel.RequesterUnit = viewModel._OrthesisProsthesisRequest.FromResource.Name;

                if (orthesisProsthesisRequest.RequesterUsr == null)
                {
                    var usr = ((TTObject)orthesisProsthesisRequest).GetState("Request", false);

                    if (usr != null)
                    {
                        orthesisProsthesisRequest.RequesterUsr = usr.UserID;
                        viewModel.RequesterUserName = usr.User.FullName;
                    }
                    else
                    {
                        viewModel.RequesterUserName = TTUser.CurrentUser.FullName;
                        orthesisProsthesisRequest.RequesterUsr = TTUser.CurrentUser.UserID;
                    }
                }
                else
                {
                    TTUser usr = TTUser.GetUser(orthesisProsthesisRequest.RequesterUsr.Value);
                    viewModel.RequesterUserName = usr.FullName;
                }

                int index = 0;
                foreach (OrthesisProsthesisProcedure opp in orthesisProsthesisRequest.OrthesisProsthesisProcedures)
                {
                    if (orthesisProsthesisRequest.OrthesisProsthesisProcedures[index] != null)
                        opp.Price = ((SubActionProcedure)(orthesisProsthesisRequest.OrthesisProsthesisProcedures[index])).GetProcedurePrice();

                    index++;
                    //SubActionProcedure sp = (SubActionProcedure)objectContext.GetObject((Guid)opp.ObjectID, "SubActionProcedure");
                    //if (sp != null)
                    //{
                    //    if (sp.GetProcedurePrice() != null)
                    //    {
                    //        opp.Price = (double)sp.GetProcedurePrice();
                    //    }
                    //}
                }
            }
            //giriş yapan kullanıcıyı ve servisini set eder
            //orthesisProsthesisRequest.SetProcedureDoctorAsCurrentResource();// istemi yapan doktor olarak ilk episode doktorunu istediler

            if (orthesisProsthesisRequest.ProcedureDoctor == null)//ilk episodeun doktorunu at
                orthesisProsthesisRequest.ProcedureDoctor = orthesisProsthesisRequest.SubEpisode.StarterEpisodeAction.ProcedureDoctor;

            //hastanın borcu var mı yok mu ekrana basmak için
            viewModel.HasDebt = orthesisProsthesisRequest.Paid();

            if (viewModel._OrthesisProsthesisRequest.PrevState != null)
                viewModel.prevStateID = viewModel._OrthesisProsthesisRequest.PrevState.StateDefID.ToString();

            ArrangeButtons(viewModel);

            ContextToViewModel(viewModel, objectContext);

        }

        partial void PostScript_OrthesisProsthesisRequestForm(OrthesisProsthesisRequestFormViewModel viewModel, OrthesisProsthesisRequest orthesisProsthesisRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //orthesisProsthesisRequest.OrthesisProsthesisProcedures[0]
            foreach (OrthesisProsthesisProcedure item in orthesisProsthesisRequest.OrthesisProsthesisProcedures)
            {
                if (item.ActionDate == null)
                    item.ActionDate = orthesisProsthesisRequest.ActionDate;
            }

            // TODO : İsmail
            if (orthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.States.Request)
            {
                orthesisProsthesisRequest.SubEpisode.ArrangeMeOrCreateNewSubEpisode(orthesisProsthesisRequest, false, false);
            }

            //ArrangeButtons(viewModel);

            //if (transDef != null && transDef.FromStateDefID == OrthesisProsthesisRequest.States.TechnicianSelection && transDef.ToStateDefID == OrthesisProsthesisRequest.States.Procedure && orthesisProsthesisRequest.AuthorizedUsers == null)
            //{
            //    AuthorizedUser au = new AuthorizedUser();
            //    au.User = orthesisProsthesisRequest.OrthesisProsthesisProcedures[0].Technician;//bu aşamada actionlar ayrıldığı için sadece kendisi kalmış olmalı
            //    orthesisProsthesisRequest.AuthorizedUsers.Add(au);
            //}
        }

        public void ArrangeButtons(OrthesisProsthesisRequestFormViewModel viewModel)
        {
            List<TTObjectStateTransitionDef> removedOutgoingTransitions = new List<TTObjectStateTransitionDef>();
            foreach (var trans in viewModel.OutgoingTransitions)
            {
                if (trans.ToStateDefID == OrthesisProsthesisRequest.States.RequestAcception)
                    removedOutgoingTransitions.Add(trans);
                else if (trans.ToStateDefID == OrthesisProsthesisRequest.States.FinancialDepartmentControl)
                    removedOutgoingTransitions.Add(trans);
                else if (trans.ToStateDefID == OrthesisProsthesisRequest.States.Appointment)
                    removedOutgoingTransitions.Add(trans);
                else if (trans.ToStateDefID == OrthesisProsthesisRequest.States.DoctorApproval)
                    removedOutgoingTransitions.Add(trans);
                else if (trans.ToStateDefID == OrthesisProsthesisRequest.States.FinancialDepartmentRejected)
                    removedOutgoingTransitions.Add(trans);
                else if (trans.ToStateDefID == OrthesisProsthesisRequest.States.HealthCommittee)
                    removedOutgoingTransitions.Add(trans);
                else if (trans.ToStateDefID == OrthesisProsthesisRequest.States.HealthCommitteeApproval)
                    removedOutgoingTransitions.Add(trans);
                else if (trans.ToStateDefID == OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialist)
                    removedOutgoingTransitions.Add(trans);
                else if (trans.ToStateDefID == OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialistApproval)
                    removedOutgoingTransitions.Add(trans);
            }

            foreach (var removedtrans in removedOutgoingTransitions)
            {
                viewModel.OutgoingTransitions.Remove(removedtrans);
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public double? GetProceduresPrice(string ProcedureDefID, string ActionID, string ReqDate)
        {
            TTObjectContext objectContext = new TTObjectContext(true);

            ProcedureDefinition pi =(ProcedureDefinition)objectContext.GetObject(new Guid(ProcedureDefID), "ProcedureDefinition");

            EpisodeAction ea = (EpisodeAction)objectContext.GetObject(new Guid(ActionID), "EpisodeAction");

            if (ea.SubEpisode != null)
            {
                if (ea.SubEpisode.OpenSubEpisodeProtocol != null)
                {
                    if (pi.GetProcedurePrice(ea.SubEpisode.OpenSubEpisodeProtocol, Convert.ToDateTime(ReqDate)) != null)
                    {
                        return (double)pi.GetProcedurePrice(ea.SubEpisode.OpenSubEpisodeProtocol, Convert.ToDateTime(ReqDate));
                    }
                    return null;
                }
                else
                    return null;
            }
            else
                return null;


            //SubActionProcedure sp = (SubActionProcedure)objectContext.GetObject(new Guid(ObjectID), "SubActionProcedure");

            //if (sp != null)
            //{
            //    if (sp.GetProcedurePrice() != null)
            //        return (double)sp.GetProcedurePrice();
            //    else
            //        return null;
            //}
            //else
            //    return null;
        }

        [HttpGet]
        public string GetLastActiveOrthesisProthesisRequestObjectId(string EpisodeID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (EpisodeID != null)
                {
                    var GetLastActiveOrthesisProthesisRequestList = OrthesisProsthesisRequest.GetLastActiveOrthesisProthesisRequest(objectContext, new Guid(EpisodeID));
                    foreach (var orthesisProthesisRequest in GetLastActiveOrthesisProthesisRequestList)
                    {
                        return orthesisProthesisRequest.ObjectID.ToString();
                    }
                }
            }
            return null;
        }
    }
}

namespace Core.Models
{
    public partial class OrthesisProsthesisRequestFormViewModel
    {
        public bool HasDebt{ get; set; }
        public string prevStateID { get; set; }
        public string RequesterUnit { get; set; }//istem yapan birim
        public string RequesterUserName { get; set; }
    }
}
