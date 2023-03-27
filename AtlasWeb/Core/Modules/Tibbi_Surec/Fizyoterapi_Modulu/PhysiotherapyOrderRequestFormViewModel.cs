//$928BEC77
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
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Text;

namespace Core.Controllers
{
    public partial class PhysiotherapyOrderServiceController
    {
        partial void PreScript_PhysiotherapyOrderRequestForm(PhysiotherapyOrderRequestFormViewModel viewModel, PhysiotherapyOrder physiotherapyOrder, TTObjectContext objectContext)
        {
            Guid? activeEpisodeObjectID = viewModel.GetSelectedEpisodeActionID();

            if (physiotherapyOrder.PhysiotherapyReports == null)//Rapor baþlatýldý
            {
                physiotherapyOrder.PhysiotherapyReports = new PhysiotherapyReports(objectContext);
            }

            if (viewModel._physiotherapyRequestObj != null)
            {
                PhysiotherapyRequest _physiotherapyRequestObj = objectContext.GetObject<PhysiotherapyRequest>(viewModel._physiotherapyRequestObj.ObjectID);
                physiotherapyOrder.PhysiotherapyRequest = _physiotherapyRequestObj;

                viewModel._PhysiotherapyOrder.SetMandatoryEpisodeActionProperties(_physiotherapyRequestObj, _physiotherapyRequestObj.MasterResource, true);
            }

            if (physiotherapyOrder.PhysiotherapyRequest != null && physiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrders != null && physiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrders.FirstOrDefault().PhysiotherapyReports != null)//Son girilen order'ýn raporu default olarak set edildi
            {
                physiotherapyOrder.PhysiotherapyReports = physiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrders.FirstOrDefault().PhysiotherapyReports;
            }

            if (physiotherapyOrder.PhysiotherapyReports != null && physiotherapyOrder.PhysiotherapyReports.FTRApplicationAreaDef != null && physiotherapyOrder.FTRApplicationAreaDef == null)
            {
                physiotherapyOrder.FTRApplicationAreaDef = physiotherapyOrder.PhysiotherapyReports.FTRApplicationAreaDef;//Rapordan gelen vücut bölgesi default olarak set edildi
            }


            viewModel.TreatmentDiagnosisInfoList = new List<TreatmentDiagnosisInfo>();
            var _treatmentDiagnosisInfoList = PhysiotherapyTreatmentUnitGrid.GetTreatmentDiagnosisInfo();
            foreach (var item in _treatmentDiagnosisInfoList.GroupBy(x => x.Treatmentdiagnosisunitid))
            {
                var selectedTreatmentDiagnosis = _treatmentDiagnosisInfoList.Where(c => c.Treatmentdiagnosisunitid == item.Key);

                List<ProcedureDefinitionList> ProcedureObjectDataSourceList = new List<ProcedureDefinitionList>();
                foreach (var item2 in selectedTreatmentDiagnosis)
                {
                    ProcedureDefinition _procedureDefinition = objectContext.GetObject<ProcedureDefinition>(item2.Physiotherapydefinitionid.Value);
                    ProcedureDefinitionList _procedureDefinitionList = new ProcedureDefinitionList
                    {
                        ProcedureDefinition = _procedureDefinition,
                        ProcedureDefinitionName = _procedureDefinition.Name,
                        isRequested = false
                    };
                    ProcedureObjectDataSourceList.Add(_procedureDefinitionList);
                }
                ResTreatmentDiagnosisUnit _ResTreatmentDiagnosisUnit = objectContext.GetObject<ResTreatmentDiagnosisUnit>(selectedTreatmentDiagnosis.FirstOrDefault().Treatmentdiagnosisunitid.Value);
                TreatmentDiagnosisInfo _TreatmentDiagnosisInfo = new TreatmentDiagnosisInfo
                {
                    ProcedureDefinitionList = ProcedureObjectDataSourceList,
                    TreatmentDiagnosisUnit = _ResTreatmentDiagnosisUnit,
                    TreatmentDiagnosisUnitName = _ResTreatmentDiagnosisUnit.Name,
                    TreatmentDiagnosisUnitId = _ResTreatmentDiagnosisUnit.ObjectID
                };
                viewModel.TreatmentDiagnosisInfoList.Add(_TreatmentDiagnosisInfo);
            }

            viewModel.ResTreatmentDiagnosisUnitList = ResTreatmentDiagnosisUnit.GetResTreatmentDiagnosisUnits(objectContext, "").ToList();
            viewModel.PhysiotherapyDefinitionList = PhysiotherapyDefinition.GetPhysiotherapyDefinitionList(objectContext, "").ToList();
            viewModel.FTRVucutBolgesiList = FTRVucutBolgesi.GetFTRVucutBolgesi(objectContext).ToList();


            if (physiotherapyOrder.PhysiotherapyRequest != null)
            {
                viewModel._physiotherapyRequestDate = physiotherapyOrder.PhysiotherapyRequest.PhysiotherapyRequestDate.Value;
            }
            else
            {
                viewModel._physiotherapyRequestDate = Common.RecTime();
            }

            if (physiotherapyOrder.PhysiotherapyRequest != null)
            {
                MedicalInformation MedicalInfo = physiotherapyOrder.PhysiotherapyRequest.Episode.Patient.MedicalInformation;

                if (MedicalInfo.Pregnancy == true)
                {
                    viewModel.Pregnancy = true;
                }
                if (MedicalInfo.MetalImplant == true)
                {
                    viewModel.MetalImplant = true;
                }
                if (MedicalInfo.MetalImplantDescription != null)
                {
                    viewModel.MetalImplantDescription = MedicalInfo.MetalImplantDescription;
                }
            }

            this.removeOutgoingTransitions(viewModel);

            ContextToViewModel(viewModel, objectContext);
        }

