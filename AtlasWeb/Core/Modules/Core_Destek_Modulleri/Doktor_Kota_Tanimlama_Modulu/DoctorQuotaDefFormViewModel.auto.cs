//$A3597754
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class DoctorQuotaDefinitionServiceController : Controller
{
    [HttpGet]
    public DoctorQuotaDefFormViewModel DoctorQuotaDefForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DoctorQuotaDefFormLoadInternal(input);
    }

    [HttpPost]
    public DoctorQuotaDefFormViewModel DoctorQuotaDefFormLoad(FormLoadInput input)
    {
        return DoctorQuotaDefFormLoadInternal(input);
    }

    private DoctorQuotaDefFormViewModel DoctorQuotaDefFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("3e04dcc7-6f10-4ac3-8ec7-f4e502ccae14");
        var objectDefID = Guid.Parse("77fc82fa-b033-4d93-a825-c362375ed7cf");
        var viewModel = new DoctorQuotaDefFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DoctorQuotaDefinition = objectContext.GetObject(id.Value, objectDefID) as DoctorQuotaDefinition;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DoctorQuotaDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DoctorQuotaDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DoctorQuotaDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DoctorQuotaDefinition);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_DoctorQuotaDefForm(viewModel, viewModel._DoctorQuotaDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DoctorQuotaDefinition = new DoctorQuotaDefinition(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DoctorQuotaDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DoctorQuotaDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DoctorQuotaDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DoctorQuotaDefinition);
                PreScript_DoctorQuotaDefForm(viewModel, viewModel._DoctorQuotaDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DoctorQuotaDefForm(DoctorQuotaDefFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return DoctorQuotaDefFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel DoctorQuotaDefFormInternal(DoctorQuotaDefFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("3e04dcc7-6f10-4ac3-8ec7-f4e502ccae14");
        objectContext.AddToRawObjectList(viewModel.ResPoliclinics);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel._DoctorQuotaDefinition);
        objectContext.ProcessRawObjects();
        var doctorQuotaDefinition = (DoctorQuotaDefinition)objectContext.GetLoadedObject(viewModel._DoctorQuotaDefinition.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(doctorQuotaDefinition, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DoctorQuotaDefinition, formDefID);
        var transDef = doctorQuotaDefinition.TransDef;
        PostScript_DoctorQuotaDefForm(viewModel, doctorQuotaDefinition, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(doctorQuotaDefinition);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(doctorQuotaDefinition);
        AfterContextSaveScript_DoctorQuotaDefForm(viewModel, doctorQuotaDefinition, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_DoctorQuotaDefForm(DoctorQuotaDefFormViewModel viewModel, DoctorQuotaDefinition doctorQuotaDefinition, TTObjectContext objectContext);
    partial void PostScript_DoctorQuotaDefForm(DoctorQuotaDefFormViewModel viewModel, DoctorQuotaDefinition doctorQuotaDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DoctorQuotaDefForm(DoctorQuotaDefFormViewModel viewModel, DoctorQuotaDefinition doctorQuotaDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DoctorQuotaDefFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ResPoliclinics = objectContext.LocalQuery<ResPoliclinic>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PoliclinicsListDefinition", viewModel.ResPoliclinics);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinitionForPA", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class DoctorQuotaDefFormViewModel
    {
        public TTObjectClasses.DoctorQuotaDefinition _DoctorQuotaDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.ResPoliclinic[] ResPoliclinics
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }
    }
}
