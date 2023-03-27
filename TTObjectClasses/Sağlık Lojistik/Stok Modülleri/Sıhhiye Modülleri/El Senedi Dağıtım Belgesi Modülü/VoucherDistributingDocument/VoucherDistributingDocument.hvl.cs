
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VoucherDistributingDocument")] 

    /// <summary>
    /// El Senedi Dağıtım Belgesi için kullanılan temel sınıftır
    /// </summary>
    public  partial class VoucherDistributingDocument : StockAction, IStockTransferTransaction, IVoucherDistributingDocument
    {
        public class VoucherDistributingDocumentList : TTObjectCollection<VoucherDistributingDocument> { }
                    
        public class ChildVoucherDistributingDocumentCollection : TTObject.TTChildObjectCollection<VoucherDistributingDocument>
        {
            public ChildVoucherDistributingDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVoucherDistributingDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetVoucherDistributingDocumentCensusReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VOUCHERDISTRIBUTINGDOCUMENT"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetVoucherDistributingDocumentCensusReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetVoucherDistributingDocumentCensusReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetVoucherDistributingDocumentCensusReportQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("87beb313-5ab0-4cf9-ba30-6cfd35dcdf54"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("ec9e3d51-eaf8-4749-a1ce-784e48ef7d70"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("5c86a028-f92b-46fb-861d-798e2f4e20b4"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("fc3540f4-694f-49e0-ae23-ff60b68f17dc"); } }
        }

        public static BindingList<VoucherDistributingDocument.GetVoucherDistributingDocumentCensusReportQuery_Class> GetVoucherDistributingDocumentCensusReportQuery(string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VOUCHERDISTRIBUTINGDOCUMENT"].QueryDefs["GetVoucherDistributingDocumentCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<VoucherDistributingDocument.GetVoucherDistributingDocumentCensusReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<VoucherDistributingDocument.GetVoucherDistributingDocumentCensusReportQuery_Class> GetVoucherDistributingDocumentCensusReportQuery(TTObjectContext objectContext, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VOUCHERDISTRIBUTINGDOCUMENT"].QueryDefs["GetVoucherDistributingDocumentCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<VoucherDistributingDocument.GetVoucherDistributingDocumentCensusReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sarf İmal İstihsale
    /// </summary>
        public bool? AutoAddConsumption
        {
            get { return (bool?)this["AUTOADDCONSUMPTION"]; }
            set { this["AUTOADDCONSUMPTION"] = value; }
        }

    /// <summary>
    /// Doldurma Tarihi
    /// </summary>
        public DateTime? FillingDate
        {
            get { return (DateTime?)this["FILLINGDATE"]; }
            set { this["FILLINGDATE"] = value; }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _VoucherDistributingDocumentMaterials = new VoucherDistributingDocumentMaterial.ChildVoucherDistributingDocumentMaterialCollection(_StockActionDetails, "VoucherDistributingDocumentMaterials");
        }

        private VoucherDistributingDocumentMaterial.ChildVoucherDistributingDocumentMaterialCollection _VoucherDistributingDocumentMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public VoucherDistributingDocumentMaterial.ChildVoucherDistributingDocumentMaterialCollection VoucherDistributingDocumentMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _VoucherDistributingDocumentMaterials;
            }            
        }

        protected VoucherDistributingDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VoucherDistributingDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VoucherDistributingDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VoucherDistributingDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VoucherDistributingDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VOUCHERDISTRIBUTINGDOCUMENT", dataRow) { }
        protected VoucherDistributingDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VOUCHERDISTRIBUTINGDOCUMENT", dataRow, isImported) { }
        public VoucherDistributingDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VoucherDistributingDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VoucherDistributingDocument() : base() { }

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