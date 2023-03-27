//$147BECA1
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Infrastructure.Helpers;
using TTDataDictionary;
using System.Data.SqlClient;
using System.IO;
using TTUtils;
using System.Data;
using static Core.Controllers.Logistic.LogisticDashboardController;
using Core.Controllers.Logistic;
using TTDefinitionManagement;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class DrugDefinitionServiceController : Controller
    {
        public class GetSgkReturnPayText_Input
        {
            public bool? SgkReturnPayNullableValue { get; set; }

        }
        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public string GetSgkReturnPayText(GetSgkReturnPayText_Input input)
        {
            var ret = DrugDefinition.GetSgkReturnPayText(input.SgkReturnPayNullableValue);
            return ret;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public BindingList<MaterialPrice.MaterialPriceByMaterialForDefinition_Class> GetDrugPrices(string objectid)

        {
            BindingList<MaterialPrice.MaterialPriceByMaterialForDefinition_Class> Drg = MaterialPrice.MaterialPriceByMaterialForDefinition(objectid);
            return Drg;
        }


        [Core.Security.AtlasRequiredRoles()]
        public MaxDoseByDrugDef GetMaxDoseByDrugDefinition(LoadModelComponent_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                MaxDoseByDrugDef maxDoseByDrugDef;
                DrugDefinition drugDefinition = context.GetObject<DrugDefinition>(input.MaterialID);
                if (drugDefinition != null)
                {
                    maxDoseByDrugDef = new MaxDoseByDrugDef()
                    {
                        InpatientMaxDoseOne = drugDefinition.InpatientMaxDoseOne,
                        InpatientMaxDoseTwo = drugDefinition.InpatientMaxDoseTwo,
                        OutpatientMaxDoseOne = drugDefinition.OutpatientMaxDoseOne,
                        OutpatientMaxDoseTwo = drugDefinition.OutpatientMaxDoseTwo,
                    };
                    return maxDoseByDrugDef;
                }
                else
                    return null;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public BindingList<ProcedureDefinition.GetProcedureDefinitionListDefinition_Class> GetProcedureDefinitionListDefinition()
        {
            var context = new TTObjectContext(false);
            BindingList<ProcedureDefinition.GetProcedureDefinitionListDefinition_Class> ret = ProcedureDefinition.GetProcedureDefinitionListDefinition("");
            return ret;
        }

        [Core.Security.AtlasRequiredRoles()]
        public List<EquivalentMaterial> GetEquivalents(LoadModelComponent_Input input)
        {
            List<EquivalentMaterial> outputforall = new List<EquivalentMaterial>();
            using (var context = new TTObjectContext(false))
            {
                EquivalentMaterial EquivalentMatforall = new EquivalentMaterial();
                BindingList<DrugDefinition.GetDrugDefinitionByEquivalentReportQuery_Class> equivalent = DrugDefinition.GetDrugDefinitionByEquivalentReportQuery(input.Equivalent);
                BindingList<ManuelEquivalentDrug.GetManuelEquivalentDrugs_Class> manuelequivalent = ManuelEquivalentDrug.GetManuelEquivalentDrugs(input.MaterialID);
                for (int i = 0; i < equivalent.Count; i++)
                {
                    EquivalentMaterial EquivalentMat = new EquivalentMaterial();
                    EquivalentMat.Equivalent = equivalent[i].Name;
                    EquivalentMat.DrugObjectid = (Guid)equivalent[i].ObjectID;
                    EquivalentMat.SelectedDrugObjectID = input.MaterialID;
                    outputforall.Add(EquivalentMat);

                }

                for (int j = 0; j < manuelequivalent.Count; j++)
                {

                    ManuelEquivalentDrug theManuelEquivalent = context.GetObject<ManuelEquivalentDrug>(new Guid(manuelequivalent[j].ObjectID.ToString()));
                    EquivalentMaterial EquivalentMat = new EquivalentMaterial();
                    if (theManuelEquivalent.EquivalentDrug != null)
                    {
                        EquivalentMat.Equivalent = theManuelEquivalent.EquivalentDrug.Name.ToString();
                        EquivalentMat.ManuelDrugObjectid = theManuelEquivalent.ObjectID;
                        EquivalentMat.SelectedDrugObjectID = input.MaterialID;
                        outputforall.Add(EquivalentMat);

                    }
                }
                return outputforall;
            }

        }
        //Buraya Döneceksin//
        [HttpPost]
        public bool DeleteEquivalent(EquivalentObjectID_Input input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {

                if (input.ManuelDrugObjectid != null && input.ManuelDrugObjectid != Guid.Empty)
                {
                    ManuelEquivalentDrug theManuelEquivalent = objectContext.GetObject<ManuelEquivalentDrug>(input.ManuelDrugObjectid.Value);
                    theManuelEquivalent.IsActive = false;
                }
                if (input.DrugObjectid != null && input.DrugObjectid != Guid.Empty)
                {
                    DrugDefinition selectedDrugDef = objectContext.GetObject<DrugDefinition>(input.SelectedDrugObjectID);
                    ManuelEquivalentDrug manuelEqDrug = selectedDrugDef.ManuelEquivalentDrugs.Select("").FirstOrDefault(x => x.EquivalentDrug?.ObjectID == input.DrugObjectid);
                    if (manuelEqDrug.ObjectID != null)
                        //manuelEqDrug.
                        manuelEqDrug.IsActive = false;
                }
                objectContext.Save();
                return true;
            }

        }
        [HttpGet]
        public List<MaterialDocumentation> GetMaterialDocumentationDetails(Material material)
        {
            List<MaterialDocumentation> list = new List<MaterialDocumentation>();
            using (var objectContext = new TTObjectContext(false))
            {
                IBindingList materialDocumentations = objectContext.QueryObjects("MATERIALDOCUMENTATION", " Material = '" + material.ObjectID + "'");
                foreach (var doc in materialDocumentations)
                {
                    list.Add((MaterialDocumentation)doc);
                }
            }
            return list;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public BindingList<Material.GetMaterialListQuery_Class> GetMaterialList()
        {
            var context = new TTObjectContext(false);
            BindingList<Material.GetMaterialListQuery_Class> ret = Material.GetMaterialListQuery("");
            return ret;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public BindingList<DrugSpecifications.GetDrugDefIDBySpesifications_Class> GetDrugSpecification()
        {
            var context = new TTObjectContext(false);
            BindingList<DrugSpecifications.GetDrugDefIDBySpesifications_Class> ret = DrugSpecifications.GetDrugDefIDBySpesifications();
            return ret;
        }
        public class DownloadFileInput
        {
            public Guid id { get; set; }
        }
        [HttpPost]
        public IActionResult DownloadFile(DownloadFileInput input)
        {

            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                try
                {
                    MaterialDocumentation doc = (MaterialDocumentation)objectContext.GetObject(input.id, typeof(MaterialDocumentation));
                    if (doc.File != null)
                    {
                        Byte[] memoryStream = (byte[])doc.File;
                        System.IO.Stream myInputStream = new System.IO.MemoryStream(memoryStream);
                        myInputStream.Position = 0;
                        var contentType = "";
                        if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".DOCX")
                        {
                            contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".PNG")
                        {
                            contentType = "image/png";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".JPG"
                            || doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".JPEG")
                        {
                            contentType = "image/jpeg";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".DOC")
                        {
                            contentType = "application/msword";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".PPT")
                        {
                            contentType = "application/vnd.ms-powerpoint";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".PPTX")
                        {
                            contentType = " application/vnd.openxmlformats-officedocument.presentationml.presentation";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".PDF")
                        {
                            contentType = "application/pdf";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".XLS")
                        {
                            contentType = "application/vnd.ms-excel";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".XLSX")
                        {
                            contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".XLSM")
                        {
                            contentType = "application/vnd.ms-excel.sheet.macroEnabled.12";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".MP3")
                        {
                            contentType = "audio/mpeg";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".MP4")
                        {
                            contentType = "video/mp4";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".AVI")
                        {
                            contentType = "video/avi";
                        }
                        else if (doc.FileName.Substring(doc.FileName.IndexOf('.')).ToUpper() == ".WMA")
                        {
                            contentType = "audio/x-ms-wma";
                        }
                        else
                            return null;
                        var response = new FileStreamResult(myInputStream, contentType);
                        response.FileDownloadName = doc.FileName;
                        objectContext.FullPartialllyLoadedObjects();
                        return response;
                    }
                    else
                    {
                        throw new FileNotFoundException("Document ilgili input ile bulunamadı. Input Body : " + JSONHelper.ToJSON(input));
                    }
                }
                catch (Exception f)
                {
                    throw f;
                }
            }
        }
        [HttpPost]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> Upload()
        {
            var result = await MultipartRequestHelper.BindMultiPartFormDataToViewModel<UploadFile_Input>(this);
            var objectResult = result as ObjectResult;
            var viewModel = objectResult.Value as UploadFile_Input;

            using (var context = new TTObjectContext(false))
            {
                Material _material = context.GetObject<Material>(new Guid(viewModel.Material));
                Guid savePoint = context.BeginSavePoint();
                if (viewModel != null)
                {
                    if (viewModel.File != null)
                    {
                        MaterialDocumentation doc = new MaterialDocumentation(context);
                        var formFile = viewModel.File.FirstOrDefault();
                        if (StreamHelpers.ToByteArray(formFile.OpenReadStream()).Length <= 10000000)
                        {

                            if (FileTypeCheck.fileTypeCheck(StreamHelpers.ToByteArray(formFile.OpenReadStream()), viewModel.FileName))
                            {
                                doc.File = StreamHelpers.ToByteArray(formFile.OpenReadStream());
                                doc.FileName = viewModel.FileName;
                                doc.FileUpdateDate = DateTime.Now;
                                doc.MaterialDocumentType = MaterialDocumentType.Sartname;
                                _material.MaterialDocumentations.Add(doc);
                                context.Save();
                            }
                            else
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25690", "Geçersiz dosya tipi!"));
                        }
                        else
                        {
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25077", "10 Mb'dan büyük dosya yükleyemezsiniz!"));
                        }
                    }
                }
            }

            return Ok();
        }

        [HttpPost]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> UploadAlerjik()
        {
            var result = await MultipartRequestHelper.BindMultiPartFormDataToViewModel<UploadFile_Input>(this);
            var objectResult = result as ObjectResult;
            var viewModel = objectResult.Value as UploadFile_Input;

            using (var context = new TTObjectContext(false))
            {
                Material _material = context.GetObject<Material>(new Guid(viewModel.Material));
                Guid savePoint = context.BeginSavePoint();
                if (viewModel != null)
                {
                    if (viewModel.File != null)
                    {
                        MaterialDocumentation doc = new MaterialDocumentation(context);
                        var formFile = viewModel.File.FirstOrDefault();
                        if (StreamHelpers.ToByteArray(formFile.OpenReadStream()).Length <= 10000000)
                        {

                            if (FileTypeCheck.fileTypeCheck(StreamHelpers.ToByteArray(formFile.OpenReadStream()), viewModel.FileName))
                            {
                                doc.File = StreamHelpers.ToByteArray(formFile.OpenReadStream());
                                doc.FileName = viewModel.FileName;
                                doc.FileUpdateDate = DateTime.Now;
                                doc.MaterialDocumentType = MaterialDocumentType.AlerjikReaksiyon;
                                _material.MaterialDocumentations.Add(doc);
                                context.Save();
                            }
                            else
                                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25690", "Geçersiz dosya tipi!"));
                        }
                        else
                        {
                            throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25077", "10 Mb'dan büyük dosya yükleyemezsiniz!"));
                        }
                    }
                }
            }

            return Ok();
        }
        public class UploadFile_Input
        {

            public IList<FormFile> File { get; set; }
            public string FileName { get; set; }
            public string Material { get; set; }
            public DateTime FileUpdateDate { get; set; }
            public Boolean IsNew { get; set; }
            public UploadedDocumentType DocumentType
            {
                get; set;
            }
        }
        public class InStockTransactionInput
        {
            public string store
            {
                get;
                set;
            }
            public List<string> materials
            {
                get;
                set;
            }
            public string accountingTermObjId
            {
                get;
                set;
            }
            public string budgetTypeObjId
            {
                get;
                set;
            }
            public bool isZeroAmount
            {
                get;
                set;
            }
        }
        public class DefinitionInTrxDVO
        {
            public DateTime TransactionDate { get; set; }
            public long TIFNo { get; set; }
            public string SourceDescription { get; set; }
            public Currency Amount { get; set; }
            public BigCurrency UnitPrice { get; set; }
            public DateTime ExpirationDate { get; set; }
            public int MKYSTrxID { get; set; }
            public Guid StockTransactionObjectID { get; set; }
            public string TrxDescription { get; set; }
            public long StockActionID { get; set; }
            public int ReceiptNumber { get; set; }
            public Guid StockActionObjectid { get; set; }
        }
        public class DefinitionOutTrxDVO
        {
            public DateTime TransactionDate { get; set; }
            public long TIFNo { get; set; }
            public string SourceDescription { get; set; }
            public long StockActionID { get; set; }
            public int ReceiptNumber { get; set; }
            public Currency Amount { get; set; }
            public BigCurrency UnitPrice { get; set; }
            public string TrxDescription { get; set; }
            public Guid StockActionObjectid { get; set; }
        }
        public class HospitalInventoryDVO
        {
            public string StoreType { get; set; }
            public string StoreName { get; set; }
            public Currency Amount { get; set; }
        }

        public class DrugDefinitionByEquivalentDVO
        {
            public string materialName
            {
                get;
                set;
            }
            public string barcode
            {
                get;
                set;
            }
            public Currency restAmount
            {
                get;
                set;
            }
        }
        public class ATCDVO
        {
            public string ATCName { get; set; }
            public string ATCCode { get; set; }

        }

        public List<DefinitionInTrxDVO> GetInputMaterials(DrugsFormViewModel input)
        {
            List<DefinitionInTrxDVO> output = new List<DefinitionInTrxDVO>();
            List<DefinitionInTrxDVO> outputPTS = new List<DefinitionInTrxDVO>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                AccountingTerm accountingTerm = (AccountingTerm)objectContext.GetObject(new Guid(input.accountingTermObjId), typeof(AccountingTerm));
                Guid materialObjectID = input.MaterialID;
                if (accountingTerm.PrevTerm != null)
                {
                    BindingList<MkysCensusSyncData.GetInStockTransactionID_Class> censusTRXs = MkysCensusSyncData.GetInStockTransactionID(accountingTerm.PrevTerm.ObjectID);
                    List<Guid> censusTRXIDs = censusTRXs.Select(x => x.StockTransactionGuid.Value).ToList();
                    int listCount = censusTRXIDs.Count();

                    BindingList<StockTransaction.GetCensusStockTransactionLikeMKYS_Class> censusInTRXs = new BindingList<StockTransaction.GetCensusStockTransactionLikeMKYS_Class>();
                    for (int i = 0; i < listCount; i = i + 1000)
                    {
                        List<Guid> tempCensusTRXIDs = censusTRXIDs.Skip(i).Take(1000).ToList();
                        BindingList<StockTransaction.GetCensusStockTransactionLikeMKYS_Class> tempCensusInTRXs = StockTransaction.GetCensusStockTransactionLikeMKYS(tempCensusTRXIDs, materialObjectID, Guid.Empty, accountingTerm.StartDate.Value);
                        foreach (StockTransaction.GetCensusStockTransactionLikeMKYS_Class census in tempCensusInTRXs)
                        {
                            censusInTRXs.Add(census);
                        }
                    }

                    foreach (StockTransaction.GetCensusStockTransactionLikeMKYS_Class census in censusInTRXs)
                    {
                        DefinitionInTrxDVO definitionInTrxDVO = new DefinitionInTrxDVO();
                        definitionInTrxDVO.TransactionDate = census.TransactionDate.Value;
                        if (census.ExpirationDate.HasValue)
                            definitionInTrxDVO.ExpirationDate = census.ExpirationDate.Value;
                        definitionInTrxDVO.Amount = Convert.ToDouble(census.Censusamount);
                        if (census.MKYS_StokHareketID.HasValue)
                            definitionInTrxDVO.MKYSTrxID = census.MKYS_StokHareketID.Value;
                        definitionInTrxDVO.StockTransactionObjectID = census.ObjectID.Value;
                        definitionInTrxDVO.UnitPrice = census.UnitPrice.Value;
                        definitionInTrxDVO.TrxDescription = "Devir";
                        definitionInTrxDVO.StockActionObjectid = (Guid)census.Stockactionobjectid;
                        definitionInTrxDVO.StockActionID = 0;

                        StockAction stockAction = (StockAction)objectContext.GetObject(census.Stockactionobjectid.Value, typeof(StockAction));
                        if (stockAction is ChattelDocumentWithPurchase)
                        {
                            if (((ChattelDocumentWithPurchase)stockAction).Supplier != null)
                                definitionInTrxDVO.SourceDescription = ((ChattelDocumentWithPurchase)stockAction).Supplier.Name;
                            if (((ChattelDocumentWithPurchase)stockAction).DocumentRecordLogs.Select(string.Empty).Count() > 0)
                            {
                                definitionInTrxDVO.ReceiptNumber = ((ChattelDocumentWithPurchase)stockAction).DocumentRecordLogs[0].ReceiptNumber.Value;
                                definitionInTrxDVO.TIFNo = ((ChattelDocumentWithPurchase)stockAction).DocumentRecordLogs[0].DocumentRecordLogNumber.Value;
                            }
                        }
                        else if (stockAction is ChattelDocumentInputWithAccountancy)
                        {
                            if (((ChattelDocumentInputWithAccountancy)stockAction).Accountancy != null)
                                definitionInTrxDVO.SourceDescription = ((ChattelDocumentInputWithAccountancy)stockAction).Accountancy.Name;
                            if (((ChattelDocumentInputWithAccountancy)stockAction).DocumentRecordLogs.Select(string.Empty).Count() > 0)
                            {
                                definitionInTrxDVO.ReceiptNumber = ((ChattelDocumentInputWithAccountancy)stockAction).DocumentRecordLogs[0].ReceiptNumber.Value;
                                definitionInTrxDVO.TIFNo = ((ChattelDocumentInputWithAccountancy)stockAction).DocumentRecordLogs[0].DocumentRecordLogNumber.Value;
                            }
                        }
                        outputPTS.Add(definitionInTrxDVO);
                    }

                    foreach (DefinitionInTrxDVO item in outputPTS)
                    {
                        if (output.Any(x => x.TrxDescription == item.TrxDescription && x.UnitPrice == item.UnitPrice && x.MKYSTrxID == item.MKYSTrxID))
                        {
                            DefinitionInTrxDVO dto = outputPTS.Where(x => x.TrxDescription == item.TrxDescription && x.UnitPrice == item.UnitPrice && x.MKYSTrxID == item.MKYSTrxID).FirstOrDefault();
                            dto.Amount += item.Amount;
                        }
                    }
                }

                BindingList<StockTransaction.GetInStockTransactionLikeMKYS_Class> inTRXs = StockTransaction.GetInStockTransactionLikeMKYS(input.StoreID, (DateTime)accountingTerm.StartDate, (DateTime)accountingTerm.EndDate, input.MaterialID, Guid.Empty);

                foreach (StockTransaction.GetInStockTransactionLikeMKYS_Class inTRX in inTRXs)
                {
                    DefinitionInTrxDVO definitionInTrxDVO = new DefinitionInTrxDVO();
                    definitionInTrxDVO.TransactionDate = inTRX.TransactionDate.Value;
                    if (inTRX.ExpirationDate.HasValue)
                        definitionInTrxDVO.ExpirationDate = inTRX.ExpirationDate.Value;
                    definitionInTrxDVO.Amount = inTRX.Amount.Value;
                    if (inTRX.MKYS_StokHareketID.HasValue)
                        definitionInTrxDVO.MKYSTrxID = inTRX.MKYS_StokHareketID.Value;
                    definitionInTrxDVO.StockTransactionObjectID = inTRX.ObjectID.Value;
                    definitionInTrxDVO.UnitPrice = inTRX.UnitPrice.Value;
                    definitionInTrxDVO.TrxDescription = inTRX.Description;
                    definitionInTrxDVO.StockActionObjectid = (Guid)inTRX.Stockactionobjectid;
                    definitionInTrxDVO.StockActionID = inTRX.StockActionID.Value;

                    StockAction stockAction = (StockAction)objectContext.GetObject(inTRX.Stockactionobjectid.Value, typeof(StockAction));
                    if (stockAction is ChattelDocumentWithPurchase)
                    {
                        if (((ChattelDocumentWithPurchase)stockAction).Supplier != null)
                            definitionInTrxDVO.SourceDescription = ((ChattelDocumentWithPurchase)stockAction).Supplier.Name;
                        if (((ChattelDocumentWithPurchase)stockAction).DocumentRecordLogs.Select(string.Empty).Count() > 0)
                        {
                            if (((ChattelDocumentWithPurchase)stockAction).DocumentRecordLogs[0].ReceiptNumber != null)
                                definitionInTrxDVO.ReceiptNumber = ((ChattelDocumentWithPurchase)stockAction).DocumentRecordLogs[0].ReceiptNumber.Value;
                            definitionInTrxDVO.TIFNo = ((ChattelDocumentWithPurchase)stockAction).DocumentRecordLogs[0].DocumentRecordLogNumber.Value;
                        }
                    }
                    else if (stockAction is ChattelDocumentInputWithAccountancy)
                    {
                        if (((ChattelDocumentInputWithAccountancy)stockAction).Accountancy != null)
                            definitionInTrxDVO.SourceDescription = ((ChattelDocumentInputWithAccountancy)stockAction).Accountancy.Name;
                        if (((ChattelDocumentInputWithAccountancy)stockAction).DocumentRecordLogs.Select(string.Empty).Count() > 0)
                        {
                            if (((ChattelDocumentInputWithAccountancy)stockAction).DocumentRecordLogs[0].ReceiptNumber != null)
                                definitionInTrxDVO.ReceiptNumber = ((ChattelDocumentInputWithAccountancy)stockAction).DocumentRecordLogs[0].ReceiptNumber.Value;
                            definitionInTrxDVO.TIFNo = ((ChattelDocumentInputWithAccountancy)stockAction).DocumentRecordLogs[0].DocumentRecordLogNumber.Value;
                        }
                    }
                    output.Add(definitionInTrxDVO);
                }
            }
            output = output.OrderBy(o => o.TransactionDate).ToList();
            return output;
        }

        public List<DefinitionOutTrxDVO> GetOutputMaterials(DrugsFormViewModel input)
        {
            List<DefinitionOutTrxDVO> output = new List<DefinitionOutTrxDVO>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                AccountingTerm accountingTerm = (AccountingTerm)objectContext.GetObject(new Guid(input.accountingTermObjId), typeof(AccountingTerm));
                BindingList<StockTransaction.GetOutStockTransaction_Class> outTRXs = StockTransaction.GetOutStockTransaction(input.StoreID, (DateTime)accountingTerm.StartDate, (DateTime)accountingTerm.EndDate, input.MaterialID, Guid.Empty);

                foreach (StockTransaction.GetOutStockTransaction_Class outTRX in outTRXs)
                {
                    StockTransaction stockTransaction = (StockTransaction)objectContext.GetObject(outTRX.ObjectID.Value, typeof(StockTransaction));
                    DefinitionOutTrxDVO definitionOutTrxDVO = new DefinitionOutTrxDVO();
                    definitionOutTrxDVO.TransactionDate = stockTransaction.TransactionDate.Value;
                    definitionOutTrxDVO.TrxDescription = stockTransaction.StockTransactionDefinition.Description;
                    definitionOutTrxDVO.Amount = stockTransaction.Amount.Value;
                    definitionOutTrxDVO.UnitPrice = stockTransaction.UnitPrice.Value;
                    definitionOutTrxDVO.StockActionID = stockTransaction.StockActionDetail.StockAction.StockActionID.Value.Value;
                    definitionOutTrxDVO.StockActionObjectid = stockTransaction.StockActionDetail.StockAction.ObjectID;
                    if (stockTransaction.StockActionDetail.StockAction is ChattelDocumentOutputWithAccountancy) //Çıkış
                    {
                        definitionOutTrxDVO.SourceDescription = ((ChattelDocumentOutputWithAccountancy)stockTransaction.StockActionDetail.StockAction).Accountancy.Name;
                        DocumentRecordLog doc = stockTransaction.StockActionDetail.StockAction.DocumentRecordLogs.Where(x => x.BudgeType == stockTransaction.BudgetTypeDefinition.MKYS_Butce).FirstOrDefault();
                        if (doc.DocumentRecordLogNumber != null)
                        {
                            definitionOutTrxDVO.TIFNo = (int)doc.DocumentRecordLogNumber.Value;
                            if (doc.ReceiptNumber != null)
                                definitionOutTrxDVO.ReceiptNumber = doc.ReceiptNumber.Value;
                        }
                    }
                    else if (stockTransaction.StockActionDetail.StockAction is DistributionDocument) //Dağıtım
                    {
                        definitionOutTrxDVO.SourceDescription = ((DistributionDocument)stockTransaction.StockActionDetail.StockAction).DestinationStore.Name;
                        DocumentRecordLog doc = stockTransaction.StockActionDetail.StockAction.DocumentRecordLogs.Where(x => x.BudgeType == stockTransaction.BudgetTypeDefinition.MKYS_Butce).FirstOrDefault();
                        if (doc.DocumentRecordLogNumber != null)
                        {
                            definitionOutTrxDVO.TIFNo = (int)doc.DocumentRecordLogNumber.Value;
                            if (doc.ReceiptNumber != null)
                                definitionOutTrxDVO.ReceiptNumber = doc.ReceiptNumber.Value;
                        }
                    }
                    else if (stockTransaction.StockActionDetail.StockAction is MainStoreStockTransfer) //Ambarlar Arası Transfer
                    {
                        definitionOutTrxDVO.SourceDescription = ((MainStoreStockTransfer)stockTransaction.StockActionDetail.StockAction).DestinationStore.Name;
                        DocumentRecordLog doc = stockTransaction.StockActionDetail.StockAction.DocumentRecordLogs.Where(x => x.BudgeType == stockTransaction.BudgetTypeDefinition.MKYS_Butce).FirstOrDefault();
                        if (doc.DocumentRecordLogNumber != null)
                        {
                            definitionOutTrxDVO.TIFNo = (int)doc.DocumentRecordLogNumber.Value;
                            if (doc.ReceiptNumber != null)
                                definitionOutTrxDVO.ReceiptNumber = doc.ReceiptNumber.Value;
                        }
                    }
                    else if (stockTransaction.StockActionDetail.StockAction is DeleteRecordDocumentDestroyable) //kayıt silme yok edilen
                    {
                        definitionOutTrxDVO.SourceDescription = ((DeleteRecordDocumentDestroyable)stockTransaction.StockActionDetail.StockAction).Store.Name;
                        DocumentRecordLog doc = stockTransaction.StockActionDetail.StockAction.DocumentRecordLogs.Where(x => x.BudgeType == stockTransaction.BudgetTypeDefinition.MKYS_Butce).FirstOrDefault();
                        if (doc.DocumentRecordLogNumber != null)
                        {
                            definitionOutTrxDVO.TIFNo = (int)doc.DocumentRecordLogNumber.Value;
                            if (doc.ReceiptNumber != null)
                                definitionOutTrxDVO.ReceiptNumber = doc.ReceiptNumber.Value;
                        }
                    }
                    else if (stockTransaction.StockActionDetail.StockAction is ExtendExpirationDate) //miad uzatım işlemi
                    {
                        definitionOutTrxDVO.SourceDescription = ((ExtendExpirationDate)stockTransaction.StockActionDetail.StockAction).Store.Name;
                        DocumentRecordLog doc = stockTransaction.StockActionDetail.StockAction.DocumentRecordLogs.Where(x => x.BudgeType == stockTransaction.BudgetTypeDefinition.MKYS_Butce).FirstOrDefault();
                        if (doc.DocumentRecordLogNumber != null)
                        {
                            definitionOutTrxDVO.TIFNo = (int)doc.DocumentRecordLogNumber.Value;
                            if (doc.ReceiptNumber != null)
                                definitionOutTrxDVO.ReceiptNumber = doc.ReceiptNumber.Value;
                        }
                    }
                    else if (stockTransaction.StockActionDetail.StockAction is KSchedule)
                    {
                        definitionOutTrxDVO.SourceDescription = ((KSchedule)stockTransaction.StockActionDetail.StockAction).InPatientPhysicianApplication.Episode.Patient.FullName;
                        if (stockTransaction.StockCollectedTrxs.Count > 0)
                        {
                            DocumentRecordLog doc = stockTransaction.StockCollectedTrxs[0].StockActionDetail.StockAction.DocumentRecordLogs.Where(x => x.BudgeType == stockTransaction.BudgetTypeDefinition.MKYS_Butce && x.Descriptions == stockTransaction.StockActionDetail.StockAction.DestinationStore.Name).FirstOrDefault();
                            if (doc.DocumentRecordLogNumber != null)
                            {
                                definitionOutTrxDVO.TIFNo = (int)doc.DocumentRecordLogNumber.Value;
                                if (doc.ReceiptNumber != null)
                                    definitionOutTrxDVO.ReceiptNumber = doc.ReceiptNumber.Value;
                            }
                        }
                    }
                    else if (stockTransaction.StockActionDetail.StockAction is StockOut)
                    {
                        definitionOutTrxDVO.SourceDescription = (stockTransaction.StockActionDetail.StockAction.StockActionDetails[0]).Patient.FullName;
                    }

                    output.Add(definitionOutTrxDVO);
                }
            }
            return output;

        }

        public static readonly List<string> months = new List<string>()
        {
            "OCAK",
            "ŞUBAT",
            "MART",
            "NISAN",
            "MAYIS",
            "HAZIRAN",
            "TEMMUZ",
            "AGUSTOS",
            "EYLUL",
            "EKIM",
            "KASIM",
            "ARALIK"

        };

        public List<AmaountTotal> GetAmount(DrugsInFormViewModel input)
        {
            List<AmaountTotal> output = new List<AmaountTotal>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                AccountingTerm accountingTerm = (AccountingTerm)objectContext.GetObject(new Guid(input.accountingTermObjId), typeof(AccountingTerm));

                DateTime startDate = (DateTime)accountingTerm.StartDate;
                DateTime endDate = Common.GetLastDayOfMounth(startDate);
                //Seçilen yıl içerisinde başlangıç ayın ilk günü alındı,bitiş ayın son günü alınarak 12 ay için yapıldı.

                int value = 0;
                object obj = value;

                for (int ctr = 0; ctr < 12; ctr++)
                {
                    AmaountTotal DrugsInDVO = new AmaountTotal();
                    BindingList<StockTransaction.GetInMaterialForMonthlyReport_Class> inTRXs = StockTransaction.GetInMaterialForMonthlyReport(input.MaterialID, startDate, endDate);
                    BindingList<StockTransaction.GetOutMaterialForMonthlyReport_Class> outTRXs = StockTransaction.GetOutMaterialForMonthlyReport(input.MaterialID, startDate, endDate);
                    if (inTRXs[0].Nqlcolumn == null)
                    {
                        DrugsInDVO.InAmount = 0;
                        DrugsInDVO.OutAmount = 0;

                    }
                    else
                    {
                        DrugsInDVO.InAmount = int.Parse(inTRXs[0].Nqlcolumn.ToString());
                        DrugsInDVO.OutAmount = int.Parse(outTRXs[0].Nqlcolumn.ToString());

                    }
                    output.Add(DrugsInDVO);
                    DrugsInDVO.Month = months[ctr];
                    startDate = startDate.AddMonths(1);
                    endDate = Common.GetLastDayOfMounth(startDate);
                }
            }

            return output;

        }

        public List<HospitalInventoryDVO> GetHospitalInventory(DrugsFormViewModel input)
        {
            List<HospitalInventoryDVO> output = new List<HospitalInventoryDVO>();
            BindingList<Stock.GetHospitalInventoryFromStoreAndMaterial_Class> stocks = Stock.GetHospitalInventoryFromStoreAndMaterial(input.MaterialID);
            foreach (Stock.GetHospitalInventoryFromStoreAndMaterial_Class stock in stocks)
            {
                HospitalInventoryDVO hospitalInventoryDVO = new HospitalInventoryDVO();
                hospitalInventoryDVO.StoreType = stock.Storetype;
                hospitalInventoryDVO.StoreName = stock.Name;
                hospitalInventoryDVO.Amount = (Currency)stock.Inheld;
                output.Add(hospitalInventoryDVO);
            }
            return output;

        }

        public List<MaterialTreeDefinition> GetMaterialTree()
        {
            List<MaterialTreeDefinition> output = new List<MaterialTreeDefinition>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                output = objectContext.QueryObjects<MaterialTreeDefinition>("ISACTIVE=1 AND GROUPCODE = '150-03-01'").ToList();

                /*BindingList<MaterialTreeDefinition.GetMaterialTreeDefinition_Class> matTrees = MaterialTreeDefinition.GetMaterialTreeDefinition("WHERE ISACTIVE=1");

                foreach (MaterialTreeDefinition.GetMaterialTreeDefinition_Class matTree in matTrees)
                {

                    DrugDefinitionSelectBoxItem MaterialTree = new DrugDefinitionSelectBoxItem();
                    MaterialTree.DisplayText = matTree.Name;
                    MaterialTree.Objectid = matTree.ObjectID.Value;
                    output.Add(MaterialTree);
                }*/
            }

            return output;
        }
        public void SaveDrugSpecification(DrugSpecification_Input input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                foreach (var item in input.drugSpecificationNewArray)
                {
                    DrugSpecifications drugSpecifications = new DrugSpecifications(objectContext);

                    drugSpecifications.DrugSpecification = (DrugSpecificationEnum)Common.GetEnumValueDefOfEnumValue(item).EnumValue;
                    drugSpecifications.DrugDefinition = input.drugDefinitionObjectid;
                }
                objectContext.Save();
                objectContext.Dispose();
            }

        }
        //public List<EtkinMadde> GetSGKActiveMaterial()
        //{
        //    List<EtkinMadde> output = new List<EtkinMadde>();
        //    using (TTObjectContext objectContext = new TTObjectContext(false))
        //    {
        //        output = objectContext.QueryObjects<EtkinMadde>().ToList();
        //    }
        //    return output;
        //}

        public LoadResult GetSGKActiveMaterial([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;
            using (var objectContext = new TTObjectContext(false))
            {
                TTQueryDef queryDef;
                queryDef = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].QueryDefs["GetEtkinMaddeDefinitionQuery"];
                var paramList = new Dictionary<string, object>();
                var injection = string.Empty;
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }

        public List<ATCDVO> GetATCList()
        {
            List<ATCDVO> output = new List<ATCDVO>();
            BindingList<ATC.OLAP_GetATC_Class> ATCs = ATC.OLAP_GetATC();
            foreach (ATC.OLAP_GetATC_Class oLAP in ATCs)
            {
                ATCDVO atc = new ATCDVO();
                atc.ATCName = oLAP.Name;
                atc.ATCCode = oLAP.Code;
                output.Add(atc);
            }
            return output;
        }
        public List<DrugSpecificationEnum> GetSpecificationsOfDrugDefinition(Guid drugDefinitionObjectID)
        {
            List<DrugSpecificationEnum> output = new List<DrugSpecificationEnum>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                BindingList<DrugSpecifications.GetTypeOfDrugDefinition_Class> dse = DrugSpecifications.GetTypeOfDrugDefinition(drugDefinitionObjectID);
                foreach (DrugSpecifications.GetTypeOfDrugDefinition_Class item in dse)
                {
                    output.Add((DrugSpecificationEnum)Common.GetEnumValueDefOfEnumValue(item.DrugSpecification).EnumValue);
                }
            }
            return output;
        }

        public class DocumentUpload_Input
        {
            public IList<FormFile> File
            {
                get; set;
            }
            public string FileName
            {
                get; set;
            }
            public string EpisodeID
            {
                get; set;
            }
        }

        public LoadModelComponent loadModelComponent(LoadModelComponent_Input input)
        {
            LoadModelComponent loadModel = new LoadModelComponent();
            loadModel.getStockLocationClasses = this.GetStockLocation();
            loadModel.getMaxDoseByDrugDef = this.GetMaxDoseByDrugDefinition(input);
            loadModel.shelfAndRowOnStock = this.GetShelfAndRowOnStock(input);
            loadModel.materialPrices = this.GetDrugPrices(input.MaterialID.ToString());
            loadModel.getEquivalents = this.GetEquivalents(input);
            loadModel.getCritical = this.GetCriticalStockLevels(input.StoreID.ToString(), input.MaterialID.ToString());
            loadModel.materialProcedures = this.GetMaterialProcedures(input.MaterialID);
            loadModel.firstInStockUnitePrices = this.GetMaterialInStock(input);
            loadModel.logDataSources = new List<LogDataSource>();// this.GetObjectAuditRecords(input.MaterialID);
            loadModel.doSearchaccountingTerm = this.GetAccountingTerm(input.StoreID);
            loadModel.drugSpecifications = this.drugSpecificationEnums(input.MaterialID);
            loadModel.routeOfAdminDataSource = this.getRouteOfAdminDataSource();
            loadModel.nfcDataSource = this.getNFCDataSource();

            return loadModel;
        }
        public List<NFC> getNFCDataSource()
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<NFC> nfcList = objectContext.QueryObjects<NFC>().ToList();
                return nfcList;
            }
        }
        public List<RouteOfAdmin> getRouteOfAdminDataSource()
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<RouteOfAdmin> routeOfAdminList = objectContext.QueryObjects<RouteOfAdmin>().ToList();
                return routeOfAdminList;
            }
        }
        public List<DrugSpecificationEnum> drugSpecificationEnums(Guid MaterialID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<DrugSpecifications> drugSpecifications = objectContext.QueryObjects<DrugSpecifications>("DRUGDEFINITION = " + TTConnectionManager.ConnectionManager.GuidToString(MaterialID)).ToList();
                return drugSpecifications.Select(x => x.DrugSpecification.Value).ToList();
            }
        }



        public LogisticDashboardViewModel GetAccountingTerm(Guid storeObjectID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                LogisticDashboardViewModel model = new LogisticDashboardViewModel();
                Store store = (Store)objectContext.GetObject(storeObjectID, typeof(Store));
                List<CostActionAccountingTerm> accounting = new List<CostActionAccountingTerm>();
                if (store is MainStoreDefinition)
                {
                    foreach (AccountingTerm term in ((MainStoreDefinition)store).Accountancy.AccountingTerms)
                    {
                        CostActionAccountingTerm accont = new CostActionAccountingTerm();
                        accont.ObjId = term.ObjectID.ToString();
                        accont.Desciption = term.Description;
                        accont.StartDate = (DateTime)term.StartDate;
                        accont.Status = term.Status;
                        accounting.Add(accont);
                    }

                    model.IsMainStoreFlag = true;
                }
                else
                    model.IsMainStoreFlag = false;
                accounting.Sort(delegate (CostActionAccountingTerm ps1, CostActionAccountingTerm ps2)
                {
                    return DateTime.Compare(ps1.StartDate, ps2.StartDate);
                }

                );
                accounting = accounting.OrderByDescending(ps1 => ps1.StartDate).ToList();
                model.costActionAccountingTerm = accounting;
                model.activeCostActionAccountingTerm = accounting.FirstOrDefault(x => x.Status == AccountingTermStatusEnum.Open);
                objectContext.FullPartialllyLoadedObjects();
                return model;
            }
        }

        public List<LogDataSource> GetObjectAuditRecords([FromQuery] Guid auditObjectID)
        {
            List<LogDataSource> arr = new List<LogDataSource>();
            TTAuditOperationTypeEnum[] auditOperationTypes = { TTAuditOperationTypeEnum.Insert, TTAuditOperationTypeEnum.Update, TTAuditOperationTypeEnum.Delete };
            DataTable _allDataDataTable = TTAuditRecord.GetAuditRecords(auditObjectID, new Guid("65a2337c-bc3c-4c6b-9575-ad47fa7a9a89"), null, null, null, false, true, auditOperationTypes, null, null);
            for (int i = 0; i < _allDataDataTable.Rows.Count; i++)
            {
                TTAuditRecord audit = new TTAuditRecord(_allDataDataTable.Rows[i]);
                arr.Add(LogDataSource.CreateFromAudit(audit));
            }
            return arr;
        }

        public List<ProcedureDefinition_Output> GetMaterialProcedures(Guid material)
        {
            List<ProcedureDefinition_Output> procedures = new List<ProcedureDefinition_Output>();
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<MaterialProcedures.GetMaterialProcedures_Class> materialProcedures = MaterialProcedures.GetMaterialProcedures(material);
                foreach (MaterialProcedures.GetMaterialProcedures_Class item in materialProcedures)
                {
                    ProcedureDefinition pd = objectContext.GetObject<ProcedureDefinition>(item.Pdobjectid.Value);
                    ProcedureDefinition_Output output = new ProcedureDefinition_Output();
                    output.ObjectID = pd.ObjectID;
                    output.Name = pd.Name;
                    output.ID = pd.ID.ToString();
                    output.Code = pd.Code;
                    procedures.Add(output);
                }
            }
            return procedures;
        }

        public ShelfAndRowOnStock GetShelfAndRowOnStock(LoadModelComponent_Input input)
        {
            ShelfAndRowOnStock shelfAndRowOnStock_Output = new ShelfAndRowOnStock();
            using (var objectContext = new TTObjectContext(false))
            {
                StoreLocation location = new StoreLocation(objectContext);
                BindingList<Stock> stockList = (BindingList<Stock>)objectContext.QueryObjects("STOCK", "STORE = '" + input.StoreID + "' AND MATERIAL = '" + input.MaterialID + "'");


                foreach (Stock _stock in stockList)
                {
                    if (_stock.StoreLocations.Count > 0)
                    {
                        shelfAndRowOnStock_Output.Shelf = _stock.Shelf;
                        shelfAndRowOnStock_Output.Row = _stock.Row;
                        if (_stock.StoreLocations[0].StockLocation != null)
                        {
                            shelfAndRowOnStock_Output.StockLocationID = _stock.StoreLocations[0].StockLocation.ObjectID;
                        }

                    }
                }
                BindingList<StockLocation> stockLocation = (BindingList<StockLocation>)objectContext.QueryObjects("STOCKLOCATION", "OBJECTID = '" + shelfAndRowOnStock_Output.StockLocationID + "'");
                if (stockLocation.Count > 0)
                {
                    foreach (StockLocation _stockLocation in stockLocation)
                    {
                        shelfAndRowOnStock_Output.StockLocation = _stockLocation;
                    }
                }
            }
            return shelfAndRowOnStock_Output;

        }

        public BindingList<StockLocation.GetStockLocation_Class> GetStockLocation()
        {
            BindingList<StockLocation.GetStockLocation_Class> stockLocationIsGroupList = new BindingList<StockLocation.GetStockLocation_Class>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                stockLocationIsGroupList = StockLocation.GetStockLocation(objectContext, " WHERE ISGROUP = '1' ");
            }
            return stockLocationIsGroupList;
        }

        public BindingList<StockLocation.GetStockLocation_Class> GetStockShelfLocation(GetStockLocation_Input ParentStockLocation)
        {
            if (ParentStockLocation == null)
                return null;

            BindingList<StockLocation.GetStockLocation_Class> stockLocationIsNotGroupList = new BindingList<StockLocation.GetStockLocation_Class>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                stockLocationIsNotGroupList = StockLocation.GetStockLocation("WHERE ISGROUP ='0' AND PARENTSTOCKLOCATION ='" + ParentStockLocation.StockLocationName + "'");
            }
            return stockLocationIsNotGroupList;
        }


        public string updateMaterialPriceByIlacAra(string drugDefinitionObjId)
        {
            string returnMessage = "";
            TTObjectContext context = new TTObjectContext(false);
            try
            {
                if (String.IsNullOrEmpty(drugDefinitionObjId) == false)
                {
                    MedulaYardimciIslemler.ilacAraGirisDVO ilacAraGirisDVO = new MedulaYardimciIslemler.ilacAraGirisDVO();
                    DrugDefinition drugDefinition = (DrugDefinition)context.GetObject(new Guid(drugDefinitionObjId), typeof(DrugDefinition));
                    //ilacAraGirisDVO.saglikTesisKodu = Int32.Parse(TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME", "XXXXXX"));
                    ilacAraGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                    ilacAraGirisDVO.barkod = drugDefinition.Barcode;
                    MedulaYardimciIslemler.ilacAraCevapDVO ilacAraCevapDVO = MedulaYardimciIslemler.WebMethods.ilacAraSync(Sites.SiteLocalHost, ilacAraGirisDVO);
                    if (ilacAraCevapDVO.sonucKodu == "0000")
                    {
                        List<PricingDetailDVO> pricingDetailDefinitions = new List<PricingDetailDVO>();
                        pricingDetailDefinitions = PricingDetailDefinitionForMedicine(context, ilacAraCevapDVO.ilaclar[0], drugDefinition);

                        if (pricingDetailDefinitions.Count == 0)
                        {
                            return " İlacın Şuanki Fiyatı Meduladaki Fiyatı ile Aynıdır..";
                        }

                        if (ilacAraCevapDVO.ilaclar.Length > 0)
                        {
                            //doz birimleri
                            drugDefinition.OutpatientMaxDoseOne = ilacAraCevapDVO.ilaclar[0].ayaktanMaksimumKullanimDoz1;
                            drugDefinition.OutpatientMaxDoseTwo = ilacAraCevapDVO.ilaclar[0].ayaktanMaksimumKullanimDoz2;
                            drugDefinition.InpatientMaxDoseOne = ilacAraCevapDVO.ilaclar[0].yatanMaksimumKullanimDoz1;
                            drugDefinition.InpatientMaxDoseTwo = ilacAraCevapDVO.ilaclar[0].yatanMaksimumKullanimDoz2;
                        }

                        foreach (PricingDetailDVO pricingDetailDVO in pricingDetailDefinitions)
                        {

                            if (pricingDetailDVO.newPricingDetailDefinition != null && pricingDetailDVO.oldPricingDetailDefinition != null)
                            {
                                // Yeni, Medulaya Gönderilmeyecek, ve Hizmet Kaydı Başarısız durumdaki ve fiyat başlangıç tarihinden sonraki accTrx ler
                                IBindingList accTrxListForPriceUpdate = context.QueryObjects("ACCOUNTTRANSACTION", "SUBACTIONMATERIAL IS NOT NULL "
                                             + " AND CURRENTSTATEDEFID IN ('934b9f03-d262-428d-8cb8-5e8ab927e3d5','33784c3f-d601-49c4-b8da-6fa502f6a9cf','6856675b-95fb-41cf-bade-6a1993626cc7')"
                                             + " AND PRICINGDETAIL = '" + pricingDetailDVO.oldPricingDetailDefinition.ObjectID.ToString()
                                             + "' AND TRANSACTIONDATE >= " + Globals.CreateNQLToDateParameter(Convert.ToDateTime(ilacAraCevapDVO.ilaclar[0].ilacFiyatlari[0].gecerlilikTarihi)));

                                foreach (AccountTransaction accTrx in accTrxListForPriceUpdate)
                                {
                                    if (accTrx.SubActionMaterial.Material is ConsumableMaterialDefinition)
                                    {
                                        // (SGK ve kurum payı) ise satış fiyatı + %12 , Malzeme için diğer durumlarda alış fiyatı kullanıldığı için güncelleme yapılmaz
                                        if (accTrx.SubEpisodeProtocol.Payer.IsSGKAll && accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                                            accTrx.UnitPrice = Math.Round((double)(pricingDetailDVO.newPricingDetailDefinition.Price.Value * 1.12), 2);
                                    }
                                    else
                                    {
                                        // ilaç ise direkt unitprice ı güncelle 
                                        accTrx.UnitPrice = Math.Round((double)pricingDetailDVO.newPricingDetailDefinition.Price.Value, 2);
                                    }
                                }
                                returnMessage = drugDefinition.Name + "isimli malzeme için Yeni Fiyatı:" + ilacAraCevapDVO.ilaclar[0].ilacFiyatlari[0].fiyat + " üzerinden hastayalara çıkılan malzeme fiyatları güncellendi.";
                            }
                            else if (pricingDetailDVO.newPricingDetailDefinition != null && pricingDetailDVO.oldPricingDetailDefinition == null) // Eski fiyatı olmayıp (PricingDetail i null) 0 fiyatlı ücretlenmişler için
                            {
                                IBindingList accTrxListForPriceUpdate = accTrxListForPriceUpdate = context.QueryObjects("ACCOUNTTRANSACTION", "SUBACTIONMATERIAL IS NOT NULL AND PRICINGDETAIL IS NULL"
                                                 + " AND CURRENTSTATEDEFID IN ('934b9f03-d262-428d-8cb8-5e8ab927e3d5','33784c3f-d601-49c4-b8da-6fa502f6a9cf','6856675b-95fb-41cf-bade-6a1993626cc7')"
                                                 + " AND SUBACTIONMATERIAL.MATERIAL = '" + drugDefinition.ObjectID
                                                 + "' AND TRANSACTIONDATE >= " + Globals.CreateNQLToDateParameter(Convert.ToDateTime(ilacAraCevapDVO.ilaclar[0].ilacFiyatlari[0].gecerlilikTarihi)));


                                foreach (AccountTransaction accTrx in accTrxListForPriceUpdate)
                                {
                                    if (accTrx.SubActionMaterial.Material is ConsumableMaterialDefinition)
                                    {
                                        // (SGK ve kurum payı) ise satış fiyatı + %12 , Malzeme için diğer durumlarda alış fiyatı kullanıldığı için güncelleme yapılmaz
                                        if (accTrx.SubEpisodeProtocol.Payer.IsSGKAll && accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                                            accTrx.UnitPrice = Math.Round((double)(pricingDetailDVO.newPricingDetailDefinition.Price.Value * 1.12), 2);
                                    }
                                    else
                                    {
                                        // ilaç ise direkt unitprice ı güncelle 
                                        accTrx.UnitPrice = Math.Round((double)pricingDetailDVO.newPricingDetailDefinition.Price.Value, 2);
                                    }
                                }
                                returnMessage = drugDefinition.Name + "isimli malzeme için Yeni Fiyatı:" + ilacAraCevapDVO.ilaclar[0].ilacFiyatlari[0].fiyat + " üzerinden hastayalara çıkılan malzeme fiyatları güncellendi.";
                            }
                        }
                    }
                    else
                    {
                        return ilacAraCevapDVO.sonucKodu + " - " + ilacAraCevapDVO.sonucMesaji;
                    }
                    context.Save();
                    context.Dispose();
                }
            }
            catch (Exception ex)
            {
                returnMessage = "Fiyat Güncelleme İşleminde Alınan Hata : " + ex.Message;
            }

            return returnMessage;
        }




        public pricePatientOutputDTO updatePatientMaterialPrice(string drugDefinitionObjId)
        {
            pricePatientOutputDTO dTO = new pricePatientOutputDTO();
            DateTime nowTime = Common.RecTime();
            DateTime yesterdayTime = Common.RecTime().AddDays(-1);

            using (TTObjectContext context = new TTObjectContext(false))
            {
                DrugDefinition drugDefinition = context.GetObject<DrugDefinition>(new Guid(drugDefinitionObjId));

                MaterialPrice oldMaterialPrice = drugDefinition.MaterialPrices.Where(x => x.PricingDetail.DateEnd < nowTime &&
                                                                                x.PricingDetail.ExternalCode == drugDefinition.Barcode &&
                                                                                x.PricingDetail.PricingList.ObjectID.ToString() == "57c5a43f-2083-433a-9f05-94c49c284436").OrderByDescending(x => x.LastUpdate).FirstOrDefault();
                MaterialPrice newMaterialPrice = drugDefinition.MaterialPrices.Where(x => x.PricingDetail.DateStart > yesterdayTime &&
                                                                                               x.PricingDetail.DateEnd > nowTime &&
                                                                                               x.PricingDetail.ExternalCode == drugDefinition.Barcode &&
                                                                                               x.PricingDetail.PricingList.ObjectID.ToString() == "57c5a43f-2083-433a-9f05-94c49c284436").FirstOrDefault();

                if (newMaterialPrice != null)
                {
                    dTO.priceEndDate = newMaterialPrice.PricingDetail.DateEnd.Value;
                    dTO.priceStartDate = newMaterialPrice.PricingDetail.DateStart.Value;

                    List<pricePatienList> unUpdatedPatienList = new List<pricePatienList>();
                    List<pricePatienList> UpdatedPatienList = new List<pricePatienList>();

                    IBindingList accTrxListForPriceUpdate = context.QueryObjects("ACCOUNTTRANSACTION", "SUBACTIONMATERIAL IS NOT NULL "
                                            + " AND CURRENTSTATEDEFID IN ('934b9f03-d262-428d-8cb8-5e8ab927e3d5','33784c3f-d601-49c4-b8da-6fa502f6a9cf','6856675b-95fb-41cf-bade-6a1993626cc7')"
                                            + " AND PRICINGDETAIL = '" + oldMaterialPrice.PricingDetail.ObjectID.ToString() + "'");

                    foreach (AccountTransaction accTrx in accTrxListForPriceUpdate)
                    {
                        if (accTrx.UnitPrice != newMaterialPrice.PricingDetail.Price)
                        {
                            pricePatienList unUpdatedPatien = new pricePatienList();
                            unUpdatedPatien.AccTrxObjID = accTrx.ObjectID.ToString();
                            unUpdatedPatien.OldPrice = oldMaterialPrice.PricingDetail.Price.ToString();
                            unUpdatedPatien.NewPrice = newMaterialPrice.PricingDetail.Price.ToString();
                            unUpdatedPatien.TrasnactionDate = (DateTime)accTrx.TransactionDate;
                            unUpdatedPatien.Desciption = "Yapılamayan İşlem";
                            unUpdatedPatien.PatientNameAndSurname = accTrx.SubEpisodeProtocol.SubEpisode.Episode.Patient.Name + " " + accTrx.SubEpisodeProtocol.SubEpisode.Episode.Patient.Surname;
                            unUpdatedPatien.PatientProtocolNo = accTrx.SubEpisodeProtocol.SubEpisode.ProtocolNo;
                            unUpdatedPatienList.Add(unUpdatedPatien);
                        }
                        else
                        {
                            pricePatienList UpdatedPatien = new pricePatienList();
                            UpdatedPatien.NewPrice = newMaterialPrice.PricingDetail.Price.ToString();
                            UpdatedPatien.OldPrice = "-";
                            UpdatedPatien.TrasnactionDate = (DateTime)accTrx.TransactionDate;
                            UpdatedPatien.Desciption = "İşlem Başarılı Sona Erdi";
                            UpdatedPatien.PatientNameAndSurname = accTrx.SubEpisodeProtocol.Episode.Patient.Name + " " + accTrx.SubEpisodeProtocol.Episode.Patient.Surname;
                            UpdatedPatien.PatientProtocolNo = accTrx.SubEpisodeProtocol.SubEpisode.ProtocolNo;
                            UpdatedPatienList.Add(UpdatedPatien);
                        }
                    }

                    dTO.unUpdatedPatienList = unUpdatedPatienList;
                    dTO.UpdatedPatienList = UpdatedPatienList;
                    dTO.totalUpdatePatientPriceCount = UpdatedPatienList.Count.ToString() + " kadar hastanın ilaç fiyatı güncellenmiştir ";
                }
                return dTO;
            }
        }

        [HttpPost]
        public void UpdateRepaitPatientPrice(RepaitUnUpdate_Intput input)
        {
            using (var context = new TTObjectContext(false))
            {

                foreach (pricePatienList item in input.unUpdatedPatienList)
                {
                    AccountTransaction accTrx = context.GetObject<AccountTransaction>(new Guid(item.AccTrxObjID));
                    try
                    {
                        accTrx.UnitPrice = Math.Round(Convert.ToDouble(item.NewPrice), 2);
                        context.Save();
                    }
                    catch (Exception e)
                    {

                    }
                }

            }
        }

        public class RepaitUnUpdate_Intput
        {
            public List<pricePatienList> unUpdatedPatienList { get; set; }
        }

        public class pricePatientOutputDTO
        {
            public List<pricePatienList> unUpdatedPatienList { get; set; }
            public List<pricePatienList> UpdatedPatienList { get; set; }
            public string totalUpdatePatientPriceCount { get; set; }
            public DateTime priceEndDate { get; set; }
            public DateTime priceStartDate { get; set; }
        }

        public class pricePatienList
        {
            public string AccTrxObjID { get; set; }
            public string PatientNameAndSurname { get; set; }
            public string PatientProtocolNo { get; set; }
            public DateTime TrasnactionDate { get; set; }
            public string OldPrice { get; set; }
            public string NewPrice { get; set; }
            public string Desciption { get; set; }
        }

        public class ITSDrugList
        {
            public Guid objectID { get; set; }
            public string drugNameBarcode { get; set; }
            public List<ITSDetail> trxLotSerialNo { get; set; }
        }
        public class ITSDetail
        {
            public Guid trxObjectid { get; set; }
            public string lotNO { get; set; }
            public string serialNo { get; set; }
        }


        public class ITSAllDrugListStatus
        {
            public Guid objectID { get; set; }
            public string drugName { get; set; }
            public string drugBarcode { get; set; }
            public List<ITSAllDrugListStatusDetail> detail { get; set; }
        }
        public class ITSAllDrugListStatusDetail
        {
            public string lotNO { get; set; }
            public string serialNo { get; set; }
            public string status { get; set; }
        }

        [HttpPost]
        public List<ITSDrugList> GetITSDrug()
        {
            List<ITSDrugList> drugLists = new List<ITSDrugList>();
            TTObjectContext context = new TTObjectContext(false);
            BindingList<DrugDefinition.GetITSDrugList_Class> getList = DrugDefinition.GetITSDrugList();
            foreach (DrugDefinition.GetITSDrugList_Class item in getList)
            {
                ITSDrugList drug = new ITSDrugList();
                drug.drugNameBarcode = item.Barcode + " - " + item.Name;
                drug.objectID = item.ObjectID.Value;
                List<ITSDetail> detailList = new List<ITSDetail>();
                BindingList<StockTransaction.GetPTSInByMaterial_Class> stockTrxList = StockTransaction.GetPTSInByMaterial(item.ObjectID.Value);
                foreach (StockTransaction.GetPTSInByMaterial_Class trx in stockTrxList)
                {
                    ITSDetail detail = new ITSDetail();
                    detail.trxObjectid = trx.ObjectID.Value;
                    detail.lotNO = trx.LotNo;
                    detail.serialNo = trx.SerialNo;
                    detailList.Add(detail);
                }
                drug.trxLotSerialNo = detailList;
                drugLists.Add(drug);
            }
            return drugLists;
        }


        [HttpPost]
        public List<ITSAllDrugListStatus> GetAllITSDrugStatus()
        {
            List<ITSAllDrugListStatus> drugLists = new List<ITSAllDrugListStatus>();
            TTObjectContext context = new TTObjectContext(false);
            BindingList<DrugDefinition.GetITSDrugList_Class> getList = DrugDefinition.GetITSDrugList();
            foreach (DrugDefinition.GetITSDrugList_Class item in getList)
            {
                ITSAllDrugListStatus drug = new ITSAllDrugListStatus();
                drug.objectID = item.ObjectID.Value;
                drug.drugName = item.Name;
                drug.drugBarcode = item.Barcode;
                drug.detail = new List<ITSAllDrugListStatusDetail>();
                BindingList<StockTransaction.GetPTSInByMaterial_Class> stockTrxList = StockTransaction.GetPTSInByMaterial(item.ObjectID.Value);
                foreach (StockTransaction.GetPTSInByMaterial_Class trx in stockTrxList)
                {
                    ITSAllDrugListStatusDetail detail = new ITSAllDrugListStatusDetail();
                    detail.lotNO = trx.LotNo;
                    detail.serialNo = trx.SerialNo;
                    BindingList<ITSSendTransaction.GetITSTrx_Class> sendTransaction = ITSSendTransaction.GetITSTrx(trx.ObjectID.Value);
                    if (sendTransaction.Count > 0)
                    {
                        if (sendTransaction[0].CurrentStateDefID == ITSSendTransaction.States.Cancelled)
                            detail.status = "Gönderim İptal Edildi.";
                        else
                            detail.status = "Gönderildi";
                    }
                    else
                    {
                        detail.status = "-";
                    }
                    drug.detail.Add(detail);
                }

                if (drug.detail.Count > 0)
                    drugLists.Add(drug);
            }
            return drugLists;
        }

        public class PricingDetailDVO
        {
            public PricingDetailDefinition oldPricingDetailDefinition { get; set; }
            public PricingDetailDefinition newPricingDetailDefinition { get; set; }
        }


        public List<PricingDetailDVO> PricingDetailDefinitionForMedicine(TTObjectContext context, MedulaYardimciIslemler.ilacListDVO ilacListDVO, DrugDefinition drugDefinition)
        {
            DateTime nowTime = Common.RecTime();
            List<PricingDetailDVO> pddReturnMedicineList = new List<PricingDetailDVO>();
            IBindingList drugList = context.QueryObjects("DRUGDEFINITION", "BARCODE = '" + ilacListDVO.barkod + "'");
            foreach (DrugDefinition drug in drugList)
            {
                drug.OutpatientReportType = (DrugReportType)(Convert.ToInt32(ilacListDVO.ayaktanOdenme));
                drug.InpatientReportType = (DrugReportType)(Convert.ToInt32(ilacListDVO.yatanOdenme));
                if (drug.CurrentPrice != ilacListDVO.ilacFiyatlari[0].fiyat)
                {
                    PricingDetailDVO pricingDetailDVO = new PricingDetailDVO();
                    DateTime nD = ((DateTime)Convert.ToDateTime(ilacListDVO.ilacFiyatlari[0].gecerlilikTarihi)).AddDays(-1);
                    MaterialPrice oldMaterialPrice = drug.MaterialPrices.Where(x => x.PricingDetail.DateEnd < nowTime &&
                                                                               x.PricingDetail.DateEnd > nowTime &&
                                                                               x.PricingDetail.ExternalCode == ilacListDVO.barkod &&
                                                                               x.PricingDetail.PricingList.ObjectID.ToString() == "57c5a43f-2083-433a-9f05-94c49c284436").FirstOrDefault();
                    if (oldMaterialPrice != null)
                    {
                        oldMaterialPrice.PricingDetail.DateEnd = new DateTime(nD.Year, nD.Month, nD.Day, 23, 59, 59);
                        pricingDetailDVO.oldPricingDetailDefinition = oldMaterialPrice.PricingDetail;
                    }
                    else
                        pricingDetailDVO.oldPricingDetailDefinition = null;

                    drug.CurrentPrice = ilacListDVO.ilacFiyatlari[0].fiyat;

                    if (drug.CurrentPrice >= 15.03)
                    {
                        drugDefinition.Discount = ilacListDVO.ilacIndirimleri[0].indirimOrani1 / 100;
                        drug.Discount = ilacListDVO.ilacIndirimleri[0].indirimOrani1 / 100;
                    }
                    else if (drug.CurrentPrice >= 9.99 && drugDefinition.CurrentPrice <= 15.02)
                    {
                        drugDefinition.Discount = ilacListDVO.ilacIndirimleri[0].indirimOrani2 / 100;
                        drug.Discount = ilacListDVO.ilacIndirimleri[0].indirimOrani2 / 100;
                    }
                    else if (drug.CurrentPrice >= 5.23 && drugDefinition.CurrentPrice <= 9.98)
                    {
                        drugDefinition.Discount = ilacListDVO.ilacIndirimleri[0].indirimOrani3 / 100;
                        drug.Discount = ilacListDVO.ilacIndirimleri[0].indirimOrani3 / 100;
                    }
                    else if (drug.CurrentPrice <= 5.22)
                    {
                        drugDefinition.Discount = ilacListDVO.ilacIndirimleri[0].indirimOrani4 / 100;
                        drug.Discount = ilacListDVO.ilacIndirimleri[0].indirimOrani4 / 100;
                    }

                    double discount = Math.Round(drug.Discount.Value, 2, MidpointRounding.AwayFromZero);

                    double packageAmount = 1;
                    if (drug.PackageAmount != null && drug.PackageAmount != 0)
                        packageAmount = drug.PackageAmount.Value;

                    Currency dumyUnitPrice = (Currency)(drug.CurrentPrice * (1 - drug.Discount)) / packageAmount;
                    Currency UnitPrice = Math.Round((double)dumyUnitPrice, 2, MidpointRounding.AwayFromZero);
                    Currency PriceWithOutDiscount = Math.Round((drug.CurrentPrice.Value / packageAmount), 2, MidpointRounding.AwayFromZero);

                    PricingDetailDefinition pdd = new PricingDetailDefinition(context);
                    pdd.DateStart = Convert.ToDateTime(ilacListDVO.ilacFiyatlari[0].gecerlilikTarihi);
                    pdd.DateEnd = new DateTime(2100, 1, 1, 0, 0, 0);
                    pdd.Description = ilacListDVO.ilacAdi;
                    pdd.CurrencyType = (CurrencyTypeDefinition)context.GetObject(new Guid("e3a4f2d5-4f74-406c-8258-37316ea8e9d1"), typeof(CurrencyTypeDefinition).Name);
                    pdd.PricingList = (PricingListDefinition)context.GetObject(new Guid("57c5a43f-2083-433a-9f05-94c49c284436"), typeof(PricingListDefinition).Name);
                    pdd.PricingListGroup = (PricingListGroupDefinition)context.GetObject(new Guid("b3e200fb-9caa-405d-9d92-01f75948b452"), typeof(PricingListGroupDefinition).Name);
                    pdd.Price = UnitPrice;
                    pdd.ExternalCode = ilacListDVO.barkod;
                    pdd.DiscountPercent = discount;
                    pdd.PriceWithOutDiscount = PriceWithOutDiscount;

                    MaterialPrice materialPrice = new MaterialPrice(context);
                    materialPrice.Material = drug;
                    materialPrice.PricingDetail = pdd;

                    string ayaktanOdeme = ilacListDVO.ayaktanOdenme;
                    string yatanOdeme = ilacListDVO.yatanOdenme;

                    pricingDetailDVO.newPricingDetailDefinition = pdd;
                    pddReturnMedicineList.Add(pricingDetailDVO);
                }

                else
                {
                    drug.CurrentPrice = ilacListDVO.ilacFiyatlari[0].fiyat;
                    if (drug.CurrentPrice >= 15.03)
                    {
                        drugDefinition.Discount = ilacListDVO.ilacIndirimleri[0].indirimOrani1 / 100;
                        drug.Discount = ilacListDVO.ilacIndirimleri[0].indirimOrani1 / 100;
                    }
                    else if (drug.CurrentPrice >= 9.99 && drugDefinition.CurrentPrice <= 15.02)
                    {
                        drugDefinition.Discount = ilacListDVO.ilacIndirimleri[0].indirimOrani2 / 100;
                        drug.Discount = ilacListDVO.ilacIndirimleri[0].indirimOrani2 / 100;
                    }
                    else if (drug.CurrentPrice >= 5.23 && drugDefinition.CurrentPrice <= 9.98)
                    {
                        drugDefinition.Discount = ilacListDVO.ilacIndirimleri[0].indirimOrani3 / 100;
                        drug.Discount = ilacListDVO.ilacIndirimleri[0].indirimOrani3 / 100;
                    }
                    else if (drug.CurrentPrice <= 5.22)
                    {
                        drugDefinition.Discount = ilacListDVO.ilacIndirimleri[0].indirimOrani4 / 100;
                        drug.Discount = ilacListDVO.ilacIndirimleri[0].indirimOrani4 / 100;
                    }

                    double discount = Math.Round(drug.Discount.Value, 2, MidpointRounding.AwayFromZero);

                    double packageAmount = 1;
                    if (drug.PackageAmount != null && drug.PackageAmount != 0)
                        packageAmount = drug.PackageAmount.Value;
                    Currency dumyUnitPrice = (Currency)(drug.CurrentPrice * (1 - drug.Discount)) / packageAmount;
                    Currency oldUnitPricex = Math.Round((double)dumyUnitPrice, 2, MidpointRounding.AwayFromZero);
                    var existMaterialPrice = drug.MaterialPrices.Where(x => x.PricingDetail.Price == oldUnitPricex).ToList();
                    if (existMaterialPrice.Count == 0)
                    {
                        PricingDetailDVO pricingDetailDVO = new PricingDetailDVO();
                        DateTime nD = ((DateTime)Convert.ToDateTime(ilacListDVO.ilacFiyatlari[0].gecerlilikTarihi)).AddDays(-1);
                        MaterialPrice oldMaterialPrice = drug.MaterialPrices.Where(x =>
                                                                                   x.PricingDetail.DateEnd > nowTime &&
                                                                                   x.PricingDetail.ExternalCode == ilacListDVO.barkod &&
                                                                                   x.PricingDetail.PricingList.ObjectID.ToString() == "57c5a43f-2083-433a-9f05-94c49c284436").OrderByDescending(x => x.LastUpdate).FirstOrDefault();
                        if (oldMaterialPrice != null)
                        {
                            oldMaterialPrice.PricingDetail.DateEnd = new DateTime(nD.Year, nD.Month, nD.Day, 23, 59, 59);
                            pricingDetailDVO.oldPricingDetailDefinition = oldMaterialPrice.PricingDetail;
                        }
                        else
                            pricingDetailDVO.oldPricingDetailDefinition = null;

                        Currency PriceWithOutDiscount = Math.Round((drug.CurrentPrice.Value / packageAmount), 2, MidpointRounding.AwayFromZero);
                        PricingDetailDefinition pdd = new PricingDetailDefinition(context);
                        pdd.DateStart = Convert.ToDateTime(ilacListDVO.ilacFiyatlari[0].gecerlilikTarihi);
                        pdd.DateEnd = new DateTime(2100, 1, 1, 0, 0, 0);
                        pdd.Description = ilacListDVO.ilacAdi;
                        pdd.CurrencyType = (CurrencyTypeDefinition)context.GetObject(new Guid("e3a4f2d5-4f74-406c-8258-37316ea8e9d1"), typeof(CurrencyTypeDefinition).Name);
                        pdd.PricingList = (PricingListDefinition)context.GetObject(new Guid("57c5a43f-2083-433a-9f05-94c49c284436"), typeof(PricingListDefinition).Name);
                        pdd.PricingListGroup = (PricingListGroupDefinition)context.GetObject(new Guid("b3e200fb-9caa-405d-9d92-01f75948b452"), typeof(PricingListGroupDefinition).Name);
                        pdd.Price = oldUnitPricex;
                        pdd.ExternalCode = ilacListDVO.barkod;
                        pdd.DiscountPercent = discount;
                        pdd.PriceWithOutDiscount = PriceWithOutDiscount;

                        MaterialPrice materialPrice = new MaterialPrice(context);
                        materialPrice.Material = drug;
                        materialPrice.PricingDetail = pdd;

                        string ayaktanOdeme = ilacListDVO.ayaktanOdenme;
                        string yatanOdeme = ilacListDVO.yatanOdenme;

                        pricingDetailDVO.newPricingDetailDefinition = pdd;
                        pddReturnMedicineList.Add(pricingDetailDVO);
                    }

                }
            }
            return pddReturnMedicineList;
        }

    }
}