        partial void PostScript_PhysiotherapyOrderRequestForm(PhysiotherapyOrderRequestFormViewModel viewModel, PhysiotherapyOrder physiotherapyOrder, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            CheckRequiredProperties(viewModel.PhysiotherapyOrderList);

            physiotherapyOrder.FromResource = physiotherapyOrder.PhysiotherapyRequest.FromResource;
            physiotherapyOrder.Episode = physiotherapyOrder.PhysiotherapyRequest.Episode;
            physiotherapyOrder.MasterResource = physiotherapyOrder.FromResource;//physiotherapyOrder kullanýlmayacaðý için geçici olarak set edildi; kullanýlacaðý zaman doðru þekilde set edilmeli
            physiotherapyOrder.SubEpisode = physiotherapyOrder.PhysiotherapyRequest.SubEpisode;

            if (physiotherapyOrder.FinishSession != null && physiotherapyOrder.StartSession != null)
            {
                physiotherapyOrder.Amount = physiotherapyOrder.FinishSession - physiotherapyOrder.StartSession + 1;
            }
            else
            {
                physiotherapyOrder.Amount = 0;
            }

            foreach (var orders in physiotherapyOrder.PhysiotherapyRequest.PhysiotherapyOrders)
            {
                if (physiotherapyOrder.PhysiotherapyReports != null && orders.PhysiotherapyReports != null)//Mevcut rapora ait order varsa ayný rapor üzerinden iþlem yapýlmalý
                {
                    if (physiotherapyOrder.PhysiotherapyReports.ReportNo == orders.PhysiotherapyReports.ReportNo)
                    {
                        physiotherapyOrder.PhysiotherapyReports = orders.PhysiotherapyReports;
                    }
                }

            }

            if (physiotherapyOrder.PhysiotherapyReports != null && physiotherapyOrder.PhysiotherapyReports.FTRApplicationAreaDef != null && physiotherapyOrder.FTRApplicationAreaDef == null)
            {
                physiotherapyOrder.FTRApplicationAreaDef = physiotherapyOrder.PhysiotherapyReports.FTRApplicationAreaDef;
            }

            foreach (var item in viewModel.PhysiotherapyOrderList)
            {
                if (item.IsNewOrder == true)
                {
                    PhysiotherapyOrder order = new PhysiotherapyOrder(objectContext);//yeni obje ise context'te new ile üret

                    order.TreatmentDiagnosisUnit = viewModel.ResTreatmentDiagnosisUnitList.Where(c => c.ObjectID == new Guid(item.TreatmentDiagnosisUnit)).FirstOrDefault();
                    order.MasterResource = order.TreatmentDiagnosisUnit;
                    order.ProcedureObject = viewModel.PhysiotherapyDefinitionList.Where(c => c.ObjectID == new Guid(item.ProcedureObject)).FirstOrDefault();

                    order.FromResource = physiotherapyOrder.FromResource;
                    order.Episode = physiotherapyOrder.Episode;
                    order.SubEpisode = physiotherapyOrder.SubEpisode;

                    order.PhysiotherapyRequest = physiotherapyOrder.PhysiotherapyRequest;
                    order.ApplicationArea = item.ApplicationAreaInfo;
                    order.Dose = item.Dose;
                    order.Duration = Convert.ToInt32(item.Duration);
                    order.raporTakipNo = physiotherapyOrder.raporTakipNo;
                    order.SessionCount = Convert.ToInt32(item.SessionCount);
                    order.TreatmentProperties = item.TreatmentProperties;
                    order.FTRApplicationAreaDef = viewModel.FTRVucutBolgesiList.Where(c => c.ObjectID == new Guid(item.ApplicationArea)).FirstOrDefault();
                    order.PhysiotherapyReports = physiotherapyOrder.PhysiotherapyReports;
                    order.ResUser = physiotherapyOrder.ResUser;
                    order.Amount = physiotherapyOrder.Amount;
                }
                else
                {
                    PhysiotherapyOrder order = objectContext.GetObject(item.PhysiotherapyOrderObj.ObjectID, item.PhysiotherapyOrderObj.ObjectDef) as PhysiotherapyOrder;

                    order.TreatmentDiagnosisUnit = viewModel.ResTreatmentDiagnosisUnitList.Where(c => c.ObjectID == new Guid(item.TreatmentDiagnosisUnit)).FirstOrDefault();
                    order.MasterResource = order.TreatmentDiagnosisUnit;
                    order.ProcedureObject = viewModel.PhysiotherapyDefinitionList.Where(c => c.ObjectID == new Guid(item.ProcedureObject)).FirstOrDefault();

                    order.FromResource = physiotherapyOrder.FromResource;
                    order.Episode = physiotherapyOrder.Episode;
                    order.SubEpisode = physiotherapyOrder.SubEpisode;

                    order.PhysiotherapyRequest = physiotherapyOrder.PhysiotherapyRequest;
                    order.ApplicationArea = item.ApplicationAreaInfo;
                    order.Dose = item.Dose;
                    order.Duration = Convert.ToInt32(item.Duration);
                    order.raporTakipNo = physiotherapyOrder.raporTakipNo;
                    order.SessionCount = Convert.ToInt32(item.SessionCount);
                    order.TreatmentProperties = item.TreatmentProperties;
                    order.FTRApplicationAreaDef = viewModel.FTRVucutBolgesiList.Where(c => c.ObjectID == new Guid(item.ApplicationArea)).FirstOrDefault();
                    order.PhysiotherapyReports = physiotherapyOrder.PhysiotherapyReports;
                    order.ResUser = physiotherapyOrder.ResUser;
                    order.Amount = physiotherapyOrder.Amount;
                }

            }

            physiotherapyOrder.PhysiotherapyRequest.CurrentStateDefID = PhysiotherapyRequest.States.RequestAcception;
            if (physiotherapyOrder.PhysiotherapyRequest.PhysiotherapyRequestDate != viewModel._physiotherapyRequestDate)
            {
                PhysiotherapyRequest PhysiotherapyRequest = objectContext.GetObject<PhysiotherapyRequest>(physiotherapyOrder.PhysiotherapyRequest.ObjectID);
                PhysiotherapyRequest.PhysiotherapyRequestDate = viewModel._physiotherapyRequestDate;
                PhysiotherapyRequest.RequestDate = viewModel._physiotherapyRequestDate;
            }

            if (physiotherapyOrder.PhysiotherapyRequest.Episode.Patient.MedicalInformation != null)
            {

                if (viewModel.MetalImplant != null)
                    physiotherapyOrder.PhysiotherapyRequest.Episode.Patient.MedicalInformation.MetalImplant = viewModel.MetalImplant;
                if (viewModel.Pregnancy != null)
                    physiotherapyOrder.PhysiotherapyRequest.Episode.Patient.MedicalInformation.Pregnancy = viewModel.Pregnancy;
                if (String.IsNullOrEmpty(viewModel.MetalImplantDescription))
                    physiotherapyOrder.PhysiotherapyRequest.Episode.Patient.MedicalInformation.MetalImplantDescription = viewModel.MetalImplantDescription;
            }
            else
            {
                physiotherapyOrder.PhysiotherapyRequest.Episode.Patient.MedicalInformation = new MedicalInformation(objectContext);
                if (viewModel.MetalImplant != null)
                    physiotherapyOrder.PhysiotherapyRequest.Episode.Patient.MedicalInformation.MetalImplant = viewModel.MetalImplant;
                if (viewModel.Pregnancy != null)
                    physiotherapyOrder.PhysiotherapyRequest.Episode.Patient.MedicalInformation.Pregnancy = viewModel.Pregnancy;
                if (String.IsNullOrEmpty(viewModel.MetalImplantDescription))
                    physiotherapyOrder.PhysiotherapyRequest.Episode.Patient.MedicalInformation.MetalImplantDescription = viewModel.MetalImplantDescription;

            }

            physiotherapyOrder.IgnoreEdit();
            physiotherapyOrder.DoNotSave = true;

            if (viewModel.createTemplate == true)
            {
                UserTemplate newUserTemplate = new UserTemplate(objectContext);
                newUserTemplate.TAObjectDefID = viewModel.savedUserTemplate.TAObjectDefID;
                newUserTemplate.TAObjectID = viewModel.savedUserTemplate.TAObjectID;
                newUserTemplate.FiliterData = "PhysiotherapyRequestTemplate";
                newUserTemplate.ResUser = Common.CurrentResource;
                newUserTemplate.Description = viewModel.savedUserTemplate.Description;
            }
        }

