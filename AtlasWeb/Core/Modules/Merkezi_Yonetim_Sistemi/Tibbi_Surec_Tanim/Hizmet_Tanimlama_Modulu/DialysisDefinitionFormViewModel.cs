//$58C91E10
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
    public partial class DialysisDefinitionServiceController
    {
        partial void PreScript_DialysisDefinitionForm(DialysisDefinitionFormViewModel viewModel, DialysisDefinition dialysisDefinition, TTObjectContext objectContext)
        {
            var _imported = objectContext.GetObject<DialysisDefinition>(dialysisDefinition.ObjectID);
            objectContext.LoadFormObjects(new Guid("77d576d2-5ef5-4462-a9ea-da15c2c35966"), dialysisDefinition.ObjectID, new Guid("3d2f1e54-0d74-468f-b931-4c51ac60b090"));
            viewModel.PackageProcedureDefinitions = objectContext.LocalQuery<PackageProcedureDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PackageProcedureListDefinition", viewModel.PackageProcedureDefinitions);

            viewModel.GILDefinitions = objectContext.LocalQuery<GILDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "GILListDefinition", viewModel.GILDefinitions);


            viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureListDefinition", viewModel.ProcedureDefinitions);

            viewModel.GridSubProceduresGridList = viewModel._DialysisDefinition.SubProcedureDefinitions.OfType<SubProcedureDefinition>().ToArray();

            viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
            viewModel.GridRequiredDiagnosisGridList = viewModel._DialysisDefinition.RequiredDiagnoseProcedures.OfType<RequiredDiagnoseProcedure>().ToArray();

        }

        partial void PostScript_DialysisDefinitionForm(DialysisDefinitionFormViewModel viewModel, DialysisDefinition dialysisDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            ProcedureDefinitionServiceController procedureDefinitionService = new ProcedureDefinitionServiceController();
            procedureDefinitionService.Global_PostScript(objectContext, viewModel.PackageProcedureDefinitions, viewModel.GridSubProceduresGridList, viewModel.GridRequiredDiagnosisGridList, viewModel._DialysisDefinition.ObjectID, dialysisDefinition.GetType());
        }
    }
}

namespace Core.Models
{
    public partial class DialysisDefinitionFormViewModel: ProcedureFormViewModel
    {
    }
}
