//$D9221877
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TTUtils;
using System.ComponentModel;
using TTDefinitionData;
using System.Collections;

namespace Core.Controllers
{
    public partial class DrugOrderIntroductionServiceController : Controller
    {
        [HttpGet]
        public DrugOrderIntroductionNewFormViewModel DrugOrderIntroductionNewForm(Guid? id)
        {
            var formDefID = Guid.Parse("b71eaa1d-e6d0-437e-b9e3-63215104577f");
            var objectDefID = Guid.Parse("a175dfa4-8038-4605-8183-9b2d41fecf51");
            TTObjectContext readonlyContext = new TTObjectContext(true);
            TTObjectDefBaseData objectDefData = TTObjectDefBaseData.GetObjectDef(objectDefID);
            DrugOrderIntroduction ıntroduction = readonlyContext.GetObject(id.Value, "DRUGORDERINTRODUCTION", false) as DrugOrderIntroduction;
            DrugOrderIntroductionNewFormViewModel viewModel = null;
            if (ıntroduction != null)
            {
                viewModel = new DrugOrderIntroductionNewFormViewModel();
                if (id.HasValue && id.Value != Guid.Empty)
                {
                    using (var objectContext = new TTObjectContext(false))
                    {
                        viewModel._DrugOrderIntroduction = objectContext.GetObject(id.Value, objectDefID) as DrugOrderIntroduction;
                        viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DrugOrderIntroduction, formDefID);
                        viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugOrderIntroduction, formDefID);
                        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DrugOrderIntroduction);
                        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DrugOrderIntroduction);
                        objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                        ContextToViewModel(viewModel, objectContext);

