
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
    /// Mal Durumu Değiştirme
    /// </summary>
    public partial class ChangeStockLevelType : StockAction, IChangeStockLevelType, IStockOutTransaction
    {

        protected void PreTransition_Completed2Cancel()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_Completed2Cancel

            MKYSControl = false;

            #endregion PreTransition_Completed2Cancel
        }

        protected void PreTransition_Registry2Completed()
        {
            // From State : Registry   To State : Completed
            #region PreTransition_Registry2Completed

            if (BudgetTypeDefinition != null)
            {
                CheckStockActionOutDetails();
            }
            else
                throw new Exception(TTUtils.CultureService.GetText("M25353", "Bütçe türünü seçmeden işleme devam edemesssiniz."));
            #endregion PreTransition_Registry2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ChangeStockLevelType).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ChangeStockLevelType.States.Registry && toState == ChangeStockLevelType.States.Completed)
                PreTransition_Registry2Completed();
            if (fromState == ChangeStockLevelType.States.Completed && toState == ChangeStockLevelType.States.Cancel)
                PreTransition_Completed2Cancel();
        }


        #region Methods

        private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        {
            get
            {

                Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> outRecordLogs = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                foreach (ChangeStockLevelTypeDetail detail in ChangeStockLevelTypeDetails)
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


    }
}