
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
    /// Muvakkaten Sayım Düzeltme Belgesi  için kullanılan temel sınıftır
    /// </summary>
    public  partial class ConsignedCensusFixed : StockAction, IStockConsumptionTransaction, IAutoDocumentNumber, IStockProductionTransaction, IAutoDocumentRecordLog, IConsignedCensusFixed
    {
        public partial class ConsignedCensusFixedReportForReportQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        {
            get
            {
               // if (this.ConsignedCensusFixedOutMaterials.Count > 0 || this.ConsignedCensusFixedInMaterials.Count > 0)
                    _documentRecordLogContents = new List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent>();
                //if (this.ConsignedCensusFixedOutMaterials.Count > 0)
                //    _documentRecordLogContents.Add(new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.Out, this, this.ConsignedCensusFixedOutMaterials.Count, ((MainStoreDefinition)this.DestinationStore).Accountancy.AccountancyNO + " " + ((MainStoreDefinition)this.DestinationStore).Accountancy.Name));
                //if (this.ConsignedCensusFixedInMaterials.Count > 0)
                //    _documentRecordLogContents.Add(new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.In, this, this.ConsignedCensusFixedInMaterials.Count, ((MainStoreDefinition)this.DestinationStore).Accountancy.AccountancyNO + " " + ((MainStoreDefinition)this.DestinationStore).Accountancy.Name));
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
        #region IStockConsumptionTransaction Members
        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        #endregion
        #region IStockProductionTransaction Members
        public StockActionDetailIn.ChildStockActionDetailInCollection GetStockActionInDetails()
        {
            return StockActionInDetails;
        }
        #endregion
        #endregion Methods

    }
}