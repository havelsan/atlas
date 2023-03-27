
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProductionConsumptionDocument")] 

    /// <summary>
    /// Tüketim, Üretim ve Elde Edilenler Belgesi  için kullanılan temel sınıftır
    /// </summary>
    public  partial class ProductionConsumptionDocument : StockAction, IStockConsumptionTransaction, IAutoDocumentNumber, IStockProductionTransaction, IAutoDocumentRecordLog, IProductionConsumptionDocument
    {
        public class ProductionConsumptionDocumentList : TTObjectCollection<ProductionConsumptionDocument> { }
                    
        public class ChildProductionConsumptionDocumentCollection : TTObject.TTChildObjectCollection<ProductionConsumptionDocument>
        {
            public ChildProductionConsumptionDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProductionConsumptionDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProductionConsumptionDocumentCensusReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTIONCONSUMPTIONDOCUMENT"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProductionConsumptionDocumentCensusReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProductionConsumptionDocumentCensusReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProductionConsumptionDocumentCensusReportQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("c70c7901-462c-42aa-83ac-19c6c9dfccd9"); } }
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid Approval { get { return new Guid("0463dc16-39b5-47d5-98b2-a79219f61b2f"); } }
            public static Guid Cancelled { get { return new Guid("07882f01-b7d0-4663-9ceb-b6a5654dbf21"); } }
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("5cbe2c7a-4c2b-46cc-b047-bf725d580a49"); } }
    /// <summary>
    /// Stok Kart Kayıt
    /// </summary>
            public static Guid StockCardRegistry { get { return new Guid("b98fa875-25e0-4306-929f-d10ced1eca62"); } }
    /// <summary>
    /// Otomatik Oluşturulmuş Belge
    /// </summary>
            public static Guid AutoCreate { get { return new Guid("492bbc9e-450a-475d-9a30-fa2e9e919879"); } }
        }

        public static BindingList<ProductionConsumptionDocument.GetProductionConsumptionDocumentCensusReportQuery_Class> GetProductionConsumptionDocumentCensusReportQuery(string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTIONCONSUMPTIONDOCUMENT"].QueryDefs["GetProductionConsumptionDocumentCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<ProductionConsumptionDocument.GetProductionConsumptionDocumentCensusReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProductionConsumptionDocument.GetProductionConsumptionDocumentCensusReportQuery_Class> GetProductionConsumptionDocumentCensusReportQuery(TTObjectContext objectContext, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTIONCONSUMPTIONDOCUMENT"].QueryDefs["GetProductionConsumptionDocumentCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<ProductionConsumptionDocument.GetProductionConsumptionDocumentCensusReportQuery_Class>(objectContext, queryDef, paramList, pi);
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
    /// Doldurma Tarihi
    /// </summary>
        public DateTime? FillingDate
        {
            get { return (DateTime?)this["FILLINGDATE"]; }
            set { this["FILLINGDATE"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        public Guid? ProductionDepStoreObjectID
        {
            get { return (Guid?)this["PRODUCTIONDEPSTOREOBJECTID"]; }
            set { this["PRODUCTIONDEPSTOREOBJECTID"] = value; }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ProductionConsumptionDocumentInMaterials = new ProductionConsumptionDocumentMaterialIn.ChildProductionConsumptionDocumentMaterialInCollection(_StockActionDetails, "ProductionConsumptionDocumentInMaterials");
            _ProductionConsumptionDocumentOutMaterials = new ProductionConsumptionDocumentMaterialOut.ChildProductionConsumptionDocumentMaterialOutCollection(_StockActionDetails, "ProductionConsumptionDocumentOutMaterials");
        }

        private ProductionConsumptionDocumentMaterialIn.ChildProductionConsumptionDocumentMaterialInCollection _ProductionConsumptionDocumentInMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ProductionConsumptionDocumentMaterialIn.ChildProductionConsumptionDocumentMaterialInCollection ProductionConsumptionDocumentInMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ProductionConsumptionDocumentInMaterials;
            }            
        }

        private ProductionConsumptionDocumentMaterialOut.ChildProductionConsumptionDocumentMaterialOutCollection _ProductionConsumptionDocumentOutMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ProductionConsumptionDocumentMaterialOut.ChildProductionConsumptionDocumentMaterialOutCollection ProductionConsumptionDocumentOutMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ProductionConsumptionDocumentOutMaterials;
            }            
        }

        protected ProductionConsumptionDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProductionConsumptionDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProductionConsumptionDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProductionConsumptionDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProductionConsumptionDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCTIONCONSUMPTIONDOCUMENT", dataRow) { }
        protected ProductionConsumptionDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCTIONCONSUMPTIONDOCUMENT", dataRow, isImported) { }
        public ProductionConsumptionDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProductionConsumptionDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProductionConsumptionDocument() : base() { }

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