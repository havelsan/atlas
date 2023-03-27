//$7A60DDFA
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
    public partial class MedicalWasteServiceController : Controller
{
    [HttpGet]
    public MeicalWasteFormViewModel MeicalWasteForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return MeicalWasteFormLoadInternal(input);
    }

    [HttpPost]
    public MeicalWasteFormViewModel MeicalWasteFormLoad(FormLoadInput input)
    {
        return MeicalWasteFormLoadInternal(input);
    }

    private MeicalWasteFormViewModel MeicalWasteFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("4c1c5337-3823-4e21-a39f-b12ce64c1577");
        var objectDefID = Guid.Parse("d1d8ac3a-f4a9-4030-a847-6ead3cc1e897");
        var viewModel = new MeicalWasteFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MedicalWaste = objectContext.GetObject(id.Value, objectDefID) as MedicalWaste;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MedicalWaste, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalWaste, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MedicalWaste);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MedicalWaste);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_MeicalWasteForm(viewModel, viewModel._MedicalWaste, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MedicalWaste = new MedicalWaste(objectContext);
                var entryStateID = Guid.Parse("64c5e121-820b-4014-ba99-e2eb7bc174eb");
                viewModel._MedicalWaste.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MedicalWaste, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalWaste, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._MedicalWaste);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._MedicalWaste);
                PreScript_MeicalWasteForm(viewModel, viewModel._MedicalWaste, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel MeicalWasteForm(MeicalWasteFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return MeicalWasteFormInternal(viewModel, objectContext);
        }
    }

    [HttpPost]
    public void SaveWasteForm(SaveModel viewModel)
    {
        TTObjectContext objectContext = new TTObjectContext(false);
        MedicalWaste medicalWaste = new MedicalWaste(objectContext);
        medicalWaste.Amount = Double.Parse(viewModel.v01agirlik);
        //medicalWaste.DeliveryDate = Convert.ToDateTime(viewModel.v14tarih + " " + viewModel.v15saat); //, "dd.MM.yyyy hh24:mm");
        medicalWaste.TransactionDate = Common.RecTime();
        medicalWaste.CurrentStateDefID = MedicalWaste.States.New;
        var resSectionGuid = new Guid(viewModel.birim);
        ResSection resSection = (ResSection)objectContext.GetObject(resSectionGuid, "ResSection");
        if (resSection != null)
        {
            medicalWaste.ResSection = resSection;
            objectContext.Save();
        }
        else
        {
            //TODO: log a yazdıralım
            throw new Exception("İlgili birim (ResSection) bulunamadı!");
        }
    }

    internal BaseViewModel MeicalWasteFormInternal(MeicalWasteFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("4c1c5337-3823-4e21-a39f-b12ce64c1577");
        objectContext.AddToRawObjectList(viewModel.MedicalWasteProduceDefinitions);
        objectContext.AddToRawObjectList(viewModel.MedicalWasteTypeDefinitions);
        objectContext.AddToRawObjectList(viewModel.ResSections);
        var entryStateID = Guid.Parse("64c5e121-820b-4014-ba99-e2eb7bc174eb");
        objectContext.AddToRawObjectList(viewModel._MedicalWaste, entryStateID);
        objectContext.ProcessRawObjects(false);
        var medicalWaste = (MedicalWaste)objectContext.GetLoadedObject(viewModel._MedicalWaste.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(medicalWaste, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalWaste, formDefID);
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(medicalWaste);
        PostScript_MeicalWasteForm(viewModel, medicalWaste, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(medicalWaste);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(medicalWaste);
        AfterContextSaveScript_MeicalWasteForm(viewModel, medicalWaste, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_MeicalWasteForm(MeicalWasteFormViewModel viewModel, MedicalWaste medicalWaste, TTObjectContext objectContext);
    partial void PostScript_MeicalWasteForm(MeicalWasteFormViewModel viewModel, MedicalWaste medicalWaste, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_MeicalWasteForm(MeicalWasteFormViewModel viewModel, MedicalWaste medicalWaste, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(MeicalWasteFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.MedicalWasteProduceDefinitions = objectContext.LocalQuery<MedicalWasteProduceDefinition>().ToArray();
        viewModel.MedicalWasteTypeDefinitions = objectContext.LocalQuery<MedicalWasteTypeDefinition>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MedicalWasteProduceListDefinition", viewModel.MedicalWasteProduceDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MedicalWasteTypeListDefinition", viewModel.MedicalWasteTypeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "EnableResSectionListDefinition", viewModel.ResSections);
    }
}
}


namespace Core.Models
{
    public partial class MeicalWasteFormViewModel
    {
        public TTObjectClasses.MedicalWaste _MedicalWaste
        {
            get;
            set;
        }

        public TTObjectClasses.MedicalWasteProduceDefinition[] MedicalWasteProduceDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.MedicalWasteTypeDefinition[] MedicalWasteTypeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResSection[] ResSections
        {
            get;
            set;
        }
    }

    public class SaveModel
    {

        public string birim
        {
            get;
            set;
        }
        public string v00
        {
            get;
            set;
        }
        public string v01agirlik
        {
            get;
            set;
        }
        public string v02agirlik
        {
            get;
            set;
        }
        public string v07
        {
            get;
            set;
        }
        public string v09
        {
            get;
            set;
        }
        public string v14tarih
        {
            get;
            set;
        }
        public string v15saat
        {
            get;
            set;
        }
        public string v30
        {
            get;
            set;
        }

        public string v31birim
        {
            get;
            set;
        }
    }
}
