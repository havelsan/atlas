//$1FBD6328
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class NuclearMedicineServiceController : Controller
    {
        public class PrintNuclearBarcode_Input
        {
            public TTObjectClasses.NuclearMedicine nuclearMedicine { get; set; }

        }
        
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)] //Buraya uygun bir rol gelecek...Þimdilik böyle kalsýn
        public NuclearMedicineTestInfo RetrieveNuclearMedicineTestInfo(RetrieveNuclearMedicineTestInfo_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                NuclearMedicine nuclearMedicine = (NuclearMedicine)objectContext.GetObject(new Guid(input.NuclearMedicineObjectID), typeof(NuclearMedicine));
                NuclearMedicineTestInfo testInfo = new NuclearMedicineTestInfo();
                if (nuclearMedicine.NuclearMedicineTests[0].AccessionNo != null)
                {
                    testInfo.AccessionNo = nuclearMedicine.NuclearMedicineTests[0].AccessionNo.ToString();
                }
                return testInfo;
            }
        }

        [HttpGet]
        public List<vmNuclearMedicine> GetPatientAllNuclearMedicineTests(string PatientObjectId, string TimeInterval)
        {
            int timeInt = Convert.ToInt16(TimeInterval);
            List<vmNuclearMedicine> nuclearMedicineTestList = new List<vmNuclearMedicine>();
            DateTime endDate = Common.RecTime();
            DateTime startDate = Convert.ToDateTime(Common.RecTime()).AddMonths(-timeInt);
            bool isPACSEntegrated = false;

            if (TTObjectClasses.SystemParameter.GetParameterValue("PACSENTEGRATION", "FALSE") == "TRUE")
                isPACSEntegrated = true;



            List<NuclearMedicineTest.GetOldNuclearMedicineTestsByDate_Class> patientOldNuclearMedicineTests = NuclearMedicineTest.GetOldNuclearMedicineTestsByDate(PatientObjectId, startDate, endDate).ToList();
            foreach (NuclearMedicineTest.GetOldNuclearMedicineTestsByDate_Class nucMedTest in patientOldNuclearMedicineTests)
            {
                vmNuclearMedicine vmNucMedTest = new vmNuclearMedicine();
                vmNucMedTest.ActionObjectId = (Guid)nucMedTest.Nuclearmedicineid;
                vmNucMedTest.RequestDate = (DateTime)nucMedTest.RequestDate;
                vmNucMedTest.ProcedureCode = nucMedTest.Testcode;
                vmNucMedTest.ProcedureName = nucMedTest.Testname;
                vmNucMedTest.RequestedByResUser = nucMedTest.Requesteddoctor;
                vmNucMedTest.ProcedureResUser = nucMedTest.Proceduredoctor;
                vmNucMedTest.ActionStatus = nucMedTest.DisplayText;
                vmNucMedTest.FromResourceName = nucMedTest.Fromresourcename;
                vmNucMedTest.isReportShown = true;

                if (isPACSEntegrated)
                {
                    if (!String.IsNullOrEmpty(nucMedTest.AccessionNo) )
                    {
                        vmNucMedTest.AccessionNo = nucMedTest.AccessionNo.ToString();
                        string accessionNo = "";
                      
                        accessionNo = nucMedTest.AccessionNo.ToString();
                        vmNucMedTest.isResultShown = true;
                        vmNucMedTest.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?an=" + accessionNo + "&usr=extreme";
                    }
                }


                nuclearMedicineTestList.Add(vmNucMedTest);

            }

            return nuclearMedicineTestList;
        }



        public class NuclearMedicineTestInfo
        {
            public string AccessionNo { get; set; }
        }

        public class RetrieveNuclearMedicineTestInfo_Input
        {
            public string NuclearMedicineObjectID { get; set; }
        }
    }
}