                        PreScript_DrugOrderIntroductionNewForm(viewModel, viewModel._DrugOrderIntroduction, objectContext);
                        objectContext.FullPartialllyLoadedObjects();
                    }
                }
                else
                {
                    using (var objectContext = new TTObjectContext(false))
                    {
                        viewModel._DrugOrderIntroduction = new DrugOrderIntroduction(objectContext);
                        var entryStateID = Guid.Parse("16b17360-e7a6-422e-80c8-708d922eb490");
                        viewModel._DrugOrderIntroduction.CurrentStateDefID = entryStateID;
                        viewModel.OldDrugOrdersGridList = new TTObjectClasses.OldDrugOrder[] { };
                        viewModel.InpatientPresDetailsGridList = new TTObjectClasses.InpatientPresDetail[] { };
                        viewModel.OutpatientPresDetailsGridList = new TTObjectClasses.OutpatientPresDetail[] { };
                        viewModel.DiagnosisForPrescriptionsGridList = new TTObjectClasses.DiagnosisForPresc[] { };
                        viewModel.DrugOrderIntroductionDetailsGridList = new TTObjectClasses.DrugOrderIntroductionDet[] { };
                        viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DrugOrderIntroduction, formDefID);
                        viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugOrderIntroduction, formDefID);
                        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DrugOrderIntroduction);
                        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DrugOrderIntroduction);
                        viewModel.GridEpisodeDiagnosisGridList = new TTObjectClasses.DiagnosisGrid[] { };


                        PreScript_DrugOrderIntroductionNewForm(viewModel, viewModel._DrugOrderIntroduction, objectContext);
                        objectContext.FullPartialllyLoadedObjects();
                    }
                }
            }
            return viewModel;
        }

        partial void PreScript_DrugOrderIntroductionNewForm(DrugOrderIntroductionNewFormViewModel viewModel, DrugOrderIntroduction drugOrderIntroduction, TTObjectContext objectContext);
        partial void PostScript_DrugOrderIntroductionNewForm(DrugOrderIntroductionNewFormViewModel viewModel, DrugOrderIntroduction drugOrderIntroduction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_DrugOrderIntroductionNewForm(DrugOrderIntroductionNewFormViewModel viewModel, DrugOrderIntroduction drugOrderIntroduction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(DrugOrderIntroductionNewFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.OldDrugOrdersGridList = viewModel._DrugOrderIntroduction.OldDrugOrders.OfType<OldDrugOrder>().ToArray();
            viewModel.InpatientPresDetailsGridList = viewModel._DrugOrderIntroduction.InpatientPresDetails.OfType<InpatientPresDetail>().ToArray();
            viewModel.OutpatientPresDetailsGridList = viewModel._DrugOrderIntroduction.OutpatientPresDetails.OfType<OutpatientPresDetail>().ToArray();
            viewModel.DiagnosisForPrescriptionsGridList = viewModel._DrugOrderIntroduction.DiagnosisForPrescriptions.OfType<DiagnosisForPresc>().ToArray();
            viewModel.DrugOrderIntroductionDetailsGridList = viewModel._DrugOrderIntroduction.DrugOrderIntroductionDetails.OfType<DrugOrderIntroductionDet>().ToArray();
            viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
            viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.InpatientPrescriptions = objectContext.LocalQuery<InpatientPrescription>().ToArray();
            viewModel.OutPatientPrescriptions = objectContext.LocalQuery<OutPatientPrescription>().ToArray();
            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();

            viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();

            List<SubEpisode> subEpisodeList = new List<SubEpisode>();
            subEpisodeList.Add(viewModel._DrugOrderIntroduction.SubEpisode);
            viewModel.SubEpisodes = subEpisodeList.ToArray();

            List<DrugOrder> drugorderList = new List<DrugOrder>();
            foreach (DrugOrderIntroductionDet detail in viewModel._DrugOrderIntroduction.DrugOrderIntroductionDetails)
            {
                drugorderList.Add(detail.DrugOrder);
            }
            viewModel.DrugOrders = drugorderList.ToArray();

            List<InpatientDrugOrder> inDrugOrderList = new List<InpatientDrugOrder>();
            foreach (InpatientPrescription inPres in viewModel.InpatientPrescriptions)
            {
                foreach (InpatientDrugOrder inDrugOrder in inPres.InpatientDrugOrders)
                    inDrugOrderList.Add(inDrugOrder);
            }
            viewModel.InpatientDrugOrders = inDrugOrderList.ToArray();


            List<OutPatientDrugOrder> outDrugOrderList = new List<OutPatientDrugOrder>();
            foreach (OutPatientPrescription outPres in viewModel.OutPatientPrescriptions)
            {
                foreach (OutPatientDrugOrder outDrugOrder in outPres.OutPatientDrugOrders)
                    outDrugOrderList.Add(outDrugOrder);
            }
            viewModel.OutPatientDrugOrders = outDrugOrderList.ToArray();

            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.Materials);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        }



        [HttpPost]
        public SignedPrescriptionOutput PrepareSignedPrescriptionContent(DrugOrderIntroductionNewFormViewModel viewModel)
        {
            SignedPrescriptionOutput output = new SignedPrescriptionOutput();
            output.PrescriptionSignContentList = new List<PrescriptionSignContent>();
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("b71eaa1d-e6d0-437e-b9e3-63215104577f");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.ResSections);
                objectContext.AddToRawObjectList(viewModel.Stores);
                objectContext.AddToRawObjectList(viewModel.DrugOrders);
                objectContext.AddToRawObjectList(viewModel.Materials);
                objectContext.AddToRawObjectList(viewModel.InpatientPrescriptions);
                objectContext.AddToRawObjectList(viewModel.OutPatientPrescriptions);
                objectContext.AddToRawObjectList(viewModel.Episodes);
                objectContext.AddToRawObjectList(viewModel.Patients);
                objectContext.AddToRawObjectList(viewModel.OldDrugOrdersGridList);
                objectContext.AddToRawObjectList(viewModel.InpatientPresDetailsGridList);
                objectContext.AddToRawObjectList(viewModel.OutpatientPresDetailsGridList);
                objectContext.AddToRawObjectList(viewModel.DiagnosisForPrescriptionsGridList);
                objectContext.AddToRawObjectList(viewModel.DrugOrderIntroductionDetailsGridList);
                objectContext.AddToRawObjectList(viewModel.InpatientDrugOrders);
                objectContext.AddToRawObjectList(viewModel.OutPatientDrugOrders);
                var entryStateID = Guid.Parse("16b17360-e7a6-422e-80c8-708d922eb490");
                objectContext.AddToRawObjectList(viewModel._DrugOrderIntroduction, entryStateID);
                objectContext.ProcessRawObjects(false);

                var drugOrderIntroduction = (DrugOrderIntroduction)objectContext.GetLoadedObject(viewModel._DrugOrderIntroduction.ObjectID);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(drugOrderIntroduction, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugOrderIntroduction, formDefID);


                if (viewModel.OldDrugOrdersGridList != null)
                {
                    foreach (var item in viewModel.OldDrugOrdersGridList)
                    {
                        var oldDrugOrdersImported = (OldDrugOrder)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)oldDrugOrdersImported).IsDeleted)
                            continue;
                        oldDrugOrdersImported.DrugOrderIntroduction = drugOrderIntroduction;
                    }
                }

                if (viewModel.InpatientPrescriptions != null)
                {
                    foreach (var item in viewModel.InpatientPrescriptions)
                    {
                        var inpatientPrescriptionImported = (InpatientPrescription)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)inpatientPrescriptionImported).IsDeleted)
                            continue;
                        var inpatientPrescriptionsImported = (InpatientPrescription)objectContext.AddObject(item);
                        inpatientPrescriptionsImported.ProcedureDoctor = Common.CurrentUser.UserObject as ResUser;
                    }
                }

                if (viewModel.InpatientDrugOrders != null)
                {
                    foreach (var item in viewModel.InpatientDrugOrders)
                    {
                        var inpatientDrugOrderImported = (InpatientDrugOrder)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)inpatientDrugOrderImported).IsDeleted)
                            continue;
                        var inpatientDrugOrdersImported = (InpatientDrugOrder)objectContext.AddObject(item);
                    }
                }

                if (viewModel.InpatientPresDetailsGridList != null)
                {
                    foreach (var item in viewModel.InpatientPresDetailsGridList)
                    {
                        var inpatientPresDetailsImported = (InpatientPresDetail)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)inpatientPresDetailsImported).IsDeleted)
                            continue;
                        inpatientPresDetailsImported.DrugOrderIntroduction = drugOrderIntroduction;
                    }
                }

                if (viewModel.OutPatientPrescriptions != null)
                {
                    foreach (var item in viewModel.OutPatientPrescriptions)
                    {
                        var outPatientPrescriptionImported = (OutPatientPrescription)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)outPatientPrescriptionImported).IsDeleted)
                            continue;
                        var outPatientPrescriptionsImported = (OutPatientPrescription)objectContext.AddObject(item);
                        outPatientPrescriptionsImported.ProcedureDoctor = Common.CurrentUser.UserObject as ResUser;
                    }
                }

                if (viewModel.OutPatientDrugOrders != null)
                {
                    foreach (var item in viewModel.OutPatientDrugOrders)
                    {
                        var outPatientDrugOrderImported = (OutPatientDrugOrder)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)outPatientDrugOrderImported).IsDeleted)
                            continue;
                        var outPatientDrugOrdersImported = (OutPatientDrugOrder)objectContext.AddObject(item);
                    }
                }

                if (viewModel.OutpatientPresDetailsGridList != null)
                {
                    foreach (var item in viewModel.OutpatientPresDetailsGridList)
                    {
                        var outpatientPresDetailsImported = (OutpatientPresDetail)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)outpatientPresDetailsImported).IsDeleted)
                            continue;
                        outpatientPresDetailsImported.DrugOrderIntroduction = drugOrderIntroduction;
                    }
                }

                if (viewModel.DiagnosisForPrescriptionsGridList != null)
                {
                    foreach (var item in viewModel.DiagnosisForPrescriptionsGridList)
                    {
                        var diagnosisForPrescriptionsImported = (DiagnosisForPresc)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)diagnosisForPrescriptionsImported).IsDeleted)
                            continue;
                        diagnosisForPrescriptionsImported.DrugOrderIntroduction = drugOrderIntroduction;
                    }
                }

                if (viewModel.DrugOrders != null)
                {
                    foreach (var item in viewModel.DrugOrders)
                    {
                        var drugOrderImported = (DrugOrder)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)drugOrderImported).IsDeleted)
                            continue;
                        var drugOrderIsImported = (DrugOrder)objectContext.AddObject(item);
                    }
                }

                if (viewModel.DrugOrderIntroductionDetailsGridList != null)
                {
                    foreach (var item in viewModel.DrugOrderIntroductionDetailsGridList)
                    {
                        var drugOrderIntroductionDetailsImported = (DrugOrderIntroductionDet)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)drugOrderIntroductionDetailsImported).IsDeleted)
                            continue;
                        drugOrderIntroductionDetailsImported.DrugOrderIntroduction = drugOrderIntroduction;
                    }
                }

                foreach (var prescriptionDetailItem in drugOrderIntroduction.OutpatientPresDetails)
                {
                    var prescription = prescriptionDetailItem.OutPatientPrescription;
                    var signContent = Prescription.GetEReceteSignedInputRequest(prescription);
                    var prescriptionSignContent = new PrescriptionSignContent()
                    { PrescriptionObjectID = prescription.ObjectID, SignContent = signContent, OrderNo = 1 };
                    output.PrescriptionSignContentList.Add(prescriptionSignContent);
                }

                foreach (var prescriptionDetailItem in drugOrderIntroduction.InpatientPresDetails)
                {
                    var prescription = prescriptionDetailItem.InpatientPrescription;
                    var signContent = Prescription.GetEReceteSignedInputRequest(prescription);
                    var prescriptionSignContent = new PrescriptionSignContent()
                    { PrescriptionObjectID = prescription.ObjectID, SignContent = signContent, OrderNo = 1, };
                    output.PrescriptionSignContentList.Add(prescriptionSignContent);
                }
            }

            return output;
        }

        [HttpPost]
        public SignedPrescriptionOutput PrepareSignedApprovalPrescriptionContent(DrugOrderIntroductionNewFormViewModel viewModel)
        {
            SignedPrescriptionOutput output = new SignedPrescriptionOutput();
            output.PrescriptionSignContentList = new List<PrescriptionSignContent>();
            using (var objectContext = new TTObjectContext(false))
            {
                var drugOrderIntroduction = (DrugOrderIntroduction)objectContext.AddObject(viewModel._DrugOrderIntroduction);

                foreach (var prescriptionDetailItem in drugOrderIntroduction.InpatientPresDetails)
                {
                    var prescription = prescriptionDetailItem.InpatientPrescription;
                    var signApprovalContent = Prescription.GetEreceteSignedApprovalRequest(prescription);
                    var prescriptionApprovalSignContent = new PrescriptionSignContent()
                    { PrescriptionObjectID = prescription.ObjectID, SignContent = signApprovalContent, OrderNo = 2, };
                    output.PrescriptionSignContentList.Add(prescriptionApprovalSignContent);

                    var signDeleteContent = Prescription.GetEReceteSignedDeleteRequest(prescription);
                    var prescriptionDeleteSignContent = new PrescriptionSignContent()
                    { PrescriptionObjectID = prescription.ObjectID, SignContent = signDeleteContent, OrderNo = 3, };
                    output.PrescriptionSignContentList.Add(prescriptionDeleteSignContent);
                }
            }

            return output;
        }

        [HttpPost]
        public string PrepareSignedDeletePrescriptionContent(PrepareSignedDeletePrescriptionContent_Input input)
        {
            string output = string.Empty;

            var signDeleteContent = Prescription.GetEReceteSignedDeleteRequestEreceteNo(input.eReceteNo);
            output = signDeleteContent;
            return output;
        }

        [HttpPost]
        public string PrepareSignedDiagnosisPrescriptionContent(PrepareSignedDiagnosisPrescriptionContent_Input input)
        {
            string output = string.Empty;

            var signDeleteContent = Prescription.GetEReceteSignedDiagnosisRequestEreceteNo(input.eReceteNo, input.diagnosisObjID);
            output = signDeleteContent;
            return output;
        }

        [HttpPost]
        public string PrepareSignedRecipeDescriptionPrescriptionContent(PrepareSignedRecipeDescriptionPrescriptionContent_Input input)
        {
            string output = string.Empty;

            var signDeleteContent = Prescription.GetEReceteSignedRecipeDescriptionRequestEreceteNo(input.eReceteNo, input.drugDescriptionType, input.desciption);
            output = signDeleteContent;
            return output;
        }

        [HttpPost]
        public string PrepareSignedDrugDescriptionPrescriptionContent(PrepareSignedDrugDescriptionPrescriptionContent_Input input)
        {
            string output = string.Empty;

            var signDeleteContent = Prescription.GetEReceteSignedDrugDescriptionRequestEreceteNo(input.eReceteNo, input.drugDescriptionType, input.drugDesciption, input.barcode);
            output = signDeleteContent;
            return output;
        }


        [HttpPost]
        public void DrugOrderIntroductionNewForm(DrugOrderIntroductionNewFormViewModel viewModel)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("b71eaa1d-e6d0-437e-b9e3-63215104577f");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.ResSections);
                objectContext.AddToRawObjectList(viewModel.Stores);
                objectContext.AddToRawObjectList(viewModel.DrugOrders);
                objectContext.AddToRawObjectList(viewModel.DrugOrderDetails);
                objectContext.AddToRawObjectList(viewModel.Materials);
                objectContext.AddToRawObjectList(viewModel.InpatientPrescriptions);
                objectContext.AddToRawObjectList(viewModel.OutPatientPrescriptions);
                objectContext.AddToRawObjectList(viewModel.Episodes);
                objectContext.AddToRawObjectList(viewModel.Patients);
                objectContext.AddToRawObjectList(viewModel.OldDrugOrdersGridList);
                objectContext.AddToRawObjectList(viewModel.InpatientPresDetailsGridList);
                objectContext.AddToRawObjectList(viewModel.OutpatientPresDetailsGridList);
                objectContext.AddToRawObjectList(viewModel.DiagnosisForPrescriptionsGridList);
                objectContext.AddToRawObjectList(viewModel.DrugOrderIntroductionDetailsGridList);
                objectContext.AddToRawObjectList(viewModel.InpatientDrugOrders);
                objectContext.AddToRawObjectList(viewModel.OutPatientDrugOrders);
                objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);

                var entryStateID = Guid.Parse("16b17360-e7a6-422e-80c8-708d922eb490");

                objectContext.AddToRawObjectList(viewModel._DrugOrderIntroduction, entryStateID);
                objectContext.ProcessRawObjects(false);

                var drugOrderIntroduction = (DrugOrderIntroduction)objectContext.GetLoadedObject(viewModel._DrugOrderIntroduction.ObjectID);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(drugOrderIntroduction, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugOrderIntroduction, formDefID);

                int drugOrderTimeOffset = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("DRUGORDERTIMEOFFSET", "1"));
                DateTime today = DateTime.Now;
                foreach (DrugOrderDetail drugOrderDetail in viewModel.DrugOrderDetails)
                {
                    if (drugOrderDetail.OrderPlannedDate < today.AddHours(-drugOrderTimeOffset))
                        throw new TTException(drugOrderTimeOffset + " saat geçmişe yönelik order verebilirsiniz! Lütfen Order saatlerini güncelleyiniz!");
                }

                if (viewModel.OldDrugOrdersGridList != null)
                {
                    foreach (var item in viewModel.OldDrugOrdersGridList)
                    {
                        var oldDrugOrdersImported = (OldDrugOrder)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)oldDrugOrdersImported).IsDeleted)
                            continue;
                        oldDrugOrdersImported.DrugOrderIntroduction = drugOrderIntroduction;
                    }
                }

                if (viewModel.InpatientPrescriptions != null)
                {
                    foreach (var item in viewModel.InpatientPrescriptions)
                    {
                        var inpatientPrescriptionImported = (InpatientPrescription)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)inpatientPrescriptionImported).IsDeleted)
                            continue;
                        var inpatientPrescriptionsImported = (InpatientPrescription)objectContext.AddObject(item);
                        inpatientPrescriptionsImported.ProcedureDoctor = Common.CurrentUser.UserObject as ResUser;
                    }
                }

                if (viewModel.InpatientDrugOrders != null)
                {
                    foreach (var item in viewModel.InpatientDrugOrders)
                    {
                        var inpatientDrugOrderImported = (InpatientDrugOrder)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)inpatientDrugOrderImported).IsDeleted)
                            continue;
                        var inpatientDrugOrdersImported = (InpatientDrugOrder)objectContext.AddObject(item);
                    }
                }

                if (viewModel.InpatientPresDetailsGridList != null)
                {
                    foreach (var item in viewModel.InpatientPresDetailsGridList)
                    {
                        var inpatientPresDetailsImported = (InpatientPresDetail)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)inpatientPresDetailsImported).IsDeleted)
                            continue;
                        inpatientPresDetailsImported.DrugOrderIntroduction = drugOrderIntroduction;
                    }
                }

                if (viewModel.OutPatientPrescriptions != null)
                {
                    foreach (var item in viewModel.OutPatientPrescriptions)
                    {
                        var outPatientPrescriptionImported = (OutPatientPrescription)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)outPatientPrescriptionImported).IsDeleted)
                            continue;
                        var outPatientPrescriptionsImported = (OutPatientPrescription)objectContext.AddObject(item);
                        outPatientPrescriptionsImported.ProcedureDoctor = Common.CurrentUser.UserObject as ResUser;
                    }
                }

                if (viewModel.OutPatientDrugOrders != null)
                {
                    foreach (var item in viewModel.OutPatientDrugOrders)
                    {
                        var outPatientDrugOrderImported = (OutPatientDrugOrder)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)outPatientDrugOrderImported).IsDeleted)
                            continue;
                        var outPatientDrugOrdersImported = (OutPatientDrugOrder)objectContext.AddObject(item);
                    }
                }

                if (viewModel.OutpatientPresDetailsGridList != null)
                {
                    foreach (var item in viewModel.OutpatientPresDetailsGridList)
                    {
                        var outpatientPresDetailsImported = (OutpatientPresDetail)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)outpatientPresDetailsImported).IsDeleted)
                            continue;
                        outpatientPresDetailsImported.DrugOrderIntroduction = drugOrderIntroduction;
                    }
                }

                if (viewModel.DiagnosisForPrescriptionsGridList != null)
                {
                    foreach (var item in viewModel.DiagnosisForPrescriptionsGridList)
                    {
                        var diagnosisForPrescriptionsImported = (DiagnosisForPresc)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)diagnosisForPrescriptionsImported).IsDeleted)
                            continue;
                        diagnosisForPrescriptionsImported.DrugOrderIntroduction = drugOrderIntroduction;
                    }
                }

                if (viewModel.DrugOrders != null)
                {
                    foreach (var item in viewModel.DrugOrders)
                    {
                        var drugOrderImported = (DrugOrder)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)drugOrderImported).IsDeleted)
                            continue;

                        if (drugOrderImported.PatientOwnDrug.HasValue && drugOrderImported.PatientOwnDrug.Value)
                        {
                            foreach (DrugOrderDetail drugOrderDetail in drugOrderImported.DrugOrderDetails)
                            {
                                drugOrderDetail.Eligible = false;
                                drugOrderDetail.Update();
                                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                            }
                        }

                        bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderImported.Material);
                        if (drugType == false)
                        {
                            foreach (DrugOrderDetail drugOrderDetail in drugOrderImported.DrugOrderDetails)
                                drugOrderDetail.Eligible = false;
                        }
                    }
                }

                if (viewModel.DrugOrderIntroductionDetailsGridList != null)
                {
                    foreach (var item in viewModel.DrugOrderIntroductionDetailsGridList)
                    {
                        var drugOrderIntroductionDetailsImported = (DrugOrderIntroductionDet)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)drugOrderIntroductionDetailsImported).IsDeleted)
                            continue;
                        drugOrderIntroductionDetailsImported.DrugOrderIntroduction = drugOrderIntroduction;

                        if (item.DoseAmount != null)
                        {
                            string doseString = item.DoseAmount.ToString();
                            string[] parser = doseString.Split(',');
                            if (parser.Length > 1)
                            {
                                throw new Exception(TTUtils.CultureService.GetText("M25537", "Doz Miktarı tam sayı olamaz."));
                            }
                        }
                        else
                            throw new Exception(TTUtils.CultureService.GetText("M25536", "Doz Miktarı boş olamaz."));
                    }
                }

                var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(drugOrderIntroduction);


                if (transDef != null)
                {
                    string eReceteEntg = TTObjectClasses.SystemParameter.GetParameterValue("ERECETEENTEGRASYON", "TRUE");

                    if (eReceteEntg == "TRUE")
                        SendSignedERecete(drugOrderIntroduction, viewModel.PrescriptionSignContentList);
                }


                if (TTObjectClasses.SystemParameter.GetParameterValue("HIMSSINTEGRATED", "FALSE") == "TRUE")
                {
                    if (drugOrderIntroduction.MasterResource != null && drugOrderIntroduction.MasterResource.HimssRequired != null)
                    {
                        if (drugOrderIntroduction.MasterResource.HimssRequired == true)
                        {
                            foreach (DrugOrderIntroductionDet detail in drugOrderIntroduction.DrugOrderIntroductionDetails)
                            {
                                if (DateTime.Now > ((DateTime)detail.PlannedStartTime).AddMinutes(1))
                                {
                                    throw new Exception(detail.Material.Name + " ilaç uygulama zamanı geçmiş tarih olamaz");
                                }

                                if (detail.PatientOwnDrug != null && detail.PatientOwnDrug == true)
                                {
                                    double amount = 0;
                                    foreach (DrugOrderDetail drugOrderDetail in detail.DrugOrder.DrugOrderDetails.Select(string.Empty))
                                    {
                                        DrugOrderDetail orderDetail = (DrugOrderDetail)objectContext.GetObject((Guid)drugOrderDetail.ObjectID, typeof(DrugOrderDetail));
                                        if (orderDetail.Amount != null)
                                        {
                                            if (DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material))
                                                amount += (double)orderDetail.Amount.Value;
                                            else
                                                amount += (double)orderDetail.Amount.Value * (double)((DrugDefinition)drugOrderDetail.Material).Dose;
                                        }
                                    }
                                    BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> trxList = PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(drugOrderIntroduction.Episode.ObjectID, detail.Material.ObjectID);
                                    if (trxList.Count > 0)
                                    {
                                        double resAmount = 0;
                                        foreach (PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class trx in trxList)
                                            resAmount = resAmount + Double.Parse(trx.Restamount.ToString());

                                        if (DrugOrder.GetDrugUsedType((DrugDefinition)detail.Material) == false)
                                            resAmount = resAmount * (double)((DrugDefinition)detail.Material).Volume;

                                        if (resAmount < amount)
                                        {
                                            throw new TTException(detail.DrugOrder.Material.Name + " isimli malzemenin mevcudu yetersizdir.");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                PostScript_DrugOrderIntroductionNewForm(viewModel, drugOrderIntroduction, transDef, objectContext);
                objectContext.AdvanceStateForNewObjects();
                retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
                objectContext.Save();
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(drugOrderIntroduction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(drugOrderIntroduction);
                AfterContextSaveScript_DrugOrderIntroductionNewForm(viewModel, drugOrderIntroduction, transDef, objectContext);
                retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
                retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
                objectContext.FullPartialllyLoadedObjects();

                drugOrderIntroduction.DrugOrderIntroductionDetails.Where(d => d.DrugOrder.DrugOrderDetails.Count > 0).ToList();

                //drugOrderIntroduction.DrugOrderIntroductionDetails.Where(f => f.CaseOfNeed != true).Where(e => e.PatientOwnDrug != true).Where(d => d.DrugOrder.DrugOrderDetails.Count > 0).ToList();
                if (drugOrderIntroduction.ActiveInPatientPhysicianApp != null)
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("DAILYDRUGSCHORDERBYPASS", "FALSE") == "TRUE")
                    {
                        bool createKS = CreatedNewKschorderByDrugOrderIntroduction(drugOrderIntroduction);
                    }
                }


                TTObjectContext context = new TTObjectContext(false);
                if ((bool)drugOrderIntroduction.IsTemplate.HasValue && (bool)drugOrderIntroduction.IsTemplate)
                {
                    UserTemplate userTemplate = new UserTemplate(context);
                    userTemplate.ResUser = (ResUser)Common.CurrentResource;
                    userTemplate.Description = drugOrderIntroduction.TemplateDescription;
                    userTemplate.TAObjectID = drugOrderIntroduction.ObjectID;
                    userTemplate.TAObjectDefID = drugOrderIntroduction.ObjectDef.ID;
                    userTemplate.FiliterData = "DrugOrderIntroduction";
                }

                foreach (DrugOrderIntroductionDet det in drugOrderIntroduction.DrugOrderIntroductionDetails)
                {
                    BindingList<FavoriteDrug.GetFavoriteDrugWithDrugID_Class> favs = FavoriteDrug.GetFavoriteDrugWithDrugID(((ResUser)Common.CurrentUser.UserObject).ObjectID, det.Material.ObjectID);
                    if (favs.Count > 0)
                    {
                        FavoriteDrug existFav = (FavoriteDrug)context.GetObject((Guid)favs[0].ObjectID, "FAVORITEDRUG");
                        existFav.Count = existFav.Count + 1;
                    }
                    else
                    {
                        FavoriteDrug newFavoriteDrug = new FavoriteDrug(context);
                        newFavoriteDrug.Count = 1;
                        newFavoriteDrug.DrugDefinition = ((DrugDefinition)det.Material);
                        newFavoriteDrug.ResUser = ((ResUser)Common.CurrentUser.UserObject);
                    }
                }

                context.Save();
            }
        }

        public bool CreatedNewKschorderByDrugOrderIntroduction(DrugOrderIntroduction drugOrderIntroduction)
        {
            try
            {
                bool returnResult = false;
                TTObjectContext contextKshedule = new TTObjectContext(false);
                InPatientPhysicianApplication inPatientApp = drugOrderIntroduction.ActiveInPatientPhysicianApp;
                KSchedule kScheduleNew = new KSchedule(contextKshedule);
                kScheduleNew.StartDate = drugOrderIntroduction.ActionDate;
                //kScheduleNew.EndDate = dailyDrugSchedule.EndDate;
                Store pharmacy = Store.GetPharmacyStore(contextKshedule);
                if (pharmacy != null)
                {
                    kScheduleNew.Store = pharmacy;
                }
                kScheduleNew.DestinationStore = drugOrderIntroduction.MasterResource.Store;
                kScheduleNew.Episode = drugOrderIntroduction.Episode;
                kScheduleNew.InPatientPhysicianApplication = inPatientApp;
                kScheduleNew.MKYS_TeslimAlanObjID = Common.CurrentUser.UserObject.ObjectID;
                kScheduleNew.MKYS_TeslimAlan = ((ResUser)Common.CurrentUser.UserObject).Name;

                foreach (DrugOrderIntroductionDet det in drugOrderIntroduction.DrugOrderIntroductionDetails)
                {
                    DrugOrder order = det.DrugOrder;
                    if (det.CaseOfNeed == true)
                        continue;

                    if (det.PatientOwnDrug != null && det.PatientOwnDrug == true)
                    {
                        double amount = 0;
                        KSchedulePatienOwnDrug kSchedulePatienOwnDrug = new KSchedulePatienOwnDrug(contextKshedule);
                        foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                        {
                            DrugOrderDetail drugOrderDetail = (DrugOrderDetail)contextKshedule.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                            kSchedulePatienOwnDrug.DrugOrderDetails.Add(drugOrderDetail);
                            if (drugOrderDetail.Amount != null)
                                amount += (double)drugOrderDetail.Amount.Value;
                        }
                        if (DrugOrder.GetDrugUsedType((DrugDefinition)order.Material))
                            kSchedulePatienOwnDrug.DrugAmount = amount;
                        else
                            kSchedulePatienOwnDrug.DrugAmount = 1;
                        kSchedulePatienOwnDrug.Material = order.Material;
                        kSchedulePatienOwnDrug.BarcodeVerifyCounter = 0;
                        kSchedulePatienOwnDrug.KSchedule = kScheduleNew;
                        kSchedulePatienOwnDrug.StockActionStatus = StockActionDetailStatusEnum.New;


                        BindingList<PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode_Class> trxList = PatientOwnDrugTrx.GetRestPatientOwnDrugByMaterialAndEpisode(drugOrderIntroduction.Episode.ObjectID, order.Material.ObjectID);
                        if (trxList.Count > 0)
                        {
                            if (trxList[0].ExpirationDate != null)
                                kSchedulePatienOwnDrug.ExpirationDate = trxList[0].ExpirationDate;
                            else
                                kSchedulePatienOwnDrug.ExpirationDate = DateTime.MinValue;
                        }

                        if (kSchedulePatienOwnDrug.ExpirationDate == null)
                            kSchedulePatienOwnDrug.ExpirationDate = DateTime.MinValue;
                    }

                    else
                    {
                        if (order.DrugOrderDetails.Count > 0)
                        {
                            double restDose = 0;
                            Dictionary<object, double> rests = DrugOrderTransaction.GetPatientRestDose(order.Material, order.Episode);
                            List<DrugOrderDetail> unListDetails = new List<DrugOrderDetail>();
                            foreach (KeyValuePair<object, double> rest in rests)
                            {
                                restDose = restDose + rest.Value;
                            }

                            KScheduleMaterial ksmaterial = null;
                            DrugDefinition drugDefinition = (DrugDefinition)order.Material;
                            bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                            double amount = 0;
                            foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                            {
                                DrugOrderDetail drugOrderDetail = (DrugOrderDetail)contextKshedule.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                                if (drugType)
                                    amount += (double)drugOrderDetail.Amount;
                                else
                                    amount += (double)drugOrderDetail.DoseAmount;
                            }

                            if (restDose == 0)
                            {
                                ksmaterial = new KScheduleMaterial(contextKshedule);
                                ksmaterial.Material = order.Material;
                                ksmaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                                ksmaterial.IsImmediate = order.IsImmediate;
                                ksmaterial.BarcodeVerifyCounter = 0;
                                ksmaterial.UsageNote = det.UsageNote;

                                if (drugType)
                                {
                                    ksmaterial.RequestAmount = amount;
                                    ksmaterial.Amount = amount;

                                }
                                else
                                {
                                    double rAmount = ((double)amount) / ((double)drugDefinition.Volume);
                                    ksmaterial.Amount = Math.Ceiling(rAmount);
                                    ksmaterial.RequestAmount = Math.Ceiling(rAmount);
                                }
                            }

                            if (restDose > 0 && restDose < amount)
                            {
                                double rAmount = (double)amount - restDose;
                                foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                                {
                                    DrugOrderDetail drugOrderDetail = (DrugOrderDetail)contextKshedule.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                                    if (rAmount >= detail.Amount)
                                    {
                                        if (drugType)
                                            rAmount -= (double)drugOrderDetail.Amount;
                                        else
                                            rAmount -= (double)drugOrderDetail.DoseAmount;

                                        unListDetails.Add(drugOrderDetail);
                                    }
                                }
                                ksmaterial = new KScheduleMaterial(contextKshedule);
                                ksmaterial.Material = order.Material;
                                ksmaterial.IsImmediate = order.IsImmediate;
                                ksmaterial.BarcodeVerifyCounter = 0;
                                ksmaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                                ksmaterial.UsageNote = det.UsageNote;

                                if (drugType)
                                {

                                    ksmaterial.RequestAmount = rAmount;
                                    ksmaterial.Amount = rAmount;

                                }
                                else
                                {
                                    double rAmountNew = ((double)rAmount) / ((double)drugDefinition.Volume);
                                    ksmaterial.Amount = Math.Ceiling(rAmountNew);
                                    ksmaterial.RequestAmount = Math.Ceiling(rAmountNew);
                                }

                            }

                            if (restDose > 0 && restDose >= amount)
                            {
                                foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                                {
                                    DrugOrderDetail drugOrderDetail = (DrugOrderDetail)contextKshedule.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                                    unListDetails.Add(drugOrderDetail);
                                    drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                                }
                            }

                            if (unListDetails.Count > 0)
                            {
                                KScheduleUnListMaterial unListMaterial = new KScheduleUnListMaterial(contextKshedule);

                                unListMaterial.UnlistDrug = order.Material.Name;
                                if (drugType)
                                {
                                    unListMaterial.UnlistAmount = restDose;
                                    unListMaterial.UnlistVolume = restDose * ((DrugDefinition)order.Material).Volume;
                                }
                                else
                                {
                                    unListMaterial.UnlistAmount = restDose / ((DrugDefinition)order.Material).Volume;
                                    unListMaterial.UnlistVolume = restDose;
                                }

                                foreach (DrugOrderDetail detail in order.DrugOrderDetails)
                                {
                                    DrugOrderDetail drugOrderDetail = (DrugOrderDetail)contextKshedule.GetObject((Guid)detail.ObjectID, typeof(DrugOrderDetail));
                                    unListMaterial.DrugOrderDetails.Add(drugOrderDetail);
                                }

                                kScheduleNew.KScheduleUnListMaterials.Add(unListMaterial);
                            }

                            if (ksmaterial != null)
                            {
                                KScheduleCollectedOrder kScheduleCollectedOrder = new KScheduleCollectedOrder(contextKshedule);
                                foreach (DrugOrderDetail detail in order.DrugOrderDetails.Select(string.Empty))
                                {
                                    DrugOrderDetail updateDetail = (DrugOrderDetail)contextKshedule.GetObject(detail.ObjectID, typeof(DrugOrderDetail));
                                    updateDetail.KScheduleCollectedOrder = null;
                                    kScheduleCollectedOrder.DrugOrderDetails.Add(updateDetail);
                                    detail.CurrentStateDefID = DrugOrderDetail.States.Request;
                                }
                                ksmaterial.KScheduleCollectedOrder = kScheduleCollectedOrder;

                                kScheduleNew.KScheduleMaterials.Add(ksmaterial);
                            }

                        }
                    }
                }

                kScheduleNew.CurrentStateDefID = KSchedule.States.New;
                kScheduleNew.Update();
                kScheduleNew.CurrentStateDefID = KSchedule.States.Approval;
                kScheduleNew.Update();
                kScheduleNew.CurrentStateDefID = KSchedule.States.RequestPreparation;

                if (kScheduleNew.KScheduleMaterials.Count != 0 || kScheduleNew.KSchedulePatienOwnDrugs.Count != 0)
                {
                    contextKshedule.Save();
                }
                else
                {
                    TTObjectContext objectContextUnDrug = new TTObjectContext(false);
                    foreach (KScheduleUnListMaterial unMaterial in kScheduleNew.KScheduleUnListMaterials)
                    {
                        foreach (DrugOrderDetail usedDetail in unMaterial.DrugOrderDetails.Select(string.Empty))
                        {

                            var usedDrug = objectContextUnDrug.GetObject(usedDetail.ObjectID, typeof(DrugOrderDetail));
                            usedDrug.CurrentStateDefID = DrugOrderDetail.States.UseRestDose;
                        }
                    }
                    objectContextUnDrug.Save();
                }

                contextKshedule.Dispose();
                returnResult = true;
                return returnResult;
            }
            catch (Exception e)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26248", "K Çizelgesi Oluşturulamadı."));
            }
        }

        public void SendSignedERecete(Prescription prescription)
        {
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            bool error = false;
            if (prescription.SubEpisode.IsSGK)
            {
                TTObjectClasses.EReceteIslemleri.imzaliEreceteGirisIstekDVO istekImzali = new TTObjectClasses.EReceteIslemleri.imzaliEreceteGirisIstekDVO();
                istekImzali.doktorTcKimlikNo = Convert.ToInt64(currentUser.UniqueNo);
                istekImzali.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                istekImzali.imzaliErecete = prescription.SignedData as byte[];
                istekImzali.surumNumarasi = 1;
                string errorMsg = string.Empty;

                EReceteIslemleri.imzaliEreceteGirisCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteGirisSync(Sites.SiteLocalHost, Common.CurrentResource.UniqueNo.ToString(), currentUser.ErecetePassword, istekImzali);
                if (response != null)
                {

                    if (response.sonucKodu.Equals("0000"))
                    {
                        prescription.EReceteNo = response.ereceteDVO.ereceteNo;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(response.uyariMesaji))
                        {
                            prescription.EReceteDescription = "e - Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı: " + response.uyariMesaji;
                            errorMsg = "e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :") + response.uyariMesaji;
                            error = true;
                        }
                        else
                        {
                            error = true;
                            errorMsg = "e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji;
                            prescription.EReceteDescription = "e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji;
                        }
                    }
                }

                if (error)
                    throw new TTException(errorMsg);
            }
        }

        public bool SendSignedApprovalERecete(Prescription prescription, byte[] signedContent)
        {
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            bool error = false;
            if (prescription.SubEpisode.IsSGK)
            {
                EReceteIslemleri.imzaliEreceteOnayIstekDVO eReceteSignedApprovalRequest = new EReceteIslemleri.imzaliEreceteOnayIstekDVO();
                long drKimlikNo = Convert.ToInt64(currentUser.UniqueNo);
                long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                eReceteSignedApprovalRequest.doktorTcKimlikNo = drKimlikNo.ToString();
                eReceteSignedApprovalRequest.tesisKodu = saglikTesisKodu.ToString();
                eReceteSignedApprovalRequest.imzaliEreceteOnay = signedContent;
                eReceteSignedApprovalRequest.surumNumarasi = "1";

                EReceteIslemleri.imzaliEreceteOnayCevapDVO resOnay = EReceteIslemleri.WebMethods.imzaliEreceteOnaySync(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), currentUser.ErecetePassword, eReceteSignedApprovalRequest);
                if (resOnay != null)
                {
                    if (resOnay.sonucKodu.Equals("0000"))
                        InfoMessageService.Instance.ShowMessage(prescription.EReceteNo.ToString() + " e reçete numarası ile reçete kaydedilmiştir.");
                    else
                    {
                        if (!string.IsNullOrEmpty(resOnay.uyariMesaji))
                        {
                            InfoMessageService.Instance.ShowMessage("e-Reçete Servisinden Gelen Sonuç Mesajı : " + resOnay.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :") + resOnay.uyariMesaji);
                            error = true;
                        }
                        else
                        {
                            InfoMessageService.Instance.ShowMessage("e-Reçete Servisinden Gelen Sonuç Mesajı : " + resOnay.sonucMesaji);
                            error = true;
                        }
                    }
                    //if (error)
                    //    throw new TTException("Bazı reçetelerınizde e reçeteye yollanırken hata alınmıştır. Tekrar kontrol ediniz");
                }
            }
            return error;
        }

        public bool SendSignedDeleteERecete(Prescription prescription, byte[] signedContent)
        {
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            bool error = false;
            if (string.IsNullOrEmpty(prescription.EReceteNo) == false)
            {
                EReceteIslemleri.imzaliEreceteSilIstekDVO eReceteSignedDeleteRequest = new EReceteIslemleri.imzaliEreceteSilIstekDVO();
                long drKimlikNo = Convert.ToInt64(currentUser.UniqueNo);
                long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                eReceteSignedDeleteRequest.doktorTcKimlikNo = drKimlikNo.ToString();
                eReceteSignedDeleteRequest.tesisKodu = saglikTesisKodu.ToString();
                eReceteSignedDeleteRequest.imzaliEreceteSil = signedContent;
                eReceteSignedDeleteRequest.surumNumarasi = "1";

                EReceteIslemleri.imzaliEreceteSilCevapDVO resOnay = EReceteIslemleri.WebMethods.imzaliEreceteSilSync(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), currentUser.ErecetePassword, eReceteSignedDeleteRequest);
                if (resOnay != null)
                {
                    if (resOnay.sonucKodu.Equals("0000"))
                        error = true;
                }
            }
            return error;
        }

        public bool SendSignedDeleteEReceteWithEReceteNo(byte[] signedContent)
        {
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            bool error = false;

            EReceteIslemleri.imzaliEreceteSilIstekDVO eReceteSignedDeleteRequest = new EReceteIslemleri.imzaliEreceteSilIstekDVO();
            long drKimlikNo = Convert.ToInt64(currentUser.UniqueNo);
            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            eReceteSignedDeleteRequest.doktorTcKimlikNo = drKimlikNo.ToString();
            eReceteSignedDeleteRequest.tesisKodu = saglikTesisKodu.ToString();
            eReceteSignedDeleteRequest.imzaliEreceteSil = signedContent;
            eReceteSignedDeleteRequest.surumNumarasi = "1";

            EReceteIslemleri.imzaliEreceteSilCevapDVO resOnay = EReceteIslemleri.WebMethods.imzaliEreceteSilSync(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), currentUser.ErecetePassword, eReceteSignedDeleteRequest);
            if (resOnay != null)
            {
                if (resOnay.sonucKodu.Equals("0000"))
                    error = true;
            }

            return error;
        }

        public bool SendSignedDiagnosisEReceteWithEReceteNo(byte[] signedContent)
        {
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            bool error = false;

            EReceteIslemleri.imzaliEreceteTaniEkleIstekDVO imzaliEreceteTaniEkleIstekDVO = new EReceteIslemleri.imzaliEreceteTaniEkleIstekDVO();
            long drKimlikNo = Convert.ToInt64(currentUser.UniqueNo);
            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            imzaliEreceteTaniEkleIstekDVO.doktorTcKimlikNo = drKimlikNo.ToString();
            imzaliEreceteTaniEkleIstekDVO.tesisKodu = saglikTesisKodu.ToString();
            imzaliEreceteTaniEkleIstekDVO.imzaliEreceteTani = signedContent;
            imzaliEreceteTaniEkleIstekDVO.surumNumarasi = "1";

            EReceteIslemleri.imzaliEreceteTaniEkleCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteTaniEkleSync(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), currentUser.ErecetePassword, imzaliEreceteTaniEkleIstekDVO);
            if (response != null)
            {
                if (response.sonucKodu.Equals("0000"))
                {
                    error = true;
                }
            }
            return error;
        }

        public bool SendSignedDrugDescriptionEReceteWithEReceteNo(byte[] signedContent)
        {
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            bool error = false;

            EReceteIslemleri.imzaliEreceteIlacAciklamaEkleIstekDVO imzaliEreceteIlacAciklamaEkleIstekDVO = new EReceteIslemleri.imzaliEreceteIlacAciklamaEkleIstekDVO();
            long drKimlikNo = Convert.ToInt64(currentUser.UniqueNo);
            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            imzaliEreceteIlacAciklamaEkleIstekDVO.doktorTcKimlikNo = drKimlikNo.ToString();
            imzaliEreceteIlacAciklamaEkleIstekDVO.imzaliEreceteIlacAciklama = signedContent;
            imzaliEreceteIlacAciklamaEkleIstekDVO.surumNumarasi = "1";
            imzaliEreceteIlacAciklamaEkleIstekDVO.tesisKodu = saglikTesisKodu.ToString();

            EReceteIslemleri.imzaliEreceteIlacAciklamaEkleCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteIlacAciklamaEkleSync(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), currentUser.ErecetePassword, imzaliEreceteIlacAciklamaEkleIstekDVO);
            if (response != null)
            {
                if (response.sonucKodu.Equals("0000"))
                {
                    error = true;
                }
            }

            return error;
        }

        public bool SendSignedRecipeDescriptionEReceteWithEReceteNo(byte[] signedContent)
        {
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            bool error = false;

            EReceteIslemleri.imzaliEreceteAciklamaEkleIstekDVO imzaliEreceteAciklamaEkleIstekDVO = new EReceteIslemleri.imzaliEreceteAciklamaEkleIstekDVO();
            long drKimlikNo = Convert.ToInt64(currentUser.UniqueNo);
            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            imzaliEreceteAciklamaEkleIstekDVO.doktorTcKimlikNo = drKimlikNo.ToString();
            imzaliEreceteAciklamaEkleIstekDVO.tesisKodu = saglikTesisKodu.ToString();
            imzaliEreceteAciklamaEkleIstekDVO.imzaliEreceteAciklama = signedContent;
            imzaliEreceteAciklamaEkleIstekDVO.surumNumarasi = "1";

            EReceteIslemleri.imzaliEreceteAciklamaEkleCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteAciklamaEkleSync(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), currentUser.ErecetePassword, imzaliEreceteAciklamaEkleIstekDVO);
            if (response != null)
            {
                if (response.sonucKodu.Equals("0000"))
                {
                    error = true;
                }
            }

            return error;
        }

        private void SendSignedERecete(DrugOrderIntroduction drugOrderIntroduction, List<PrescriptionSignContent> prescriptionSignContentList)
        {
            foreach (var inPatientPrescriptionItem in drugOrderIntroduction.InpatientPresDetails)
            {
                var prescription = inPatientPrescriptionItem.InpatientPrescription;
                var query =
                    from s in prescriptionSignContentList
                    where s.PrescriptionObjectID == prescription.ObjectID
                    orderby s.OrderNo
                    select s;
                foreach (var signedContentTuple in query)
                {
                    prescription.IsSigned = true;
                    var signedData = Convert.FromBase64String(signedContentTuple.SignContent);
                    if (signedContentTuple.OrderNo == 1)
                    {
                        prescription.SignedData = signedData;
                        SendSignedERecete(prescription);
                    }
                }
            }

            foreach (var outpatientPrescriptionItem in drugOrderIntroduction.OutpatientPresDetails)
            {
                var prescription = outpatientPrescriptionItem.OutPatientPrescription;
                var query =
                    from s in prescriptionSignContentList
                    where s.PrescriptionObjectID == prescription.ObjectID
                    orderby s.OrderNo
                    select s;
                if (query.Any())
                {
                    var signedContentTuple = query.FirstOrDefault();
                    prescription.IsSigned = true;
                    var signedData = Convert.FromBase64String(signedContentTuple.SignContent);
                    prescription.SignedData = signedData;
                    SendSignedERecete(prescription);
                }
            }
        }

        [HttpPost]
        public void SendSignedApprovalPrescriptionContent(DrugOrderIntroductionNewFormViewModel viewModel)
        {
            bool error = false;
            using (var objectContext = new TTObjectContext(false))
            {
                var drugOrderIntroduction = (DrugOrderIntroduction)objectContext.AddObject(viewModel._DrugOrderIntroduction);
                List<PrescriptionSignContent> prescriptionSignContentList = viewModel.PrescriptionSignContentList;
                foreach (var inPatientPrescriptionItem in drugOrderIntroduction.InpatientPresDetails)
                {
                    var prescription = inPatientPrescriptionItem.InpatientPrescription;
                    var query =
                        from s in prescriptionSignContentList
                        where s.PrescriptionObjectID == prescription.ObjectID
                        orderby s.OrderNo
                        select s;
                    foreach (var signedContentTuple in query)
                    {
                        var signedData = Convert.FromBase64String(signedContentTuple.SignContent);
                        if (signedContentTuple.OrderNo == 2)
                        {
                            error = SendSignedApprovalERecete(prescription, signedData);
                        }
                        else if (signedContentTuple.OrderNo == 3)
                        {
                            if (error)
                            {
                                SendSignedDeleteERecete(prescription, signedData);
                            }
                        }
                    }
                }
            }
        }

        [HttpPost]
        public bool SendSignedDeletePrescriptionContent(SendSignedDeletePrescriptionContent_Input input)
        {
            var signedData = Convert.FromBase64String(input.singContent);
            bool output = SendSignedDeleteEReceteWithEReceteNo(signedData);
            return output;
        }

        [HttpPost]
        public bool SendSignedDiagnosisPrescriptionContent(SendSignedDiagnosisPrescriptionContent_Input input)
        {
            var signedData = Convert.FromBase64String(input.singContent);
            bool output = SendSignedDiagnosisEReceteWithEReceteNo(signedData);
            return output;
        }

        [HttpPost]
        public bool SendSignedDrugDescriptionPrescriptionContent(SendSignedDrugDescriptionPrescriptionContent_Input input)
        {
            var signedData = Convert.FromBase64String(input.singContent);
            bool output = SendSignedDrugDescriptionEReceteWithEReceteNo(signedData);
            return output;
        }
    }
}

