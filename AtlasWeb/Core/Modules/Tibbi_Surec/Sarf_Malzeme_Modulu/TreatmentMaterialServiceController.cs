using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections.Generic;
using TTDefinitionManagement;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class TreatmentMaterialServiceController : Controller
    {

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public LoadResult GetMaterialList([FromBody] DataSourceLoadOptions loadOptions, [FromQuery] string storeID)
        {
            LoadResult result = null;

            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;

            using (var objectContext = new TTObjectContext(true))
            {

                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetAllowedDrugAndMaterialListQuery"];
                var paramList = new Dictionary<string, object>();
                var injection = "MKYSMALZEMEKODU IS NOT NULL AND " +storeID;
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }



        [HttpPost]
        public TreatmentMaterialFormViewModel GetAddedTreatmentMaterials(AddedTreatmentMaterialInputDVO inputDVO)
        {
            var viewModel = new TreatmentMaterialFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                var objectDef = TTObjectDefManager.Instance.ObjectDefs[new Guid(inputDVO.EpisodeActionObjectDefID)];
                string treatmentMaterialObjectDefName = String.Empty;
                if (!String.IsNullOrEmpty(inputDVO.TreatmentMaterialTypeName))
                {
                    treatmentMaterialObjectDefName = inputDVO.TreatmentMaterialTypeName;
                }
                else
                {
                    foreach (TTObjectRelationSubtypeDef rSubType in objectDef.ChildRelationsSubtypeDefs)
                    {
                        if (rSubType.RelationDef.ChildrenName == "TreatmentMaterials")
                        {
                            treatmentMaterialObjectDefName = rSubType.ChildObjectDef.Name;
                            break;
                        }
                    }
                }
                SubEpisodeProtocol sep = null;
                SubEpisode subepisode = null;
                if (inputDVO.SubEpisodeGuid != null && inputDVO.SubEpisodeGuid != Guid.Empty)
                {
                    SubEpisode subEpisode = (SubEpisode)objectContext.GetObject(inputDVO.SubEpisodeGuid, "SubEpisode");

                    if (subEpisode != null)
                    {
                        if (subEpisode.OpenSubEpisodeProtocol != null)
                            sep = subEpisode.OpenSubEpisodeProtocol;

                        subepisode = subEpisode;
                    }

                }
                if (String.IsNullOrEmpty(treatmentMaterialObjectDefName))
                    throw new Exception(objectDef.DisplayText + " isimli objectDef' in, BaseTreatmentMaterial' den türemiş bir objectDef ile subtype relationı bulunamadı.");
                viewModel.AddedTreatmentMaterials = new List<AddedTreatmentMaterialsViewModel>();
                foreach (TreatmentMaterialInputDVODetail detail in inputDVO.AddedTreatmentMaterials)
                {
                    Material material = (Material)objectContext.GetObject(new Guid(detail.MaterialObjectID), typeof(Material));
                    AddedTreatmentMaterialsViewModel addedViewModel = new AddedTreatmentMaterialsViewModel();
                    BaseTreatmentMaterial treatmentMaterial = (BaseTreatmentMaterial)objectContext.CreateObject(treatmentMaterialObjectDefName);
                    treatmentMaterial.Material = material;
                    treatmentMaterial.Amount = detail.Amount;
                    treatmentMaterial.ActionDate = detail.TransactionDate;
                    //Client ta set ediliyor.
                    //peTreatmentMaterial.Episode = this.EpisodeAction.Episode;
                    treatmentMaterial.Eligible = true;

                    //treatmentMaterial.ActionDate = (inputDVO.ActionDate == null || inputDVO.ActionDate == DateTime.MinValue) ? Common.RecTime() : inputDVO.ActionDate;
                    if (treatmentMaterial.ActionDate == null)
                        treatmentMaterial.ActionDate = inputDVO.ActionDate;
                    treatmentMaterial.CreationDate = treatmentMaterial.ActionDate;
                    treatmentMaterial.Active = true;
                    if (sep != null)
                        treatmentMaterial.UnitPrice = material.GetMaterialPrice(sep, treatmentMaterial.CreationDate);

                    if (treatmentMaterial.Material is DrugDefinition)
                    {
                        if (((DrugDefinition)treatmentMaterial.Material).InpatientReportType.HasValue)
                        {
                            addedViewModel.DrugReportType = ((DrugDefinition)treatmentMaterial.Material).InpatientReportType.Value;
                        }
                    }
                    addedViewModel.material = material;
                    addedViewModel.Barcode = material.Barcode;
                    addedViewModel.StockCard = material.StockCard;
                    addedViewModel.DistributionTypeDef = material.StockCard.DistributionType;
                    addedViewModel.DistributionType = material.StockCard.DistributionType.DistributionType;
                    addedViewModel.subEpisode = subepisode;
                    if (TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", "") == "40d3a1a8-198d-4c5a-bfa4-4487136e4cb8") //PURSAKLAR
                    {

                        if (material is DrugDefinition)
                        {


                            if (((DrugDefinition)material).DrugSpecifications.Count > 0)
                            {

                                for (int i = 0; i < ((DrugDefinition)material).DrugSpecifications.Count; i++)
                                {
                                    string specification = Common.GetDisplayTextOfEnumValue("DrugSpecificationEnum", (int)((DrugDefinition)material).DrugSpecifications[i].DrugSpecification);

                                    addedViewModel.drugSpecification += specification + " - ";

                                }
                            }
                        }
                    }
                    addedViewModel.AddedTreatmentMaterial = treatmentMaterial;

                    // Zorunlu Procedureler için 
                    //if (material.MaterialProcedures.Count() > 0)
                    //{
                    //    List<Guid> resourceIDList = new List<Guid>();
                    //    if (inputDVO.EpisodeActionMasterResourceId != null) 
                    //        resourceIDList.Add((Guid)inputDVO.EpisodeActionMasterResourceId); // istek yapılan birim
                    //    resourceIDList.Add(Common.CurrentResource.ObjectID);// istek yapılan kişi

                    //    addedViewModel.MaterialProcedureViewModelList = new List<MaterialProcedureViewModel>();
                    //    foreach (var MaterialProcedure in material.MaterialProcedures)
                    //    {
                    //        MaterialProcedureViewModel materialProcedureViewModel = new MaterialProcedureViewModel();
                    //        if (MaterialProcedure.ProcedureDefinition != null)
                    //        {
                    //            materialProcedureViewModel.ProcedureObjectId = MaterialProcedure.ProcedureDefinition.ObjectID;
                    //            materialProcedureViewModel.ProcedureName = MaterialProcedure.ProcedureDefinition.Code + "-" + MaterialProcedure.ProcedureDefinition.Name;


                    //            materialProcedureViewModel.IsAdditionalApplication = false;
                    //            if (MaterialProcedure.ProcedureDefinition is SurgeryDefinition)
                    //            {
                    //                var surgeryDefinition = (SurgeryDefinition)MaterialProcedure.ProcedureDefinition;
                    //                if (surgeryDefinition.SurgeryProcedureType == SurgeyProcedureTypeEnum.OnlyAdditionalApplication || surgeryDefinition.SurgeryProcedureType == SurgeyProcedureTypeEnum.ManipulationAdditionalApplication)
                    //                    materialProcedureViewModel.IsAdditionalApplication = true;
                    //            }
                    //            if (!materialProcedureViewModel.IsAdditionalApplication)
                    //            {
                    //                var procedureRequestFormDetailList = ProcedureRequestFormDetailDefinition.GetFormDetailByProcedureDefAndResources(objectContext, MaterialProcedure.ProcedureDefinition.ObjectID, resourceIDList);
                    //                foreach (var procedureRequestFormDetail in procedureRequestFormDetailList)
                    //                {
                    //                    materialProcedureViewModel.ProcedureRequestFormDetailObjectId = procedureRequestFormDetail.ObjectID;
                    //                    break;
                    //                }
                    //            }

                    //            addedViewModel.MaterialProcedureViewModelList.Add(materialProcedureViewModel);
                    //        }
                    //    }
                    // }
                    viewModel.AddedTreatmentMaterials.Add(addedViewModel);
                }

                objectContext.FullPartialllyLoadedObjects();
            }

            return viewModel;
        }

        [HttpPost]
        public void SendAddedTreatmentMaterial(TreatmentMaterialFormViewModel viewModel)
        {
            Console.WriteLine(viewModel.ToString());
        }

        [HttpGet]
        public TreatmentMaterialStartUpViewModel GetTreatmentMaterialStartUpViewModel(bool GetRectimeForMaxDate, bool GetSubEpisodeClosingDateForMaxDate, bool GetSubEpisodeOpeningDateForMinDate, bool GetEpisodeActionRequestDateForMinDate, string SubEpisodeObjectID, string EpisodeActionObjectID)
        {
            var treatmentMaterialStartUpViewModel = new TreatmentMaterialStartUpViewModel();


            using (var objectContext = new TTObjectContext(false))
            {
                var Rectime = Common.RecTime();
                var RectimeMax = Rectime.Date.AddDays(1).AddMinutes(-1);
                treatmentMaterialStartUpViewModel.DefaultDate = Rectime;

                bool findSubepisode = false;
                if (GetSubEpisodeClosingDateForMaxDate || GetSubEpisodeOpeningDateForMinDate)
                {
                    findSubepisode = true;
                }

                bool findEpisodeAction = false;
                if (GetEpisodeActionRequestDateForMinDate)
                {
                    findEpisodeAction = true;
                }

                //TreatmentMaterialForma  EpisodeAction sadece Guid olarak verildi ise SubEpisode Boş olur o durumda EpisodeActionObjectID kullanılabilir
                SubEpisode subepisode = null;
                EpisodeAction episodeAction = null;
                if (findSubepisode)
                {
                    if (SubEpisodeObjectID != null && !string.IsNullOrEmpty(SubEpisodeObjectID))
                    {
                        var subEpisodes = SubEpisode.GetByObjectId(objectContext, new Guid(SubEpisodeObjectID));
                        foreach (var _subepisode in subEpisodes)
                        {
                            subepisode = _subepisode;
                            treatmentMaterialStartUpViewModel.ProtocolNo = subepisode.ProtocolNo;
                            break;
                        }
                    }
                }
                if (findEpisodeAction || (subepisode == null && findSubepisode))   //TreatmentMaterialForma  EpisodeAction sadece Guid olarak verildi ise SubEpisode Boş olur o durumda EpisodeActionObjectID kullanılabilir
                {
                    if (EpisodeActionObjectID != null && !string.IsNullOrEmpty(EpisodeActionObjectID))
                    {
                        var episodeActions = EpisodeAction.GetByObjectID(objectContext, new Guid(EpisodeActionObjectID));
                        foreach (var _episodeAction in episodeActions)
                        {
                            episodeAction = _episodeAction;
                            subepisode = _episodeAction.SubEpisode;
                            treatmentMaterialStartUpViewModel.ProtocolNo = subepisode.ProtocolNo;
                            break;
                        }
                    }
                }
                if (episodeAction != null && GetEpisodeActionRequestDateForMinDate)
                    treatmentMaterialStartUpViewModel.MinDate = episodeAction.RequestDate;
                if (subepisode != null)
                {
                    if (GetSubEpisodeClosingDateForMaxDate)
                    {
                        if (subepisode.ClosingDate != null)
                            treatmentMaterialStartUpViewModel.MaxDate = subepisode.ClosingDate;
                        else
                            treatmentMaterialStartUpViewModel.MaxDate = RectimeMax;
                    }
                    if (GetSubEpisodeOpeningDateForMinDate)
                        treatmentMaterialStartUpViewModel.MinDate = subepisode.OpeningDate;
                }

                if (GetRectimeForMaxDate)
                    treatmentMaterialStartUpViewModel.MaxDate = RectimeMax;
            }

            return treatmentMaterialStartUpViewModel;
        }



        [HttpPost]
        public string GetTreatmentMaterialDetail(GetTreatmentMaterialDetail_Input input)
        {
            string returnMessage = "";
            using (var objectContext = new TTObjectContext(false))
            {
                BaseTreatmentMaterial trMat = (BaseTreatmentMaterial)objectContext.GetObject(input.Material.ObjectID, typeof(BaseTreatmentMaterial).Name, false);

                //BaseTreatmentMaterial trMat = (BaseTreatmentMaterial)objectContext.GetObject(input.Material.ObjectID, typeof(BaseTreatmentMaterial).Name);
                if (trMat != null)
                {
                    if (trMat.StockActionDetail != null)
                    {
                        foreach (StockTransaction st in trMat.StockActionDetail.StockTransactions.Select(string.Empty))
                        {
                            if (st.CurrentStateDefID == StockTransaction.States.Cancelled)
                            {
                                returnMessage = "İşlem İptal Edilmiştir.";
                            }
                            else
                            {

                                StockTransaction first = st.GetFirstInTransaction();

                                foreach (StockTransactionDetail trxDet in st.OutStockTransactionDetails.Select(string.Empty))
                                {

                                    returnMessage = trxDet.OutStockTransaction.StockActionDetail.StockAction.StockActionID.ToString() + " İşlem ile hastaya çıkışı - " +
                                        trxDet.InStockTransaction.StockActionDetail.StockAction.StockActionID.ToString() + " İşlem ile giriş yapılmıştır." +
                                        first.StockActionDetail.StockAction.StockActionID.ToString() + " İşlemi ile İlk girişi yapılmıştır.";
                                }
                            }
                        }
                    }
                    else
                    {
                        returnMessage = "Stok Düşümü Yapılmamıştır.";
                    }
                }
                else
                {
                    returnMessage = "Malzeme düşümü daha yapılmadığı için işlem kaydı tutmaz.!";
                }
            }
            return returnMessage;
        }


        [HttpPost]
        public string DeleteUTSRowTreatmentMaterialDetail(GetTreatmentMaterialDetail_Input input)
        {
            string sonuc = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                BaseTreatmentMaterial trMat = (BaseTreatmentMaterial)objectContext.GetObject(input.Material.ObjectID, typeof(BaseTreatmentMaterial).Name, false);
                string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");

                if(trMat == null)
                {
                    throw new Exception("Harekti Olmayan Malzeme İçin İşlem İlerletilemez. ");
                }

                foreach (StockTransaction item in trMat.StockActionDetail.StockTransactions.Select(""))
                {
                    foreach (UTSNotificationDetail utsNotDet in item.UTSNotificationDetails.Where(x => x.CurrentStateDefID != UTSNotificationDetail.States.Cancelled))
                    {
                        UTSServis.KullanimIptalBildirimiIstek kullanimIptalBildirimiIstek = new UTSServis.KullanimIptalBildirimiIstek();
                        kullanimIptalBildirimiIstek.BID = utsNotDet.NotificationID;

                        try
                        {
                            UTSServis.BildirimCevap KullanımIptalcevap = UTSServis.WebMethods.KullanimIptalBildirimiSync(new Guid(siteID), kullanimIptalBildirimiIstek);
                            sonuc = KullanımIptalcevap.MSJ[0].MET;
                            if (String.IsNullOrEmpty(KullanımIptalcevap.MSJ[0].TIP) == false)
                            {
                                if (KullanımIptalcevap.MSJ[0].TIP != "HATA")
                                {
                                    utsNotDet.CurrentStateDefID = UTSNotificationDetail.States.Cancelled;
                                    IBindingList acctrx = objectContext.QueryObjects(typeof(AccountTransaction).Name, "UTSNOTIFICATIONDETAIL = '" + utsNotDet.ObjectID.ToString() + "'");
                                    foreach (AccountTransaction acc in acctrx)
                                    {
                                        acc.UTSNotificationDetail = null;
                                    }
                                }
                                else
                                {
                                    sonuc = KullanımIptalcevap.MSJ[0].KOD + KullanımIptalcevap.MSJ[0].MET + KullanımIptalcevap.MSJ[0].MPA + KullanımIptalcevap.MSJ[0].TIP;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            sonuc = e.Message.ToString();
                        }
                    }
                }
                objectContext.Save();
                if (String.IsNullOrEmpty(sonuc) == true)
                {
                    sonuc = "İşlem Yapılamadı.";
                }
                return sonuc;
            }
        }
    }
}