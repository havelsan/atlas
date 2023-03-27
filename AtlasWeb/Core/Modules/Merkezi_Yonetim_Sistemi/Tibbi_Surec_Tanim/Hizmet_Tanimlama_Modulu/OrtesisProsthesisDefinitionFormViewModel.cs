//$0004C0E7
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
    public partial class OrtesisProsthesisDefinitionServiceController
    {
        partial void PreScript_OrtesisProsthesisDefinitionForm(OrtesisProsthesisDefinitionFormViewModel viewModel, OrtesisProsthesisDefinition ortesisProsthesisDefinition, TTObjectContext objectContext)
        {
            var _imported = objectContext.GetObject<OrtesisProsthesisDefinition>(ortesisProsthesisDefinition.ObjectID);
            objectContext.LoadFormObjects(new Guid("77d576d2-5ef5-4462-a9ea-da15c2c35966"), ortesisProsthesisDefinition.ObjectID, new Guid("3d2f1e54-0d74-468f-b931-4c51ac60b090"));
            viewModel.PackageProcedureDefinitions = objectContext.LocalQuery<PackageProcedureDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PackageProcedureListDefinition", viewModel.PackageProcedureDefinitions);

            viewModel.GILDefinitions = objectContext.LocalQuery<GILDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "GILListDefinition", viewModel.GILDefinitions);


            viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureListDefinition", viewModel.ProcedureDefinitions);

            viewModel.GridSubProceduresGridList = viewModel._OrtesisProsthesisDefinition.SubProcedureDefinitions.OfType<SubProcedureDefinition>().ToArray();

            viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
            viewModel.GridRequiredDiagnosisGridList = viewModel._OrtesisProsthesisDefinition.RequiredDiagnoseProcedures.OfType<RequiredDiagnoseProcedure>().ToArray();

        }

        partial void PostScript_OrtesisProsthesisDefinitionForm(OrtesisProsthesisDefinitionFormViewModel viewModel, OrtesisProsthesisDefinition ortesisProsthesisDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            ProcedureDefinitionServiceController procedureDefinitionService = new ProcedureDefinitionServiceController();
            procedureDefinitionService.Global_PostScript(objectContext, viewModel.PackageProcedureDefinitions, viewModel.GridSubProceduresGridList, viewModel.GridRequiredDiagnosisGridList, viewModel._OrtesisProsthesisDefinition.ObjectID, ortesisProsthesisDefinition.GetType());
        }
    }
}

namespace Core.Models
{
    public partial class OrtesisProsthesisDefinitionFormViewModel: ProcedureFormViewModel
    {
    }
}
