
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using System.Collections.Generic;
using TTDefinitionManagement;
using TTUtils;
using TTStorageManager;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class RadiologyTestServiceController
    {
        partial void PreScript_RadiologyTestAppointmentForm(RadiologyTestAppointmentFormViewModel viewModel, RadiologyTest radiologyTest, TTObjectContext objectContext)
        {
            var episode = viewModel._RadiologyTest.Episode;
            if (episode != null)
            {
                viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
                foreach(DiagnosisGrid dg in viewModel.GridEpisodeDiagnosisGridList)
                {
                    var diagnosisDef = dg.Diagnose;
                }
            }
            var radiology = viewModel._RadiologyTest.Radiology;
            var procedureDefinition = viewModel._RadiologyTest.ProcedureObject;
            var patient = viewModel._RadiologyTest.Episode.Patient;
            viewModel.ResRadiologyEquipments = objectContext.LocalQuery<ResRadiologyEquipment>().ToArray();
            viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
            viewModel.ResRadiologyDepartments = objectContext.LocalQuery<ResRadiologyDepartment>().ToArray();
            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
            viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
            viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.Radiologys = objectContext.LocalQuery<Radiology>().ToArray();
        }

        partial void PostScript_RadiologyTestAppointmentForm(RadiologyTestAppointmentFormViewModel viewModel, RadiologyTest radiologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            objectContext.AddToRawObjectList(viewModel.ResRadiologyEquipments);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResRadiologyDepartments);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Radiologys);
            objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
            var entryStateID = Guid.Parse("8c10952f-a4d9-4007-a8fb-1660dba7b45d");
            objectContext.AddToRawObjectList(viewModel._RadiologyTest, entryStateID);
            objectContext.ProcessRawObjects(false);
        }

        partial void AfterContextSaveScript_RadiologyTestAppointmentForm(RadiologyTestAppointmentFormViewModel viewModel, RadiologyTest radiologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null)
            {
                if (transDef.ToStateDefID == RadiologyTest.States.Procedure)
                {
                    //PACS enrtegrasyonu acık ıse gonderım yapılacak
                    if (TTObjectClasses.SystemParameter.GetParameterValue("PACSENTEGRATION", "FALSE") == "TRUE")
                    {
                        if (((RadiologyTestDefinition)(radiologyTest.ProcedureObject)).IsRISEntegratedTest == true)
                        {
                            this.SendTestToPACSAndTELETIP(radiologyTest);
                        }
                    }
                }
            }
        }

        [HttpGet]
        public RadiologyBarcodeInfo PrepareRadiologyAppointmentBarcode(string RadiologyTestObjectID)
        {
            RadiologyBarcodeInfo barcode= new RadiologyBarcodeInfo();
            TTObjectContext objectContext = new TTObjectContext(false);
            RadiologyTest radiologyTest = objectContext.GetObject<RadiologyTest>(new Guid(RadiologyTestObjectID));

            barcode.ProtocolNo = radiologyTest.SubEpisode.ProtocolNo;
            barcode.PatientFullName = radiologyTest.Radiology.Episode.Patient.Name + " " + radiologyTest.Radiology.Episode.Patient.Surname;
            barcode.FromResource = radiologyTest.FromResource.Name;
            barcode.ProcedureName = radiologyTest.ProcedureObject.Name;
            barcode.RequestDoctor = radiologyTest.Radiology.RequestDoctor.Name;

            SubActionProcedure sp = (SubActionProcedure)radiologyTest;
            if (sp.GetMyNewAppointments() != null)
            {
                if (sp.GetMyNewAppointments().Count > 0)
                {
                    if (sp.GetMyNewAppointments()[0].StartTime != null)
                    {
                        DateTime appDate = sp.GetMyNewAppointments()[0].StartTime.Value;
                        barcode.AppointmentDate = appDate.ToString();
                    }
                }
            }
           
            return barcode;
        }



    }
}

namespace Core.Models
{
    public partial class RadiologyTestAppointmentFormViewModel
    {
        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.ResRadiologyEquipment[] ResRadiologyEquipments { get; set; }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions { get; set; }
        public TTObjectClasses.ResRadiologyDepartment[] ResRadiologyDepartments { get; set; }
        public TTObjectClasses.Radiology[] Radiologys { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
    }
}