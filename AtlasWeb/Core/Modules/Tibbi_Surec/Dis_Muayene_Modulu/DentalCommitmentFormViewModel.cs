//$10291B32
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
using System.ComponentModel;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class DentalCommitmentServiceController
    {
        partial void PreScript_DentalCommitmentForm(DentalCommitmentFormViewModel viewModel, DentalCommitment dentalCommitment, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionObjectID.HasValue)
            {
                using (var objectContextLocal = new TTObjectContext(false))
                {
                    if (selectedEpisodeActionObjectID != Guid.Empty)
                    {
                        DentalExamination episodeAction = objectContext.GetObject<DentalExamination>(selectedEpisodeActionObjectID.Value);
                        viewModel.DentalExaminationID = selectedEpisodeActionObjectID.Value;
                        List<DentalCommitment> oldDentalCommitments = DentalCommitment.GetOldDentalCommitments(objectContext, episodeAction.Episode.Patient.ObjectID).ToList();

                        foreach (DentalCommitment oldCommitment in oldDentalCommitments)
                        {
                            if(oldCommitment.ObjectID != dentalCommitment.ObjectID)
                            {
                                OldDentalCommitment commitment = new OldDentalCommitment();
                                commitment.ObjectId = oldCommitment.ObjectID;
                                commitment.commitmentNo = oldCommitment.CommitmentProtocolNo;
                                commitment.dentalCommitmentProstheses = oldCommitment.DentalCommitmentProstethises.ToList();
                                commitment.commitmentDate = oldCommitment.SendDate;
                                foreach (DentalCommitmentProsthesis prosthesis in commitment.dentalCommitmentProstheses)
                                {
                                    commitment.oldCommitments += "Diþ No:" + prosthesis.ToothNo + " Ýþlem:" + prosthesis.DentalProsthesisDefinition.Code + "-" + prosthesis.DentalProsthesisDefinition.Name + "\r\n";
                                }
                                viewModel.oldDentalCommitments.Add(commitment);
                            }
                           
                        }

                        /*if(dentalCommitment.DentalExamination == null || dentalCommitment.DentalExamination.Count == 0)
                        {
                            dentalCommitment.DentalExamination.Add(episodeAction);
                        }*/
                        viewModel.provisionNo = String.IsNullOrEmpty(episodeAction.SubEpisode.LastActiveSubEpisodeProtocolByCloneType.MedulaTakipNo) != true ? episodeAction.SubEpisode.LastActiveSubEpisodeProtocolByCloneType.MedulaTakipNo : "";
                        viewModel._DentalCommitment.CommitmentTakenByName = Common.CurrentResource.Person.Name;
                        viewModel._DentalCommitment.CommitmentTakenBySurname = Common.CurrentResource.Person.Surname;
                        if (episodeAction.Episode.Patient != null)
                        {
                            if (episodeAction.Episode.Patient.MobilePhone != null)
                            {
                                viewModel._DentalCommitment.PhoneNumber = episodeAction.Episode.Patient.MobilePhone;
                            }
                            if (episodeAction.Episode.Patient.Name != null)
                            {
                                viewModel.patientName = episodeAction.Episode.Patient.Name;
                            }
                            if (episodeAction.Episode.Patient.Surname != null)
                            {
                                viewModel.patientSurname = episodeAction.Episode.Patient.Surname;
                            }
                            if (episodeAction.Episode.Patient.UniqueRefNo != null)
                            {
                                viewModel.patientUniqueRefNo = episodeAction.Episode.Patient.UniqueRefNo.ToString();
                            }
                            if (episodeAction.Episode.Patient.BirthDate != null)
                            {
                                viewModel.patientBirthDate = (DateTime)episodeAction.Episode.Patient.BirthDate;
                            }
                            if (episodeAction.Episode.Patient.Sex != null)
                            {
                                viewModel.patientSex = episodeAction.Episode.Patient.Sex.ADI;
                            }
                        }
                    }

                }

            }
            IBindingList dentalProcedures = objectContext.QueryObjects("DentalProsthesisDefinition", "ISACTIVE = 1", "NAME");
            foreach (DentalProsthesisDefinition p in dentalProcedures)
                viewModel.dentalProcedures.Add(p);

        }

        partial void PostScript_DentalCommitmentForm(DentalCommitmentFormViewModel viewModel, DentalCommitment dentalCommitment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionObjectID.HasValue)
            {
                using (var objectContextLocal = new TTObjectContext(false))
                {
                    if (selectedEpisodeActionObjectID != Guid.Empty)
                    {
                        DentalExamination episodeAction = objectContext.GetObject<DentalExamination>(selectedEpisodeActionObjectID.Value);
                        if (episodeAction.DentalCommitment == null)
                        {
                            episodeAction.DentalCommitment = dentalCommitment;
                        }

                    }


                }

            }
        }

    }
}

namespace Core.Models
{
    public partial class DentalCommitmentFormViewModel : BaseViewModel
    {
        public List<DentalProsthesisDefinition> dentalProcedures = new List<DentalProsthesisDefinition>();
        public string provisionNo { get; set; }
        public string patientName { get; set; }
        public string patientSurname { get; set; }
        public string patientUniqueRefNo { get; set; }
        public DateTime patientBirthDate { get; set; }
        public string patientSex { get; set; }
        public Guid DentalExaminationID { get; set; }
        public List<OldDentalCommitment> oldDentalCommitments = new List<OldDentalCommitment>();
    }

    public class OldDentalCommitment
    {
        public Guid ObjectId { get; set; }
        public string commitmentNo { get; set; }
        public List<DentalCommitmentProsthesis> dentalCommitmentProstheses = new List<DentalCommitmentProsthesis>();
        public string oldCommitments { get; set; }
        public DateTime? commitmentDate { get; set; }
    }
}
