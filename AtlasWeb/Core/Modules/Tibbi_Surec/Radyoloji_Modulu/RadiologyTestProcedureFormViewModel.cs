//$3F3FE4BD
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class RadiologyTestServiceController
    {
        partial void PreScript_RadiologyTestProcedureForm(RadiologyTestProcedureFormViewModel viewModel, RadiologyTest radiologyTest, TTObjectContext objectContext)
        {
            viewModel.NewRadiologyBarcode = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("NEWRADIOLOGYBARCODE", "FALSE"));

            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalýþmamalý
            viewModel.MaterialsGridList = viewModel.MaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();

            if (viewModel._RadiologyTest.Episode != null)
            {
                viewModel.EpisodeID = viewModel._RadiologyTest.Episode.ID.ToString();
                if (viewModel._RadiologyTest.Episode.Patient.UniqueRefNo != null)
                {
                    viewModel.PatientTCNo = viewModel._RadiologyTest.Episode.Patient.UniqueRefNo.ToString();
                }
            }
        }

        [HttpGet]
        public RadiologyBarcodeInfo[] PrepareRadiologyBarcode(string RadiologyTestObjectID)
        {
            List<RadiologyBarcodeInfo> barcodeList = new List<RadiologyBarcodeInfo>();
            TTObjectContext objectContext = new TTObjectContext(false);
            RadiologyTest radiologyTest = objectContext.GetObject<RadiologyTest>(new Guid(RadiologyTestObjectID));
            var radTestDefinition = radiologyTest.ProcedureObject as RadiologyTestDefinition;
            var radTestType = radTestDefinition.TestType as RadiologyTestTypeDefinition;
            if(radTestType != null)
            {
                if(radTestType.Name == "CR")
                {
                    List<AllRadiologyList> result = GetAllRadiologyTest(radiologyTest);
                    if(result != null)
                    {
                        foreach(AllRadiologyList r in result)
                        {
                            RadiologyBarcodeInfo barcode = new RadiologyBarcodeInfo();
                            barcode.PatientFullName = radiologyTest.Radiology.Episode.Patient.Name + " " + radiologyTest.Radiology.Episode.Patient.Surname;
                            barcode.PrintDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                            barcode.AccessionNumber = r.AccessionNumber == null ?"" : "Accession No: " + r.AccessionNumber;
                            barcode.ProcedureCode = r.ProcudureCode;
                            barcode.BirthDate = Convert.ToDateTime(radiologyTest.Radiology.Episode.Patient.BirthDate).ToString("dd.MM.yyyy HH:mm");
                            barcode.ProcedureName = r.ProcudureName;
                            barcode.BarcodeCode = radiologyTest.Radiology.Episode.Patient.UniqueRefNo.ToString();
                            barcode.RequestDoctor = radiologyTest.RequestedByUser.Name;
                            barcode.PatientAge = radiologyTest.Radiology.Episode.Patient.CalculatedAge;
                            barcode.PatientGender = radiologyTest.Radiology.Episode.Patient.Sex.ADI;
                            barcode.RequestDate = Convert.ToDateTime(radiologyTest.RequestDate).ToString("dd.MM.yyyy HH:mm");
                            barcode.ProtocolNo = radiologyTest.SubEpisode.ProtocolNo;
                            barcode.UniqueRefNo = radiologyTest.Radiology.Episode.Patient.UniqueRefNo.ToString();

                            barcodeList.Add(barcode);
                        }
                    }
                }
                else
                {
                    RadiologyBarcodeInfo barcode = new RadiologyBarcodeInfo();
                    barcode.PatientFullName = radiologyTest.Radiology.Episode.Patient.Name + " " + radiologyTest.Radiology.Episode.Patient.Surname;
                    barcode.PrintDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                    barcode.AccessionNumber = radiologyTest.AccessionNo == null ? "": "Accession No: " + radiologyTest.AccessionNo.ToString();
                    barcode.ProcedureCode = radiologyTest.ProcedureObject.Code;
                    barcode.ProcedureName = radiologyTest.ProcedureObject.Name;
                    barcode.BarcodeCode = radiologyTest.Radiology.Episode.Patient.UniqueRefNo.ToString();
                    barcode.RequestDoctor = radiologyTest.RequestedByUser.Name;
                    barcode.PatientAge = radiologyTest.Radiology.Episode.Patient.CalculatedAge;
                    barcode.BirthDate = Convert.ToDateTime(radiologyTest.Radiology.Episode.Patient.BirthDate).ToString("dd.MM.yyyy HH:mm");
                    barcode.PatientGender = radiologyTest.Radiology.Episode.Patient.Sex.ADI;
                    barcode.RequestDate = Convert.ToDateTime(radiologyTest.RequestDate).ToString("dd.MM.yyyy HH:mm");
                    barcode.ProtocolNo = radiologyTest.SubEpisode.ProtocolNo;
                    barcode.UniqueRefNo = radiologyTest.Radiology.Episode.Patient.UniqueRefNo.ToString();

                    barcodeList.Add(barcode);

                }
            }
            return barcodeList.ToArray();
        }

        partial void AfterContextSaveScript_RadiologyTestProcedureForm(RadiologyTestProcedureFormViewModel viewModel, RadiologyTest radiologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null)
            {
                if (((RadiologyTestDefinition)(radiologyTest.ProcedureObject)).IsRISEntegratedTest == true && transDef.ToStateDefID == RadiologyTest.States.Completed 
                    && radiologyTest.ExternalServiceRequests.Count > 0 && TTObjectClasses.SystemParameter.GetParameterValue("PACSENTEGRATION", "FALSE") == "TRUE") 
                {
                    using (TTObjectContext objectContextLocal = new TTObjectContext(false))
                    {
                        RadiologyTest radTest = (RadiologyTest)objectContextLocal.GetObject(radiologyTest.ObjectID, "RADIOLOGYTEST");
                        List<Guid> radSubactionList = new List<Guid>();

                        radSubactionList.Add(radTest.ObjectID);

                        try
                        {
                            var resultExternalHIS = HL7EngineManagerFactory.Instance.SendHospitalMessageToEngine(radSubactionList, "O01XO", HL7ServerNames.Cubuk);
                            radTest.IsMessageInExternalHIS = resultExternalHIS.Item1;
                            radTest.ACKMessageExternalHIS = resultExternalHIS.Item2;
                        }
                        catch (Exception)
                        {

                        }
                        finally
                        {
                            objectContextLocal.Save();
                        }

                        //this.SendTestToPACSAndTELETIP(radiologyTest, true);
                    }

                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class RadiologyTestProcedureFormViewModel
    {
        public string PatientTCNo;
        public string EpisodeID;
        public bool NewRadiologyBarcode;

    }

    public class RadiologyBarcodeInfo
    {
        public string PrintDate { get; set; }
        public string ProcedureCode { get; set; }
        public string ProcedureName { get; set; }
        public string PatientIdentifier{ get; set; }
        public string PatientFullName { get; set; }
        public string RequestDoctor { get; set; }
        public string BarcodeCode{ get; set; }
        public string BirthDate { get; set; }
        public string  AccessionNumber { get; set; }
        public string PatientAge { get; set; }
        public string PatientGender { get; set; }
        public string RequestDate { get; set; }
        public string ProtocolNo { get; set; }
        public string UniqueRefNo { get; set; }
        public string FromResource { get; set; }
        public string AppointmentDate { get; set; }
    }
}