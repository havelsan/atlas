//$CB0A6F1B
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
    public partial class BloodBankTestDefinitionServiceController
    {

        partial void PreScript_BloodBankTestDefinitionForm(BloodBankTestDefinitionFormViewModel viewModel, BloodBankTestDefinition bloodBankTestDefinition, TTObjectContext objectContext)
        {
            var _imported = objectContext.GetObject<BloodBankTestDefinition>(bloodBankTestDefinition.ObjectID);
            objectContext.LoadFormObjects(new Guid("77d576d2-5ef5-4462-a9ea-da15c2c35966"), bloodBankTestDefinition.ObjectID, new Guid("3d2f1e54-0d74-468f-b931-4c51ac60b090"));
            viewModel.PackageProcedureDefinitions = objectContext.LocalQuery<PackageProcedureDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PackageProcedureListDefinition", viewModel.PackageProcedureDefinitions);

            viewModel.GILDefinitions = objectContext.LocalQuery<GILDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "GILListDefinition", viewModel.GILDefinitions);


            viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureListDefinition", viewModel.ProcedureDefinitions);

            viewModel.GridSubProceduresGridList = viewModel._BloodBankTestDefinition.SubProcedureDefinitions.OfType<SubProcedureDefinition>().ToArray();

            viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
            viewModel.GridRequiredDiagnosisGridList = viewModel._BloodBankTestDefinition.RequiredDiagnoseProcedures.OfType<RequiredDiagnoseProcedure>().ToArray();

        }

        partial void PostScript_BloodBankTestDefinitionForm(BloodBankTestDefinitionFormViewModel viewModel, BloodBankTestDefinition bloodBankTestDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            ProcedureDefinitionServiceController procedureDefinitionService = new ProcedureDefinitionServiceController();
            procedureDefinitionService.Global_PostScript(objectContext, viewModel.PackageProcedureDefinitions, viewModel.GridSubProceduresGridList, viewModel.GridRequiredDiagnosisGridList, viewModel._BloodBankTestDefinition.ObjectID, bloodBankTestDefinition.GetType());
        }
    }
}

namespace Core.Models
{
    public partial class BloodBankTestDefinitionFormViewModel: ProcedureFormViewModel
    {
    }
}
