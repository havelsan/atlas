
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;
using TTObjectClasses.DTOs;

namespace TTObjectClasses
{
    /// <summary>
    /// Bağış Yardım
    /// </summary>
    public partial class GrantMaterial : BaseChattelDocument, IAutoDocumentNumber, ICheckStockActionInDetail, IStockInTransaction, IAutoDocumentRecordLog
    {

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_Completed2Cancelled
            MKYSControl = false;
            #endregion PreTransition_Completed2Cancelled
        }
        protected void PreTransition_New2Approval()
        {
            // From State : New   To State : Approval
            #region PreTransition_New2Approval
            if (String.IsNullOrEmpty(MaterialGranttedBy))
            {
                throw new Exception(TTUtils.CultureService.GetText("M25223", "Bağış yapan kurum/ kişi boş geçilemez"));
            }
            if (String.IsNullOrEmpty(GranttedByUniqNo))
            {
                throw new Exception(TTUtils.CultureService.GetText("M25224", "Bağış yapan tc/kurum vergi no boş geçilemez"));
            }
            #endregion PreTransition_New2Approval
        }
        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
            #region PreTransition_New2Completed
            if (String.IsNullOrEmpty(MaterialGranttedBy))
            {
                throw new Exception(TTUtils.CultureService.GetText("M25223", "Bağış yapan kurum/ kişi boş geçilemez"));
            }
            if (String.IsNullOrEmpty(GranttedByUniqNo))
            {
                throw new Exception(TTUtils.CultureService.GetText("M25224", "Bağış yapan tc/kurum vergi no boş geçilemez"));
            }
            #endregion PreTransition_New2Completed
        }



        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(GrantMaterial).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == GrantMaterial.States.Completed && toState == GrantMaterial.States.Cancelled)
                PreTransition_Completed2Cancelled();
            if (fromState == GrantMaterial.States.New && toState == GrantMaterial.States.Approved)
                PreTransition_New2Approval();
            if (fromState == GrantMaterial.States.New && toState == GrantMaterial.States.Completed)
                PreTransition_New2Completed();

        }

        #region Methods

        public static string CreateFromDTO(StockActionDTO model)
        {
            string result = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                GrantMaterial stockAction;
                if (model.StockActionObjectId.HasValue)
                {
                    stockAction = objectContext.GetObject<GrantMaterial>(model.StockActionObjectId.Value);
                }
                else
                {
                    stockAction = new GrantMaterial(objectContext);
                }
                stockAction.MKYS_EAlimYontemi = (MKYS_EAlimYontemiEnum)model.BuyMethod;
                stockAction.BudgetTypeDefinition = objectContext.GetObject<BudgetTypeDefinition>(model.BudgetType.Value);
                stockAction.MKYS_TeslimAlanObjID = model.Deliverer;
                stockAction.MKYS_TeslimEdenObjID = model.TakenBy;
                stockAction.Description = model.Description;
                stockAction.Store = objectContext.GetObject<Store>(model.MainStoreId);
                stockAction.TransactionDate = model.TicketDate;
                stockAction.MKYS_ETedarikTuru = (MKYS_ETedarikTurEnum)model.SupplyType;
                stockAction.MaterialGranttedBy = model.Company;
                stockAction.GranttedByUniqNo = ""; //TODO TC kimlik no getirilecek.
                stockAction.MKYS_EMalzemeGrup = model.MaterialGroup;

                foreach (var materialDTO in model.MaterialList)
                {
                    GrantMaterialDetail materialDetail;
                    
                    if (materialDTO.ObjectID != null && materialDTO.ObjectID != Guid.Empty)
                    {
                        materialDetail = objectContext.GetObject<GrantMaterialDetail>(materialDTO.ObjectID);
                    }
                    else
                    {
                        materialDetail = new GrantMaterialDetail(objectContext);
                    }


                    materialDetail.Material = objectContext.GetObject<Material>(materialDTO.MaterialID);
                    materialDetail.Amount = materialDTO.Amount;
                    materialDetail.VatRate = Convert.ToInt64(materialDTO.VatRate);
                    materialDetail.DiscountRate = materialDTO.DiscountRate;
                    materialDetail.DiscountAmount = materialDTO.DiscountAmount;
                    materialDetail.NotDiscountedUnitPrice = materialDTO.NotDiscountedUnitPrice; //TODO
                    materialDetail.Price = materialDTO.Price;
                    materialDetail.UnitPrice = materialDTO.UnitPrice; //TODO
                    materialDetail.ExpirationDate = materialDTO.ExpirationDate;
                    materialDetail.LotNo = materialDTO.LotNo;
                    materialDetail.StockLevelType = StockLevelType.NewStockLevel;
                    materialDetail.Status = StockActionDetailStatusEnum.New;
                    materialDetail.RetrievalYear = Common.RecTime().Year;
                    stockAction.GrantMaterialDetails.Add(materialDetail);
                }
                stockAction.CurrentStateDefID = States.New;
                objectContext.Save();
                if (model.RecordType == 1)
                {
                    stockAction.CurrentStateDefID = States.Completed;
                    objectContext.Save();
                    if (model.SendToMKYS)
                    {
                        result = stockAction.SendMKYSForInputDocument(model.MKYSPassword);
                    }
                    AfterContextSaveScript(stockAction);
                }
            }
            return result;
        }

        public static void AfterContextSaveScript(GrantMaterial stockAction)
        {
        }

        private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        {
            get
            {

                Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> inRecordLogs = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                foreach (GrantMaterialDetail detail in GrantMaterialDetails)
                {
                    foreach (StockTransaction inTrx in detail.StockTransactions.Where(d => d.CurrentStateDefID == StockTransaction.States.Completed).ToList())
                    {
                        if (inTrx.InOut == TransactionTypeEnum.In)
                        {
                            if (inTrx.BudgetTypeDefinition.MKYS_Butce == null)
                                throw new TTException(inTrx.BudgetTypeDefinition.Name + " bütcesi MKYS ile eşleştirilmemiştir. Lütfen eşleştirip işleme öyle devam ediniz.");
                            MKYS_EButceTurEnum butce = (MKYS_EButceTurEnum)inTrx.BudgetTypeDefinition.MKYS_Butce;
                            if (inRecordLogs.ContainsKey(butce))
                            {
                                if (inRecordLogs[butce].Contains(detail) == false)
                                    inRecordLogs[butce].Add(detail);
                            }
                            else
                            {
                                List<StockActionDetail> dets = new List<StockActionDetail>();
                                dets.Add(detail);
                                inRecordLogs.Add(butce, dets);
                            }
                        }
                    }
                }

                if (inRecordLogs.Count > 0)
                {
                    _documentRecordLogContents = new List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent>();
                    foreach (KeyValuePair<MKYS_EButceTurEnum, List<StockActionDetail>> inLog in inRecordLogs)
                    {
                        string place = ((MainStoreDefinition)Store).Accountancy.AccountancyNO + " " + ((MainStoreDefinition)Store).Accountancy.Name;
                        AutoDocumentRecordLogAttribute.DocumentRecordLogContent logContent = new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.In, this, inLog.Value.Count, place, inLog.Key);

                        _documentRecordLogContents.Add(logContent);
                    }
                }
                return _documentRecordLogContents;
            }
        }

        #region IAutoDocumentRecordLog Member
        public Guid GetObjectID()
        {
            return ObjectID;
        }

        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> GetDocumentRecordLogContents()
        {
            return DocumentRecordLogContents;
        }
        #endregion
        #region ICheckStockActionInDetail Members
        public StockActionDetailIn.ChildStockActionDetailInCollection GetStockActionInDetails()
        {
            return StockActionInDetails;
        }
        #endregion
        #region IGrantMaterial Members
        public string GetMaterialGranttedBy()
        {
            return MaterialGranttedBy;
        }

        public void SetMaterialGranttedBy(string value)
        {
            MaterialGranttedBy = value;
        }

        public string GetGranttedByUniqNo()
        {
            return GranttedByUniqNo;
        }

        public void SetGranttedByUniqNo(string value)
        {
            GranttedByUniqNo = value;
        }
        #endregion
        #region IStockInTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Store GetStore()
        {
            return Store;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion
        #endregion Methods


    }

}