namespace Core.Models
{
    public class PrescriptionSignContent
    {
        public Guid PrescriptionObjectID
        {
            get;
            set;
        }

        public string SignContent
        {
            get;
            set;
        }
        public int OrderNo
        {
            get;
            set;
        }
    }

    public class PrepareSignedDeletePrescriptionContent_Input
    {
        public string eReceteNo
        {
            get;
            set;
        }

    }

    public class PrepareSignedDiagnosisPrescriptionContent_Input
    {
        public string eReceteNo
        {
            get;
            set;
        }
        public Guid diagnosisObjID
        {
            get;
            set;
        }

    }

    public class PrepareSignedRecipeDescriptionPrescriptionContent_Input
    {
        public string eReceteNo
        {
            get;
            set;
        }
        public int drugDescriptionType
        {
            get;
            set;
        }
        public string desciption
        {
            get;
            set;
        }

    }

    public class PrepareSignedDrugDescriptionPrescriptionContent_Input
    {
        public string eReceteNo
        {
            get;
            set;
        }

        public string drugDesciption
        {
            get;
            set;
        }
        public string barcode
        {
            get;
            set;
        }
        public int drugDescriptionType
        {
            get;
            set;
        }

    }
    public class DrugOrderObjectModel
    {
        public DrugOrder drugOrder
        {
            get;
            set;
        }
        public Material material
        {
            get;
            set;
        }
    }

