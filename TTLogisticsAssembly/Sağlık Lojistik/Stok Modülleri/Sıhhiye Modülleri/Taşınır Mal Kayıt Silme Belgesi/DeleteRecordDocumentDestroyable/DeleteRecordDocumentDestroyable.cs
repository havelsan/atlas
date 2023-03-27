
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
    /// Kayıt Silme Belgesi - Yok Edilen için kullanılan temel sınıftır
    /// </summary>
    public partial class DeleteRecordDocumentDestroyable : BaseDeleteRecordDocument, IStockOutTransaction, IAutoDocumentNumber, IDeleteRecordDocumentDestroyable, IAutoDocumentRecordLog
    {
        public partial class GetDeleteRecordDocDestroyableCensusReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class CensusReportNQL_DeleteRecordDocument_Class : TTReportNqlObject
        {
        }

        public partial class DeleteRecordDocumentDestroyableDestroyedReportRQ_Class : TTReportNqlObject
        {
        }

        protected void PreTransition_MaterialCheck2Approval()
        {
            // From State : MaterialCheck   To State : Approval
            #region PreTransition_MaterialCheck2Approval


            bool inspection = true;
            foreach (DeleteRecordDocumentDestroyableMaterialOut material in DeleteRecordDocumentDestroyableOutMaterials)
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

        protected void PreTransition_MaterialCheck2DeleteRecordInspection()
        {
            // From State : MaterialCheck   To State : DeleteRecordInspection
            #region PreTransition_MaterialCheck2DeleteRecordInspection

            CreateStockActionInspection();
            bool approval = false;
            foreach (DeleteRecordDocumentDestroyableMaterialOut material in DeleteRecordDocumentDestroyableOutMaterials)
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
        protected void PreTransition_StockCardRegistry2Completed()
        {
            // From State : Registry   To State : Completed
            #region PreTransition_StockCardRegistry2Completed();
            CheckStockActionOutDetails();
            #endregion PreTransition_StockCardRegistry2Completed();
        }


        #region Methods

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

        private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        {
            get
            {
                Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> outRecordLogs = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                foreach (DeleteRecordDocumentDestroyableMaterialOut detail in DeleteRecordDocumentDestroyableOutMaterials)
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

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DeleteRecordDocumentDestroyable).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DeleteRecordDocumentDestroyable.States.MaterialCheck && toState == DeleteRecordDocumentDestroyable.States.Approval)
                PreTransition_MaterialCheck2Approval();
            else if (fromState == DeleteRecordDocumentDestroyable.States.MaterialCheck && toState == DeleteRecordDocumentDestroyable.States.DeleteRecordInspection)
                PreTransition_MaterialCheck2DeleteRecordInspection();
            else if (fromState == DeleteRecordDocumentDestroyable.States.StockCardRegistry && toState == DeleteRecordDocumentDestroyable.States.Completed)
                PreTransition_StockCardRegistry2Completed();
        }

    }
}