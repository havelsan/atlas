
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
    /// Miad Güncelleme İşlemi (Çıkış)
    /// </summary>
    public  partial class ExtendExpDateOut : BaseChattelDocument, IAutoDocumentNumber, ICheckStockActionOutDetail, IStockOutTransaction
    {

        #region Methods

        private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        {
            get
            {
                Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> outRecordLogs = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                foreach (ExtendExpDateOutDetail detail in ExtendExpDateOutDetails)
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
        #region ICheckStockActionOutDetail Members
        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        #endregion
        #region IStockOutTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion
        #endregion
    }
}