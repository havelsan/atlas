//$F0E9AE31
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class EpisodeActionServiceController : Controller
    {
        [HttpGet]
        public BaseNewDoctorExaminationFormViewModel BaseNewDoctorExaminationForm(Guid? id)
        {
            var FormDefID = Guid.Parse("fb1a6e08-346a-4658-8a1b-2b2082ce4f45");
            var ObjectDefID = Guid.Parse("a9754f35-2998-48c7-80f3-5194f9e678a7");
            var viewModel = new BaseNewDoctorExaminationFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._EpisodeAction = objectContext.GetObject(id.Value, ObjectDefID) as EpisodeAction;
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                //using (var objectContext = new TTObjectContext(false))
                //{
                //    viewModel._EpisodeAction = new EpisodeAction(objectContext);
                //}
            }

            return viewModel;
        }

        [HttpPost]
        public void BaseNewDoctorExaminationForm(BaseNewDoctorExaminationFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(viewModel._EpisodeAction);
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public class BaseNewDoctorExaminationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.EpisodeAction _EpisodeAction
        {
            get;
            set;
        }

        public ISpecialityBasedObjectViewModel[] SpecialityBasedObjectViewModels
        {
            get;
            set;
        }

        public IENabizViewModel[] ENabizViewModels
        {
            get; set;
        }

        public Boolean hasSpecialityBasedObject
        {
            get; set;
        }

        public Boolean hasWomanSpecialityBasedObject
        {
            get; set;
        }

        public List<SpecialityBasedObject> SpecialityBasedObjectList
        {
            get;
            set;
        }
        public String procedureSpecialityName
        {
            get; set;
        }

        public TTObjectClasses.BaseTreatmentMaterial[] NewGridTreatmentMaterialsGridList
        {
            get;
            set;
        }

        public List<SubEpisode> SubEpisodeList
        {
            get; set;
        }

        public List<EpisodeAction> EpisodeActionList
        {
            get; set;
        }

        public bool HasPaidPayerTypeSEPExists { get; set; }
        public bool IsDischarged { get; set; }

        public bool ControlTreatmentMaterialActions(SubActionMaterial material)
        {
            if ( material.EpisodeAction != null
                && (material.EpisodeAction?.ActionType != ActionTypeEnum.InPatientPhysicianApplication || 
                (material.EpisodeAction?.ActionType == ActionTypeEnum.InPatientPhysicianApplication
                && (((InPatientPhysicianApplication)material.EpisodeAction)?.InPatientTreatmentClinicApp != null
                && ((InPatientPhysicianApplication)material.EpisodeAction)?.InPatientTreatmentClinicApp?.IsDailyOperation == true))
                || ((InPatientPhysicianApplication)material.EpisodeAction)?.EmergencyIntervention != null
                || ((InPatientPhysicianApplication)material.EpisodeAction)?.InPatientTreatmentClinicApp?.IsDailyOperation != true && material.EpisodeAction?.ActionType != ActionTypeEnum.Surgery) 
                && material.EpisodeAction?.ActionType != ActionTypeEnum.TreatmentDischarge
                && material.EpisodeAction?.ActionType != ActionTypeEnum.InPatientTreatmentClinicApplication
                )
            {
                this.SubEpisodeList.Add(material.SubEpisode);
                this.EpisodeActionList.Add(material.EpisodeAction);
                return true;
            }

            else
                return false;
        }

        public void SetHasSpecialityBasedObject(PhysicianApplication physicianApplication)
        {
            hasSpecialityBasedObject = false;
            hasWomanSpecialityBasedObject = false;
            SpecialityBasedObjectList = new List<SpecialityBasedObject>();
            if (physicianApplication is InPatientPhysicianApplication)
            {
                if (physicianApplication.MasterResource is ResWard)
                {
                    ResWard resClinic = physicianApplication.MasterResource as ResWard;
                    if (resClinic.IsIntensiveCare == true)
                    {
                        hasSpecialityBasedObject = true;
                        //if (physicianApplication.SubEpisode.PatientAdmission.IsNewBorn == true)//Yenidoğan Kabulü ise yenidoğan uzmanlığı açılacak
                        //{
                        //    procedureSpecialityName = "Yeni Doğan Yoğun Bakım";
                        //}
                        //else
                        //{
                            procedureSpecialityName = "Yoğun Bakım";
                        //}
                    }
                }//acil uzmnlık tabının yatışta gösterilmesi
                else if (physicianApplication.ProcedureSpeciality != null && physicianApplication.ProcedureSpeciality.SpecialityBasedObjectType != null && physicianApplication.SpecialityBasedObject.Count > 0
                    && physicianApplication.ProcedureSpeciality.SpecialityBasedObjectType == SpecialityBasedObjectEnum.EmergencySpecialityObject )
                {
                    procedureSpecialityName = physicianApplication.ProcedureSpeciality.Name;
                    hasSpecialityBasedObject = true;
                }
            }
            else
            {
                if (physicianApplication.ProcedureSpeciality != null && physicianApplication.ProcedureSpeciality.SpecialityBasedObjectType != null && physicianApplication.SpecialityBasedObject.Count > 0)
                {
                    procedureSpecialityName = physicianApplication.ProcedureSpeciality.Name;
                    hasSpecialityBasedObject = true;
                    if (physicianApplication.ProcedureSpeciality.SpecialityBasedObjectType == SpecialityBasedObjectEnum.WomanSpecialityObject)
                        hasWomanSpecialityBasedObject = true;
                }
            }

            if (hasSpecialityBasedObject == true)
            {
                foreach (SpecialityBasedObject specialityBasedObject in physicianApplication.SpecialityBasedObject)
                {
                    SpecialityBasedObjectList.Add(specialityBasedObject);
                }
            }
        }

        public bool hasOpenEpisodeRole { get; set; }
        public bool hasCloseEpisodeRole { get; set; }
    }

    public class DynamicComponentInfoDVO
    {
        public string ComponentName
        {
            get;
            set;
        }

        public string ModuleName
        {
            get;
            set;
        }

        public string ModulePath
        {
            get;
            set;
        }

        public string objectID
        {
            get;
            set;
        }
    }
}