//$638798C2
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
    public partial class LaboratoryTestDefinitionServiceController
    {
        partial void PreScript_LaboratoryTestDefinitionNewForm(LaboratoryTestDefinitionNewFormViewModel viewModel, LaboratoryTestDefinition laboratoryTestDefinition, TTObjectContext objectContext)
        {            
            var _imported = objectContext.GetObject<LaboratoryTestDefinition>(laboratoryTestDefinition.ObjectID);
            objectContext.LoadFormObjects(new Guid("77d576d2-5ef5-4462-a9ea-da15c2c35966"), laboratoryTestDefinition.ObjectID, new Guid("3d2f1e54-0d74-468f-b931-4c51ac60b090"));
            viewModel.PackageProcedureDefinitions = objectContext.LocalQuery<PackageProcedureDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PackageProcedureListDefinition", viewModel.PackageProcedureDefinitions);

            viewModel.GILDefinitions = objectContext.LocalQuery<GILDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "GILListDefinition", viewModel.GILDefinitions);


            viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureListDefinition", viewModel.ProcedureDefinitions);

            viewModel.GridSubProceduresGridList = viewModel._LaboratoryTestDefinition.SubProcedureDefinitions.OfType<SubProcedureDefinition>().ToArray();

            viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
            viewModel.GridRequiredDiagnosisGridList = viewModel._LaboratoryTestDefinition.RequiredDiagnoseProcedures.OfType<RequiredDiagnoseProcedure>().ToArray();

        }

        partial void PostScript_LaboratoryTestDefinitionNewForm(LaboratoryTestDefinitionNewFormViewModel viewModel, LaboratoryTestDefinition laboratoryTestDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            ProcedureDefinitionServiceController procedureDefinitionService = new ProcedureDefinitionServiceController();
            procedureDefinitionService.Global_PostScript(objectContext, viewModel.PackageProcedureDefinitions, viewModel.GridSubProceduresGridList, viewModel.GridRequiredDiagnosisGridList, viewModel._LaboratoryTestDefinition.ObjectID, laboratoryTestDefinition.GetType());

            //objectContext.AddToRawObjectList(viewModel.PackageProcedureDefinitions);
            //objectContext.AddToRawObjectList(viewModel.GridSubProceduresGridList);
            //objectContext.ProcessRawObjects();

            //var procedureDefinition = (LaboratoryTestDefinition)objectContext.GetLoadedObject(viewModel._LaboratoryTestDefinition.ObjectID);

            //if (viewModel.GridSubProceduresGridList != null)
            //{
            //    foreach (var item in viewModel.GridSubProceduresGridList)
            //    {
            //        var subProcedureDefinitionsImported = (SubProcedureDefinition)objectContext.GetLoadedObject(item.ObjectID);
            //        if (((ITTObject)subProcedureDefinitionsImported).IsDeleted)
            //            continue;
            //        subProcedureDefinitionsImported.ParentProcedureDefinition = procedureDefinition;
            //    }
            //}
        }
    }
}

namespace Core.Models
{
    public partial class LaboratoryTestDefinitionNewFormViewModel: ProcedureFormViewModel
    {
        //public TTObjectClasses.PackageProcedureDefinition[] PackageProcedureDefinitions
        //{
        //    get;
        //    set;
        //}
    }
}
