//$34F32406
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
    public partial class EkokardiografiFormObjectServiceController : Controller
{
    [HttpGet]
    public EkokardiografiFormViewModel EkokardiografiForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return EkokardiografiFormLoadInternal(input);
    }

    [HttpPost]
    public EkokardiografiFormViewModel EkokardiografiFormLoad(FormLoadInput input)
    {
        return EkokardiografiFormLoadInternal(input);
    }

    private EkokardiografiFormViewModel EkokardiografiFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("908097eb-6ee1-428b-bda9-2b51aeee7803");
        var objectDefID = Guid.Parse("b657c826-a8e8-48c8-8e42-694b07d45240");
        var viewModel = new EkokardiografiFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._EkokardiografiFormObject = objectContext.GetObject(id.Value, objectDefID) as EkokardiografiFormObject;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EkokardiografiFormObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EkokardiografiFormObject, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._EkokardiografiFormObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._EkokardiografiFormObject);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_EkokardiografiForm(viewModel, viewModel._EkokardiografiFormObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._EkokardiografiFormObject = new EkokardiografiFormObject(objectContext);
                viewModel.EkokardiografiBulgularGridList = new TTObjectClasses.EkokardiografiBulgu[]{};
                viewModel.PulmonerKapakBulgularGridList = new TTObjectClasses.PulmonerKapakBulgu[]{};
                viewModel.TrikuspitKapakBulgularGridList = new TTObjectClasses.TrikuspitKapakBulgu[]{};
                viewModel.AortKapakBulgularGridList = new TTObjectClasses.AortKapakBulgu[]{};
                viewModel.MitralKapakBulgularGridList = new TTObjectClasses.MitralKapakBulgu[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EkokardiografiFormObject, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EkokardiografiFormObject, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._EkokardiografiFormObject);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._EkokardiografiFormObject);
                PreScript_EkokardiografiForm(viewModel, viewModel._EkokardiografiFormObject, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel EkokardiografiForm(EkokardiografiFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return EkokardiografiFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel EkokardiografiFormInternal(EkokardiografiFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("908097eb-6ee1-428b-bda9-2b51aeee7803");
        objectContext.AddToRawObjectList(viewModel.EkokardiografiBulgularGridList);
        objectContext.AddToRawObjectList(viewModel.PulmonerKapakBulgularGridList);
        objectContext.AddToRawObjectList(viewModel.TrikuspitKapakBulgularGridList);
        objectContext.AddToRawObjectList(viewModel.AortKapakBulgularGridList);
        objectContext.AddToRawObjectList(viewModel.MitralKapakBulgularGridList);
        objectContext.AddToRawObjectList(viewModel._EkokardiografiFormObject);
        objectContext.ProcessRawObjects();
        var ekokardiografiFormObject = (EkokardiografiFormObject)objectContext.GetLoadedObject(viewModel._EkokardiografiFormObject.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(ekokardiografiFormObject, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EkokardiografiFormObject, formDefID);
        if (viewModel.EkokardiografiBulgularGridList != null)
        {
            foreach (var item in viewModel.EkokardiografiBulgularGridList)
            {
                var ekokardiografiBulgularImported = (EkokardiografiBulgu)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)ekokardiografiBulgularImported).IsDeleted)
                    continue;
                ekokardiografiBulgularImported.EkokardiografiFormObject = ekokardiografiFormObject;
            }
        }

        if (viewModel.PulmonerKapakBulgularGridList != null)
        {
            foreach (var item in viewModel.PulmonerKapakBulgularGridList)
            {
                var pulmonerKapakBulgularImported = (PulmonerKapakBulgu)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)pulmonerKapakBulgularImported).IsDeleted)
                    continue;
                pulmonerKapakBulgularImported.EkokardiografiFormObject = ekokardiografiFormObject;
            }
        }

        if (viewModel.TrikuspitKapakBulgularGridList != null)
        {
            foreach (var item in viewModel.TrikuspitKapakBulgularGridList)
            {
                var trikuspitKapakBulgularImported = (TrikuspitKapakBulgu)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)trikuspitKapakBulgularImported).IsDeleted)
                    continue;
                trikuspitKapakBulgularImported.EkokardiografiFormObject = ekokardiografiFormObject;
            }
        }

        if (viewModel.AortKapakBulgularGridList != null)
        {
            foreach (var item in viewModel.AortKapakBulgularGridList)
            {
                var aortKapakBulgularImported = (AortKapakBulgu)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)aortKapakBulgularImported).IsDeleted)
                    continue;
                aortKapakBulgularImported.EkokardiografiFormObject = ekokardiografiFormObject;
            }
        }

        if (viewModel.MitralKapakBulgularGridList != null)
        {
            foreach (var item in viewModel.MitralKapakBulgularGridList)
            {
                var mitralKapakBulgularImported = (MitralKapakBulgu)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)mitralKapakBulgularImported).IsDeleted)
                    continue;
                mitralKapakBulgularImported.EkokardiografiFormObject = ekokardiografiFormObject;
            }
        }

        var transDef = ekokardiografiFormObject.TransDef;
        PostScript_EkokardiografiForm(viewModel, ekokardiografiFormObject, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(ekokardiografiFormObject);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(ekokardiografiFormObject);
        AfterContextSaveScript_EkokardiografiForm(viewModel, ekokardiografiFormObject, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_EkokardiografiForm(EkokardiografiFormViewModel viewModel, EkokardiografiFormObject ekokardiografiFormObject, TTObjectContext objectContext);
    partial void PostScript_EkokardiografiForm(EkokardiografiFormViewModel viewModel, EkokardiografiFormObject ekokardiografiFormObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_EkokardiografiForm(EkokardiografiFormViewModel viewModel, EkokardiografiFormObject ekokardiografiFormObject, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(EkokardiografiFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.EkokardiografiBulgularGridList = viewModel._EkokardiografiFormObject.EkokardiografiBulgular.OfType<EkokardiografiBulgu>().ToArray();
        viewModel.PulmonerKapakBulgularGridList = viewModel._EkokardiografiFormObject.PulmonerKapakBulgular.OfType<PulmonerKapakBulgu>().ToArray();
        viewModel.TrikuspitKapakBulgularGridList = viewModel._EkokardiografiFormObject.TrikuspitKapakBulgular.OfType<TrikuspitKapakBulgu>().ToArray();
        viewModel.AortKapakBulgularGridList = viewModel._EkokardiografiFormObject.AortKapakBulgular.OfType<AortKapakBulgu>().ToArray();
        viewModel.MitralKapakBulgularGridList = viewModel._EkokardiografiFormObject.MitralKapakBulgular.OfType<MitralKapakBulgu>().ToArray();
    }
}
}


namespace Core.Models
{
    public partial class EkokardiografiFormViewModel
    {
        public TTObjectClasses.EkokardiografiFormObject _EkokardiografiFormObject
        {
            get;
            set;
        }

        public TTObjectClasses.EkokardiografiBulgu[] EkokardiografiBulgularGridList
        {
            get;
            set;
        }

        public TTObjectClasses.PulmonerKapakBulgu[] PulmonerKapakBulgularGridList
        {
            get;
            set;
        }

        public TTObjectClasses.TrikuspitKapakBulgu[] TrikuspitKapakBulgularGridList
        {
            get;
            set;
        }

        public TTObjectClasses.AortKapakBulgu[] AortKapakBulgularGridList
        {
            get;
            set;
        }

        public TTObjectClasses.MitralKapakBulgu[] MitralKapakBulgularGridList
        {
            get;
            set;
        }
    }
}
