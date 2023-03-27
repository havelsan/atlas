
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


namespace TTObjectClasses
{
    /// <summary>
    /// Kayıt Silme Belgesi - Hek Edilen için kullanılan temel sınıftır
    /// </summary>
    public  partial class DeleteRecordDocumentWaste : BaseDeleteRecordDocument, IStockOutTransaction, IAutoDocumentNumber, IDeleteRecordDocumentWaste
    {
        protected void PreTransition_MaterialCheck2DeleteRecordInspection()
        {
            // From State : MaterialCheck   To State : DeleteRecordInspection
#region PreTransition_MaterialCheck2DeleteRecordInspection
            
            
            bool approval = false;
            foreach (DeleteRecordDocumentWasteMaterialOut material in DeleteRecordDocumentWasteOutMaterials )
            {
                if (material.DeleteRecordReason == DeleteRecordReasonEnum.Hibe)
                {
                    approval = true;
                    break;
                }
            }
            if (approval)
            {
                throw new TTException(TTUtils.CultureService.GetText("M26816", "Seçilen malzemeler içinde Hibe olduğu için muayene işlemine gönderemezsiniz."));
            }

#endregion PreTransition_MaterialCheck2DeleteRecordInspection
        }

        protected void PreTransition_MaterialCheck2Approval()
        {
            // From State : MaterialCheck   To State : Approval
#region PreTransition_MaterialCheck2Approval
            
            
            bool inspection = true;
            foreach (DeleteRecordDocumentWasteMaterialOut material in DeleteRecordDocumentWasteOutMaterials)
            {
                if (material.DeleteRecordReason == DeleteRecordReasonEnum.Hibe)
                {
                    inspection = false;
                    break;
                }
            }
            if (inspection)
            {
                throw new TTException(TTUtils.CultureService.GetText("M26817", "Seçilen malzemeler içinde Hibe olmadığı için saymanlık onayına gönderemezsiniz."));
            }

#endregion PreTransition_MaterialCheck2Approval
        }

        #region Methods


        private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        {
            get
            {
                Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> outRecordLogs = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                foreach (DeleteRecordDocumentWasteMaterialOut detail in DeleteRecordDocumentWasteOutMaterials)
                {
                    foreach (StockTransaction outTrx in detail.StockTransactions.Where(d => d.CurrentStateDefID == StockTransaction.States.Completed).ToList())
                    {
                        if (outTrx.InOut == TransactionTypeEnum.Out)
                        {
                            if (outTrx.BudgetTypeDefinition.MKYS_Butce == null)
                                throw new TTException(outTrx.BudgetTypeDefinition.Name + " bütcesi MKYS ile eşleştirilmemiştir. Lütfen eşleştirip işleme öyle devam ediniz.");
                            MKYS_EButceTurEnum butce = (MKYS_EButceTurEnum)outTrx.BudgetTypeDefinition.MKYS_Butce;
                            if (outRecordLogs.ContainsKey(butce))
                            {
                                if (outRecordLogs[butce].Contains(detail) == false)
                                    outRecordLogs[butce].Add(detail);
                            }
                            else
                            {
                                List<StockActionDetail> dets = new List<StockActionDetail>();
                                dets.Add(detail);
                                outRecordLogs.Add(butce, dets);
                            }
                        }
                    }
                }

                if (outRecordLogs.Count > 0)
                {
                    _documentRecordLogContents = new List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent>();
                    foreach (KeyValuePair<MKYS_EButceTurEnum, List<StockActionDetail>> outLog in outRecordLogs)
                    {
                        string place = ((MainStoreDefinition)Store).Accountancy.AccountancyNO + " " + ((MainStoreDefinition)Store).Accountancy.Name;
                        AutoDocumentRecordLogAttribute.DocumentRecordLogContent logContent = new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.Out, this, outLog.Value.Count, place, outLog.Key);

                        _documentRecordLogContents.Add(logContent);
                    }
                }
                return _documentRecordLogContents;
            }
        }



        public void CreateDeleteRecordDocumentWaste(ReturningDocument returningDocument, IDeleteRecordDocumentWaste IdeleteRecordDocumentWaste)
        {
            DeleteRecordDocumentWaste deleteRecordDocumentWaste = (DeleteRecordDocumentWaste)IdeleteRecordDocumentWaste;
            deleteRecordDocumentWaste.Store = returningDocument.DestinationStore;
            AccountingTerm openAccountingTerm = ((MainStoreDefinition)returningDocument.DestinationStore).Accountancy.GetOpenAccountingTerm();
            deleteRecordDocumentWaste.AccountingTerm = openAccountingTerm;
            deleteRecordDocumentWaste.AdditionalDocumentCount = 1;
            deleteRecordDocumentWaste.Description = returningDocument.Description;
            deleteRecordDocumentWaste.ReturningDocument = returningDocument;
            TTObjectContext context = new TTObjectContext(true);
            if(returningDocument.RepairObjectID != null)
            {
                Repair repair = (Repair)context.GetObject((Guid)returningDocument.RepairObjectID, typeof(Repair));
                deleteRecordDocumentWaste.TechnicalReport = repair.HEKReportDescription;
            }
            if (returningDocument.MaterialRepairObjectID != null)
            {
                MaterialRepair materialRepair = (MaterialRepair)context.GetObject((Guid)returningDocument.MaterialRepairObjectID, typeof(MaterialRepair));
                deleteRecordDocumentWaste.TechnicalReport = materialRepair.HEKReportDescription;
            }

            deleteRecordDocumentWaste.CurrentStateDefID = DeleteRecordDocumentWaste.States.New;
            foreach (ReturningDocumentMaterial material in returningDocument.ReturningDocumentMaterials)
            {
                DeleteRecordDocumentWasteMaterialOut deleteRecordDocumentWasteMaterialOut = new DeleteRecordDocumentWasteMaterialOut(returningDocument.ObjectContext);
                deleteRecordDocumentWasteMaterialOut.StockAction = deleteRecordDocumentWaste;
                deleteRecordDocumentWasteMaterialOut.Amount = material.Amount;
                deleteRecordDocumentWasteMaterialOut.DeleteRecordReason = DeleteRecordReasonEnum.Nay;
                deleteRecordDocumentWasteMaterialOut.Material = material.Material;
                if (material.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                {
                    foreach (FixedAssetOutDetail outDetail in material.FixedAssetOutDetails)
                    {
                        FixedAssetOutDetail fixedAssetOutDetail = new FixedAssetOutDetail(returningDocument.ObjectContext);
                        fixedAssetOutDetail.FixedAssetMaterialDefinition = outDetail.FixedAssetMaterialDefinition;
                        fixedAssetOutDetail.StockActionDetail = deleteRecordDocumentWasteMaterialOut;
                    }
                }
                deleteRecordDocumentWasteMaterialOut.StockLevelType = material.StockLevelType;
            }
            TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25327", "Bu malzeme için Kayıt Silme Belgesi - Hek Edilen işlemi oluşturulmuştur."));
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
        #region IStockOutTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion
        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DeleteRecordDocumentWaste).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DeleteRecordDocumentWaste.States.MaterialCheck && toState == DeleteRecordDocumentWaste.States.DeleteRecordInspection)
                PreTransition_MaterialCheck2DeleteRecordInspection();
            else if (fromState == DeleteRecordDocumentWaste.States.MaterialCheck && toState == DeleteRecordDocumentWaste.States.Approval)
                PreTransition_MaterialCheck2Approval();
        }

    }
}