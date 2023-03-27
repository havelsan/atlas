//$31C95521
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using TTUtils;

namespace Core.Controllers
{
    public partial class SubactionProcedureFlowableServiceController : Controller
    {
        [HttpGet]
        public SubactionProcedureFlowableFormViewModel SubactionProcedureFlowableForm(Guid? id)
        {
            var FormDefID = Guid.Parse("ac5eb99f-f751-4e53-ab2a-c23c3a612df1");
            var ObjectDefID = Guid.Parse("bb5dc227-e1f5-4354-b31e-cfe1bd176fa0");
            var viewModel = new SubactionProcedureFlowableFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._SubactionProcedureFlowable = objectContext.GetObject(id.Value, ObjectDefID) as SubactionProcedureFlowable;
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void SubactionProcedureFlowableForm(SubactionProcedureFlowableFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var subactionProcedureFlowable = (SubactionProcedureFlowable)objectContext.AddObject(viewModel._SubactionProcedureFlowable);
                objectContext.Save();
            }
        }

        [HttpGet]
        public string WarningMessage(string subActionProcedureObjectId)
        {
            string warningMessage = String.Empty;
            using (var objectContext = new TTObjectContext(true))
            {
                Guid id = new Guid(subActionProcedureObjectId);
                BindingList<TTObjectClasses.SubActionProcedure> spList = SubActionProcedure.GetByObjectID(objectContext, subActionProcedureObjectId);
                if (spList.Count > 0)
                {
                    SubactionProcedureFlowable subActionProcedure = (SubactionProcedureFlowable)spList[0]; 
                    if (subActionProcedure != null)
                    {

                        warningMessage += subActionProcedure.SubEpisode.isolationInformation();

                        //if (subActionProcedure.Episode.Patient.IsPatientAllergic())
                        //    warningMessage += "HASTANIN ALERJÝSÝ VAR !" + "\r\n";

                        if (subActionProcedure.SubEpisode.PatientAdmission.ImportantPAInfo != null)
                            warningMessage += subActionProcedure.SubEpisode.PatientAdmission.ImportantPAInfo.ToString() + "\r\n";

                        if (subActionProcedure.SubEpisode.PatientAdmission.AdmissionType.provizyonTipiKodu == "V")
                            warningMessage += "Adli Vaka" + "\r\n";

                        if (subActionProcedure.SubEpisode.HasPaidPayerTypeSEPExists)
                            warningMessage += "Ücretli Hasta" + "\r\n";

                        if (subActionProcedure.Episode.Patient.Nationality != null && subActionProcedure.Episode.Patient.Nationality.Kodu == "SY")
                            warningMessage += "Suriyeli Hasta" + "\r\n";

                        if (subActionProcedure.SubEpisode.SGKSEP != null && String.IsNullOrEmpty(subActionProcedure.SubEpisode.SGKSEP.MedulaTakipNo))
                            warningMessage += "Provizyon Alýnmamýþ Hasta" + "\r\n";

                        if (subActionProcedure.SubEpisode.InpatientStatus != null && subActionProcedure.SubEpisode.InpatientStatus == InpatientStatusEnum.Discharged)
                            warningMessage += "Taburcu Olmuþ Hasta" + "\r\n";

                        if (subActionProcedure.SubEpisode.IsInvoicedCompletely)
                            warningMessage += "Faturasý Kesilmiþ Hasta" + "\r\n";
                    }
                }
            }
            if (!String.IsNullOrEmpty(warningMessage))
                InfoMessageService.Instance.ShowMessage(warningMessage);
            return warningMessage;
        }
    }
}

namespace Core.Models
{
    public class SubactionProcedureFlowableFormViewModel
    {
        public TTObjectClasses.SubactionProcedureFlowable _SubactionProcedureFlowable
        {
            get;
            set;
        }
    }
}