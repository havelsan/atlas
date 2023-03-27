
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
    public partial class StockMerge : StockAction, IStockMergeTransaction, IStockMerge, IAutoDocumentNumber, IAutoDocumentRecordLog
    {
        public partial class CensusReportNQL_StockMerge_Class : TTReportNqlObject
        {
        }

        public partial class StockMergeReportForReportQuery_Class : TTReportNqlObject
        {
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_Completed2Cancelled
            throw new TTException(TTUtils.CultureService.GetText("M25315", "Bu işlem iptal edilemez."));
            #endregion PreTransition_Completed2Cancelled
        }

        protected void UndoTransition_New2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Completed
            #region UndoTransition_New2Completed
            throw new TTException(TTUtils.CultureService.GetText("M25311", "Bu işlem geri alınamaz."));
            #endregion UndoTransition_New2Completed
        }

        #region Methods
        private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        {
            get
            {
                if (StockMergeOutMaterials.Count > 0 || StockMergeInMaterials.Count > 0)
                    _documentRecordLogContents = new List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent>();
                //        if (this.StockMergeOutMaterials.Count > 0)
                //        {
                //            if (this.Store != null && this.DestinationStore == null)
                //                _documentRecordLogContents.Add(new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.Out, this, this.StockMergeOutMaterials.Count, ((MainStoreDefinition)this.Store).Accountancy.AccountancyNO + " " + ((MainStoreDefinition)this.Store).Accountancy.Name));
                //            else
                //                _documentRecordLogContents.Add(new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.Out, this, this.StockMergeOutMaterials.Count, ((MainStoreDefinition)this.DestinationStore).Accountancy.AccountancyNO + " " + ((MainStoreDefinition)this.DestinationStore).Accountancy.Name));
                //        }

                //        if (this.StockMergeInMaterials.Count > 0)
                //        {
                //            if (this.Store != null && this.DestinationStore == null)
                //                _documentRecordLogContents.Add(new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.In, this, this.StockMergeInMaterials.Count, ((MainStoreDefinition)this.Store).Accountancy.AccountancyNO + " " + ((MainStoreDefinition)this.Store).Accountancy.Name));
                //            else
                //                _documentRecordLogContents.Add(new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.In, this, this.StockMergeInMaterials.Count, ((MainStoreDefinition)this.DestinationStore).Accountancy.AccountancyNO + " " + ((MainStoreDefinition)this.DestinationStore).Accountancy.Name));
                //        }
                return _documentRecordLogContents;
            }
        }

        public List<IStockMergeMaterialOut> GetStockMergeOutMaterialsList()
        {
            return GetStockMergeOutMaterials();
        }

        public List<IStockMergeMaterialOut> StockMergeOutMaterialsList
        {
            get
            {
                return GetStockMergeOutMaterials();
            }
        }


        private List<IStockMergeMaterialOut> GetStockMergeOutMaterials()
        {
            List<IStockMergeMaterialOut> stockMergeOutMaterials = new List<IStockMergeMaterialOut>();

            foreach (StockMergeMaterialOut stockMergeMaterialOut in StockMergeOutMaterials)
                stockMergeOutMaterials.Add((IStockMergeMaterialOut)stockMergeMaterialOut);
            return stockMergeOutMaterials;
        }


        public List<IStockMergeMaterialIn> GetStockMergeInMaterialsList()
        {
            return GetStockMergeInMaterials();
        }

        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public List<IStockMergeMaterialIn> StockMergeInMaterialsList
        {
            get
            {
                return GetStockMergeInMaterials();
            }
        }


        private List<IStockMergeMaterialIn> GetStockMergeInMaterials()
        {
            List<IStockMergeMaterialIn> stockMergeInMaterials = new List<IStockMergeMaterialIn>();

            foreach (StockMergeMaterialIn stockMergeMaterialIn in StockMergeInMaterials)
                stockMergeInMaterials.Add((IStockMergeMaterialIn)stockMergeMaterialIn);
            return stockMergeInMaterials;
        }


        public void PrintStateReports()
        {
            //            foreach (TTObjectStateReportDef objectStateReportDef in CurrentStateDef.ReportDefs)
            //            {
            //                TTObjectReportDef objectReportDef = (TTObjectReportDef)objectStateReportDef;
            //
            //                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            //                TTReportTool.PropertyCache<object> newParameterItem = new TTReportTool.PropertyCache<object>();
            //                newParameterItem.Add("Value", ObjectID.ToString(), "T", "TTOBJECTID");
            //                parameters.Add("TTOBJECTID", newParameterItem);
            //
            //                Type reportType = objectReportDef.ReportDef.ModuleDef.AssemblyDef.Assembly.GetType("TTReportClasses.I_" + objectReportDef.ReportDef.CodeName);
            //                TTReportTool.TTReport.PrintReport(parent, reportType, objectReportDef.IsDisplay, objectReportDef.DuplicateCount, parameters);
            //            }
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


        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StockMerge).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == StockMerge.States.Completed && toState == StockMerge.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StockMerge).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == StockMerge.States.New && toState == StockMerge.States.Completed)
                UndoTransition_New2Completed(transDef);
        }


    }
}