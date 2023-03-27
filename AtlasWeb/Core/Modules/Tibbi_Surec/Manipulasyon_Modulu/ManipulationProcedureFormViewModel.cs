//$8D678E4D
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class ManipulationServiceController
    {
        partial void PreScript_ManipulationProcedureForm(ManipulationProcedureFormViewModel viewModel, Manipulation manipulation, TTObjectContext objectContext)
        {
            var CurrentResource = Common.CurrentResource;
            viewModel.isCurrentUserDoctor = (Common.CurrentDoctor != null);
            viewModel.SetHasManipulationFormBaseObject(manipulation);
            if (manipulation.CurrentStateDefID == Manipulation.States.TechnicianProcedure)
            {
                if (manipulation.Technician == null)
                {
                    if (CurrentResource.UserType == UserTypeEnum.Technician || CurrentResource.UserType == UserTypeEnum.DentalTechnician)
                        manipulation.Technician = CurrentResource;
                }
            }

            if (manipulation.CurrentStateDefID == Manipulation.States.DoctorProcedure || manipulation.CurrentStateDefID == Manipulation.States.ResultEntry)
            {
                if (manipulation.Technician == null)
                {
                    manipulation.SetProcedureDoctorAsCurrentResource();
                }

                if (manipulation.ResponsiblePersonnel == null)
                {
                    if (CurrentResource.UserType == UserTypeEnum.Psychologist)
                        manipulation.ResponsiblePersonnel = CurrentResource;
                }
            }

            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalışmamalı
            viewModel.GridTreatmentMaterialsGridList = viewModel.GridTreatmentMaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
            //ContextToViewModel den sonra çağırılmalı //TANI için
            viewModel.GridEpisodeDiagnosisGridList = manipulation.DiagnosisGrid_PreScript();
            ContextToViewModel(viewModel, objectContext);
        }

        

        partial void PostScript_ManipulationProcedureForm(ManipulationProcedureFormViewModel viewModel, Manipulation manipulation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            
            if (transDef != null)
            {
                if (transDef.FromStateDefID == Manipulation.States.TechnicianProcedure)
                {
                    if (manipulation.Technician == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27088", "Teknisyen bilgisini giriniz!"));
                }

                if (transDef.ToStateDefID == Manipulation.States.ResultEntry)
                {
                    if (manipulation.ManipulationPersonnel.Count < 1)
                    {
                        throw new Exception(SystemMessage.GetMessage(1131));
                    }
                }

                if (transDef.FromStateDefID == Manipulation.States.DoctorProcedure || manipulation.CurrentStateDefID == Manipulation.States.ResultEntry)
                {
                    if (transDef.ToStateDefID == Manipulation.States.Completed)
                    {
                        if (manipulation.ProcedureDoctor == null)
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26940", "Sorumlu doktor bilgisini giriniz!"));
                    }

                    //if (transDef.ToStateDefID != Manipulation.States.Cancelled)
                    //{
                    //    if (manipulation.ManipulationRequest != null && !(manipulation.ManipulationRequest.MasterAction is HealthCommitteeExaminationFromOtherDepartments) && !(manipulation.ManipulationRequest.MasterAction is HealthCommittee))
                    //    {
                    //        if (manipulation.Episode.Diagnosis.Count == 0)
                    //            throw new Exception(SystemMessage.GetMessage(635));
                    //    //else
                    //    //    this.CreateDiagnosisGridFromEpisode();
                    //    }
                    //}
                }
            }
            //TANI için
            manipulation.DiagnosisGrid_PostScript(viewModel.GridEpisodeDiagnosisGridList);

            //HİZMETE ÖZEL EKRANLAR İÇİN
            if (viewModel.ManipulationFormBaseObjectViewModels != null)
            {
                foreach (var manipulationFormBaseObjectViewModel in viewModel.ManipulationFormBaseObjectViewModels)
                {
                    if (manipulationFormBaseObjectViewModel is IManipulationFormBaseObjectViewModel)
                    {
                        ((IManipulationFormBaseObjectViewModel)manipulationFormBaseObjectViewModel).AddManipulationFormBaseObjectViewModelToContext(objectContext);
                        ((IManipulationFormBaseObjectViewModel)manipulationFormBaseObjectViewModel).SetManipulationReport(manipulation);
                    }
                }
            }


        }

        partial void AfterContextSaveScript_ManipulationProcedureForm(ManipulationProcedureFormViewModel viewModel, Manipulation manipulation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            objectContext.Save();
        }
    }
}

namespace Core.Models
{
    public partial class ManipulationProcedureFormViewModel
    {
        public bool isCurrentUserDoctor;
        public IManipulationFormBaseObjectViewModel[] ManipulationFormBaseObjectViewModels
        {
            get;
            set;
        }
        public Boolean hasManipulationFormBaseObject
        {
            get; set;
        }

        public String manipulationFormName
        {
            get; set;
        }

        public void SetHasManipulationFormBaseObject(Manipulation manipulation)
        {
            hasManipulationFormBaseObject = false;

            if (manipulation.ManipulationFormBaseObject != null && manipulation.ManipulationFormBaseObject.Count > 0)
            {
                manipulationFormName = manipulation.ManipulationFormBaseObject[0].ObjectDef.DisplayText;
                hasManipulationFormBaseObject = true;
            }

            //else if (manipulation.ManipulationProcedures != null && manipulation.ManipulationProcedures.Count > 0)
            //{
            //    if(manipulation.ManipulationProcedures[0].ProcedureObject != null)
            //    {
            //        if(manipulation.ManipulationProcedures[0].ProcedureObject is SurgeryDefinition)
            //        {
            //            SurgeryDefinition manipulationProcedureDefinition = (SurgeryDefinition)manipulation.ManipulationProcedures[0].ProcedureObject;
            //            if(manipulationProcedureDefinition.ManipulationFormName != null)
            //            {
            //                if(manipulationProcedureDefinition.ManipulationFormName == ManipulationFormNameEnum.EkokardiografiForm)
            //                {
            //                    EkokardiografiFormObject ekokardiografiFormObject = new EkokardiografiFormObject(manipulation);
            //                    manipulationFormName = ekokardiografiFormObject.ObjectDef.DisplayText;
            //                    hasManipulationFormBaseObject = true;
            //                }
            //                //Yeni eklenecek formlar else if ile altına eklenecek.
            //            }
            //        }

            //    }
            //}
            
        }
    }
}