        partial void AfterContextSaveScript_PhysiotherapyOrderRequestForm(PhysiotherapyOrderRequestFormViewModel viewModel, PhysiotherapyOrder physiotherapyOrder, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {

            
        }


        public (List<PhysiotherapyOrderInfo>, string, DateTime, DateTime, MedicalInformationModel, List <UserTemplateModel>) GetPhysiotherapyOrderList(Guid ObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PhysiotherapyRequest _PhysiotherapyRequest = objectContext.GetObject<PhysiotherapyRequest>(ObjectID);
                #region FTR Listesi
                List<PhysiotherapyOrderInfo> PhysiotherapyOrderList = new List<PhysiotherapyOrderInfo>();//grid için order listesi
                foreach (var order in _PhysiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID != PhysiotherapyOrder.States.Cancelled))
                {
                    PhysiotherapyOrderInfo _orderInfo = new PhysiotherapyOrderInfo
                    {
                        ApplicationArea = order?.FTRApplicationAreaDef?.ObjectID.ToString(),
                        ApplicationAreaInfo = order.ApplicationArea != null ? order.ApplicationArea : "",
                        Dose = order.Dose,
                        Duration = order.Duration.ToString(),
                        CurrentStateDefID = order.CurrentStateDefID.Value,
                        ProcedureObject = order.ProcedureObject.ObjectID.ToString(),
                        SessionCount = order.SessionCount.Value.ToString(),
                        TreatmentDiagnosisUnit = order.TreatmentDiagnosisUnit.ObjectID.ToString(),
                        TreatmentProperties = order.TreatmentProperties,
                        IsPlannedBefore = order.PhysiotherapyOrderDetails.Count() > 0 ? true : false,
                        OrderObjectId = order.ObjectID,
                        OrderObjectDefId = order.ObjectDef.ID,
                        IsNewOrder = false,
                        PhysiotherapyOrderObj = order
                    };
                    PhysiotherapyOrderList.Add(_orderInfo);
                }
                #endregion FTR Listesi

                #region FTR istek tarihi düzenleme

                DateTime physiotherapyRequestDate = _PhysiotherapyRequest.PhysiotherapyRequestDate != null ? _PhysiotherapyRequest.PhysiotherapyRequestDate.Value : Common.RecTime();

                DateTime minPhysiotherapyRequestDate = (_PhysiotherapyRequest.MasterAction as EpisodeAction).SubEpisode.OpeningDate.Value;

                #endregion FTR istek tarihi düzenleme

                #region Anamnez
                string medicalInfo = "";
                MedicalInformation MedicalInfo = _PhysiotherapyRequest.Episode.Patient.MedicalInformation;
                bool? pregnancy = null;
                bool? metalImplant = null;
                string metalImplantDescription = null;
                MedicalInformationModel medInfo = new MedicalInformationModel();
                medInfo.Sex = _PhysiotherapyRequest.Episode.Patient.Sex.ADI;

                if (MedicalInfo != null)
                {
                    StringBuilder medicalInfoStr = new StringBuilder();
                    if (MedicalInfo.HeartFailure == true)
                    {
                        medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "HeartFailure").FirstOrDefault().Caption);
                        medicalInfoStr.Append(", ");
                    }
                    if (MedicalInfo.Broken == true)
                    {
                        medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Broken").FirstOrDefault().Caption);
                        medicalInfoStr.Append(", ");
                    }
                    if (MedicalInfo.Pregnancy == true)
                    {
                        medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Pregnancy").FirstOrDefault().Caption);
                        medicalInfoStr.Append(", ");
                        medInfo.Pregnancy = true;
                        pregnancy = true;
                    }
                    if (MedicalInfo.Diabetes == true)
                    {
                        medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Diabetes").FirstOrDefault().Caption);
                        medicalInfoStr.Append(", ");
                    }
                    if (MedicalInfo.Malignancy == true)
                    {
                        medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Malignancy").FirstOrDefault().Caption);
                        medicalInfoStr.Append(", ");
                    }
                    if (MedicalInfo.MetalImplant == true)
                    {
                        medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "MetalImplant").FirstOrDefault().Caption);
                        medicalInfoStr.Append(", ");
                        medInfo.MetalImplant = true;
                        metalImplant = true;
                    }
                    if (MedicalInfo.VascularDisorder == true)
                    {
                        medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "VascularDisorder").FirstOrDefault().Caption);
                        medicalInfoStr.Append(", ");
                    }
                    if (MedicalInfo.Infection == true)
                    {
                        medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Infection").FirstOrDefault().Caption);
                        medicalInfoStr.Append(", ");
                    }
                    if (MedicalInfo.Stent == true)
                    {
                        medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Stent").FirstOrDefault().Caption);
                        medicalInfoStr.Append(", ");
                    }
                    if (MedicalInfo.Other == true)
                    {
                        medicalInfoStr.Append(MedicalInfo.ObjectDef.PropertyDefs.Values.Where(c => c.CodeName == "Other").FirstOrDefault().Caption);
                    }
                    if (!string.IsNullOrEmpty(MedicalInfo.MetalImplantDescription))
                    {
                        metalImplantDescription = MedicalInfo.MetalImplantDescription;
                        medInfo.MetalImplantDescription = MedicalInfo.MetalImplantDescription;
                    }
                    medicalInfo = medicalInfoStr.ToString();
                }
                #endregion Anamnez

                var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, _PhysiotherapyRequest.ObjectDef.ID, "PhysiotherapyRequestTemplate").ToList();
                List <UserTemplateModel> templateList = new List<UserTemplateModel>();
                foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList.Where(t => t.TAObjectID.ToString() != _PhysiotherapyRequest.ObjectID.ToString()))
                {
                    UserTemplateModel templateModel = new UserTemplateModel();
                    templateModel.ObjectID = item.ObjectID;
                    templateModel.TAObjectID = item.TAObjectID;
                    templateModel.TAObjectDefID = item.TAObjectDefID;
                    templateModel.Description = item.Description;
                    templateList.Add(templateModel);
                }

                return (PhysiotherapyOrderList, medicalInfo, physiotherapyRequestDate, minPhysiotherapyRequestDate,medInfo, templateList);
            }
        }

        public void DeletePhysiotherapyOrder(Guid ObjectID, Guid ObjectDef)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PhysiotherapyOrder order = objectContext.GetObject(ObjectID, ObjectDef) as PhysiotherapyOrder;
                order.CurrentStateDefID = PhysiotherapyOrder.States.Cancelled;

                objectContext.Save();
            }
        }

        protected void removeOutgoingTransitions(PhysiotherapyOrderRequestFormViewModel viewModel)
        {
            List<TTObjectStateTransitionDef> removedOutgoingTransitions = new List<TTObjectStateTransitionDef>();

            foreach (var trans in viewModel.OutgoingTransitions)
            {
                if (trans.ToStateDefID == PhysiotherapyOrder.States.Aborted || trans.ToStateDefID == PhysiotherapyOrder.States.Cancelled || trans.ToStateDefID == PhysiotherapyOrder.States.Completed || trans.ToStateDefID == PhysiotherapyOrder.States.Rejected || trans.ToStateDefID == PhysiotherapyOrder.States.RequestAcception)
                {
                    removedOutgoingTransitions.Add(trans);
                }

            }

            foreach (var removedtrans in removedOutgoingTransitions)
            {
                viewModel.OutgoingTransitions.Remove(removedtrans);
            }
        }

        private void CheckRequiredProperties(List<PhysiotherapyOrderInfo> _physiotherapyOrderList)
        {
            if (_physiotherapyOrderList.Where(c => c.Dose == null || c.Dose == "").Count() > 0)
            {
                throw new Exception(TTUtils.CultureService.GetText("", "'Doz' alaný boþ geçilemez."));
            }
            if (_physiotherapyOrderList.Where(c => c.Duration == null).Count() > 0)
            {
                throw new Exception(TTUtils.CultureService.GetText("", "'Süre' alaný boþ geçilemez."));
            }
            if (_physiotherapyOrderList.Where(c => c.SessionCount == null).Count() > 0)
            {
                throw new Exception(TTUtils.CultureService.GetText("", "'Seans Sayýsý' alaný boþ geçilemez."));
            }
        }



        [HttpPost]
        public List<PhysiotherapyOrderInfo> PhysiotherapyOrderTemplate(UserTemplateModel selectedUserTemplate)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<PhysiotherapyOrderInfo> PhysiotherapyOrderList = new List<PhysiotherapyOrderInfo>();//grid için order listesi

                if (selectedUserTemplate != null)
                {
                    PhysiotherapyRequest templatePhysiotherapyRequest = objectContext.GetObject<PhysiotherapyRequest>((Guid)selectedUserTemplate.TAObjectID);

                    foreach (var order in templatePhysiotherapyRequest.PhysiotherapyOrders.Where(c => c.CurrentStateDefID != PhysiotherapyOrder.States.Cancelled))
                    {
                        PhysiotherapyOrderInfo _orderInfo = new PhysiotherapyOrderInfo
                        {
                            ApplicationArea = order?.FTRApplicationAreaDef?.ObjectID.ToString(),
                            ApplicationAreaInfo = order.ApplicationArea != null ? order.ApplicationArea : "",
                            Dose = order.Dose,
                            Duration = order.Duration.ToString(),
                            CurrentStateDefID = order.CurrentStateDefID.Value,
                            ProcedureObject = order.ProcedureObject.ObjectID.ToString(),
                            SessionCount = order.SessionCount.Value.ToString(),
                            TreatmentDiagnosisUnit = order.TreatmentDiagnosisUnit.ObjectID.ToString(),
                            TreatmentProperties = order.TreatmentProperties,
                            IsPlannedBefore = order.PhysiotherapyOrderDetails.Count() > 0 ? true : false,
                            OrderObjectId = order.ObjectID,
                            OrderObjectDefId = order.ObjectDef.ID,
                            IsNewOrder = false,
                            PhysiotherapyOrderObj = order
                        };
                        PhysiotherapyOrderList.Add(_orderInfo);
                    }

                }
                return PhysiotherapyOrderList;
            }

        }

        [HttpPost]
        public List<UserTemplateModel> DeletePhysiotherapyRequestUserTemplate(UserTemplateModel userTemplate)
        {
            List<UserTemplateModel> userTemplatesList = new List<UserTemplateModel>();

            using (var objectContext = new TTObjectContext(false))
            {

            UserTemplate oldUserTemplate = objectContext.GetObject<UserTemplate>((Guid)userTemplate.ObjectID);
            oldUserTemplate.FiliterData = "DELETED-PhysiotherapyRequestTemplate";

            objectContext.Save();
  
                var userTemplateList = UserTemplate.GetUserTemplate(Common.CurrentResource.ObjectID, (Guid)userTemplate.TAObjectDefID, "PhysiotherapyRequestTemplate").ToList();
                foreach (UserTemplate.GetUserTemplate_Class item in userTemplateList)
                {
                    UserTemplateModel templateModel = new UserTemplateModel();
                    templateModel.ObjectID = item.ObjectID;
                    templateModel.TAObjectID = item.TAObjectID;
                    templateModel.TAObjectDefID = item.TAObjectDefID;
                    templateModel.Description = item.Description;
                    userTemplatesList.Add(templateModel);
                }
            }
            return userTemplatesList;
        }


    }
}

