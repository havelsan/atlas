//$2EDA082C
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

namespace Core.Controllers
{
    public partial class SurgeryDefinitionServiceController
    {
        partial void PreScript_SurgeryDefinitionForm(SurgeryDefinitionFormViewModel viewModel, SurgeryDefinition surgeryDefinition, TTObjectContext objectContext)
        {
            var _imported = objectContext.GetObject<SurgeryDefinition>(surgeryDefinition.ObjectID);
            objectContext.LoadFormObjects(new Guid("77d576d2-5ef5-4462-a9ea-da15c2c35966"), surgeryDefinition.ObjectID, new Guid("3d2f1e54-0d74-468f-b931-4c51ac60b090"));
            viewModel.PackageProcedureDefinitions = objectContext.LocalQuery<PackageProcedureDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PackageProcedureListDefinition", viewModel.PackageProcedureDefinitions);

            viewModel.GILDefinitions = objectContext.LocalQuery<GILDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "GILListDefinition", viewModel.GILDefinitions);


            viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
            viewModel.GridRequiredDiagnosisGridList = viewModel._SurgeryDefinition.RequiredDiagnoseProcedures.OfType<RequiredDiagnoseProcedure>().ToArray();

            viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialityListDefinition", viewModel.SpecialityDefinitions);
            viewModel.BranchesGridList = viewModel._SurgeryDefinition.RequiredDiagnoseProcedures.OfType<SurgeryBranchDefinition>().ToArray();


            viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureListDefinition", viewModel.ProcedureDefinitions);

            viewModel.GridSubProceduresGridList = viewModel._SurgeryDefinition.SubProcedureDefinitions.OfType<SubProcedureDefinition>().ToArray();

            viewModel.SurgeryDuration = surgeryDefinition.SurgeryDuration;

            if (!string.IsNullOrEmpty(surgeryDefinition.PreInformation))
                 viewModel.PreInformation = surgeryDefinition.PreInformation;
        }

    partial void PostScript_SurgeryDefinitionForm(SurgeryDefinitionFormViewModel viewModel, SurgeryDefinition surgeryDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            ProcedureDefinitionServiceController procedureDefinitionService = new ProcedureDefinitionServiceController();
            procedureDefinitionService.Global_PostScript(objectContext, viewModel.PackageProcedureDefinitions, viewModel.GridSubProceduresGridList,viewModel.GridRequiredDiagnosisGridList, viewModel._SurgeryDefinition.ObjectID, surgeryDefinition.GetType());

            if (surgeryDefinition.IsAdditionalApplication == null)
                surgeryDefinition.IsAdditionalApplication = false;

            if (surgeryDefinition.IsManipulation == null)
                surgeryDefinition.IsManipulation = false;

            if (surgeryDefinition.IsSurgery == null)
                surgeryDefinition.IsSurgery = false;

            surgeryDefinition.SurgeryDuration = viewModel.SurgeryDuration;

            if (surgeryDefinition.ProcedureType == ProcedureDefGroupEnum.digerIslemBilgileri)//Ek uygulamalar
            {
                if (surgeryDefinition.IsAdditionalApplication.Value && surgeryDefinition.IsManipulation.Value)
                    surgeryDefinition.SurgeryProcedureType = SurgeyProcedureTypeEnum.ManipulationAdditionalApplication;
                else if (surgeryDefinition.IsAdditionalApplication.Value)
                    surgeryDefinition.SurgeryProcedureType = SurgeyProcedureTypeEnum.OnlyAdditionalApplication;
                else if (surgeryDefinition.IsManipulation.Value)
                    surgeryDefinition.SurgeryProcedureType = SurgeyProcedureTypeEnum.OnlyManipulation;
                else
                    throw new Exception("Ýþlem Tipi Alanlarýndan En Az Bir Tanesini Seçmek Zorundasýnýz.");
            }
            else if (surgeryDefinition.ProcedureType == ProcedureDefGroupEnum.ameliyatveGirisimBilgileri)//Ameliyat ve Tetkik
            {
                if (surgeryDefinition.IsSurgery.Value && surgeryDefinition.IsManipulation.Value)
                    surgeryDefinition.SurgeryProcedureType = SurgeyProcedureTypeEnum.SurgeryAndManiplation;
                else if (surgeryDefinition.IsSurgery.Value)
                    surgeryDefinition.SurgeryProcedureType = SurgeyProcedureTypeEnum.OnlySurgery;
                else if (surgeryDefinition.IsManipulation.Value)
                    surgeryDefinition.SurgeryProcedureType = SurgeyProcedureTypeEnum.OnlyManipulation;
                else
                    throw new Exception("Ýþlem Tipi Alanlarýndan En Az Bir Tanesini Seçmek Zorundasýnýz.");
            }

            if(!string.IsNullOrEmpty(viewModel.PreInformation))
                surgeryDefinition.PreInformation = viewModel.PreInformation;

        }
    }
}

namespace Core.Models
{
    public partial class SurgeryDefinitionFormViewModel: ProcedureFormViewModel
    {
        public int? SurgeryDuration { get; set; }
        public string PreInformation { get; set; }
    }
}
