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
using TTStorageManager.Security;
using System.Collections;
using TTDefinitionManagement;
using TTDataDictionary;
using static TTObjectClasses.SurgeryDefinition;

using Core.Models;

namespace Core.Modules.Tibbi_Surec.Tetkik_Istem_Modulu
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]

    public class ProcedureRequestServiceController : Controller
    {
        [HttpPost]
        public ProcedureRequestViewModel GetProcedureRequestViewModel(List<Guid> resourceIDList)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            //var ttProcedureRequestFormDefinitionList = TTObjectClasses.ProcedureRequestFormDefinition.GetForms(objContext, "");
            BindingList<RequestUnitOfProcedureForm> ttRequestUnitOfProcedureFormList = TTObjectClasses.RequestUnitOfProcedureForm.GetFormsByResourceIDs(objContext, resourceIDList);
            var procedureRequestViewModel = new ProcedureRequestViewModel();
            foreach (RequestUnitOfProcedureForm ttRequestUnitOfProcedureForm in ttRequestUnitOfProcedureFormList)
            {
                var vmProcedureRequestFormDefinition = new vmProcedureRequestFormDefinition();
                vmProcedureRequestFormDefinition.Id = ttRequestUnitOfProcedureForm.ProcedureRequestFormDef.ObjectID;
                vmProcedureRequestFormDefinition.Name = ttRequestUnitOfProcedureForm.ProcedureRequestFormDef.Name;
                foreach (var ttProcedureRequestFormCategory in ttRequestUnitOfProcedureForm.ProcedureRequestFormDef.FormCategory.ToList().OrderBy(dr => dr.OrderNo))
                {
                    var vmProcedureRequestFormCategory = new vmProcedureRequestCategoryDefinition();
                    vmProcedureRequestFormCategory.Id = ttProcedureRequestFormCategory.ObjectID;
                    vmProcedureRequestFormCategory.Name = ttProcedureRequestFormCategory.CategoryName;
                    foreach (var ttProcedureRequestFormDetail in ttProcedureRequestFormCategory.FormDetail.ToList().OrderBy(dr => dr.OrderNo))
                    {
                        var vmProcedureRequestDetailDefinition = new vmProcedureRequestDetailDefinition();
                        vmProcedureRequestDetailDefinition.Id = ttProcedureRequestFormDetail.ObjectID;
                        vmProcedureRequestDetailDefinition.Code = ttProcedureRequestFormDetail.ProcedureDefinition.Code;
                        vmProcedureRequestDetailDefinition.Name = ttProcedureRequestFormDetail.ProcedureDefinition.Name;
                        vmProcedureRequestDetailDefinition.ProcedureObjectDefID = ttProcedureRequestFormDetail.ProcedureDefinition.ObjectID;
                        vmProcedureRequestDetailDefinition.Checked = false;
                        if ((bool)ttProcedureRequestFormDetail.ProcedureDefinition.IsActive == true)
                        {
                            vmProcedureRequestDetailDefinition.IsActive = true;
                            vmProcedureRequestFormCategory.FormDetails.Add(vmProcedureRequestDetailDefinition);
                        }
                        else
                            vmProcedureRequestDetailDefinition.IsActive = false;

                        vmProcedureRequestDetailDefinition.IsWorkingDay = true;

                        //ProcedureObject in BoundedTestleri varsa onlar da viewmodel e yuklenecek.
                        if (ttProcedureRequestFormDetail.ProcedureDefinition is LaboratoryTestDefinition)
                        {
                            if (((LaboratoryTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).BoundedTests.Count > 0)
                            {

                                foreach (LaboratoryGridBoundedTestDefinition boundedTestDef in ((LaboratoryTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).BoundedTests)
                                {
                                    //Bounded testin formdetail ini bulup collectiona ekle

                                    vmProcedureRequestDetailDefinition boundedProcedureReqFormDet = new vmProcedureRequestDetailDefinition();
                                    ProcedureDefinition boundedProcedureDefinition = (ProcedureDefinition)boundedTestDef.LaboratoryTest;

                                    BindingList<ProcedureRequestFormDetailDefinition> procedureRequestFormDetailList = ProcedureRequestFormDetailDefinition.GetProcedureRequestFormDetailByProcedureDefinition(objContext, boundedProcedureDefinition.ObjectID);
                                    foreach (ProcedureRequestFormDetailDefinition reqFormDetDef in procedureRequestFormDetailList)
                                    {
                                        if (reqFormDetDef.ProcedureRequestCategory.ProcedureRequestForm.ObjectID.ToString() == ttProcedureRequestFormDetail.ProcedureRequestCategory.ProcedureRequestForm.ObjectID.ToString())
                                        {
                                            var vmProcedureRequestDetailDefinitionBoundedTest = new vmProcedureRequestDetailDefinition();
                                            vmProcedureRequestDetailDefinitionBoundedTest.Id = reqFormDetDef.ObjectID;
                                            vmProcedureRequestDetailDefinitionBoundedTest.Code = boundedProcedureDefinition.Code;
                                            vmProcedureRequestDetailDefinitionBoundedTest.Name = boundedProcedureDefinition.Name;
                                            vmProcedureRequestDetailDefinitionBoundedTest.ProcedureObjectDefID = boundedProcedureDefinition.ObjectID;
                                            vmProcedureRequestDetailDefinitionBoundedTest.Checked = false;
                                            vmProcedureRequestDetailDefinitionBoundedTest.IsActive = true;
                                            vmProcedureRequestDetailDefinition.BoundedProcedureRequestDetails.Add(vmProcedureRequestDetailDefinitionBoundedTest);
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        //RadyolojiTest lerinde viewmodel e calısılan gunler yuklenecek.
                        if (ttProcedureRequestFormDetail.ProcedureDefinition is RadiologyTestDefinition)
                        {
                            vmProcedureRequestDetailDefinition.IsWorkingDay = false;
                            var currentDay = DateTime.Now.DayOfWeek;
                            switch (currentDay)
                            {
                                case DayOfWeek.Monday:
                                    if (((RadiologyTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).OnMonday == true)
                                        vmProcedureRequestDetailDefinition.IsWorkingDay = true;
                                    break;
                                case DayOfWeek.Tuesday:
                                    if (((RadiologyTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).OnTuesday == true)
                                        vmProcedureRequestDetailDefinition.IsWorkingDay = true;
                                    break;
                                case DayOfWeek.Wednesday:
                                    if (((RadiologyTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).OnWednesday == true)
                                        vmProcedureRequestDetailDefinition.IsWorkingDay = true;
                                    break;
                                case DayOfWeek.Thursday:
                                    if (((RadiologyTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).OnThursday == true)
                                        vmProcedureRequestDetailDefinition.IsWorkingDay = true;
                                    break;
                                case DayOfWeek.Friday:
                                    if (((RadiologyTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).OnFriday == true)
                                        vmProcedureRequestDetailDefinition.IsWorkingDay = true;
                                    break;
                                case DayOfWeek.Saturday:
                                    if (((RadiologyTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).OnSaturday == true)
                                        vmProcedureRequestDetailDefinition.IsWorkingDay = true;
                                    break;
                                case DayOfWeek.Sunday:
                                    if (((RadiologyTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).OnSunday == true)
                                        vmProcedureRequestDetailDefinition.IsWorkingDay = true;
                                    break;
                            }
                        }
                    }

                    vmProcedureRequestFormDefinition.FormCategories.Add(vmProcedureRequestFormCategory);
                }

                if (ttRequestUnitOfProcedureForm.Resource is ResUser)
                    procedureRequestViewModel.UserMostUsedFormDefinitions.Add(vmProcedureRequestFormDefinition);
                else
                    procedureRequestViewModel.FormDefinitions.Add(vmProcedureRequestFormDefinition);
            }

            return procedureRequestViewModel;
        }

        [HttpPost]
        public ProcedureRequestViewModel GetMostUsedProcedureRequestViewModel()
        {
            List<Guid> IDList = new List<Guid>();
            IDList.Add(Common.CurrentResource.ObjectID);
            return GetProcedureRequestViewModel_V2(IDList);
        }

        [HttpPost]
        public ProcedureRequestViewModel GetProcedureRequestViewModel_V2(List<Guid> resourceIDList)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            //var ttProcedureRequestFormDefinitionList = TTObjectClasses.ProcedureRequestFormDefinition.GetForms(objContext, "");
            BindingList<RequestUnitOfProcedureForm> ttRequestUnitOfProcedureFormList = TTObjectClasses.RequestUnitOfProcedureForm.GetFormsByResourceIDs(objContext, resourceIDList);
            var procedureRequestViewModel = new ProcedureRequestViewModel();

            procedureRequestViewModel.TestTypesCheckedParam = TTObjectClasses.SystemParameter.GetParameterValue("TESTTYPESCHECKEDPARAM", "");
            procedureRequestViewModel.IgnoreMukerrerException = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("IGNOREMUKERREREXCEPTION", "FALSE"));

            //Kayıt kabulde sevkli tetkik için 2 birim seçildiği zaman lablar çoklayarak geliyor
            List<RequestUnitOfProcedureForm> distinct_ttRequestUnitOfProcedureForm = new List<RequestUnitOfProcedureForm>();
            foreach (RequestUnitOfProcedureForm ttRequestUnitOfProcedureForm in ttRequestUnitOfProcedureFormList)
            {
                if (distinct_ttRequestUnitOfProcedureForm.Where(x => x.ProcedureRequestFormDef.ObjectID == ttRequestUnitOfProcedureForm.ProcedureRequestFormDef.ObjectID).FirstOrDefault() == null)
                    distinct_ttRequestUnitOfProcedureForm.Add(ttRequestUnitOfProcedureForm);
            }
            
            foreach (RequestUnitOfProcedureForm ttRequestUnitOfProcedureForm in distinct_ttRequestUnitOfProcedureForm)
            {
                var vmProcedureRequestFormDefinition = new vmProcedureRequestFormDefinition();
                vmProcedureRequestFormDefinition.Id = ttRequestUnitOfProcedureForm.ProcedureRequestFormDef.ObjectID;
                vmProcedureRequestFormDefinition.Name = ttRequestUnitOfProcedureForm.ProcedureRequestFormDef.Name;
                foreach (var ttProcedureRequestFormCategory in ttRequestUnitOfProcedureForm.ProcedureRequestFormDef.FormCategory.ToList().OrderBy(dr => dr.OrderNo))
                {
                    var vmProcedureRequestFormCategory = new vmProcedureRequestCategoryDefinition();
                    vmProcedureRequestFormCategory.Id = ttProcedureRequestFormCategory.ObjectID;
                    vmProcedureRequestFormCategory.Name = ttProcedureRequestFormCategory.CategoryName;
                    vmProcedureRequestFormCategory.IsPassiveNow = ttProcedureRequestFormCategory.IsPassiveNow;
                    vmProcedureRequestFormCategory.ReasonForPassive = ttProcedureRequestFormCategory.ReasonForPassive == null ? "" : " -(Çalışılamama Nedeni:" + ttProcedureRequestFormCategory.ReasonForPassive + ")";

                    //FormCategory altındakı detail ları 3 grıd kolon a bolme calısması

                    var categoryDetailsList = ttProcedureRequestFormCategory.FormDetail.ToList().OrderBy(dr => dr.OrderNo).ToList();
                    int totalDetailCount = categoryDetailsList.Count();
                    int firstGridDetailCount = Convert.ToInt32(Math.Floor((double)(totalDetailCount / 3)));
                    int secondGridDetailCount = firstGridDetailCount;


                    if (totalDetailCount % 3 == 1)
                        firstGridDetailCount++;
                    else if (totalDetailCount % 3 == 2)
                    {
                        firstGridDetailCount++;
                        secondGridDetailCount++;
                    }
                    int lastGridDetailCount = totalDetailCount - (firstGridDetailCount + secondGridDetailCount);

                    int minIndex = 0;
                    int maxIndex = 0;
                    for (int i = 1; i <= 3; i++)
                    {
                        if (i == 1)
                        {
                            minIndex = 0;
                            maxIndex = firstGridDetailCount;
                        }
                        if (i == 2)
                        {
                            minIndex = maxIndex;
                            maxIndex = minIndex + secondGridDetailCount;
                        }
                        if (i == 3)
                        {
                            minIndex = maxIndex;
                            maxIndex = minIndex + lastGridDetailCount;
                        }

                        bool addGridFormDetails;
                        for (int k = minIndex; k < maxIndex; k++)
                        {
                            addGridFormDetails = true;
                            //Aktif olmayan  tetkiklerin istem paneline hic yuklenmemesi saglandi.
                            if (categoryDetailsList[k].ProcedureDefinition.IsActive != null && (bool)categoryDetailsList[k].ProcedureDefinition.IsActive == true)
                            {
                                if (categoryDetailsList[k].ProcedureDefinition is LaboratoryTestDefinition)
                                {
                                    if (((LaboratoryTestDefinition)categoryDetailsList[k].ProcedureDefinition).IsSubTest != null && ((LaboratoryTestDefinition)categoryDetailsList[k].ProcedureDefinition).IsSubTest == true)
                                        addGridFormDetails = false;
                                }
                                if (addGridFormDetails)
                                {
                                    var vmProcedureRequestDetailDefinition = new vmProcedureRequestDetailDefinition();
                                    vmProcedureRequestDetailDefinition.Id = categoryDetailsList[k].ObjectID;
                                    vmProcedureRequestDetailDefinition.Code = categoryDetailsList[k].ProcedureDefinition.Code;
                                    vmProcedureRequestDetailDefinition.Name = categoryDetailsList[k].ProcedureDefinition.Name;
                                    vmProcedureRequestDetailDefinition.ProcedureObjectDefID = categoryDetailsList[k].ProcedureDefinition.ObjectID;
                                    vmProcedureRequestDetailDefinition.Checked = false;
                                    vmProcedureRequestDetailDefinition.IsWorkingDay = true;
                                    if (vmProcedureRequestFormCategory.IsPassiveNow.HasValue && vmProcedureRequestFormCategory.IsPassiveNow.Value)
                                        vmProcedureRequestDetailDefinition.IsPassiveNow = true;
                                    else
                                        vmProcedureRequestDetailDefinition.IsPassiveNow = false;

                                    vmProcedureRequestDetailDefinition.IsActive = true;
                                    vmProcedureRequestDetailDefinition.TestType = "";
                                    vmProcedureRequestDetailDefinition.RepetitionQueryNeeded = categoryDetailsList[k].ProcedureDefinition.RepetitionQueryNeeded == null ? false : categoryDetailsList[k].ProcedureDefinition.RepetitionQueryNeeded;
                                    if (categoryDetailsList[k].ObservationUnit != null)
                                        vmProcedureRequestDetailDefinition.ResObservationUnitId = (Guid)categoryDetailsList[k].ObservationUnit.ObjectID;


                                    if (categoryDetailsList[k].ProcedureDefinition is LaboratoryTestDefinition)
                                    {
                                        SetBoundedTestsForProcedureRequestDetail(categoryDetailsList[k], ref vmProcedureRequestDetailDefinition, objContext);
                                        SetGroupTestsForProcedureRequestDetail(categoryDetailsList[k], ref vmProcedureRequestDetailDefinition, objContext);
                                        
                                        if(vmProcedureRequestFormCategory.IsPassiveNow.HasValue && vmProcedureRequestFormCategory.IsPassiveNow.Value)
                                            vmProcedureRequestDetailDefinition.IsPassiveNow = true;
                                        else
                                            vmProcedureRequestDetailDefinition.IsPassiveNow = ((LaboratoryTestDefinition)categoryDetailsList[k].ProcedureDefinition).IsPassiveNow != null ? (bool)((LaboratoryTestDefinition)categoryDetailsList[k].ProcedureDefinition).IsPassiveNow : false;
                                        
                                        if (((LaboratoryTestDefinition)categoryDetailsList[k].ProcedureDefinition).IsSexControl == true)
                                        {
                                            vmProcedureRequestDetailDefinition.IsSexControl = true;
                                            if (((LaboratoryTestDefinition)categoryDetailsList[k].ProcedureDefinition).Sex != null)
                                                vmProcedureRequestDetailDefinition.Sex = ((LaboratoryTestDefinition)categoryDetailsList[k].ProcedureDefinition).Sex;
                                        }
                                        else
                                            vmProcedureRequestDetailDefinition.IsSexControl = false;

                                        if (((LaboratoryTestDefinition)categoryDetailsList[k].ProcedureDefinition).IsDurationControl == true)
                                        {
                                            vmProcedureRequestDetailDefinition.IsDurationControl = true;
                                            if (((LaboratoryTestDefinition)categoryDetailsList[k].ProcedureDefinition).DurationValue != null && ((LaboratoryTestDefinition)categoryDetailsList[k].ProcedureDefinition).DurationValue != 0)
                                                vmProcedureRequestDetailDefinition.DurationValue = (int)((LaboratoryTestDefinition)categoryDetailsList[k].ProcedureDefinition).DurationValue;
                                        }
                                        else
                                            vmProcedureRequestDetailDefinition.IsDurationControl = false;

                                    }
                                    if (categoryDetailsList[k].ProcedureDefinition is RadiologyTestDefinition)
                                    {
                                        SetWorkingDayOfProcedureRequestDetail(categoryDetailsList[k], ref vmProcedureRequestDetailDefinition, objContext);
                                        
                                        if (vmProcedureRequestFormCategory.IsPassiveNow.HasValue && vmProcedureRequestFormCategory.IsPassiveNow.Value)
                                            vmProcedureRequestDetailDefinition.IsPassiveNow = true;
                                        else
                                            vmProcedureRequestDetailDefinition.IsPassiveNow = ((RadiologyTestDefinition)categoryDetailsList[k].ProcedureDefinition).IsPassiveNow != null ? (bool)((RadiologyTestDefinition)categoryDetailsList[k].ProcedureDefinition).IsPassiveNow : false;
                                        
                                        vmProcedureRequestDetailDefinition.TestType = ((RadiologyTestDefinition)categoryDetailsList[k].ProcedureDefinition).TestType != null ? ((RadiologyTestDefinition)categoryDetailsList[k].ProcedureDefinition).TestType.Name : "";
                                        if (((RadiologyTestDefinition)categoryDetailsList[k].ProcedureDefinition).TimeLimit != null)
                                           vmProcedureRequestDetailDefinition.DurationValue = (int)((RadiologyTestDefinition)categoryDetailsList[k].ProcedureDefinition).TimeLimit;
                                    }

                                    if (categoryDetailsList[k].ProcedureDefinition is SurgeryDefinition)
                                        vmProcedureRequestDetailDefinition.IsAdditionalApplication = true;
                                    else
                                        vmProcedureRequestDetailDefinition.IsAdditionalApplication = false;

                                    vmProcedureRequestDetailDefinition.isReportRequired = categoryDetailsList[k].ProcedureDefinition.ReportSelectionRequired == true ? true : false;
                                    vmProcedureRequestDetailDefinition.isPathologyRequired = categoryDetailsList[k].ProcedureDefinition.PathologyOperationNeeded == true ? true : false;
                                    vmProcedureRequestDetailDefinition.isResultNeeded = categoryDetailsList[k].ProcedureDefinition.IsResultNeeded == true ? true : false;

                                    if(vmProcedureRequestDetailDefinition.Code == "700050")
                                          vmProcedureRequestDetailDefinition.isSkinPrickTest = true;
                                    else
                                        vmProcedureRequestDetailDefinition.isSkinPrickTest = false;

                                    if (i == 1)
                                        vmProcedureRequestFormCategory.Grid1FormDetails.Add(vmProcedureRequestDetailDefinition);
                                    if (i == 2)
                                        vmProcedureRequestFormCategory.Grid2FormDetails.Add(vmProcedureRequestDetailDefinition);
                                    if (i == 3)
                                        vmProcedureRequestFormCategory.Grid3FormDetails.Add(vmProcedureRequestDetailDefinition);
                                }
                            }
                        }
                    }

                    vmProcedureRequestFormDefinition.FormCategories.Add(vmProcedureRequestFormCategory);
                }

                if (ttRequestUnitOfProcedureForm.Resource is ResUser)
                    procedureRequestViewModel.UserMostUsedFormDefinitions.Add(vmProcedureRequestFormDefinition);
                else
                    procedureRequestViewModel.FormDefinitions.Add(vmProcedureRequestFormDefinition);
            }

            return procedureRequestViewModel;
        }

        public void SetBoundedTestsForProcedureRequestDetail(ProcedureRequestFormDetailDefinition ttProcedureRequestFormDetail, ref vmProcedureRequestDetailDefinition vmProcedureRequestDetailDefinition, TTObjectContext objContext)
        {
            //ProcedureObject in BoundedTestleri varsa onlar da viewmodel e yuklenecek.
            if (((LaboratoryTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).BoundedTests.Count > 0)
            {

                foreach (LaboratoryGridBoundedTestDefinition boundedTestDef in ((LaboratoryTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).BoundedTests)
                {
                    //Bounded testin formdetail ini bulup collectiona ekle
                    ProcedureDefinition boundedProcedureDefinition = (ProcedureDefinition)boundedTestDef.LaboratoryTest;
                    BindingList<ProcedureRequestFormDetailDefinition> procedureRequestFormDetailList = ProcedureRequestFormDetailDefinition.GetProcedureRequestFormDetailByProcedureDefinition(objContext, boundedProcedureDefinition.ObjectID);

                    foreach (ProcedureRequestFormDetailDefinition reqFormDetDef in procedureRequestFormDetailList)
                    {
                        if (reqFormDetDef.ProcedureRequestCategory.ProcedureRequestForm.ObjectID.ToString() == ttProcedureRequestFormDetail.ProcedureRequestCategory.ProcedureRequestForm.ObjectID.ToString())
                        {
                            var vmProcedureRequestDetailDefinitionBoundedTest = new vmProcedureRequestDetailDefinition();
                            vmProcedureRequestDetailDefinitionBoundedTest.Id = reqFormDetDef.ObjectID;
                            vmProcedureRequestDetailDefinitionBoundedTest.Code = boundedProcedureDefinition.Code;
                            vmProcedureRequestDetailDefinitionBoundedTest.Name = boundedProcedureDefinition.Name;
                            vmProcedureRequestDetailDefinitionBoundedTest.ProcedureObjectDefID = boundedProcedureDefinition.ObjectID;
                            vmProcedureRequestDetailDefinitionBoundedTest.Checked = false;
                            vmProcedureRequestDetailDefinitionBoundedTest.IsActive = true;
                            vmProcedureRequestDetailDefinition.BoundedProcedureRequestDetails.Add(vmProcedureRequestDetailDefinitionBoundedTest);
                            break;
                        }
                    }
                }
            }
        }

        public void SetGroupTestsForProcedureRequestDetail(ProcedureRequestFormDetailDefinition ttProcedureRequestFormDetail, ref vmProcedureRequestDetailDefinition vmProcedureRequestDetailDefinition, TTObjectContext objContext)
        {
            //LaboratoryTestDefinition IsGroupTest ise BagimliTetkik gridindeki testler GroupProcedureRequestDetails listesine dolduruluyor.
            if (((LaboratoryTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).IsGroupTest == true)
            {
                if (((LaboratoryTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).PanelTests.Count > 0)
                {

                    foreach (LaboratoryGridPanelTestDefinition groupTestDef in ((LaboratoryTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).PanelTests)
                    {
                        //GroupTest in formdetail ini bulup collectiona ekle
                        ProcedureDefinition groupProcedureDefinition = (ProcedureDefinition)groupTestDef.LaboratoryTest;
                        BindingList<ProcedureRequestFormDetailDefinition> procedureRequestFormDetailList = ProcedureRequestFormDetailDefinition.GetProcedureRequestFormDetailByProcedureDefinition(objContext, groupProcedureDefinition.ObjectID);

                        foreach (ProcedureRequestFormDetailDefinition reqFormDetDef in procedureRequestFormDetailList)
                        {
                            if (reqFormDetDef.ProcedureRequestCategory.ProcedureRequestForm.ObjectID.ToString() == ttProcedureRequestFormDetail.ProcedureRequestCategory.ProcedureRequestForm.ObjectID.ToString())
                            {
                                var vmProcedureRequestDetailDefinitionGroupTest = new vmProcedureRequestDetailDefinition();
                                vmProcedureRequestDetailDefinitionGroupTest.Id = reqFormDetDef.ObjectID;
                                vmProcedureRequestDetailDefinitionGroupTest.Code = groupProcedureDefinition.Code;
                                vmProcedureRequestDetailDefinitionGroupTest.Name = groupProcedureDefinition.Name;
                                vmProcedureRequestDetailDefinitionGroupTest.ProcedureObjectDefID = groupProcedureDefinition.ObjectID;
                                vmProcedureRequestDetailDefinitionGroupTest.Checked = false;
                                vmProcedureRequestDetailDefinitionGroupTest.IsActive = true;
                                vmProcedureRequestDetailDefinition.GroupProcedureRequestDetails.Add(vmProcedureRequestDetailDefinitionGroupTest);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void SetWorkingDayOfProcedureRequestDetail(ProcedureRequestFormDetailDefinition ttProcedureRequestFormDetail, ref vmProcedureRequestDetailDefinition vmProcedureRequestDetailDefinition, TTObjectContext objContext)
        {
            //RadyolojiTest lerinde viewmodel e calısılan gunler yuklenecek.
            vmProcedureRequestDetailDefinition.IsWorkingDay = false;
            var currentDay = DateTime.Now.DayOfWeek;
            switch (currentDay)
            {
                case DayOfWeek.Monday:
                    if (((RadiologyTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).OnMonday == true)
                        vmProcedureRequestDetailDefinition.IsWorkingDay = true;
                    break;
                case DayOfWeek.Tuesday:
                    if (((RadiologyTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).OnTuesday == true)
                        vmProcedureRequestDetailDefinition.IsWorkingDay = true;
                    break;
                case DayOfWeek.Wednesday:
                    if (((RadiologyTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).OnWednesday == true)
                        vmProcedureRequestDetailDefinition.IsWorkingDay = true;
                    break;
                case DayOfWeek.Thursday:
                    if (((RadiologyTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).OnThursday == true)
                        vmProcedureRequestDetailDefinition.IsWorkingDay = true;
                    break;
                case DayOfWeek.Friday:
                    if (((RadiologyTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).OnFriday == true)
                        vmProcedureRequestDetailDefinition.IsWorkingDay = true;
                    break;
                case DayOfWeek.Saturday:
                    if (((RadiologyTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).OnSaturday == true)
                        vmProcedureRequestDetailDefinition.IsWorkingDay = true;
                    break;
                case DayOfWeek.Sunday:
                    if (((RadiologyTestDefinition)ttProcedureRequestFormDetail.ProcedureDefinition).OnSunday == true)
                        vmProcedureRequestDetailDefinition.IsWorkingDay = true;
                    break;
            }

        }


        [HttpPost]
        public string SaveProcedureRequest(List<Guid> CheckedProcedureObjectId)
        {
            return TTUtils.CultureService.GetText("M25245", "Başarılı kaydedildi");
        }

        [HttpPost]
        public vmRequestedProcedure GetProcedureRequestInfo(AdditionalAppInfoInputDVO inputDVO)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            ProcedureDefinition ttProcedureDefinition = (ProcedureDefinition)objContext.GetObject(new Guid(inputDVO.ProcedureDefObjectId), "ProcedureDefinition");
            vmRequestedProcedure vmRequestedProcedure = new vmRequestedProcedure();
            vmRequestedProcedure.Id = ttProcedureDefinition.ObjectID;
            vmRequestedProcedure.ProcedureCode = ttProcedureDefinition.Code;
            vmRequestedProcedure.ProcedureName = ttProcedureDefinition.Name;
            vmRequestedProcedure.RequestedByResUser = Common.CurrentResource.Name;
            vmRequestedProcedure.RequestedById = (Guid)Common.CurrentUser.TTObjectID;
            vmRequestedProcedure.Amount = 1;
            vmRequestedProcedure.DailyMedulaProvisionNecessity = ttProcedureDefinition.DailyMedulaProvisionNecessity;

            vmRequestedProcedure.isReportRequired = ttProcedureDefinition.ReportSelectionRequired == true ? true : false;
            vmRequestedProcedure.isPathologyRequired = ttProcedureDefinition.PathologyOperationNeeded == true ? true : false;
            vmRequestedProcedure.isResultNeeded = ttProcedureDefinition.IsResultNeeded == true ? true : false;
            vmRequestedProcedure.RightLeftInfoNeeded = ttProcedureDefinition.RightLeftInfoNeeded;
            if (vmRequestedProcedure.ProcedureCode == "700050")
                vmRequestedProcedure.isSkinPrickTest = true;
            else
                vmRequestedProcedure.isSkinPrickTest = false;

            if (ttProcedureDefinition is RadiologyTestDefinition)
            {
                vmRequestedProcedure.isRadiologyProcedure = true;
                vmRequestedProcedure.isRISIntegrated = ((RadiologyTestDefinition)ttProcedureDefinition).IsRISEntegratedTest;
            }
            else
            {
                vmRequestedProcedure.isRadiologyProcedure = false;
            }
            //Hizmetin fiyatını bulma kodu, hizmetin eşleşmiş bir fiyatı yoksa exception verip istem anında uyarı verilip kesilecek.
            //Hizmet fiyatinin gosteriminden vazgecildigi icin asagidaki kod kapatildi.
            try
            {
                EpisodeAction ea = (EpisodeAction)objContext.GetObject(new Guid(inputDVO.EpisodeActionObjectId), "EpisodeAction");

                if (ea.SubEpisode != null)
                {
                    if (ea.SubEpisode.OpenSubEpisodeProtocol != null)
                    {
                        SubEpisodeProtocol sep = ea.SubEpisode.OpenSubEpisodeProtocol;
                        DateTime serverTime = TTObjectDefManager.ServerTime;
                        DateTime pricingDate = serverTime;

                        ArrayList col = new ArrayList();
                        col = sep.Protocol.CalculatePrice(ttProcedureDefinition, ea.Episode.PatientStatus, null, pricingDate, ea.Episode.Patient.AgeCompleted);
                        Currency procedurePrice = 0;
                        foreach (ManipulatedPrice mpd in col)
                        {
                            if (mpd.PayerPrice > 0)
                                procedurePrice = procedurePrice + (Currency)mpd.PayerPrice;

                            if (mpd.PatientPrice > 0)
                                procedurePrice = procedurePrice + (Currency)mpd.PatientPrice;
                        }
                        vmRequestedProcedure.UnitPrice = (double)procedurePrice;

                    }
                }
            }
            catch { }
            return vmRequestedProcedure;
        }

        [HttpGet]
        public string GetRelatedPhysiotherapyTestForm(string ProcedureCode)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            string formName = "";
            IList<GetRelatedPhysiotherapyForm_Class> forms = SurgeryDefinition.GetRelatedPhysiotherapyForm(objContext, "Where Code = '" + ProcedureCode + "'");
            try
            {
                switch (forms[0].PhysiotherapyFormName)
                {
                    case PhysiotherapyFormsEnum.MuscleTestForm:
                        formName = "MuscleTestFormForm";
                        break;
                    case PhysiotherapyFormsEnum.AmputeeAssessmentForm:
                        formName = "AmputeeAssessmentFormForm";
                        break;
                    case PhysiotherapyFormsEnum.IsokineticTestForm:
                        formName = "IsokineticTestFormForm";
                        break;
                    case PhysiotherapyFormsEnum.BalanceCoordinationTestsForm:
                        formName = "BalanceCoordinationTestsFormForm";
                        break;
                    case PhysiotherapyFormsEnum.SensoryPerceptionAssessmentForm:
                        formName = "SensoryPerceptionAssessmentFormForm";
                        break;
                    case PhysiotherapyFormsEnum.RangeOfMotionMeasurementForm:
                        formName = "RangeOfMotionMeasurementFormForm";
                        break;
                    case PhysiotherapyFormsEnum.ManualDexterityTestsForm:
                        formName = "ManualDexterityTestsFormForm";
                        break;
                    case PhysiotherapyFormsEnum.ElectrodiagnosticTestsForm:
                        formName = "ElectrodiagnosticTestsForm";
                        break;
                    case PhysiotherapyFormsEnum.DailyActivityTestsForm:
                        formName = "DailyActivityTestsFormForm";
                        break;
                    case PhysiotherapyFormsEnum.MuscleStrengthMeasuringForm:
                        formName = "MuscleStrengthMeasuringFormForm";
                        break;
                    case PhysiotherapyFormsEnum.OccupationalAssessmentForm:
                        formName = "OccupationalAssessmentFormForm";
                        break;
                    case PhysiotherapyFormsEnum.NeurophysiologicalAssessmentForm:
                        formName = "NeurophysiologicalAssessmentFormForm";
                        break;
                    case PhysiotherapyFormsEnum.PostureAnalysisForm:
                        formName = "PostureAnalysisFormForm";
                        break;
                    case PhysiotherapyFormsEnum.ScoliosisAssessmentForm:
                        formName = "ScoliosisAssessmentFormForm";
                        break;
                    case PhysiotherapyFormsEnum.GaitAnalysisForm:
                        formName = "GaitAnalysisFormForm";
                        break;
                    case PhysiotherapyFormsEnum.GaitAnalysisComputerBasedForm:
                        formName = "GaitAnalysisComputerBasedFormForm";
                        break;
                }
            }
            catch (Exception)
            {
               ;
            }

            return formName;
        }

        [HttpGet]
        public bool IsDescriptionNeeded(string ProcedureCode)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            bool isDescriptionNeeded = false;
            IList<GetNeedDescription_Class> forms = SurgeryDefinition.GetNeedDescription(objContext, "Where Code = '" + ProcedureCode + "'");
            if (forms[0].IsDescriptionNeeded != null)
                isDescriptionNeeded = (bool)forms[0].IsDescriptionNeeded;
            return isDescriptionNeeded;
        }

        [HttpGet]
        public void UpdateBaseAdditionalApplicationDescription(string SubActionProcedureObjectId, string Description)
        {
            SubActionProcedure sa;
            using (var context = new TTObjectContext(false))
            {
                sa = context.GetObject<SubActionProcedure>(new Guid(SubActionProcedureObjectId));
                if (sa is BaseAdditionalApplication)
                {
                    ((BaseAdditionalApplication)sa).Description = Description;
                    context.Save();
                }
            }
        }

        [HttpGet]
        public string GetPatientName(string ObjectID)
        {
            Patient patient;
            using (var context = new TTObjectContext(false))
            {
                patient = context.GetObject<Patient>(new Guid(ObjectID));
            }
            return patient.Name + " " + patient.Surname;
        }


        [HttpGet]
        public SubEpisode GetSubepisode(string ObjectID)
        {
            SubEpisode sepisode;
            using (var context = new TTObjectContext(false))
            {
                sepisode = context.GetObject<SubEpisode>(new Guid(ObjectID));
            }
            return sepisode;
        }

        [HttpGet]
        public List<DateTime?> GetDateList(string ObjectID)
        {
            DateTime? RequestDate = null;
            DateTime? ClosingDate = null;
            DateTime? SubEpisodeOpeningDate = null;
            DateTime? SubEpisodeClosingDate = null;
            List<DateTime?> DateList = new List<DateTime?>();

            using (var context = new TTObjectContext(false))
            {
                EpisodeAction ea = context.GetObject<EpisodeAction>(new Guid(ObjectID));
                if (ea.SubEpisode != null)
                {
                    SubEpisodeOpeningDate = ea.SubEpisode.OpeningDate;
                    SubEpisodeClosingDate = ea.SubEpisode.ClosingDate;

                    if (ea is PatientExamination || ea is Consultation || ea is DentalExamination)
                    {
                        ClosingDate = ((PhysicianApplication)ea).ProcessEndDate;
                    }
                }
                var RecTime = Common.RecTime();
                if (RecTime.Date > ((DateTime)SubEpisodeOpeningDate).Date && SubEpisodeClosingDate == null)
                {
                    if (ea is PatientExamination)
                    {
                        if (((PatientExamination)ea).ProcessDate == null)
                            RequestDate = RecTime;
                        else
                            RequestDate = ((PatientExamination)ea).ProcessDate;
                    }
                    else if (ea is DentalExamination)
                    {
                        if (((DentalExamination)ea).ProcessDate == null)
                            RequestDate = RecTime;
                        else
                            RequestDate = ((DentalExamination)ea).ProcessDate;
                    }
                    else if (ea is Consultation)
                    {
                        if (((Consultation)ea).ProcessDate == null)
                            RequestDate = RecTime;
                        else
                            RequestDate = ((Consultation)ea).ProcessDate;
                    }
                    else
                        RequestDate = RecTime;

                    //    else if( ea is InPatientPhysicianApplication && ((InPatientPhysicianApplication)ea).InPatientTreatmentClinicApp.IsDailyOperation == true 

                }

                else if (ClosingDate == null || RecTime <= ea.SubEpisode.ClosingDate)
                    RequestDate = RecTime;
                else
                {
                    if ((ea is EmergencyIntervention || ea is PatientExamination || ea is DentalExamination || ea is InPatientPhysicianApplication)
                        && ea.Episode.GetActiveInpatientAdmission() != null)
                    {
                        InpatientAdmission activeInpatient = ea.Episode.GetActiveInpatientAdmission();
                        if (activeInpatient.InPatientTreatmentClinicApplications[0].IsDailyOperation == true)
                        {
                            RequestDate = activeInpatient.RequestDate;
                        }

                        else
                        {
                            RequestDate = SubEpisodeOpeningDate;
                        }
                    }
                    else if (ea.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Outpatient && ClosingDate != null)
                    {
                        if (ea is PatientExamination)
                            RequestDate = ((PatientExamination)ea).ProcessDate;
                        else if (ea is Consultation)
                            RequestDate = ((Consultation)ea).ProcessDate;
                        else if (ea is DentalExamination)
                            RequestDate = ((DentalExamination)ea).ProcessDate;

                    }
                    else if ((ea.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient || ea.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Daily) && SubEpisodeOpeningDate != null && SubEpisodeClosingDate != null)
                        RequestDate = SubEpisodeOpeningDate;
                    else
                        RequestDate = null;
                }

                DateList.Add(RequestDate);
                DateList.Add(SubEpisodeOpeningDate);
                DateList.Add(SubEpisodeClosingDate);
                DateList.Add(ClosingDate);
            }
            return DateList;
        }

        [HttpGet]
        public vmPackageTemplate GetPackageTemplateDetail(string PackageTemplateObjectId)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            PackageTemplateDefinition ttPackageTempDef = (PackageTemplateDefinition)objContext.GetObject(new Guid(PackageTemplateObjectId), "PackageTemplateDefinition");
            vmPackageTemplate packageTemplate = new vmPackageTemplate();
            List<vmPackageProcedure> packageProcedureList = new List<vmPackageProcedure>();
            List<vmPackageTemplateICD> packageICDList = new List<vmPackageTemplateICD>();

            foreach (PackageTemplateProcReqFormDetailDefinition packageProcReqFormDetDef in ttPackageTempDef.ProcedureRequestFormDetailDefinitions)
            {
                if (packageProcReqFormDetDef.ProcedureReqFormDetailDef != null)
                {
                    vmPackageProcedure vmPackProc = new vmPackageProcedure();
                    vmPackProc.Id = packageProcReqFormDetDef.ProcedureReqFormDetailDef.ObjectID;
                    vmPackProc.ProcedureCode = packageProcReqFormDetDef.ProcedureReqFormDetailDef.ProcedureDefinition.Code;
                    vmPackProc.ProcedureName = packageProcReqFormDetDef.ProcedureReqFormDetailDef.ProcedureDefinition.Name;
                    vmPackProc.isAdditionalApplication = false;
                    packageProcedureList.Add(vmPackProc);
                }
            }


            foreach (PackageTemplateProcedureDefinition packageProcDef in ttPackageTempDef.ProcedureDefinitions)
            {
                if (packageProcDef.ProcedureDefinition != null)
                {
                    vmPackageProcedure vmPackProc = new vmPackageProcedure();
                    vmPackProc.Id = packageProcDef.ProcedureDefinition.ObjectID;
                    vmPackProc.ProcedureCode = packageProcDef.ProcedureDefinition.Code;
                    vmPackProc.ProcedureName = packageProcDef.ProcedureDefinition.Name;
                    vmPackProc.isAdditionalApplication = true;


                    packageProcedureList.Add(vmPackProc);
                }
            }

            foreach (PackageTemplateICDDetailDefinition packageTempICDDef in ttPackageTempDef.PackageTemplateICDs)
            {
                if (packageTempICDDef.Diagnose != null)
                {
                    vmPackageTemplateICD vmPackICD = new vmPackageTemplateICD();
                    vmPackICD.DiagnoseObjectId = packageTempICDDef.Diagnose.ObjectID;
                    vmPackICD.DiagnoseCode = packageTempICDDef.Diagnose.Code;
                    vmPackICD.DiagnoseName = packageTempICDDef.Diagnose.Name;
                    vmPackICD.Diagnose = packageTempICDDef.Diagnose;
                    packageICDList.Add(vmPackICD);
                }
            }

            packageTemplate.PackageICDs = packageICDList;
            packageTemplate.PackageProcedures = packageProcedureList;
            return packageTemplate;
        }
        [HttpPost]
        public void CancelPathologyRequiredProcedures(string[] pathologyRequiredProcedureObjectIDs)
        {
            TTObjectContext objContext = new TTObjectContext(false);

            foreach(string objectID in pathologyRequiredProcedureObjectIDs)
            {
                SubActionProcedure subActionProcedure = (SubActionProcedure)objContext.GetObject(new Guid(objectID), "SubActionProcedure");
                subActionProcedure.CurrentStateDefID = SubActionProcedure.States.Cancelled;


            }
            objContext.Save();
        }

       


        [HttpGet]
        public bool CancelRequestedProcedure(string SubactionProcedureObjectId)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            SubActionProcedure subActionProcedure = (SubActionProcedure)objContext.GetObject(new Guid(SubactionProcedureObjectId), "SubActionProcedure");

            if (subActionProcedure.ProcedureObject is LaboratoryTestDefinition)
            {
                if (((LaboratoryProcedure)subActionProcedure).CurrentStateDefID == LaboratoryProcedure.States.SampleAccept) //Ilk state Istek Kabul, bu asamada ıse ıptal edılmesıne ızın verılecek.
                {
                    ((LaboratoryProcedure)subActionProcedure).CurrentStateDefID = LaboratoryProcedure.States.Cancelled;
                    objContext.Save();
                    return true;
                }
            }
            //RadiologyTestDef
            else if (subActionProcedure.ProcedureObject is RadiologyTestDefinition)
            {
                if (((RadiologyTest)subActionProcedure).CurrentStateDefID == RadiologyTest.States.RequestAcception) //Ilk state Istek Kabul, bu asamada ıse ıptal edılmesıne ızın verılecek.
                {
                    ((RadiologyTest)subActionProcedure).CurrentStateDefID = RadiologyTest.States.Cancelled;
                    objContext.Save();
                    return true;
                }
            }
            //NuclearMedicineTestDef
            else if (subActionProcedure.ProcedureObject is NuclearMedicineTestDefinition)
            {
                NuclearMedicineTest nuclearTest = (NuclearMedicineTest)subActionProcedure;
                if (nuclearTest.NuclearMedicine != null)
                {
                    if (nuclearTest.NuclearMedicine.CurrentStateDefID == NuclearMedicine.States.RequestAcception) //NuclearMedicine episodeaction i İstek kabul aşamasında ise hem action iptal edilecek. NuclearMedicineTest subaction i da iptal edilmiş olacak.
                    {
                        nuclearTest.NuclearMedicine.CurrentStateDefID = NuclearMedicine.States.Cancelled;
                        objContext.Save();
                        return true;
                    }
                }
            }
            //PathologyTestDefinition
            else if (subActionProcedure.ProcedureObject is PathologyTestDefinition)
            {
                if (((PathologyTestProcedure)subActionProcedure).CurrentStateDefID == PathologyTestProcedure.States.New)
                {
                    ((PathologyTestProcedure)subActionProcedure).CurrentStateDefID = PathologyTestProcedure.States.Cancelled;
                    objContext.Save();
                    return true;
                }
            }
            //PsychologyProcedureDefiniton
            else if (subActionProcedure.ProcedureObject is PsychologyProcedureDefiniton)
            {
                if (((PsychologyTest)subActionProcedure).CurrentStateDefID == PsychologyTest.States.New)
                {
                    ((PsychologyTest)subActionProcedure).CurrentStateDefID = PsychologyTest.States.Cancelled;
                    objContext.Save();
                    return true;
                }
            }
            else if(subActionProcedure.ProcedureObject is SurgeryDefinition)
            {
                if(((SurgeryDefinition)subActionProcedure.ProcedureObject).SurgeryProcedureType == SurgeyProcedureTypeEnum.OnlyManipulation  || ((SurgeryDefinition)subActionProcedure.ProcedureObject).SurgeryProcedureType == SurgeyProcedureTypeEnum.ManipulationAdditionalApplication ||  ((SurgeryDefinition)subActionProcedure.ProcedureObject).SurgeryProcedureType == SurgeyProcedureTypeEnum.SurgeryAndManiplation)
                {
                    if (subActionProcedure.CurrentStateDefID == SubActionProcedure.States.New || subActionProcedure.CurrentStateDefID == SubActionProcedure.States.Completed)
                    {
                        subActionProcedure.CurrentStateDefID = SubActionProcedure.States.Cancelled;
                        if(subActionProcedure is ManipulationProcedure && ((ManipulationProcedure)subActionProcedure).Manipulation != null)
                            ((ManipulationProcedure)subActionProcedure).Manipulation.CurrentStateDefID = Manipulation.States.Cancelled;

                        objContext.Save();
                        return true;
                    }
                }
                else
                { 
                    //State New ya da Completed ıse ıptal edılmesıne ızın verılecek.
                    if (subActionProcedure.CurrentStateDefID == SubActionProcedure.States.New || subActionProcedure.CurrentStateDefID == SubActionProcedure.States.Completed)
                    {
                        subActionProcedure.CurrentStateDefID = SubActionProcedure.States.Cancelled;
                        objContext.Save();
                        return true;
                    }
                }
            }
            else
            {
                //State New ya da Completed ıse ıptal edılmesıne ızın verılecek.
                if (subActionProcedure.CurrentStateDefID == SubActionProcedure.States.New || subActionProcedure.CurrentStateDefID == SubActionProcedure.States.Completed)
                {
                    subActionProcedure.CurrentStateDefID = SubActionProcedure.States.Cancelled;
                    objContext.Save();
                    return true;
                }
            }



            return false;
        }

        [HttpGet]
        public bool UpdateRightLeftInformation(string SubactionProcedureObjectId, int newValue)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            SubActionProcedure subActionProcedure = (SubActionProcedure)objContext.GetObject(new Guid(SubactionProcedureObjectId), "SubActionProcedure");

            var packageProc = subActionProcedure.EpisodeAction.SubactionProcedures.Where(x => x.MasterSubActionProcedure != null && x.MasterSubActionProcedure.ObjectID == subActionProcedure.ObjectID).FirstOrDefault();

            if(packageProc != null)
            {
                packageProc.RightLeftInformation = (RightLeftEnum)newValue;
            }
            subActionProcedure.RightLeftInformation = (RightLeftEnum)newValue;
            objContext.Save();

            return true;
        }

        //Fonksiyon hem tetkikler icin hem de sık kullanılanlar tabı icin cagriliyor. Hizmet de gelebilir
        [HttpPost]
        public vmRequestedProcedure GetRequestFormDetailProcedureRequestInfo(ProcedureReqInfoInputDVO inputDVO)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            ProcedureRequestFormDetailDefinition ttProcedureRequestFormDetailDefinition = (ProcedureRequestFormDetailDefinition)objContext.GetObject(new Guid(inputDVO.CheckedFormDetailObjectId), "ProcedureRequestFormDetailDefinition");
            vmRequestedProcedure vmRequestedProcedure = new vmRequestedProcedure();
            vmRequestedProcedure.Id = ttProcedureRequestFormDetailDefinition.ObjectID;
            vmRequestedProcedure.ProcedureCode = ttProcedureRequestFormDetailDefinition.ProcedureDefinition.Code;
            vmRequestedProcedure.ProcedureName = ttProcedureRequestFormDetailDefinition.ProcedureDefinition.Name;
            vmRequestedProcedure.ProcedureObjectId = ttProcedureRequestFormDetailDefinition.ProcedureDefinition.ObjectID;
            vmRequestedProcedure.ProcedureObjectDefId = ttProcedureRequestFormDetailDefinition.ProcedureDefinition.ObjectDef.ID;
            vmRequestedProcedure.RequestDate = Common.RecTime();
            vmRequestedProcedure.RequestedByResUser = Common.CurrentResource.Name;
            vmRequestedProcedure.RequestedById = (Guid)Common.CurrentUser.TTObjectID;
            vmRequestedProcedure.MasterResource = ttProcedureRequestFormDetailDefinition.ObservationUnit?.Name;
            if (ttProcedureRequestFormDetailDefinition.ObservationUnit != null)
                vmRequestedProcedure.MasterResourceObjectId = (Guid)ttProcedureRequestFormDetailDefinition.ObservationUnit.ObjectID;
            vmRequestedProcedure.Amount = 1;
            vmRequestedProcedure.isGroupTest = false;
            if (inputDVO.IsAdditionalApplication != null)
                vmRequestedProcedure.isAdditionalApplication = inputDVO.IsAdditionalApplication.Value;
            else
                vmRequestedProcedure.isAdditionalApplication = false;
            vmRequestedProcedure.isPathologyRequired = ttProcedureRequestFormDetailDefinition.ProcedureDefinition.PathologyOperationNeeded == true ? true : false;
            vmRequestedProcedure.isResultNeeded = ttProcedureRequestFormDetailDefinition.ProcedureDefinition.IsResultNeeded == true ? true : false;
            vmRequestedProcedure.RightLeftInfoNeeded = ttProcedureRequestFormDetailDefinition.ProcedureDefinition.RightLeftInfoNeeded;
            if (vmRequestedProcedure.ProcedureCode == "700050")
                vmRequestedProcedure.isSkinPrickTest = true;
            else
                vmRequestedProcedure.isSkinPrickTest = false;

            if (ttProcedureRequestFormDetailDefinition.ProcedureDefinition is LaboratoryTestDefinition)
            {
                vmRequestedProcedure.ProcedureType = "LAB";
                LaboratoryTestDefinition labTestDef = (LaboratoryTestDefinition)ttProcedureRequestFormDetailDefinition.ProcedureDefinition;
                if (labTestDef.RequiresBinaryScanForm == true || labTestDef.RequiresTripleTestForm == true || labTestDef.RequiresUreaBreathTestReport == true || labTestDef.TestDescription != null)
                {
                    string procedureInst = "";
                    string instReportName = "";
                    if (labTestDef.RequiresBinaryScanForm == true)
                    {
                        procedureInst = procedureInst + TTUtils.CultureService.GetText("M26037", "İkili Tarama Formu Gerektirir\n");
                        instReportName = instReportName + "LaboratoryBinaryScanInfoReport" + "|";
                    }

                    if (labTestDef.RequiresTripleTestForm == true)
                    {
                        procedureInst = procedureInst + TTUtils.CultureService.GetText("M27161", "Üçlü Test Formu Gerektirir\n");
                        instReportName = instReportName + "LaboratoryTripleTestInfoReport" + "|";
                    }

                    if (labTestDef.RequiresUreaBreathTestReport == true)
                    {
                        procedureInst = procedureInst + TTUtils.CultureService.GetText("M27164", "Üre Nefes Testi Hasta Talimat Raporunu Gerektirir\n");
                        instReportName = instReportName + "UreaBreathTestPatientInstructionReport" + "|";
                    }

                    if (labTestDef.TestDescription != null)
                    {
                        procedureInst = procedureInst + labTestDef.TestDescription;
                        instReportName = instReportName + "LaboratoryTestPatientInstructionReport" + "|";
                    }

                    vmRequestedProcedure.hasProcedureInstruction = true;
                    vmRequestedProcedure.ProcedureInstructions = procedureInst;
                    vmRequestedProcedure.ProcedureInstructionReportName = instReportName;
                }

                if (labTestDef.IsGroupTest == true)
                    vmRequestedProcedure.isGroupTest = true;
            }

            if (ttProcedureRequestFormDetailDefinition.ProcedureDefinition is RadiologyTestDefinition)
            {
                vmRequestedProcedure.ProcedureType = "RAD";
                RadiologyTestDefinition radTestDef = (RadiologyTestDefinition)ttProcedureRequestFormDetailDefinition.ProcedureDefinition;
                if (radTestDef.RadiologyTestDescriptions.Count > 0)
                {
                    string procedureInst = "";
                    foreach (RadiologyGridTestDescriptionDefinition RadGridTestDef in radTestDef.RadiologyTestDescriptions)
                    {
                        procedureInst = procedureInst + RadGridTestDef.TestDescription?.Description?.ToString() + "\n";
                    }

                    vmRequestedProcedure.hasProcedureInstruction = true;
                    vmRequestedProcedure.ProcedureInstructions = procedureInst;
                }
                if (inputDVO.EpisodeActionObjectId != null)
                {
                    string alertMsg = radTestDef.GetMyAlertMessage(new Guid(inputDVO.EpisodeActionObjectId));
                    if (!string.IsNullOrEmpty(alertMsg))
                        vmRequestedProcedure.AlertMessage = alertMsg;
                }
            

            vmRequestedProcedure.isRadiologyProcedure = true;
            vmRequestedProcedure.isRISIntegrated = radTestDef.IsRISEntegratedTest;
        }else
                vmRequestedProcedure.isRadiologyProcedure = false;

            if (ttProcedureRequestFormDetailDefinition.ProcedureDefinition is PathologyTestDefinition)
            {
                vmRequestedProcedure.ProcedureType = "PAT";
            }

            if (ttProcedureRequestFormDetailDefinition.ProcedureDefinition is PsychologyProcedureDefiniton)
            {
                vmRequestedProcedure.ProcedureType = "PSYCH";
            }

            if (ttProcedureRequestFormDetailDefinition.ObservationUnit?.IsExternalObservationUnit == true)
                vmRequestedProcedure.isExternalProcedureRequest = true;
            else
                vmRequestedProcedure.isExternalProcedureRequest = false;


            //ProcedureRequestFormDetail e surgerydefinition tipinde ek uygulamalar ve islemler de tanimlanabiliyor. 
            //Onlar da vmRequestedProcedure  olarak ekleniyor.
            if (ttProcedureRequestFormDetailDefinition.ProcedureDefinition is SurgeryDefinition)
            {
                if (!String.IsNullOrEmpty(inputDVO.ProcedureByUserId))
                {
                    ResUser procedureResUser = (ResUser)objContext.GetObject(new Guid(inputDVO.ProcedureByUserId), "ResUser");
                    vmRequestedProcedure.ProcedureResUser = procedureResUser.Name;
                    vmRequestedProcedure.ProcedureUserId = procedureResUser.ObjectID;
                }

                SurgeryDefinition surgeryDef = (SurgeryDefinition)ttProcedureRequestFormDetailDefinition.ProcedureDefinition;
                if (surgeryDef.SurgeryProcedureType == SurgeyProcedureTypeEnum.OnlyAdditionalApplication || surgeryDef.SurgeryProcedureType == SurgeyProcedureTypeEnum.ManipulationAdditionalApplication)
                    vmRequestedProcedure.isAdditionalApplication = true;
            }


            //Artık fiyat gösterilmediği için aşağıdaki kod kapatılmıştır. by cons†an†ine
            //Tekrar fiyat istendiği için kod açıldı. ASLI
            //Hizmetin fiyatını bulma kodu, hizmetin eşleşmiş bir fiyatı yoksa exception verip istem anında uyarı verilip kesilecek.
            try
            {
                EpisodeAction ea = (EpisodeAction)objContext.GetObject(new Guid(inputDVO.EpisodeActionObjectId), "EpisodeAction");
                if (ea.SubEpisode != null)
                {
                    if (ea.SubEpisode.OpenSubEpisodeProtocol != null)
                    {
                        SubEpisodeProtocol sep = ea.SubEpisode.OpenSubEpisodeProtocol;
                        DateTime serverTime = TTObjectDefManager.ServerTime;
                        DateTime pricingDate = serverTime;

                        ArrayList col = new ArrayList();
                        col = sep.Protocol.CalculatePrice(ttProcedureRequestFormDetailDefinition.ProcedureDefinition, ea.Episode.PatientStatus, null, pricingDate, ea.Episode.Patient.AgeCompleted);


                        Currency procedurePrice = 0;
                        foreach (ManipulatedPrice mpd in col)
                        {
                            if (mpd.PayerPrice > 0)
                                procedurePrice = procedurePrice + (Currency)mpd.PayerPrice;

                            if (mpd.PatientPrice > 0)
                                procedurePrice = procedurePrice + (Currency)mpd.PatientPrice;
                        }
                        vmRequestedProcedure.UnitPrice = (double)procedurePrice;


                    }
                }
            }
            catch { }

            return vmRequestedProcedure;
        }

        public class AddMostUsedProcedureRequestFormParam
        {
            public Guid ProcedureObjectID
            {
                get;
                set;
            }
            public Guid ObservationUnit
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void AddMostUsedProcedureRequestForm(AddMostUsedProcedureRequestFormParam param)
        {
            //CurrentUser a tanımlı bır ProcedureRequestForm varsa get edilecek, yoksa olusturulacak
            TTObjectContext objContext = new TTObjectContext(false);
            List<Guid> resourceList = new List<Guid>();
            resourceList.Add(Common.CurrentResource.ObjectID);

            IBindingList requestUnitProcFormList = RequestUnitOfProcedureForm.GetFormsByResourceIDs(objContext, resourceList);
            if (requestUnitProcFormList != null && requestUnitProcFormList.Count > 0)
            {
                //TODO: aynı hızmet eklenmemelı
                RequestUnitOfProcedureForm myRequestUnitProcForm = (RequestUnitOfProcedureForm)requestUnitProcFormList[0];
                ProcedureRequestFormDefinition myFormDef = myRequestUnitProcForm.ProcedureRequestFormDef;
                if (myFormDef != null)
                {
                    ProcedureRequestCategoryDefinition myProcReqCat = myFormDef.FormCategory[0];
                    if (myProcReqCat != null)
                    {
                        List<ProcedureRequestFormDetailDefinition> procReqFormDetailList = new List<ProcedureRequestFormDetailDefinition>();

                        int maxOrderNo = 1;
                        if (myProcReqCat.FormDetail.Count > 0)
                        {
                            procReqFormDetailList = myProcReqCat.FormDetail.OrderBy(dr => dr.OrderNo).ToList();
                            foreach (ProcedureRequestFormDetailDefinition procReqFormDetail in procReqFormDetailList)
                            {
                                if (procReqFormDetail.ProcedureDefinition.ObjectID == param.ProcedureObjectID)
                                    throw new Exception("Eklenmek istenen hizmet Sık Kullanılanlar Panelinde tanımlıdır. Tekrar eklenemez!");
                            }

                            if (procReqFormDetailList.LastOrDefault().OrderNo != null)
                                maxOrderNo = (int)procReqFormDetailList.LastOrDefault().OrderNo + 1;

                        }
                        ProcedureRequestFormDetailDefinition myProcReqFormDetail = new ProcedureRequestFormDetailDefinition(objContext);
                        ProcedureDefinition myProcedureDef = (ProcedureDefinition)objContext.GetObject(param.ProcedureObjectID, "ProcedureDefinition");
                        ResObservationUnit myResObservationUnit = null;
                        if (param.ObservationUnit != Guid.Empty)
                            myResObservationUnit = (ResObservationUnit)objContext.GetObject(param.ObservationUnit, "ResObservationUnit");

                        myProcReqFormDetail.ProcedureDefinition = myProcedureDef;
                        myProcReqFormDetail.ObservationUnit = myResObservationUnit;
                        myProcReqFormDetail.OrderNo = maxOrderNo;
                        myProcReqFormDetail.ProcedureRequestCategory = myProcReqCat;

                        objContext.Save();
                    }
                    else
                        throw new Exception("Kullanıcıya tanımlı Sık Kullanılanlar Paneli kategorisinin yüklemesinde sorun oluştu.");
                }
                else
                    throw new Exception("Kullanıcıya tanımlı Sık Kullanılanlar Paneli formunun yüklemesinde sorun oluştu.");

            }
            else //Kullanıcı ıcın ılk kez Sık Kullanılanlar Panelı olusturuluyor.
            {
                RequestUnitOfProcedureForm myRequestUnitProcForm = new RequestUnitOfProcedureForm(objContext);
                Resource myResource = (Resource)Common.CurrentResource;

                ProcedureRequestFormDefinition myFormDef = new ProcedureRequestFormDefinition(objContext);
                myFormDef.Name = myResource.Name + "-Sık Kullanılanlar";

                ProcedureRequestCategoryDefinition myProcReqCat = new ProcedureRequestCategoryDefinition(objContext);
                myProcReqCat.CategoryName = "Sık Kullanılanlar"; //Doktor ekranlarında görülen isimdir. Değiştirilmemeli.
                myProcReqCat.ProcedureRequestForm = myFormDef;

                ProcedureRequestFormDetailDefinition myProcReqFormDetail = new ProcedureRequestFormDetailDefinition(objContext);
                ProcedureDefinition myProcedureDef = (ProcedureDefinition)objContext.GetObject(param.ProcedureObjectID, "ProcedureDefinition");
                ResObservationUnit myResObservationUnit = null;
                if (param.ObservationUnit != Guid.Empty)
                    myResObservationUnit = (ResObservationUnit)objContext.GetObject(param.ObservationUnit, "ResObservationUnit");

                myProcReqFormDetail.ProcedureDefinition = myProcedureDef;
                myProcReqFormDetail.ObservationUnit = myResObservationUnit;
                myProcReqFormDetail.OrderNo = 1;
                myProcReqFormDetail.ProcedureRequestCategory = myProcReqCat;



                myRequestUnitProcForm.Resource = myResource;
                myRequestUnitProcForm.ProcedureRequestFormDef = myFormDef;

                objContext.Save();

            }
        }


        [HttpGet]
        public void ExcludeFromMostUsedProcedureRequestForm(Guid procedureRequestFormDetailID)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            ProcedureRequestFormDetailDefinition myProcReqFormDetail = (ProcedureRequestFormDetailDefinition)objContext.GetObject(procedureRequestFormDetailID, "ProcedureRequestFormDetailDefinition");
            if (myProcReqFormDetail != null)
            {
                ((ITTObject)myProcReqFormDetail).Delete();
                objContext.Save();
            }
            else
                throw new Exception("Sık Kullanılanlar Panelinden çıkarma işleminde sorun oluştu. Seçilen Hizmet/Tetkik detayı bulunamadı!");

        }

        [HttpPost]
        public List<vmRequestedProcedure> GetBloodProductProcedureInfo(string EpisodeActionObjectId)
        {
            

            TTObjectContext objContext = new TTObjectContext(true);
            List<XXXXXXIHEWS.HastaUrun> bloodProductList = new List<XXXXXXIHEWS.HastaUrun>();
            List<XXXXXXIHEWS.HastaKanIstem> bloodRequestList = new List<XXXXXXIHEWS.HastaKanIstem>();
            List<vmRequestedProcedure> vmRequestedProcedureList = new List<vmRequestedProcedure>();
            //bloodProductList = BloodProductRequest.GetPatientBloodRequestFromLIS(EpisodeActionObjectId);
         // bloodRequestList = BloodProductRequest.GetPatientNewBloodRequestFromLIS(EpisodeActionObjectId);
            foreach (XXXXXXIHEWS.HastaKanIstem bloodRequest in bloodRequestList)
            {
                string bloodRequestID = bloodRequest.ISTEM_ID;
                foreach (XXXXXXIHEWS.HastaUrun bloodProduct in bloodRequest.HastaUrunler)
                {
                    BindingList<ProcedureDefinition> procedureDefList = TTObjectClasses.ProcedureDefinition.GetByCode(objContext, bloodProduct.URUN_LOINC_KODU, "");
                    if (procedureDefList.Count > 0)
                    {
                        vmRequestedProcedure vmRequestedProcedure = new vmRequestedProcedure();
                        //ProcedureDefinition in baglı oldugu ProcedureRequestFormDetailDefinition objesinin ID si get ediliyor. 
                        //EpisodeAction Kaydet te action ve subactıonprocedure un fire edilmesi icin gerekli.
                        BindingList<ProcedureRequestFormDetailDefinition> procedureRequestDetailDefList = TTObjectClasses.ProcedureRequestFormDetailDefinition.GetProcedureRequestFormDetailByProcedureDefinition(objContext, procedureDefList[0].ObjectID);
                        if (procedureRequestDetailDefList.Count > 0)
                        {
                            vmRequestedProcedure.Id = procedureRequestDetailDefList[0].ObjectID;
                            vmRequestedProcedure.ProcedureCode = procedureDefList[0].Code;
                            vmRequestedProcedure.ProcedureName = procedureDefList[0].Name;
                            vmRequestedProcedure.ProcedureObjectDefId = procedureDefList[0].ObjectID;
                            vmRequestedProcedure.ProcedureType = "BLOODREQ";
                            vmRequestedProcedure.RequestDate = Convert.ToDateTime(bloodRequest.ISTEM_TARIHI);
                            vmRequestedProcedure.MasterResource = procedureRequestDetailDefList[0].ObservationUnit.Name;
                            vmRequestedProcedure.Amount = 1;
                            vmRequestedProcedure.ExternalProcedureId = bloodProduct.HASTAURUNENTEG_ID + "|" + bloodRequestID;
                            EpisodeAction ea = (EpisodeAction)objContext.GetObject(new Guid(EpisodeActionObjectId), "EpisodeAction");
                            if (ea.SubEpisode != null)
                            {
                                if (ea.SubEpisode.OpenSubEpisodeProtocol != null)
                                {
                                    if (procedureDefList[0].GetProcedurePrice(ea.SubEpisode.OpenSubEpisodeProtocol, DateTime.Now) != null)
                                    {
                                        vmRequestedProcedure.UnitPrice = (double)procedureDefList[0].GetProcedurePrice(ea.SubEpisode.OpenSubEpisodeProtocol, DateTime.Now);
                                    }
                                }
                            }

                            vmRequestedProcedureList.Add(vmRequestedProcedure);
                        }
                        else
                            throw new Exception("Kan Ürün İstemin form detay tanımı bulunamadı! İstenilen kan ürün istem: " + procedureDefList[0].Code + "-" + procedureDefList[0].Name);
                    }
                    else
                        throw new Exception("İstenilen LOINC koduna ait Kan Ürün İstem hizmet tanımı bulunamadı! İstenilen LOINC Kodu: " + bloodProduct.URUN_LOINC_KODU);
                }
                //Kan urunlerı ıcın calısılan testlerı de requestedProcedure e ekleyecek.
                //string requiredTestLOINCCodes = bloodRequest.KBTESTLER;
                /*
                    if (bloodRequest.KBTESTLER != "" && bloodRequest.KBTESTLER != null)
                    {
                        string[] testLOINCCodesList = bloodRequest.KBTESTLER.Split('&');

                       //TODO: test kodlarının bızım tarafta loınc eslemsı yapılması gerekıyor

                        foreach (string loincCode in testLOINCCodesList)
                        {
                            BindingList<ProcedureDefinition> procedureDefList = TTObjectClasses.ProcedureDefinition.GetByLOINCCode(objContext, loincCode);
                            if (procedureDefList.Count > 0)
                            {
                                vmRequestedProcedure vmRequestedProcedure = new vmRequestedProcedure();

                                //ProcedureDefinition in baglı oldugu ProcedureRequestFormDetailDefinition objesinin ID si get ediliyor. 
                                //EpisodeAction Kaydet te action ve subactıonprocedure un fire edilmesi icin gerekli.
                                BindingList<ProcedureRequestFormDetailDefinition> procedureRequestDetailDefList = TTObjectClasses.ProcedureRequestFormDetailDefinition.GetProcedureRequestFormDetailByProcedureDefinition(objContext, procedureDefList[0].ObjectID);

                                if (procedureRequestDetailDefList.Count > 0)
                                {

                                    vmRequestedProcedure.Id = procedureRequestDetailDefList[0].ObjectID;
                                    vmRequestedProcedure.ProcedureCode = procedureDefList[0].Code;
                                    vmRequestedProcedure.ProcedureName = procedureDefList[0].Name;
                                    vmRequestedProcedure.RequestDate = DateTime.Now;
                                    vmRequestedProcedure.RequestBy = Common.CurrentUser.FullName;
                                    vmRequestedProcedure.MasterResource = procedureRequestDetailDefList[0].ObservationUnit.Name;
                                    vmRequestedProcedure.Amount = 1;

                                    EpisodeAction ea = (EpisodeAction)objContext.GetObject(new Guid(EpisodeActionObjectId), "EpisodeAction");
                                    if (ea.SubEpisode != null)
                                    {
                                        if (ea.SubEpisode.OpenSubEpisodeProtocol != null)
                                        {
                                            if (procedureDefList[0].GetProcedurePrice(ea.SubEpisode.OpenSubEpisodeProtocol, DateTime.Now) != null)
                                            {
                                                vmRequestedProcedure.UnitPrice = (double)procedureDefList[0].GetProcedurePrice(ea.SubEpisode.OpenSubEpisodeProtocol, DateTime.Now);
                                            }
                                        }
                                    }
                                    vmRequestedProcedureList.Add(vmRequestedProcedure);
                                }
                                else
                                    throw new Exception("Kan Ürün İstemin form detay tanımı bulunamadı! İstenilen kan test tanımı: " + procedureDefList[0].Code + "-" + procedureDefList[0].Name);
                            }
                            else
                                throw new Exception("İstenilen LOINC koduna ait kan test tanımı bulunamadı! İstenilen LOINC Kodu: " + loincCode);
                        }
                    } */
            }

            return vmRequestedProcedureList;
        }

        [HttpPost]
        public void AddPackageTemplateDefinition(vmPackageTemplateDefinition PackageTemplateDef)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            Resource ownerResource = (Resource)objContext.GetObject(Common.CurrentResource.ObjectID, "Resource");

            PackageTemplateDefinition newPackTemplateDef = new PackageTemplateDefinition(objContext);
            newPackTemplateDef.Code = PackageTemplateDef.Code;
            newPackTemplateDef.Name = PackageTemplateDef.Name;
            newPackTemplateDef.PackageOwnerResource = ownerResource;

            foreach (Guid reqId in PackageTemplateDef.PackageRequestedProcedures)
            {

                IBindingList procReqFormDet = ProcedureRequestFormDetailDefinition.GetProcedureRequestFormDetailByObjectId(objContext, reqId);
                if (procReqFormDet.Count > 0)
                {
                    PackageTemplateProcReqFormDetailDefinition packTempProcReqFormDet = new PackageTemplateProcReqFormDetailDefinition(objContext);
                    packTempProcReqFormDet.ProcedureReqFormDetailDef = (ProcedureRequestFormDetailDefinition)procReqFormDet[0];
                    newPackTemplateDef.ProcedureRequestFormDetailDefinitions.Add(packTempProcReqFormDet);
                }
                else
                {
                    PackageTemplateProcedureDefinition packTempProcDef = new PackageTemplateProcedureDefinition(objContext);
                    ProcedureDefinition procedureDef = (ProcedureDefinition)objContext.GetObject(reqId, "ProcedureDefinition");
                    packTempProcDef.ProcedureDefinition = procedureDef;
                    newPackTemplateDef.ProcedureDefinitions.Add(packTempProcDef);
                }

            }

            foreach (Guid ICDId in PackageTemplateDef.PackageICDs)
            {
                PackageTemplateICDDetailDefinition packICDDef = new PackageTemplateICDDetailDefinition(objContext);
                DiagnosisDefinition icd = (DiagnosisDefinition)objContext.GetObject(ICDId, "DiagnosisDefinition");
                packICDDef.Diagnose = icd;
                newPackTemplateDef.PackageTemplateICDs.Add(packICDDef);
            }

            objContext.Save();
        }

        [HttpPost]
        public void UpdatePackageTemplateDefinition(vmPackageTemplateDefinition PackageTemplateDef)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            Resource ownerResource = (Resource)objContext.GetObject(Common.CurrentResource.ObjectID, "Resource");

            PackageTemplateDefinition newPackTemplateDef = (PackageTemplateDefinition)objContext.GetObject(PackageTemplateDef.ObjectId, "PackageTemplateDefinition"); //new PackageTemplateDefinition(objContext);  this.ViewModel._selectedPackageValue
            newPackTemplateDef.Name = PackageTemplateDef.Name;

            #region var olan hizmet ve tanılar siliniyor.

            var packageTemplateICDList = newPackTemplateDef.PackageTemplateICDs.ToList();
            foreach (var item in packageTemplateICDList)
            {
                PackageTemplateICDDetailDefinition packageTemplateICD = newPackTemplateDef.PackageTemplateICDs.Where(c => c.ObjectID == item.ObjectID).FirstOrDefault();
                ((ITTObject)packageTemplateICD).Delete();
            }

            var procedureDefinitionsList = newPackTemplateDef.ProcedureDefinitions.ToList();
            foreach (var item in procedureDefinitionsList)
            {
                PackageTemplateProcedureDefinition procedureDefinition = newPackTemplateDef.ProcedureDefinitions.Where(c => c.ObjectID == item.ObjectID).FirstOrDefault();
                ((ITTObject)procedureDefinition).Delete();
            }

            var procedureRequestFormDetailDefinitionsList = newPackTemplateDef.ProcedureRequestFormDetailDefinitions.ToList();
            foreach (var item in procedureRequestFormDetailDefinitionsList)
            {
                PackageTemplateProcReqFormDetailDefinition procedureRequestFormDetailDefinition = newPackTemplateDef.ProcedureRequestFormDetailDefinitions.Where(c => c.ObjectID == item.ObjectID).FirstOrDefault();
                ((ITTObject)procedureRequestFormDetailDefinition).Delete();
            }
            #endregion var olan hizmet ve tanılar siliniyor.

            #region yeni olan hizmet ve tanılar siliniyor.
            foreach (Guid reqId in PackageTemplateDef.PackageRequestedProcedures)
            {

                IBindingList procReqFormDet = ProcedureRequestFormDetailDefinition.GetProcedureRequestFormDetailByObjectId(objContext, reqId);
                if (procReqFormDet.Count > 0)
                {
                    PackageTemplateProcReqFormDetailDefinition packTempProcReqFormDet = new PackageTemplateProcReqFormDetailDefinition(objContext);
                    packTempProcReqFormDet.ProcedureReqFormDetailDef = (ProcedureRequestFormDetailDefinition)procReqFormDet[0];
                    newPackTemplateDef.ProcedureRequestFormDetailDefinitions.Add(packTempProcReqFormDet);
                }
                else
                {
                    PackageTemplateProcedureDefinition packTempProcDef = new PackageTemplateProcedureDefinition(objContext);
                    ProcedureDefinition procedureDef = (ProcedureDefinition)objContext.GetObject(reqId, "ProcedureDefinition");
                    packTempProcDef.ProcedureDefinition = procedureDef;
                    newPackTemplateDef.ProcedureDefinitions.Add(packTempProcDef);
                }

            }

            foreach (Guid ICDId in PackageTemplateDef.PackageICDs)
            {
                PackageTemplateICDDetailDefinition packICDDef = new PackageTemplateICDDetailDefinition(objContext);
                DiagnosisDefinition icd = (DiagnosisDefinition)objContext.GetObject(ICDId, "DiagnosisDefinition");
                packICDDef.Diagnose = icd;
                newPackTemplateDef.PackageTemplateICDs.Add(packICDDef);
            }
            #endregion yeni olan hizmet ve tanılar siliniyor.

            objContext.Save();
        }

        [HttpPost]
        //Hizlandirma calismasi icin dusunulmustu, kullanilmiyor.
        public vmRequestedProcedureForm GetRequestedProceduresFormViewModelSpeedy(QueryInputDVO inputDVO)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            List<vmRequestedProcedure> procedureList = new List<vmRequestedProcedure>();
            EpisodeAction ea = (EpisodeAction)objContext.GetObject(inputDVO.EpisodeActionObjectID, "EpisodeAction");

            // Iptaller Dahıl ıse tum hızmetler grıde eklenecek
            bool addAllProcedureList;
            if (inputDVO.IsCancelledIncluded == true)
                addAllProcedureList = true;
            else
                addAllProcedureList = false;

            List<SubActionProcedure> allRequestProceduresList = SubActionProcedure.GetRequestedProceduresOfSubEpisode(objContext, inputDVO.EndDate,inputDVO.StartDate,ea.Episode.ObjectID.ToString()).ToList();
            foreach (SubActionProcedure subActionProcedure in allRequestProceduresList)
            {
                bool addProcedureList = false;
                if (addAllProcedureList == false)
                {
                    if (subActionProcedure.CurrentStateDefID != SubActionProcedure.States.Cancelled)
                        addProcedureList = true;
                    else
                        addProcedureList = false;
                }

                //İşlem 'NURSINGORDERDETAIL','SINGLENURSINGORDERDETAIL','DIETORDERDETAIL' türünde bir işlemse ücret kaydı oluşmussa ProcedureList e eklenecek.


                if (addAllProcedureList == true || addProcedureList == true)
                {
                    vmRequestedProcedure requestedProcedure = new vmRequestedProcedure();
                    setRequestedProcedureBaseProperties(ref requestedProcedure, subActionProcedure);

                    //LaboratoryTestDef
                    if (subActionProcedure is LaboratoryProcedure)
                        setRequestedProcedureLaboratoryProperties(ref requestedProcedure, subActionProcedure);
                    //RadiologyTestDef
                    else if (subActionProcedure is RadiologyTest)
                        setRequestedProcedureRadiologyProperties(ref requestedProcedure, subActionProcedure);
                    else if (subActionProcedure is NuclearMedicineTest)
                        setRequestedProcedureNuclearMedicineProperties(ref requestedProcedure, subActionProcedure);
                    //PathologyTestDef
                    else if (subActionProcedure is PathologyTestProcedure)
                        setRequestedProcedurePathologyProperties(ref requestedProcedure, subActionProcedure);
                    //SurgeryDef - Manipulation
                    else if (subActionProcedure is ManipulationProcedure)
                        setRequestedProcedureManipulationProperties(ref requestedProcedure, subActionProcedure);
                    else if (subActionProcedure is PsychologyTest)
                        setRequestedProcedurePsychologyProperties(ref requestedProcedure, subActionProcedure);
                    //BaseAdditionalApplication turundeki hizmetler icin BaseAdditionalInfoForm datası varsa yuklenecek
                    else if (subActionProcedure is BaseAdditionalApplication)
                        setRequestedProcedureBaseApplicationProperties(ref requestedProcedure, subActionProcedure);

                    procedureList.Add(requestedProcedure);
                }
            }

            vmRequestedProcedureForm _vmRequestedProcedureForm = new vmRequestedProcedureForm();

            if (ea.SubEpisode != null)
            {
                _vmRequestedProcedureForm.SubEpisodeOpeningDate = ea.SubEpisode.OpeningDate;
                _vmRequestedProcedureForm.SubEpisodeClosingDate = ea.SubEpisode.ClosingDate;
            }
            var RecTime = Common.RecTime();
            if (_vmRequestedProcedureForm.SubEpisodeClosingDate == null || RecTime <= ea.SubEpisode.ClosingDate)
                _vmRequestedProcedureForm.RequestDate = RecTime;
            else
                _vmRequestedProcedureForm.RequestDate = null;


            if (inputDVO.PhysicianSuggestionsIsActive == true)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("DOKTORKARARDESTEK", "TRUE") == "TRUE" && ea.MasterResource.HimssRequired == true)
                    _vmRequestedProcedureForm.ProcedureSuggestionInputDVOList = GetProcedureSuggestionInputDVOListByProcedureList(ea.SubEpisode);
            }

            if (ea.SubEpisode.IsSGK == true)
                _vmRequestedProcedureForm.IsSGKPatient = true;

            _vmRequestedProcedureForm.PatientTCNo = ea.Episode.Patient.UniqueRefNo?.ToString();
            _vmRequestedProcedureForm.PatientObjectId = ea.Episode.Patient.ObjectID.ToString();
            _vmRequestedProcedureForm.RequestedProcedureList = procedureList;

            return _vmRequestedProcedureForm;
        }

        public void setRequestedProcedureBaseProperties(ref vmRequestedProcedure requestedProcedure, SubActionProcedure inputSubActProcedure)
        {
            requestedProcedure.SubActionProcedureObjectId = (Guid)inputSubActProcedure.ObjectID;
            requestedProcedure.ProcedureObjectId = (Guid)inputSubActProcedure.ProcedureObject.ObjectID;
            requestedProcedure.EpisodeActionObjectId = (Guid)inputSubActProcedure.EpisodeAction.ObjectID;
            requestedProcedure.ProcedureCode = inputSubActProcedure.ProcedureObject.Code;
            requestedProcedure.ProcedureName = inputSubActProcedure.ProcedureObject.Name;
            requestedProcedure.ProcedureObjectDefId = (Guid)inputSubActProcedure.ProcedureObject.ObjectDef.ID;

            if (inputSubActProcedure.CreationDate != null)
                requestedProcedure.RequestDate = (DateTime)inputSubActProcedure.CreationDate;

            if (inputSubActProcedure.RequestedByUser != null)
            {
                requestedProcedure.RequestedByResUser = inputSubActProcedure.RequestedByUser.Name;
                requestedProcedure.RequestedById = (Guid)inputSubActProcedure.RequestedByUser.ObjectID;
            }
            if (inputSubActProcedure.ProcedureDoctor != null)
            {
                requestedProcedure.ProcedureResUser = inputSubActProcedure.ProcedureDoctor.Name;
                requestedProcedure.ProcedureUserId = (Guid)inputSubActProcedure.ProcedureDoctor.ObjectID;
            }


            Resource masterResource = inputSubActProcedure.EpisodeAction.MasterResource;
            requestedProcedure.MasterResource = masterResource.Name;
            requestedProcedure.MasterResourceObjectId = masterResource.ObjectID;
            requestedProcedure.Amount = Convert.ToInt32(inputSubActProcedure.Amount);

            if (inputSubActProcedure.Emergency != null)
                requestedProcedure.isEmergency = inputSubActProcedure.Emergency.Value;

            requestedProcedure.isAdditionalApplication = false;
            requestedProcedure.isResultShown = false;
            requestedProcedure.isReportShown = false;
            requestedProcedure.ActionStatus = inputSubActProcedure.CurrentStateDef.DisplayText;
            requestedProcedure.CurrentStateDefID = (Guid)inputSubActProcedure.CurrentStateDefID;
            requestedProcedure.StateStatus = Convert.ToInt32(inputSubActProcedure.CurrentStateDef.Status);
            requestedProcedure.isExternalProcedureRequest = false;
            requestedProcedure.isProcedureRejected = false;

            if (masterResource is ResObservationUnit)
            {
                if (((ResObservationUnit)masterResource).IsExternalObservationUnit == true)
                    requestedProcedure.isExternalProcedureRequest = true;
            }
            requestedProcedure.isAddedToMostUsedRequest = false;


        }

        public void setRequestedProcedureLaboratoryProperties(ref vmRequestedProcedure requestedProcedure, SubActionProcedure inputSubActProcedure)
        {
            LaboratoryProcedure labProcedure = (LaboratoryProcedure)inputSubActProcedure;
            LaboratoryTestDefinition labTestDef = (LaboratoryTestDefinition)labProcedure.ProcedureObject;

            requestedProcedure.isAddedToMostUsedRequest = true;
            requestedProcedure.ProcedureType = "LAB";
            requestedProcedure.StateStatus = Convert.ToInt32(inputSubActProcedure.CurrentStateDef.Status);
            if (requestedProcedure.CurrentStateDefID == LaboratoryProcedure.States.Completed) //Lab sonucclandı asamasında ıse sonuc gosterme lınkı set edılecek ve sonuc gosterme ikonlari ona gore visible olacak.
            {
                string reportURL = "";
                if (TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXENTEGRATION", "FALSE") == "TRUE")
                {
                    reportURL = GetReportURLFromLIS(labProcedure);
                    if (reportURL != "")
                    {
                        requestedProcedure.isReportShown = true;
                        requestedProcedure.ProcedureReportLink = reportURL;
                        if (labProcedure.IsResultSeen != null)
                            requestedProcedure.isResultSeen = (Boolean)labProcedure.IsResultSeen;
                        else
                            requestedProcedure.isResultSeen = false;
                    }
                    if (labProcedure.ApproveUser != null)
                    {
                        requestedProcedure.ProcedureResUser = labProcedure.ApproveUser.Name;
                        requestedProcedure.ProcedureUserId = (Guid)labProcedure.ApproveUser.ObjectID;
                    }
                }

                if (labTestDef.IsPanel == true)
                    requestedProcedure.isPanelTest = true;

                if (labTestDef.ProcedureTree != null && labTestDef.ProcedureTree.ObjectID.ToString() == "66022707-6322-4ece-b725-99ba1dcf0e56")
                {
                    requestedProcedure.isMikrobiyolojiTest = true;
                    requestedProcedure.mikrobiyolojiResult = labProcedure.ResultDescription;
                }
            }

            if (labTestDef.RequiresBinaryScanForm == true || labTestDef.RequiresTripleTestForm == true || labTestDef.RequiresUreaBreathTestReport == true || labTestDef.TestDescription != null)
            {
                string procedureInst = "";
                string instReportName = "";
                if (labTestDef.RequiresBinaryScanForm == true)
                {
                    procedureInst = procedureInst + TTUtils.CultureService.GetText("M26037", "İkili Tarama Formu Gerektirir\n");
                    instReportName = instReportName + "LaboratoryBinaryScanInfoReport" + "|";
                }

                if (labTestDef.RequiresTripleTestForm == true)
                {
                    procedureInst = procedureInst + TTUtils.CultureService.GetText("M27161", "Üçlü Test Formu Gerektirir\n");
                    instReportName = instReportName + "LaboratoryTripleTestInfoReport" + "|";
                }

                if (labTestDef.RequiresUreaBreathTestReport == true)
                {
                    procedureInst = procedureInst + TTUtils.CultureService.GetText("M27164", "Üre Nefes Testi Hasta Talimat Raporunu Gerektirir\n");
                    instReportName = instReportName + "UreaBreathTestPatientInstructionReport" + "|";
                }

                if (labTestDef.TestDescription != null)
                {
                    procedureInst = procedureInst + labTestDef.TestDescription;
                    instReportName = instReportName + "LaboratoryTestPatientInstructionReport" + "|";
                }

                requestedProcedure.hasProcedureInstruction = true;
                requestedProcedure.ProcedureInstructions = procedureInst;
                requestedProcedure.ProcedureInstructionReportName = instReportName;
            }

           
            if (inputSubActProcedure.CurrentStateDefID.ToString() == LaboratoryProcedure.States.SampleReject.ToString())
            {
                requestedProcedure.isProcedureRejected = true;
                if (labProcedure.ReasonOfReject != null)
                    requestedProcedure.RejectReason = Common.GetTextOfRTFString(labProcedure.ReasonOfReject.ToString());
            }

            if (labProcedure.Panic == LaboratoryAbnormalFlagsEnum.HH || labProcedure.Panic == LaboratoryAbnormalFlagsEnum.H || labProcedure.Panic == LaboratoryAbnormalFlagsEnum.L || labProcedure.Panic == LaboratoryAbnormalFlagsEnum.LL)
            {
                requestedProcedure.hasPanicValue = true;
                requestedProcedure.PanicValue = labProcedure.Panic.ToString();
            }

            if (labProcedure.Result != null && labProcedure.Result != "")
            {
                requestedProcedure.ResultValue = labProcedure.Result + " " + labProcedure.Unit + " (" + labProcedure.Reference + ")";
            }


        }

        public void setRequestedProcedureRadiologyProperties(ref vmRequestedProcedure requestedProcedure, SubActionProcedure inputSubActProcedure)
        {

            requestedProcedure.isAddedToMostUsedRequest = true;
            requestedProcedure.ProcedureType = "RAD";
            requestedProcedure.StateStatus = Convert.ToInt32(inputSubActProcedure.CurrentStateDef.Status);
            if (requestedProcedure.CurrentStateDefID == RadiologyTest.States.Reported || requestedProcedure.CurrentStateDefID == RadiologyTest.States.Completed) //Radyoloji testi raporlandı veya cekim yapıldı asamasında ıse sonuc gosterme lınkı set edılecek ve sonuc gosterme ikonlari ona gore visible olacak.
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("PACSENTEGRATION", "FALSE") == "TRUE")
                {
                    RadiologyTest radTest = (RadiologyTest)inputSubActProcedure;
                    if (radTest.AccessionNo != null && radTest.AccessionNo.ToString() != "")
                    {
                        //string accessionNo = "";
                        //int numberOfZero = (7 - radTest.AccessionNo.ToString().Length);
                        //for (int i = 0; i < numberOfZero; i++)
                        //{
                        //    accessionNo = accessionNo + "0";
                        //}

                        //accessionNo = accessionNo + radTest.AccessionNo.ToString();
                        requestedProcedure.isResultShown = true;
                        if (TTObjectClasses.SystemParameter.GetParameterValue("YAPAYZEKAAKTIF", "FALSE") == "TRUE")
                        {
                            var AIProcedures = TTObjectClasses.SystemParameter.GetParameterValue("YAPAYZEKACALISACAKTESTLER", "");
                            var AIProcedureList = AIProcedures.Split(',').ToList();
                            if(AIProcedureList.Contains(requestedProcedure.ProcedureCode))
                                requestedProcedure.canAnalyzeWithAI = true;
                        }
                            requestedProcedure.isReportShown = true;
                        //requestedProcedure.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?an=" + accessionNo + "&usr=extreme"; //http://X.X.X.X:35005/?an=0000000&usr=extreme

                        if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "EXTREME")
                        {
                            requestedProcedure.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?an=" + radTest.AccessionNo.ToString() + "&usr=extreme";

                        }
                        else if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "COMPANY1") == "COMPANY2")
                        {
                            requestedProcedure.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?accession=" + radTest.AccessionNo.ToString() + "&patientid=" + radTest.EpisodeAction.Episode.Patient.UniqueRefNo?.ToString() + "&ietab=true";
                        }
                        else if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "XXXXXX")
                        {
                            requestedProcedure.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "&accession=" + radTest.AccessionNo.ToString() + "&StudyReload=1";
                        }

                        if (radTest.IsResultSeen != null)
                            requestedProcedure.isResultSeen = (Boolean)radTest.IsResultSeen;
                        else
                            requestedProcedure.isResultSeen = false;
                    }
                }
            }

            RadiologyTest radiologyTest = (RadiologyTest)inputSubActProcedure;
            RadiologyTestDefinition radTestDef = (RadiologyTestDefinition)radiologyTest.ProcedureObject;
            if (radTestDef.RadiologyTestDescriptions.Count > 0)
            {
                string procedureInst = "";
                foreach (RadiologyGridTestDescriptionDefinition RadGridTestDef in radTestDef.RadiologyTestDescriptions)
                {
                    procedureInst = procedureInst + RadGridTestDef.TestDescription?.Description?.ToString() + "\n";
                }

                requestedProcedure.hasProcedureInstruction = true;
                requestedProcedure.ProcedureInstructions = procedureInst;
            }
        }

        public void setRequestedProcedurePathologyProperties(ref vmRequestedProcedure requestedProcedure, SubActionProcedure inputSubActProcedure)
        {
            requestedProcedure.ProcedureType = "PAT";
            requestedProcedure.StateStatus = Convert.ToInt32(inputSubActProcedure.CurrentStateDef.Status);
            if (requestedProcedure.CurrentStateDefID == PathologyTestProcedure.States.Completed) //İşlem sonucclandı asamasında ıse  sonuc gosterme ikonlari ona gore visible olacak.
            {
                PathologyTestProcedure patTest = (PathologyTestProcedure)inputSubActProcedure;
                requestedProcedure.isResultShown = true;
                requestedProcedure.isReportShown = true;
                requestedProcedure.ProcedureReportLink = "";

                if (patTest.IsResultSeen != null)
                    requestedProcedure.isResultSeen = (Boolean)patTest.IsResultSeen;
                else
                    requestedProcedure.isResultSeen = false;
            }

        }

        public void setRequestedProcedureNuclearMedicineProperties(ref vmRequestedProcedure requestedProcedure, SubActionProcedure inputSubActProcedure)
        {
            requestedProcedure.ActionStatus = inputSubActProcedure.EpisodeAction.CurrentStateDef.DisplayText;
            requestedProcedure.StateStatus = Convert.ToInt32(inputSubActProcedure.CurrentStateDef.Status);
        }
        public void setRequestedProcedureManipulationProperties(ref vmRequestedProcedure requestedProcedure, SubActionProcedure inputSubActProcedure)
        {
            requestedProcedure.ProcedureType = "MANIPULATION";
            requestedProcedure.StateStatus = Convert.ToInt32(inputSubActProcedure.CurrentStateDef.Status);
            if (requestedProcedure.CurrentStateDefID == ManipulationProcedure.States.Completed) //İşlem tamamlandı ıse  sonuc gosterme ikonlari ona gore visible olacak.
            {
                // Surgery - Additional Applications - Maniulasyon hepsi SurgerDefinitiondan tanımlandığı için gelen guid her zman maniplasyon olmayabilir o durumda patlamasın diye NQL le çekildi 
                // ManipulationProcedure manTest = (ManipulationProcedure)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "ManipulationProcedure");
                ManipulationProcedure manTest = (ManipulationProcedure)inputSubActProcedure;
                requestedProcedure.isResultShown = true;
                requestedProcedure.isReportShown = true;
                requestedProcedure.ProcedureReportLink = "";

                if (manTest.IsResultSeen != null)
                    requestedProcedure.isResultSeen = (Boolean)manTest.IsResultSeen;
                else
                    requestedProcedure.isResultSeen = false;
            }

        }

        public void setRequestedProcedurePsychologyProperties(ref vmRequestedProcedure requestedProcedure, SubActionProcedure inputSubActProcedure)
        {
            requestedProcedure.ProcedureType = "PSYCH";
            requestedProcedure.StateStatus = Convert.ToInt32(inputSubActProcedure.CurrentStateDef.Status);
            if (requestedProcedure.CurrentStateDefID == PsychologyTest.States.Completed) //İşlem tamamlandı ıse  sonuc gosterme ikonlari ona gore visible olacak.
            {
                requestedProcedure.isResultShown = false;
                requestedProcedure.isReportShown = true;
                requestedProcedure.ProcedureReportLink = "";
            }

            if (inputSubActProcedure.ProcedureByUser != null)
            {
                requestedProcedure.ProcedureResUser = inputSubActProcedure.ProcedureByUser.Name;
                requestedProcedure.ProcedureUserId = (Guid)inputSubActProcedure.ProcedureByUser.ObjectID;
            }
        }

        public void setRequestedProcedureBaseApplicationProperties(ref vmRequestedProcedure requestedProcedure, SubActionProcedure inputSubActProcedure)
        {
            requestedProcedure.isAddedToMostUsedRequest = true;
            requestedProcedure.isAdditionalApplication = true;
            requestedProcedure.StateStatus = Convert.ToInt32(inputSubActProcedure.CurrentStateDef.Status);
            BaseAdditionalApplication baseAddApp = (BaseAdditionalApplication)inputSubActProcedure;
            if (baseAddApp.BaseAdditionalInfoForm != null)
            {
                requestedProcedure.BaseAdditionalInfoFormGuids = new List<Guid>();
                foreach (BaseAdditionalInfo baseAdditionalInfoForm in baseAddApp.BaseAdditionalInfoForm)
                {
                    requestedProcedure.BaseAdditionalInfoFormGuids.Add(baseAdditionalInfoForm.ObjectID);
                }
            }

            if (baseAddApp.Description != null)
            {
                requestedProcedure.Description = baseAddApp.Description;
            }
        }

        [HttpPost]
        public vmRequestedProcedureForm GetRequestedProceduresFormViewModel(QueryInputDVO inputDVO)
        {
            //return GetRequestedProceduresFormViewModelSpeedy(inputDVO);

            TTObjectContext objContext = new TTObjectContext(false);
            Dictionary<string, string> specimenIDDict = new Dictionary<string, string>();
            List<string> specimenIDList = new List<string>();
            long LastSpecimenId = 0;

            EpisodeAction ea = (EpisodeAction)objContext.GetObject(inputDVO.EpisodeActionObjectID, "EpisodeAction");

            if (TTObjectClasses.SystemParameter.GetParameterValue("GETLABRESULTSINREQUESTEDPROCFORM", "FALSE") == "TRUE")
            {
                BindingList<SubActionProcedure.GetRequestedProceduresByEpisode_Class> requestProceduresListForLIS = TTObjectClasses.SubActionProcedure.GetRequestedProceduresByEpisode(objContext, ea.Episode.ObjectID.ToString(), inputDVO.StartDate, inputDVO.EndDate);
                foreach (SubActionProcedure.GetRequestedProceduresByEpisode_Class subActionProc in requestProceduresListForLIS.ToList())
                {

                   
                    if (subActionProc.Procedureobjectdef.ToString() == "42ed5391-9525-457f-8412-500f7b0935bf") //laboratorytest definition
                    {

                        LaboratoryProcedure labProc = (LaboratoryProcedure)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "LaboratoryProcedure");

                        if (!String.IsNullOrEmpty(subActionProc.MasterSubActionProcedure.ToString()) && labProc.ProcedureObject.IsVisible != true )
                            continue;


                        //Numune Alma asamasinda iken de sorgulama yapilacak ama bu gecici olarak yapildi simdilik, 09/09/2017
                        if (labProc.CurrentStateDefID == LaboratoryProcedure.States.Procedure || labProc.CurrentStateDefID == LaboratoryProcedure.States.Approve || labProc.CurrentStateDefID == LaboratoryProcedure.States.SampleTaking)
                        {
                            if (labProc.SpecimenId > 0)
                            {
                                string outSpecimenID = "";
                                if (specimenIDDict.TryGetValue(labProc.SpecimenId.ToString(), out outSpecimenID) == false)
                                {
                                    specimenIDList.Add(labProc.SpecimenId.ToString());
                                    specimenIDDict.Add(labProc.SpecimenId.ToString(), outSpecimenID);
                                }
                            }
                        }
                    }

                }

                if (specimenIDList.Count > 0)
                    LaboratoryRequest.AskResultsFromLISBySpecimenIDList(specimenIDList);

            }

            List<vmRequestedProcedure> procedureList = new List<vmRequestedProcedure>(); //ekranda bulunan subepisode icindeki hizmetleri tutar


            //Sonuc Update leri oldugu ıcın  subactıonprocedure ler yenıden yuklenmelı
            // Iptaller Dahıl ıse tum hızmetler grıde eklenecek
            bool addAllProcedureList;
            if (inputDVO.IsCancelledIncluded == true)
                addAllProcedureList = true;
            else
                addAllProcedureList = false;



            //  List<SubActionProcedure.GetRequestedProceduresBySubEpisode_Class> requestProceduresList = TTObjectClasses.SubActionProcedure.GetRequestedProceduresBySubEpisode(objContext, ea.SubEpisode.ObjectID.ToString(), inputDVO.StartDate, inputDVO.EndDate).ToList();

            List<SubActionProcedure.GetRequestedProceduresByEpisode_Class> allRequestProceduresList = new List<SubActionProcedure.GetRequestedProceduresByEpisode_Class>();
            if ((ea.ActionType == ActionTypeEnum.InPatientPhysicianApplication 
                && ((InPatientPhysicianApplication)ea).InPatientTreatmentClinicApp != null 
                && ((InPatientPhysicianApplication)ea).InPatientTreatmentClinicApp.IsDailyOperation != true)
                || ea.ActionType == ActionTypeEnum.HealthCommitteeExamination
                || ea.ActionType == ActionTypeEnum.Surgery
                || ea.ActionType == ActionTypeEnum.Consultation
                || ea.ActionType == ActionTypeEnum.AnesthesiaAndReanimation)
            {
                string filter = " AND THIS.EPISODEACTION.SubEpisode = '" + ea.SubEpisode.ObjectID.ToString() + "' ";
                allRequestProceduresList = TTObjectClasses.SubActionProcedure.GetRequestedProceduresByEpisode(objContext, ea.Episode.ObjectID.ToString(), inputDVO.StartDate, inputDVO.EndDate, filter).ToList();
            }
            else
            {
                string inpatientFilter = "";
                List<Guid> subEpisodeList = new List<Guid>();
                if (!(ea is NursingApplication))
                {
                    foreach (InPatientTreatmentClinicApplication clinicApp in ea.Episode.InPatientTreatmentClinicApplications.Where(treatClinicApp => treatClinicApp.InPatientPhysicianApplication.Count != 0))
                    {
                        if (clinicApp.IsDailyOperation != true)
                        {
                            subEpisodeList.Add(clinicApp.SubEpisode.ObjectID);
                        }
                    }
                    if (subEpisodeList.Count > 0)
                    {
                        inpatientFilter = " AND THIS.EPISODEACTION.SubEpisode NOT IN (";
                        foreach (Guid value in subEpisodeList)
                            inpatientFilter += "'" + value.ToString() + "', ";
                        inpatientFilter = inpatientFilter.Remove(inpatientFilter.Length - 2, 1) + ") ";
                    }
                }
                allRequestProceduresList = TTObjectClasses.SubActionProcedure.GetRequestedProceduresByEpisode(objContext, ea.Episode.ObjectID.ToString(), inputDVO.StartDate, inputDVO.EndDate, inpatientFilter).ToList();
            }


            vmRequestedProcedureForm _vmRequestedProcedureForm = new vmRequestedProcedureForm();

            if (ea.SubEpisode != null)
            {
                _vmRequestedProcedureForm.SubEpisodeOpeningDate = ea.SubEpisode.OpeningDate;
                _vmRequestedProcedureForm.SubEpisodeClosingDate = ea.SubEpisode.ClosingDate;
                _vmRequestedProcedureForm.ClosingDate = ea.SubEpisode.ClosingDate;

                if(ea is PatientExamination || ea is Consultation || ea is DentalExamination)
                {
                    if (ea.Episode.GetActiveInpatientAdmission() != null)
                    {
                        InpatientAdmission activeInpatient = ea.Episode.GetActiveInpatientAdmission();
                        if (activeInpatient.InPatientTreatmentClinicApplications[0].IsDailyOperation != true)
                        {
                            _vmRequestedProcedureForm.ClosingDate = ((PhysicianApplication)ea).ProcessEndDate;
                        }
                    }
                    else
                        _vmRequestedProcedureForm.ClosingDate = ((PhysicianApplication)ea).ProcessEndDate;

                }
            }
            var RecTime = Common.RecTime();
            if (RecTime.Date > ((DateTime)_vmRequestedProcedureForm.SubEpisodeOpeningDate).Date  && _vmRequestedProcedureForm.SubEpisodeClosingDate == null)
            {
                if (ea is PatientExamination)
                {
                    if(((PatientExamination)ea).ProcessDate == null)
                        _vmRequestedProcedureForm.RequestDate = RecTime;
                    else
                        _vmRequestedProcedureForm.RequestDate = ((PatientExamination)ea).ProcessDate;
                }
                else if(ea is DentalExamination)
                {
                    if (((DentalExamination)ea).ProcessDate == null)
                        _vmRequestedProcedureForm.RequestDate = RecTime;
                    else
                        _vmRequestedProcedureForm.RequestDate = ((DentalExamination)ea).ProcessDate;
                }
                else if(ea is Consultation)
                {
                    if (((Consultation)ea).ProcessDate == null)
                        _vmRequestedProcedureForm.RequestDate = RecTime;
                    else
                        _vmRequestedProcedureForm.RequestDate = ((Consultation)ea).ProcessDate;
                }
                else
                    _vmRequestedProcedureForm.RequestDate = RecTime;

                //    else if( ea is InPatientPhysicianApplication && ((InPatientPhysicianApplication)ea).InPatientTreatmentClinicApp.IsDailyOperation == true 

            }

            else if (_vmRequestedProcedureForm.ClosingDate == null || RecTime <= ea.SubEpisode.ClosingDate)
                _vmRequestedProcedureForm.RequestDate = RecTime;
            else
            {
                if ((ea is EmergencyIntervention || ea is PatientExamination || ea is DentalExamination || ea is InPatientPhysicianApplication)
                    && ea.Episode.GetActiveInpatientAdmission() != null)
                {
                    InpatientAdmission activeInpatient = ea.Episode.GetActiveInpatientAdmission();
                    if(activeInpatient.InPatientTreatmentClinicApplications[0].IsDailyOperation == true)
                    {
                        _vmRequestedProcedureForm.RequestDate = activeInpatient.RequestDate;
                        _vmRequestedProcedureForm.ClosingDate = activeInpatient.SubEpisode.OpeningDate;

                    }

                    else
                    {
                        _vmRequestedProcedureForm.RequestDate = _vmRequestedProcedureForm.SubEpisodeOpeningDate;
                    }
                }
                else if(ea.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Outpatient && _vmRequestedProcedureForm.ClosingDate != null)
                {
                    if(ea is PatientExamination)
                        _vmRequestedProcedureForm.RequestDate = ((PatientExamination)ea).ProcessDate;
                    else if(ea is Consultation)
                        _vmRequestedProcedureForm.RequestDate = ((Consultation)ea).ProcessDate;
                    else if (ea is DentalExamination)
                        _vmRequestedProcedureForm.RequestDate = ((DentalExamination)ea).ProcessDate;

                }
                else if((ea.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient || ea.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Daily) && _vmRequestedProcedureForm.SubEpisodeOpeningDate != null &&_vmRequestedProcedureForm.SubEpisodeClosingDate != null)
                    _vmRequestedProcedureForm.RequestDate = _vmRequestedProcedureForm.SubEpisodeOpeningDate;
                else
                    _vmRequestedProcedureForm.RequestDate = null;
            }

         /*   if(ea is InPatientPhysicianApplication && ((InPatientPhysicianApplication)ea).InPatientTreatmentClinicApp.IsDailyOperation == true)
            {
                if (((InPatientPhysicianApplication)ea).InPatientTreatmentClinicApp.TreatmentDischarge.CurrentStateDefID == TreatmentDischarge.States.Discharged)
                    _vmRequestedProcedureForm.RequestDate = ((InPatientPhysicianApplication)ea).InPatientTreatmentClinicApp.ClinicInpatientDate;
                else if(((InPatientPhysicianApplication)ea).InPatientTreatmentClinicApp.TreatmentDischarge.CurrentStateDefID == TreatmentDischarge.States.PreDischarge)
            }*/

            
            _vmRequestedProcedureForm.RequestedProcedureList = CreateProcedureList(allRequestProceduresList, objContext, addAllProcedureList, ea); 

            if (inputDVO.PhysicianSuggestionsIsActive == true)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("DOKTORKARARDESTEK", "TRUE") == "TRUE" && ea.MasterResource.HimssRequired == true)
                    _vmRequestedProcedureForm.ProcedureSuggestionInputDVOList = GetProcedureSuggestionInputDVOListByProcedureList(ea.SubEpisode);
            }

            _vmRequestedProcedureForm.LastSpecimenId = LastSpecimenId.ToString();

            if (ea.SubEpisode.IsSGK == true)
                _vmRequestedProcedureForm.IsSGKPatient = true;

            _vmRequestedProcedureForm.PatientTCNo = ea.Episode.Patient.UniqueRefNo?.ToString();
            _vmRequestedProcedureForm.PatientObjectId = ea.Episode.Patient.ObjectID.ToString();
            _vmRequestedProcedureForm.ProtocolNo = ea.SubEpisode.ProtocolNo; //Kabul no alanının renklendirilmesinde kullanilacak kontrol icin
           

            return _vmRequestedProcedureForm;
        }

        public void GetExaminationProcedures(TTObjectContext objContext, EpisodeAction ea, QueryInputDVO inputDVO, List <PatientExamination> RelatedExaminations,
            List<SubActionProcedure.GetRequestedProceduresBySubEpisode_Class> controlExaminationRequestProceduresList, List<SubActionProcedure.GetRequestedProceduresBySubEpisode_Class> otherExaminationRequestProceduresList,
            List<SubActionProcedure.GetRequestedProceduresBySubEpisode_Class> inpatientRequestProceduresList)
        {
            foreach (PatientExamination relatedExamination in ea.Episode.PatientExaminations.Where(examination => examination.CurrentStateDefID != PatientExamination.States.Cancelled))
            {
                if (ea.ObjectID != relatedExamination.ObjectID)
                {
                    RelatedExaminations.Add(relatedExamination);
                    if (relatedExamination.PatientExaminationType == PatientExaminationEnum.Control)
                    {
                        if (controlExaminationRequestProceduresList.Count == 0)
                            controlExaminationRequestProceduresList = TTObjectClasses.SubActionProcedure.GetRequestedProceduresBySubEpisode(objContext, relatedExamination.SubEpisode.ObjectID.ToString(), inputDVO.StartDate, inputDVO.EndDate).ToList();
                        else
                           controlExaminationRequestProceduresList.AddRange(TTObjectClasses.SubActionProcedure.GetRequestedProceduresBySubEpisode(objContext, relatedExamination.SubEpisode.ObjectID.ToString(), inputDVO.StartDate, inputDVO.EndDate).ToList());
                    }
                    else
                    {
                        if (otherExaminationRequestProceduresList.Count == 0)
                            otherExaminationRequestProceduresList = TTObjectClasses.SubActionProcedure.GetRequestedProceduresBySubEpisode(objContext, relatedExamination.SubEpisode.ObjectID.ToString(), inputDVO.StartDate, inputDVO.EndDate).ToList();
                        else
                            otherExaminationRequestProceduresList.AddRange(TTObjectClasses.SubActionProcedure.GetRequestedProceduresBySubEpisode(objContext, relatedExamination.SubEpisode.ObjectID.ToString(), inputDVO.StartDate, inputDVO.EndDate).ToList());
                    }
                }
            }

            foreach (InPatientTreatmentClinicApplication inpatientObject in ea.Episode.InPatientTreatmentClinicApplications.Where(app => app.CurrentStateDefID != InPatientTreatmentClinicApplication.States.Cancelled && app.IsDailyOperation == true))
            {
                if (RelatedExaminations.Where(examination => examination.SubEpisode == inpatientObject.SubEpisode.OldSubEpisode).FirstOrDefault() != null)
                {
                    if (inpatientRequestProceduresList.Count == 0)
                        inpatientRequestProceduresList = TTObjectClasses.SubActionProcedure.GetRequestedProceduresBySubEpisode(objContext, inpatientObject.SubEpisode.ObjectID.ToString(), inputDVO.StartDate, inputDVO.EndDate).ToList();
                    else
                       inpatientRequestProceduresList.AddRange(TTObjectClasses.SubActionProcedure.GetRequestedProceduresBySubEpisode(objContext, inpatientObject.SubEpisode.ObjectID.ToString(), inputDVO.StartDate, inputDVO.EndDate).ToList());
                }
            }
        }


        private string ConditionGenerator(string columnName, List<string> list)
        {
            int count = list.Count;
            string condition = "";
            int page = 0;
            while(count > 0)
            {
                if(!string.IsNullOrEmpty(condition))
                {
                    condition += " OR ";
                }
                condition += columnName + " IN (";
                var items = string.Join(",", list.Skip(page * 1000).Take(1000));
                condition += items + ")";
                count -= 1000;
                page++;
            }
            return condition;
        }

        public List <vmRequestedProcedure> CreateProcedureList (List<SubActionProcedure.GetRequestedProceduresByEpisode_Class> inputList, TTObjectContext objContext, bool addAllProcedureList, EpisodeAction ea)
        {
            List<vmRequestedProcedure> resultList = new List<vmRequestedProcedure>();
            //     List<object> subActionProcList = new List<object>();

            var subActionProcedureObjectIds = inputList.Where(p => p.Subactionprocedureobjectid.HasValue)
                .Select(p => TTConnectionManager.ConnectionManager.GuidToString(p.Subactionprocedureobjectid.Value)).ToList();
            var procedureObjectIs = inputList.Where(p => p.Procedureobjectid.HasValue).Select(p => TTConnectionManager.ConnectionManager.GuidToString(p.Procedureobjectid.Value)).ToList();
            var resourceIds = inputList.Where(p => p.MasterResource.HasValue).Select(p => TTConnectionManager.ConnectionManager.GuidToString(p.MasterResource.Value)).ToList();
            var laboratoryProcedureIds = inputList.Where(p => p.Subactionprocedureobjectid.HasValue).Select(p => TTConnectionManager.ConnectionManager.GuidToString(p.Subactionprocedureobjectid.Value)).ToList();
            var radiologyTestIds = inputList.Where(p => p.Subactionprocedureobjectid.HasValue).Select(p => TTConnectionManager.ConnectionManager.GuidToString(p.Subactionprocedureobjectid.Value)).ToList();
            var nuclearMedicineIds = inputList.Where(p => p.Episodeactionobjectid.HasValue).Select(p => TTConnectionManager.ConnectionManager.GuidToString(p.Episodeactionobjectid.Value)).ToList();
            var pathologyTestProcedureIds = inputList.Where(p => p.Subactionprocedureobjectid.HasValue).Select(p => TTConnectionManager.ConnectionManager.GuidToString(p.Subactionprocedureobjectid.Value)).ToList();
            var manipulationProcedureIds = inputList.Where(p => p.Subactionprocedureobjectid.HasValue).Select(p => TTConnectionManager.ConnectionManager.GuidToString(p.Subactionprocedureobjectid.Value)).ToList();
            
            var subActionProcedureObjects = subActionProcedureObjectIds.Any() ? objContext.QueryObjects<SubActionProcedure>(ConditionGenerator("OBJECTID", subActionProcedureObjectIds)) : new BindingList<SubActionProcedure>();
            var procedureDefinitionObjects = procedureObjectIs.Any() ? objContext.QueryObjects<ProcedureDefinition>(ConditionGenerator("OBJECTID", procedureObjectIs)) : new BindingList<ProcedureDefinition>();
            var resourceObjects = resourceIds.Any() ? objContext.QueryObjects<Resource>(ConditionGenerator("OBJECTID", resourceIds)) : new BindingList<Resource>();
            var laboratoryProcedureObjects = laboratoryProcedureIds.Any() ? objContext.QueryObjects<LaboratoryProcedure>(ConditionGenerator("OBJECTID", laboratoryProcedureIds)) : new BindingList<LaboratoryProcedure>();
            var radiologyTestObjects = radiologyTestIds.Any() ? objContext.QueryObjects<RadiologyTest>(ConditionGenerator("OBJECTID", radiologyTestIds)) : new BindingList<RadiologyTest>();
            var nuclearMedicineObjects = nuclearMedicineIds.Any() ? objContext.QueryObjects<NuclearMedicine>(ConditionGenerator("OBJECTID", nuclearMedicineIds)) : new BindingList<NuclearMedicine>();
            var pathologyTestProcedureObjects = pathologyTestProcedureIds.Any() ? objContext.QueryObjects<PathologyTestProcedure>(ConditionGenerator("OBJECTID", pathologyTestProcedureIds)) : new BindingList<PathologyTestProcedure>();
            var manipulationProcedureObjects = manipulationProcedureIds.Any() ? objContext.QueryObjects<ManipulationProcedure>(ConditionGenerator("OBJECTID", manipulationProcedureIds)) : new BindingList<ManipulationProcedure>();

            foreach (SubActionProcedure.GetRequestedProceduresByEpisode_Class subActionProc in inputList)
            {
                //           subActionProcList[0].GetType().GetProperty("Subactionprocedureobjectid");

                SubActionProcedure sa = subActionProcedureObjects.FirstOrDefault(p => p.ObjectID == subActionProc.Subactionprocedureobjectid);
                //(SubActionProcedure)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "SubActionProcedure");

                ProcedureDefinition procedureDef = procedureDefinitionObjects.FirstOrDefault(p => p.ObjectID == subActionProc.Procedureobjectid);
                    //(ProcedureDefinition)objContext.GetObject((Guid)subActionProc.Procedureobjectid, "ProcedureDefinition");

                    if (!String.IsNullOrEmpty(subActionProc.MasterSubActionProcedure.ToString()) && procedureDef.IsVisible != true)
                      continue;

                bool addProcedureList = false;

                if (addAllProcedureList == false)
                    {
                        if (subActionProc.Statestatus.ToString() != "4")
                            addProcedureList = true;
                        else
                            addProcedureList = false;
                    }

                    if (addAllProcedureList == true || addProcedureList == true)
                    {
                        vmRequestedProcedure reqProc = new vmRequestedProcedure();
                        reqProc.SubActionProcedureObjectId = (Guid)subActionProc.Subactionprocedureobjectid;
                        reqProc.ProcedureObjectId = (Guid)subActionProc.Procedureobjectid;
                        reqProc.EpisodeActionObjectId = (Guid)subActionProc.Episodeactionobjectid;
                        reqProc.ProcedureCode = subActionProc.Procedurecode;
                        reqProc.ProcedureName = subActionProc.Procedurename;
                        reqProc.ProcedureObjectDefId = (Guid)subActionProc.Procedureobjectdef;
                        if (subActionProc.Requestdate != null)
                            reqProc.RequestDate = (DateTime)subActionProc.Requestdate;
                        if (subActionProc.Requestbyid != null)
                        {
                            reqProc.RequestedByResUser = subActionProc.Requestby;
                            reqProc.RequestedById = (Guid)subActionProc.Requestbyid;
                        }
                        if (subActionProc.Proceduredoctorid != null)
                        {
                            reqProc.ProcedureResUser = subActionProc.Proceduredoctorname;
                            reqProc.ProcedureUserId = (Guid)subActionProc.Proceduredoctorid;
                        }


                    Resource masterResource = resourceObjects.FirstOrDefault(p => p.ObjectID == subActionProc.MasterResource);
                        //(Resource)objContext.GetObject((Guid)subActionProc.MasterResource, "Resource");

                        reqProc.MasterResource = masterResource.Name;
                        reqProc.MasterResourceObjectId = masterResource.ObjectID;
                        reqProc.Amount = Convert.ToInt32(subActionProc.Amount);

                        if (subActionProc.Emergency != null)
                            reqProc.isEmergency = subActionProc.Emergency.Value;

                        reqProc.isAdditionalApplication = false;
                        reqProc.isResultShown = false;
                        reqProc.isReportShown = false;
                        reqProc.ActionStatus = subActionProc.DisplayText;
                        reqProc.CurrentStateDefID = (Guid)subActionProc.CurrentStateDefID;
                        reqProc.StateStatus = Convert.ToInt32(subActionProc.Statestatus);
                        reqProc.isExternalProcedureRequest = false;
                        reqProc.isProcedureRejected = false;
                        if (masterResource is ResObservationUnit)
                        {
                            if (((ResObservationUnit)masterResource).IsExternalObservationUnit == true)
                                reqProc.isExternalProcedureRequest = true;
                        }
                        reqProc.isAddedToMostUsedRequest = false;

                        reqProc.isReportRequired = procedureDef.ReportSelectionRequired == true ? true : false;
                        reqProc.isPathologyRequired = procedureDef.PathologyOperationNeeded == true ? true : false;
                        reqProc.isResultNeeded = procedureDef.IsResultNeeded == true ? true : false;
                    //reqProc.StateStatus = Convert.ToInt32(subActionProc.CurrentStateDef.Status);
                    if (reqProc.ProcedureCode == "700050")
                        reqProc.isSkinPrickTest = true;
                    else
                        reqProc.isSkinPrickTest = false;

                    //LaboratoryTestDef
                    //if (subActionProc.Procedureobjectdef.ToString() == "42ed5391-9525-457f-8412-500f7b0935bf")
                    if (procedureDef is LaboratoryTestDefinition)  
                    {
                        LaboratoryProcedure labProcedure = laboratoryProcedureObjects.FirstOrDefault(p => p.ObjectID == subActionProc.Subactionprocedureobjectid);
                            //(LaboratoryProcedure)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "LaboratoryProcedure");


                        LaboratoryTestDefinition labTestDef = (LaboratoryTestDefinition)labProcedure.ProcedureObject;

                            reqProc.isAddedToMostUsedRequest = true;
                            reqProc.ProcedureType = "LAB";
                            if (reqProc.CurrentStateDefID == LaboratoryProcedure.States.Completed) //Lab sonucclandı asamasında ıse sonuc gosterme lınkı set edılecek ve sonuc gosterme ikonlari ona gore visible olacak.
                            {
                                string reportURL = "";
                                if (TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXENTEGRATION", "FALSE") == "TRUE")
                                {
                                    reportURL = GetReportURLFromLIS(labProcedure);
                                    if (reportURL != "")
                                    {
                                        //reqProc.isResultShown = true;
                                        reqProc.isReportShown = true;
                                        reqProc.ProcedureReportLink = reportURL;
                                        //reqProc.ProcedureResultLink = GetResultURLFromLIS(laboratoryProcedure); //TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXRESULTVIEWURL", "") + "OID=" + laboratoryProcedure.SpecimenId.ToString(); //"http://X.X.X.X/AlisWeb/orneksonucgoster.aspx?
                                        if (labProcedure.IsResultSeen != null)
                                            reqProc.isResultSeen = (Boolean)labProcedure.IsResultSeen;
                                        else
                                            reqProc.isResultSeen = false;

                                    }
                                    if (labProcedure.ApproveUser != null)
                                    {
                                        reqProc.ProcedureResUser = labProcedure.ApproveUser.Name;
                                        reqProc.ProcedureUserId = (Guid)labProcedure.ApproveUser.ObjectID;
                                    }

                                    //if (laboratoryProcedure.SpecimenId !=  null && laboratoryProcedure.SpecimenId > LastSpecimenId)
                                    //    LastSpecimenId = (long)laboratoryProcedure.SpecimenId;
                                }

                                if (labTestDef.IsPanel == true)
                                    reqProc.isPanelTest = true;

                                if (labTestDef.ProcedureTree != null && labTestDef.ProcedureTree.ObjectID.ToString() == "66022707-6322-4ece-b725-99ba1dcf0e56")
                                {
                                    reqProc.isMikrobiyolojiTest = true;
                                    reqProc.mikrobiyolojiResult = labProcedure.ResultDescription;
                                }
                            }

                            if (labTestDef.RequiresBinaryScanForm == true || labTestDef.RequiresTripleTestForm == true || labTestDef.RequiresUreaBreathTestReport == true || labTestDef.TestDescription != null)
                            {
                                string procedureInst = "";
                                string instReportName = "";
                                if (labTestDef.RequiresBinaryScanForm == true)
                                {
                                    procedureInst = procedureInst + TTUtils.CultureService.GetText("M26037", "İkili Tarama Formu Gerektirir\n");
                                    instReportName = instReportName + "LaboratoryBinaryScanInfoReport" + "|";
                                }

                                if (labTestDef.RequiresTripleTestForm == true)
                                {
                                    procedureInst = procedureInst + TTUtils.CultureService.GetText("M27161", "Üçlü Test Formu Gerektirir\n");
                                    instReportName = instReportName + "LaboratoryTripleTestInfoReport" + "|";
                                }

                                if (labTestDef.RequiresUreaBreathTestReport == true)
                                {
                                    procedureInst = procedureInst + TTUtils.CultureService.GetText("M27164", "Üre Nefes Testi Hasta Talimat Raporunu Gerektirir\n");
                                    instReportName = instReportName + "UreaBreathTestPatientInstructionReport" + "|";
                                }

                                if (labTestDef.TestDescription != null)
                                {
                                    procedureInst = procedureInst + labTestDef.TestDescription;
                                    instReportName = instReportName + "LaboratoryTestPatientInstructionReport" + "|";
                                }

                                reqProc.hasProcedureInstruction = true;
                                reqProc.ProcedureInstructions = procedureInst;
                                reqProc.ProcedureInstructionReportName = instReportName;
                            }




                            if (subActionProc.CurrentStateDefID.ToString() == LaboratoryProcedure.States.SampleReject.ToString())
                            {
                                reqProc.isProcedureRejected = true;
                                if (labProcedure.ReasonOfReject != null)
                                    reqProc.RejectReason = Common.GetTextOfRTFString(labProcedure.ReasonOfReject.ToString());
                            }

                            if (labProcedure.Panic == LaboratoryAbnormalFlagsEnum.HH || labProcedure.Panic == LaboratoryAbnormalFlagsEnum.H || labProcedure.Panic == LaboratoryAbnormalFlagsEnum.L || labProcedure.Panic == LaboratoryAbnormalFlagsEnum.LL)
                            {
                                reqProc.hasPanicValue = true;
                                reqProc.PanicValue = labProcedure.Panic.ToString();
                            }

                            if (labProcedure.Result != null && labProcedure.Result != "")
                            {
                                reqProc.ResultValue = labProcedure.Result + " " + labProcedure.Unit + " (" + labProcedure.Reference + ")";
                            }
                        }

                        //RadiologyTestDef
                        //if (subActionProc.Procedureobjectdef.ToString() == "2a86ddb5-6508-41c6-ae55-6b983add9c84")
                        if (procedureDef is RadiologyTestDefinition)
                        {

                            reqProc.isRadiologyProcedure = true;
                            reqProc.isRISIntegrated = ((RadiologyTestDefinition)procedureDef).IsRISEntegratedTest;



                            reqProc.isAddedToMostUsedRequest = true;
                            reqProc.ProcedureType = "RAD";
                        if (reqProc.CurrentStateDefID == RadiologyTest.States.Reported || reqProc.CurrentStateDefID == RadiologyTest.States.Completed || reqProc.CurrentStateDefID == RadiologyTest.States.ResultEntry)  //Radyoloji testi raporlandı veya cekim yapıldı asamasında ıse sonuc gosterme lınkı set edılecek ve sonuc gosterme ikonlari ona gore visible olacak.
                        {
                            if (TTObjectClasses.SystemParameter.GetParameterValue("PACSENTEGRATION", "FALSE") == "TRUE")
                                {
                                RadiologyTest radTest = radiologyTestObjects.FirstOrDefault(p => p.ObjectID == subActionProc.Subactionprocedureobjectid);
                                    //(RadiologyTest)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "RadiologyTest");
                                reqProc.isResultShown = true;
                                if (TTObjectClasses.SystemParameter.GetParameterValue("YAPAYZEKAAKTIF", "FALSE") == "TRUE")
                                {
                                    var AIProcedures = TTObjectClasses.SystemParameter.GetParameterValue("YAPAYZEKACALISACAKTESTLER", "");
                                    var AIProcedureList = AIProcedures.Split(',').ToList();
                                    if (AIProcedureList.Contains(reqProc.ProcedureCode))
                                        reqProc.canAnalyzeWithAI = true;
                                }
                                reqProc.isReportShown = true;
                                if (radTest.AccessionNo != null && radTest.AccessionNo.ToString() != "")
                                    {
                                        //string accessionNo = "";
                                        //int numberOfZero = (7 - radTest.AccessionNo.ToString().Length);
                                        //for (int i = 0; i < numberOfZero; i++)
                                        //{
                                        //    accessionNo = accessionNo + "0";
                                        //}

                                        //accessionNo = accessionNo + radTest.AccessionNo.ToString();
                                     

                                        if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "EXTREME")
                                        {
                                            reqProc.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?an=" + radTest.AccessionNo.ToString() + "&usr=extreme";

                                        }
                                        else if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "COMPANY1") == "COMPANY2")
                                        {
                                            reqProc.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?accession=" + radTest.AccessionNo.ToString() + "&patientid=" + ea.Episode.Patient.UniqueRefNo?.ToString() + "&ietab=true";
                                        }
                                        else if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "XXXXXX")
                                        {
                                            reqProc.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "&accession=" + radTest.AccessionNo.ToString() + "&StudyReload=1";
                                        }

                                        if (radTest.IsResultSeen != null)
                                            reqProc.isResultSeen = (Boolean)radTest.IsResultSeen;
                                        else
                                            reqProc.isResultSeen = false;
                                    }
                                }
                            }

                            RadiologyTest radiologyTest = radiologyTestObjects.FirstOrDefault(p => p.ObjectID == subActionProc.Subactionprocedureobjectid);
                            //(RadiologyTest)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "RadiologyTest");
                            RadiologyTestDefinition radTestDef = (RadiologyTestDefinition)radiologyTest.ProcedureObject;
                            if (radTestDef.RadiologyTestDescriptions.Count > 0)
                            {
                                string procedureInst = "";
                                foreach (RadiologyGridTestDescriptionDefinition RadGridTestDef in radTestDef.RadiologyTestDescriptions)
                                {
                                    procedureInst = procedureInst + RadGridTestDef.TestDescription?.Description?.ToString() + "\n";
                                }

                                reqProc.hasProcedureInstruction = true;
                                reqProc.ProcedureInstructions = procedureInst;
                            }
                        }else
                            reqProc.isRadiologyProcedure = false;

                        //NuclearMedicineTestDefinition
                        if (procedureDef is NuclearMedicineTestDefinition)
                        {
                            reqProc.ProcedureType = "NUCLEARTEST";

                        NuclearMedicine nuclearMedicineEA = nuclearMedicineObjects.FirstOrDefault(p => p.ObjectID == subActionProc.Episodeactionobjectid);
                            //(NuclearMedicine)objContext.GetObject((Guid)subActionProc.Episodeactionobjectid, "NuclearMedicine");
                            if (nuclearMedicineEA != null)
                            {
                                reqProc.ActionStatus = nuclearMedicineEA.CurrentStateDef.DisplayText;
                                if (nuclearMedicineEA.CurrentStateDefID == NuclearMedicine.States.Reported)
                                {
                                    reqProc.isReportShown = true;
                                }
                            }
                        }

                        //PathologyTestDef
                        //if (subActionProc.Procedureobjectdef.ToString() == "0ec41b0f-08bb-4549-ad85-3ffc8e3c8ae6")
                        if (procedureDef is PathologyTestDefinition)
                        {
                            reqProc.ProcedureType = "PAT";
                            PathologyTestProcedure patTest = pathologyTestProcedureObjects.FirstOrDefault(p => p.ObjectID == subActionProc.Subactionprocedureobjectid);
                            //(PathologyTestProcedure)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "PathologyTestProcedure");

                            if (reqProc.CurrentStateDefID == PathologyTestProcedure.States.Completed) //İşlem sonucclandı asamasında ıse  sonuc gosterme ikonlari ona gore visible olacak.
                            {
                                reqProc.isResultShown = true;
                                reqProc.isReportShown = true;
                                reqProc.ProcedureReportLink = "";

                                if (patTest.IsResultSeen != null)
                                    reqProc.isResultSeen = (Boolean)patTest.IsResultSeen;
                                else
                                    reqProc.isResultSeen = false;
                            }


                            if (patTest.CurrentStateDefID.ToString() == PathologyTestProcedure.States.Cancelled.ToString())
                            {
                                reqProc.isProcedureRejected = true;
                                if (patTest.ReasonOfCancel != null)
                                    reqProc.RejectReason = patTest.ReasonOfCancel.ToString();
                            }

                        }
                        //SurgeryDef - Manipulation
                        //if (subActionProc.Procedureobjectdef.ToString() == "3c01da70-344c-4f44-9dc5-8e936758499f")
                        if (procedureDef is SurgeryDefinition)
                        {
                            reqProc.ProcedureType = "MANIPULATION";
                            if (reqProc.CurrentStateDefID == ManipulationProcedure.States.Completed) //İşlem tamamlandı ıse  sonuc gosterme ikonlari ona gore visible olacak.
                            {
                                var manTestList = manipulationProcedureObjects.Where(p => p.ObjectID == subActionProc.Subactionprocedureobjectid).ToList();
                                //ManipulationProcedure.GetByManipulationProcedureByObjectId(objContext, (Guid)subActionProc.Subactionprocedureobjectid);
                                foreach (ManipulationProcedure manTest in manTestList)
                                {
                                    // Surgery - Additional Applications - Maniulasyon hepsi SurgerDefinitiondan tanımlandığı için gelen guid her zman maniplasyon olmayabilir o durumda patlamasın diye NQL le çekildi 
                                    // ManipulationProcedure manTest = (ManipulationProcedure)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "ManipulationProcedure");
                                    reqProc.isResultShown = true;
                                    reqProc.isReportShown = true;
                                    reqProc.ProcedureReportLink = "";

                                    if (manTest.IsResultSeen != null)
                                        reqProc.isResultSeen = (Boolean)manTest.IsResultSeen;
                                    else
                                        reqProc.isResultSeen = false;
                                }
                            }
                        }

                        //if (subActionProc.Procedureobjectdef.ToString() == "f0b2d1dd-e2fc-4c5a-bcb7-f1e498552beb")
                        if (procedureDef is PsychologyProcedureDefiniton)
                        {
                            reqProc.ProcedureType = "PSYCH";
                            if (reqProc.CurrentStateDefID == PsychologyTest.States.Completed) //İşlem tamamlandı ıse  sonuc gosterme ikonlari ona gore visible olacak.
                            {
                                reqProc.isResultShown = false;
                                reqProc.isReportShown = true;
                                reqProc.ProcedureReportLink = "";
                            }

                            if (subActionProc.Procedurebyuserid != null)
                            {
                                reqProc.ProcedureResUser = subActionProc.Procedurebyusername;
                                reqProc.ProcedureUserId = (Guid)subActionProc.Procedurebyuserid;
                            }
                        }


                    //BaseAdditionalApplication turundeki hizmetler icin BaseAdditionalInfoForm datası varsa yuklenecek
                    SubActionProcedure sp = subActionProcedureObjects.FirstOrDefault(x => x.ObjectID == subActionProc.Subactionprocedureobjectid);
                    //SubActionProcedure sp = (SubActionProcedure)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "SubActionProcedure");

                       
                        //Hizmet ucret bilgisi gosterilmesinden vazgecildigi icin kapatildi.
                        try
                        {
                            if (sp != null)
                            {
                                //if (sp.GetProcedurePrice() != null)
                                //{
                                    //reqProc.UnitPrice = (double)sp.GetProcedurePrice();
                                //}
                            }
                        }
                        catch { }
                        if (sp is BaseAdditionalApplication)
                        {
                            reqProc.isAddedToMostUsedRequest = true;
                            reqProc.isAdditionalApplication = true;
                            if (((BaseAdditionalApplication)sp).BaseAdditionalInfoForm != null)
                            {
                                reqProc.BaseAdditionalInfoFormGuids = new List<Guid>();
                                foreach (BaseAdditionalInfo baseAdditionalInfoForm in ((BaseAdditionalApplication)sp).BaseAdditionalInfoForm)
                                {
                                    reqProc.BaseAdditionalInfoFormGuids.Add(baseAdditionalInfoForm.ObjectID);
                                }
                            }

                            if (((BaseAdditionalApplication)sp).Description != null)
                            {
                                reqProc.Description = ((BaseAdditionalApplication)sp).Description;
                            }
                        }

                        //BloodBankTestDef
                        //if (subActionProc.Procedureobjectdef.ToString() == "e0a1c9eb-5ab9-44cd-a1d3-6756165c6962")
                        //if (procedureDef is BloodBankTestDefinition)
                        //{
                        //    reqProc.ProcedureType = "BLOODREQ";
                        //    reqProc.ExternalProcedureId = ((BloodBankBloodProducts)sp).BloodProductExternalID;
                        //}


                        ResUser myUser = Common.CurrentResource;

                        if (reqProc.isAdditionalApplication && (hasProcedureUpdateRole() || reqProc.RequestedById == myUser.ObjectID) && sa.IsAllowedToCancel())
                            reqProc.isProcedureReadOnly = false;
                        else
                            reqProc.isProcedureReadOnly = true;

                        reqProc.RightLeftInformation = sa.RightLeftInformation;
                        reqProc.ProtocolNo = sa.SubEpisode.ProtocolNo;
                        reqProc.isNew = false;
                        reqProc.ActionType = sa.EpisodeAction.ActionType;
                        if(sa.EpisodeAction.ActionType == ActionTypeEnum.InPatientPhysicianApplication
                        && ((InPatientPhysicianApplication)sa.EpisodeAction).InPatientTreatmentClinicApp == null
                        && ((InPatientPhysicianApplication)sa.EpisodeAction).EmergencyIntervention != null)
                    {
                        reqProc.isObserved = true;
                    }
                        else
                        reqProc.isObserved = false;

                    if (reqProc.ActionType != ActionTypeEnum.PatientExamination
                         && reqProc.ActionType != ActionTypeEnum.FollowUpExamination
                         && reqProc.ActionType != ActionTypeEnum.DentalExamination
                         && reqProc.ActionType != ActionTypeEnum.InPatientPhysicianApplication
                         && reqProc.ActionType != ActionTypeEnum.Consultation
                         && reqProc.ActionType != ActionTypeEnum.InPatientTreatmentClinicApplication
                         && reqProc.ActionType != ActionTypeEnum.EmergencyIntervention
                         && reqProc.ActionType != ActionTypeEnum.HealthCommitteeExamination
                         && reqProc.ActionType != ActionTypeEnum.HealthCommittee
                         && reqProc.ActionType != ActionTypeEnum.NursingApplication)
                        {
                        if((EpisodeAction)sa.EpisodeAction.MasterAction!= null)
                            reqProc.ActionType = ((EpisodeAction)sa.EpisodeAction.MasterAction).ActionType;
                        }

                        resultList.Add(reqProc);
                    }
                
            }
            return resultList;
        }
        /*  TARIH ARALIGI FILTRELEME */
        [HttpPost]
        public List<vmRequestedProcedure> GetRequestedProceduresFormViewModelByRequestDateFilter(QueryInputDVO inputDVO)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            EpisodeAction ea = (EpisodeAction)objContext.GetObject(inputDVO.EpisodeActionObjectID, "EpisodeAction");

            inputDVO.StartDate = Convert.ToDateTime(inputDVO.StartDate.ToString("dd.MM.yyyy") + " " + "00:00:00");
            inputDVO.EndDate = Convert.ToDateTime(inputDVO.EndDate.ToString("dd.MM.yyyy") + " " + "23:59:59");

            //LAB SONUCLARI ALIP UPDATE ICIN YAPILMISTI.
            //BATCH e DONDURULDUGU ICIN ASAGIDAKI BLOK KAPATILDI
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("GETLABRESULTSINREQUESTEDPROCFORM", "FALSE") == "TRUE")
            {
                BindingList<SubActionProcedure.GetRequestedProceduresBySubEpisode_Class> requestProceduresListForLIS = TTObjectClasses.SubActionProcedure.GetRequestedProceduresBySubEpisode(objContext, ea.SubEpisode.ObjectID.ToString(), inputDVO.StartDate, inputDVO.EndDate);
                Dictionary<string, string> specimenIDDict = new Dictionary<string, string>();
                List<string> specimenIDList = new List<string>();
                foreach (SubActionProcedure.GetRequestedProceduresBySubEpisode_Class subActionProc in requestProceduresListForLIS.ToList())
                {
                    if (subActionProc.Procedureobjectdef.ToString() == "42ed5391-9525-457f-8412-500f7b0935bf") //laboratorytest definition
                    {
                        LaboratoryProcedure labProc = (LaboratoryProcedure)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "LaboratoryProcedure");
                        if (labProc.CurrentStateDefID == LaboratoryProcedure.States.Procedure || labProc.CurrentStateDefID == LaboratoryProcedure.States.Approve)
                        {
                            if (labProc.SpecimenId > 0)
                            {
                                string outSpecimenID = "";
                                if (specimenIDDict.TryGetValue(labProc.SpecimenId.ToString(), out outSpecimenID) == false)
                                {
                                    specimenIDList.Add(labProc.SpecimenId.ToString());
                                    specimenIDDict.Add(labProc.SpecimenId.ToString(), outSpecimenID);
                                }
                            }
                        }
                    }
                }

                if (specimenIDList.Count > 0)
                    LaboratoryRequest.AskResultsFromLISBySpecimenIDList(specimenIDList);
            }

            List<vmRequestedProcedure> procedureList = new List<vmRequestedProcedure>();

            //Sonuc Update leri oldugu ıcın  subactıonprocedure ler yenıden yuklenmelı
            BindingList<SubActionProcedure.GetRequestedProceduresBySubEpisode_Class> allRequestProceduresList = TTObjectClasses.SubActionProcedure.GetRequestedProceduresBySubEpisode(objContext, ea.Episode.ObjectID.ToString(), inputDVO.StartDate, inputDVO.EndDate);
            foreach (SubActionProcedure.GetRequestedProceduresBySubEpisode_Class subActionProc in allRequestProceduresList.ToList())
            {
                vmRequestedProcedure reqProc = new vmRequestedProcedure();
                reqProc.SubActionProcedureObjectId = (Guid)subActionProc.Subactionprocedureobjectid;
                reqProc.ProcedureObjectId = (Guid)subActionProc.Procedureobjectid;
                reqProc.EpisodeActionObjectId = (Guid)subActionProc.Episodeactionobjectid;
                reqProc.ProcedureCode = subActionProc.Procedurecode;
                reqProc.ProcedureName = subActionProc.Procedurename;
                reqProc.ProcedureObjectDefId = (Guid)subActionProc.Procedureobjectdef;
                if (subActionProc.Requestdate != null)
                    reqProc.RequestDate = (DateTime)subActionProc.Requestdate;
                if (subActionProc.Requestbyid != null)
                {
                    reqProc.RequestedByResUser = subActionProc.Requestby;
                    reqProc.RequestedById = (Guid)subActionProc.Requestbyid;
                }
                if (subActionProc.Proceduredoctorid != null)
                {
                    reqProc.ProcedureResUser = subActionProc.Proceduredoctorname;
                    reqProc.ProcedureUserId = (Guid)subActionProc.Proceduredoctorid;

                }

                Resource masterResource = (Resource)objContext.GetObject((Guid)subActionProc.MasterResource, "Resource");
                reqProc.MasterResource = masterResource.Name;
                reqProc.Amount = Convert.ToInt32(subActionProc.Amount);
                if (subActionProc.Emergency != null)
                    reqProc.isEmergency = subActionProc.Emergency.Value;
                SubActionProcedure sp = (SubActionProcedure)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "SubActionProcedure");
                try
                {
                    if (sp != null)
                    {
                        if (sp.GetProcedurePrice() != null)
                        {
                            reqProc.UnitPrice = (double)sp.GetProcedurePrice();
                        }
                    }
                }
                catch { }
                reqProc.isAdditionalApplication = true;
                reqProc.isResultShown = false;
                reqProc.isReportShown = true;
                reqProc.ActionStatus = subActionProc.DisplayText;
                reqProc.CurrentStateDefID = (Guid)subActionProc.CurrentStateDefID;
                reqProc.StateStatus = Convert.ToInt32(subActionProc.Statestatus);
                reqProc.isExternalProcedureRequest = false;
                reqProc.isProcedureRejected = false;
                if (masterResource is ResObservationUnit)
                {
                    if (((ResObservationUnit)masterResource).IsExternalObservationUnit == true)
                        reqProc.isExternalProcedureRequest = true;
                }

                ProcedureDefinition procedureDef = (ProcedureDefinition)objContext.GetObject((Guid)subActionProc.Procedureobjectid, "ProcedureDefinition");
                reqProc.isReportRequired = procedureDef.ReportSelectionRequired == true ? true : false;
                reqProc.isPathologyRequired = procedureDef.PathologyOperationNeeded == true ? true : false;
                reqProc.isResultNeeded = procedureDef.IsResultNeeded == true ? true : false;
                if (reqProc.ProcedureCode == "700050")
                    reqProc.isSkinPrickTest = true;
                else
                    reqProc.isSkinPrickTest = false;

                //LaboratoryTestDef
                if (subActionProc.Procedureobjectdef.ToString() == "42ed5391-9525-457f-8412-500f7b0935bf")
                {
                    LaboratoryProcedure labProcedure = (LaboratoryProcedure)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "LaboratoryProcedure");
                    LaboratoryTestDefinition labTestDef = (LaboratoryTestDefinition)labProcedure.ProcedureObject;

                    reqProc.isAdditionalApplication = false;
                    reqProc.ProcedureType = "LAB";
                    if (reqProc.CurrentStateDefID == LaboratoryProcedure.States.Completed) //Lab sonucclandı asamasında ıse sonuc gosterme lınkı set edılecek ve sonuc gosterme ikonlari ona gore visible olacak.
                    {
                        string reportURL = "";
                        if (TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXENTEGRATION", "FALSE") == "TRUE")
                        {
                            reportURL = GetReportURLFromLIS(labProcedure);
                            if (reportURL != "")
                            {
                                //reqProc.isResultShown = true;
                                reqProc.isReportShown = true;
                                reqProc.ProcedureReportLink = reportURL;
                                //reqProc.ProcedureResultLink = GetResultURLFromLIS(laboratoryProcedure);
                                if (labProcedure.IsResultSeen != null)
                                    reqProc.isResultSeen = (Boolean)labProcedure.IsResultSeen;
                                else
                                    reqProc.isResultSeen = false;
                            }

                            if (labProcedure.ApproveUser != null)
                            {
                                reqProc.ProcedureResUser = labProcedure.ApproveUser.Name;
                                reqProc.ProcedureUserId = (Guid)labProcedure.ApproveUser.ObjectID;
                            }
                        }

                        if (labTestDef.IsPanel == true)
                            reqProc.isPanelTest = true;

                        if (labTestDef.ProcedureTree != null && labTestDef.ProcedureTree.ObjectID.ToString() == "66022707-6322-4ece-b725-99ba1dcf0e56")
                        {
                            reqProc.isMikrobiyolojiTest = true;
                            reqProc.mikrobiyolojiResult = labProcedure.ResultDescription;
                        }
                    }

                    if (labTestDef.RequiresBinaryScanForm == true || labTestDef.RequiresTripleTestForm == true || labTestDef.RequiresUreaBreathTestReport == true || labTestDef.TestDescription != null)
                    {
                        string procedureInst = "";
                        string instReportName = "";
                        if (labTestDef.RequiresBinaryScanForm == true)
                        {
                            procedureInst = procedureInst + TTUtils.CultureService.GetText("M26037", "İkili Tarama Formu Gerektirir\n");
                            instReportName = instReportName + "LaboratoryBinaryScanInfoReport" + "|";
                        }

                        if (labTestDef.RequiresTripleTestForm == true)
                        {
                            procedureInst = procedureInst + TTUtils.CultureService.GetText("M27161", "Üçlü Test Formu Gerektirir\n");
                            instReportName = instReportName + "LaboratoryTripleTestInfoReport" + "|";
                        }

                        if (labTestDef.RequiresUreaBreathTestReport == true)
                        {
                            procedureInst = procedureInst + TTUtils.CultureService.GetText("M27164", "Üre Nefes Testi Hasta Talimat Raporunu Gerektirir\n");
                            instReportName = instReportName + "UreaBreathTestPatientInstructionReport" + "|";
                        }

                        if (labTestDef.TestDescription != null)
                            procedureInst = procedureInst + labTestDef.TestDescription;

                        reqProc.hasProcedureInstruction = true;
                        reqProc.ProcedureInstructions = procedureInst;
                        reqProc.ProcedureInstructionReportName = instReportName;

                    }

                   
                    if (subActionProc.CurrentStateDefID.ToString() == LaboratoryProcedure.States.SampleReject.ToString())
                    {
                        reqProc.isProcedureRejected = true;
                        reqProc.RejectReason = Common.GetTextOfRTFString(labProcedure.ReasonOfReject.ToString());
                    }

                    if (labProcedure.Panic == LaboratoryAbnormalFlagsEnum.HH || labProcedure.Panic == LaboratoryAbnormalFlagsEnum.H || labProcedure.Panic == LaboratoryAbnormalFlagsEnum.L || labProcedure.Panic == LaboratoryAbnormalFlagsEnum.LL)
                    {
                        reqProc.hasPanicValue = true;
                        reqProc.PanicValue = labProcedure.Panic.ToString();
                    }
                }

                //RadiologyTestDef
                if (subActionProc.Procedureobjectdef.ToString() == "2a86ddb5-6508-41c6-ae55-6b983add9c84")
                {
                    reqProc.isAdditionalApplication = false;
                    reqProc.ProcedureType = "RAD";
                    if (reqProc.CurrentStateDefID == RadiologyTest.States.Reported || reqProc.CurrentStateDefID == RadiologyTest.States.Completed) //Radyoloji testi raporlandı veya cekim yapıldı asamasında ıse sonuc gosterme lınkı set edılecek ve sonuc gosterme ikonlari ona gore visible olacak.
                    {
                        if (TTObjectClasses.SystemParameter.GetParameterValue("PACSENTEGRATION", "FALSE") == "TRUE")
                        {
                            RadiologyTest radTest = (RadiologyTest)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "RadiologyTest");
                            if (radTest.AccessionNo != null && radTest.AccessionNo.ToString() != "")
                            {
                                //string accessionNo = "";
                                //int numberOfZero = (7 - radTest.AccessionNo.ToString().Length);
                                //for (int i = 0; i < numberOfZero; i++)
                                //{
                                //    accessionNo = accessionNo + "0";
                                //}

                                //accessionNo = accessionNo + radTest.AccessionNo.ToString();
                                reqProc.isResultShown = true;
                                if (TTObjectClasses.SystemParameter.GetParameterValue("YAPAYZEKAAKTIF", "FALSE") == "TRUE")
                                {
                                    var AIProcedures = TTObjectClasses.SystemParameter.GetParameterValue("YAPAYZEKACALISACAKTESTLER", "");
                                    var AIProcedureList = AIProcedures.Split(',').ToList();
                                    if (AIProcedureList.Contains(reqProc.ProcedureCode))
                                        reqProc.canAnalyzeWithAI = true;
                                }
                                reqProc.isReportShown = true;
                                //reqProc.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?an=" + accessionNo + "&usr=extreme"; //http://X.X.X.X:35005/?an=0000000&usr=extreme

                                if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "EXTREME")
                                {
                                    reqProc.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?an=" + radTest.AccessionNo.ToString() + "&usr=extreme";

                                }
                                else if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "COMPANY1") == "COMPANY2")
                                {
                                    reqProc.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?accession=" + radTest.AccessionNo.ToString() + "&patientid=" + ea.Episode.Patient.UniqueRefNo?.ToString() + "&ietab=true";
                                }
                                else if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "XXXXXX")
                                {
                                    reqProc.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "&accession=" + radTest.AccessionNo.ToString() + "&StudyReload=1";
                                }

                                if (radTest.IsResultSeen != null)
                                    reqProc.isResultSeen = (Boolean)radTest.IsResultSeen;
                                else
                                    reqProc.isResultSeen = false;
                            }
                        }
                    }

                    RadiologyTest radiologyTest = (RadiologyTest)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "RadiologyTest");
                    RadiologyTestDefinition radTestDef = (RadiologyTestDefinition)radiologyTest.ProcedureObject;
                    if (radTestDef.RadiologyTestDescriptions.Count > 0)
                    {
                        string procedureInst = "";
                        foreach (RadiologyGridTestDescriptionDefinition RadGridTestDef in radTestDef.RadiologyTestDescriptions)
                        {
                            procedureInst = procedureInst + RadGridTestDef.TestDescription?.Description?.ToString() + "\n";
                        }

                        reqProc.hasProcedureInstruction = true;
                        reqProc.ProcedureInstructions = procedureInst;
                    }
                }

                //BloodBankTestDef
                if (subActionProc.Procedureobjectdef.ToString() == "e0a1c9eb-5ab9-44cd-a1d3-6756165c6962")
                {
                    reqProc.isAdditionalApplication = false;
                    reqProc.ProcedureType = "BLOODREQ";
                    reqProc.ExternalProcedureId = ((BloodBankBloodProducts)sp).BloodProductExternalID;
                }

                //PathologyTestDef
                if (subActionProc.Procedureobjectdef.ToString() == "0ec41b0f-08bb-4549-ad85-3ffc8e3c8ae6")
                {
                    reqProc.isAdditionalApplication = false;
                    reqProc.ProcedureType = "PAT";
                    PathologyTestProcedure patTest = (PathologyTestProcedure)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "PathologyTestProcedure");

                    if (reqProc.CurrentStateDefID == PathologyTestProcedure.States.Completed) //İşlem sonucclandı asamasında ıse  sonuc gosterme ikonlari ona gore visible olacak.
                    {
                         reqProc.isResultShown = true;
                        reqProc.isReportShown = true;
                        reqProc.ProcedureReportLink = "";

                        if (patTest.IsResultSeen != null)
                            reqProc.isResultSeen = (Boolean)patTest.IsResultSeen;
                        else
                            reqProc.isResultSeen = false;
                    }

                    if (patTest.CurrentStateDefID.ToString() == PathologyTestProcedure.States.Cancelled.ToString())
                    {
                        reqProc.isProcedureRejected = true;
                        if (patTest.ReasonOfCancel != null)
                            reqProc.RejectReason = patTest.ReasonOfCancel.ToString();
                    }
                }

                //SurgeryDef - Manipulation
                if (subActionProc.Procedureobjectdef.ToString() == "3c01da70-344c-4f44-9dc5-8e936758499f")
                {
                    reqProc.isAdditionalApplication = false;
                    reqProc.ProcedureType = "MANIPULATION";
                    if (reqProc.CurrentStateDefID == ManipulationProcedure.States.Completed) //İşlem tamamlandı ıse  sonuc gosterme ikonlari ona gore visible olacak.
                    {
                        ManipulationProcedure manTest = (ManipulationProcedure)objContext.GetObject((Guid)subActionProc.Subactionprocedureobjectid, "ManipulationProcedure");
                        reqProc.isResultShown = true;
                        reqProc.isReportShown = true;
                        reqProc.ProcedureReportLink = "";

                        if (manTest.IsResultSeen != null)
                            reqProc.isResultSeen = (Boolean)manTest.IsResultSeen;
                        else
                            reqProc.isResultSeen = false;
                    }
                }

                procedureList.Add(reqProc);
            }

            return procedureList;
        }



        [HttpGet]
        public bool GetLaboratoryProcedureResultFromXXXXXX([FromQuery] LaboratoryProcedure laboratoryProcedure)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            if (laboratoryProcedure != null)
            {
                try
                {
                    XXXXXXIHEWS.ORL34 orl34 = new XXXXXXIHEWS.ORL34();
                    XXXXXXIHEWS.OUL22 oul22 = new XXXXXXIHEWS.OUL22();
                    XXXXXXIHEWS.MSH msh = new XXXXXXIHEWS.MSH();
                    XXXXXXIHEWS.Patient patient = new XXXXXXIHEWS.Patient();
                    List<XXXXXXIHEWS.OUL22Specimen> oul22SpecimenList = new List<XXXXXXIHEWS.OUL22Specimen>();
                    XXXXXXIHEWS.PID pid = new XXXXXXIHEWS.PID();
                    XXXXXXIHEWS.PV1 pv1 = new XXXXXXIHEWS.PV1();
                    List<XXXXXXIHEWS.OULOrder> orderList = new List<XXXXXXIHEWS.OULOrder>();
                    List<XXXXXXIHEWS.OBX> obxList = new List<XXXXXXIHEWS.OBX>();
                    //MSH, mesaj basligi segmenti
                    msh.EncodingCharacters = @"^~\&";
                    msh.SendingApplication = "HBYS_TEST";
                    msh.SendingFacility = "HBYS_TEST_HOSPITAL";
                    msh.DateTimeOfMessage = DateTime.Now.ToString("yyyyMMddHHmmss");
                    msh.ReceivingApplication = "XXXXXX";
                    msh.ReceivingFacility = "XXXXXX_Kurumu";
                    msh.MessageType = "OML^O33^OML_O33";
                    Random random = new Random();
                    msh.MessageControlID = random.Next(9999, 19999).ToString();
                    //Patient.PID  hasta bilgileri segmenti     
                    pid.PatientID = laboratoryProcedure.Episode.Patient.UniqueRefNo.ToString(); //"10000000000";
                    pid.PatientIdentifierList = laboratoryProcedure.Episode.Patient.ID.ToString() + "^^^" + "ATLAS_ATLASDEV^PI"; //"H12345678950^^^ATLAS_ATLASDEV^PI";
                    pid.PatientName = laboratoryProcedure.Episode.Patient.Surname + "^" + laboratoryProcedure.Episode.Patient.Name; //"DENEME^DENEME";
                    if (laboratoryProcedure.Episode.Patient.Mother != null)
                        pid.MothersMaidenName = laboratoryProcedure.Episode.Patient.FatherName + "^" + laboratoryProcedure.Episode.Patient.MotherName + "^" + laboratoryProcedure.Episode.Patient.Mother.UniqueRefNo; //"BABA^ANNE^10000000000";
                    else
                        pid.MothersMaidenName = laboratoryProcedure.Episode.Patient.FatherName + "^" + laboratoryProcedure.Episode.Patient.MotherName; //"BABA^ANNE^10000000000";
                    pid.DateTimeofBirth = Convert.ToDateTime(laboratoryProcedure.Episode.Patient.BirthDate).ToString("yyyyMMddHHmmss"); //"19791102000000";
                    pid.PhoneNumberHome = laboratoryProcedure.Episode.Patient.PatientAddress.HomePhone; //"05555555555";
                    pid.PhoneNumberBusiness = laboratoryProcedure.Episode.Patient.PatientAddress.BusinessPhone; //"05555555555";
                    pid.PatientAddress = laboratoryProcedure.Episode.Patient.PatientAddress.HomeAddress; //"Bilinmiyor";
                    pid.PatientAccountNumber = laboratoryProcedure.Episode.ID.ToString(); //msh.MessageControlID;
                    if (laboratoryProcedure.Episode.Patient.Sex != null)
                    {
                        if (laboratoryProcedure.Episode.Patient.Sex.ADI == "KADIN")
                            pid.Sex = "F";
                        else if (laboratoryProcedure.Episode.Patient.Sex.ADI == "ERKEK")
                            pid.Sex = "M";
                        else
                            pid.Sex = "O";
                    }
                    else
                        pid.Sex = "U";
                    patient.Pid = pid;
                    //Order.OBR, tetkik bilgisi segmenti
                    XXXXXXIHEWS.OBR obr = new XXXXXXIHEWS.OBR();
                    obr.PlacerOrderNumber = laboratoryProcedure.ObjectID.ToString();
                    //obr.UniversalServiceID = laboratoryProcedure.ProcedureObject.SKRSLoincKodu.LOINCNUMARASI.ToString();
                    obr.UniversalServiceID = ((LaboratoryTestDefinition)laboratoryProcedure.ProcedureObject).FreeLOINCCode;
                    obr.OrderingProvider = laboratoryProcedure.Laboratory.RequestDoctor.DiplomaNo + "^" + laboratoryProcedure.Laboratory.RequestDoctor.Person.Surname + "^" + laboratoryProcedure.Laboratory.RequestDoctor.Person.Name + "^" + laboratoryProcedure.Laboratory.RequestDoctor.EmploymentRecordID + "^" + laboratoryProcedure.Laboratory.RequestDoctor.Person.UniqueRefNo + "^" + laboratoryProcedure.Laboratory.RequestDoctor.PhoneNumber; // "N-DOK165^KARAYEĞEN^AYTUĞ^^10000000000^";
                    //Order.ORC, istem bilgisi segmenti
                    XXXXXXIHEWS.ORC orc = new XXXXXXIHEWS.ORC();
                    orc.OrderControl = "NW";
                    orc.PlacerOrderNumber = obr.PlacerOrderNumber;
                    orc.DateTimeofTransaction = ((DateTime)laboratoryProcedure.RequestDate).ToString("yyyyMMddHHmmss"); //DateTime.Now.ToString("yyyyMMddHHmmss");
                    //Order segmenti
                    XXXXXXIHEWS.OULOrder order = new XXXXXXIHEWS.OULOrder();
                    order.Orc = orc;
                    order.Obr = obr;
                    orderList.Add(order);
                    //Specimen.SPM, ornek bilgileri segmenti 
                    XXXXXXIHEWS.SPM spm = new XXXXXXIHEWS.SPM();
                    spm.SpecimenType = "SER";
                    spm.SpecimenDesc = "Aciklama";
                    spm.SpecimenID = laboratoryProcedure.SpecimenId.ToString();
                    //Specimen segmenti
                    XXXXXXIHEWS.Specimen specimen = new XXXXXXIHEWS.Specimen();
                    specimen.Spm = spm;
                    XXXXXXIHEWS.OUL22Specimen oul22Specimen = new XXXXXXIHEWS.OUL22Specimen();
                    oul22Specimen.Specimen = specimen;
                    oul22Specimen.OULOrderArr = orderList.ToArray();
                    oul22SpecimenList.Add(oul22Specimen);
                    oul22.Msh = msh;
                    oul22.Patient = patient;
                    oul22.OUL22SpecimenArr = oul22SpecimenList.ToArray();
                    orl34 = XXXXXXIHEWS.WebMethods.OUL22ToORL34Sync(Sites.SiteLocalHost, oul22);
                    if (orl34.Msa.AcknowledgmentCode == "AA") //basarılı kaydedıldı.
                    {
                        if (orl34.OML33Specimen[0].Order[0].Obr.ResultStatus == "F")
                        {
                            laboratoryProcedure.Reference = orl34.OML33Specimen[0].Order[0].Obx[0].ReferencesRange;
                            laboratoryProcedure.Result = orl34.OML33Specimen[0].Order[0].Obx[0].ObservationValue;
                            //if (orl34.OML33Specimen[0].Order[0].Obx[0].DateOfAnalysis != "")
                            //{
                            //    laboratoryProcedure.ResultDate = Convert.ToDateTime(orl34.OML33Specimen[0].Order[0].Obx[0].DateOfAnalysis).Date;
                            //    laboratoryProcedure.ApproveDate = Convert.ToDateTime(orl34.OML33Specimen[0].Order[0].Obx[0].DateOfAnalysis).Date;
                            //}
                            //if (orl34.OML33Specimen[0].Order[0].Obx[0].DateOfObservation != "")
                            //{
                            //    laboratoryProcedure.ProcedureDate = Convert.ToDateTime(orl34.OML33Specimen[0].Order[0].Obx[0].DateOfObservation).Date;
                            //}
                            laboratoryProcedure.Unit = orl34.OML33Specimen[0].Order[0].Obx[0].Units;
                            //laboratoryProcedure.Panic = orl34.OML33Specimen[0].Order[0].Obx[0].AbnormalFlags;
                            //laboratoryProcedure.AcceptDate= orl34.OML33Specimen[0].Order[0].Obx[0].date ;
                            objContext.Save();
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    //throw new Exception(ex.Message.ToString());
                    return false;
                }
            }

            return false;
        }

        public string GetReportURLFromLIS(LaboratoryProcedure laboratoryProcedure)
        {
            string urlParams = "";
            string checkSum = "";
            string urlLink = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXENTEGRATIONURL", ""); //"http://X.X.X.X/alissonuc/Rapor_Sonuc.aspx?";
            if (laboratoryProcedure.SpecimenId != null)
            {
                urlParams = urlParams + "OID=" + WebUtility.UrlEncode(EncodeTo64UTF8(laboratoryProcedure.SpecimenId.ToString()));
                if (laboratoryProcedure.Episode.Patient.UniqueRefNo.ToString() != null)
                {
                    urlParams = urlParams + "&TCKN=" + WebUtility.UrlEncode(EncodeTo64UTF8(laboratoryProcedure.Episode.Patient.UniqueRefNo.ToString()));
                }
            }

            checkSum = CheckSumUrl(DateTime.Now, laboratoryProcedure.SpecimenId.ToString());
            urlLink = urlLink + urlParams + "&CHK=" + checkSum;
            return urlLink;
        }

        [HttpGet]
        public string GetReportURLFromLISBySpecimenID(string specimenID, string patientTCNo)
        {
            string urlParams = "";
            string checkSum = "";
            string urlLink = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXENTEGRATIONURL", ""); //"http://X.X.X.X/alissonuc/Rapor_Sonuc.aspx?";
            if (specimenID != null)
            {
                urlParams = urlParams + "OID=" + WebUtility.UrlEncode(EncodeTo64UTF8(specimenID.ToString()));
                if (patientTCNo.ToString() != null)
                {
                    urlParams = urlParams + "&TCKN=" + WebUtility.UrlEncode(EncodeTo64UTF8(patientTCNo.ToString()));
                }
            }

            checkSum = CheckSumUrl(DateTime.Now, specimenID.ToString());
            urlLink = urlLink + urlParams + "&CHK=" + checkSum;
            return urlLink;
        }


        public string GetResultURLFromLIS(LaboratoryProcedure laboratoryProcedure)
        {
            string urlParams = "";
            string checkSum = "";

            // reqProc.ProcedureResultLink = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXRESULTVIEWURL", "") + "OID=" + laboratoryProcedure.SpecimenId.ToString(); 

            string urlLink = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXRESULTVIEWURL", "");
            if (laboratoryProcedure.SpecimenId != null)
            {
                urlParams = urlParams + "OID=" + WebUtility.UrlEncode(EncodeTo64UTF8(laboratoryProcedure.SpecimenId.ToString()));
            }

            checkSum = CheckSumUrl(DateTime.Now, laboratoryProcedure.SpecimenId.ToString());
            urlLink = urlLink + urlParams + "&CHK=" + checkSum;
            return urlLink;
        }



        [HttpGet]
        public string GetBloodRequestURL(string EpisodeActionObjectID)
        {
            BloodProductRequest bld = new BloodProductRequest();
            string urlLink = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXBLOODURL", "http://X.X.X.X/AlisWeb/Default.aspx?Enteg=S0J8MA=="); ;
            TTObjectContext objContext = new TTObjectContext(false);
            EpisodeAction episodeAction = (EpisodeAction)objContext.GetObject(new Guid(EpisodeActionObjectID), "EpisodeAction");
            List<XXXXXXIHEWS.HastaKanIstem> list = BloodProductRequest.GetPatientBloodRequestFromLIS(episodeAction.SubEpisode.ObjectID.ToString());
            if (list != null)
                bld.CreateorUpdateBloodBankRequestAction(list, episodeAction.SubEpisode.ObjectID.ToString(), episodeAction);


            //Eski sistemden aktarılan hastalar için eski sistemdeki Patient.ID gönderilecek (Patient.VemHastaKodu)
            string patientID;
            if (!string.IsNullOrEmpty(episodeAction.Episode.Patient.VemHastaKodu))
                patientID = episodeAction.Episode.Patient.VemHastaKodu.ToString();
            else
                patientID = episodeAction.Episode.Patient.ID.ToString();


            urlLink = urlLink + "&Kisi=";
            string kisi = "";
            kisi = kisi + episodeAction.Episode.Patient.UniqueRefNo.ToString() + "|" + patientID + "|";
            kisi = kisi + episodeAction.Episode.Patient.Name + "|" + episodeAction.Episode.Patient.Surname + "|";
            if (episodeAction.Episode.Patient.Sex.KODU == "1") //Erkek
                kisi = kisi + "1" + "|";
            else if (episodeAction.Episode.Patient.Sex.KODU == "2") //Kadın
                kisi = kisi + "0" + "|";
            else
                kisi = kisi + "2" + "|"; //Bilinmeyen
            kisi = kisi + Convert.ToDateTime(episodeAction.Episode.Patient.BirthDate).ToString("dd.MM.yyyy hh:mm:ss") + "|";
            kisi = kisi + episodeAction.Episode.Patient.CityOfBirth?.ADI + "|" + episodeAction.Episode.Patient.FatherName + "|";
            kisi = kisi + episodeAction.Episode.Patient.MotherName + "|||" + episodeAction.Episode.Patient.MobilePhone + "|";
            kisi = kisi + episodeAction.Episode.Patient.EMail + "|";
            kisi = kisi + episodeAction.SubEpisode.ObjectID + "|";
            urlLink = urlLink + EncodeTo64UTF8(kisi);
            //Protokol No oalrak ıstemın yapıldıgı Epısodeactıon.ID gonderılıyor. 
            //Daha sonra KanIstem sorgulamada bu EpisodeActionObjectID ıle sorgulama yapılacak ve masterActıon ı bu  olan ıstemlerın lıstelenmesı ve fıre edılmesı saglanmıs olacak.
            urlLink = urlLink + "&Gelis=";
            string gelis = "|";
            gelis = gelis + episodeAction.Episode.ID.ToString() + "|";
            gelis = gelis + "1|";
            if (episodeAction.Episode.PatientStatus == PatientStatusEnum.Outpatient)
                gelis = gelis + "0|";
            else
                gelis = gelis + "1|";
            gelis = gelis + episodeAction.SubEpisode.PatientAdmission.Payer?.Code?.ToString() + "|" + episodeAction.SubEpisode.PatientAdmission.Payer?.Name?.ToString() + "|";
            if (episodeAction.Episode.PatientStatus == PatientStatusEnum.Inpatient)
            {
                if (episodeAction.SubEpisode.StarterEpisodeAction is InPatientTreatmentClinicApplication)
                {
                    gelis = gelis + episodeAction.SubEpisode.StarterEpisodeAction.MasterResource.ID.ToString() + "|" + episodeAction.SubEpisode.StarterEpisodeAction.MasterResource.Name.ToString() + "||";
                }
            }

            if (episodeAction.Episode.PatientStatus == PatientStatusEnum.Outpatient)
                gelis = gelis + episodeAction.Episode.GetExaminationPoliclinic().ID.ToString() + "|" + episodeAction.Episode.GetExaminationPoliclinic().Name.ToString() + "||";
            if (episodeAction.Episode.PatientStatus == PatientStatusEnum.Outpatient)
            {
                gelis = gelis + episodeAction.Episode.GetPatientExaminationDoctor()?.Person?.UniqueRefNo.ToString() + "|" + episodeAction.Episode.GetPatientExaminationDoctor()?.Person?.Name?.ToString() + "|";
                gelis = gelis + episodeAction.Episode.GetPatientExaminationDoctor()?.Person?.Surname?.ToString() + "|" + episodeAction.Episode.GetPatientExaminationDoctor()?.EmploymentRecordID?.ToString() + "|";
            }

            if (episodeAction.Episode.PatientStatus == PatientStatusEnum.Inpatient)
            {
                if (episodeAction.SubEpisode.StarterEpisodeAction is InPatientTreatmentClinicApplication)
                {
                    InPatientTreatmentClinicApplication clinicEpisodeAction = (InPatientTreatmentClinicApplication)episodeAction.SubEpisode.StarterEpisodeAction;
                    gelis = gelis + clinicEpisodeAction.ProcedureDoctor.Person?.UniqueRefNo.ToString() + "|" + clinicEpisodeAction.ProcedureDoctor.Person?.Name?.ToString() + "|";
                    gelis = gelis + clinicEpisodeAction.ProcedureDoctor.Person?.Surname?.ToString() + "|" + clinicEpisodeAction.ProcedureDoctor.EmploymentRecordID?.ToString() + "|";
                }
            }

            foreach (DiagnosisGrid dg in episodeAction.Episode.Diagnosis)
            {
                gelis = gelis + dg.Diagnose?.Code?.ToString() + "|" + dg.Diagnose?.Name?.ToString() + "|";
                break;
            }

            gelis = gelis + DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss") + "|||||||";
            urlLink = urlLink + EncodeTo64UTF8(gelis);
            string tarih = "&tarih=";
            tarih = tarih + DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss");
            urlLink = urlLink + tarih;
            if (episodeAction.Episode.PatientStatus == PatientStatusEnum.Inpatient)
                urlLink = urlLink + "&YATAN=E";
            else
                urlLink = urlLink + "&YATAN=H";
            urlLink = urlLink + "&code=base64";
            return urlLink;
        }

        [HttpPost]
        public string GetURLForAllTestResults(TestResultQueryInputDVO inputDVO)
        {
            //Test gelis no  ve ornek no datası : 
            //EpisodeID = "38456";
            //string OrnekNo = "20154044";
            string urlParams = "";
            string urlLink = "";
            if (inputDVO.ViewType == "GRID")
                urlLink = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXRESULTVIEWBYGRIDFORMATURL", "");
            if (inputDVO.ViewType == "PIVOT")
                urlLink = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXRESULTVIEWBYPIVOTFORMATURL", "");

            urlParams = "Date=" + Convert.ToDateTime(DateTime.Now).ToString("dd.MM.yyyy HH:mm:ss") + "&GELIS_NO=" + inputDVO.EpisodeID;
            urlLink = urlLink + "Param=" + EncodeTo64UTF8(urlParams);
            return urlLink;
        }

        [HttpPost]
        public string GetURLForAllEpisodeTestResults(TestResultQueryInputDVO inputDVO)
        {

            string urlParams = "";
            string checkSum = "";

            string urlLink = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXRESULTVIEWURL", "");
            if (inputDVO.PatientTCKN != null)
            {
                urlParams = urlParams + "TCKN=" + WebUtility.UrlEncode(EncodeTo64UTF8(inputDVO.PatientTCKN.ToString()));
                checkSum = CheckSumUrl(DateTime.Now, inputDVO.PatientTCKN.ToString());
                urlLink = urlLink + urlParams + "&CHK=" + checkSum;
                return urlLink;
            }
            else
            {
                urlParams = urlParams + "GELIS_NO=" + WebUtility.UrlEncode(EncodeTo64UTF8(inputDVO.EpisodeID.ToString()));
                checkSum = CheckSumUrl(DateTime.Now, inputDVO.EpisodeID.ToString());
                urlLink = urlLink + urlParams + "&CHK=" + checkSum;
                return urlLink;
            }
        }

        [HttpGet]
        public string GetURLForAllTestResultsByPatientID(string PatientID)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            Patient patient = (Patient)objContext.GetObject(new Guid(PatientID), "Patient");

            string urlParams = "";
            string checkSum = "";
            string urlLink = "";
            if (!String.IsNullOrEmpty(patient.UniqueRefNo.ToString()))
            {
                urlLink = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXRESULTVIEWURL", "");
                urlParams = urlParams + "TCKN=" + WebUtility.UrlEncode(EncodeTo64UTF8(patient.UniqueRefNo.ToString()));
                checkSum = CheckSumUrl(DateTime.Now, patient.UniqueRefNo.ToString());
                urlLink = urlLink + urlParams + "&CHK=" + checkSum;
              
            }
            return urlLink;
        }


        public static string GetURLForAllEpisodeTestResultsForPatientHistory(string patientTCKN)
        {

            string urlParams = "";
            string checkSum = "";

            string urlLink = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXRESULTVIEWURL", "");
            if (patientTCKN != null)
            {
                urlParams = urlParams + "TCKN=" + WebUtility.UrlEncode(EncodeTo64UTF8(patientTCKN.ToString()));
            }

            checkSum = CheckSumUrl(DateTime.Now, patientTCKN.ToString());
            urlLink = urlLink + urlParams + "&CHK=" + checkSum;
            return urlLink;

        }
        public static string GetURLForAllTestResultsByPatient(string viewType, string patientID)
        {
            //Test gelis no  ve ornek no datası : 
            //EpisodeID = "38456";
            //string OrnekNo = "20154044";
            string urlParams = "";
            string urlLink = "";
            if (viewType == "GRID")
                urlLink = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXRESULTVIEWBYGRIDFORMATURL", "");
            if (viewType == "PIVOT")
                urlLink = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXRESULTVIEWBYPIVOTFORMATURL", "");

            urlParams = "Date=" + Convert.ToDateTime(DateTime.Now).ToString("dd.MM.yyyy HH:mm:ss") + "&TCKN=" + patientID;
            urlLink = urlLink + "Param=" + EncodeTo64UTF8(urlParams);
            return urlLink;
        }

        [HttpGet]
        public string PrepareAndShowLabResultURLForXXXXXX([FromQuery] LaboratoryProcedure laboratoryProcedure)
        {
            //Bu method hem lab sonuclarını sorgulamk hem de sonuc URL sini olusturmak icin yazilmisti. Ancak sonuclar batch ile alanicagi icin gecerliligi kalmadi.
            //sonuc URL GetResultURLFromLIS methodu ile olusturulacak.
            return null;
            //string urlParams = "";
            //string checkSum = "";
            //string urlLink = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXENTEGRATIONURL", ""); //"http://X.X.X.X/alissonuc/Rapor_Sonuc.aspx?";
            //TTObjectContext objContext = new TTObjectContext(false);
            //if (laboratoryProcedure.Result == null || laboratoryProcedure.Result == "")
            //{
            //    if (this.GetLaboratoryProcedureResultFromXXXXXX(laboratoryProcedure) == true)
            //    {
            //        urlLink = GetResultURLFromLIS(laboratoryProcedure);
            //        if (laboratoryProcedure.SpecimenId != null)
            //        {
            //            urlParams = urlParams + "OID=" + WebUtility.UrlEncode(EncodeTo64UTF8(laboratoryProcedure.SpecimenId.ToString()));
            //            if (laboratoryProcedure.Episode.Patient.UniqueRefNo.ToString() != null)
            //            {
            //                urlParams = urlParams + "&TCKN=" + WebUtility.UrlEncode(EncodeTo64UTF8(laboratoryProcedure.Episode.Patient.UniqueRefNo.ToString()));
            //            }
            //        }
            //        checkSum = CheckSumUrl(DateTime.Now, laboratoryProcedure.SpecimenId.ToString());
            //        urlLink = urlLink + urlParams + "&CHK=" + checkSum;
            //        return urlLink;
            //    }
            //    else
            //    {
            //        return "";
            //    }
            //}
            //else
            //{
            //    urlLink = GetResultURLFromLIS(laboratoryProcedure);
            //    if (laboratoryProcedure.SpecimenId != null)
            //    {
            //        urlParams = urlParams + "OID=" + WebUtility.UrlEncode(EncodeTo64UTF8(laboratoryProcedure.SpecimenId.ToString()));
            //        if (laboratoryProcedure.Episode.Patient.UniqueRefNo.ToString() != null)
            //        {
            //            urlParams = urlParams + "&TCKN=" + WebUtility.UrlEncode(EncodeTo64UTF8(laboratoryProcedure.Episode.Patient.UniqueRefNo.ToString()));
            //        }
            //    }
            //    checkSum = CheckSumUrl(DateTime.Now, laboratoryProcedure.SpecimenId.ToString());
            //    urlLink = urlLink + urlParams + "&CHK=" + checkSum;
            //    return urlLink;
            //}
        }

        [HttpGet]
        public List<string> GetPatientProceduresByLastNDays(string EpisodeActionObjectID)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            EpisodeAction episodeAction = (EpisodeAction)objContext.GetObject(new Guid(EpisodeActionObjectID), "EpisodeAction");
            List<string> procedureObjectDefList = new List<string>();
            Int16 lastNDays = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("PROCEDUREREQUESTLASTNDAY", "10"));
            DateTime startDate = DateTime.Now.AddDays(-lastNDays);
            DateTime endDate = DateTime.Now;
            IBindingList procedureObjectIDList = SubActionProcedure.GetSubActionProcedureByTimeInterval(episodeAction.Episode.Patient.ObjectID, startDate, endDate);
            foreach (SubActionProcedure.GetSubActionProcedureByTimeInterval_Class procedure in procedureObjectIDList)
            {
                procedureObjectDefList.Add(procedure.ObjectID.ToString());
            }

            return procedureObjectDefList;
        }

        [HttpGet]
        public int GetPatientStatus(string EpisodeActionObjectID)
        {
          
            TTObjectContext objContext = new TTObjectContext(false);
            EpisodeAction episodeAction = (EpisodeAction)objContext.GetObject(new Guid(EpisodeActionObjectID), "EpisodeAction");
            int patientStatus = episodeAction.SubEpisode.PatientStatus.HasValue ? Convert.ToInt32(episodeAction.SubEpisode.PatientStatus.Value) : -1; //0'da kapalı olacak
            
            return patientStatus;
        }

        [HttpPost]
        public string GetLabTestByPatientByTestByDateExists(DurationLimitedProceduresQueryParam inputParam)
        {
            TTObjectContext objContext = new TTObjectContext(false);


            DateTime startDate = DateTime.Now.AddDays(-inputParam.Duration);
            DateTime endDate = DateTime.Now;
            List<LaboratoryProcedure> labTestList = LaboratoryProcedure.GetLabTestByPatientByTestByDate(objContext, inputParam.PatientObjectID, inputParam.ProcedureObjectID, startDate, endDate).ToList();

            string resultText = string.Empty;

            if (labTestList != null && labTestList.Count > 0)
            {
                resultText = "İstediğiniz tetkiğin aşağıdaki tarihte sonucu mevcuttur. <br/><br/>";
                foreach (var test in labTestList)
                {
                    resultText += "Test Adı: "+test.ProcedureObject.Code+"-"+ test.ProcedureObject.Name + " <br/>Sonuç Tarihi: " + test.ResultDate.Value.ToShortDateString() + " <br/>Sonuç: " + test.Result + " " + test.Unit + "(" + test.Reference + ")" + "<br/>";
                }

                if (labTestList[0].ProcedureObject is LaboratoryTestDefinition)//en son girilen
                {
                    LaboratoryTestDefinition labTestDef = (LaboratoryTestDefinition)labTestList[0].ProcedureObject;

                    if (labTestList[0].SubEpisode.PatientAdmission.IsNewBorn == true && !string.IsNullOrEmpty(labTestDef.NewBornAlert))
                    {
                        //yenidoğan açıklama grilmiş ve negatif çeki işaretlenmiş ve en son tahlil sonucu negatif ise
                        if (labTestDef.NewBornNegative == true && (labTestList[0].Result.ToLower().Contains("negatif") || labTestList[0].Result.ToLower().Contains("negatıf")))
                        {
                            resultText += "<br/>" + labTestDef.NewBornAlert;
                        }
                        else if (labTestDef.NewBornPositive == true && (labTestList[0].Result.ToLower().Contains("positif") || labTestList[0].Result.ToLower().Contains("pozıtıf")))
                        {
                            resultText += "<br/>" + labTestDef.NewBornAlert;
                        }
                        else if (labTestDef.NewBornNegative != true && labTestDef.NewBornPositive != true)//hiç biri çekli değil ise
                            resultText += "<br/>" + labTestDef.NewBornAlert;
                    }

                    if (!string.IsNullOrEmpty(labTestDef.AdultAlert) && labTestList[0].Episode.Patient.Age != null && labTestList[0].Episode.Patient.Age >= 18)
                    {
                        if (labTestDef.AdultNegative == true && labTestList[0].Result != null && (labTestList[0].Result.ToLower().Contains("negatif") || labTestList[0].Result.ToLower().Contains("negatıf")))
                        {
                            resultText += "<br/>" + labTestDef.AdultAlert;
                        }
                        else if (labTestDef.AdultPositive == true && labTestList[0].Result != null && (labTestList[0].Result.ToLower().Contains("positif") || labTestList[0].Result.ToLower().Contains("pozıtıf")))
                        {
                            resultText += "<br/>" + labTestDef.AdultAlert;
                        }
                        else if (labTestDef.AdultPositive != true && labTestDef.AdultNegative != true)
                            resultText += "<br/>" + labTestDef.AdultAlert;
                    }
                }
            }

            //(LaboratoryTestDefinition)labTestList[0].ProcedureObject

            return resultText;
        }


        [HttpPost]
        public List<ProcedureDefinition> CheckRepeatedProceduresByPatient(RepeatedProceduresQueryInputDVO inputDVO)
        {
            TTObjectContext objContext = new TTObjectContext(false);

            List<ProcedureDefinition> repeatedProceduresList = new List<ProcedureDefinition>();

            //Sadece aynı gündeki istemlerinde mükerrer test var mi kontrol yapilacak
            DateTime todayValue = Convert.ToDateTime(Common.RecTime().ToString("dd.MM.yyyy") + " " + "00:00:00");
            IBindingList patientProceduresList = SubActionProcedure.GetTestsByOutpatientEpisode(objContext, todayValue, inputDVO.PatientID);

            foreach (string reqProcObjectID in inputDVO.RequestedProceduresObjectIDList)
            {

                foreach (SubActionProcedure sp in patientProceduresList)
                {
                    if (sp is LaboratoryProcedure)
                    {
                        if (sp.ProcedureObject.ObjectID.ToString() == reqProcObjectID)
                        {
                            LaboratoryProcedure labProc = (LaboratoryProcedure)sp;
                            if (labProc.CurrentStateDefID == LaboratoryProcedure.States.SampleAccept || labProc.CurrentStateDefID == LaboratoryProcedure.States.SampleTaking || labProc.CurrentStateDefID == LaboratoryProcedure.States.SampleLaboratoryAccept || labProc.CurrentStateDefID == LaboratoryProcedure.States.Procedure)
                            {
                                repeatedProceduresList.Add(sp.ProcedureObject);
                                break;
                            }
                        }
                    }
                    if (sp is RadiologyTest)
                    {
                        if (sp.ProcedureObject.ObjectID.ToString() == reqProcObjectID)
                        {
                            RadiologyTest rTest = (RadiologyTest)sp;
                            if (rTest.CurrentStateDefID == RadiologyTest.States.RequestAcception || rTest.CurrentStateDefID == RadiologyTest.States.Appointment || rTest.CurrentStateDefID == RadiologyTest.States.Procedure)
                            {
                                repeatedProceduresList.Add(sp.ProcedureObject);
                                break;
                            }
                        }
                    }
                    if (sp is NuclearMedicineTest)
                    {
                        if (sp.ProcedureObject.ObjectID.ToString() == reqProcObjectID)
                        {
                            NuclearMedicineTest rTest = (NuclearMedicineTest)sp;
                            if (rTest.CurrentStateDefID == NuclearMedicineTest.States.New)
                            {
                                repeatedProceduresList.Add(sp.ProcedureObject);
                                break;
                            }
                        }
                    }
                }
            }
            return repeatedProceduresList;
        }

        public static string FillLeftStr(string str, string fillStr, int size)
        {
            string result = str;
            if (!string.IsNullOrEmpty(str))
                if (str.Length < size)
                {
                    int toRepeat = size - str.Length;
                    for (int i = 1; i <= toRepeat; i++)
                        str = fillStr + str;
                }

            return str;
        }

        //public string EncodeTo64(string toEncode)
        //{
        //    byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
        //    string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
        //    return returnValue;
        //}
        public static string EncodeTo64UTF8(string toEncode)
        {
            string returnValue = "";
            if (!string.IsNullOrWhiteSpace(toEncode))
            {
                try
                {
                    byte[] toEncodeAsBytes = System.Text.UTF8Encoding.UTF8.GetBytes(toEncode);
                    returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
                }
                catch
                {
                    returnValue = toEncode;
                }
            }

            return returnValue;
        }

        public static string CheckSumUrl(DateTime tarih, string str)
        {
            if (string.IsNullOrEmpty(str) || tarih == null || tarih == DateTime.MinValue)
                return string.Empty;
            str = tarih.ToString("yyyyMMddHHmm") + FillLeftStr(str, "0", 25);
            string res = string.Empty;
            for (int i = 0; i < str.Length - 1; i++)
                if (str[i] % 3 == 0)
                    res += Convert.ToChar((((str[i] + str[(i + 1)]) % 80) + 80));
                else
                    res += Convert.ToChar((((str[i] + str[(i + 1)]) % 50) + 50));
            return WebUtility.UrlEncode(EncodeTo64UTF8(res));
        }

        [HttpGet]
        public Guid GetPathologyObjectID(string SubActionProcedureObjectID)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            PathologyTestProcedure pathologyTest = (PathologyTestProcedure)objContext.GetObject(new Guid(SubActionProcedureObjectID), "PathologyTestProcedure");
            return pathologyTest.PathologyMaterial.Pathology.ObjectID;
        }

        [HttpGet]
        public Boolean hasRadiologyImageViewRole()
        {
            if (TTUser.CurrentUser.IsSuperUser)
                return true;

            if (TTUser.CurrentUser.HasRole(Common.RadyolojiTestImajGoruntulemeRoleID))
                return true;
            else
                return false;
        }

        [HttpGet]
        public Boolean hasProcedureDeleteRole()
        {
            if (TTUser.CurrentUser.IsSuperUser)
                return true;

            if (TTUser.CurrentUser.HasRole(Common.HizmetİstemSatırSilmeRoleID))
                return true;
            else
                return false;
        }

        [HttpGet]
        public Boolean hasProcedureAmountUpdateRole()
        {
            if (TTUser.CurrentUser.IsSuperUser)
                return true;

            if (TTUser.CurrentUser.HasRole(Common.HizmetİstemMiktarDegistirmeRoleID))
                return true;
            else
                return false;
        }

        [HttpGet]
        public Boolean hasProcedureUpdateRole()
        {
            if (TTUser.CurrentUser.IsSuperUser)
                return true;

            if (TTUser.CurrentUser.HasRole(TTRoleNames.Hizmet_Guncelleme))
                return true;
            else
                return false;
        }

        [HttpGet]
        public Boolean SetIsResultSeenValue(string subactionProcedureObjectID)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            SubActionProcedure sp = (SubActionProcedure)objContext.GetObject(new Guid(subactionProcedureObjectID), "SubActionProcedure");

            if (sp is LaboratoryProcedure)
            {
                LaboratoryProcedure labProcedure = (LaboratoryProcedure)objContext.GetObject(new Guid(subactionProcedureObjectID), "LaboratoryProcedure");
                labProcedure.IsResultSeen = true;
                objContext.Save();
                return true;
            }
            if (sp is RadiologyTest)
            {
                RadiologyTest radProcedure = (RadiologyTest)objContext.GetObject(new Guid(subactionProcedureObjectID), "RadiologyTest");
                radProcedure.IsResultSeen = true;
                objContext.Save();
                return true;
            }

            if (sp is PathologyTestProcedure)
            {
                PathologyTestProcedure patProcedure = (PathologyTestProcedure)objContext.GetObject(new Guid(subactionProcedureObjectID), "PathologyTestProcedure");
                patProcedure.IsResultSeen = true;
                objContext.Save();
                return true;
            }

            if (sp is ManipulationProcedure)
            {
                ManipulationProcedure manProcedure = (ManipulationProcedure)objContext.GetObject(new Guid(subactionProcedureObjectID), "ManipulationProcedure");
                manProcedure.IsResultSeen = true;
                objContext.Save();
                return true;
            }


            return false;
        }

        [HttpGet]
        public Guid GetManipulationObjectID(string SubActionProcedureObjectID)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            ManipulationProcedure manipulationProcedure = (ManipulationProcedure)objContext.GetObject(new Guid(SubActionProcedureObjectID), "ManipulationProcedure");
            return manipulationProcedure.Manipulation.ObjectID;
        }

        [HttpGet]
        public Guid GetPsychologyTestObjectID(string SubActionProcedureObjectID)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            PsychologyTest psychologyTest = (PsychologyTest)objContext.GetObject(new Guid(SubActionProcedureObjectID), "PsychologyTest");
            return psychologyTest.ObjectID;
        }

        // Hizmete Göre İşlem/ Hizmet Öneri için
        public List<ProcedureSuggestionInputDVO> GetProcedureSuggestionInputDVOListByProcedureList(SubEpisode subepisode)
        {
            var context = subepisode.ObjectContext;
            List<ProcedureSuggestionInputDVO> procedureSuggestionInputDVOList = new List<ProcedureSuggestionInputDVO>();

            if (subepisode.CurrentStateDefID == SubEpisode.States.Closed || subepisode.CurrentStateDefID == SubEpisode.States.Cancelled)
                return procedureSuggestionInputDVOList;

            if (subepisode.Episode.CurrentStateDefID != Episode.States.Open)
                return procedureSuggestionInputDVOList;

            // BU NQL in Order bayı ORDER BY this.ProcedureObject.SuggestionCases.ProcedureActionSuggestion,this.ProcedureObject.OBJECTID,THIS.CreationDate DESC olmalı değiştirilmemeli
            var procedureSuggestionsByEpisodeList = LaboratoryProcedure.GetProcedureSuggestionsByEpisode(subepisode.Episode.ObjectID);

            Guid OldProcedureActionSuggestion = Guid.Empty;
            Guid OldProcedureObject = Guid.Empty;
            ProcedureActionSuggestion procedureActionSuggestion = null;
            int suggestionCasesCount = -1;
            int approvedSuggestionCasesCount = 0;
            string sonucMetni = string.Empty;
            Guid? LastFouldProcedureActionSuggestion = Guid.Empty;

            foreach (var procedureSuggestionInfo in procedureSuggestionsByEpisodeList)
            {
                // Yeni Bir Öner bloğu başlıyor demek 
                if (OldProcedureActionSuggestion != procedureSuggestionInfo.Procedureactionsuggestion)
                {
                    if (OldProcedureActionSuggestion != Guid.Empty) // ilk satırda Öneri bloğu çalışmasın diye
                    {
                        // Bir önceki Öneri blogunu kontrol edip koşulları sağlanıyorsa procedureSuggestionInputDVOList e eklemek için 
                        this.CheckAddNewActionToProcedureSuggestionInputDVOList(context, subepisode, procedureSuggestionInputDVOList, approvedSuggestionCasesCount, suggestionCasesCount, procedureActionSuggestion, sonucMetni);
                    }

                    // Yeni öneri Blogunu hazırlamak için
                    procedureActionSuggestion = (ProcedureActionSuggestion)context.GetObject((Guid)procedureSuggestionInfo.Procedureactionsuggestion, "ProcedureActionSuggestion");
                    suggestionCasesCount = procedureActionSuggestion.SuggestionCases.Count;
                    OldProcedureObject = Guid.Empty;
                    approvedSuggestionCasesCount = 0;
                    OldProcedureActionSuggestion = procedureActionSuggestion.ObjectID;
                    sonucMetni = string.Empty;
                }

                if (LastFouldProcedureActionSuggestion != procedureActionSuggestion.ObjectID) //Bir öneri bloğuna ait herhangi bir koşulda çakdı ise tekrar diğer caseleri sorgulamasın
                {
                    if (OldProcedureObject != procedureSuggestionInfo.Procedureobjectid) // eğer aynı tetkikden birden fazla kez yapıldı ise sonuncusunu alsın diğerlerini hiç kale almasın diye 
                    {
                        OldProcedureObject = (Guid)procedureSuggestionInfo.Procedureobjectid; // aynı hizmetden birden fazla yapıldı ise sonuncusunu alsın diye 

                        bool approved = false;
                        double result_numeric; // tetkik sonucu numaric ise Max ve Min değerle karşılaştırılır 
                        bool isNumeric = double.TryParse(procedureSuggestionInfo.Result.Replace(".", ","), out result_numeric);
                        if (isNumeric)
                        {
                            if (procedureSuggestionInfo.MinResult != null)
                            {
                                double min_numeric;
                                bool minIsNumeric = double.TryParse(procedureSuggestionInfo.MinResult.Replace(".", ","), out min_numeric);
                                if (minIsNumeric)
                                {
                                    if (result_numeric <= min_numeric)
                                    {
                                        approved = true;
                                    }

                                }
                            }

                            if (approved == false && procedureSuggestionInfo.MaxResult != null)
                            {
                                double max_numeric;

                                bool maxIsNumeric = double.TryParse(procedureSuggestionInfo.MaxResult.Replace(".", ","), out max_numeric);
                                if (maxIsNumeric)
                                {
                                    if (result_numeric >= max_numeric)
                                        approved = true;
                                }
                            }
                        }
                        else
                        {
                            if (procedureSuggestionInfo.MinResult != null)
                            {
                                if (procedureSuggestionInfo.Result.Trim().Equals(procedureSuggestionInfo.MinResult.Trim()))
                                    approved = true;

                            }
                            else if (procedureSuggestionInfo.MaxResult != null)
                            {
                                if (procedureSuggestionInfo.Result.Trim().Equals(procedureSuggestionInfo.MaxResult.Trim()))
                                    approved = true;
                            }
                        }
                        if (approved)
                        {
                            sonucMetni += "<br/>" + procedureSuggestionInfo.Procedureobjectname + ":" + procedureSuggestionInfo.Result;
                            approvedSuggestionCasesCount++;
                        }
                        else
                        {
                            LastFouldProcedureActionSuggestion = procedureActionSuggestion.ObjectID;
                        }
                    }

                }
            }

            //Son Öneri blogunu kontrol edip koşulları sağlanıyorsa procedureSuggestionInputDVOList e eklemek için 
            this.CheckAddNewActionToProcedureSuggestionInputDVOList(context, subepisode, procedureSuggestionInputDVOList, approvedSuggestionCasesCount, suggestionCasesCount, procedureActionSuggestion, sonucMetni);

            return procedureSuggestionInputDVOList;
        }

        private void CheckAddNewActionToProcedureSuggestionInputDVOList(TTObjectContext context, SubEpisode subepisode, List<ProcedureSuggestionInputDVO> procedureSuggestionInputDVOList, int approvedSuggestionCasesCount, int suggestionCasesCount, ProcedureActionSuggestion procedureActionSuggestion, string sonucMetni)
        {
            if (approvedSuggestionCasesCount == suggestionCasesCount) // tüm koşullar sağlandıysa 
            {
                if (procedureActionSuggestion.ActionType != null) // ProcedureActionSuggestionForm Tanımında  ActionTye varsa
                {
                    ResSection defaultMasterResource = null;
                    List<Guid> masterResourceGuidList = new List<Guid>();
                    // Daha önce istenmedi ise
                    if (procedureActionSuggestion.SuggestedMasterResource is ResDepartment)
                    {
                        foreach (ResPoliclinic resPoliClinic in ((ResDepartment)procedureActionSuggestion.SuggestedMasterResource).Policlinics)
                        {
                            if (defaultMasterResource == null)
                                defaultMasterResource = resPoliClinic;
                            masterResourceGuidList.Add(resPoliClinic.ObjectID);
                        }
                        foreach (ResClinic resClinic in ((ResDepartment)procedureActionSuggestion.SuggestedMasterResource).Clinics)
                        {
                            if (defaultMasterResource == null)
                                defaultMasterResource = resClinic;
                            masterResourceGuidList.Add(resClinic.ObjectID);
                        }
                    }
                    else
                    {
                        defaultMasterResource = procedureActionSuggestion.SuggestedMasterResource;
                        if (defaultMasterResource != null)
                            masterResourceGuidList.Add(defaultMasterResource.ObjectID);
                    }



                    bool hasActionInSubEpisode = subepisode.Episode.EpisodeActions.FirstOrDefault(dr => dr.ActionType == procedureActionSuggestion.ActionType &&
                                                                                                         (procedureActionSuggestion.SuggestedMasterResource == null || masterResourceGuidList.Contains(dr.MasterResource.ObjectID))) != null;
                    if (!hasActionInSubEpisode)
                    {
                        ProcedureSuggestionInputDVO procedureSuggestionInputDVO = new ProcedureSuggestionInputDVO();
                        procedureSuggestionInputDVO.MasterResource = defaultMasterResource;
                        procedureSuggestionInputDVO.MasterResourceGuidList = masterResourceGuidList;
                        procedureSuggestionInputDVO.Message = procedureActionSuggestion.Message + sonucMetni;
                        procedureSuggestionInputDVO.ActionType = procedureActionSuggestion.ActionType;
                        procedureSuggestionInputDVOList.Add(procedureSuggestionInputDVO);

                    }
                }
            }
        }


        [HttpPost]
        public void SaveUserOption(UserOptionInputDVO userOptionInputDVO)
        {

            ResUser myUser = Common.CurrentResource;
            myUser.SaveUserOptionValue(userOptionInputDVO.UserOptionType, userOptionInputDVO.OptionValue);
        }

        [HttpPost]
        public UserOption GetUserOption(UserOptionInputDVO userOptionInputDVO)
        {

            ResUser myUser = Common.CurrentResource;
            UserOption myUserOption = myUser.GetUserOption(userOptionInputDVO.UserOptionType);
            return myUserOption;
        }


        [HttpGet]
        //Verilen Hizmet Kodu icin verilen tarih araliginda ayni hizmetin oldugu tarih bilgisini liste olarak doner
        public List<DateTime> GetProcedureCountByDateTimeIntervalByPatient(string PatientObjectID, string ProcedureObjectID, string StartDate, string EndDate)
        {
            DateTime startDate = Convert.ToDateTime(StartDate);
            DateTime endDate = Convert.ToDateTime(EndDate);

            List<DateTime> procedureDateList = new List<DateTime>();
            List<SubActionProcedure.GetProcedureCountByDateTimeIntervalByPatient_Class> procedureCountByDateList = SubActionProcedure.GetProcedureCountByDateTimeIntervalByPatient(startDate, endDate, PatientObjectID, ProcedureObjectID).ToList();

            foreach (SubActionProcedure.GetProcedureCountByDateTimeIntervalByPatient_Class procedureDate in procedureCountByDateList)
            {
                procedureDateList.Add(Convert.ToDateTime(procedureDate.Tarih));
            }

            return procedureDateList;
        }

        [HttpGet]
        public QuickProcedureEntryViewModel LoadQuickProcedureEntryForm()
        {
            QuickProcedureEntryViewModel viewModel = new QuickProcedureEntryViewModel();

            if (Common.CurrentResource.TakesPerformanceScore == true )
            {

                viewModel.ProcedureDoctor = Common.CurrentResource as ResUser;

            }
            return viewModel;
        }


        public class DurationLimitedProceduresQueryParam
        {
            public string PatientObjectID
            {
                get;
                set;
            }
            public string ProcedureObjectID
            {
                get;
                set;
            }
            public int Duration
            {
                get;
                set;
            }
        }

        [HttpGet]
        public ProcedureUserObj[] GetProcedureUsers(string MasterResourceID)
        {
            ProcedureUserObj[] result;
            using (var objectContext = new TTObjectContext(false))
            {
               
                var ttList = ResUser.DoctorListNQL(objectContext, " AND ISACTIVE = 1 AND USERRESOURCES.RESOURCE = '" + MasterResourceID + "' ORDER BY NAME");
                var query =
                    from i in ttList
                    select new ProcedureUserObj { ObjectID = i.ObjectID, Name = i.Name };
                result = query.ToArray();
             
            }

            return result;
        }


        [HttpPost]
        public void UpdateProcedure(vmRequestedProcedure procedure)
        {
            if (procedure.SubActionProcedureObjectId != Guid.Empty)
            {
                SubActionProcedure sa;
                using (var context = new TTObjectContext(false))
                {
                    sa = context.GetObject<SubActionProcedure>(procedure.SubActionProcedureObjectId);
                    if (procedure.isAmountChanged)
                        sa.Amount = procedure.Amount;
                    if (procedure.isDateChanged)
                    {
                        sa.CreationDate = procedure.RequestDate;
                        sa.PricingDate = procedure.RequestDate;
                    }
                    if (procedure.isProcedureUserChanged)
                        sa.ProcedureDoctor = context.GetObject<ResUser>(procedure.ProcedureUserId);

                    if (sa is BaseAdditionalApplication)
                    {

                        if (procedure.BaseAdditionalInfoFormViewModels != null)
                        {
                            foreach (BaseAdditionalInfoFormViewModel baseAdditionalInfoFormViewModel in procedure.BaseAdditionalInfoFormViewModels)
                            {
                                var baseAdditionalInfoForm = baseAdditionalInfoFormViewModel.AddViewModelToContext(context);
                                ((BaseAdditionalApplication)sa).BaseAdditionalInfoForm.Add(baseAdditionalInfoForm);
                            }
                        }
                    }

                    context.Save();

                }
            }
        }

        [HttpGet]
        public bool HasPathologyRequest(string EpisodeActionObjectID)
        {
            bool hasPathologyRequest = false;
            TTObjectContext objContext = new TTObjectContext(true);
            EpisodeAction ea = (EpisodeAction)objContext.GetObject(new Guid(EpisodeActionObjectID), "EpisodeAction");

            foreach (EpisodeAction action in ea.SubEpisode.EpisodeActions)
            {
                if (action is PathologyRequest && ((PathologyRequest)action).CurrentStateDefID != PathologyRequest.States.Cancelled)
                {
                    hasPathologyRequest = true;
                    break;
                }
            }

            return hasPathologyRequest;
        }

        [HttpGet]
        public void CancelPathologyRequiredProceduresByCode(string EpisodeActionObjectID , string pathologyRequiredProcedureCodes)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            EpisodeAction ea = (EpisodeAction)objContext.GetObject(new Guid(EpisodeActionObjectID), "EpisodeAction");

            string[] ProcedureCodes = pathologyRequiredProcedureCodes.Split(',');


            foreach (SubActionProcedure sp in ea.SubEpisode.SubActionProcedures)
            {
                foreach (string code in ProcedureCodes)
                {
                    if (sp.ProcedureObject.Code == code && code != "" )
                    {
                      
                        sp.CurrentStateDefID = SubActionProcedure.States.Cancelled;
                    }


                }
               
            }
           


            
            objContext.Save();
        }


    }
}