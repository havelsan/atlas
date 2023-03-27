//$C7D2BC29
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
    public partial class VaccineDetailsServiceController : Controller
{
    [HttpGet]
    public VaccineApplicationFormViewModel VaccineApplicationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return VaccineApplicationFormLoadInternal(input);
    }

    [HttpPost]
    public VaccineApplicationFormViewModel VaccineApplicationFormLoad(FormLoadInput input)
    {
        return VaccineApplicationFormLoadInternal(input);
    }

    private VaccineApplicationFormViewModel VaccineApplicationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("8c81a686-19fc-47a1-9c10-16fd0dad3f70");
        var objectDefID = Guid.Parse("968cc060-19c5-4acf-ac01-da233190af10");
        var viewModel = new VaccineApplicationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._VaccineDetails = objectContext.GetObject(id.Value, objectDefID) as VaccineDetails;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._VaccineDetails, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._VaccineDetails, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._VaccineDetails);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._VaccineDetails);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_VaccineApplicationForm(viewModel, viewModel._VaccineDetails, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._VaccineDetails = new VaccineDetails(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._VaccineDetails, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._VaccineDetails, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._VaccineDetails);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._VaccineDetails);
                PreScript_VaccineApplicationForm(viewModel, viewModel._VaccineDetails, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel VaccineApplicationForm(VaccineApplicationFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("8c81a686-19fc-47a1-9c10-16fd0dad3f70");
        using (var objectContext = new TTObjectContext(false))
        {

            objectContext.AddToRawObjectList(viewModel.SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtkis);
            objectContext.AddToRawObjectList(viewModel.SKRSKurumlars);
            objectContext.AddToRawObjectList(viewModel.SKRSASIISLEMTURUs);
            objectContext.AddToRawObjectList(viewModel.SKRSAsiOzelDurumNedenis);
            objectContext.AddToRawObjectList(viewModel.SKRSAsiKodus);
            objectContext.AddToRawObjectList(viewModel.SKRSAsininDozus);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.SKRSAsininUygulamaSeklis);
            objectContext.AddToRawObjectList(viewModel.SKRSAsiUygulamaYeris);
            objectContext.AddToRawObjectList(viewModel.SKRSAsiYapilmamaNedenis);
            objectContext.AddToRawObjectList(viewModel.SKRSAsiYapilmamaDurumus);
            objectContext.AddToRawObjectList(viewModel.SKRSAsininSaglandigiKaynaks);
            objectContext.AddToRawObjectList(viewModel._VaccineDetails);
            objectContext.ProcessRawObjects();
            var vaccineDetails = (VaccineDetails)objectContext.GetLoadedObject(viewModel._VaccineDetails.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(vaccineDetails, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._VaccineDetails, formDefID);
            var transDef = vaccineDetails.TransDef;
            PostScript_VaccineApplicationForm(viewModel, vaccineDetails, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(vaccineDetails);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(vaccineDetails);
            AfterContextSaveScript_VaccineApplicationForm(viewModel, vaccineDetails, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_VaccineApplicationForm(VaccineApplicationFormViewModel viewModel, VaccineDetails vaccineDetails, TTObjectContext objectContext);
    partial void PostScript_VaccineApplicationForm(VaccineApplicationFormViewModel viewModel, VaccineDetails vaccineDetails, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_VaccineApplicationForm(VaccineApplicationFormViewModel viewModel, VaccineDetails vaccineDetails, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(VaccineApplicationFormViewModel viewModel, TTObjectContext objectContext)
    {
            viewModel.SKRSAsininSaglandigiKaynaks = objectContext.LocalQuery<SKRSAsininSaglandigiKaynak>().ToArray();

            viewModel.SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtkis = objectContext.LocalQuery<SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtki>().ToArray();
        viewModel.SKRSKurumlars = objectContext.LocalQuery<SKRSKurumlar>().ToArray();
        viewModel.SKRSASIISLEMTURUs = objectContext.LocalQuery<SKRSASIISLEMTURU>().ToArray();
        viewModel.SKRSAsiOzelDurumNedenis = objectContext.LocalQuery<SKRSAsiOzelDurumNedeni>().ToArray();
        viewModel.SKRSAsiKodus = objectContext.LocalQuery<SKRSAsiKodu>().ToArray();
        viewModel.SKRSAsininDozus = objectContext.LocalQuery<SKRSAsininDozu>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.SKRSAsininUygulamaSeklis = objectContext.LocalQuery<SKRSAsininUygulamaSekli>().ToArray();
        viewModel.SKRSAsiUygulamaYeris = objectContext.LocalQuery<SKRSAsiUygulamaYeri>().ToArray();
        viewModel.SKRSAsiYapilmamaNedenis = objectContext.LocalQuery<SKRSAsiYapilmamaNedeni>().ToArray();
        viewModel.SKRSAsiYapilmamaDurumus = objectContext.LocalQuery<SKRSAsiYapilmamaDurumu>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAsininSaglandigiKaynakList", viewModel.SKRSAsininSaglandigiKaynaks);

            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtkiList", viewModel.SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtkis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKurumlarList", viewModel.SKRSKurumlars);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSASIISLEMTURUList", viewModel.SKRSASIISLEMTURUs);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAsiOzelDurumNedeniList", viewModel.SKRSAsiOzelDurumNedenis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAsiKoduList", viewModel.SKRSAsiKodus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAsininDozuList", viewModel.SKRSAsininDozus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "NurseListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAsininUygulamaSekliList", viewModel.SKRSAsininUygulamaSeklis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAsiUygulamaYeriList", viewModel.SKRSAsiUygulamaYeris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAsiYapilmamaNedeniList", viewModel.SKRSAsiYapilmamaNedenis);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSAsiYapilmamaDurumuList", viewModel.SKRSAsiYapilmamaDurumus);
    }
}
}


namespace Core.Models
{
    public partial class VaccineApplicationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.VaccineDetails _VaccineDetails { get; set; }
        public TTObjectClasses.SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtki[] SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtkis { get; set; }
        public TTObjectClasses.SKRSKurumlar[] SKRSKurumlars { get; set; }
        public TTObjectClasses.SKRSASIISLEMTURU[] SKRSASIISLEMTURUs { get; set; }
        public TTObjectClasses.SKRSAsiOzelDurumNedeni[] SKRSAsiOzelDurumNedenis { get; set; }
        public TTObjectClasses.SKRSAsiKodu[] SKRSAsiKodus { get; set; }
        public TTObjectClasses.SKRSAsininDozu[] SKRSAsininDozus { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.SKRSAsininUygulamaSekli[] SKRSAsininUygulamaSeklis { get; set; }
        public TTObjectClasses.SKRSAsiUygulamaYeri[] SKRSAsiUygulamaYeris { get; set; }
        public TTObjectClasses.SKRSAsiYapilmamaNedeni[] SKRSAsiYapilmamaNedenis { get; set; }
        public TTObjectClasses.SKRSAsiYapilmamaDurumu[] SKRSAsiYapilmamaDurumus { get; set; }
        public TTObjectClasses.SKRSAsininSaglandigiKaynak[] SKRSAsininSaglandigiKaynaks
        {
            get;
            set;
        }
    }
}
