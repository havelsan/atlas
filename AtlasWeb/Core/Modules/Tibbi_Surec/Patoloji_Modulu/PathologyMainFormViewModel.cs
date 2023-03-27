//$06277CC6
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class PathologyServiceController
    {
        partial void PostScript_PathologyMainForm(PathologyMainFormViewModel viewModel, Pathology pathology, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //TANI için
            pathology.DiagnosisGrid_PostScript(viewModel.DiagnosisDiagnosisGridGridList);

            foreach (vmRequestedPathologyProcedure procedure in viewModel._RequestedPathologyProceduresArray)
            {
                var importedMaterial = (PathologyMaterial)objectContext.GetLoadedObject(procedure.MaterialObjectID);
                if (importedMaterial.CurrentStateDefID != PathologyMaterial.States.Reject)
                {
                    if (procedure.SubActionProcedureObjectId == Guid.Empty)
                    {
                        var pathologyTest = new PathologyTestProcedure(objectContext);
                        var pathologyDef = (PathologyTestDefinition)objectContext.GetObject(procedure.ProcedureDefObjectID, "PathologyTestDefinition");
                        pathologyTest.ProcedureObject = pathologyDef;
                        pathologyTest.Amount = procedure.Amount;
                        pathologyTest.EpisodeAction = pathology;
                        pathologyTest.PathologyMaterial = importedMaterial;
                        pathologyTest.PathologyRequest = pathology.PathologyRequest;
                        pathologyTest.ProcedureDoctor = pathology.ProcedureDoctor;
                        pathologyTest.ActionDate = DateTime.Now;
                        pathologyTest.CreationDate = procedure.RequestDate;
                        pathologyTest.CurrentStateDefID = PathologyTestProcedure.States.New;
                    }
                }
             
            }
            objectContext.Save();
        }

        partial void PreScript_PathologyMainForm(PathologyMainFormViewModel viewModel, Pathology pathology, TTObjectContext objectContext)
        {
            viewModel._StateName = pathology.CurrentStateDef.DisplayText;
            viewModel._PatientObjectID = pathology.Episode.Patient.ObjectID.ToString();
            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalýþmamalý
            viewModel.TreatmentMaterialsGridList = viewModel.TreatmentMaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();

            //ContextToViewModel den sonra çaðýrýlmalý //TANI için
            viewModel.DiagnosisDiagnosisGridGridList = pathology.DiagnosisGrid_PreScript();

            if (Common.CurrentUser.HasRole(TTRoleNames.Patoloji_Uzmani) == true)
            {
                viewModel.hasRolePathologist = true;
            }

            else
            {
                viewModel.hasRolePathologist = false;
            }

            if (viewModel._Pathology.CurrentStateDefID == Pathology.States.Procedure && Common.CurrentResource.TakesPerformanceScore == true && viewModel._Pathology.ProcedureDoctor == null)
            {
                viewModel._Pathology.ProcedureDoctor = Common.CurrentResource;
                
            }

        }

        [HttpGet]
        public string CheckAdditionalReport(Guid PathologyID)
        {
            using (var objectContext = new TTObjectContext(false))
            {

                Pathology pathology = objectContext.GetObject<Pathology>(PathologyID);
                if (pathology.PathologyAdditionalReport != null)
                {
                    return pathology.PathologyAdditionalReport.ObjectID.ToString();
                }
                return "";

            }

        }

        [HttpGet]
        public string CheckUnapprovedPathologyReports(Guid PathologyID)
        {
            string result = "";
            using (var objectContext = new TTObjectContext(true))
            {
                Pathology pathology = objectContext.GetObject<Pathology>(PathologyID);

                List<Pathology.GetUnapprovedPathologyReports_Class> reports = Pathology.GetUnapprovedPathologyReports(pathology.Episode.Patient.ObjectID,pathology.ObjectID).ToList();
                if(reports.Count>0)
                {
                   
                    foreach (Pathology.GetUnapprovedPathologyReports_Class report in reports)
                    {

                        Pathology pathologyReport = objectContext.GetObject<Pathology>(new Guid(report.Pathologyid.ToString()));

                        int resultTime = 0;
                        foreach (PathologyMaterial material in pathologyReport.PathologyMaterial)
                        {
                            
                            foreach (PathologyTestProcedure test in material.PathologyTestProcedure) //Rapordaki patoloji iþlemlerinin arasýndaki en uzun sürede sonuçlanan iþlemin sonuçlanma zamaný
                            {
                                if(((PathologyTestDefinition)test.ProcedureObject).ResultTime != null)
                                {
                                    if (Convert.ToInt32(((PathologyTestDefinition)test.ProcedureObject).ResultTime) > resultTime)
                                        resultTime = Convert.ToInt32(((PathologyTestDefinition)test.ProcedureObject).ResultTime); 
                                    

                                }
                                
                            }
                        }

                        if(resultTime != 0 && result == "" && Convert.ToDateTime(pathologyReport.PathologyRequest.AcceptionDate).AddDays(resultTime) < DateTime.Now)
                        {
                            result = "Hastaya Ait Onaylanmamýþ Patoloji Raporlarý Bulunmaktadýr. Protokol Numaralarý; ";
                            result += "<br/>" + report.MatPrtNoString;
                        }else if(resultTime != 0 && result != ""  && Convert.ToDateTime(pathologyReport.PathologyRequest.AcceptionDate).AddDays(resultTime) < DateTime.Now)
                        {
                            result += "<br/>" + report.MatPrtNoString;
                        }


                    }
                }
           

            }
            return result;
        }


        [HttpGet]
        public string CheckPanicAlert(Guid PathologyID)
        {
            using (var objectContext = new TTObjectContext(false))
            {

                Pathology pathology = objectContext.GetObject<Pathology>(PathologyID);
                if (pathology.PathologyPanicAlert !=  null)
                {
                    return pathology.PathologyPanicAlert.ObjectID.ToString();
                }
                return "";

            }

        }
    }
}

namespace Core.Models
{
    public partial class PathologyMainFormViewModel : BaseViewModel
    {
        public MaterialProcedure[] MaterialProcedureList
        {
            get;
            set;
        }

        public vmRequestedPathologyProcedure[] _RequestedPathologyProceduresArray
        {
            get;
            set;
        }

        public string _StateName
        {
            get;
            set;
        }

        public string _PatientObjectID
        {
            get;
            set;
        }

        public bool hasRolePathologist
        {
            get;
            set;
        }
    }

    public class MaterialProcedure
    {
        public Guid MaterialObjectID;
        public TTObjectClasses.PathologyTestProcedure[] PathologyTestProcedureGridList
        {
            get;
            set;
        }
    }
}