    public class SendSignedDeletePrescriptionContent_Input
    {
        public string singContent
        {
            get;
            set;
        }

    }

    public class SendSignedDiagnosisPrescriptionContent_Input
    {
        public string singContent
        {
            get;
            set;
        }

    }


    public class SendSignedRecipeDescriptionPrescriptionContent_Input
    {
        public string singContent
        {
            get;
            set;
        }

    }

    public class SendSignedDrugDescriptionPrescriptionContent_Input
    {
        public string singContent
        {
            get;
            set;
        }

    }

    public class SignedPrescriptionOutput
    {
        public List<PrescriptionSignContent> PrescriptionSignContentList
        {
            get;
            set;
        }
    }

    public class DrugOrderIntroductionNewFormViewModel : BaseViewModel
    {
        public List<DrugOrderDetail> DrugOrderDetails { get; set; }
        public TTObjectClasses.DrugOrderIntroduction _DrugOrderIntroduction
        {
            get;
            set;
        }

        public TTObjectClasses.OldDrugOrder[] OldDrugOrdersGridList
        {
            get;
            set;
        }

        public TTObjectClasses.InpatientPresDetail[] InpatientPresDetailsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.OutpatientPresDetail[] OutpatientPresDetailsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisForPresc[] DiagnosisForPrescriptionsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DrugOrderIntroductionDet[] DrugOrderIntroductionDetailsGridList
        {
            get;
            set;
        }
        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList
        {
            get;
            set;
        }
        public TTObjectClasses.ResSection[] ResSections
        {
            get;
            set;
        }

        public TTObjectClasses.Store[] Stores
        {
            get;
            set;
        }

        public TTObjectClasses.DrugOrder[] DrugOrders
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.InpatientPrescription[] InpatientPrescriptions
        {
            get;
            set;
        }

        public TTObjectClasses.OutPatientPrescription[] OutPatientPrescriptions
        {
            get;
            set;
        }

        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }

        public TTObjectClasses.Patient[] Patients
        {
            get;
            set;
        }

        public InpatientDrugOrder[] InpatientDrugOrders
        {
            get;
            set;
        }

        public OutPatientDrugOrder[] OutPatientDrugOrders
        {
            get;
            set;
        }

        public List<PrescriptionSignContent> PrescriptionSignContentList
        {
            get;
            set;
        }
        public List<DiagnosisDefinitionList> DiagnosisDefinitionList
        {
            get;
            set;
        }
        public TTObjectClasses.SubEpisode[] SubEpisodes
        {
            get;
            set;
        }
    }

    public class DiagnosisDefinitionList
    {
        public string DiagnosisName
        {
            get;
            set;
        }
        public Guid DiagnosisObjID
        {
            get;
            set;
        }
    }

}