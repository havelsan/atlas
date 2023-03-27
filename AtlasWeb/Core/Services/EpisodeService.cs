using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;

namespace Core.Services
{
    public class EpisodeService
    {
        public void WriteEpisodeRequest(EpisodeRequestInfo request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            using(var objectContext = new TTObjectContext(false))
            {

                var episode = objectContext.GetObject<Episode>(request.EpisodeID);
                if ( episode == null)
                {
                    throw new TTException($"{request.EpisodeID} anahtarı ile kayıtlı bir geliş bulunamadı");
                }

                var requestList = new List<(EpisodeRequestDetailInfo, ProcedureDefinition, ResUser)>();

                foreach(var requestDetail in request.RequestDetails)
                {
                    var procedureObject = objectContext.QueryObjects<ProcedureDefinition>($"CODE = '{requestDetail.ProcedureCode}'")?.FirstOrDefault();
                        
                    if ( procedureObject == null)
                    {
                        throw new TTException($"{requestDetail.ProcedureCode} kodlu işlem kaydı bulunamadı");
                    }

                    var requestDoctor = objectContext.GetObject<ResUser>(requestDetail.RequestDoctor);
                    if (requestDoctor == null)
                    {
                        throw new TTException($"{requestDetail.RequestDoctor} kodlu doktor kaydı bulunamadı");
                    }

                    requestList.Add((requestDetail, procedureObject, requestDoctor));
                }

                var patientAdmission = episode.PatientAdmissions.FirstOrDefault();

                EpisodeAction episodeAction = episode.PatientExaminations.FirstOrDefault();
                if (episodeAction == null)
                    episodeAction = episode.HealthCommittees.FirstOrDefault();

                SubEpisode subEpisode = episode.LastSubEpisode;
                if ( subEpisode == null)
                {
                    subEpisode = new SubEpisode(objectContext);
                    subEpisode.Episode = episode;
                    subEpisode.PatientStatus = SubEpisodeStatusEnum.Outpatient;
                    subEpisode.ResSection = episodeAction.GetSubEpisodeResSection();
                    subEpisode.PatientAdmission = patientAdmission;
                }

                foreach(var newRequest in requestList)
                {
                    var subactionProcedure = new SubActionProcedure(objectContext);
                    subactionProcedure.SubEpisode = subEpisode;
                    subactionProcedure.EpisodeAction = episodeAction;
                    subactionProcedure.ProcedureObject = newRequest.Item2;
                    subactionProcedure.RequestedByUser = newRequest.Item3;
                    subactionProcedure.ActionDate = newRequest.Item1.RequestDate;
                    subactionProcedure.Amount = newRequest.Item1.Quantity;

                    episode.SubActionProcedures.Add(subactionProcedure);
                }

                objectContext.Save();
            }
        }
    }
}