namespace Core.Models
{
    public partial class PhysiotherapyOrderRequestFormViewModel
    {
        public string MedicalInfo { get; set; }
        public string Message { get; set; }

        public PhysiotherapyRequest _physiotherapyRequestObj { get; set; }
        public string _physiotherapyRequestId { get; set; }

        public List<ReportItem> ReportItemList { get; set; }

        public List<TreatmentDiagnosisInfo> TreatmentDiagnosisInfoList { get; set; }
        public List<PhysiotherapyOrderInfo> PhysiotherapyOrderList { get; set; }

        public List<ResTreatmentDiagnosisUnit> ResTreatmentDiagnosisUnitList { get; set; }//Taný Tedavi Ünitesi Listesi
        public List<PhysiotherapyDefinition> PhysiotherapyDefinitionList { get; set; }//FTR Ýþlem Listesi
        public List<FTRVucutBolgesi> FTRVucutBolgesiList { get; set; }//FTR Vücut Bölgesi Listesi

        public DateTime _physiotherapyRequestDate { get; set; }
        public bool? MetalImplant { get; set; }
        public bool? Pregnancy { get; set; }
        public string MetalImplantDescription { get; set; }
        public bool createTemplate { get; set; }
        public UserTemplateModel savedUserTemplate { get; set; }
        public List<UserTemplateModel> userTemplateList { get; set; }
        public UserTemplateModel selectedUserTemplate { get; set; }
    }

