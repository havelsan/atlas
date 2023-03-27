//$E8498C7A
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class RadiologyTestServiceController
    {
        partial void AfterContextSaveScript_RadiologyTestCompletedForm(RadiologyTestCompletedFormViewModel viewModel, RadiologyTest radiologyTest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //Tetkik US tetkik ise Rapor Giriþ aþamasýna geçerken, Ultrason kuyruðundan istemin kaldýrýlmasý
            RadiologyTestDefinition rTestDef = (RadiologyTestDefinition)radiologyTest.ProcedureObject;
            if (rTestDef.TestType != null && rTestDef.TestType.Name == "US")
            {
                if (transDef != null)
                {
                    if (transDef.ToStateDefID == RadiologyTest.States.ResultEntry)
                    {
                        if (TTObjectClasses.SystemParameter.GetParameterValue("RADIOLOGYLCDOPEN", "FALSE") == "TRUE")
                        {
                            if (radiologyTest.Radiology != null)
                            {
                                List<ExaminationQueueItem> queueItem = ExaminationQueueItem.GetByEpisodeAction(objectContext, radiologyTest.Radiology.ObjectID).ToList();
                                if (queueItem.Count > 0)
                                {
                                    if (queueItem[0].CurrentStateDefID != ExaminationQueueItem.States.Completed)
                                    {
                                        queueItem[0].CurrentStateDefID = ExaminationQueueItem.States.Completed;
                                        objectContext.Save();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        partial void PreScript_RadiologyTestCompletedForm(RadiologyTestCompletedFormViewModel viewModel, RadiologyTest radiologyTest, TTObjectContext objectContext)
        {
            if(radiologyTest.RadiologyAdditionalReport != null)
            {
                viewModel.RadiologyAdditionalReport = radiologyTest.RadiologyAdditionalReport.AdditionalReport;
                viewModel.hasAdditionalReport = true;
            }else
                viewModel.hasAdditionalReport = false;

            //Kullanýcýnýn Radyoloji Test[Sonuç Giriþe Geri Alma] rolu  varsa ve kendi yazdýðý rapor ise iþlemi rapor giriþe geri alabilecek
            
            if (radiologyTest.CurrentStateDefID == RadiologyTest.States.Reported && (radiologyTest.ProcedureDoctor != null 
                && (radiologyTest.ProcedureDoctor.ObjectID != Common.CurrentResource.ObjectID || (radiologyTest.ProcedureDoctor.ObjectID == Common.CurrentResource.ObjectID && !Common.CurrentUser.HasRole(new Guid("dd5476d6-983e-4b5f-b573-8723f55bdbbf")) ))) || (radiologyTest.ProcedureDoctor == null) && !Common.CurrentUser.HasRole(new Guid("dd5476d6-983e-4b5f-b573-8723f55bdbbf")))
            {
                List<TTObjectStateTransitionDef> removedOutgoingTransitions = new List<TTObjectStateTransitionDef>();
                foreach (var trans in viewModel.OutgoingTransitions) //Bu stateten tek geçiþ var ama ileride baþka stateler eklenebilir diye bu þekilde kontrol edildi.
                {
                    if (trans.ToStateDefID == RadiologyTest.States.ResultEntry )
                        removedOutgoingTransitions.Add(trans);

                }

                foreach (var removedtrans in removedOutgoingTransitions)
                {
                    viewModel.OutgoingTransitions.Remove(removedtrans);
                }

            }

            viewModel.paramNewRadiologyReport = TTObjectClasses.SystemParameter.GetParameterValue("NEWRADIOLOGYREPORT", "FALSE") == "TRUE" ? true : false;



        }

        [HttpGet]
        public string CheckAdditionalReport(Guid RadiologyTestID)
        {
            using (var objectContext = new TTObjectContext(false))
            {

                RadiologyTest radiologyTest = objectContext.GetObject<RadiologyTest>(RadiologyTestID);
                if (radiologyTest.RadiologyAdditionalReport != null)
                {
                    return radiologyTest.RadiologyAdditionalReport.ObjectID.ToString();
                }
                return "";

            }

        }

        [HttpGet]
        public List<RadiologyTestObject> GetRadiologyTests(string RadiologyTestObjectID)
        {
            List<RadiologyTestObject> result = new List<RadiologyTestObject>();

            TTObjectContext objectContext = new TTObjectContext(true);
            RadiologyTest radTest = (RadiologyTest)objectContext.GetObject(new Guid(RadiologyTestObjectID), "RADIOLOGYTEST");

            RadiologyTestTypeDefinition testType = radTest.RadiologyTestDefinition.TestType;
            if (testType != null)
            {
                BindingList<RadiologyTest> radiologyTestList = RadiologyTest.GetRadTestBySubEpisode(objectContext, radTest.SubEpisode.ObjectID, radTest.SubEpisode.Episode.ObjectID.ToString());
                foreach (RadiologyTest test in radiologyTestList)
                {
                    if (test.ObjectID != radTest.ObjectID 
                        && test.RadiologyTestDefinition.TestType != null
                        && test.RadiologyTestDefinition.TestType.ObjectID == testType.ObjectID 
                        && test.CurrentStateDefID == RadiologyTest.States.Completed
                        && radTest.Radiology.ObjectID == test.Radiology.ObjectID)
                    {
                        RadiologyTestObject r = new RadiologyTestObject();
                        r.ObjectID = test.ObjectID.ToString();
                        r.ProcedureCode = test.RadiologyTestDefinition.Code;
                        r.ProcedureName = test.RadiologyTestDefinition.Name;
                        result.Add(r);

                    }
                }
            }
            return result;
        }

        [HttpPost]
        public void CopyReportToRadiologyTests(CopyReportInput input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                RadiologyTest radiologyTest = (RadiologyTest)objectContext.GetObject(new Guid(input.RadiologyTestObjectID), "RADIOLOGYTEST");

                foreach(RadiologyTestObject test in input.SelectedRadiologyTests)
                {
                    RadiologyTest selectedTest = (RadiologyTest)objectContext.GetObject(new Guid(test.ObjectID), "RADIOLOGYTEST");
                    selectedTest.Report = radiologyTest.Report;//Rapor
                    selectedTest.RadiographyTechnique = radiologyTest.RadiographyTechnique; //Çekim Tekniði
                    selectedTest.Results = radiologyTest.Results; //Bulgular
                    selectedTest.ComparisonInfo = radiologyTest.ComparisonInfo;//Karþýlaþtýrma Bilgisi
                    selectedTest.RequestReasonAssesment = radiologyTest.RequestReasonAssesment; //Tetkik Ýstem Nedeni Deðerlendirme
                    selectedTest.ImageQualityAssesment = radiologyTest.ImageQualityAssesment; //Çekim Kalitesi Deðerlendirme
                    selectedTest.ProcedureDoctor = radiologyTest.ProcedureDoctor;
                    selectedTest.CurrentStateDefID = RadiologyTest.States.Reported;

                }
                objectContext.Save();
            }


        }
    }
}

namespace Core.Models
{
    public partial class RadiologyTestCompletedFormViewModel : BaseViewModel
    {
        public object RadiologyAdditionalReport { get; set; }
        public bool hasAdditionalReport { get; set; }
        public bool paramNewRadiologyReport { get; set; }
    }

    public class RadiologyTestObject
    {
        public string ObjectID { get; set; }
        public string ProcedureCode { get; set; }
        public string ProcedureName { get; set; }
    }

    public class CopyReportInput
    {
        public List<RadiologyTestObject> SelectedRadiologyTests; //Burada seçilen iþlemlere kopyalanacak
        public string RadiologyTestObjectID;//Kopayalacak olan iþlemin objectidsi
    }
}