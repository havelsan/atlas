//$6A511E8C
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

namespace Core.Controllers
{
    public partial class SurgeryExtensionServiceController
    {
        partial void PreScript_SurgeryExtensionForm(SurgeryExtensionFormViewModel viewModel, SurgeryExtension surgeryExtension, TTObjectContext objectContext)
        {

            viewModel.vitalSingsViewModel = surgeryExtension.MainSurgery.GetVitalSingsFormViewModel(objectContext);
            viewModel.MainSurgeryTreatmentMaterialList = new List<Material>();
            if (surgeryExtension.MainSurgery.TreatmentMaterials.Count > 0)
            {
                foreach (var item in surgeryExtension.MainSurgery.TreatmentMaterials)
                {
                    viewModel.MainSurgeryTreatmentMaterialList.Add(item.Material);
                }
            }

            // Doktrun Uzmanlýðýný set etmek için
            var surgeryPersonneSpecilaityList = new List<SurgeryPersonneSpeciality>();
            foreach (var surgeryPersonnel in surgeryExtension.MainSurgery.AllSurgeryPersonnels)
            {
                if (surgeryPersonnel.Personnel != null)
                {
                    if (surgeryPersonneSpecilaityList.FirstOrDefault(dr => dr.userObjectId == surgeryPersonnel.Personnel.ObjectID.ToString()) == null)
                    {
                        var surgeryPersonneSpeciality = new SurgeryPersonneSpeciality();
                        surgeryPersonneSpeciality.userObjectId = surgeryPersonnel.Personnel.ObjectID.ToString();
                        surgeryPersonneSpeciality.specilaityName = surgeryPersonnel.Personnel.GetSpecialityName();
                        surgeryPersonneSpecilaityList.Add(surgeryPersonneSpeciality);

                    }
                }
            }
            viewModel.SurgeryPersonneSpecilaityList = surgeryPersonneSpecilaityList.ToArray();

            if (surgeryExtension.SubEpisode != null && surgeryExtension.SubEpisode.StarterEpisodeAction != null)
            {
                var _InPatientTreatmentClinicApplication = surgeryExtension.SubEpisode.StarterEpisodeAction as InPatientTreatmentClinicApplication;
                viewModel.InpatientPhyAppObjectId = _InPatientTreatmentClinicApplication.InPatientPhysicianApplication.Count > 0 ? _InPatientTreatmentClinicApplication.InPatientPhysicianApplication.FirstOrDefault().ObjectID : Guid.Empty;
            }

            //Ameliyatlar listesine silinmiþ ameliyatlarýn gelmemesi için
            viewModel.GridMainSurgeryProceduresGridList = viewModel.GridMainSurgeryProceduresGridList.Where(c=>c.CurrentStateDefID!=MainSurgeryProcedure.States.Cancelled).ToArray();

            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalýþmamalý
            viewModel.GridSurgeryExpendsGridList = viewModel.GridSurgeryExpendsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
            viewModel.SurgeryExpendsSurgeryExpendGridList = viewModel.SurgeryExpendsSurgeryExpendGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();

        }
        partial void PostScript_SurgeryExtensionForm(SurgeryExtensionFormViewModel viewModel, SurgeryExtension surgeryExtension, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            surgeryExtension.MainSurgery.SetVitalSingsFormViewModel(viewModel.vitalSingsViewModel);
        }
    }
}

namespace Core.Models
{
    public partial class SurgeryExtensionFormViewModel
    {
        public TTObjectClasses.EpisodeAction.VitalSingsFormViewModel vitalSingsViewModel;
        public SurgeryPersonneSpeciality[] SurgeryPersonneSpecilaityList { get; set; }
        public List<Material> MainSurgeryTreatmentMaterialList { get; set; }
        public Guid InpatientPhyAppObjectId { get; set; }//Yatan Hasta ObjectId
    }

    public partial class SurgeryPersonneSpeciality
    {
        public string userObjectId;
        public string specilaityName;

    }
}
