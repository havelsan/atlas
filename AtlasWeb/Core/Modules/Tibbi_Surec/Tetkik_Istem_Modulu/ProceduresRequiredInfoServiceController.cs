using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using TTObjectClasses;
using TTInstanceManagement;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Filters;

namespace Core.Modules.Tibbi_Surec.Tetkik_Istem_Modulu
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]

    public class ProceduresRequiredInfoServiceController : Controller
    {

        [HttpPost]
        public ProceduresRequiredInfoViewModel GetProceduresRequiredInfoViewModel(List<Guid> requestedProcedureList)
        {

            TTObjectContext objContext = new TTObjectContext(true);
            var proceduresRequiredInfoViewModel = new ProceduresRequiredInfoViewModel();
            foreach (Guid reqId in requestedProcedureList)
            {
                SubActionProcedure sp = (SubActionProcedure)objContext.GetObject(reqId, "SubActionProcedure");
                if (sp is RadiologyTest)
                {
                    if (((RadiologyTestDefinition)sp.ProcedureObject).TestType != null)
                    {
                        if ((((RadiologyTestDefinition)sp.ProcedureObject).TestType.Name == "CR" && sp.ProcedureObject.IsDescriptionNeeded == true) || ((RadiologyTestDefinition)sp.ProcedureObject).TestType.Name != "CR")
                        {
                                proceduresRequiredInfoViewModel.RadiologyTestList.Add((RadiologyTest)sp);
                        }
                   
                    }
                }
                else if (sp is LaboratoryProcedure)
                    proceduresRequiredInfoViewModel.LaboratoryTestList.Add((LaboratoryProcedure)sp);
                else if (sp is PsychologyTest)
                    proceduresRequiredInfoViewModel.PsychologyProcedureList.Add((PsychologyTest)sp);
                else if (sp is PathologyTestProcedure)
                    proceduresRequiredInfoViewModel.PathologyProcedureList.Add((PathologyTestProcedure)sp);
                else if (sp is NuclearMedicineTest)
                    proceduresRequiredInfoViewModel.NuclearMedicineTestList.Add((NuclearMedicineTest)sp);
                else if (sp is ManipulationProcedure)
                    proceduresRequiredInfoViewModel.ManipulationProcedureList.Add((ManipulationProcedure)sp);

                if (sp is RadiologyTest)
                    proceduresRequiredInfoViewModel.RadiologyTestTypeDefinitions.Add(((RadiologyTestDefinition)sp.ProcedureObject).TestType);

                proceduresRequiredInfoViewModel.ProcedureObjectList.Add((ProcedureDefinition)sp.ProcedureObject);
            }

            return proceduresRequiredInfoViewModel;
        }

        //[HttpPost]
        //public ProceduresRequiredInfoViewModel RadiologyTestRequestInfoForm(Guid? id)
        //{
        //    var FormDefID = Guid.Parse("7c029d5d-e9d0-49bf-9037-9d49aa917a60");
        //    var ObjectDefID = Guid.Parse("2cf639c4-5819-4cf4-b295-2594a294c6a0");
        //    var viewModel = new RadiologyTestRequestInfoFormViewModel();
        //    if (id.HasValue && id.Value != Guid.Empty)
        //    {
        //        using (var objectContext = new TTObjectContext(false))
        //        {
        //            objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
        //            viewModel._RadiologyTest = objectContext.GetObject(id.Value, ObjectDefID) as RadiologyTest;
        //            objectContext.FullPartialllyLoadedObjects();
        //        }
        //    }
        //    return viewModel;
        //}
        [HttpPost]
        public List<Guid> SaveProceduresRequiredInfoViewModel(ProceduresRequiredInfoViewModel viewModel)
        {
            List<Guid> episodeActionObjectIDList = new List<Guid>();
            Dictionary<string, string> eaObjectIDDict = new Dictionary<string, string>();

            using (var objectContext = new TTObjectContext(false))
            {
                foreach (RadiologyTest radTest in viewModel.RadiologyTestList)
                {
                    //var radiologyTest = (RadiologyTest)objectContext.AddObject(radTest);

                    var radiologyTest = objectContext.GetObject<RadiologyTest>(radTest.ObjectID);

                    radiologyTest.GeneralDescription = radTest.GeneralDescription;
                    radiologyTest.ContrastType = radTest.ContrastType;


                    if (((ResObservationUnit)radiologyTest.MasterResource).IsExternalObservationUnit == true)
                    {
                        string eaObjectID = "";
                        if (eaObjectIDDict.TryGetValue(radiologyTest.EpisodeAction.ObjectID.ToString(), out eaObjectID) == false)
                        {
                            episodeActionObjectIDList.Add(radiologyTest.EpisodeAction.ObjectID);
                            eaObjectIDDict.Add(radiologyTest.EpisodeAction.ObjectID.ToString(), eaObjectID);
                        }
                    }
                }

                foreach (NuclearMedicineTest nucTest in viewModel.NuclearMedicineTestList)
                {
                    var nuclearTest = (NuclearMedicineTest)objectContext.AddObject(nucTest);
                    ((NuclearMedicine)nuclearTest.EpisodeAction).Description = nuclearTest.GeneralDescription;
                }

                foreach (PsychologyTest psyTest in viewModel.PsychologyProcedureList)
                {
                    var psychologyTest = (PsychologyTest)objectContext.AddObject(psyTest);
                    //psychologyTest.EpisodeAction.ProcedureDoctor = psychologyTest.ProcedureDoctor;            Eski Kod : Mert
                    psychologyTest.EpisodeAction.ProcedureByUser = psychologyTest.ProcedureByUser;
                }

                foreach (PathologyTestProcedure patTest in viewModel.PathologyProcedureList)
                {
                    var pathologyTest = (PathologyTestProcedure)objectContext.AddObject(patTest);
                    pathologyTest.Description = patTest.Description;
                    if (((ResObservationUnit)pathologyTest.EpisodeAction.MasterResource).IsExternalObservationUnit == true)
                    {
                        string eaObjectID = "";
                        if (eaObjectIDDict.TryGetValue(pathologyTest.EpisodeAction.ObjectID.ToString(), out eaObjectID) == false)
                        {
                            episodeActionObjectIDList.Add(pathologyTest.EpisodeAction.ObjectID);
                            eaObjectIDDict.Add(pathologyTest.EpisodeAction.ObjectID.ToString(), eaObjectID);
                        }
                    }

                }
                foreach (ManipulationProcedure mp in viewModel.ManipulationProcedureList)
                {
                    var manipulationProcedure = (ManipulationProcedure)objectContext.AddObject(mp);


                    Manipulation manipulation = (Manipulation)objectContext.GetObject(manipulationProcedure.Manipulation.ObjectID, "Manipulation");

                    ManipulationRequest manipulationRequest = (ManipulationRequest)objectContext.GetObject(manipulation.ManipulationRequest.ObjectID, "ManipulationRequest");


                    manipulationProcedure.ManipulationRequest = manipulationRequest;

                    manipulationRequest.PreInformation = manipulationProcedure.Description;


                }


                objectContext.Save();
            }
            return episodeActionObjectIDList;
        }
    }
}