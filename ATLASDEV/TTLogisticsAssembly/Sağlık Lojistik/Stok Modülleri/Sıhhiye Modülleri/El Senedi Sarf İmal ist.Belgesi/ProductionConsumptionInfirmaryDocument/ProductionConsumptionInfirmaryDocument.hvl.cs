
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProductionConsumptionInfirmaryDocument")] 

    /// <summary>
    /// El Senedi Sarf İmal İstihsal Belgesi
    /// </summary>
    public  partial class ProductionConsumptionInfirmaryDocument : StockAction, IStockConsumptionTransaction, IProductionConsumptionInfirmaryDocument
    {
        public class ProductionConsumptionInfirmaryDocumentList : TTObjectCollection<ProductionConsumptionInfirmaryDocument> { }
                    
        public class ChildProductionConsumptionInfirmaryDocumentCollection : TTObject.TTChildObjectCollection<ProductionConsumptionInfirmaryDocument>
        {
            public ChildProductionConsumptionInfirmaryDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProductionConsumptionInfirmaryDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProductionConsumptionInfirmaryCensusReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string RegistrationNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTIONCONSUMPTIONINFIRMARYDOCUMENT"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProductionConsumptionInfirmaryCensusReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProductionConsumptionInfirmaryCensusReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProductionConsumptionInfirmaryCensusReportQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("72f2fa1e-4067-48d0-80bb-327cd5ad957a"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("0b39fe55-36de-4017-8984-b639cb4016e0"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("2e86d539-0fa2-4771-8228-e3eb4750b11d"); } }
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("3ebadb14-972c-4985-b374-df6bc095a06c"); } }
        }

        public static BindingList<ProductionConsumptionInfirmaryDocument.GetProductionConsumptionInfirmaryCensusReportQuery_Class> GetProductionConsumptionInfirmaryCensusReportQuery(string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTIONCONSUMPTIONINFIRMARYDOCUMENT"].QueryDefs["GetProductionConsumptionInfirmaryCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<ProductionConsumptionInfirmaryDocument.GetProductionConsumptionInfirmaryCensusReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProductionConsumptionInfirmaryDocument.GetProductionConsumptionInfirmaryCensusReportQuery_Class> GetProductionConsumptionInfirmaryCensusReportQuery(TTObjectContext objectContext, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTIONCONSUMPTIONINFIRMARYDOCUMENT"].QueryDefs["GetProductionConsumptionInfirmaryCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<ProductionConsumptionInfirmaryDocument.GetProductionConsumptionInfirmaryCensusReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ProductionConsumptionInfirmaryDocumentOutMaterials = new ProductionConsumptionInfirmaryDocumentMaterialOut.ChildProductionConsumptionInfirmaryDocumentMaterialOutCollection(_StockActionDetails, "ProductionConsumptionInfirmaryDocumentOutMaterials");
            _ProductionConsumptionInfirmaryDocumentInMaterials = new ProductionConsumptionInfirmaryDocumentMaterialIn.ChildProductionConsumptionInfirmaryDocumentMaterialInCollection(_StockActionDetails, "ProductionConsumptionInfirmaryDocumentInMaterials");
        }

        private ProductionConsumptionInfirmaryDocumentMaterialOut.ChildProductionConsumptionInfirmaryDocumentMaterialOutCollection _ProductionConsumptionInfirmaryDocumentOutMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ProductionConsumptionInfirmaryDocumentMaterialOut.ChildProductionConsumptionInfirmaryDocumentMaterialOutCollection ProductionConsumptionInfirmaryDocumentOutMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ProductionConsumptionInfirmaryDocumentOutMaterials;
            }            
        }

        private ProductionConsumptionInfirmaryDocumentMaterialIn.ChildProductionConsumptionInfirmaryDocumentMaterialInCollection _ProductionConsumptionInfirmaryDocumentInMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ProductionConsumptionInfirmaryDocumentMaterialIn.ChildProductionConsumptionInfirmaryDocumentMaterialInCollection ProductionConsumptionInfirmaryDocumentInMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ProductionConsumptionInfirmaryDocumentInMaterials;
            }            
        }

        protected ProductionConsumptionInfirmaryDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProductionConsumptionInfirmaryDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProductionConsumptionInfirmaryDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProductionConsumptionInfirmaryDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProductionConsumptionInfirmaryDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCTIONCONSUMPTIONINFIRMARYDOCUMENT", dataRow) { }
        protected ProductionConsumptionInfirmaryDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCTIONCONSUMPTIONINFIRMARYDOCUMENT", dataRow, isImported) { }
        public ProductionConsumptionInfirmaryDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProductionConsumptionInfirmaryDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProductionConsumptionInfirmaryDocument() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}