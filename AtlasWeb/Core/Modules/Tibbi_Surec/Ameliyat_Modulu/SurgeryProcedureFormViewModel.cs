//$CCC6CAEC
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class SurgeryProcedureServiceController
    {

        partial void PreScript_SurgeryProcedureForm(SurgeryProcedureFormViewModel viewModel, SurgeryProcedure surgeryProcedure, TTObjectContext objectContext)
        {
            if (surgeryProcedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
            {
                if (surgeryProcedure.SutPoint == null)
                {
                    surgeryProcedure.SutPoint = surgeryProcedure.ProcedureObject.GetSUTPoint();
                }

                if (surgeryProcedure.ProcedureDoctor == null)
                {
                    ResUser procedureDoctor = null;
                    if (surgeryProcedure is MainSurgeryProcedure)
                        procedureDoctor = ((MainSurgeryProcedure)surgeryProcedure).MainSurgery.ProcedureDoctor;
                    if (surgeryProcedure is SubSurgeryProcedure)
                        procedureDoctor = ((SubSurgeryProcedure)surgeryProcedure).SubSurgery.ProcedureDoctor;
                    if (procedureDoctor != null)
                    {
                        surgeryProcedure.ProcedureDoctor = procedureDoctor;
                    }
                }
                // Sorumlu Cerrah iþlemleri
                viewModel.OnlyOneProcedureDoctor = true;
                if (surgeryProcedure.IsSecondDoctorNeededByGILPoint())
                {
                    var selectedResponsibleDoctorList = new List<ResUser>();
                    viewModel.ResponsibleDoctor_DataSource = ResUser.GetSpecialistDoctorByResource(objectContext, surgeryProcedure.Department.ObjectID).ToArray();
                    viewModel.OnlyOneProcedureDoctor = false;
                    foreach (var surgeryResponsibleDoctor in surgeryProcedure.SurgeryResponsibleDoctors)
                    {
                        selectedResponsibleDoctorList.Add(surgeryResponsibleDoctor.ResponsibleDoctor);
                    }
                    viewModel.SelectedResponsibleDoctorList = selectedResponsibleDoctorList.ToArray();
                }

                viewModel.IsRequiredPathology = false;//Ameliyat hizmeti patoloji gerektiriyor ise patoloji istek yapmaya zorlanacak!
                if (surgeryProcedure.ProcedureObject.PathologyOperationNeeded != null && surgeryProcedure.ProcedureObject.PathologyOperationNeeded == true && surgeryProcedure.SubEpisode != null)
                {
                    var pathologyExist = PathologyRequest.GetPathologyRequestBySubEpisode(surgeryProcedure.SubEpisode.ObjectID.ToString());
                    if (pathologyExist.Count() == 0)
                    {
                        viewModel.IsRequiredPathology = true;
                    }
                }

                ContextToViewModel(viewModel, objectContext);

            }

        }
        partial void PostScript_SurgeryProcedureForm(SurgeryProcedureFormViewModel viewModel, SurgeryProcedure surgeryProcedure, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (surgeryProcedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
            {
                if (transDef == null || transDef.ToStateDefID != SurgeryProcedure.States.Cancelled)
                {
                    string fullErrorString = "";
                    string errorString = "";

                    // Sorumlu Cerrah Kaydetme

                    surgeryProcedure.ArrangeProcedureDoctorAndAddContext(viewModel.OnlyOneProcedureDoctor, viewModel.SelectedResponsibleDoctorList);
                    //if (viewModel.OnlyOneProcedureDoctor)
                    //{
                    //    if (surgeryProcedure.ProcedureDoctor == null)
                    //    {
                    //        errorString = "Sorumlu Cerrah girmediniz \n ";
                    //    }
                    //    var selectedResponsibleDoctorList = new List<ResUser>();
                    //    selectedResponsibleDoctorList.Add(surgeryProcedure.ProcedureDoctor);
                    //    viewModel.SelectedResponsibleDoctorList = selectedResponsibleDoctorList.ToArray();

                    //}
                    //int doctorCount = viewModel.SelectedResponsibleDoctorList.Count();
                    //int oldDoctorCount = surgeryProcedure.SurgeryResponsibleDoctors.Count;

                    //while (doctorCount < oldDoctorCount)
                    //{
                    //    ((ITTObject)surgeryProcedure.SurgeryResponsibleDoctors[oldDoctorCount - 1]).Delete();
                    //    oldDoctorCount--;
                    //}

                    //doctorCount = 0;
                    //oldDoctorCount = surgeryProcedure.SurgeryResponsibleDoctors.Count - 1;
                    //foreach (var responsibleDoctor in viewModel.SelectedResponsibleDoctorList)
                    //{
                    //    if (doctorCount == 0 && !viewModel.OnlyOneProcedureDoctor)
                    //    { surgeryProcedure.ProcedureDoctor = responsibleDoctor; }

                    //    // eskiden girilenin doktor sayýsý yeni girilene eþitse yada büyükse günceller
                    //    if (doctorCount <= oldDoctorCount)
                    //    {
                    //        surgeryProcedure.SurgeryResponsibleDoctors[doctorCount].ResponsibleDoctor = responsibleDoctor;
                    //    }
                    //    else // eskiden girilenin doktor sayýsý yeni girilenden küçükse yeni yaratýr
                    //    {
                    //        SurgeryResponsibleDoctor surgeryResponsibleDoctors = new SurgeryResponsibleDoctor(objectContext);
                    //        surgeryResponsibleDoctors.ResponsibleDoctor = responsibleDoctor;
                    //        surgeryProcedure.SurgeryResponsibleDoctors.Add(surgeryResponsibleDoctors);
                    //    }
                    //    doctorCount++;
                    //}


                    if (surgeryProcedure.ProcedureDoctor == null)
                    {
                        errorString = "Sorumlu Cerrah girmediniz \n ";
                    }

                    if (surgeryProcedure.AyniFarkliKesi == null)
                        errorString = "Kesi Bilgisi girmediniz\n ";
                    if (surgeryProcedure.Position == null)
                        errorString = "Taraf girmediniz\n ";

                    if (surgeryProcedure.IsNeededEuroScoreEmpty() == true)
                    {
                        errorString = "Kardiak Risk Skoru (Euroscore)  girmediniz\n ";
                    }
                    // Sonda kalsýn
                    if (!string.IsNullOrEmpty(errorString))
                    {
                        errorString = surgeryProcedure.ProcedureObject.Name + " ameliyatý için: \n " + errorString;
                        fullErrorString += errorString;
                    }

                    if (fullErrorString != "")
                    {
                        throw new Exception(fullErrorString);
                    }
                    if (surgeryProcedure.IsComplicationSurgery.HasValue == false || (surgeryProcedure.IsComplicationSurgery.HasValue && surgeryProcedure.IsComplicationSurgery.Value == false))
                        surgeryProcedure.ComplicationDescription = String.Empty;
                }
            }
        }

        // Ameliyattan dönen SurgeryProcedurelerin kaydedilmesi için 
        public static void SaveSurgeryProcedureFormViewModelList(TTObjectContext context, SurgeryProcedureFormViewModel[] SurgeryProcedureFormViewModelList)
        {
            SurgeryProcedureServiceController surgeryProcedureServiceController = new SurgeryProcedureServiceController();
            foreach (var surgeryProcedureFormViewModel in SurgeryProcedureFormViewModelList)
            {
                if (!(surgeryProcedureFormViewModel.isNew == true && surgeryProcedureFormViewModel._SurgeryProcedure.CurrentStateDef.Status == StateStatusEnum.Cancelled)) // Yeni eklenen iþlemler iptal edildi ise  kaydedilemez
                    surgeryProcedureServiceController.SaveSurgeryProcedureFormViewModel(context, surgeryProcedureFormViewModel);
            }

            using (var objectContext = new TTObjectContext(false))
            {
                List<SurgeryProcedure> SurgeryList = new List<SurgeryProcedure>();
                foreach (var surgeryProcedureItem in SurgeryProcedureFormViewModelList.Where(x => x._SurgeryProcedure.CurrentStateDefID != SurgeryProcedure.States.Cancelled))
                {
                    var surgeryItem = (SurgeryProcedure)context.GetLoadedObject(surgeryProcedureItem._SurgeryProcedure.ObjectID);
                    SurgeryList.Add(surgeryItem);
                }
                //Ana ameliyat 
                var mainSurgery = SurgeryList.Where(x => x.AyniFarkliKesi.ayniFarkliKesiKodu == "2").FirstOrDefault();

                //Kesi Bilgisi --> farklý klinik kod olan iþlemler
                var differentResourceDoctorList = SurgeryList.Where(x => x.AyniFarkliKesi.ayniFarkliKesiKodu == "4" || x.AyniFarkliKesi.ayniFarkliKesiKodu == "5");
                foreach (var differentResourceDoctor in differentResourceDoctorList)
                {
                    var listMain = mainSurgery.ProcedureDoctor.ResourceSpecialities;
                    var listDifferent = differentResourceDoctor.ProcedureDoctor.ResourceSpecialities;

                    var result = listMain.Where(a => listDifferent.Any(b => a.ObjectID == b.ObjectID));

                    if (result.Count() > 0)
                    {
                        throw new Exception("Ayný branþtaki doktor için kesi bilgisi 'Faklý Klinik Kod' seçilemez!");
                    }
                }
            }
        }
        public void SaveSurgeryProcedureFormViewModel(TTObjectContext objectContext, SurgeryProcedureFormViewModel viewModel)
        {
            var formDefID = Guid.Parse("e53dfd24-4bae-4345-9480-c674ed1611ad");
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.AyniFarkliKesis);
            objectContext.AddToRawObjectList(viewModel.SurgeryResponsibleDoctorsGridList);
            objectContext.AddToRawObjectList(viewModel._SurgeryProcedure);
            objectContext.ProcessRawObjects();

            var surgeryProcedure = (SurgeryProcedure)objectContext.GetLoadedObject(viewModel._SurgeryProcedure.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(surgeryProcedure, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SurgeryProcedure, formDefID);

            if (viewModel.SurgeryResponsibleDoctorsGridList != null)
            {
                foreach (var item in viewModel.SurgeryResponsibleDoctorsGridList)
                {
                    var surgeryResponsibleDoctorsImported = (SurgeryResponsibleDoctor)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)surgeryResponsibleDoctorsImported).IsDeleted)
                        continue;
                    surgeryResponsibleDoctorsImported.SurgeryProcedure = surgeryProcedure;
                }
            }
            var transDef = surgeryProcedure.TransDef;
            PostScript_SurgeryProcedureForm(viewModel, surgeryProcedure, transDef, objectContext);
            // objectContext.Save(); Bunu çaðýran yerde save eliecek
            //AfterContextSaveScript_SurgeryProcedureForm(viewModel, surgeryProcedure, transDef, objectContext); AfterContex save desteklenmiyor çünkü Bunu çaðýran yerde save eliecek

        }

        public static SurgeryProcedureFormViewModel[] GetSurgeryProcedureFormViewModelList(List<SurgeryProcedure> SurgeryProcedureList)
        {
            SurgeryProcedureServiceController surgeryProcedureServiceController = new SurgeryProcedureServiceController();
            List<SurgeryProcedureFormViewModel> surgeryProcedureFormViewModelList = new List<SurgeryProcedureFormViewModel>();

            foreach (var surgeryProcedure in SurgeryProcedureList)
            {
                surgeryProcedureFormViewModelList.Add(surgeryProcedureServiceController.SurgeryProcedureForm(surgeryProcedure.ObjectID));
            }
            return surgeryProcedureFormViewModelList.ToArray();
        }



        [HttpPost]
        public SurgeryProcedureFormViewModel GetNewViewModelByProcedureObject(GetNewViewModelByProcedureObject getNewViewModelByProcedureObject)
        {

            var formDefID = Guid.Parse("e53dfd24-4bae-4345-9480-c674ed1611ad");
            var objectDefID = Guid.Parse("92532fda-beeb-47e4-9dc5-be36a6eabf8a");
            var viewModel = new SurgeryProcedureFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction episodeAction = getNewViewModelByProcedureObject.episodeAction;
                objectContext.AddToRawObjectList(episodeAction);
                var surgery = (EpisodeAction)objectContext.GetLoadedObject(episodeAction.ObjectID);
                SurgeryDefinition surgeryDefinition = (SurgeryDefinition)objectContext.GetObject(getNewViewModelByProcedureObject.surgeryDefinition, "SurgeryDefinition");
                viewModel.isNew = true;
                if (surgery is Surgery)
                {
                    var mainSurgeryProcedure = new MainSurgeryProcedure(objectContext);
                    mainSurgeryProcedure.MainSurgery = (Surgery)surgery;
                    mainSurgeryProcedure.EpisodeAction = (Surgery)surgery;
                    viewModel._SurgeryProcedure = mainSurgeryProcedure;
                }
                else if (surgery is SubSurgery)
                {
                    var subSurgeryProcedure = new SubSurgeryProcedure(objectContext);
                    subSurgeryProcedure.SubSurgery = (SubSurgery)surgery;
                    subSurgeryProcedure.EpisodeAction = ((SubSurgery)surgery).Surgery;
                    viewModel._SurgeryProcedure = subSurgeryProcedure;
                }

                var entryStateID = Guid.Parse("1c28a828-4470-46a5-af69-701b5322df1f");
                viewModel._SurgeryProcedure.CurrentStateDefID = entryStateID;
                viewModel._SurgeryProcedure.ProcedureObject = surgeryDefinition;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SurgeryProcedure, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SurgeryProcedure, formDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_SurgeryProcedureForm(viewModel, viewModel._SurgeryProcedure, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }

            return viewModel;
        }
    }
}

namespace Core.Models
{
    public partial class SurgeryProcedureFormViewModel
    {
        public Boolean isNew;
        public TTObjectClasses.ResUser[] ResponsibleDoctor_DataSource { get; set; }
        public TTObjectClasses.ResUser[] SelectedResponsibleDoctorList { get; set; }
        public List<SurgeryResponsibleDoctor> SurgeryResponsibleDoctorList { get; set; }

        public Boolean OnlyOneProcedureDoctor;
        public Boolean IsRequiredPathology { get; set; }
    }

    public class GetNewViewModelByProcedureObject
    {
        public Guid surgeryDefinition;//SurgeryDefinition 
        public EpisodeAction episodeAction;

    }

}