    public class TreatmentDiagnosisInfo
    {
        public ResTreatmentDiagnosisUnit TreatmentDiagnosisUnit { get; set; }
        public string TreatmentDiagnosisUnitName { get; set; }
        public Guid TreatmentDiagnosisUnitId { get; set; }
        public List<ProcedureDefinitionList> ProcedureDefinitionList { get; set; }
    }
    public class ProcedureDefinitionList
    {
        public ProcedureDefinition ProcedureDefinition { get; set; }
        public string ProcedureDefinitionName { get; set; }
        public bool isRequested { get; set; }// istek yapýlan iþlemler true set edilir
    }

    public class PhysiotherapyOrderInfo
    {
        public string TreatmentDiagnosisUnit { get; set; }
        public string ApplicationArea { get; set; }
        public string ApplicationAreaInfo { get; set; }
        public string ProcedureObject { get; set; }//Fizyoterapi iþlemi
        public string SessionCount { get; set; }
        public string Duration { get; set; }
        public string Dose { get; set; }
        public string TreatmentProperties { get; set; }

        public bool IsPlannedBefore { get; set; }//Planlanmýþ tedavi mi kontrolü

        public Guid CurrentStateDefID { get; set; }
        public Guid OrderObjectId { get; set; }
        public Guid OrderObjectDefId { get; set; }

        public bool IsNewOrder { get; set; }
        public PhysiotherapyOrder PhysiotherapyOrderObj { get; set; }
        public bool isTemplateOrder { get; set; }
    }

    public class MedicalInformationModel
    {
        public bool? Pregnancy { get; set; }
        public bool? MetalImplant { get; set; }
        public string MetalImplantDescription { get; set; }
        public string Sex { get; set; }
    }
}
