//$C26A1D79
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
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class RadiologyTestDefinitionServiceController
    {
        partial void PreScript_RadiologyTestDefinitionForm(RadiologyTestDefinitionFormViewModel viewModel, RadiologyTestDefinition radiologyTestDefinition, TTObjectContext objectContext)
        {
            var _imported = objectContext.GetObject<RadiologyTestDefinition>(radiologyTestDefinition.ObjectID);
            objectContext.LoadFormObjects(new Guid("77d576d2-5ef5-4462-a9ea-da15c2c35966"), radiologyTestDefinition.ObjectID, new Guid("3d2f1e54-0d74-468f-b931-4c51ac60b090"));
            viewModel.PackageProcedureDefinitions = objectContext.LocalQuery<PackageProcedureDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PackageProcedureListDefinition", viewModel.PackageProcedureDefinitions);

            viewModel.GILDefinitions = objectContext.LocalQuery<GILDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "GILListDefinition", viewModel.GILDefinitions);


            viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureListDefinition", viewModel.ProcedureDefinitions);

            viewModel.GridSubProceduresGridList = viewModel._RadiologyTestDefinition.SubProcedureDefinitions.OfType<SubProcedureDefinition>().ToArray();

            viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
            viewModel.GridRequiredDiagnosisGridList = viewModel._RadiologyTestDefinition.RequiredDiagnoseProcedures.OfType<RequiredDiagnoseProcedure>().ToArray();

        }

        partial void PostScript_RadiologyTestDefinitionForm(RadiologyTestDefinitionFormViewModel viewModel, RadiologyTestDefinition radiologyTestDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            var dictionary = new Dictionary<string, Object>();
            // Ayný Bölüm Kontrolü
            //for (int i= 0; i < viewModel._RadiologyTestDefinition.Departments.Count; i++) {
            //    string Code = viewModel._RadiologyTestDefinition.Departments[i].Department.Name.ToString();
            //    if (dictionary.ContainsKey(Code))
            //    {
            //        throw new Exception("Ayný Bölüm eklenmiþ!");
            //    }
            //    else
            //    {
            //        dictionary.Add( Code, radiologyTestDefinition);
            //    }
            //}
            //dictionary.Clear();
            //// Ayný Cihaz Kontrolü
            //for (int i = 0; i < viewModel._RadiologyTestDefinition.Equipments.Count; i++) {
            //    string Code = viewModel._RadiologyTestDefinition.Equipments[i].Equipment.Name.ToString();
            //    if (dictionary.ContainsKey(Code))
            //    {
            //        throw new Exception("Ayný Cihaz eklenmiþ!");
            //    }
            //    else
            //    {
            //        dictionary.Add( Code, viewModel);
            //    }
            //}
            //dictionary.Clear();

            if (!(viewModel._RadiologyTestDefinition.TestID != null))
                viewModel._RadiologyTestDefinition.TestID.GetNextValue();

            ProcedureDefinitionServiceController procedureDefinitionService = new ProcedureDefinitionServiceController();
            procedureDefinitionService.Global_PostScript(objectContext, viewModel.PackageProcedureDefinitions, viewModel.GridSubProceduresGridList, viewModel.GridRequiredDiagnosisGridList, viewModel._RadiologyTestDefinition.ObjectID, radiologyTestDefinition.GetType());

            //objectContext.AddToRawObjectList(viewModel.PackageProcedureDefinitions);
            //objectContext.AddToRawObjectList(viewModel.GridSubProceduresGridList);
            //objectContext.ProcessRawObjects();

            ////var a = radiologyTestDefinition.GetType() == typeof(RadiologyTestDefinition) ? true : false;

            ////var procedureDefinition = (RadiologyTestDefinition)objectContext.GetLoadedObject(viewModel._RadiologyTestDefinition.ObjectID);
            //var procedureDefinition = Convert.ChangeType(objectContext.GetLoadedObject(viewModel._RadiologyTestDefinition.ObjectID), radiologyTestDefinition.GetType());

            //if (viewModel.GridSubProceduresGridList != null)
            //{
            //    foreach (var item in viewModel.GridSubProceduresGridList)
            //    {
            //        var subProcedureDefinitionsImported = (SubProcedureDefinition)objectContext.GetLoadedObject(item.ObjectID);
            //        if (((ITTObject)subProcedureDefinitionsImported).IsDeleted)
            //            continue;
            //        subProcedureDefinitionsImported.ParentProcedureDefinition = (ProcedureDefinition)procedureDefinition;
            //    }
            //}
        }
    }
}

namespace Core.Models
{
    public partial class RadiologyTestDefinitionFormViewModel: ProcedureFormViewModel
    {
    }
}
